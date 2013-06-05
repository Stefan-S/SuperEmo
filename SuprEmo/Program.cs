using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuprEmo
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int j = 0; j < 50; j++)
            {
                AgentEnvironment env = new AgentEnvironment();
                Agent nevena = new Agent();
                nevena.sensitivity = 1;
                nevena.curiosity = 0;
                nevena.load("nevena.txt");

                //PROMENA
                for (int i = 0; i < 300; i++)
                {
                    //Console.Clear();
                    env.drawEnvironment();
                    int a = nevena.getAction(); //zemi akcija od agent
                    Console.WriteLine("State: " + nevena.getState() + " I will do: " + a + "\n");
                    System.Threading.Thread.Sleep(10);

                    int[] tiles = env.lastNStates(4); //zadnji 4
                    //ako smo poginuli
                    if (nevena.isDead(nevena.getState(), tiles[0]))
                    {
                        Console.WriteLine("Nevena je poginula :S");
                        nevena.lives++;
                        break;
                    }
                    //ako smo preziveli
                    nevena.takeAction(a, a, tiles[0], tiles[1], tiles[2]); //na agent take action so akcijata od prethodniot cekor
                    env.generateState();
                }

                //verify
                int totalIncrements = 0;
                for (int i1 = 0; i1 < 3; i1++)
                {
                    for (int i2 = 0; i2 < 3; i2++)
                    {
                        for (int i3 = 0; i3 < 5; i3++)
                        {
                            for (int i4 = 0; i4 < 5; i4++)
                            {
                                for (int i5 = 0; i5 < 5; i5++)
                                {
                                    totalIncrements += nevena.genome[i1, i2, i3, i4, i5];
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("total " + totalIncrements + "  coins " + nevena.gold);

                nevena.save("nevena.txt");
                Console.Write("\n\n\n");
            }
        }
    }
}