using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Business.Constans;
using Core.Utilities.Business;
using Core.Entities.Concrete;

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
            if (_userDal.GetAll(p=> p.Email==user.Email).Any())
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.Deleted);
            }
            return new ErrorResult("kullanıcı bulunamadı");
            
        }

       

        public IDataResult<List<User>> GetAll()
        {
            
            return new SuccessDataResult<List<User>>("kullanıcılar listelendi");
        }

        public IDataResult<User> GetById(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p=> p.Id==Id));
        }

        public User GetByMail(string mail)
        {
            return (_userDal.Get(u => u.Email == mail));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }

        

        IDataResult<List<User>> IUserService.GetAll()
        {
            return new SuccessDataResult<List<User>>( _userDal.GetAll());
        }

        

        IDataResult<User> IUserService.GetById(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p=> p.Id==Id));
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
