<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="SuprEmo.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        About
    </h2>
    <div style="float:left; width:450px">
    <p style="text-align:justify; width:450px">
        SuprEmo is a project made by Stefan Spasovski, Vladimir Popovski and Monika Simjanoska as a part of the course 
        Information Processing in Biological Systems during the master studies in Intelligent Systems Engineering.
    </p>
    <p  style="text-align:justify; width:450px"> 
        The project's objective is creating an emotional learning based agent, which is capable of surviving in a dynamic environment. 
        When a new agent is born, it follows only the "basic" insticts, the money affinity and the death avoidance, coded in its genome. 
        Confronting the real life (the environment), the agent learns how to survive in a sequence of trials. Its behaviour is highly 
        individual and non deterministic, since it is controlled by the two crucial humanoid parameters, sensitivity and curiosity.
        The more sensitive the agent is, the greater is the environment impact during the learning process. The more curious the agent is, 
        the greater is the chance to get itself involved in an unexpected situation.
    </p>
    </div>
    <div style="float:right; width:450px; height:450px">
    <p style="text-align:justify">
        Agent's genome is a 5D space that consists of agent's three possible actions (jump, forward, slide), three possible positions 
        from which the action was performed (high, stand, low) and six possible states (walkable, walkable gold low, walkable gold high,
        danger, danger gold, obstacle) defined as a triple of the past environment surrounding (t0), the current environment surrounding (t1)
        and the future environment surrounding (t2). The figures below depict the graphical representation of the agent's genome. The fisrt
        figure depicts the agent's genome as a 3D cube where the depth is the actions (A), the width is the past positions of the agent (P) and 
        the height is the past surroundings (t0). The middle figure is a six-layer presentation of the past surroundings, showing the current
        changings in the genome as the agent acts in the environment. It is disassembled in the last figure as a matrix presenting the changes
        in t1 and t2, which we defined above.
    </p>
    <p>
        <asp:Image ID="Image6" runat="server" ImageUrl="Images/cube.png"  style="float:left"  /> &nbsp
        <asp:Image ID="Image7" runat="server" ImageUrl="Images/cube2.png"  style="float:left; margin-left:30px" /> &nbsp
        <asp:Image ID="Image8" runat="server" ImageUrl="Images/cube3.png"  style="float:left; margin-left:30px" /> &nbsp
    </p>
    <p></p>
    </div>
  
    
</asp:Content>
