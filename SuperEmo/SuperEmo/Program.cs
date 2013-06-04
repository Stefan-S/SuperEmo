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
            nevena.sensitivity = 1;
            nevena.save("nevena.txt");

            //PROMENA
            for (int i = 0; i < 300; i++)
            {
                Console.Clear();
                env.drawEnvironment();
                Console.WriteLine(nevena.getState());

                int[] tiles = env.lastNStates(4); //zadnji 4
                int a = nevena.getAction(); //zemi akcija od agent
                nevena.takeAction(a,a,tiles[0],tiles[1],tiles[2]); //na agent take action so akcijata od prethodniot cekor
                env.generateState();
                System.Threading.Thread.Sleep(100);
            }

            Console.Write("\n");
        }
    }
}
