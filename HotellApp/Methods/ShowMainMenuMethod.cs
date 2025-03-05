using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp.Methods
{
    internal class ShowMainMenuMethod
    {
        // Metod som skriver ut Huvudmenyn
        public static void ShowMainMenu()
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
    }
}
