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
            Coins:
            <asp:Label ID="coins" runat="server" Text="0"></asp:Label>
            </br>
            Lives:
            <asp:Label ID="lives" runat="server" Text="0"></asp:Label>
            </br>
            Passed:
            <asp:Label ID="tiles" runat="server" Text="0"></asp:Label>
            </br>
            T0:
            <asp:Label ID="tile0" runat="server" Text="0"></asp:Label>
            </br>
            T1:
            <asp:Label ID="tile1" runat="server" Text="0"></asp:Label>
            </br>
            T2:
            <asp:Label ID="tile2" runat="server" Text="0"></asp:Label>
            </br>
            State:
            <asp:Label ID="state" runat="server" Text="0"></asp:Label>
            </br>
            Next Action:
            <asp:Label ID="nextAction" runat="server" Text="0"></asp:Label>
            </br>
            </br>
            <asp:Button class= "butonka" ID="Reset" runat="server" Text="Reset" onclick="resetButtonClick" />
       </div>
        </div>
        <div id="genome">
        <table width=100%>
            <tr>
                <td width=307>
 
                         <asp:Image ID="Matrix5D" runat="server" Height=220px />
    
                </td>
                <td width=307>

                    <asp:Image ID="Matrix3D" runat="server" Height=298px />

                </td>
                <td width=307>
  
                    <asp:PlaceHolder ID="Matrix2D" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
        </table>



    </div>
</asp:Content>