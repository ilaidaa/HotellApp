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
        static void ShowRoomMenu()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("|\t1. Lägg till nytt rum        |");
            Console.WriteLine("|\t2. Visa alla rum             |");
            Console.WriteLine("|\t3. Ändra rumsuppgifter       |");
            Console.WriteLine("|\t4. Ta bort rum               |");
            Console.WriteLine("|\t5. Återvänd till Huvudmeny   |");
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

                Console.WriteLine("Fel: Välj en siffra från menyn 1 - 5.");
            }

            // Hantera kundens önskemål i submenyn beroende på vad hen vlt genom submeny
            switch (choice)
            {
                case 1:

                    // Enkel rum eller dubbelrum
                    int roomChoice; // För att kunna hantera while loopen där enkel eller dubbel rum bestäms.
                    Console.WriteLine();
                    Console.WriteLine("1. Välj enkelrum.");
                    Console.WriteLine("2. Välj dubbelrum liten (60 kvm)");
                    Console.WriteLine("3. Välj dubbelrum stor (100 kvm)");
                    string? inputRoom = Console.ReadLine(); // Ta emot input men hantera ?
                    
                    // går ej konvertera t int, checka om svaret är mindre än ett eller större än 3 
                    // så om det ovan stämmer ge fel
                    while ((!int.TryParse(inputRoom, out roomChoice) || roomChoice < 1 || roomChoice > 3))
                    {
                            Console.WriteLine("FEL: Välj en siffra i menyn 1 – 3."); 
                            inputRoom = Console.ReadLine(); // Låt användaren ge nytt värde utan att ställa frågan igen.
                        
                    }

                    //Om han lyckats skriva rätt kommer det som händer i varje rums alternativ t.ex dubbelrum liten en säng osv
                    switch (roomChoice)
                    {
                        case 1:
                            Console.WriteLine($"Du har bokat enkelrum: //skriv rumsnamn här fortsätt koda//");
                            break;
                        
                        case 2:
                            Console.Write("Du har valt dubbelrum liten (60 kvm). Vill du lägga till en extrasäng? (JA/NEJ): ");
                            string? singleRoomAnswer;

                            while (true)
                            {
                                singleRoomAnswer = Console.ReadLine().Trim().ToLower(); // Tar bort mellanslag och omvandlar till små bokstäver

                                if (string.IsNullOrWhiteSpace(singleRoomAnswer)) // Hantera vad som händer om ? och isnullorWhiteSpace sker
                                {
                                    Console.WriteLine("FEL: skriv in en JA eller NEJ.");
                                    continue; // Gör så att man forstätter fråga frågan för den går tillbaka till while
                                              // continue; hoppar över resten av iterationen och startar om loopen från början.
                                              // break; avslutar loopen helt.
                                }

                                switch (singleRoomAnswer)
                                {
                                    case "ja":
                                        Console.WriteLine();
                                        Console.WriteLine("BOKAT! Du har bokat dubbelrum liten (60 kvm) och lagt till en extrasäng.");
                                        break;
                                    case "nej":
                                        Console.WriteLine();
                                        Console.WriteLine("BOKAT! Du har bokat dubbelrum liten (60 kvm) utan en extrasäng.");
                                        break;
                                    default:
                                        Console.WriteLine();
                                        Console.Write("FEL: skriv in JA eller NEJ: ");
                                        continue; // Fråga igen om svaret är ogiltigt
                                }
                                break; // Avsluta while loopen om vi fått ett giltigt svar
                            }
                            break; // Avsluta case:et
                        
                        case 3:

                            Console.Write("Du har valt dubbelrum stor (100 kvm). Vill du lägga till extrasängar? (JA/NEJ): ");
                            string? doubleRoomAnswer;

                            while (true)
                            {
                                doubleRoomAnswer = Console.ReadLine().Trim().ToLower();

                                if (string.IsNullOrWhiteSpace(doubleRoomAnswer))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("FEL: skriv in en JA eller NEJ.");
                                    continue;
                                }

                                switch (doubleRoomAnswer)
                                {
                                    case "ja":
                                        Console.Write("Du kan max boka 2 sängar. Skriv in antal sängar ( 1/2 ): ");
                                        string? inputBed;

                                        // Hantera bokningar av sängar
                                        while (true)
                                        {
                                            inputBed = Console.ReadLine(); // När personen failar med inmatning ska de få en ny chans att mata in I SJÄLVA WHILE loopen 

                                            if(int.TryParse(inputBed, out int bed) && (bed == 1 || bed == 2)) // Hantera ?, hantera att de mellan 1-2
                                            {
                                                switch (bed)
                                                {
                                                    case 1:
                                                        Console.WriteLine();
                                                        Console.WriteLine("BOKAT! Du har bokat dubbelrum stor (100 kvm) med 1 extrasäng.");
                                                        break;
                                                    case 2:
                                                        Console.WriteLine();
                                                        Console.WriteLine("BOKAT! Du har bokat dubbelrum stor (100 kvm) med 2 extrasängar.");
                                                        break;
                                                }
                                                break; // Avslutar while-loopen efter giltig inmatning!!!!! tog 70 h att hitta felet KUL :)
                                            }
                                            else
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("FEL: Skriv in 1 eller 2.");
                                            }
                                        }
                                        break;

                                    case "nej":
                                        Console.WriteLine();
                                        Console.WriteLine("BOKAT! Du har bokat dubbelrum stor (100 kvm) utan extrasängar."); ;
                                        break;
                                    default:
                                        Console.WriteLine();
                                        Console.WriteLine("FEL: skriv in JA eller NEJ: ");
                                        continue; // Fråga igen om svaret är ogiltig
                                }
                                break; // Avsluta while loopen
                            }
                            break; // Avsluta case:et
                    }


                    break;
                case 2:
                    break;
                case 3: 
                    break;
                case 4:
                    break;
                case 5:
                    Console.WriteLine("Återvänder till huvudmenyn...");
                    Thread.Sleep(1000);
                    return; // Bryter loopen och återvänder till huvudmenyn
                    //  Behöver ingen default för jag säkerställde i while loopen innan switch satsen att siffran ska vara mellan 1-5
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

                Console.WriteLine("Fel: Välj en siffra från menyn 1 - 5.");
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
                    Console.WriteLine("Återvänder till huvudmenyn...");
                    Thread.Sleep(1000);
                    return; // Bryter loopen och återvänder till huvudmenyn
                    //  Behöver ingen default för jag säkerställde i while loopen innan switch satsen att siffran ska vara mellan 1-5
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

                Console.WriteLine("Fel: Välj en siffra från menyn 1 - 5.");
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
                    Console.WriteLine("Återvänder till huvudmenyn...");
                    Thread.Sleep(1000);
                    return; // Bryter loopen och återvänder till huvudmenyn
                    //  Behöver ingen default för jag säkerställde i while loopen innan switch satsen att siffran ska vara mellan 1-5
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

                Console.WriteLine("Fel: Välj en siffra från menyn 1 - 5.");
            }

            // Hantera kundens önskemål i submenyn beroende på vad hen vlt genom submeny
            switch (choice)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:              
                    Console.WriteLine("Återvänder till huvudmenyn...");
                    Thread.Sleep(1000);
                    return; // Bryter loopen och återvänder till huvudmenyn
                    //  Behöver ingen default för jag säkerställde i while loopen innan switch satsen att siffran ska vara mellan 1-5
            }

           
        }


        static void Pause()
        {
            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }

    }
}
