using HotellApp.Classes;
using HotellApp.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HotellApp.Methods
{
    internal class ShowBookingMenuMethod
    {
        // Metod som ska hantera "Hantera Bokningar" alternativet i huvudmenyn Meny
        // DB ändring: Skicka in din databas koppling också
        public static void ShowBookingMenu(Classes.HotelManager hotelManager, ApplicationDbContext dbContext) // public före static så att man kan anropa metoden i Program
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("|\t1. Skapa ny bokning          |");
            Console.WriteLine("|\t2. Ändra bokning             |");
            Console.WriteLine("|\t3. Ta bort bokning           |");
            Console.WriteLine("|\t4. Återvänd till Huvudmeny   |");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("======================================");


            // Ska bestämmas i while loopen när användaren ger svar men nu deklarerar jag bara så vi kan ändra värdet beroende på vad anvndaren säger
            int choice;

            // Hantera om användaren skriver fel siffra
            while (true)
            {
                // Fråga om inpput
                Console.WriteLine();
                Console.Write("Vänligen välj ett alternativ genom att skriva in siffran för det val du önskar och tryck på Enter: ");

                // Lagra input
                string? input = Console.ReadLine();

                // Hantera ? och om det är mer eller mindre än 5
                if (int.TryParse(input, out choice) && choice <= 4 && choice >= 1)
                {
                    break; // Bryt loopen så du kan gå t switchen
                }

                Console.WriteLine("Vänligen välj en siffra från menyn 1 - 4.");
            }

            // Hantera kundens önskemål i submenyn beroende på vad hen vlt genom submeny
            switch (choice)
            {
                case 1:
                    // Börja med att samla alla element som behövs för att använda metoden MakeBooking som finns i HotelManager klassen

                    // Visa befintliga kunder för att göra det tydligt för användaren att kunna välja Kund ID
                    Console.WriteLine();
                    Console.WriteLine("Befintliga Kunder:");

                    // DB uppdatering
                    var customers = dbContext.Customers.ToList();
                    // DB: ändring, loopar från DB och inte Classes.HotelManager
                    foreach (var c in customers) 
                    {
                        Console.WriteLine($"- Kund ID: {c.CustomerId},  Namn: {c.Name}, Email: {c.Email}, Tel: {c.PhoneNumber})");
                    }

                    // Ta emot ID från personen som ska göra en bookning
                    Console.WriteLine();
                    Console.Write("Vänligen ange kund ID på personen du vill göra en ny bokning för: ");

                  

                    // Ta emot kund id 
                    string? inputCustomerId = Console.ReadLine();

                    // Skapa en int variabel som ska vara den nya customerId när inputCustomerId stringen konverteras
                    int customerId;

                    // Hantera vad som gänder om inputCustomerID inte lyckas konverteras eller om Kund Id inte hittas
                    while (!int.TryParse(inputCustomerId, out customerId) || !customers.Any(c => c.CustomerId == customerId))
                    {
                        Console.WriteLine();
                        Console.Write("Fel: Ange ett giltigt kund-ID: ");
                        inputCustomerId = Console.ReadLine(); // Låt användaren försöka tills hen får rätt.
                    }



                    // Visa befintliga rum för att göra det tydligt för användaren att kunna välja rum ID
                    Console.WriteLine();
                    Console.WriteLine("Befintliga Rum: ");

                    //DB ändring!
                    var rooms = dbContext.Rooms.ToList();
                    // DB ändring i foreach loopen ändra hotelMAanger.Rooms till rooms bara så du kopplar till dbContet
                    foreach (var rooom in rooms)
                    {
                        Console.WriteLine($"-Rum ID: {rooom.RoomId}, Namn: {rooom.RoomName}, Typ: {rooom.RoomType}, Extrasängar: {rooom.ExtraBeds})");
                    }

                    // Ta emot ID från personen som ska göra en bookning
                    Console.WriteLine();
                    Console.Write("Vänligen ange rums ID på rummet du vill göra en ny bokning för: ");

                    // Ta emot input i string
                    string? inputRoomId = Console.ReadLine();

                    // Skapa en int variabel som ska vara den nya roomId när inputCustomerId stringen konverteras
                    int roomId;

                    // Hantera vad som händer om inputRoomID inte lyckas konverteras eller om rum Id inte hittas
                    while (!int.TryParse(inputRoomId, out roomId) || !rooms.Any(r => r.RoomId == roomId))
                    {
                        Console.WriteLine();
                        Console.Write("Fel: Ange ett giltigt rums-ID: ");
                        inputRoomId = Console.ReadLine();
                    }





                    // Ta emot startdatum för vistelsen
                    Console.WriteLine();
                    Console.Write("Ange startdatum (YYYY-MM-DD) för bokningen (glöm inte - teckn mellan siffrorna): ");

                    // Spara datumsinput i string
                    string? inputDateTime = Console.ReadLine();

                    // skapa en DateTime variabel som ska få värde när den konverterats klart i while loopen nedan
                    DateTime startDate;

                    // Om DateTime inte konverteras eller om startdatumet för bokningen är mindre än dagen datum ska meddelandet i blocket visas
                    while (!DateTime.TryParse(inputDateTime, out startDate) || startDate < DateTime.Today)
                    {
                        Console.WriteLine();
                        Console.Write("Vänligen ange ett giltigt datum / ett datum som inte är i det förflutna: ");
                        inputDateTime = Console.ReadLine();
                    }





                    // Ta emot antal nätter för vistelsen
                    Console.WriteLine();
                    Console.Write("Ange antal nätter: ");

                    // Ta emot antal nätter
                    string? inputNights = Console.ReadLine();

                    // Skapa en int variabel som ska få värde när den konverterats klart i while loopen nedan
                    int nights;

                    // Om inputNights inte lyckas konverteras eller om nätter är mindre eller lika med 0 ge ett felmeddelande
                    while (!int.TryParse(inputNights, out nights) || nights <= 0)
                    {
                        Console.WriteLine();
                        Console.Write("Vänligen ange ett giltigt antal / ett antal som inte är eller mindre än 0: ");
                        inputNights = Console.ReadLine();
                    }




                    // Nu anropar vi MakeBooking metoden med de insamlade uppgifterna
                    Console.WriteLine(); // design
                    hotelManager.MakeBooking(customerId, roomId, startDate, nights);





                    break;


                case 2:
                    // Fråga om vem som ska boka
                    Console.WriteLine();
                    Console.Write("Vänligen ange namnet på personen för den bokning som du önskar ändra (Ex: Karin Larsson): ");

                    // Ta emot nput
                    string? nameOfBooker = Console.ReadLine().ToLower(); ;

                    // För DB
                    var customerForBooking = dbContext.Customers.ToList(); // DB: hämta från DB

                    // Hantera ? och kolla om namnet ens finns "om strängen är null eller bokar INTE finns i listan)
                    while (string.IsNullOrWhiteSpace(nameOfBooker) || !customerForBooking.Any(c => c.Name.ToLower() == nameOfBooker))
                    {
                        Console.WriteLine();
                        Console.Write("Vänligen skriv in ett giltigt namn / en kund som existerar: ");
                        nameOfBooker = Console.ReadLine().ToLower();
                    }

                    // Hitta kunden och HÄMTA kunden baserat på namnet, First hämtar ju en kund, Any kollar bara om det finns en matchande element
                    // Du behöver inte använda FirstOrDefault för du dubbelkollade i while loopen att namnet fanns i listan med hjälp av Any redan.
                    var customerBooking = customerForBooking.First(c => c.Name.ToLower() == nameOfBooker);
                    // koppla customerBookings till din DB
                    var customerBookings = dbContext.Bookings
                        .Include(b => b.BookedRoom) // .Include(b => b.BookedRoom) Hämtar info om vilket rum som är kopplat till bokningen, inte bara RoomId.
                                                    // (Annars hade du fått problem om du vill skriva ut tex. "Rum 101").
                        .Where(b => b.CustomerId == customerBooking.CustomerId) //  Filtrerar så att du bara får bokningar för den kund du jobbar med just nu.
                                                                                //  (Alltså alla bokningar som är kopplade till den personens ID).
                        .ToList(); // Gör om resultatet till en lista som du kan loopa igenom och använda direkt.


                    // Om kunden inte har bokningar, avbryt
                    if (!customerBookings.Any())
                    {
                        Console.WriteLine($"Kunden {customerBooking.Name} har inga bokningar att ändra.");
                        return;
                    }

                    // Visa bokningar och låt användaren välja vilken de vill ändra
                    Console.WriteLine();
                    Console.WriteLine($"Bokningar för {customerBooking.Name}: ");

                    for (int i = 0; i < customerBookings.Count; i++) // Count är där för att den räknar och det är en lista.
                    {
                        var booking = customerBookings[i]; // Skapar ett objekt av Booking klassen i DB och lägger varje nu customerBookings i den
                        Console.WriteLine($"{i + 1}. Rum: {booking.BookedRoom.RoomName}, Från: {booking.StartDate.ToShortDateString()} Till: {booking.EndDate.ToShortDateString()}");
                        // i + 1 = så den räknar från 1. vi börjar ju loopen från 0
                        // ToShortDateString behövs ej men blir skitfult utan
                    }

                    // Be användaren välja en bokning
                    Console.WriteLine();
                    Console.Write("Ange siffran för den bokning du vill ändra: ");
                    

                    // ta emot användarens input i string
                    string? choosenInput = Console.ReadLine();

                    // Skapa denna int variabel som ska få ett värde när den konverteras i while loopen
                    int chosenBooking;

                    // Hantera ? och konvertera choosenInput. Du säger "Om det inte går att konvertera, om den är mindre än 1 eller större än antal bookningar som finns
                    while (!int.TryParse(choosenInput, out chosenBooking) || chosenBooking < 1 || chosenBooking > customerBookings.Count)
                    {
                        Console.WriteLine();
                        Console.Write("Felaktigt val, ange en giltig siffra: ");
                        choosenInput = Console.ReadLine();  // Låt användaren testa igen
                    }

                    // Hämta den valda bokningen
                    // -1 används eftersom listor börjar på index 0, men användare tänker i "1, 2, 3...".
                    // Denna rad hämtar en specifik bokning från listan customerBookings, baserat på användarens val.
                    var selectedBooking = customerBookings[chosenBooking - 1];

                    Console.WriteLine();
                    // Låt användaren byta datum på sin bokning
                    // Du kan använda choosenInput för den kommer ju aldrig vara fel. Den måste vara giltg så att man kan hoppa ner till nästa kod från while-loopen
                    Console.Write($"Du har valt att ändra datum för bokningen {choosenInput}. Ange nytt startdatum (YYYY-MM-DD): ");

                    // Starta en variabel som ska vara det som konverteras i whileloopen
                    DateTime newStartDate;

                    // Konvertera användaren input I SJÄLVA while loopen och säg att nya datumet inte ska vara mindre än dagens datum
                    // Om input är ogiltig, går programmet tillbaka in i loopen och anropar Console.ReadLine() igen.
                    while (!DateTime.TryParse(Console.ReadLine(), out newStartDate) || newStartDate < DateTime.Today)
                    {
                        Console.WriteLine();
                        Console.Write("Felaktigt datum, försök igen: ");
                    }

                    // Fråga om nätter nya bookningen ska vara
                    Console.WriteLine();
                    Console.Write("Ange nytt antal nätter: ");

                    // Skapa en variabel som ska konverteras i while loopen och få värde där
                    int newNights;

                    // Du säger "Om användarens input inte går att konvertera eller om nya nätterna är mindre än eller lika med 0"
                    while (!int.TryParse(Console.ReadLine(), out newNights) || newNights <= 0)
                    {
                        Console.WriteLine();
                        Console.Write("Felaktigt antal nätter, försök igen: ");
                    }

                    // Skapa en ny slutdatum också genom att lägga på antal nätter på startdatumet
                    // AddDays() är en inbyggd metod i C#. Den används för att lägga till eller ta bort dagar från ett datum.
                    DateTime newEndDate = newStartDate.AddDays(newNights);

                    // Kontrollera om det nya datumet krockar med någon annan bokning av samma rum
                    // BookedRoom är en property i Bookings klassen. Den innehåller ett objekt av klassen Room, vilket betyder att den pekar på vilket rum som bokningen gäller.
                    // Bookings är en lista (List<Booking>) som finns i Room-klassen. Den innehåller alla bokningar som har gjorts för detta specifika rum.
                    // b != selectedBooking betyder "ignorera den bokning vi just nu ändrar".
                    // IsOverlapping() är en metod vi definierade i Booking-klassen. Den kollar om bokningen b överlappar den nya perioden(newStartDate - newEndDate).




                    /* egentligen skulle endast detta stycke användas men eftersom att EF är lite efterbliven kunde den inte översätta min IsOverlapping metod i booking så nu måste jag HÄMTA allt från databasen ÅSEN kolla igenom
                    bool isOverlapping = dbContext.Bookings.Any(b => b.RoomId == selectedBooking.RoomId && b.BookingId != selectedBooking.BookingId && b.IsOverlapping(newStartDate, newEndDate));
                    */

                    // Så nu måste jag göra allt detta nedan istället :)
                    // 1. Hämta alla andra bokningar för detta rum (inte den vi försöker ändra)
                    var existingBookings = dbContext.Bookings
                        .Where(b => b.RoomId == selectedBooking.RoomId && b.BookingId != selectedBooking.BookingId)
                        .ToList(); // HÄMTA FRÅN DB FÖRST

                    // 2. Kör IsOverlapping i C# (som funkar när datan är i minnet)
                    bool isOverlapping = existingBookings.Any(b => b.IsOverlapping(newStartDate, newEndDate));



                    if (isOverlapping)
                    {
                        Console.WriteLine("Det valda datumet krockar med en annan bokning för detta rum.");
                    }
                    else
                    {
                        selectedBooking.StartDate = newStartDate;
                        selectedBooking.EndDate = newEndDate;
                        dbContext.Bookings.Update(selectedBooking);
                        dbContext.SaveChanges(); // DB: Spara ändringen!

                        Console.WriteLine();
                        Console.WriteLine($"Bokningen har uppdaterats! Nytt datum: {newStartDate.ToShortDateString()} - {newEndDate.ToShortDateString()}.");
                    }
                    
                    break;


                case 3:
                    Console.WriteLine();
                    hotelManager.ShowBookings();

                    Console.WriteLine();
                    Console.Write("Vänligen ange rumsnamn för den bookning du vill ta bort (Ex: 101): ");


                    // Ta emot input
                    string? bookingGettingDeleted = Console.ReadLine();

                    // Hantera ? (null) som du lova i raden ovan
                    while (string.IsNullOrWhiteSpace(bookingGettingDeleted))
                    {
                        Console.WriteLine();
                        Console.Write("Vänligen skriv in ett giltigt namn (Ex: Rum 101): ");
                        bookingGettingDeleted = Console.ReadLine().ToLower();
                    }

                    // Kolla om rumsnamnet ens finns om inte ge användaren nya chanser tills han lyckas
                    while (!dbContext.Rooms.Any(r => r.RoomName.ToLower() == bookingGettingDeleted))
                    {
                        Console.WriteLine();
                        Console.Write("Bookningen du vill ta bort kunde inte hittas. Vänligen skriv in ett giltigt rumsnamn: ");
                        bookingGettingDeleted = Console.ReadLine();
                    }

                    // Hitta en bokning som är kopplad till detta rum
                    // Hämta alla bokningar för det rummet
                    var bookingsForRoom = dbContext.Bookings
                        .Include(b => b.BookedRoom)
                        .Include(b => b.Customer) 
                        .Where(b => b.BookedRoom.RoomName == bookingGettingDeleted)
                        .ToList();

                    // Om inga bokningar hittas, avbryt
                    if (!bookingsForRoom.Any())
                    {
                        Console.WriteLine("Det finns inga bokningar för detta rum.");
                        return;
                    }

                    // Lista bokningar med siffror
                    Console.WriteLine();
                    Console.WriteLine($"Bokningar för {bookingGettingDeleted}:");
                    for (int i = 0; i < bookingsForRoom.Count; i++)
                    {
                        var b = bookingsForRoom[i];
                        Console.WriteLine($"{i + 1}. Bokare: {b.Customer.Name}, Från: {b.StartDate.ToShortDateString()} Till: {b.EndDate.ToShortDateString()}");
                    }

                    // Låt användaren välja en bokning att ta bort
                    Console.WriteLine();
                    Console.Write("Ange siffran för den bokning du vill ta bort: ");
                    string? chosenBookingInput = Console.ReadLine();
                    int chosenBookingNumber;

                    // Validera inmatningen
                    while (!int.TryParse(chosenBookingInput, out chosenBookingNumber) || chosenBookingNumber < 1 || chosenBookingNumber > bookingsForRoom.Count)
                    {
                        Console.WriteLine();
                        Console.Write("Felaktigt val, ange en giltig siffra: ");
                        chosenBookingInput = Console.ReadLine();
                    }

                    // Hämta den valda bokningen
                    var selectedBookingToDelete = bookingsForRoom[chosenBookingNumber - 1];

                    // Ta bort den valda bokningen
                    dbContext.Bookings.Remove(selectedBookingToDelete);
                    dbContext.SaveChanges(); // Spara ändringen!

                    Console.WriteLine();
                    Console.WriteLine($"Bokningen för {bookingGettingDeleted} ({selectedBookingToDelete.StartDate.ToShortDateString()} - {selectedBookingToDelete.EndDate.ToShortDateString()}) har tagits bort.");

                    break;



                case 4:
                    ReturnToMainMenuMethod.ReturnToMainMenu();
                    break;

            }

        }

    }
}
