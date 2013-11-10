<%@ Page Title="" Language="C#" MasterPageFile="~/district.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta name="description" content="AA Alcoholics Anonymous serving Aurora, IL" />
    <meta name="keywords" content="Alcoholics Anonymouse Aurora District 64, Alcoholics Anonymous, AA, Drinking, Aurora, North Aurora, District 64" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h2>Serving Aurora, North Aurora and Sugar Grove</h2>
       
       <div id="right-menu-box">	
	        <ul class="right-menu">  
	            <li>    
	                <a href="http://www.aa.org/lang/en/subpage.cfm?page=359" target="_blank"><img src="/district64/images/en_big_book_anime.gif" alt="AA Big Book" border="0" /></a>
	            </li> 
	            <li>  
	                <a href="http://www.aa.org/pdf/products/p-2_faqAboutAA.pdf" target="_blank"><img src="/district64/images/p-2_faqAboutAA.jpg" alt="About AA" border="0" /></a>	    
	            </li> 
	            <li>  
	                <a href="http://www.aa.org/pdf/products/p-3_isaaforyou.pdf" target="_blank"><img src="/district64/images/p-3_isaaforyou.jpg" alt="Is AA for You?" border="0" /></a>	    
	            </li>  
	            <li>  
	                <a href="http://www.aa.org/pdf/products/f-1_AAataGlance.pdf" target="_blank"><img src="/district64/images/f-1_AAataGlance1.gif" alt="Is AA for You?" border="0" /></a>	    
	            </li>           
	        </ul>  
	    </div>
	  
       
       
        <div class="article" style="float:left; width:500px;">
		 <h3 style="text-align: center; height: 18px;">The AA Preamble</h3>
		     <p style="font-weight: lighter; font-size: small; text-align:center; width: 100%;">
		     Alcoholics Anonymous 
		     is a fellowship of men and women who
		     share their experience, strength and
		     hope with each other that they may
		     solve their common problem and help
		     others to recover from alcoholism.
		     The only requirementfor membership
		     is a desire to stop drinking. There
		     are no dues or fees for A.A. membership; 
		     we are self supporting  through our own
		     contributions. A.A. is not allied with
		     any sect, denomination, politics, 
		     organization or institution; does not engage 
		     in any controversy; neither endorses nor 
		     opposes any causes. Our primary purpose
		     is to stay sober and help other alcoholics
		     to achieve sobriety. </p>
		     <br />
		     <h3 style="text-align: center; font-size: 80%; font-weight: normal; ">
		     Copyright © The Grapevine Inc</h3>
		</div>
		
		<div class="article-zebra" style="float:left; width:300px;" >
		    <h3 style="text-align: center; height: 18px;">Upcoming Events</h3>
            <asp:Literal ID="LiteralEvents" runat="server"></asp:Literal>
		</div>
		
	
		
	    


</asp:Content>

