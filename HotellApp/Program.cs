namespace HotellApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

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

                    Console.WriteLine("Fel: Välj en siffra från menyn 1 - 5.");
                    
                }





                   // Hantera subval
                    switch (choice)
                    {
                        case 1:

                            // Visa Submeny 1
                            ShowRoomMenu();

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

                        default:
                            Console.WriteLine("Fel: Välj en siffra från menyn (1-5).");
                            break;

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
        static void ShowRoomMenu()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("|\t1. Lägg till nytt rum        |");
            Console.WriteLine("|\t2. Visa alla rum             |");
            Console.WriteLine("|\t3. Ändra rumsuppgifter       |");
            Console.WriteLine("|\t4. Ta bort rum               |");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("======================================");
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
            Console.WriteLine("|\t                             |");
            Console.WriteLine("======================================");
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
            Console.WriteLine("|\t                             |");
            Console.WriteLine("======================================");
        }



        // Tillgänglighets Meny
        static void AvailabilityMenu()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("|\t1. Sök lediga rum            |");
            Console.WriteLine("|\t2. Rumsstatus                |");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("======================================");
        }


        static void Pause()
        {
            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }

    }
}
