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
        public int BookingId { get; set; } // DATABAS: Lägg till ID för databasen
        // DATABAS: Foreign Keys (FK) - Lagrar ID istället för hela objektet
        public int CustomerId { get; set; } // DATABAS: FK till Customer-tabellen
        public int RoomId { get; set; } // DATABAS: FK till Room-tabellen



        public DateTime StartDate { get; set; } // Startdatum för bokningen
        public DateTime EndDate { get; set; } // Slutdatum
        public Classes.Customer Customer { get; set; } // Kunden som bokar. Detta är så att C# koden ska fatta
        public Classes.Room BookedRoom { get; set; } // Visar vilket rum som är bokat. Utan den skulle mn inte veta vilket rum som har bokats. Detta är så att C# koden ska fatta


        private static int nextBookingId = 1; // DATABAS: För att generera unika ID:n

        // Konstruktorrr
        public Booking(DateTime start, DateTime end, Classes.Customer customer, Classes.Room bookedRoom)
        {
            BookingId = nextBookingId++; // DATABAS: ökar värdt en gång så nya bokningen får en unik ID
            RoomId = bookedRoom.RoomId; // DATABAS: FK lagras i databasen
            CustomerId = customer.CustomerId; // DATABAS: FK lagras i databasen


            StartDate = start;
            EndDate = end;
            Customer = customer;
            BookedRoom = bookedRoom;
        }

        /* 
         Vad gör nextBookingId++?
         - nextBookingId är en statisk variabel som lagrar nästa lediga boknings-ID.
         - När en ny bokning skapas, tilldelas BookingId det nuvarande värdet av nextBookingId.
         - Sedan ökar nextBookingId med 1 (++), så nästa bokning får ett unikt ID.

        
        Varför matas inte BookingID i konstruktorn?
         - Manuell ID-hantering → Du skulle behöva manuellt välja ID varje gång du skapar en bokning.
         - Risk för dubbletter → Om du glömmer att öka ID:t själv, kan två bokningar få samma ID.
         */

        // DATABAS: Lägg till en parameterlös konstruktor för sist gick det inte att läsa från databasen
        // men den konstruktor som används för att koden ska köras är såklart den över.
        public Booking() 
        {
        
        }



        // Metod: Kontrollera om bokningen överlappar en annan bokning kommer användas i HotelManager klassen
        public bool IsOverlapping(DateTime start, DateTime end) // matar in startdatum och slutdatum på när man ska övernatta
        {
            return (start < EndDate && end > StartDate);
        }

        // ShowBokingsmetoden skrev inte ut ordentligt utan denna metod utan skrev istället på datorspråk som exempelvis Hotelmanager.Booking.Name
    }

}
