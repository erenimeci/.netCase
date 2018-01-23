using KOC.Model.Entities.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.Business.Abstract.Other
{
    public interface IArticleService
    {
        void Add(Article item);
        void Delete(Article item);
        void Update(Article item);
        Article GetByID(Guid ArticleID);
        ICollection<Article> GetAll();
    }
}
