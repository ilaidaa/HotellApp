using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp.Classes
{
    // Hotell Manager Klassen
    public class HotelManager
    {
        // Använd alla klasser som du gjorde tidigare Room, Booking och Customer som properies för vad HotelManger ska kunna göra.
        // klasserna Room, Booking och Customer görs om till Lists när jag skapar properiesen till HotelManager för att det ska ju finnas flera av allt dessa.
        public List<Classes.Room> Rooms { get; set; } = new List<Classes.Room>();
        public List<Classes.Customer> Customers { get; set; } = new List<Classes.Customer>();
        public List<Classes.Booking> Bookings { get; set; } = new List<Classes.Booking>();

        // Konstruktorn refererar till metoden (SedData) som genererar exempel rum och exempel kunder.
        public HotelManager()
        {
            SeedData(); // Metoden SeedData() läggs i konstruktorn för att automatiskt fylla listorna Rooms och Customers med exempeldata varje gång ett objekt av HotelManager skapas.
                        // Det innebär att så fort en ny instans av HotelManager skapas, så kommer den direkt att ha några rum och kunder tillgängliga,
                        // Slipper anropa metoden manuellt varje gång jag skapar ett nytt HotelManager-objekt.
        }

        // privat metod (SeedData) för att den kommer bara användas i HotelManager
        // Metoden innehåller 4 rum och 4 kunder jag har bestämt
        private void SeedData()
        {
            Rooms.Add(new Classes.Room(1, "Rum 101", "Enkelrum", 0));
            Rooms.Add(new Classes.Room(2, "Rum 102", "Dubbelrum", 1));
            Rooms.Add(new Classes.Room(3, "Rum 103", "Dubbelrum", 2));
            Rooms.Add(new Classes.Room(4, "Rum 104", "Enkelrum", 0));

            Customers.Add(new Classes.Customer(1, "Alice Karlsson", "alice@hotmail.com", "070-123 45 67"));
            Customers.Add(new Classes.Customer(2, "Erik Andersson", "erik@hotmail.com", "070-765 43 21"));
            Customers.Add(new Classes.Customer(3, "Maria Svensson", "maria@hotmail.com", "070-987 65 43"));
            Customers.Add(new Classes.Customer(4, "Johan Larsson", "johan@hotmail.com", "070-654 32 10"));
        }

        // Metod: Lägg till nytt rum
        public void AddRoom(Classes.Room room) // Lägger till ett rum från Room klassen för att metoden ska funka
        {
            Rooms.Add(room); // Rooms är listen som bestämdes i HotelManager klassens properties. room är objekt från klassen Room
            Console.WriteLine($"Rum {room.RoomName} har lagts till.");
        }

        // Metod: Lägg till en kund
        public void AddCustomer(Classes.Customer customer) // Lägger till en kund från Room klassen för att metoden ska funka
        {
            Customers.Add(customer); // Customers är listen som bestämdes i HotelManager klassens properties
            Console.WriteLine($"Kund {customer.Name} har lagts till.");
        }

        // Metod: Visa alla rum
        public void ShowRooms()
        {
            Console.WriteLine("Lista över alla rum:");
            foreach (Classes.Room room in Rooms) // Första (gröna) Room är klassen Room som finns längst upp
                                                 // Andra (blåa) room är ett rum (variabel) som skapats av Room klassen
                                                 // Sista Rooms (vit) är från HotelManagers klassen property
            {
                Console.WriteLine($"- ID: {room.RoomId}, Namn: {room.RoomName}, Typ: {room.RoomType}, Extrasängar: {room.ExtraBeds}, Ledigt: {(room.IsAvailable ? "Ja" : "Nej")}"); // Om det som är på vänster sida av ? stämmer ska den skriva ja annars skriver den det som kommer efter :
            }
        }

        // MEtod: Visa alla kunder
        public void ShowCustomers()
        {
            Console.WriteLine("Lista över alla kunder:");
            foreach (Classes.Customer customer in Customers) // Första (gröna) Customer är klassen Customer som finns längst upp
                                                             // Andra (blåa) customer är en kund (variabel) som skapats av Customer klassen
                                                             // Sista Customers (vit) är från HotelManagers klassen property
            {
                Console.WriteLine($"- ID: {customer.CustomerId}, Namn: {customer.Name}, Email: {customer.Email}, Telefon: {customer.PhoneNumber}");
            }
        }

        // Metod: Visa alla bokningar
        public void ShowBookings()
        {

            Console.WriteLine("Lista över alla bookningar:");
            foreach (Classes.Booking booking in Bookings) // Första (gröna) Customer är klassen Customer som finns längst upp
                                                          // Andra (blåa) customer är en kund (variabel) som skapats av Customer klassen
                                                          // Sista Customers (vit) är från HotelManagers klassen property
            {
                Console.WriteLine($"- Bokad rum: {booking.BookedRoom}, bookare: {booking.Customer}, startdatum: {booking.StartDate.}, slutdatum: {booking.EndDate}");
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
            Classes.Room room = Rooms.FirstOrDefault(r => r.RoomId == roomId); // FirstOrDefault() är en metod som används för att hämta det första elementet i en samling (mitt fall lista) som uppfyller ett visst villkor.
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
            Classes.Customer customer = Customers.FirstOrDefault(c => c.CustomerId == customerId); // Samma som ovan


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




            // Kolla om rummet är tillgängligt för datumen
            if (room.Bookings.Any(b => b.IsOverlapping(startDate, endDate))) // .Any inbyggd metod i C#, den kollar om minst ett objekt i en lista uppfyller ett visst villkor.
                                                                             // IsOverlapping var ju metoden som jag gjorde i Booking klassen mke längre upp
                                                                             // lambda operator igen. Så den här gånger om b överlappar villkoret efter => så skrivs det ett meddelande t user om att rummet redan är bokat
            {
                Console.WriteLine("Rummet är redan bokat under denna period.");
                return;
            }


            Classes.Booking newBooking = new Classes.Booking(startDate, endDate, customer, room); // Skapar ett nytt objekt av klassen Booking med alla elemnt som finns i parntesen
            room.Bookings.Add(newBooking); // Bookings är ju en property i Room Klassen, det är en lista. Så då läggs den nya bokningen i rummets egna Bookings lista
            Bookings.Add(newBooking); // Vi lägger till den nya bokningen i Bookings listan som är en property i HotelManager klassen (Hela hotellets bokningslista) 
                                      // Denna och Room klassens egna Bookings lista kan hjälpas åt att spara bokningar.
                                      // Men Room klassen måste ha en egen så när man söker i just det rummet kan man se om den är bokad och behöver inte kolla igenom hotellets alla bokningar.
            room.IsAvailable = false; // Isavailable är ju en property i Room klassen, den är vanligtvis alltid på true men nu är den på false för rummet blev precis bokat

            // ÄNTLIGEN BEKRÄFTELSE
            Console.WriteLine($"Bokning skapad! {customer.Name} har bokat {room.RoomName} från {startDate.ToShortDateString()} till {endDate.ToShortDateString()}.");
            // Det går att tabort ToShortDateString() men då blir datumet jättefullt med tid.

        }
    
    }

}
