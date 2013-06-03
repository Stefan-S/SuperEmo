using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperEmo
{
    //the agent
    class Agent
    {
 

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
        public int [,,,,] genome =  new int[3,3,6,6,6];
        
        /* indication whether the Agent is
         * 0 - high
         * 1 - stand
         * 2 - low
         */
        int state=1;

        /* indication whether the Agent on ground 
         * 0 - Walkable
         * 1 - Walkable gold low
         * 2 - Walkable gold high
         * 3 - Danger
         * 4 - Danger gold
         * 5 - Obsticle
         * the number after the name indicates the type of the next three tiles 
         */
        int ground0 = 0;
        int ground1 = 0;
        int ground2 = 0;

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

        Random randomNumberGenerator = new Random();

        public void save(String file)
        {
            String saved = "";
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
                                saved += genome[i1, i2, i3, i4, i5] + ",";
                            }
                        }
                    }
                }
            }
            saved = saved.Substring(0, saved.Length-1);
            saved += "\n" + curiosity;
            saved += "\n" + sensitivity;
            saved += "\n" + gold + "\n" + tilesPassed + "\n" + lives;
            System.IO.File.WriteAllText(file, saved);

        }

        public void load(String file)
        {
            String text = System.IO.File.ReadAllText(file);
            String [] lines = text.Split('\n');
            String [] textgenome = lines[0].Split(',');

            int globalCount = 0;
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
                                genome[i1, i2, i3, i4, i5] = int.Parse(textgenome[globalCount]);
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


        int getAction()
        {
            int jump = this.genome[0,this.state,this.ground0,this.ground1,this.ground2];
            int walk = this.genome[1, this.state, this.ground0, this.ground1, this.ground2];
            int slide = this.genome[2, this.state, this.ground0, this.ground1, this.ground2];

            int solution = max(jump, walk);
            solution = max(solution, slide);

            //there the curiousity kicks in
            /* the number is between 0-1
             * it representas the probability that the agent will take
             * an action even though it (for now) thinks it is not the optimal
             */
            if (randomNumberGenerator.Next(0, 101) < this.curiosity * 100)
            {
                solution=(solution+coin()+1)%3;
            }

            return solution;
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

        public int coin()//returns 0 or 1
        {
            return randomNumberGenerator.Next(0, 2);
        }

        public void takeAction(int action, int state, int ground0, int ground1, int ground2){
        }

        public int getState()
        {
            return this.state;
        }
    }
}
