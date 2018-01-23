using KOC.Core.DataAccess;
using KOC.Model.Entities.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.DataAccess.Abstract.Other
{
    public interface IArticleDAL : IEntityRepository<Article>
    {
    }
}
