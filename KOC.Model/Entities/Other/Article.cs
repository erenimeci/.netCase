using KOC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.Model.Entities.Other
{
    public class Article : IEntity
    {
        public Guid ArticleID { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleLink { get; set; }

    }
}
