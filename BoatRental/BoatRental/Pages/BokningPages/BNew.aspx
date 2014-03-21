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
            InsertMethod="BokningFormView_InsertItem"
            DatKeyNames="BokningID, BåtplID">
            <InsertItemTemplate>
        
                <div>Båtplats nummer:</div> <asp:DropDownList ID="DropDown" runat="server" ItemType="BoatRental.Model.Batplats" SelectMethod="DropDown_GetBatplatser" 
                    DataTextField="Båtplatsnr" DataValueField="BåtplID" SelectedValue='<%# BindItem.BåtplID %>'></asp:DropDownList> 
                <div>Startdatum:</div> <asp:TextBox ID="StartTextBox" runat="server" Text='<%# BindItem.StartDatum %>'></asp:TextBox>
                <div>Slutdatum:</div> <asp:TextBox ID="SlutTextBox" runat="server" Text='<%# BindItem.SlutDatum %>'></asp:TextBox>
            
                <div>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Insert" Text="Lägg till"></asp:LinkButton>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# GetRouteUrl("Bokningar", null) %>' Text="Gå tillbaka"></asp:HyperLink>
                </div>

                <%-- Validering --%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Du måste ange ett startdatum"
                     ControlToValidate="StartTextBox" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Du måste ange ett slutdatum"
                     ControlToValidate="SlutTextBox" Display="None" ></asp:RequiredFieldValidator>


                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Startdatum är inte ett godkänt datum" ControlToValidate="StartTextBox"
                     Operator="DataTypeCheck" Type="Date" Display="None"></asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Slutdatum är inte ett godkänt datum" ControlToValidate="SlutTextBox"
                     Operator="DataTypeCheck" Type="Date" Display="None"></asp:CompareValidator>

                <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Slutdatumet kan inte gå ut före startdatumet!" 
                    ControlToValidate="SlutTextBox" ControlToCompare="StartTextBox" Type="Date" Operator="GreaterThan" Display="None"></asp:CompareValidator>
            </InsertItemTemplate>
            <%-- Slut validering --%>
        </asp:FormView>
    </div>
</asp:Content>
