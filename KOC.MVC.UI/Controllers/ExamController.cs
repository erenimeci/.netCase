using HtmlAgilityPack;
using KOC.Business.Abstract.Test;
using KOC.Model.Entities.Other;
using KOC.Model.Entities.Test;
using KOC.MVC.UI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;

namespace KOC.MVC.UI.Controllers
{
    public class ExamController : Controller
    {
        // GET: Exam
        ArticleViewModel articleModel = new ArticleViewModel();

        public ExamController(IExamService examService, IQuestionService questionService)
        {
            _examService = examService;
            _questionService = questionService;
        }

        public ActionResult Index()
        {
            List<SelectListItem> titleList = new List<SelectListItem>();

            var webRequest = HttpWebRequest.Create("https://www.wired.com/feed/rss");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Stream stream = webRequest.GetResponse().GetResponseStream();
            string html = new StreamReader(stream).ReadToEnd();
            stream.Close();

            HtmlDocument someDoc = new HtmlDocument();
            someDoc.LoadHtml(html);

            articleModel.ArticleTitle.Add(new SelectListItem
            {
                Text = "Choose One",
                Value = "Choose One"
            });

            foreach (HtmlNode nodeRss in someDoc.DocumentNode.SelectNodes("rss"))
            {
                foreach (HtmlNode aNode2 in nodeRss.SelectNodes("channel"))
                {
                    foreach (HtmlNode aNode3 in aNode2.SelectNodes("item").Take(5))
                    {
                        articleModel.ArticleTitle.Add(new SelectListItem
                        {
                            Text = aNode3.SelectSingleNode("title").InnerText,
                            Value = aNode3.SelectSingleNode("link").NextSibling.InnerText
                        });
                        Session["Titles"] = articleModel;
                    }
                }
            }
            return View(articleModel);
        }

        [HttpPost]
        public ActionResult Index(FormCollection formcollection)
        {
            string ArticleLink = formcollection["ContentTitle"];


            var webRequest = HttpWebRequest.Create(ArticleLink);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Stream stream = webRequest.GetResponse().GetResponseStream();
            string html = new StreamReader(stream).ReadToEnd();
            stream.Close();


            HtmlDocument someDoc = new HtmlDocument();
            someDoc.LoadHtml(html);
            someDoc.DocumentNode.SelectSingleNode("//*[@id=\"app-root\"]/div/div[6]/div/div[2]/main");

            articleModel = (ArticleViewModel)Session["Titles"];
            articleModel.ArticleContent = someDoc.DocumentNode.SelectSingleNode("//*/article").InnerText;

            foreach (var item in articleModel.ArticleTitle)
            {

                if (item.Value == formcollection["ContentTitle"])
                {
                    item.Selected = true;
                }

            }

            return View(articleModel);

        }


        IExamService _examService;
        IQuestionService _questionService;
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveExam(FormCollection formcollection)
        {
            string examName = formcollection["ExamName"];
            string examContent = formcollection["ExamContent"];

            Exam newExam = new Exam()
            {
                ExamID = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                User = ((KOC.Model.Entities.Login.User)(Session["User"])),
                ExamContent = examContent,
                ExamName = examName,

            };
            _examService.Add(newExam);

            for (int i = 1; i <= 4; i++)
            {
                string questionText = formcollection["question" + i];
                string questionChoice1 = formcollection["question" + i + "Choice" + 1];
                string questionChoice2 = formcollection["question" + i + "Choice" + 2];
                string questionChoice3 = formcollection["question" + i + "Choice" + 3];
                string questionChoice4 = formcollection["question" + i + "Choice" + 4];
                string questionCorreck = formcollection["question" + i + "CorrectChoice"];
                Question newQuestion = new Question()
                {
                    QuestionID = Guid.NewGuid(),
                    ExamID = newExam.ExamID,
                    QuestionText = questionText,
                    choiceFirst = questionChoice1,
                    choiceSecond = questionChoice2,
                    choiceThird = questionChoice3,
                    choiceFourth = questionChoice4,
                    correctChoice = questionCorreck,

                };
                _questionService.Add(newQuestion);
            }

            return RedirectToAction("ListExam", "Exam");
        }

        ExamQuestionViewModel _examQuestionVM = new ExamQuestionViewModel();
        public ActionResult ListExam()
        {
            _examQuestionVM.Exams = _examService.GetAll().ToList();
            _examQuestionVM.Questions = _questionService.GetAll().ToList();


            return View(_examQuestionVM);
        }


        public ActionResult DeleteExam(Guid ID)
        {
            Exam exam = _examService.GetByID(ID);
            _examService.Delete(exam);

            return RedirectToAction("ListExam", "Exam");
        }

        [HttpGet]
        public ActionResult EnterExam(Guid ID)
        {
            Exam exam = _examService.GetByID(ID);
            EnterExamViewModel enterExam = new EnterExamViewModel();
            enterExam.Exam = exam;
            enterExam.Questions = exam.Question.ToList();

            return View(enterExam);
        }

        public JsonResult CheckAnswers(string answers, Guid ID)
        {
            Exam exam = _examService.GetByID(ID);
            string[] ans = answers.Split(',');

            bool[] result = new bool[4];

            int counter = 0;
            foreach (Question item in exam.Question)
            {
                if (item.correctChoice == ans[counter])
                {
                    result[counter] = true;
                }
                else
                {
                    result[counter] = false;
                }
                counter++;
            }


            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }


}