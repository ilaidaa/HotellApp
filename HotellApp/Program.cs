using System.Diagnostics;
using System;
using System.Runtime.Intrinsics.Arm;
using static System.Runtime.InteropServices.JavaScript.JSType;
using HotellApp.Methods;

namespace HotellApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Classes.HotelManager hotelManager = new Classes.HotelManager(); // Ropa metoden från Classes mappen


            // Bool för att köra programmet tills användaren stoppar
            bool runProgram = true;
            while (runProgram)
            {

                // Visa meny 
                ShowMainMenuMethod.ShowMainMenu();

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
                    Console.WriteLine();

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
                            ShowBookingMenuMethod.ShowBookingMenu(hotelManager);
                            break;

                        case 4:
                            // Visa submeny 4
                            AvailabilityMenuMethod.AvailabilityMenu(hotelManager);
                            break;

                        case 5:
                            runProgram = false;
                        break;

                        //  Behöver ingen default för jag säkerställde i while loopen innan switch satsen att siffran ska vara mellan 1-5

                    }

                PauseMethod.Pause();

            }



        }




    }
}
