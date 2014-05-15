<%@ Page Language="c#" Codebehind="ReIndexInformation.aspx.cs" AutoEventWireup="False" Inherits="Nergard.EPi.Admin.SearchReIndex.Plugins.ReIndexInformation" Title="" %>
<%@ Register TagPrefix="EPiServerUI" Namespace="EPiServer.UI.WebControls" assembly="EPiServer.UI" %>
<%@ Register TagPrefix="EPiServerScript" Namespace="EPiServer.ClientScript.WebControls" assembly="EPiServer" %>

<asp:content contentplaceholderid="MainRegion" runat="server">
    <div class="epi-formArea epi-paddingHorizontal">
        <asp:Repeater id="rptReIndexInformation" runat="server">
            <HeaderTemplate>
                <table class="epi-default">
                    <tr>
                        <th>Date</th><th>Whas index reset</th>
                    </tr>
                
            </HeaderTemplate>
            <ItemTemplate>
                <tr><td><%#IndexInformation.ExecutionDate %></td><td><%#IndexInformation.ResetIndex %></td><td></td></tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:content>
