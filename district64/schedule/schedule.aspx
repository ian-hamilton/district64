<%@ Page Language="C#" MasterPageFile="~/district.master" AutoEventWireup="true"
    CodeFile="schedule.aspx.cs" Inherits="schedule_schedule" Title="Schedule Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>District 64 Meeting Schedule Search</h2>
    <ul class="menu"><li>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/schedule/Meeting schedule complete.pdf">Download Schedule PDF</asp:HyperLink>
    </li></ul>
    <br />        
        <table class="display" dir="ltr">                            
                 
        <tr><th colspan="2">Use this box to sort meetings:</th></tr>       
        <tr>
            <td class="label">
                By Day:
            </td>
            <td class="display">
                <asp:DropDownList ID="DropDownListDayOfWeek" runat="server" Height="20px">
                    <asp:ListItem Value="-1">Select...</asp:ListItem>
                    <asp:ListItem Value="7">Saturday</asp:ListItem>
                    <asp:ListItem Value="1">Sunday</asp:ListItem>
                    <asp:ListItem Value="2">Monday</asp:ListItem>
                    <asp:ListItem Value="3">Tuesday</asp:ListItem>
                    <asp:ListItem Value="4">Wednesday</asp:ListItem>
                    <asp:ListItem Value="5">Thursday</asp:ListItem>
                    <asp:ListItem Value="6">Friday</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
                      
        <tr>
            <td class="label">
                By City:
            </td>
            <td>
                 <asp:TextBox ID="TextBoxCity" runat="server" Height="20px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="label">
                By Meeting Type:
            </td>
            <td>
                <asp:DropDownList ID="DropDownListMeetingType" runat="server" Height="20px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr><td class="label">
            <asp:Button ID="ButtonSearch" runat="server" Text="Sort Meetings" 
                onload="ButtonSearch_Click" CssClass="formbutton" /></td></tr>
        </td></tr>
    </table>
   
    <br />
    <br />
    <asp:GridView ID="GridViewSchedule" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" Width="95%" 
        OnSorting="GridViewSchedule_Sorting" AllowSorting="True" BackColor="White" 
        onselectedindexchanged="GridViewSchedule_SelectedIndexChanged">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="MeetingId" DataNavigateUrlFormatString="~/schedule/meetingdetail.aspx?id={0}"
                DataTextField="MeetingName" HeaderText="Meeting Name" 
                SortExpression="meetingName" >
            </asp:HyperLinkField>
            <asp:BoundField DataField="DayOfWeek" HeaderText="Day" SortExpression="dayOfWeek" />
            <asp:BoundField DataField="TimeOfDay" HeaderText="Time" SortExpression="timeOfDay" />
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="city" />
            <asp:BoundField DataField="MeetingType" HeaderText="Type" SortExpression="type" />
        </Columns>
        <PagerStyle CssClass="pgr" BackColor="Black"></PagerStyle>
        <HeaderStyle BackColor="Black" ForeColor="White" />
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
    </asp:GridView>
    <br />
</asp:Content>
