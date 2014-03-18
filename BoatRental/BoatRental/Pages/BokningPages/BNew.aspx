<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Site.Master" AutoEventWireup="true" CodeBehind="BNew.aspx.cs" Inherits="BoatRental.Pages.Master.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Skapa bokning</h2>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <div id="input-form">
        <asp:FormView ID="BokningFormView" runat="server"
            ItemType="BoatRental.Model.Bokning"
            DefaultMode="Insert"
            InsertMethod="BokningFormView_InsertItem">
            <InsertItemTemplate>
        
                <div>Båtplats nummer:</div> <asp:TextBox ID="BåtplTextBox" runat="server" Text='<%# BindItem.BåtplID %>'></asp:TextBox>
                <div>Startdatum:</div> <asp:TextBox ID="StartTextBox" runat="server" Text='<%# BindItem.StartDatum %>'></asp:TextBox>
                <div>Slutdatum:</div> <asp:TextBox ID="SlutTextBox" runat="server" Text='<%# BindItem.SlutDatum %>'></asp:TextBox>
            
                <div>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Insert" Text="Lägg till"></asp:LinkButton>
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

                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Startdatum är inte ett godkänt datum, måste formateras MM-dd-yyyy, MM/dd/yyyy" ControlToValidate="StartTextBox"
                     Operator="DataTypeCheck" Type="Date" Display="None"></asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Slutdatum är inte ett godkänt datum, måste formateras MM-dd-yyyy, MM/dd/yyyy" ControlToValidate="SlutTextBox"
                     Operator="DataTypeCheck" Type="Date" Display="None"></asp:CompareValidator>
            </InsertItemTemplate>
            <%-- Slut validering --%>
        </asp:FormView>
    </div>
</asp:Content>
