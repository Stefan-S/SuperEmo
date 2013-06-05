<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SuprEmo._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Supremo Rulz
    </h2>
     <div id="gameWindow">
         <asp:Image class="img" ID="Image1" runat="server" />
                  
         <asp:Image class="img" ID="Image2" runat="server" />
         <asp:Image class="img" ID="Image3" runat="server" />
         <asp:Image class="img" ID="Image4" runat="server" />
         <asp:Image class="img" ID="Image5" runat="server" />
         <asp:Image class="img" ID="agent" runat="server" />
         
        <div id="rightInfoDiv">
            Coins Collected
            <asp:Label ID="coins" runat="server" Text="0"></asp:Label>
            </br>
            Lives Lived
            <asp:Label ID="lives" runat="server" Text="0"></asp:Label>
            </br>
            TilesPassed
            <asp:Label ID="tiles" runat="server" Text="0"></asp:Label>
            </br>
            <asp:Button ID="Reset" runat="server" Text="Reset" onclick="resetButtonClick" />

        </div>
        </div>
</asp:Content>