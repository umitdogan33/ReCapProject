using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class RentalsDetailDto:IDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public int DailyPrice { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        
        public string UserNameLastName { get; set; }

        public int CarId { get; set; }

        public int TotalPrice { get; set; }
    }
}
