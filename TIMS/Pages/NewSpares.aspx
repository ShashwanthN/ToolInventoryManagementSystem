<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="NewSpares.aspx.cs" Inherits="Pages_NewSpares" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 class="large">Spare Parts Entry</h1>
    <p>Please enter the spare parts information.</p>
    
    <fieldset style="border: 2px solid #aaa">
        <legend >Enter Spare Part Information</legend>
        <div class="accountInfo">
            <p>
                <asp:Label ID="DateOfEntryLabel" runat="server" AssociatedControlID="DateOfEntry">Date of entry: <span style="color:#777777;">(Month-Day-Year)</span></asp:Label>
                <asp:TextBox ID="DateOfEntry" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="NomenclatureLabel" runat="server" AssociatedControlID="Nomenclature">Nomenclature:</asp:Label>
                <asp:TextBox ID="Nomenclature" runat="server" MaxLength="100" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="QuantityLabel" runat="server" AssociatedControlID="Quantity">Quantity:</asp:Label>
                <asp:TextBox ID="Quantity" runat="server" MaxLength="7" CssClass="textEntry"></asp:TextBox>
                <asp:RegularExpressionValidator ID="reExValidator" runat="server" ControlToValidate="Quantity" CssClass="failureNotification" ErrorMessage="You can only input numbers." ValidationExpression="^\d+$"/>
            </p>
            <p>
                <asp:Label ID="RackNoLabel" runat="server" AssociatedControlID="RackNo">Rack number:</asp:Label>
                <asp:TextBox ID="RackNo"  AutoCompleteType="none" runat="server" MaxLength="10" CssClass="textEntry"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="RackNo" CssClass="failureNotification" ErrorMessage="You can only input numbers." ValidationExpression="^\d+$"/>
            </p>
            <p>
                <asp:Label ID="RemarksLabel" runat="server" AssociatedControlID="Remarks">Remarks:</asp:Label>
                <asp:TextBox ID="Remarks" runat="server" MaxLength="255" CssClass="textEntry"></asp:TextBox>
            </p>
        </div>
    </fieldset>
    
    <p class="submitButton">
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" CssClass="primaryButton" OnClick="SubmitButton_Click" />
    </p>
    
    <p>
        <asp:Label ID="errorMessage" runat="server"  Font-Size="Medium" ForeColor="Red"></asp:Label>
    </p>
     <script>
         $(function () {
             $("#<%= DateOfEntry.ClientID %>").datepicker({
                 dateFormat: 'mm-dd-yy'
             });
         });
    </script>
</asp:Content>
