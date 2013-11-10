<%@ Page Title="Event Request" Language="C#" MasterPageFile="~/district.master" AutoEventWireup="true"
    CodeFile="eventrequest.aspx.cs" Inherits="event_eventrequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 46px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<h2>AA Event Web Notification Request</h2>
    <br />
    <asp:Table ID="TableError" runat="server" CssClass="error">
    </asp:Table>
    <asp:MultiView ID="MultiViewEvent" runat="server">
        <asp:View ID="ViewExtendedInfo" runat="server">
                  <table class="display">
                <tr>
                    <td class="label">
                        Event Id:
                    </td>
                    <td>
                        <asp:Literal ID="LiteralEventId" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        Event Created:
                    </td>
                    <td>
                        <asp:Literal ID="LiteralCreated" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        Event Updated:
                    </td>
                    <td>
                        <asp:Literal ID="LiteralUpdated" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        Event Approved:
                    </td>
                    <td>
                        <asp:Literal ID="LiteralApproved" runat="server"></asp:Literal>
                    </td>
                </tr>
                 <tr>
                    <td class="label">
                        Event Status:
                    </td>
                    <td>
                        <asp:Literal ID="LiteralStatus" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
                <br />
        </asp:View>
    </asp:MultiView>

    <table class="display">
        <tr>
            <th colspan="2" align="center">
              <span style = "font-weight: bold"> &nbsp &nbsp &nbsp Enter the information that you<br /> 
               &nbsp &nbsp &nbsp want shown on the District 64 web site.</span>
               
            </th>
        </tr>
        <tr>
            <td class="label">
                Event Subject:
            </td>
            <td>
                <asp:TextBox ID="TextBoxSubject" MaxLength="100" runat="server" Width="400"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSubject" runat="server" ControlToValidate="TextBoxSubject"
                    ErrorMessage="Missing Required Information" Display="None" ValidationGroup="group1"></asp:RequiredFieldValidator>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtenderSubject" runat="server"
                    TargetControlID="RequiredFieldValidatorSubject" CssClass="customCalloutStyle" />
            </td>
        </tr>
        <tr>
            <td class="label">
                Event Description:
            </td>
            <td>
                <asp:TextBox ID="TextBoxEventDesc" runat="server" Width="500" Rows="10" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDesc" runat="server" ControlToValidate="TextBoxEventDesc"
                    ErrorMessage="Missing Required Information" Display="None" ValidationGroup="group1"></asp:RequiredFieldValidator>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtenderEventDesc" runat="server"
                    TargetControlID="RequiredFieldValidatorDesc" CssClass="customCalloutStyle" />
            </td>
        </tr>
        <tr>
            <td class="label">
                Event Date:
            </td>
            <td>
                <asp:TextBox ID="TextBoxEventDate" runat="server"></asp:TextBox>MM/DD/YYYY
                <cc1:CalendarExtender ID="CalendarExtenderEventDate" TargetControlID="TextBoxEventDate"
                    runat="server" CssClass="MyCalendar">
                </cc1:CalendarExtender>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderEventDate" runat="server"
                    TargetControlID="TextBoxEventDate" FilterType="Custom ,Numbers" ValidChars="/" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ControlToValidate="TextBoxEventDate"
                    ErrorMessage="Missing Required Information" Display="None" ValidationGroup="group1"></asp:RequiredFieldValidator>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtenderEventDate" runat="server" TargetControlID="RequiredFieldValidatorDate"
                    CssClass="customCalloutStyle" />
            </td>
            
            <%--NEW--%>
           <%-- <td class="label">
                Event Begin Date:
            </td>
            <td>
                <asp:TextBox ID="TextBoxEventBeginDate" runat="server"></asp:TextBox>MM/DD/YYYY
                <cc1:CalendarExtender ID="CalendarExtenderEventBeginDate" TargetControlID="TextBoxEventBeginDate"
                    runat="server" CssClass="MyCalendar">
                </cc1:CalendarExtender>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderEventBeginDate" runat="server"
                    TargetControlID="TextBoxEventBeginDate" FilterType="Custom ,Numbers" ValidChars="/" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate1" runat="server" ControlToValidate="TextBoxEventBeginDate"
                    ErrorMessage="Missing Required Information" Display="None" ValidationGroup="group1"></asp:RequiredFieldValidator>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtenderEventBeginDate" runat="server" TargetControlID="RequiredFieldValidatorDate"
                    CssClass="customCalloutStyle" />
            </td>--%>
            </tr>       
        
        
        <tr>
            <td class="label">
                Event Time:
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
                Event Location:
            </td>
            <td>
                <asp:TextBox ID="TextBoxLocation" MaxLength="100" Width="400" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label">
                Event Address:
            </td>
            <td>
                <asp:TextBox ID="TextBoxAdress" MaxLength="100" Width="400" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label">
                Event City:
            </td>
            <td>
                <asp:TextBox ID="TextBoxCity" MaxLength="100" Width="200" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label">
                Event State:
            </td>
            <td>
                <asp:DropDownList ID="DropDownListState" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="label">
                Event Zip:
            </td>
            <td>
                <asp:TextBox ID="TextBoxZip" runat="server" MaxLength="5"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderZip" runat="server" TargetControlID="TextBoxZip"
                    FilterType="Numbers" />
            </td>
        </tr>
          <tr>
            <td class="label">
                Flyer File Upload:
            </td>
            <td>
                <asp:FileUpload ID="FileUploadFlyer" runat="server" CssClass="formbutton" />
                <asp:LinkButton ID="LinkButtonFlyer" runat="server" Visible="False" 
                    onclick="LinkButtonFlyer_Click">Download Flyer</asp:LinkButton>
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
                Phone:
            </td>
            <td>
                <asp:TextBox ID="TextBoxSubmittedPhone" runat="server" MaxLength="12" Width="100"></asp:TextBox>630-555-1234
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderSubmittedPhone" runat="server"
                    TargetControlID="TextBoxSubmittedPhone" FilterType="Custom, Numbers" ValidChars="-" />
            </td>
        </tr>
        <tr>
            <td class="label" style="height: 46px">
                Email:
            </td>
            <td class="style1">
                <asp:TextBox ID="TextBoxEmail" runat="server" MaxLength="100" Width="200"></asp:TextBox>myname@myhost.com
            </td>
        </tr>
             <tr><td class="label"><asp:Button ID="ButtonSubmit" CssClass="formbutton" runat="server" Text="Submit" ValidationGroup="group1"
        OnClick="ButtonSubmit_Click" />
    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtenderSubmit" runat="server" ConfirmText="Are you sure you wish to submit this Event Request?"
        TargetControlID="ButtonSubmit" /><br /><br />
      
     <%--use below area for changing status flag to 0 for unwanted events--%>
     
     <asp:Button ID="ButtonReject" CssClass="formbutton" runat="server" Text="Reject" ValidationGroup="group1"
       Onclick="ButtonReject_Click" />
    <cc1:confirmbuttonextender id="ConfirmButtonExtenderReject" runat="server" confirmtext="Are you sure you wish to reject this Event Request? \n 
    This will cancel any changes to the corresponding schedule"
        targetcontrolid="ButtonReject" />  
        
      <%-- end new  --%>  </td></tr>
    </table>
    <br />       
        
</asp:Content>
