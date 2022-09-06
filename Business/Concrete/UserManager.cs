using Business.Abstract;
using Core.Entities.Concrate;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager:IUserManager
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User User)
        {
            _userDal.Add(User);
         
        }

        public User GetByEmai(string Email)
        {
            return _userDal.Get(x => x.Email == Email); ;

        }
    }
}
