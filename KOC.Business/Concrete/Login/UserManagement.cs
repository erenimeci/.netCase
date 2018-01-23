using KOC.Business.Abstract.Login;
using KOC.DataAccess.Abstract.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.Business.Concrete.Login
{
    public class UserManagement : IUserService
    {
        IUserDAL _userDal;

        public UserManagement(IUserDAL userdal)
        {
            _userDal = userdal;
        }

        public void Add(Model.Entities.Login.User item)
        {
            _userDal.Add(item);
        }

        public void Delete(Model.Entities.Login.User item)
        {
            _userDal.Delete(item);
        }

        public void Update(Model.Entities.Login.User item)
        {
            _userDal.Update(item);
        }

        public Model.Entities.Login.User GetByUserName(string userName)
        {
            return _userDal.Get(e => e.UserName == userName);
        }

        public ICollection<Model.Entities.Login.User> GetAll()
        {
            return _userDal.GetAll();
        }
    }
}
