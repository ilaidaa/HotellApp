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










        // Kund Meny
        static void ShowCustomerMenu()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("|\t1. Lägg till ny kund         |");
            Console.WriteLine("|\t2. Ändra kunduppgifter       |");
            Console.WriteLine("|\t3. Ta bort kund              |");
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
            Console.WriteLine("Återvänder till huvudmenyn...");
            Thread.Sleep(1000);
            return; // Bryter loopen och återvänder till huvudmenyn
                    //  Behöver ingen default för jag säkerställde i while loopen innan switch satsen att siffran ska vara mellan 1-5
        }


    }
}
