<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="KDelete.aspx.cs" Inherits="BoatRental.Pages.Shared.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Radera kund</h2>
    <asp:ValidationSummary runat="server"></asp:ValidationSummary>
    <h2>Är du säker på att du vill radera kunden?</h2>
    <asp:LinkButton ID="DeleteLinkButton" runat="server" OnCommand="DeleteLinkButton_Command" CommandArgument='<%$ RouteValue:ID %>' Text="Ja"></asp:LinkButton>
     / 
    <asp:HyperLink ID="HyperLink2" runat="server" Text="Nej" NavigateUrl='<%$ RouteUrl:routename=Kunder %>'></asp:HyperLink>
</asp:Content>
