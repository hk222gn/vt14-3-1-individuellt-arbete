<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="BoatRental.Pages.Master.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div> Ett fel inträffade och din förfrågan kunde inte hanteras.</div>
    <div><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%$ RouteUrl:routename=Default %>'>Tillbaka till index</asp:HyperLink></div>
</asp:Content>
