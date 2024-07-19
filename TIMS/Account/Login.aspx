<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" CodeBehind="Login.aspx.cs"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<style>
    .form-group {
        margin-bottom: 15px;
    }

    .form-group .input-label {
        display: block;
        margin-bottom: 5px;
        font-weight: bold;
    }

    .form-group .input-field {
        width: 100%;
        padding: 8px;
        box-sizing: border-box;
    }

    .failureNotification {
        color: red;
        font-size: 0.9em;
    }

    .form-group-inline {
        display: flex;
        align-items: center;
    }

    .form-group-inline label.inline {
        margin-left: 5px;
    }

    .submitButton {
        text-align: center;
    }

    
</style>

    <div class="format">
        <h1 class="large">Log In</h1>
        <p>Please enter your credentials.</p>
        <p> ~</p>
        
        <p><asp:Label ID="errorMessage" runat="server" ForeColor="Red"></asp:Label></p>
         <fieldset style="border: 2px solid #aaa">
            <legend>Account Information</legend>
            <div class="form-group">
                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="input-label">Username:</asp:Label>
                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry input-field"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="input-label">Password:</asp:Label>
                <asp:TextBox ID="Password" runat="server" CssClass="textEntry input-field" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group submitButton">
                <asp:Button ID="LoginButton" onClick="btnSubmitOnClickDb" CssClass="primaryButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup"/>
            </div>
        </fieldset>
    </div>
</asp:Content>
