<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="IssueOfSpares.aspx.cs" Inherits="Pages_IssueOfSpares" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 class="large">Issue of Spares</h1>
    <p>Please enter the information for issuing spares.</p>
    
    <fieldset style="border: 2px solid #aaa">
        <legend>Enter Issue Information</legend>
        <div class="accountInfo">
        <p>
        
        <asp:Label ID="Label2" runat="server" CssClass="Label2" AssociatedControlID="Nomenclature">Choose Nomenclature:</asp:Label>
        
        
        <asp:DropDownList ID="Nomenclature" runat="server" AutoPostBack="true" CssClass="dropdown" OnSelectedIndexChanged="Nomenclature_SelectedIndexChanged">
        </asp:DropDownList>
        </p>
            
        <p>
            <asp:Label ID="QuantityLabel" runat="server" AssociatedControlID="Quantity">Quantity: <asp:Label ID="Label1" runat="server" ForeColor="Gray"></asp:Label></asp:Label>
            <asp:TextBox ID="Quantity" runat="server" MaxLength="7" CssClass="textEntry"></asp:TextBox>
            <asp:RegularExpressionValidator ID="reExValidator" runat="server" ControlToValidate="Quantity" CssClass="failureNotification" ErrorMessage="You can only input numbers." ValidationExpression="^\d+$"/>
        </p>
        <p>
            <asp:Label ID="IssueTypeLabel" runat="server" CssClass="Label2" AssociatedControlID="IssueType">Issue type:</asp:Label>
            <asp:DropDownList ID="IssueType" AutoPostBack="true" runat="server" CssClass="dropdown">
                <asp:ListItem Text="Loan" Value="Loan"></asp:ListItem>
                <asp:ListItem Text="Issued" Value="Issued"></asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="PurposeLabel" runat="server" AssociatedControlID="Purpose">Purpose:</asp:Label>
            <asp:TextBox ID="Purpose" runat="server" CssClass="textEntry"></asp:TextBox>
        </p>
        <p>
        
            <asp:Label ID="IssueToLabel" runat="server" AssociatedControlID="IssueTo">Issue to:</asp:Label>
            <asp:TextBox ID="IssueTo" runat="server" CssClass="textEntry"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="IssueDateLabel" runat="server" AssociatedControlID="IssueDate">Issue date: <span style="color:#777777;">(Month-Day-Year)</span></asp:Label>
            <asp:TextBox ID="IssueDate" runat="server" CssClass="textEntry"></asp:TextBox>
        </p>
        </div>
    </fieldset>
    
    <p class="submitButton">
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" CssClass="primaryButton" OnClick="SubmitButton_Click" />
    </p>
    
    <p>
        <asp:Label ID="errorMessage" runat="server" ForeColor="Red"></asp:Label>
    </p>
     <script>
         $(function () {
             $("#<%= IssueDate.ClientID %>").datepicker({
                 dateFormat: 'mm-dd-yy'
             });
         });
    </script>
</asp:Content>
