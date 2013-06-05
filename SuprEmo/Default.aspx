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
                ovoj div e za neso info, i se prostira vo ista visina kako i prozorecot od igricata
            </div>
        </div>
    <p>
    end    
    </p>
</asp:Content>
