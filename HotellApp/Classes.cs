using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp
{
    // Rums klassen
    public class Room
    {
        // Skapa properties
        public int Id { get; set; } // Unikt ID för varje rum
        public string RoomName { get; set; } // Namn på rummet (ex. "Rum 101")
        public string RoomType { get; set; } // "Enkelrum" eller "Dubbelrum"
        public int ExtraBeds { get; set; } //  extrasängar
        public bool IsAvailable { get; set; } // Är rummet ledigt?
        public List<Booking> Bookings { get; set; } = new List<Booking>(); // Lista över bokningar

        // Konstruktor för att skapa ett nytt rum
        public Room(int id, string roomName, string roomType, int extraBeds)
        {
            Id = id;
            RoomName = roomName;
            RoomType = roomType;
            ExtraBeds = extraBeds;
            IsAvailable = true;
        }

    }









    // Kund Klassen
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customer(int id, string name, string email, string phone)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phone;
        }
    }












        // Boknings Klassen
       public class Booking
        {
            public DateTime StartDate { get; set; } // Startdatum för bokningen
            public DateTime EndDate { get; set; } // Slutdatum
            public Customer Customer { get; set; } // Kunden som bokar
            public Room BookedRoom { get; set; }



            // Konstruktorrr
            public Booking(DateTime start, DateTime end, Customer customer, Room bokedRoom)
            {
                StartDate = start;
                EndDate = end;
                Customer = customer;
                BookedRoom = BookedRoom;
            }

            // Kontrollera om bokningen överlappar en annan bokning
            public bool IsOverlapping(DateTime start, DateTime end)
            {
                return (start < EndDate && end > StartDate);
            }
        }
}


    

