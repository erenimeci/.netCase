using KOC.Business.Abstract.Login;
using KOC.MVC.UI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KOC.MVC.UI.Controllers
{
    public class HomeController : Controller
    {
        IUserService _userService;

        public HomeController(IUserService UserService)
        {
            _userService = UserService;

        }
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
          

            return View();
        }

        [HttpPost]
        [ValidateInput(false)] 
        public ActionResult Index(FormCollection formcollection) 
        {
            _userService.GetAll();
            HomeViewModel model = new HomeViewModel();
            model.Kisiler = _userService.GetAll().ToList();

            string userName = formcollection["userName"];
            string userPass = formcollection["userPass"];

            try
            {
                KOC.Model.Entities.Login.User kisi = _userService.GetByUserName(userName);
                if (kisi.UserPass == userPass)
                {
                    Session["User"] = kisi;
                    return RedirectToAction("Index", "Exam");
                }

            }
            catch (Exception)
            {
                
                throw;
            }

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SignIn(FormCollection formcollection)
        {
          
            string SignUserName = formcollection["SignUserName"];
            string SignName = formcollection["SignName"];
            string Signsurname = formcollection["Signsurname"];
            string SignuserPass = formcollection["SignuserPass"];

            try
            {
                KOC.Model.Entities.Login.User yeniKisi = new Model.Entities.Login.User{
                     Name = SignName,
                     Surname = Signsurname,
                     UserName = SignUserName,
                     UserPass = SignuserPass
                };

                _userService.Add(yeniKisi);


            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index", "Home");

        }
    }
}