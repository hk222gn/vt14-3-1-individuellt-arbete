<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Site.Master" AutoEventWireup="true" CodeBehind="BModify.aspx.cs" Inherits="BoatRental.Pages.Master.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Ändra Bokning</h2>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <div id="input-form">
        <asp:FormView ID="BokningFormView" runat="server"
        ItemType="BoatRental.Model.Bokning"
        DefaultMode="Edit"
        SelectMethod="BokningFormView_GetItem"
        UpdateMethod="BokningFormView_UpdateItem"
        DataKeyNames="BokningID">
        <EditItemTemplate>
            <%-- Datat som ska ändras, Bind("DATE", EXPRESSION) ändrar hela datetime till endast datumet. --%>
            <div>Båtplatsnummer <asp:TextBox ID="BåtplTextBox" runat="server" Text='<%# BindItem.BåtplID %>'></asp:TextBox></div>
            <div>Startdatum <asp:TextBox ID="StartTextBox" runat="server" Text='<%# Bind("StartDatum", "{0:yyyy/dd/MM}") %>'></asp:TextBox></div>
            <div>Slutdatum <asp:TextBox ID="SlutTextBox" runat="server" Text='<%# Bind("SlutDatum", "{0:yyyy/dd/MM}") %>'></asp:TextBox></div>
            
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Ändra"></asp:LinkButton>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# GetRouteUrl("Bokningar", null) %>' Text="Gå tillbaka"></asp:HyperLink>
            </div>
            <%-- Validering --%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Du måste ange ett båtplats nummer"
                 ControlToValidate="BåtplTextBox" Display="None"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Du måste ange ett startdatum"
                 ControlToValidate="StartTextBox" Display="None"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Du måste ange ett slutdatum"
                 ControlToValidate="SlutTextBox" Display="None" ></asp:RequiredFieldValidator>

            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Båtplatsnummret måste vara 1-10" ControlToValidate="BåtplTextBox" 
                MinimumValue="1" MaximumValue="10" Type="Integer"></asp:RangeValidator>

            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Startdatum är inte ett godkänt datum" ControlToValidate="StartTextBox"
                 Operator="DataTypeCheck" Type="Date" Display="None"></asp:CompareValidator>
            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Startdatum är inte ett godkänt datum" ControlToValidate="SlutTextBox"
                 Operator="DataTypeCheck" Type="Date" Display="None"></asp:CompareValidator>
            <%-- Slut validering --%>
        </EditItemTemplate>
    </asp:FormView>
    </div>
</asp:Content>
