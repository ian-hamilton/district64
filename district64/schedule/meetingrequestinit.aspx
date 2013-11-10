<%@ Page Title="" Language="C#" MasterPageFile="~/district.master" AutoEventWireup="true" CodeFile="meetingrequestinit.aspx.cs" Inherits="schedule_meetingrequestinit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Request a Meeting Change or Addition</h2>
<br />
    <table class="display">
        <tr><th>District Schedule Request</th></tr>
        <tr><td>
            <asp:RadioButtonList ID="RadioButtonListChangeType" runat="server">
                <asp:ListItem Value="modify" Selected="True">Change Scheduled Meeting</asp:ListItem>
                <asp:ListItem Value="add">Add New Meeting to Schedule</asp:ListItem>
            </asp:RadioButtonList>
        </td></tr>
        <tr><td><asp:Button ID="ButtonSubmit" CssClass="formbutton" runat="server" Text="Submit" 
                onclick="ButtonSubmit_Click" /></td></tr>
    </table>
</asp:Content>

