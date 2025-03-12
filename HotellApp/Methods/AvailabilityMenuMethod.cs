using HotellApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp.Methods
{
    internal class AvailabilityMenuMethod
    {
        // Tillgänglighets Meny
        public static void AvailabilityMenu(Classes.HotelManager hotelManager, ApplicationDbContext dbContext)
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("|\t1. Visa alla bokningar       |");
            Console.WriteLine("|\t2. Visa alla rum             |");
            Console.WriteLine("|\t3. Visa alla kunder          |");
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
                    Console.WriteLine();
                    hotelManager.ShowBookings();
                    break;

                case 2:
                    Console.WriteLine();
                    hotelManager.ShowRooms();
                    break;

                case 3:
                    Console.WriteLine();
                    hotelManager.ShowCustomers();
                    break;

                case 4:
                    return; // Bryter loopen och återvänder till huvudmenyn
                    //  Behöver ingen default för jag säkerställde i while loopen innan switch satsen att siffran ska vara mellan 1-5
            }


        }

    }
}
