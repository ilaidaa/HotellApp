using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp.Methods
{
    internal class ReturnToMainMenuMethod
    {

        // Metod som finns i alla switch satsers sista case så man kan återvända till huvudmenyn
        public static void ReturnToMainMenu() // Jag la public static framför så att man kan anropa metoden i alla fliker såsom program, ShowRoomMenuMETHOD osv.
        {
            Console.WriteLine();
            return; // Bryter loopen och återvänder till huvudmenyn
                    //  Behöver ingen default för jag säkerställde i while loopen innan switch satsen att siffran ska vara mellan 1-5
        }


    }
}
