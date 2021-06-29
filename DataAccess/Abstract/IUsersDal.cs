using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
namespace DataAccess.Concrete.EntityFramework
{
  public interface IUsersDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(int id);
    }
}
