using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp.Classes
{
    // Kund Klassen
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customer(string name, string email, string phone)
        {
           
            Name = name;
            Email = email;
            PhoneNumber = phone;
        }


        // DATABAS: Lägg till en parameterlös konstruktor för sist gick det inte att läsa från databasen
        // men den konstruktor som används för att koden ska köras är såklart den över.
        public Customer()
        {

        }

    }
}
