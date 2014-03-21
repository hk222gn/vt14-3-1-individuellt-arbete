<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="BaList.aspx.cs" Inherits="BoatRental.Pages.Shared.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Båtplatser</h1>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

    <div id="input-form-BåList">
    <asp:ListView ID="BåtplListView" runat="server"
        ItemType="BoatRental.Model.Batplats"
        SelectMethod="BåtplListView_GetData"
        DataKeyNames="BåtplID">
        <LayoutTemplate>
            <%-- Platshållare för Båtplatser --%>
            <table>
                    <tr>
                        <th>
                            Båtplatsnummer
                        </th>
                        <th>
                            Djup klass
                        </th>
                    </tr>
                <asp:PlaceHolder ID="ItemPlaceholder" runat="server" />
            </table>
            <asp:DataPager ID="DataPager1" runat="server" PageSize="20">
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
                    <%# Item.Båtplatsnr %>
                </td>
                <td>
                    <%# Item.DjupID %>
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <%-- Visas om det inte finns några båtplatser --%>
            <p>
                Finns inga båtplatser.
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
        </div>
</asp:Content>
