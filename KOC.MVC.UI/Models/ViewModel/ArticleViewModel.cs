
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KOC.MVC.UI.Models.ViewModel
{
    public class ArticleViewModel
    {
        public List<SelectListItem> ArticleTitle { get; set; }

        public string ArticleContent { get; set; }


        public ArticleViewModel()
        {
            ArticleTitle = new List<SelectListItem>();
        }
    }
}