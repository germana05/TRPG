using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    class Program
    {
        public static void Main(string[] args)
        {
            //ik heb meer duidelijkheid toegevoegd bij de crafting en shop wat je nodig hebt.
            //ik heb een informatie optie toegevoegd.
            //ik heb klassen toegevoegd.
            //skills deleted. dit is omdat het niet goed werkte en kreeg het niet opgelost.
            //kleine crafting fix.
            //commentaar overal bij toegevoegd.
            //een deel van de code een beetje beter opgeruimd voor meer overzicht.

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("welcome to my TRPG.");
            GamePlay.Name();
        }
    }
}
