using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //sadece rental'deki buisness bölümünü doldurdum
            //diğer methodları test etmek isteyen arkadaşlar methodları dataaccess üzerinden çağırabilir
            
            
            RentalManager manager = new RentalManager(new EfRentalDal());
           
            
        
        }


    }
}
