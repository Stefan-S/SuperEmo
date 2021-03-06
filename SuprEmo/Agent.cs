﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuprEmo
{
        //the agent
    public class Agent
    {

        //tabula rasa constructor
        //that wants coins
        //and wants to live
        public Agent()
        {

            for (int i1 = 0; i1 < 3; i1++)
            {
                for (int i2 = 0; i2 < 3; i2++)
                {
                    for (int i3 = 0; i3 < 6; i3++)
                    {
                        for (int i4 = 0; i4 < 6; i4++)
                        {
                            for (int i5 = 0; i5 < 6; i5++)
                            {
                                //doesnt want to be stand or low above danger
                                if ((i2 == 1 && i3 == 3) || (i2 == 2 && i3 == 3))
                                    genome[i1, i2, i3, i4, i5] = -20;

                                //doesnt want to stand or high below obsticle
                                if ((i2 == 1 && i3 == 5) || (i2 == 0 && i3 == 5))
                                    genome[i1, i2, i3, i4, i5] = -20;


                                //doesnt want to be stand or low above danger gold
                                if ((i2 == 1 && i3 == 4) || (i2 == 2 && i3 == 4))
                                    genome[i1, i2, i3, i4, i5] = -20;


                                //wants to be high on Walkable gold high and danger gold
                                if ((i2 == 0 && i3 == 2) || (i2 == 0 && i3 == 4))
                                    genome[i1, i2, i3, i4, i5] = 20;

                                //wants to stand or low on walkable gold low
                                if ((i2 == 1 && i3 == 1) || (i2 == 2 && i3 == 1))
                                    genome[i1, i2, i3, i4, i5] = 20;
                            }
                        }
                    }
                }
            }
        }

        /*
         * genome: 0
         * 0 - jump
         * 1 - foreward
         * 2 - slide
         * 
         * genome: 1
         * 0 - high
         * 1 - stand
         * 2 - low
         * 
         * genome: 2 3 and 4
         * 0 - Walkable
         * 1 - Walkable gold low
         * 2 - Walkable gold high
         * 3 - Danger
         * 4 - Danger gold
         * 5 - Obsticle
         */
        //matrix of states 5d (space)
        public int[, , , ,] genome = new int[3, 3, 6, 6, 6];

        /* indication whether the Agent is
         * 0 - high
         * 1 - stand
         * 2 - low
         */
        int state = 1;

        /* indication whether the Agent on ground 
         * 0 - Walkable
         * 1 - Walkable gold low
         * 2 - Walkable gold high
         * 3 - Danger
         * 4 - Danger gold
         * 5 - Obsticle
         * the number after the name indicates the type of the next three tiles 
         */
        int tile0 = 0;
        int tile1 = 0;
        int tile2 = 0;


        //probailiy that the agent will try an action even though it knows there is a better action
        public double curiosity;

        //1-probaility that he will supress the emotion
        public double sensitivity;

        //highScore for gold collected in a single run
        public int gold;

        //highscore for tiles passed
        public int tilesPassed;

        //lives lived
        public int lives;


        Random randomNumberGenerator = new Random(DateTime.Now.Millisecond);

        /* @args file: the file in which the genome and the
         * personalisation parameters will be saved.
         */
        public void save(String file)
        {
            String saved = "";
            for (int i1 = 0; i1 < 3; i1++)
            {
                for (int i2 = 0; i2 < 3; i2++)
                {
                    for (int i3 = 0; i3 < 6; i3++)
                    {
                        for (int i4 = 0; i4 < 6; i4++)
                        {
                            for (int i5 = 0; i5 < 6; i5++)
                            {
                                saved += genome[i1, i2, i3, i4, i5] + ",";
                            }
                        }
                    }
                }
            }

            saved = saved.Substring(0, saved.Length - 1);
            saved += "\n" + curiosity;
            saved += "\n" + sensitivity;
            saved += "\n" + gold + "\n" + tilesPassed + "\n" + lives;
            System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\" + file, saved);

        }

        public void load(String file)
        {
            String text = System.IO.File.ReadAllText(file);
            String[] lines = text.Split('\n');
            String[] textgenome = lines[0].Split(',');

            int globalCount = 0;
            for (int i1 = 0; i1 < 3; i1++)
            {
                for (int i2 = 0; i2 < 3; i2++)
                {
                    for (int i3 = 0; i3 < 6; i3++)
                    {
                        for (int i4 = 0; i4 < 6; i4++)
                        {
                            for (int i5 = 0; i5 < 6; i5++)
                            {
                                genome[i1, i2, i3, i4, i5] = int.Parse(textgenome[globalCount++]);
                            }
                        }
                    }
                }
            }

            curiosity = int.Parse(lines[1]);
            sensitivity = int.Parse(lines[2]);
            gold = int.Parse(lines[3]);
            tilesPassed = int.Parse(lines[4]);
            lives = int.Parse(lines[5]);
        }


        public int getAction()
        {
            if (state == 1)
            {
                int[] actions = new int[3];
                actions[0] = this.genome[0, state, tile0, tile1, tile2];
                actions[1] = this.genome[1, state, tile0, tile1, tile2];
                actions[2] = this.genome[2, state, tile0, tile1, tile2];
                //if in state high cannot jump, and cannot slide
                //if in slide, cannot jump and cannot slide

                int solution = findMax(actions);
                //there the curiousity kicks in
                /* the number is between 0-1
                 * it representas the probability that the agent will take
                 * an action even though it (for now) thinks it is not the optimal
                 */
                if (randomNumberGenerator.Next(0, 101) < this.curiosity * 99)
                {
                    solution = (solution + coin() + 1) % 3;
                }

                return solution;
            }
            else
            {
                return 1;
            }
        }


        int max(int x, int y)
        {
            if (x > y)
            {
                return x;
            }
            else if (y > x)
            {
                return y;
            }
            else
            {
                return (coin() == 0) ? x : y;
            }
        }

        int maxIndexed(int x, int y, int i, int j)
        {
            if (x > y)
            {
                return i;
            }
            else if (y > x)
            {
                return j;
            }
            else
            {
                return (coin() == 0) ? i : j;
            }
        }



        int coin()//returns 0 or 1
        {
            return randomNumberGenerator.Next(0, 2);
        }


        int withAction;
        int oldState;
        int oldtile0;
        int oldtile1;
        int oldtile2;


        public void takeAction(int action, int state, int tile0, int tile1, int tile2)
        {
            oldState = this.state;
            oldtile0 = this.tile0;
            oldtile1 = this.tile1;
            oldtile2 = this.tile2;
            withAction = action;

            this.state = state;
            this.tile0 = tile0;
            this.tile1 = tile1;
            this.tile2 = tile2;

            int thisStateEmotion = EmotionForState(state, tile0, tile1, tile2);
            if (thisStateEmotion > 0)
            {
                if (randomNumberGenerator.Next(0, 101) >= (1 - this.sensitivity) * 99)
                {
                    genome[action, oldState, oldtile0, oldtile1, oldtile2]++;
                }
            }
            else if (thisStateEmotion < 0)
            {
                if (randomNumberGenerator.Next(0, 101) >= (1 - this.sensitivity) * 99)
                {
                    genome[action, oldState, oldtile0, oldtile1, oldtile2] -= 20;
                }
            }

            this.tilesPassed++;


            //wants to be high on Walkable gold high and danger gold
            if ((state == 0 && tile0 == 2) || (state == 0 && tile0 == 4))
                this.gold++;

            //wants to stand or low on walkable gold low
            if ((state == 1 && tile0 == 1) || (state == 2 && tile0 == 1))
                this.gold++;
        }

        public int getState()
        {
            return this.state;
        }

        public int EmotionForState(int state, int tile0, int tile1, int tile2)
        {
            if (state == 1)
            {
                int jump = this.genome[0, state, tile0, tile1, tile2];
                int walk = this.genome[1, state, tile0, tile1, tile2];
                int slide = this.genome[2, state, tile0, tile1, tile2];

                int solution = max(jump, walk);
                solution = max(solution, slide);
                return solution;
            }
            else
            {
                return this.genome[1, state, tile0, tile1, tile2];
            }
        }


        public int ActionForState(int state, int tile0, int tile1, int tile2)
        {
            int[] actions = new int[3];
            actions[0] = this.genome[0, state, tile0, tile1, tile2];
            actions[1] = this.genome[1, state, tile0, tile1, tile2];
            actions[2] = this.genome[2, state, tile0, tile1, tile2];
            //if in state high cannot jump, and cannot slide
            //if in slide, cannot jump and cannot slide


            return findMax(actions);
        }

        int findMax(int[] n)
        {
            HashSet<int> maxIndexes = new HashSet<int>();
            int max = int.MinValue;
            maxIndexes.Add(max);
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] > max)
                {
                    maxIndexes.Clear();
                    max = n[i];
                    maxIndexes.Add(i);
                }
                else if (n[i] == max)
                {
                    maxIndexes.Add(i);
                }
            }

            int[] maximums = maxIndexes.ToArray();
            return maximums[randomNumberGenerator.Next(0, maximums.Length)];
        }

        public Boolean isDead(int state, int tile0)
        {
            if ((state == 1 && tile0 == 3) || (state == 2 && tile0 == 3) || (state == 1 && tile0 == 4) || (state == 2 && tile0 == 4) || (state == 1 && tile0 == 5) || (state == 0 && tile0 == 5))
                return true;
            else
                return false;
        }



        public int getTile0()
        {
            return tile0;
        }

        public int getTile1()
        {
            return tile1;
        }

        public int getTile2()
        {
            return tile2;
        }

        public int[] getLastChangedEmotionLocation()
        {
            return new int[] { withAction, oldState, oldtile0, oldtile1, oldtile2 };
        }

        public int getGenome(int wAction, int State, int tile0, int tile1, int tile2)
        {
            return genome[wAction, State, tile0, tile1, tile2];
        }

        public int[, , , ,] getCopyOfGenome()
        {
            int[, , , ,] copy = new int[3, 3, 6, 6, 6];
            for (int i1 = 0; i1 < 3; i1++)
            {
                for (int i2 = 0; i2 < 3; i2++)
                {
                    for (int i3 = 0; i3 < 6; i3++)
                    {
                        for (int i4 = 0; i4 < 6; i4++)
                        {
                            for (int i5 = 0; i5 < 6; i5++)
                            {
                                copy[i1, i2, i3, i4, i5] = genome[i1, i2, i3, i4, i5];
                            }
                        }
                    }
                }
            }
            return copy;
        }

        public int getOldState()
        {
            return oldState;
        }

        public int oldTile0()
        {
            return oldtile0;
        }
    }
}