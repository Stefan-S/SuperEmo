﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperEmo
{
    class Enviroment
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

        public Enviroment()
        {
            //walkable
            states.AddLast(0);
            states.AddLast(0);
            states.AddLast(0);
            generateState();
            generateState();

        }
        
        
        LinkedList<int> states = new LinkedList<int>();
        Random randomNumberGenerator = new Random();
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
                    nextState = randomNumberGenerator.Next(0, 5);
                    break;
                case 3:
                case 4:
                case 5:
                    nextState = randomNumberGenerator.Next(0, 2);
                    break;
            }
            states.AddLast(nextState);
            return nextState;
        }
    }
}