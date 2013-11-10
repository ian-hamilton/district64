<%@ Page Title="" Language="C#" MasterPageFile="~/district.master" AutoEventWireup="true"
    CodeFile="meetingrequestapproval.aspx.cs" Inherits="schedule_meetingrequestapproval" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/controls/ScrollValueBox.ascx" TagName="ScrollValueBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>
        Meeting Change/Add Request...</h3>
    <br />
    <asp:Table ID="TableError" runat="server" CssClass="error">
    </asp:Table>
    <asp:MultiView ID="MultiViewEvent" runat="server">
        <asp:View ID="ViewExtendedInfo" runat="server">
            <table class="display">
                <tr>
                    <td class="label">
                        Meeting Id:
                    </td>
                    <td>
                        <asp:Literal ID="LiteralMeetingId" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        Meeting Created:
                    </td>
                    <td>
                        <asp:Literal ID="LiteralCreated" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        Meeting Updated:
                    </td>
                    <td>
                        <asp:Literal ID="LiteralUpdated" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        Meeting Approved:
                    </td>
                    <td>
                        <asp:Literal ID="LiteralApproved" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
            <br />
        </asp:View>
    </asp:MultiView>
    <table class="display">
        <tr>
            <td class="label">
                Meeting Name:
            </td>
            <td>
                <asp:TextBox ID="TextBoxMeetingName" runat="server" Width="300"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorMeetingName" runat="server"
                    ControlToValidate="TextBoxMeetingName" ErrorMessage="Missing Required Information"
                    Display="None" ValidationGroup="group1"></asp:RequiredFieldValidator>
                <cc1:validatorcalloutextender id="ValidatorCalloutExtenderMeetingName" runat="server"
                    targetcontrolid="RequiredFieldValidatorMeetingName" cssclass="customCalloutStyle" />
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
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxHour" Text="12" ReadOnly="false" runat="server" Width="35px"></asp:TextBox>
                                        <cc1:numericupdownextender id="NumericUpDownExtenderHour" runat="server" targetcontrolid="TextBoxHour"
                                            targetbuttonupid="ImageButtonHourUp" targetbuttondownid="ImageButtonHourDown"
                                            refvalues="1;2;3;4;5;6;7;8;9;10;11;12">
                                        </cc1:numericupdownextender>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="ImageButtonHourUp" runat="server" Height="9px" Width="14px"
                                                        ImageUrl="~/App_Themes/district64/images/up.gif" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="ImageButtonHourDown" runat="server" Height="9px" Width="13px"
                                                        ImageUrl="~/App_Themes/district64/images/down.gif" />
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
                                        <cc1:numericupdownextender id="NumericUpDownExtenderMinute" runat="server" targetcontrolid="TextBoxMinute"
                                            targetbuttonupid="ImageButtonMinUp" targetbuttondownid="ImageButtonMinDown" refvalues="00;10;20;30;40;50">
                                        </cc1:numericupdownextender>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="ImageButtonMinUp" runat="server" Height="9px" Width="14px" ImageUrl="~/App_Themes/district64/images/up.gif" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="ImageButtonMinDown" runat="server" Height="9px" Width="14px"
                                                        ImageUrl="~/App_Themes/district64/images/down.gif" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxModulation" Text="AM" ReadOnly="false" runat="server" Width="35px"></asp:TextBox>
                                        <cc1:numericupdownextender id="NumericUpDownExtenderModulation" runat="server" targetcontrolid="TextBoxModulation"
                                            targetbuttonupid="ImageButtonModUp" targetbuttondownid="ImageButtonModDown" refvalues="AM;PM">
                                        </cc1:numericupdownextender>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="ImageButtonModUp" runat="server" Height="9px" Width="14px" ImageUrl="~/App_Themes/district64/images/up.gif" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="ImageButtonModDown" runat="server" Height="9px" Width="14px"
                                                        ImageUrl="~/App_Themes/district64/images/down.gif" />
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
                <cc1:validatorcalloutextender id="ValidatorCalloutExtenderAddress" runat="server"
                    targetcontrolid="RequiredFieldValidatorAddress" cssclass="customCalloutStyle" />
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
                <cc1:validatorcalloutextender id="ValidatorCalloutExtenderCity" runat="server" targetcontrolid="RequiredFieldValidatorCity"
                    cssclass="customCalloutStyle" />
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
                <cc1:filteredtextboxextender id="FilteredTextBoxExtenderZip" runat="server" targetcontrolid="TextBoxZip"
                    filtertype="Numbers" />
            </td>
        </tr>
        <tr>
            <td class="label">
                District Number:
            </td>
            <td>
                <asp:TextBox ID="TextBoxDistrictNumber" runat="server" MaxLength="2" Width="40px"></asp:TextBox>
                <cc1:filteredtextboxextender id="FilteredTextBoxExtenderDistrictNumber" runat="server"
                    targetcontrolid="TextBoxDistrictNumber" filtertype="Numbers" />
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
                <asp:Label ID="LabelSubmittersName" runat="server" Text=""></asp:Label>
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
                <asp:Label ID="LabelSubmittersPhone" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="label">
                Email:
            </td>
            <td>
                <asp:Label ID="LabelSubmittersEmail" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="ButtonApprove" runat="server" Text="Approve" 
        ValidationGroup="group1" onclick="ButtonApprove_Click" />
    <cc1:confirmbuttonextender id="ConfirmButtonExtenderApprove" runat="server" confirmtext="Are you sure you wish to approve this Event Request? \n 
    This will overwrite the meeting information in the corresponding schedule."
        targetcontrolid="ButtonApprove" />
        &nbsp;&nbsp;
    <asp:Button ID="ButtonReject" runat="server" Text="Reject" 
        ValidationGroup="group1" onclick="ButtonReject_Click" />
    <cc1:confirmbuttonextender id="ConfirmButtonExtenderReject" runat="server" confirmtext="Are you sure you wish to reject this Event Request? \n 
    This will cancel any changes to the corresponding schedule"
        targetcontrolid="ButtonReject" />
</asp:Content>
