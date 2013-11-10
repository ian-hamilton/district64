<%@ Page Title="Editable Event List" Language="C#" MasterPageFile="~/district.master" AutoEventWireup="true" CodeFile="eventeditlist.aspx.cs" Inherits="event_eventeditlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Submitted Event Request Search</h2>
<br />
    <table class="display">
        <tr><th colspan="2">Search Criteria</th></tr>
        <tr>
            <td class="label">
                Only Unapproved:
            </td>
            <td>
                <asp:CheckBox ID="CheckBoxUnapproved" Checked="true" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="label">
                Only Active:
            </td>
            <td>
                <asp:CheckBox ID="CheckBoxOnlyActive" Checked="true" runat="server" />
            </td>
        </tr>
         <tr>
            <td class="label">
                Events Not Passed:
            </td>
            <td>
                <asp:CheckBox ID="CheckBoxNotYetPast" Checked="true" runat="server" />
            </td>
        </tr>
        <tr><td class="label">
            <asp:Button ID="ButtonSearch" CssClass="formbutton" runat="server" Text="Search" 
                onclick="ButtonSearch_Click" /></td></tr>
    </table>
    <br />
    <br />
    <asp:GridView ID="GridViewEvents" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" Width="639px">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="EventId" DataNavigateUrlFormatString="~/event/eventrequest.aspx?id={0}"
                DataTextField="Subject" HeaderText="Event Subject"/>
            <asp:BoundField DataField="EventDate" HeaderText="Event Date"/>
            <asp:BoundField DataField="City" HeaderText="City"/>
        </Columns>
        <PagerStyle CssClass="pgr"></PagerStyle>
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
    </asp:GridView>
    
</asp:Content>

