using HotellApp.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotellApp.Classes
{
    // Hotell Manager Klassen
    public class HotelManager
    {
        // applicationDbContext är som en datatyp som int eller string men i detta fall är det en datatyp som kopplar till databasen
        // int = datatyp för heltal
        // string = datatyp för text
        // ApplicationDbContext = din egen "special-datatyp" för att prata med databasen.
        // du har skapat en plats/minne för att kunna lagra ett ApplicationDbContext-objekt senare. Men du har inte gett den något värde än.
        // Du har bara deklarerat en variabel(en "plats" för databas-kopplingen), men inte skapat själva kopplingen än.
        private ApplicationDbContext _dbContext;


        // Konstruktorn som tar in dbContext
        // detta är en konstruktor som tar emot min speciella variabel (som kopplar koden till databas) och i konstruktorn så omvandlas dbContext variabeln till _DbContext variabel 
        public HotelManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; // JAg skapar inte en NY variabel i konstruktorn. Jag tilldelar ett värde till -DbContext som jag deklarerat ovanför konstuktorn.
            SeedDatabase(); // Kör SeedData varje gång systemet startar (men bara om databasen är tom)
        }


        // Det är en metod för att automatiskt fylla databasen med exempeldata
        // SeedData (exempel personer och rum) men SeedData till databasen inte till min kod
        private void SeedDatabase()
        {
            // Kolla om det redan finns data i databasen (om det finns, gör inget)
            // Kontrollerar om tabellerna är tomma.
            // Om tomma → lägger till startdata(seed).
            // Om det redan finns data → gör INGENTING, så du slipper dubbla.
            // Kolla om det redan finns data i databasen (om det finns, gör inget)
            if (!_dbContext.Customers.Any() && !_dbContext.Rooms.Any())
            {
                // SEEDA KUNDER
                var customers = new List<Customer>
                {
                 new Customer("Alice Karlsson", "alice@hotmail.com", "070-123 45 67"),
                 new Customer("Erik Andersson", "erik@hotmail.com", "070-765 43 21"),
                 new Customer("Maria Svensson", "maria@hotmail.com", "070-987 65 43"),
                 new Customer("Johan Larsson", "johan@hotmail.com", "070-654 32 10")
                 };
                _dbContext.Customers.AddRange(customers);

                // SEEDA RUM
                var rooms = new List<Room>
                {
                new Room("101", "Enkelrum", 0),
                new Room("102", "Dubbelrum", 1),
                new Room("103", "Dubbelrum", 2),
                new Room("104", "Enkelrum", 0)
                 };
                _dbContext.Rooms.AddRange(rooms);

                // SPARA TILL DATABAS
                _dbContext.SaveChanges();
            }
        }




        // Metod: Lägg till nytt rum
        public void AddRoom(Classes.Room room) // Lägger till ett rum från Room klassen för att metoden ska funka
        {
            // Jag bytte ut Room.Add(room) till dessa två rader nedan så att DATABASEN förstår. Alltså en ändring från Lists till Databas
            _dbContext.Rooms.Add(room);
            _dbContext.SaveChanges();

            Console.WriteLine($"Rum {room.RoomName} har lagts till.");
        }



        // Metod: Lägg till en kund
        public void AddCustomer(Classes.Customer customer) // Lägger till en kund från Room klassen för att metoden ska funka
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            
            Console.WriteLine($"Kund {customer.Name} har lagts till.");
        }


        // Metod: Visa alla rum
        public void ShowRooms()
        {
            var rooms = _dbContext.Rooms.ToList(); // DB: La bara till denna rad och ändrade lite i foreach loopens villkor
                                                   // _dbContext	Din koppling till databasen, där tabellerna bor (ex: Rooms).
                                                   // _dbContext.Rooms Hämtar alla rader från tabellen Rooms som en "query".
                                                   // .ToList()   Gör om "queryn" till en färdig lista som du kan jobba med i C#.
                                                   // var rooms Skapar en lokal lista - variabel(endast i metoden) med alla rum

            Console.WriteLine("Lista över alla rum:");
            foreach (var room in rooms) // Första (gröna) Room är klassen Room som finns längst upp
                                                 // Andra (blåa) room är ett rum (variabel) som skapats av Room klassen
                                                 // Sista Rooms (vit) är från HotelManagers klassen property
            {
                Console.WriteLine($"- ID: {room.RoomId}, Namn: {room.RoomName}, Typ: {room.RoomType}, Extrasängar: {room.ExtraBeds}, Ledigt: {(room.IsAvailable ? "Ja" : "Nej")}"); // Om det som är på vänster sida av ? stämmer ska den skriva ja annars skriver den det som kommer efter :
            }
        }



        // MEtod: Visa alla kunder
        public void ShowCustomers()
        {
            var customers = _dbContext.Customers.ToList();

            Console.WriteLine("Lista över alla kunder:");
            foreach (var customer in customers) // Första (gröna) Customer är klassen Customer som finns längst upp
                                                             // Andra (blåa) customer är en kund (variabel) som skapats av Customer klassen
                                                             // Sista Customers (vit) är från HotelManagers klassen property
            {
                Console.WriteLine($"- ID: {customer.CustomerId}, Namn: {customer.Name}, Email: {customer.Email}, Telefon: {customer.PhoneNumber}");
            }
        }



        // Metod: Visa alla bokningar
        public void ShowBookings()
        {
            // Include hämtar den kopplade tabellen, så du får riktiga namn istället för ID.
            // .Include(b => b.Customer) så hämtar du hela kund-objektet från databasen — inte bara ID:t — vilket innebär att du får tillgång till allt som finns i den klassen!
            var bookings = _dbContext.Bookings
                 .Include(b => b.Customer)  
                 .Include(b => b.BookedRoom)
                 .ToList();

            Console.WriteLine("Lista över alla bookningar:");
            foreach (var booking in bookings) // Första (gröna) Customer är klassen Customer som finns längst upp
                                                          // Andra (blåa) customer är en kund (variabel) som skapats av Customer klassen
                                                          // Sista Customers (vit) är från HotelManagers klassen property
            {
                Console.WriteLine($"- Bokad rum: {booking.BookedRoom.RoomName}, bookare: {booking.Customer.Name}, startdatum: {booking.StartDate.ToShortDateString()}, slutdatum: {booking.EndDate.ToShortDateString()}");
            }
        }




        // Metod: Skapa en bokning
        public void MakeBooking(int customerId, int roomId, DateTime startDate, int nights) // Tar emot alla element i parentesen så metoden kan funka
        {
            // Hantera alla fel som kan ske först
            if (nights <= 0) // Såklart måste man kunna boka mer än en natt
            {
                Console.WriteLine("Antal nätter måste vara minst 1.");
                return;
            }

            if (startDate < DateTime.Today) // SÅKLART kan man inte boka "igår"
            {
                Console.WriteLine("Du kan inte boka ett rum för ett datum som redan har passerat.");
                return;
            }

            // Om felen ovan inte existerar gå ner t följande rader:
            // Vi ska hitta rätt rum och rätt kund med hjälp av FirstOrDefault
            var room = _dbContext.Rooms.FirstOrDefault(r => r.RoomId == roomId); // FirstOrDefault() är en metod som används för att hämta det första elementet i en samling (mitt fall lista) som uppfyller ett visst villkor.
                                                                               // Villkoret är den som finns i parentesen bredvid.
                                                                               // r : Variablerna i parentesen är bara påhittade i detta fall r så jag kan koppla till room i huvet
                                                                               // => : är lambda-operatorn, som betyder "går till" eller "returnerar".
                                                                               // r.Id == roomId : är själva villkoret som kontrollerar om rummet har det önskade Id.
                                                                               // VAD HÄNDER?:
                                                                               // Tänk dig att du har en lista med rum och du ska hitta rum med Id 2.
                                                                               // då skriver jag lambada såhär: Room room = Rooms.FirstOrDefault(r => r.Id == 2);
                                                                               // Första rummet (r.Id == 1) matchar inte.
                                                                               // Andra rummet(r.Id == 2) matchar, så detta Room returneras.
                                                                               // Metoden slutar söka eftersom FirstOrDefault() bara returnerar det första matchande objektet.
                                                                               // Om ingen matchning hittas, returnerar FirstOrDefault() null.
                                                                               // FirstOrDefault söker i listan Rooms efter ett rum där Id matchar det roomId jag fick som parameter i MakeBooking metoden.
                                                                               // Varför söker den ett rum med samma roomId (r.Id == roomId)?
                                                                               // Den gör det för att jag ska hitta rätt rum att boka
                                                                               // jag vill skapa en bokning för en viss kund i ett visst rum.
                                                                               // För att kunna göra det måste jag hitta det specifika rummet som kunden vill boka.
           var customer = _dbContext.Customers.FirstOrDefault(c => c.CustomerId == customerId); // Samma som ovan


            // Om rummet ELLER kunden inte hittas, då meddela user
            if (room == null || customer == null)
            {
                Console.WriteLine("Fel: Rummet eller kunden existerar inte.");
                return;
            }

            // Beräknar slutdatumet för bokningen genom att lägga till antal nätter på startdatumet.
            DateTime endDate = startDate.AddDays(nights); // startDate och nights fick jag också som parameter i MakeBooking metoden
                                                          // endDate skapar jag nu efter att jag har AddDays på startdatumet
                                                          // AddDays() är en inbyggd metod i Csharps DateTime-klass







            // Kolla om rummet är tillgängligt för datumen genom att först skapa en bool som kollar om databasen har en bokning som
            // har samma rumsId som den id som matas in i bokningen eller om startdatumet är mindre än sluttadum eller slutdatum större än startdatum
            bool isBooked = _dbContext.Bookings.Any(b => b.RoomId == roomId && startDate < b.EndDate && endDate > b.StartDate);

            //Om isBooked är sant alltså det finns en bookning
            if (isBooked)
            {
                Console.WriteLine("Rummet är redan bokat under denna period.");
                return;
            }


            var booking = new Booking(startDate, endDate, customer, room); // Här skapas ett nytt boknings-objekt av klassen Booking.
                                                                           // Det får ett startdatum, slutdatum, vilken kund som bokar, och vilket rum som bokas.
                                                                           // Detta finns bara i minnet just nu, inte i databasen än.
            _dbContext.Bookings.Add(booking); // "Hej databas, jag vill att du lägger till denna nya bokning nästa gång jag sparar!"
            _dbContext.SaveChanges(); //  Nu skickas bokningen till databasen och blir permanent!

            room.IsAvailable = false; // rummet nu är upptaget genom att ändra IsAvailable till false.
            _dbContext.Rooms.Update(room); // "Hej, uppdatera detta rum (som nu är upptaget)."
            _dbContext.SaveChanges(); // Spara ändringar 


            // ÄNTLIGEN BEKRÄFTELSE
            Console.WriteLine($"Bokning skapad! {customer.Name} har bokat {room.RoomName} från {startDate.ToShortDateString()} till {endDate.ToShortDateString()}.");
            // Det går att tabort ToShortDateString() men då blir datumet jättefullt med tid.

        }
    
    }

}
