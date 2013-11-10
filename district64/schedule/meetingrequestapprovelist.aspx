<%@ Page Title="" Language="C#" MasterPageFile="~/district.master" AutoEventWireup="true" CodeFile="meetingrequestapprovelist.aspx.cs" Inherits="schedule_meetingrequestlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h2>
        Please Select the Meeting Request You Wish to Approve...</h2>
    <br />
    <br />
    <asp:GridView ID="GridViewSchedule" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" 
    Width="639px">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="MeetingChangeRequestId" DataNavigateUrlFormatString="~/schedule/meetingrequestapproval.aspx?id={0}"
                DataTextField="MeetingName" HeaderText="Meeting Name" 
                SortExpression="meetingName" />
            <asp:BoundField DataField="DayOfWeek" HeaderText="Day" SortExpression="dayOfWeek" />
            <asp:BoundField DataField="TimeOfDay" HeaderText="Time" SortExpression="timeOfDay" />
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="city" />
            <asp:BoundField DataField="MeetingType" HeaderText="Type" SortExpression="type" />
            <asp:BoundField DataField="RowCreated" HeaderText="Date Requested" SortExpression="type" />
        </Columns>
        <PagerStyle CssClass="pgr"></PagerStyle>
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
    </asp:GridView>

</asp:Content>

