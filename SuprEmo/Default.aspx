<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SuprEmo._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Supremo Rulz
        <asp:Button class="butonka" ID="Button4" runat="server" Text="Step" OnClientClick="function fnstep() { function(){location.reload(true);}}"  style="float:right" />
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
            State:
            <asp:Label ID="state" runat="server" Text="0"></asp:Label>
            </br>
            Next Action:
            <asp:Label ID="nextAction" runat="server" Text="0"></asp:Label>
            </br>
            CurrEmo:
            <asp:Label ID="currentEmotion" runat="server" Text="0"></asp:Label>
            </br>
            PrevsEmo:
            <asp:Label ID="previousEmotion" runat="server" Text="0"></asp:Label>
            </br>
            Couriosity:
            <asp:Label ID="couriosity" runat="server" Text="0"></asp:Label>
            </br>
            <asp:Button Width=25 class="butonka" ID="couriosityDecBtn" runat="server" Text="-" OnClick="couriosityDec"  style="float:left" />
            <asp:Button Width=25 class="butonka" ID="couriosityIncBtn" runat="server" Text="+" OnClick="couriosityInc"/>
            </br>
            Sensitivity:
            <asp:Label ID="sensitivity" runat="server" Text="0"></asp:Label>
            </br>
            <asp:Button Width=25 class="butonka" ID="Button2" runat="server" Text="-" OnClick="sensitivityDec"  style="float:left" />
            <asp:Button Width=25 class="butonka" ID="Button3" runat="server" Text="+" OnClick="sensitivityInc"/>
            </br>
            <asp:Button class= "butonka" ID="Reset" runat="server" Text="Reset" onclick="resetButtonClick" />
            <asp:Button class= "butonka" ID="trainingbtn" runat="server" Text="Train" onclick="training" />
            <asp:Button class= "butonka" ID="HCtrainingbtn" runat="server" Text="Train Hard" onclick="HCtraining" />
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
        <asp:PlaceHolder ID="script" runat="server"></asp:PlaceHolder>
</asp:Content>
