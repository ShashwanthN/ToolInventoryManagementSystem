<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="BalanceSpares.aspx.cs" Inherits="Pages_BalanceSpares" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 class="large">Balance of Spares</h1>
    <fieldset style="border: 2px solid #aaa">
        <legend>Balance</legend>
        <p class="ptagPadding">Please select a nomenclature:</p>
        
        <asp:DropDownList CssClass="dropdown" ID="NomenclatureDropDown" runat="server" AutoPostBack="true" 
            OnSelectedIndexChanged="NomenclatureDropDown_SelectedIndexChanged">
        </asp:DropDownList>
        
        <div id="DetailsPanel" runat="server" style="display:none;">
            <h2>Nomenclature Details</h2>
            <table class="details-table">
                <tr>
                    <th>Nomenclature</th>
                    <td><asp:Label ID="NomenclatureLabel" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <th>Quantity</th>
                    <td><asp:Label ID="QuantityLabel" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <th>Date of Entry</th>
                    <td><asp:Label ID="DateOfEntryLabel" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <th>Rack No</th>
                    <td><asp:Label ID="RackNoLabel" runat="server"></asp:Label></td>
                </tr>
            </table>
        </div>
        
        <asp:GridView ID="GridView1" runat="server" cssClass="padin" BackColor="#f0f0f0" 
            BorderColor="#888888" Width="100%" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
            >
            <AlternatingRowStyle BorderColor="#888888" BorderWidth="1px" BackColor="#ffffff" />
            <FooterStyle BackColor="#c0ff78" />
            <HeaderStyle  ForeColor="Black" BackColor="#c0ff78" Font-Bold="True" />
            <PagerStyle BackColor="#1a1a1a" BorderWidth="1px" BorderColor="White" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#ccc" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#222222" BorderWidth="1px" BorderColor="White"  />
            <SortedAscendingHeaderStyle BackColor="#c0ff78" />
            <SortedDescendingCellStyle BackColor="#b6b7bc" />
            <SortedDescendingHeaderStyle BackColor="#c0ff78" />
        </asp:GridView>
    </fieldset>
</asp:Content>
