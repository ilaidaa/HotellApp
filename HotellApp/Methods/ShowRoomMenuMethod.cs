using HotellApp.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp.Methods
{
    public class ShowRoomMenuMethod
    {
        // Metod som ska hantera "Hantera Rum" alternativet i huvudmenyn Meny
        public static void ShowRoomMenu(Classes.HotelManager hotelManager, ApplicationDbContext dbContext) // Ta in hotelManager metoden i ShowRoomMetoden så att den ska funka
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("|\t1. Lägg till nytt rum        |");
            Console.WriteLine("|\t2. Ändra rumsuppgifter       |");
            Console.WriteLine("|\t3. Ta bort rum               |");
            Console.WriteLine("|\t4. Återvänd till Huvudmeny   |");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("======================================");
            Console.WriteLine();

            // Ska bestämmas i while loopen när användaren ger svar men nu deklarerar jag bara så vi kan ändra värdet beroende på vad anvndaren säger
            int choice;

            // Hantera om användaren skriver fel siffra
            while (true)
            {
                // Fråga om inpput
                Console.Write("Vänligen välj ett alternativ genom att skriva in siffran för det val du önskar och tryck på Enter: ");

                // Lagra input
                string? input = Console.ReadLine();

                // Hantera ? och om det är mer eller mindre än 4
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
                    // Ge användaren alternativ
                    Console.WriteLine();
                    Console.WriteLine("1. Välj enkelrum.");
                    Console.WriteLine("2. Välj dubbelrum liten (60 kvm)");
                    Console.WriteLine("3. Välj dubbelrum stor (100 kvm)");
                    Console.WriteLine();
                    // Spara input, ? = "Jag löser null sj"
                    string? inputRoom = Console.ReadLine();


                    // inputRoom ska bli roomChoice när den konverteras till int från string
                    int roomChoice;
                    // Konverterar och hanterar om man skriver nånting bortom 1-3
                    // Lyckas inte komma ur while loopen om inputRoom inte går att konvertera till roomChoice, eller RoomChoice är mindre än 1, eller roomChoice är stöörre än 3
                    while (!int.TryParse(inputRoom, out roomChoice) || roomChoice < 1 || roomChoice > 3)
                    {
                        Console.WriteLine("Vänligen välj en siffra i menyn 1 – 3."); // Ingen return behövs för loopen körs SÅ LÄNGE fel inmatning sker.
                                                                                     // Om inte så går man ner till nästa rad
                        inputRoom = Console.ReadLine(); // gör att användaren får en ny chans att skriva in rätt input.
                    }


                    // Den här raden används för att bestämma vilken typ av rum som användaren har valt.
                    // Skaar en ny string som heter roomType och det som är efter = är ternary 
                    // Ternary säger om roomChoice är 1 så är det enkelrum annars är det dubbelrum. Vilket är det som står i menyn
                    string roomType = roomChoice == 1 ? "Enkelrum" : "Dubbelrum";


                    // Ska bestämma maxantal sängar för dubbelrummen så man behöver något som kan hålla räkningen på sängar
                    int maxExtraBeds = 0;
                    if (roomChoice == 2)
                    {
                        maxExtraBeds = 1; // Dubbelrum liten (60 kvm) kan ha 1 extrasäng
                    }
                    else if (roomChoice == 3)
                    {
                        maxExtraBeds = 2; // Dubbelrum stor (100 kvm) kan ha 2 extrasängar
                    }


                    // Ska betämma hur MÅNGA sängar kunden ska ha så vi behöver något som håller räkningen
                    int extraBeds = 0;
                    if (maxExtraBeds > 0)
                    {
                        Console.Write($"Hur många extrasängar vill du lägga till? (0 - {maxExtraBeds}): ");

                        // Ta emot input , Säg t programmet att du hanterar null själv genom ?
                        string? bedCount = Console.ReadLine();

                        // Om det inte går att konverter, eller extrabeds är mindre än 0 eller extraBeds är mer än maxBeds ge felmeddelande
                        while (!int.TryParse(bedCount, out extraBeds) || extraBeds < 0 || extraBeds > maxExtraBeds)
                        {
                            Console.WriteLine();
                            Console.Write($"Vänligen ange ett nummer mellan 0 och {maxExtraBeds}: ");
                            bedCount = Console.ReadLine(); // användaren ska få en ny chans att mata in rätt värde.
                        }
                    }


                    Console.WriteLine();
                    Console.Write("Ange ett namn för rummet (Ex: Rum 105): "); // ÄNDRAT: Användaren skriver namnet
                    string? roomName = Console.ReadLine();

                    // Validera input för rumsnamn
                    while (string.IsNullOrWhiteSpace(roomName) || dbContext.Rooms.Any(r => r.RoomName == roomName)) // ÄNDRAT: Kolla så det inte finns
                    {
                        Console.WriteLine("Rumsnamnet är ogiltigt eller finns redan, ange ett annat namn: ");
                        roomName = Console.ReadLine();
                    }

                    // Skapa ett nytt rum (RoomId skapas automatiskt av databasen) 
                    Classes.Room newRoom = new Classes.Room(roomName, roomType, extraBeds); // ÄNDRAT: 0 som ID, databasen sätter ID själv
                    dbContext.Rooms.Add(newRoom); // Lägg till i DB
                    dbContext.SaveChanges(); // Spara till DB

                    // Ge meddelande till user om att bokningen är klar
                    Console.WriteLine($"Rum {roomName} Bokat! Du har skapat {roomType} med {extraBeds} extrasäng(ar).");
                    break;



                case 2:
                    Console.Write("Vänligen ange rumsnumret för det rum du vill ändra (Ex: 101): ");

                    // Ta emot användarens svar i string 
                    string? input = Console.ReadLine();
                    Console.WriteLine();

                    // Konvertera och hantera ? från    -->    "string? input = Console.ReadLine();"
                    int roomNumber; // behöver deklareras utanför while-loopen för att den ska vara tillgänglig efter att loopen är klar       
                    while (!int.TryParse(input, out roomNumber)) // Hade jag inte deklarerat roomNumber över while loopen hade jag varit tvungen att lägga "int" framför out
                    {
                        Console.WriteLine();
                        Console.Write("Vänligen skriv in ett giltigt nummer: ");
                        input = Console.ReadLine(); // denna rad så användaren kan fortsätta skriva in svar tills han ger ett korrekt svar
                    }


                    // Kolla om rummet ens finns i hotelManager.Rooms
                    var roomToEdit = dbContext.Rooms.FirstOrDefault(r => r.RoomName == input); // var är en room objekt från Room klassen

                    // Hanter om find inte hittar rummet
                    if (roomToEdit != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Du har valt att ändra {roomToEdit.RoomName}");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Rummet kunde inte hittas.");
                    }

                    Console.WriteLine();
                    // Låt användaren välja det som ska ändras i rummet
                    Console.WriteLine("1. Rumsnummer (Ex: 101)");
                    Console.WriteLine("2. Rumstyp (Ex: enkelrum/dubbelrum)");
                    Console.WriteLine("3. Extrasängar");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Vänligen välj ett alternativ genom att skriva in siffran för det val du önskar och tryck på Enter: ");

                    // Ta emot användarens input 
                    string? inputString = Console.ReadLine();

                    // Deklarera variabeln som ska skapas när inputString konverteras. dvs variabeln i while loopen nedan
                    int userChoice;

                    // Konvertera, hantera ?, låt användaren testa skriva tills hen skriver rätt
                    while (!int.TryParse(inputString, out userChoice) || userChoice > 4 || userChoice < 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Vänligen ange ett nummer mellan 1 - 3");
                        inputString = Console.ReadLine();
                    }

                    // Hantera alla alternativ med en switch sats
                    switch (userChoice)
                    {
                        case 1:
                            Console.WriteLine();
                            Console.Write($"Ditt nuvarande rumsnummer är: {roomToEdit.RoomName}. Skriv det rumsnummer du vill byta till : ");

                            // Ta emot input
                            string? newRoomName = Console.ReadLine();

                            // Hantera null ( ? )
                            while (string.IsNullOrWhiteSpace(newRoomName))
                            {
                                Console.WriteLine();
                                Console.WriteLine("Vänligen skriv in ett giltigt rumsnummer");
                                newRoomName = Console.ReadLine(); // Ge flera chanser till användaren skriver utan null eller tom sträng
                            }

                            // Kolla om rumsnamnet redan är upptaget om så fallet låt användaren ge nya namn tills han lyckas
                            while (dbContext.Rooms.Any(r => r.RoomName == newRoomName))
                            {
                                Console.WriteLine();
                                Console.Write($"Det finns redan ett rum som heter {newRoomName}. Vänligen välj ett nytt nummer: ");
                                newRoomName = Console.ReadLine(); // Låt användaren skriva in ett nytt namn
                            }

                            roomToEdit.RoomName = newRoomName;
                            dbContext.Rooms.Update(roomToEdit);
                            dbContext.SaveChanges(); // Spara ändringen
                          
                            // Meddela användaren om bytet
                            Console.WriteLine();
                            Console.WriteLine($"Rumsnumret ändrades till {newRoomName}");
                            break;

                        case 2:
                            Console.Write($"Ditt nuvarande rumstyp är: {roomToEdit.RoomType}. Ange den nya rumstypen (t.ex. enkelrum eller dubbelrum): ");

                            // Ta emot input
                            string? newRoomType = Console.ReadLine();
                            Console.WriteLine();

                            // Hantera ?, alltås om newRoomType är null lr mellanslag
                            while (string.IsNullOrWhiteSpace(newRoomType))
                            {
                                Console.WriteLine();
                                Console.Write("Vänligen ange en giltig rumstyp: ");
                                newRoomType = Console.ReadLine();
                            }

                            // Uppdatera roomToEdits RoomType till användarens nya önskemål som är newRoomType
                            roomToEdit.RoomType = newRoomType;

                            dbContext.Rooms.Update(roomToEdit);
                            dbContext.SaveChanges(); // Spara ändringen

                            // Meddela användaren
                            Console.WriteLine();
                            Console.WriteLine($"Rumstypen har ändrats till {newRoomType}.");
                            break;

                        case 3:
                            Console.Write($"Ditt nuvarande val av extrasängar är: {roomToEdit.ExtraBeds}. Ange det nya antalet extrasängar: ");

                            // ta emot input
                            string? extraBedsinput = Console.ReadLine();
                            Console.WriteLine();

                            // denna variabel är den som kommer att uppdateras efter konverteringen i while
                            int newExtraBeds;

                            // Konvertera och hantera ?
                            while (!int.TryParse(extraBedsinput, out newExtraBeds) || newExtraBeds < 1 || newExtraBeds > 2)
                            {
                                Console.WriteLine();
                                Console.Write("Vänligen ange ett giltigt nummer mellan 1 och 2: ");
                                extraBedsinput = Console.ReadLine();
                            }

                            // Updatera roomToEdits ExtraBeds property med den nya newExtraBeds
                            roomToEdit.ExtraBeds = newExtraBeds;

                            // DB
                            dbContext.Rooms.Update(roomToEdit);
                            dbContext.SaveChanges(); // Spara ändringen

                            // Meddela användaren om detta
                            Console.WriteLine();
                            Console.WriteLine($"Antalet extrasängar har uppdaterats till {newExtraBeds}.");
                            break;
                    }

                    break;


                case 3:
                    Console.Write("Vänligen ange rumsnumret för det rum du vill ta bort (Ex: Rum 101): ");

                    // Ta emot input
                    string? roomGettingDeleted = Console.ReadLine();

                    // Hantera ? (null) som du lova i raden ovan
                    while (string.IsNullOrWhiteSpace(roomGettingDeleted))
                    {
                        Console.WriteLine("Vänligen skriv in ett giltigt nummer (Ex: Rum 101): ");
                        roomGettingDeleted = Console.ReadLine();
                    }

                    // Kolla om rumsnamnet ens finns om inte ge användaren nya chanser tills han lyckas
                    while (!dbContext.Rooms.Any(r => r.RoomName == roomGettingDeleted))
                    {
                        Console.WriteLine("Rummet du vill ta bort kunde inte hittas. Vänligen skriv in ett giltigt rumsnamn: ");
                        roomGettingDeleted = Console.ReadLine();
                    }

                    // Döp rummet (till room) som hittades och som användaren sökte så att du kan i nästa steg deleta
                    var room = dbContext.Rooms.FirstOrDefault(r => r.RoomName == roomGettingDeleted); 

                    // DB
                    dbContext.Rooms.Remove(room); // Ta bort från DB
                    dbContext.SaveChanges(); // Spara ändring

                    // Meddela användaren
                    Console.WriteLine($"Rum {roomGettingDeleted} har tagits bort. ");

                    break;

                case 4:
                    ReturnToMainMenuMethod.ReturnToMainMenu();
                    break;
            }


        }

    }
}
