using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class CustomerCreditCard:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CartId { get; set; }
    }
}