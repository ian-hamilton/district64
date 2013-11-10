<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ScrollValueBox.ascx.cs"
    Inherits="controls_WebUserControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table>
    <tr>
        <td>
            <asp:TextBox ID="TextBoxTextValue" Text="" ReadOnly="false" runat="server" Width="35px"></asp:TextBox>
            <cc1:NumericUpDownExtender ID="NumericUpDownExtenderTextValue" runat="server" TargetControlID="TextBoxTextValue"
                TargetButtonUpID="ImageButtonTextValueUp" TargetButtonDownID="ImageButtonTextValueDown"
                RefValues="">
            </cc1:NumericUpDownExtender>
        </td>
        <td>
            <table>
                <tr>
                    <td>
                        <asp:ImageButton ID="ImageButtonTextValueUp" runat="server" Height="9px" Width="14px"
                            ImageUrl="~/App_Themes/district64/images/up.gif" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ImageButton ID="ImageButtonTextValueDown" runat="server" Height="9px" Width="13px"
                            ImageUrl="~/App_Themes/district64/images/down.gif" />
                    </td>
                </tr>
            </table>
        </td>
        </tr>
</table>
