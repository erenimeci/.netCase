using KOC.Core.DataAccess.EntityFramework;
using KOC.DataAccess.Abstract.Test;
using KOC.Model.Entities.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.DataAccess.Concrete.Test
{
    public class EFExamDAL : EFEntityRepositoryBase<KOCDBContext, Exam>, IExamDAL 
    {
    }
}
