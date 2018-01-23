using KOC.Core.DataAccess.EntityFramework;
using KOC.DataAccess.Abstract.Login;
using KOC.Model.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.DataAccess.Concrete.Login
{
    public class EFUserDAL : EFEntityRepositoryBase<KOCDBContext, User>, IUserDAL 
    {
    }
}
