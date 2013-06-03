using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperEmo
{
    class Program
    {
        static void Main(string[] args)
        {
            Enviroment env = new Enviroment();
            Agent nevena = new Agent();
            nevena.save(Environment.CurrentDirectory+"\\nevena.txt");

            //PROMENA
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();
                env.drawEnvironment();
                env.generateState();
                System.Threading.Thread.Sleep(1000);
            }

            Console.Write("\n");
        }
    }
}
