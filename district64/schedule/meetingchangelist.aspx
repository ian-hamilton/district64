<%@ Page Title="" Language="C#" MasterPageFile="~/district.master" AutoEventWireup="true"
    CodeFile="meetingchangelist.aspx.cs" Inherits="schedule_meetingchangelist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<h2>Meeting Change List</h2><br />
    <h3> Please Select the Meeting You Wish to Change</h3>
    
    <asp:GridView ID="GridViewSchedule" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" Width="639px"
        OnSorting="GridViewSchedule_Sorting" AllowSorting="True">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="MeetingId" DataNavigateUrlFormatString="~/schedule/meetingrequest.aspx?id={0}"
                DataTextField="MeetingName" HeaderText="Meeting Name" SortExpression="meetingName" />
            <asp:BoundField DataField="DayOfWeek" HeaderText="Day" SortExpression="dayOfWeek" />
            <asp:BoundField DataField="TimeOfDay" HeaderText="Time" SortExpression="timeOfDay" />
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="city" />
            <asp:BoundField DataField="MeetingType" HeaderText="Type" SortExpression="type" />
        </Columns>
        <PagerStyle CssClass="pgr"></PagerStyle>
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
    </asp:GridView>
</asp:Content>
