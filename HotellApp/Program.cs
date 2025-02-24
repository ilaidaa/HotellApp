using System.Diagnostics;
using System;
using System.Runtime.Intrinsics.Arm;

namespace HotellApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HotelManager hotelManager = new HotelManager(); // Ropa metoden från Classes fliken


            // Bool för att köra programmet tills användaren stoppar
            bool runProgram = true;
            while (runProgram)
            {

                // Visa meny 
                ShowMainMenu();

                // Inte bestämd för har ej frågat användaren än, men ska ändra denna till d användaren vill när jag knvrterar.
                int choice;

                // Säkerställ att användaren skriver in en giltig siffra från menyn med en loop
                while (true)
                {
                    // Fråga om inpput
                    Console.Write("Vänligen välj ett alternativ genom att skriva in siffran för det val du önskar och tryck på Enter: ");

                    // Ta emot input
                    string? input = Console.ReadLine(); // string? = variabeln kan vara null, och det är mitt ansvar att hantera vilket jag gör i konverteringen (annars använd IsNullOrWhiteSpace)

                    if (int.TryParse(input, out choice) && choice <= 5 && choice >= 1) // Hanterar konvertering och ? && att 1-5 siffra skrivs
                    {
                        break; // Giltigt val så loop ska stanna
                    }

                    Console.WriteLine("Vänligen välj en siffra från menyn 1 - 5.");
                    
                }




                   // Hantera subval
                    switch (choice)
                    {
                        case 1:

                            // Visa Submeny 1
                            ShowRoomMenu(hotelManager);

                            break;

                        case 2:

                            // Visa Submeny 2
                            ShowCustomerMenu();

                            break;

                        case 3:

                            // Visa submeny 3
                            ShowBookingMenu();

                            break;

                        case 4:

                            // Visa submeny 4
                            AvailabilityMenu();
                            break;

                        case 5:
                            Console.WriteLine("Programmet avslutas . . .");
                            Thread.Sleep(1000);
                            runProgram = false;
                        break;

                        //  Behöver ingen default för jag säkerställde i while loopen innan switch satsen att siffran ska vara mellan 1-5

                    }

                Pause();

            }



        }





























        // METODER

        // Huvudmeny
        static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("|\t1. Hantera Rum               |");
            Console.WriteLine("|\t2. Hantera Kunder            |");
            Console.WriteLine("|\t3. Hantera Bokningar         |");
            Console.WriteLine("|\t4. Visa Tillgänglighet       |");
            Console.WriteLine("|\t5. Avsluta Program           |");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("======================================");
            Console.WriteLine();
        }







        // Rum Meny
        static void ShowRoomMenu(HotelManager hotelManager) // Ta in hotelManager metoden i ShowRoomMetoden så att den ska funka
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

                // Hantera ? och om det är mer eller mindre än 5
                if (int.TryParse(input, out choice) && choice <= 5 && choice >= 1)
                {
                    break; // Bryt loopen så du kan gå t switchen
                }

                Console.WriteLine("Vänligen välj en siffra från menyn 1 - 5.");
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
                        Console.Write($"Hur många extrasängar vill du lägga till? (0 -{maxExtraBeds}): ");

                        // Ta emot input , Säg t programmet att du hanterar null själv genom ?
                        string? bedCount = Console.ReadLine();

                        // Om det inte går att konverter, eller extrabeds är mindre än 0 eller extraBeds är mer än maxBeds ge felmeddelande
                        while (!int.TryParse(bedCount, out extraBeds) || extraBeds < 0 || extraBeds > maxExtraBeds)
                        {
                            Console.WriteLine($"Vänligen ange ett nummer mellan 0 och {maxExtraBeds}.");
                            bedCount = Console.ReadLine(); // användaren ska få en ny chans att mata in rätt värde.
                        }
                    }



                    // Uppdatera allt som har med HotelMAnager att göra

                    // Skapa en ny id genom att ta hotelManagers Rooms LISTA och går igenom listan och räknar med hjälp av Count
                    // Count är en property som tillhör List<T> i C# Den räknar hur många element(rum) som finns i listan.
                    int newId = hotelManager.Rooms.Count + 1; // + 1 Skapar nytt ID i ordning för vi har ju 4 seed
                    
                    // Skapar en ny string rumsnamn. Rums namnet beror på ID så om ID är 5 ska rumsnamn vara 105. Lättare att komma ihåg.
                    string roomName = $"Rum {100 + newId}"; // Skapar rumsnamn t.ex. "Rum 101"
                    
                    // Skapar ett nytt rums objekt av klassen Rooms med nya id och alla andra element som vi bestämt ovan
                    Room newRoom = new Room(newId, roomName, roomType, extraBeds);

                    // Ropar på HotelManager klassens metod AddRoom som ska lägga till i listan.
                    hotelManager.AddRoom(newRoom);

                    // Ge meddelande till user om att bokningen är klar
                    Console.WriteLine($"Rum {roomName} Bokat! Du har skapat {roomType} med {extraBeds} extrasäng(ar).");
                    break;



                case 2:
                    Console.Write("Vänligen ange rumsnamnet för det rum du vill ändra (Ex: Rum 101): ");

                    // Ta emot användarens svar i string 
                    string? input = Console.ReadLine();


                    // Konvertera och hantera ? från    -->    "string? input = Console.ReadLine();"
                    int roomNumber; // behöver deklareras utanför while-loopen för att den ska vara tillgänglig efter att loopen är klar       
                    while (!int.TryParse(input, out roomNumber)) // Hade jag inte deklarerat roomNumber över while loopen hade jag varit tvungen att lägga "int" framför out
                    {
                        Console.WriteLine("Vänligen skriv in ett giltigt nummer: ");
                        input = Console.ReadLine(); // denna rad så användaren kan fortsätta skriva in svar tills han ger ett korrekt svar
                    }


                    // Kolla om rummet ens finns i hotelManager.Rooms
                    var roomToEdit = hotelManager.Rooms.Find(r => r.RoomName == input); // var är en room objekt från Room klassen

                    // Hanter om find inte hittar rummet
                    if (roomToEdit != null)
                    {
                        Console.WriteLine($"Du har valt att ändra {roomToEdit.RoomName}");
                    }
                    else
                    {
                        Console.WriteLine("Rummet kunde inte hittas.");
                    }


                    // Låt användaren välja det som ska ändras i rummet
                    Console.WriteLine("1. Rumsnamn (Ex: Rum 101)");
                    Console.WriteLine("2. Rumstyp (Ex: enkelrum/dubbelrum)");
                    Console.WriteLine("3. Extrasängar");
                    Console.WriteLine();
                    Console.Write("Vänligen välj ett alternativ genom att skriva in siffran för det val du önskar och tryck på Enter: ");

                    // Ta emot användarens input 
                    string? inputString = Console.ReadLine();

                    // Deklarera variabeln som ska skapas när inputString konverteras. dvs variabeln i while loopen nedan
                    int userChoice;

                    // Konvertera, hantera ?, låt användaren testa skriva tills hen skriver rätt
                    while(!int.TryParse(inputString, out userChoice) || userChoice > 4 || userChoice < 1)
                    {
                        Console.WriteLine("Vänligen ange ett nummer mellan 1 - 3");
                        inputString = Console.ReadLine();
                    }

                    // Hantera alla alternativ med en switch sats
                    switch (userChoice)
                    {
                        case 1:
                            Console.Write($"Ditt nuvarande rumsnamn är: {roomToEdit.RoomName}. Skriv det rumsnamn du vill byta till : ");

                            // Ta emot input
                            string? newRoomName = Console.ReadLine();

                            // Hantera null ( ? )
                            while (string.IsNullOrWhiteSpace(newRoomName))
                            {
                                Console.WriteLine("Vänligen skriv in ett giltigt rumsnamn");
                                newRoomName = Console.ReadLine(); // Ge flera chanser till användaren skriver utan null eller tom sträng
                            }

                            // Kolla om rumsnamnet redan är upptaget om så fallet låt användaren ge nya namn tills han lyckas
                            while(hotelManager.Rooms.Any(r => r.RoomName == newRoomName))
                            {
                                Console.WriteLine($"Det finns redan ett rum som heter {newRoomName}. Vänligen välj ett nytt namn: ");
                                newRoomName = Console.ReadLine(); // Låt användaren skriva in ett nytt namn
                            }

                            // Den letar igenom listan av rum i hotelManager.Rooms och hittar det första rummet där rumsnamnet är detsamma som roomToEdit´s roomName.
                            var rooom = hotelManager.Rooms.First(r => r.RoomName == roomToEdit.RoomName); // First :  returnerar det första elementet som uppfyller ett givet villkor (här, att rumsnamnet matchar).
                                                                                                // Det används när man förväntar sig att hitta minst ett matchande objekt och vill ha just det första som hittas.

                            // Uppdatera rumsnamnet i room objektet till newRoomName
                            rooom.RoomName = newRoomName;

                            // Meddela användaren om bytet
                            Console.WriteLine($"Rumsnamnet ändrades till {newRoomName}");
                            break;

                        case 2:
                            Console.Write($"Ditt nuvarande rumstyp är: {roomToEdit.RoomType}. Ange den nya rumstypen (t.ex. enkelrum eller dubbelrum): ");

                            // Ta emot input
                            string? newRoomType = Console.ReadLine();

                            // Hantera ?, alltås om newRoomType är null lr mellanslag
                            while (string.IsNullOrWhiteSpace(newRoomType))
                            {
                                Console.WriteLine("Vänligen ange en giltig rumstyp.");
                                newRoomType = Console.ReadLine();
                            }

                            // Uppdatera roomToEdits RoomType till användarens nya önskemål som är newRoomType
                            roomToEdit.RoomType = newRoomType;

                            // Meddela användaren
                            Console.WriteLine($"Rumstypen har ändrats till {newRoomType}.");
                            break;

                        case 3:
                            Console.Write($"Ditt nuvarande val av extrasängar är: {roomToEdit.ExtraBeds}. Ange det nya antalet extrasängar: ");

                            // ta emot input
                            string? extraBedsinput = Console.ReadLine();

                            // denna variabel är den som kommer att uppdateras efter konverteringen i while
                            int newExtraBeds;

                            // Konvertera och hantera ?
                            while(!int.TryParse(extraBedsinput, out newExtraBeds) || newExtraBeds < 1 || newExtraBeds > 2)
                            {
                                Console.WriteLine("Vänligen ange ett giltigt nummer mellan 1 och 2:");
                                extraBedsinput = Console.ReadLine();
                            }

                            // Updatera roomToEdits ExtraBeds property med den nya newExtraBeds
                            roomToEdit.ExtraBeds = newExtraBeds;

                            // Meddela användaren om detta
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
                    while(!hotelManager.Rooms.Any(r => r.RoomName == roomGettingDeleted))
                    {
                        Console.WriteLine("Rummet du vill ta bort kunde inte hittas. Vänligen skriv in ett giltigt rumsnamn: ");
                        roomGettingDeleted = Console.ReadLine();
                    }

                    // Döp rummet (till room) som hittades och som användaren sökte så att du kan i nästa steg deleta
                    var room = hotelManager.Rooms.Find(r => r.RoomName == roomGettingDeleted); // First :  returnerar det första elementet som uppfyller ett givet villkor (här, att rumsnamnet matchar).
                                                                                               // Det används när man förväntar sig att hitta minst ett matchande objekt och vill ha just det första som hittas.
                    // Ta bort rummet
                    hotelManager.Rooms.Remove(room);

                    // Meddela användaren
                    Console.WriteLine($"Rummet {roomGettingDeleted} har tagits bort. ");
                    
                    break;


                case 4:
                    ReturnToMainMenu();
                    break;
            }

           
        }







        // Kund Meny
        static void ShowCustomerMenu()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("|\t1. Lägg till ny kund         |");
            Console.WriteLine("|\t2. Visa alla kunder          |");
            Console.WriteLine("|\t3. Ändra kunduppgifter       |");
            Console.WriteLine("|\t4. Ta bort kund              |");
            Console.WriteLine("|\t5. Återvänd till Huvudmeny   |");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("======================================");


            // Ska bestämmas i while loopen när användaren ger svar men nu deklarerar jag bara så vi kan ändra värdet beroende på vad anvndaren säger
            int choice;

            // Hantera om användaren skriver fel siffra
            while (true)
            {
                // Fråga om inpput
                Console.Write("Vänligen välj ett alternativ genom att skriva in siffran för det val du önskar och tryck på Enter: ");

                // Lagra input
                string? input = Console.ReadLine();

                // Hantera ? och om det är mer eller mindre än 5
                if (int.TryParse(input, out choice) && choice <= 5 && choice >= 1)
                {
                    break; // Bryt loopen så du kan gå t switchen
                }

                Console.WriteLine("Vänligen välj en siffra från menyn 1 - 5.");
            }

            // Hantera kundens önskemål i submenyn beroende på vad hen vlt genom submeny
            switch (choice)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    ReturnToMainMenu();
                    break;
            }

          
        }







        // Boknings Meny
        static void ShowBookingMenu()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("|\t1. Skapa ny bokning          |");
            Console.WriteLine("|\t2. Visa alla bokningar       |");
            Console.WriteLine("|\t3. Ändra bokning             |");
            Console.WriteLine("|\t4. Avboka en bokning         |");
            Console.WriteLine("|\t5. Återvänd till Huvudmeny   |");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("======================================");


            // Ska bestämmas i while loopen när användaren ger svar men nu deklarerar jag bara så vi kan ändra värdet beroende på vad anvndaren säger
            int choice;

            // Hantera om användaren skriver fel siffra
            while (true)
            {
                // Fråga om inpput
                Console.Write("Vänligen välj ett alternativ genom att skriva in siffran för det val du önskar och tryck på Enter: ");

                // Lagra input
                string? input = Console.ReadLine();

                // Hantera ? och om det är mer eller mindre än 5
                if (int.TryParse(input, out choice) && choice <= 5 && choice >= 1)
                {
                    break; // Bryt loopen så du kan gå t switchen
                }

                Console.WriteLine("Vänligen välj en siffra från menyn 1 - 5.");
            }

            // Hantera kundens önskemål i submenyn beroende på vad hen vlt genom submeny
            switch (choice)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    ReturnToMainMenu();
                    break;
            }

        }







        // Tillgänglighets Meny
        static void AvailabilityMenu()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("|\t1. Sök lediga rum            |");
            Console.WriteLine("|\t2. Rumsstatus                |");
            Console.WriteLine("|\t3. Återvänd till Huvudmeny   |");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("======================================");


            // Ska bestämmas i while loopen när användaren ger svar men nu deklarerar jag bara så vi kan ändra värdet beroende på vad anvndaren säger
            int choice;

            // Hantera om användaren skriver fel siffra
            while (true)
            {
                // Fråga om inpput
                Console.Write("Vänligen välj ett alternativ genom att skriva in siffran för det val du önskar och tryck på Enter: ");

                // Lagra input
                string? input = Console.ReadLine();

                // Hantera ? och om det är mer eller mindre än 5
                if (int.TryParse(input, out choice) && choice <= 3 && choice >= 1)
                {
                    break; // Bryt loopen så du kan gå t switchen
                }

                Console.WriteLine("Vänligen välj en siffra från menyn 1 - 5.");
            }

            // Hantera kundens önskemål i submenyn beroende på vad hen vlt genom submeny
            switch (choice)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:              
                    Console.WriteLine("Återvänder till huvudme" +
                        "nyn...");
                    Thread.Sleep(1000);
                    return; // Bryter loopen och återvänder till huvudmenyn
                    //  Behöver ingen default för jag säkerställde i while loopen innan switch satsen att siffran ska vara mellan 1-5
            }

           
        }





        // Paus metod
        static void Pause()
        {
            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }










        // Metod som finns i alla switch satsers sista case så man kan återvända till huvudmenyn
        static void ReturnToMainMenu()
        {
            Console.WriteLine("Återvänder till huvudmenyn...");
            Thread.Sleep(1000);
            return; // Bryter loopen och återvänder till huvudmenyn
                    //  Behöver ingen default för jag säkerställde i while loopen innan switch satsen att siffran ska vara mellan 1-5
        }


    }
}
