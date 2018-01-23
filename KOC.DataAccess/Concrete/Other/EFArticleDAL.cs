using KOC.Core.DataAccess.EntityFramework;
using KOC.DataAccess.Abstract.Other;
using KOC.Model.Entities.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.DataAccess.Concrete.Other
{
    public class EFArticleDAL : EFEntityRepositoryBase<KOCDBContext, Article>, IArticleDAL 
    {
    }
}
