<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="SuprEmo.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        About
    </h2>
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
    <asp:Image ID="Image1" runat="server" />
    <asp:Image ID="Image2" runat="server" />
    <asp:Image ID="Image3" runat="server" />
    <asp:Image ID="Image4" runat="server" />
    <asp:Image ID="Image5" runat="server" />

    
</asp:Content>
