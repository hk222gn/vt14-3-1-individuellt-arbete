<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="BList.aspx.cs" Inherits="BoatRental.Pages.Shared.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Bokningar</h2>

    <%-- Visar status meddelande --%>
    
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <div id="input-form-BList">
        <asp:Panel ID="Panel1" runat="server" Visible="false">
        <asp:Label ID="ResultLabel" runat="server" Text=""></asp:Label>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Stäng" CausesValidation="false" />
        </div>
    </asp:Panel>
        <asp:ListView ID="BokningListView" runat="server"
            ItemType="BoatRental.Model.Bokning"
            SelectMethod="BokningListView_GetDataPageWise"
            DataKeyNames="BokningID">
            <LayoutTemplate>
                <%-- Platshållare för bokningar --%>
                 <table>
                        <tr>
                            <th>
                                Kund namn 
                            </th>
                            <th>
                                Båtplatsnummer
                            </th>
                            <th>
                                Start datum
                            </th>
                            <th>
                                Slut datum
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
                        <asp:Label ID="NameLabel" runat="server" Text='<%# GetKundNamn(Item.KundID) %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="BatplatsLabel" runat="server" Text='<%# GetBatplatsnr(Item.BåtplID) %>'></asp:Label>
                    </td>
                    <td>
                        <%-- Visar endast datum --%>
                        <%# Item.StartDatum.ToShortDateString() %>
                    </td>
                    <td>
                        <%-- Visar endast datum --%>
                        <%# Item.SlutDatum.ToShortDateString() %>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" Text="Radera" NavigateUrl='<%# GetRouteUrl("BokningarRadera", new { ID = Item.BokningID }) %>'></asp:HyperLink>
                        <asp:HyperLink ID="HyperLink2" runat="server" Text="Ändra" NavigateUrl='<%# GetRouteUrl("BokningarÄndra", new { ID = Item.BokningID }) %>'></asp:HyperLink>
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <%-- Visas om det inte finns några bokningar --%>
                <p>
                    Finns inga bokningar.
                </p>
            </EmptyDataTemplate>
        </asp:ListView>
    </div>
</asp:Content>
