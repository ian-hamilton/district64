<%@ Page Title="Event Calender" Language="C#" MasterPageFile="~/district.master" AutoEventWireup="true"
    CodeFile="eventcalender.aspx.cs" Inherits="event_eventcalender" %>

<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pageHeader">
        <h2>
            District Event Calender</h2>
    </div>
    <br />
    <h3>
        Please click event for details...</h3>
    <br />
    <a href="javascript:dpm.refreshCallBack(-1);" style="text-decoration: none; background-color: White;
        border: 1px solid navy; padding: 3px;">Previous month <span style="color: red">&laquo;</span>
    </a>&nbsp; <a href="javascript:dpm.refreshCallBack(DayPilot.Date.today());" style="text-decoration: none;
        background-color: White; border: 1px solid navy; padding: 3px;">This month</a>
    &nbsp; <a href="javascript:dpm.refreshCallBack(1);" style="text-decoration: none;
        background-color: White; border: 1px solid navy; padding: 3px;"><span style="color: red">
            &raquo;</span> Next month</a><br />
    <DayPilot:DayPilotMonth ID="DayPilotMonthEvent" runat="server" DataEndField="end"
        DataStartField="start" DataTextField="name" DataValueField="id" DataTagFields="name, id"
        EventClickHandling="JavaScript" EventClickJavaScript="alert(e.text());" ClientObjectName="dpm"
        Width="100%" TimeRangeSelectedHandling="PostBack" OnRefresh="DayPilotMonthEvent_Refresh"
        ShowEventStartEnd="False" WeekStarts="Sunday" BackColor="#FFFFD5" BorderColor="Black"
        CellHeaderBackColor="" CellHeaderFontColor="Black" EventBackColor="#578B9E" EventBorderColor="Black"
        EventFontColor="White" HeaderBackColor="236, 233, 216" HeaderFontColor="Black"
        InnerBorderColor="204, 204, 204" NonBusinessBackColor="#FFF4BC" OnTimeRangeSelected="DayPilotMonthEvent_TimeRangeSelected"
        StartDate="" OnBeforeCellRender="DayPilotMonthEvent_BeforeCellRender" Font-Bold="False"
        OnBeforeEventRender="DayPilotMonthEvent_BeforeEventRender"></DayPilot:DayPilotMonth>
</asp:Content>
