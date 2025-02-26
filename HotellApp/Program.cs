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
                        ShowRoomMenuMethod.ShowRoomMenu(hotelManager);
                            break;

                        case 2:
                            // Visa Submeny 2
                            ShowCustomerMenuMethod.ShowCustomerMenu(hotelManager);

                            break;

                        case 3:
                            // Visa submeny 3
                            ShowBookingMenu(hotelManager);
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











        // Metod som skriver ut Huvudmenyn
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














        // Boknings Meny
        static void ShowBookingMenu(HotelManager hotelManager)
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("|\t1. Skapa ny bokning          |");
            Console.WriteLine("|\t2. Ändra bokning             |");
            Console.WriteLine("|\t3. Avboka en bokning         |");
            Console.WriteLine("|\t4. Återvänd till Huvudmeny   |");
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
                    Console.WriteLine("Befintliga Kunder:");
                    foreach(var customer in hotelManager.Customers)
                    {
                        Console.WriteLine($"- Kund ID: {customer.Id},  Namn: {customer.Name}, Email: {customer.Email}, Tel: {customer.PhoneNumber})");
                    }

                    // Ta emot ID från personen som ska göra en bookning
                    Console.WriteLine();
                    Console.Write("Vänligen ange kund ID på personen du vill göra en ny bokning för: ");

                    // Ta emot kund id 
                    string? inputCustomerId = Console.ReadLine();

                    // Skapa en int variabel som ska vara den nya customerId när inputCustomerId stringen konverteras
                    int customerId;

                    // Hantera vad som gänder om inputCustomerID inte lyckas konverteras eller om Kund Id inte hittas
                    while(!int.TryParse(inputCustomerId, out customerId) || !hotelManager.Customers.Any(c => c.Id == customerId))
                    {
                        Console.WriteLine();
                        Console.Write("Fel: Ange ett giltigt kund-ID: ");
                        inputCustomerId = Console.ReadLine(); // Låt användaren försöka tills hen får rätt.
                    }






                    // Visa befintliga rum för att göra det tydligt för användaren att kunna välja rum ID
                    Console.WriteLine("Befintliga Rum: ");
                    foreach(var room in hotelManager.Rooms)
                    {
                        Console.WriteLine($"Rum ID: {room.Id}, Namn: {room.RoomName}, Typ: {room.RoomType}, Extrasängar: {room.ExtraBeds})");
                    }

                    // Ta emot ID från personen som ska göra en bookning
                    Console.WriteLine();
                    Console.Write("Vänligen ange rums ID på rummet du vill göra en ny bokning för: ");

                    // Ta emot input i string
                    string? inputRoomId = Console.ReadLine();

                    // Skapa en int variabel som ska vara den nya roomId när inputCustomerId stringen konverteras
                    int roomId;

                    // Hantera vad som händer om inputRoomID inte lyckas konverteras eller om rum Id inte hittas
                    while (!int.TryParse(inputRoomId, out roomId) || !hotelManager.Rooms.Any(r => r.Id == roomId))
                    {
                        Console.WriteLine();
                        Console.Write("Fel: Ange ett giltigt rums-ID: ");
                        inputRoomId = Console.ReadLine();
                    }





                    // Ta emot startdatum för vistelsen
                    Console.WriteLine();
                    Console.Write("Ange startdatum (YYYY-MM-DD) för bokningen: ");

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
                    hotelManager.MakeBooking(customerId, roomId, startDate, nights);
                    break;


                case 2:
                    break;
                case 3:
                    break;
                case 4:
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





        // Metod som har i syfte att pausa
        static void Pause()
        {
            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }










        // Metod som finns i alla switch satsers sista case så man kan återvända till huvudmenyn
        public static void ReturnToMainMenu() // Jag la public static framför så att man kan anropa metoden i alla fliker såsom program, ShowRoomMenuMETHOD osv.
        {
            Console.WriteLine();
            return; // Bryter loopen och återvänder till huvudmenyn
                    //  Behöver ingen default för jag säkerställde i while loopen innan switch satsen att siffran ska vara mellan 1-5
        }


    }
}
