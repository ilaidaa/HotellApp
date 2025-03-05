using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp.Classes
{

    // Boknings Klassen
    public class Booking
    {
        public DateTime StartDate { get; set; } // Startdatum för bokningen
        public DateTime EndDate { get; set; } // Slutdatum
        public Classes.Customer Customer { get; set; } // Kunden som bokar
        public Classes.Room BookedRoom { get; set; } // Visar vilket rum som är bokat. Utan den skulle mn inte veta vilket rum som har bokats



        // Konstruktorrr
        public Booking(DateTime start, DateTime end, Classes.Customer customer, Classes.Room bookedRoom)
        {
            StartDate = start;
            EndDate = end;
            Customer = customer;
            BookedRoom = bookedRoom;
        }

        // Metod: Kontrollera om bokningen överlappar en annan bokning kommer användas i HotelManager klassen
        public bool IsOverlapping(DateTime start, DateTime end) // matar in startdatum och slutdatum på när man ska övernatta
        {
            return (start < EndDate && end > StartDate);
        }

        // ShowBokingsmetoden skrev inte ut ordentligt utan denna metod utan skrev istället på datorspråk som exempelvis Hotelmanager.Booking.Name
    }

}
