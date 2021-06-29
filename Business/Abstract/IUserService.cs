using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<User> GetById(int Id);
        IDataResult<List<OperationClaim>> GetClaims(int id);
        IResult EditProfil(User user, string password);
        IDataResult<User> GetUserByEmail(string email);
        User GetByMail(string mail);


    }
}
