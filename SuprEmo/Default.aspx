<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SuprEmo._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Supremo Rulz
    </h2>
     <div id="gameWindow">
        <%
            SuprEmo.Agent nevena = new SuprEmo.Agent();
            SuprEmo.AgentEnvironment environment = new SuprEmo.AgentEnvironment();
            Dictionary<int, String> pictures_for_state = new Dictionary<int, string>();
            pictures_for_state.Add(0, "Images/basicTile.png");
            pictures_for_state.Add(1, "Images/1_WGL.png");
            pictures_for_state.Add(2, "Images/2_WGH.png");
            pictures_for_state.Add(3, "Images/3_D.png");
            pictures_for_state.Add(4, "Images/4_DG.png");
            pictures_for_state.Add(5, "Images/5_O.png");
            int[] states = environment.lastNStates(5);
            String url;
            pictures_for_state.TryGetValue(states[0], out  url);
            Image1.ImageUrl = url;
            pictures_for_state.TryGetValue(states[1], out  url);
            Image2.ImageUrl = url;
            pictures_for_state.TryGetValue(states[2], out  url);
            Image3.ImageUrl = url;
            pictures_for_state.TryGetValue(states[3], out  url);
            Image4.ImageUrl = url;
            pictures_for_state.TryGetValue(states[4], out  url);
            Image5.ImageUrl = url;

            agent.ImageUrl = "Images/agent_1_Stand.png";
        %>
         <asp:Image class="img" ID="Image1" runat="server" />
                  
         <asp:Image class="img" ID="Image2" runat="server" />
         <asp:Image class="img" ID="Image3" runat="server" />
         <asp:Image class="img" ID="Image4" runat="server" />
         <asp:Image class="img" ID="Image5" runat="server" />
         <asp:Image class="img" ID="agent" runat="server" />
         
            <div id="rightInfoDiv">
                ovoj div e za neso info, i se prostira vo ista visina kako i prozorecot od igricata
            </div>
        </div>
    <p>
    end    
    </p>
</asp:Content>
