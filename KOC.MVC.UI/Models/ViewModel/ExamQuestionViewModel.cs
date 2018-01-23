using KOC.Model.Entities.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KOC.MVC.UI.Models.ViewModel
{
    public class ExamQuestionViewModel
    {

        public List<Exam> Exams { get; set; }
        public List<Question> Questions { get; set; }
    }
}