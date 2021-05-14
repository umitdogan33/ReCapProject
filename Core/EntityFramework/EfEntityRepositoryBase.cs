using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>
    where TEntity:class,IEntity,new()
    {
    }
}
