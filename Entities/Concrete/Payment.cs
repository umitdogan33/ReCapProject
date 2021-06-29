using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Payment:IEntity
    {
        public int  Id { get; set; }
        public String NameOnTheCard { get; set; }
        public String CardNumber { get; set; }
        public String CardCvv { get; set; }
        public String ExpirationDate { get; set; }
        public int UserId { get; set; }
    }
}