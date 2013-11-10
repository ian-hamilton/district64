<%@ Page Title="Event Detail" Language="C#" MasterPageFile="~/district.master" AutoEventWireup="true"
    CodeFile="eventdetail.aspx.cs" Inherits="event_eventdetail" %>
<%@ Register Src="~/controls/GoogleMapForASPNet.ascx" TagName="GoogleMapForASPNet" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<h2>Event Detail</h2>
    <asp:MultiView ID="MultiViewSuccess" runat="server">
        <asp:View ID="ViewSuccessMessage" runat="server">
            <div class="article" style="width:600px;">
                <p>
                    The event request has been succesfully submitted. The Web-Master will review the
                    request, and once approved the event will appear on the calender and the event list
                    in order of the date of the event. Thank you.
                </p>
            </div>
        </asp:View>
    </asp:MultiView>
    <div class="article" style="width:600px;">
        <table class="events">
            <tr>
                <th>                 
                    <asp:Literal ID="LiteralSubject" runat="server"></asp:Literal>                
                </th>
            </tr>
            <tr>
                <td class="eventaddress">
                    <asp:Literal ID="LiteralDate" runat="server"></asp:Literal>
                </td>
            </tr>
            
            <tr>
                <td class="eventaddress">
                    <asp:Literal ID="LiteralLocation" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="eventaddress">
                    <asp:Literal ID="LiteralAddress" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="eventaddress">
                    <asp:Literal ID="LiteralCity" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    <p>
                        <asp:Literal ID="LiteralDesc" runat="server"></asp:Literal></p>                  
                </td>
            </tr>
             <tr>
                <td>
                    <p>
                        <asp:LinkButton ID="LinkButtonFlyer" runat="server" 
                            onclick="LinkButtonFlyer_Click">Download Flyer</asp:LinkButton></p>      
                    <p class="error"><asp:Literal ID="LiteralFlyer" runat="server"></asp:Literal></p>           
                </td>
            </tr>
        </table>
    </div>
        <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server" TargetControlID="PanelOpenPrograms"
            ExpandControlID="PanelTitlePrograms" CollapseControlID="PanelTitlePrograms" Collapsed="false"
            TextLabelID="LabelLabelFacilityCollaspse">
        </cc1:CollapsiblePanelExtender><br />
        <asp:Panel ID="PanelTitlePrograms" runat="server">
            <asp:Image ID="Image2" runat="server" ImageUrl="/district64/images/maps_logo_small.gif" />
            <asp:Label ID="LabelProgramCollapse" runat="server" Text=""></asp:Label>
        </asp:Panel>
        <asp:Panel ID="PanelOpenPrograms" runat="server">
                <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
                <br />
        </asp:Panel><br />
    
    
</asp:Content>
