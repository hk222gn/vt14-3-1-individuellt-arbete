<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="KList.aspx.cs" Inherits="BoatRental.Pages.Shared.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Kunder</h2>

    <%-- Visar status meddelande --%>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
                <asp:Label ID="ResultLabel" runat="server" Text=""></asp:Label>
                    <div>
                        <asp:Button ID="Button1" runat="server" Text="Stäng" CausesValidation="false" />
                    </div>
            </asp:Panel>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <asp:ListView ID="KundListView" runat="server"
        ItemType="BoatRental.Model.Kund"
        SelectMethod="KundListView_GetDataPageWise"
        DataKeyNames="KundID">
        <LayoutTemplate>
            <%-- Platshållare för kunder --%>
            <table>
                    <tr>
                        <th>
                            Namn
                        </th>
                        <th>
                            Address
                        </th>
                        <th>
                            Telefonnummer
                        </th>
                        <th>
                            E-Mail
                        </th>
                        <th>
                            <asp:HyperLink ID="HyperLink3" runat="server" Text="Ny kund" NavigateUrl='<%$ RouteUrl:routename=KunderNy %>'></asp:HyperLink>
                        </th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            <asp:DataPager ID="DataPager1" runat="server" PageSize="8">
                    <fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="true"  
                            FirstPageText="<<" 
                            ShowNextPageButton="false" 
                            ShowPreviousPageButton="false"/>
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField 
                            ShowLastPageButton="true" 
                            LastPageText=">>"
                            ShowFirstPageButton="false" 
                            ShowPreviousPageButton="false" />
                    </fields>
                </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
            <%-- De data som ska visas --%>
            <tr>
                <td>
                    <%#: Item.Namn %>
                </td>
                <td>
                    <%# Item.Address %>
                </td>
                <td>
                    <%# Item.Telefonnummer %>
                </td>
                <td>
                    <%# Item.E_Mail %>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" Text="Radera" NavigateUrl='<%# GetRouteUrl("KunderRadera", new { ID = Item.KundID }) %>'></asp:HyperLink>
                    <asp:HyperLink ID="HyperLink2" runat="server" Text="Ändra" NavigateUrl='<%# GetRouteUrl("KunderÄndra", new { ID = Item.KundID }) %>'></asp:HyperLink>
                    <asp:HyperLink ID="HyperLink4" runat="server" Text="Lägg till bokning" NavigateUrl='<%# GetRouteUrl("BokningarNy", new { ID = Item.KundID }) %>'></asp:HyperLink>
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <%-- Visas om det inte finns några kunder --%>
            <p>
                Finns inga kunder.
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
