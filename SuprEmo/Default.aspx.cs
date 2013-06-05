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
            SuprEmo.Agent nevena = new SuprEmo.Agent();
            SuprEmo.AgentEnvironment environment = new SuprEmo.AgentEnvironment();
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

        }
    }
}
