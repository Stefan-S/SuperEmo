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
        
        //probailiy that the agent will try an action even though it knows there is a better action
        public double curiosity;
        
        //1-probaility that he will supress the emotion
        public double sensitivity;

        //highScore for gold collected in a single run
        public int gold;

        //highscore for units passed
        public int units;

        //lives lived
        public int lives;

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
            saved += "\n" + gold + "\n" + units + "\n" + lives;
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
            units = int.Parse(lines[4]);
            lives = int.Parse(lines[5]);
        }
    }
}
