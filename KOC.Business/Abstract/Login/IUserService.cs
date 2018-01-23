using KOC.Model.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.Business.Abstract.Login
{
    public interface IUserService
    {
        void Add(User item);
        void Delete(User item);
        void Update(User item);
        User GetByUserName(string userName);
        ICollection<User> GetAll();
    }
}
