using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DailyProgrammer349
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ih = new InputHandler("3 34312332");

            var test = Directory.GetCurrentDirectory() + @"\input.txt";  // is the working directory of the compiled exe (in bin\debug)
            var fileInputReader = new FileInputGetter(@"C:\Users\Nick\source\repos\DailyProgrammer349\DailyProgrammer349\input.txt");
            var ih = new InputHandler(fileInputReader.GetInput());
            var bsvc = new BoxStackingViabilityChecker(ih);


            if (bsvc.GetBoxStackingPossibility() == true)
            {
                var bs = new BoxStacker(ih, bsvc.GetDivisibility());
                Console.WriteLine("Time to write some boxes.");

            }

            else
            {
                Console.WriteLine("Not the time to write boxes.");
            }

            Console.Write("Press any key to continue...");         
            Console.ReadLine();
        }
    }
}
