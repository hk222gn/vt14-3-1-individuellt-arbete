<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Site.Master" AutoEventWireup="true" CodeBehind="BDelete.aspx.cs" Inherits="BoatRental.Pages.Master.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Radera bokning</h2>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

    <h2>Är du säker på att du vill radera bokningen?</h2>
    <asp:LinkButton ID="DeleteLinkButton" runat="server" OnCommand="DeleteLinkButton_Command" CommandArgument='<%$ RouteValue:ID %>' Text="Ja"></asp:LinkButton>
     / 
    <asp:HyperLink ID="HyperLink2" runat="server" Text="Nej" NavigateUrl='<%$ RouteUrl:routename=Bokningar %>'></asp:HyperLink>

</asp:Content>
