<%@ Page Title="" Language="C#" MasterPageFile="~/district.master" AutoEventWireup="true"
    CodeFile="meetingdetail.aspx.cs" Inherits="schedule_meetingdetail" %>
<%@ Register Src="~/controls/GoogleMapForASPNet.ascx" TagName="GoogleMapForASPNet" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Meeting Details</h2>
    <br />
    <table class="display">
    <tr><th colspan="2">Meeting Information</th></tr>
        <tr>
            <td class="label">
                <asp:Label ID="Label1" runat="server" Text="Meeting Name:" />
            </td>
            <td>
                <asp:Literal ID="LiteralMeetingName" runat="server" />
            </td>
        </tr>
          <tr>
            <td class="label">
                <asp:Label ID="Label2" runat="server" Text="Meeting Time:" />
            </td>
            <td>
                <asp:Literal ID="LiteralTime" runat="server" />
            </td>
        </tr>
          <tr>
            <td class="label">
                <asp:Label ID="Label3" runat="server" Text="Meeting Type:" />
            </td>
            <td>
                <asp:Literal ID="LiteralMeetingType" runat="server" />
            </td>
        </tr>
         <tr>
            <td class="label">
                <asp:Label ID="Label4" runat="server" Text="Facility:" />
            </td>
            <td>
                <asp:Literal ID="LiteralFacility" runat="server" />
            </td>
        </tr>
          <tr>
            <td class="label">
                <asp:Label ID="Label5" runat="server" Text="Address:" />
            </td>
            <td>
                <asp:Literal ID="LiteralAddress" runat="server" />
            </td>
        </tr>
          <tr>
            <td class="label">
                <asp:Label ID="Label6" runat="server" Text="City:" />
            </td>
            <td>
                <asp:Literal ID="LiteralCity" runat="server" />
            </td>
        </tr>
          <tr>
            <td class="label">
                <asp:Label ID="Label7" runat="server" Text="Non-Smoking:" />
            </td>
            <td>
                <asp:Literal ID="LiteralNonSmoking" runat="server" />
            </td>
        </tr>
          <tr>
            <td class="label">
                <asp:Label ID="Label8" runat="server" Text="Handicap Accessible:" />
            </td>
            <td>
                <asp:Literal ID="LiteralHandicapp" runat="server" />
            </td>
        </tr>
          <tr>
            <td class="label">
                <asp:Label ID="Label9" runat="server" Text="Women's Meeting:" />
            </td>
            <td>
                <asp:Literal ID="LiteralWomans" runat="server" />
            </td>
        </tr>
                 
        
    </table>
    <br />
    <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server" TargetControlID="PanelOpenPrograms"
            ExpandControlID="PanelTitlePrograms" CollapseControlID="PanelTitlePrograms" Collapsed="false"
            TextLabelID="LabelLabelFacilityCollaspse">
        </cc1:CollapsiblePanelExtender><br />
        <asp:Panel ID="PanelTitlePrograms" runat="server">
            <asp:Image ID="Image2" runat="server" ImageUrl="/district64/images/maps_logo_small.gif" />
            <br />
            <asp:Label ID="LabelProgramCollapse" runat="server" Text=""></asp:Label>
        </asp:Panel>
        <asp:Panel ID="PanelOpenPrograms" runat="server">
                <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
                <br />
        </asp:Panel><br />
</asp:Content>
