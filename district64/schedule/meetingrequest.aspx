<%@ Page Title="" Language="C#" MasterPageFile="~/district.master" AutoEventWireup="true"
    CodeFile="meetingrequest.aspx.cs" Inherits="schedule_meetingrequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/controls/ScrollValueBox.ascx" TagName="ScrollValueBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Meeting Change/Add Request</h2>
    
    <br />
    <asp:Table ID="TableError" runat="server" CssClass="error">
    </asp:Table>
    <table class="display">
    <tr><th colspan="2">Meeting Information Form</th></tr>
        <tr>
            <td class="label">
                Meeting Name:
            </td>
            <td>
                <asp:TextBox ID="TextBoxMeetingName" runat="server" Width="300"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorMeetingName" runat="server"
                    ControlToValidate="TextBoxMeetingName" ErrorMessage="Missing Required Information"
                    Display="None" ValidationGroup="group1"></asp:RequiredFieldValidator>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtenderMeetingName" runat="server"
                    TargetControlID="RequiredFieldValidatorMeetingName" CssClass="customCalloutStyle" />
            </td>
        </tr>
        <tr>
            <td class="label">
                Meeting Type:
            </td>
            <td>
                <asp:DropDownList ID="DropDownListMeetingType" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="label">
                Meeting Day:
            </td>
            <td>
                <asp:DropDownList ID="DropDownListDayOfWeek" runat="server">
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
                Meeting Time:
            </td>
            <td>
                <table class="time">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxHour" Text="12" ReadOnly="false" runat="server" Width="35px"></asp:TextBox>
                                        <cc1:NumericUpDownExtender ID="NumericUpDownExtenderHour" runat="server" TargetControlID="TextBoxHour"
                                            TargetButtonUpID="ImageButtonHourUp" TargetButtonDownID="ImageButtonHourDown"
                                            RefValues="1;2;3;4;5;6;7;8;9;10;11;12">
                                        </cc1:NumericUpDownExtender>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="ImageButtonHourUp" runat="server" Height="9px" Width="14px"
                                                        ImageUrl="/district64/images/up.gif" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="ImageButtonHourDown" runat="server" Height="9px" Width="13px"
                                                        ImageUrl="/district64/images/down.gif" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <table cellpadding="0px" cellspacing="0px" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxMinute" Text="00" ReadOnly="false" runat="server" Width="35px"></asp:TextBox>
                                        <cc1:NumericUpDownExtender ID="NumericUpDownExtenderMinute" runat="server" TargetControlID="TextBoxMinute"
                                            TargetButtonUpID="ImageButtonMinUp" TargetButtonDownID="ImageButtonMinDown" RefValues="00;10;20;30;40;50">
                                        </cc1:NumericUpDownExtender>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="ImageButtonMinUp" runat="server" Height="9px" Width="14px" ImageUrl="/district64/images/up.gif" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="ImageButtonMinDown" runat="server" Height="9px" Width="14px"
                                                        ImageUrl="/district64/images/down.gif" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0"  border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxModulation" Text="AM" ReadOnly="false" runat="server" Width="35px"></asp:TextBox>
                                        <cc1:NumericUpDownExtender ID="NumericUpDownExtenderModulation" runat="server" TargetControlID="TextBoxModulation"
                                            TargetButtonUpID="ImageButtonModUp" TargetButtonDownID="ImageButtonModDown" RefValues="AM;PM">
                                        </cc1:NumericUpDownExtender>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="ImageButtonModUp" runat="server" Height="9px" Width="14px" ImageUrl="/district64/images/up.gif" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="ImageButtonModDown" runat="server" Height="9px" Width="14px"
                                                        ImageUrl="/district64/images/down.gif" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            </td>    
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="label">
                Meeting Facility:
            </td>
            <td>
                <asp:TextBox ID="TextBoxFacility" runat="server" MaxLength="100" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label">
                Meeting Note:
            </td>
            <td>
                <asp:TextBox ID="TextBoxNote" runat="server" MaxLength="100" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label">
                Meeting Address:
            </td>
            <td>
                <asp:TextBox ID="TextBoxAddress" runat="server" MaxLength="100" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" ControlToValidate="TextBoxAddress"
                    ErrorMessage="Missing Required Information" Display="None" ValidationGroup="group1"></asp:RequiredFieldValidator>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtenderAddress" runat="server"
                    TargetControlID="RequiredFieldValidatorAddress" CssClass="customCalloutStyle" />
            </td>
        </tr>
        <tr>
            <td class="label">
                Meeting City:
            </td>
            <td>
                <asp:TextBox ID="TextBoxCity" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCity" runat="server" ControlToValidate="TextBoxCity"
                    ErrorMessage="Missing Required Information" Display="None" ValidationGroup="group1"></asp:RequiredFieldValidator>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtenderCity" runat="server" TargetControlID="RequiredFieldValidatorCity"
                    CssClass="customCalloutStyle" />
            </td>
        </tr>
        <tr>
            <td class="label">
                Meeting State:
            </td>
            <td>
                <asp:DropDownList ID="DropDownListState" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="label">
                Meeting Zip:
            </td>
            <td>
                <asp:TextBox ID="TextBoxZip" runat="server" MaxLength="5" Width="50px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderZip" runat="server" TargetControlID="TextBoxZip"
                    FilterType="Numbers" />
            </td>
        </tr>
        <tr>
            <td class="label">
                District Number:
            </td>
            <td>
                <asp:TextBox ID="TextBoxDistrictNumber" runat="server" MaxLength="2" Width="40px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderDistrictNumber" runat="server"
                    TargetControlID="TextBoxDistrictNumber" FilterType="Numbers" />
            </td>
        </tr>
        <tr>
            <td class="label">
                Handicapped:
            </td>
            <td>
                <asp:CheckBox ID="CheckBoxHandicapped" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="label">
                Womens:
            </td>
            <td>
                <asp:CheckBox ID="CheckBoxWomens" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="label">
                Submitters Name:
            </td>
            <td>
                <asp:TextBox ID="TextBoxSubmittedBy" runat="server" MaxLength="100" Width="200"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSubmittedBy" runat="server"
                    ControlToValidate="TextBoxSubmittedBy" ErrorMessage="Missing Required Information"
                    Display="None" ValidationGroup="group1"></asp:RequiredFieldValidator>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtenderSubmittedBy" runat="server"
                    TargetControlID="RequiredFieldValidatorSubmittedBy" CssClass="customCalloutStyle" />
            </td>
        </tr>
        <tr>
            <td class="label">
                Are you a GSR?
            </td>
            <td>
                <asp:CheckBox ID="CheckBoxGsr" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="label">
                Phone:
            </td>
            <td>
                <asp:TextBox ID="TextBoxSubmittedPhone" runat="server" MaxLength="12" Width="100"></asp:TextBox>630-555-1234
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderSubmittedPhone" runat="server"
                    TargetControlID="TextBoxSubmittedPhone" FilterType="Custom, Numbers" ValidChars="-" />
            </td>
        </tr>
        <tr>
            <td class="label">
                Email:
            </td>
            <td>
                <asp:TextBox ID="TextBoxEmail" runat="server" MaxLength="100" Width="200"></asp:TextBox>myname@myhost.com
            </td>
        </tr>  
        <tr><td class="label"> <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" ValidationGroup="group1"
        OnClick="ButtonSubmit_Click" CssClass="formbutton" />
    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtenderSubmit" runat="server" ConfirmText="Are you sure you wish to submit this Event Request?"
        TargetControlID="ButtonSubmit" />
        </td><td></td></tr>       
    </table>  
        <br />
    <ul class="menu">
                        <li><a href="http://www.aa-nia.org/pdf/info/GroupInformationChangeForm.doc">Get NIA Regstrar Form</a>
                        </li>
              </ul>                
       
</asp:Content>
