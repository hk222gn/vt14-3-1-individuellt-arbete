<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="KModify.aspx.cs" Inherits="BoatRental.Pages.Shared.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Ändra kund</h2>

    <asp:ValidationSummary runat="server"></asp:ValidationSummary>
    <asp:FormView ID="KundFormView" runat="server"
        ItemType="BoatRental.Model.Kund"
        DefaultMode="Edit"
        SelectMethod="KundFormView_GetItem"
        UpdateMethod="KundFormView_UpdateItem"
        DataKeyNames="KundID">
        <EditItemTemplate>
            <%-- Datat som ska ändras --%>
            <div>Namn <asp:TextBox ID="NamnTextBox" runat="server" Text='<%# BindItem.Namn %>' MaxLength="30"></asp:TextBox></div>
            <div>Address <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# BindItem.Address %>' MaxLength="20"></asp:TextBox></div>
            <div>Telefonnummer <asp:TextBox ID="TelefonnummerTextBox" runat="server" Text='<%# BindItem.Telefonnummer %>' MaxLength="16"></asp:TextBox></div>
            <div>Mail <asp:TextBox ID="MailTextBox" runat="server" Text='<%# BindItem.E_Mail %>' MaxLength="50"></asp:TextBox></div>

            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Ändra"></asp:LinkButton>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# GetRouteUrl("Kunder", null) %>' Text="Gå tillbaka"></asp:HyperLink>
            </div>

            <%-- Validering --%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fältet Namn måste vara ifyllt." 
                ControlToValidate="NamnTextBox" Display="None"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Fältet Address måste vara ifyllt."
                ControlToValidate="AddressTextBox" Display="None"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Fältet Telefonnummer måste vara ifyllt." 
                ControlToValidate="TelefonnummerTextBox" Display="None"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Fältet Mail måste vara ifyllt." 
                ControlToValidate="MailTextBox" Display="None"></asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Inmatningen matchar inte en Mail adress."
                ControlToValidate="MailTextBox" ValidationExpression="[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}" Display="None"></asp:RegularExpressionValidator>
            <%-- Slut validering --%>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
