<%@ Page Title="Up-coming Events" Language="C#" MasterPageFile="~/district.master" AutoEventWireup="true" CodeFile="eventlist.aspx.cs" Inherits="event_eventlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Event List</h2>
<br /><br />
  <asp:GridView ID="GridViewEvents" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" Width="639px">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="EventId" DataNavigateUrlFormatString="~/event/eventdetail.aspx?id={0}"
                DataTextField="Subject" HeaderText="Event Subject"/>
            <asp:BoundField DataField="EventDate" HeaderText="Event Date"/>
            <asp:BoundField DataField="City" HeaderText="City"/>
        </Columns>
        <PagerStyle CssClass="pgr"></PagerStyle>
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
    </asp:GridView>
</asp:Content>

