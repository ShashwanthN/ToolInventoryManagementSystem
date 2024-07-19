<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Menu.aspx.cs" Inherits="Menu" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="menu-container">
    <p>
    <asp:Label ID="Imagebutton2label" AssociatedControlID="Imagebutton2" runat="server"></asp:Label>
    <asp:ImageButton ID="Imagebutton2" OnClick="RedirectToNewSpares" ImageUrl="~/Styles/Tools.svg.png" CssClass="imageButton" runat="server" />
    </p>
    <p>
    <asp:Label ID="Label1" AssociatedControlID="Imagebutton0" runat="server"></asp:Label>
    <asp:ImageButton ID="Imagebutton0" OnClick="RedirectToIssueOfSpares" ImageUrl="~/Styles/issue.png" CssClass="imageButton" runat="server" />
    </p>
        <p>
<asp:Label ID="Label2" AssociatedControlID="Imagebutton1" runat="server"></asp:Label>
        <asp:ImageButton ID="Imagebutton1" OnClick="RedirectToBalance" ImageUrl="~/Styles/balance.png" CssClass="imageButton" runat="server" />
        </p>
    </div>
</asp:Content>
