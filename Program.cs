using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF49_16
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("");
            IspisiGlavniMenu();

        }
        private static void IspisiGlavniMenu()
        {
            int izbor = 0;
            do
            {
                do
                {
                    Console.WriteLine("1. Rad sa namestajem");
                    // gajbi ostatak
                    Console.WriteLine("0. Izlaz iz aplikacije");
                    izbor = int.Parse(Console.ReadLine());
                } while (izbor < 0 || izbor > 2); //dodaj posle izbor > 2

                switch (izbor)
                {
                    case 1:
                        NamestajMenu();
                        break;
                    case 2:

                    default:
                        break;
                }

            } while (izbor != 0);
        }

        private static void NamestajMenu()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("==================RAD SA NAMESTAJEM =======================sssss");
                IspisiCRUDMenu();

                izbor = int.Parse(Console.ReadLine());

            } while (izbor > 0 || izbor >4);
        }
        

        private static void IspisiCRUDMenu()
        {
            Console.WriteLine("1. Prikazi listing");
            Console.WriteLine("2. Dodaj novi");
            Console.WriteLine("3. Izmeni postojeci");
            Console.WriteLine("4. Obrisi postojeci");
        }
    }
}
