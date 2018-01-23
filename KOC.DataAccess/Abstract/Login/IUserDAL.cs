using KOC.Core.DataAccess;
using KOC.Model.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.DataAccess.Abstract.Login
{
    public interface IUserDAL : IEntityRepository<User>
    {
    }
}
