using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuprEmo
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            SuprEmo.Agent nevena = (SuprEmo.Agent)Session["agent"];
            SuprEmo.AgentEnvironment environment = (SuprEmo.AgentEnvironment)Session["env"];
            if (nevena == null)
            {
                nevena = new SuprEmo.Agent();

                nevena.curiosity = 0;
                nevena.sensitivity = 1;
                //for better testing

                environment = new AgentEnvironment();
                
                //environment = new SuprEmo.AgentEnvironment();
            }
            else
            {
                if ((string)Session["pass"] == "pass")
                {
                    Session["pass"] = null;
                }
                else
                {
                    int action = nevena.getAction();
                    environment.generateState();
                    int[] tilesIn = environment.lastNStates(5);
                    nevena.takeAction(action, action, tilesIn[1], tilesIn[2], tilesIn[3]);
                }
            }

            //ginenjeto tuka e so oldState-ovi za da mozeme da go vidime
            //dole u train e so momentalni
            //neznam kako e poispravno
            if (nevena.isDead(nevena.getOldState(), nevena.oldTile0()) == true)
            {
                Agent tmp = nevena;
                nevena = new Agent();
                nevena.genome = tmp.getCopyOfGenome();
                nevena.curiosity = tmp.curiosity;
                nevena.sensitivity = tmp.sensitivity;
                nevena.lives = tmp.lives;
                environment = new AgentEnvironment();
                nevena.lives++;
            }


            Dictionary<int, String> pictures_for_tile = new Dictionary<int, string>();
            Dictionary<int, String> pictures_for_state = new Dictionary<int, string>();
            pictures_for_tile.Add(0, "Images/0_W_");


            pictures_for_tile.Add(1, "Images/1_WCL_");
            pictures_for_tile.Add(2, "Images/2_WCH_");


            pictures_for_tile.Add(3, "Images/3_D_");
            pictures_for_tile.Add(4, "Images/4_DG_");
            pictures_for_tile.Add(5, "Images/5_O_");

            pictures_for_state.Add(0, "Images/agent_0_Jump.png");
            pictures_for_state.Add(1, "Images/agent_1_Stand_" + rand.Next(0, 2) + ".png");
            pictures_for_state.Add(2, "Images/agent_2_Slide.png");

            int[] states = environment.lastNStates(5);
            String url;
            int[] skins=environment.lastNSkins(5);
            pictures_for_tile.TryGetValue(states[0], out  url);
            Image1.ImageUrl = url+skins[0]+".png";
            pictures_for_tile.TryGetValue(states[1], out  url);
            Image2.ImageUrl = url + skins[1] + ".png";
            pictures_for_tile.TryGetValue(states[2], out  url);
            Image3.ImageUrl = url + skins[2] + ".png";
            pictures_for_tile.TryGetValue(states[3], out  url);
            Image4.ImageUrl = url + skins[3] + ".png";
            pictures_for_tile.TryGetValue(states[4], out  url);
            Image5.ImageUrl = url + skins[4] + ".png";
            pictures_for_state.TryGetValue(nevena.getState(), out url);
            agent.ImageUrl = url; 
            coins.Text = nevena.gold + "";
            lives.Text = nevena.lives + "";
            tiles.Text = nevena.tilesPassed + "";
            state.Text = nevena.getState() + "";
            nextAction.Text = nevena.getAction() + "";
            currentEmotion.Text = nevena.EmotionForState(nevena.getState(), nevena.getTile0(), nevena.getTile1(), nevena.getTile2()) + "";
            int [] last = nevena.getLastChangedEmotionLocation();
            previousEmotion.Text = nevena.EmotionForState(last[1], last[2], last[3], last[4])+"";
            couriosity.Text = nevena.curiosity + "";
            sensitivity.Text = nevena.sensitivity + "";
            Matrix5D.ImageUrl = "Images/5DMatrix" + (last[0] + 1) + "" + (last[1] + 1) + ".png";

            Matrix3D.ImageUrl = "Images/3DMatrix"+(last[2]+1)+".png";
            string matrix = "<table>";
            for (int i = 0; i < 6; i++)
            {
                matrix += "<tr height=35>";
                for (int j = 0; j < 6; j++)
                {
                    if (last[3] == i && last[4] == j)
                    {
                        matrix += "<td width=35 class='target'><center>" + nevena.getGenome(last[0], last[1], last[2], i, j) + "</center></td>";
                    }
                    else if (last[3] == i || last[4] == j)
                    {
                        matrix += "<td width=35 class='line'><center>" + nevena.getGenome(last[0], last[1], last[2], i, j) + "</center></td>";
                    }
                    else
                    {
                        matrix += "<td width=35 class='none'><center>" + nevena.getGenome(last[0], last[1], last[2], i, j) + "</center></td>";
                    }
                }
                matrix += "</tr>";
            }


            matrix += "</table>";
            Matrix2D.Controls.Add(new LiteralControl(matrix));

            Session["agent"] = nevena;
            Session["env"] = environment;
        }

        public void resetButtonClick(Object sender, EventArgs e)
        {

            Session["agent"] = null;
            Session["env"] = null;
            Response.Redirect("~/default.aspx");

        }

        public void training(Object sender, EventArgs e)
        {
            train(100000);
        }

        public void HCtraining(Object sender, EventArgs e)
        {
            train(1000000);
        }

        public void couriosityDec(Object sender, EventArgs e)
        {
            SuprEmo.Agent nevena = (SuprEmo.Agent)Session["agent"];
            Session["pass"] = "pass";
            if (nevena.curiosity > 0)
            {
                nevena.curiosity -= 0.1;
            }
            Response.Redirect("~/default.aspx");
        }


        public void couriosityInc(Object sender, EventArgs e)
        {
            SuprEmo.Agent nevena = (SuprEmo.Agent)Session["agent"];
            Session["pass"] = "pass";
            if (nevena.curiosity < 1)
            {
                nevena.curiosity += 0.1;
            }
            Response.Redirect("~/default.aspx");
        }

        public void sensitivityDec(Object sender, EventArgs e)
        {
            SuprEmo.Agent nevena = (SuprEmo.Agent)Session["agent"];
            Session["pass"] = "pass";
            if (nevena.curiosity > 0)
            {
                nevena.curiosity -= 0.1;
            }
            Response.Redirect("~/default.aspx");
        }


        public void sensitivityInc(Object sender, EventArgs e)
        {
            SuprEmo.Agent nevena = (SuprEmo.Agent)Session["agent"];
            Session["pass"] = "pass";
            if (nevena.curiosity < 1)
            {
                nevena.curiosity += 0.1;
            }
            Response.Redirect("~/default.aspx");
        }


        //treniranje treba da se prai so randomci
        //t.e. bez ljubopitnost nemas dobar trening
        public void train(int n)
        {
            SuprEmo.Agent nevena = (SuprEmo.Agent)Session["agent"];
            SuprEmo.AgentEnvironment environment = (SuprEmo.AgentEnvironment)Session["env"];

            for (int i = 0; i < n; i++)
            {
                int action = nevena.getAction();
                environment.generateState();
                int[] tilesIn = environment.lastNStates(5);
                nevena.takeAction(action, action, tilesIn[1], tilesIn[2], tilesIn[3]);
                if (nevena.isDead(nevena.getState(), nevena.getTile0()) == true)
                {
                    Agent tmp = nevena;
                    nevena = new Agent();
                    nevena.genome = tmp.getCopyOfGenome();
                    nevena.curiosity = tmp.curiosity;
                    nevena.sensitivity = tmp.sensitivity;
                    nevena.lives = tmp.lives;
                    environment = new AgentEnvironment();
                    nevena.lives++;
                }
            }


            Session["agent"] = nevena;
            Session["env"] = environment;
            Response.Redirect("~/default.aspx");
        }
    }
}
