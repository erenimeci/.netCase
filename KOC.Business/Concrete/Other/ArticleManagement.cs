using KOC.Business.Abstract.Other;
using KOC.DataAccess.Abstract.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.Business.Concrete.Other
{
    public class ArticleManagement : IArticleService
    {
        IArticleDAL _examDal;

        public ArticleManagement(IArticleDAL examDal)
        {
            _examDal = examDal;
        }

        public void Add(Model.Entities.Other.Article item)
        {
            _examDal.Add(item);
        }

        public void Delete(Model.Entities.Other.Article item)
        {
            _examDal.Delete(item);
        }

        public void Update(Model.Entities.Other.Article item)
        {
            _examDal.Update(item);
        }

        public Model.Entities.Other.Article GetByID(Guid ArticleID)
        {
            return _examDal.Get(e => e.ArticleID == ArticleID);
        }

        public ICollection<Model.Entities.Other.Article> GetAll()
        {
            return _examDal.GetAll();
        }
    }
}
