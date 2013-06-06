using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuprEmo
{
    public class AgentEnvironment
    {
         /*
         * states:
         * 0 - Walkable
         * 1 - Walkable gold low
         * 2 - Walkable gold high
         * 3 - Danger
         * 4 - Danger gold
         * 5 - Obsticle
         */

        public AgentEnvironment()
        {
            //walkable
            states.AddLast(0);
            states.AddLast(0);
            states.AddLast(0);
            states.AddLast(0);
            generateState();

        }


        protected LinkedList<int> pictures = new LinkedList<int>();
        protected LinkedList<int> states = new LinkedList<int>();
        protected Random randomNumberGenerator = new Random();
        public int[] nextState(){
            int[] ret = new int[3];
            ret[0] = states.Last.Previous.Value;
            ret[1] = states.Last.Value;
            ret[2] = generateState();
            return ret;
        }


        public int[] lastNStates(int n)
        {
            int[] ret = new int[n];
            var iter = states.Last;
            for (int i = n-1; i >= 0; i--)
            {
                ret[i] = iter.Value;
                if (i != 0)
                {
                    iter = iter.Previous;
                }
            }
            return ret;
        }
        

        public int generateState()
        {
            int previousState = states.Last.Value;
            int nextState = 1;
            switch (previousState)
            {
                case 0:
                case 1:
                case 2:
                    nextState = randomNumberGenerator.Next(0, 6);
                    break;
                case 3:
                case 4:
                case 5:
                    nextState = randomNumberGenerator.Next(0, 3);
                    break;
            }
            states.AddLast(nextState);
            return nextState;
        }

        public void drawEnvironment()
        {
            int[] niza = new int[5];
            niza = lastNStates(5);
            for (int i = 0; i < 5; i++)
            {
                switch(niza[i]){
                    case 0:
                        Console.Write("|   ");
                        break;
                    case 1:
                        Console.Write("|   ");
                        break;
                    case 2:
                        Console.Write("| 0 ");
                        break;
                    case 3:
                        Console.Write("|   ");
                        break;
                    case 4:
                        Console.Write("| 0 ");
                        break;
                    case 5:
                        Console.Write("| W ");
                        break;
                }
            }
            Console.Write("\n");
            for (int i = 0; i < 5; i++)
            {
                switch (niza[i])
                {
                    case 0:
                        Console.Write("|   ");
                        break;
                    case 1:
                        Console.Write("| 0 ");
                        break;
                    case 2:
                        Console.Write("|   ");
                        break;
                    case 3:
                        Console.Write("|   ");
                        break;
                    case 4:
                        Console.Write("|   ");
                        break;
                    case 5:
                        Console.Write("| V ");
                        break;
                }
            }
            Console.Write("\n");
            for (int i = 0; i < 5; i++)
            {
                switch (niza[i])
                {
                    case 0:
                        Console.Write("|___");
                        break;
                    case 1:
                        Console.Write("|___");
                        break;
                    case 2:
                        Console.Write("|___");
                        break;
                    case 3:
                        Console.Write("|   ");
                        break;
                    case 4:
                        Console.Write("|   ");
                        break;
                    case 5:
                        Console.Write("|___");
                        break;
                }
            }
            Console.Write("|\n");
        }
    }
}