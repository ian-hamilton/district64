<%@ Page Title="" Language="C#" MasterPageFile="~/district.master" AutoEventWireup="true" CodeFile="unauthorized.aspx.cs" Inherits="info_unauthorized" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h2>Unauthorized Access....</h2>
    <p class="error">We are sorry...but your current security access does not allow entry to this page.</p>
    <p>Please login if you are trying to reach a secured page.</p><br />
    
    <a href="/district64/Default.aspx">Return Home</a>
    

</asp:Content>

