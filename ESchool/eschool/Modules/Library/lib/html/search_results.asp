<!-- #INCLUDE FILE="../con1.asp" -->


<%

dim pass;
pass=(Session["password"].ToString ());
'if isempty(Session("EmpID")) then
'	Response.Redirect "../index.asp"
'end if	
if isempty(Request.Form("SearchField")) or isempty(Request.Form("SearchCriteria")) then
	Response.Redirect "./search.html"
end if

Set conn= Server.CreateObject( "ADODB.Connection" )
conn.Open connectionstring 

'set conn = server.createobject ("adodb.connection")
'conn.open "ASPBook", "sa", "yourpassword"
set RSBooks = conn.Execute("select BookID, Author, Title, Subject from LibBooks where " _
	& Request.Form("SearchField") & " Like '%" & Request.Form("SearchCriteria") & "%'")
%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 3.2//EN">

<HTML>
<HEAD>
<TITLE>Search Results</TITLE>
<META NAME="Generator" CONTENT="Microsoft FrontPage 4.0">
<LINK href="../../../Styles.css" type="text/css" rel="stylesheet">

</HEAD>

<BODY BACKGROUND="../../../images/maineschoolimage.jpg" LINK="#0000FF" VLINK="#800080" TEXT="#000000" onload="if((navigator.appName=='Netscape') && (navigator.appVersion.charAt(0)=='3') && (navigator.appVersion.indexOf('Win')+navigator.appVersion.indexOf('Mac')!=-2)) document.bgColor=document.bgColor;"  >
	<script type='text/javascript' src='g22_var.js'></script>
	<script type='text/javascript' src='menu81_com.js'></script>

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=640>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=20 HEIGHT =20><IMG SRC="../assets/images/dot_clear.gif" WIDTH =20 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=520><IMG SRC="../assets/images/dot_clear.gif" WIDTH =520 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=62><IMG SRC="../assets/images/dot_clear.gif" WIDTH =62 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=38><IMG SRC="../assets/images/dot_clear.gif" WIDTH =38 HEIGHT =1 BORDER=0></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =40></TD>
	<TD WIDTH=582 COLSPAN=2>
      <p align="center">&nbsp;</p>
      <p align="center">&nbsp;</p>
      <p align="center">&nbsp;</p>
      <p align="center">&nbsp;</p>
      <p align="center"><font size="5" color="#800000">Search Results</font></p>
    </TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=4 HEIGHT =20></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=520><P><B><FONT SIZE="+1">Your search for <% Response.Write Request.Form("SearchCriteria") %> in <% Response.Write Request.Form("SearchField") %> field found:</B></FONT></TD>

	<TD COLSPAN=2><a href="library_menu.asp">Home</a></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=4 HEIGHT =19></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =20></TD>
	<TD WIDTH=582 COLSPAN=2 ALIGN="left" VALIGN="top"><IMG HEIGHT=9 WIDTH=520 SRC="../assets/images/Bar7.gif"  BORDER=0  ALT="Picture" ></TD>
	<TD></TD>
   </TR>
<%
Do Until RSBooks.EOF
%>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=520><P><B>Title:</B> <A HREF="../html/book.asp?BookID=<% Response.Write RSBooks("BookID") %>"><% Response.Write RSBooks("Title") %></A><BR><B>Author:</B> <% Response.Write RSBooks("Author") %><BR><B>Subject:</B> <% Response.Write RSBooks("Subject") %></TD>

	<TD COLSPAN=2></TD>
   </TR>
<%
	RSBooks.MoveNext
Loop
%>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=4 HEIGHT =320></TD>
   </TR>
  </TABLE>
</BODY>
</HTML>
