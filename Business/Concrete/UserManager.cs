using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Business.Constans;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {

        IUsersDal _userDal;

        public UserManager(IUsersDal userDal)
        {
            _userDal = userDal;
        }


        public IResult Add(User user)
        {
            IResult result = BusinessRules.Run(SameUserName(user.Email));

            if (result!=null)
            {
                return result;
            }

            _userDal.Add(user);
            return new SuccessResult(Messages.AddedUser);
        }

        public IResult Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            
            return new SuccessDataResult<List<User>>("kullanıcılar listelendi");
        }

        public IDataResult<User> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }

        private IResult SameUserName(string Email)
        {
            var result = _userDal.GetAll(p=> p.Email==Email).Any();
            if (result)
            {
                return new ErrorResult(Messages.SameUserName);
            }

            return new SuccessResult();
        }
    }
}
