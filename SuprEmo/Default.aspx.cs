﻿using System;
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

            SuprEmo.Agent nevena = (SuprEmo.Agent)Session["agent"];
            SuprEmo.AgentEnvironment environment = (SuprEmo.AgentEnvironment)Session["env"];
            if (nevena == null)
            {
                nevena = new SuprEmo.Agent();
                //for better testing

                environment = new AgentEnvironment();
                
                //environment = new SuprEmo.AgentEnvironment();
            }
            else
            {
                int action = nevena.getAction();
                environment.generateState();
                int[] tilesIn = environment.lastNStates(5);
                nevena.takeAction(action, action, tilesIn[1], tilesIn[2], tilesIn[3]);
            }
            Dictionary<int, String> pictures_for_tile = new Dictionary<int, string>();
            Dictionary<int, String> pictures_for_state = new Dictionary<int, string>();
            pictures_for_tile.Add(0, "Images/basicTile.png");
            pictures_for_tile.Add(1, "Images/1_WGL.png");
            pictures_for_tile.Add(2, "Images/2_WGH.png");
            pictures_for_tile.Add(3, "Images/3_D.png");
            pictures_for_tile.Add(4, "Images/4_DG.png");
            pictures_for_tile.Add(5, "Images/5_O.png");

            pictures_for_state.Add(0, "Images/agent_0_Jump.png");
            pictures_for_state.Add(1, "Images/agent_1_Stand.png");
            pictures_for_state.Add(2, "Images/agent_2_Slide.png");

            int[] states = environment.lastNStates(5);
            String url;
            pictures_for_tile.TryGetValue(states[0], out  url);
            Image1.ImageUrl = url;
            pictures_for_tile.TryGetValue(states[1], out  url);
            Image2.ImageUrl = url;
            pictures_for_tile.TryGetValue(states[2], out  url);
            Image3.ImageUrl = url;
            pictures_for_tile.TryGetValue(states[3], out  url);
            Image4.ImageUrl = url;
            pictures_for_tile.TryGetValue(states[4], out  url);
            Image5.ImageUrl = url;
            pictures_for_state.TryGetValue(nevena.getState(), out url);
            agent.ImageUrl = url;
            coins.Text = nevena.gold + "";
            lives.Text = nevena.lives + "";
            tiles.Text = nevena.tilesPassed + "";
            tile0.Text = nevena.getTile0()+"";
            tile1.Text = nevena.getTile1() + "";
            tile2.Text = nevena.getTile2() + "";
            state.Text = nevena.getState() + "";
            nextAction.Text = nevena.getAction() + "";
            int [] last = nevena.getLastChangedEmotionLocation();
            Matrix5D.ImageUrl = "Images/5D Matrix " + (last[0] + 1) + " " + (last[1] + 1) + ".png";

            Matrix3D.ImageUrl = "Images/3D Matrix "+(last[2]+1)+".png";
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
    }
}
