<!-- #INCLUDE FILE="../con1.asp" -->
<%

'if isempty(Session("EmpID")) then
'	Response.Redirect "../index.asp"
'end if	
'Dim Pass 
'pass=(Session("password"));

Dim conn

Set conn= Server.CreateObject( "ADODB.Connection" )
conn.Open connectionstring 

'set conn = server.createobject ("adodb.connection")
'conn.open "ASPBook", "sa", "yourpassword"
'if NOT isempty(Request.Form("CheckIn")) then
'	conn.Execute "update LibBooks set CheckedOutTo = 0, Status = 'Available' where " _
'		& " BookID = " & Request.Form("BookID")
'end if

'EmpID
set RSBooks = conn.Execute ("select BookID, Title from LibBooks")
'set RSBooks = conn.Execute ("select BookID, Title from LibBooks where " _
	'& "CheckedOutTo = " & Session("EmpID"))
%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 3.2//EN">

<HTML>
<HEAD>
<TITLE>Library Menu</TITLE>
<META NAME="Generator" CONTENT="Microsoft FrontPage 4.0">
<LINK href="../../../Styles.css" type="text/css" rel="stylesheet">

</HEAD>

<BODY BACKGROUND="../../../images/maineschoolimage.jpg" LINK="#0000FF" VLINK="#800080" TEXT="#000000" onload="if((navigator.appName=='Netscape') && (navigator.appVersion.charAt(0)=='3') && (navigator.appVersion.indexOf('Win')+navigator.appVersion.indexOf('Mac')!=-2)) document.bgColor=document.bgColor;"  >
<script type='text/javascript' src='g22_var.js'></script>
<script type='text/javascript' src='menu81_com.js'></script>

<FORM ACTION="./library_menu.asp"  METHOD=POST>
  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=640>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=20 HEIGHT =20><IMG SRC="../assets/images/dot_clear.gif" WIDTH =20 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=582><IMG SRC="../assets/images/dot_clear.gif" WIDTH =582 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=38><IMG SRC="../assets/images/dot_clear.gif" WIDTH =38 HEIGHT =1 BORDER=0></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =40></TD>
	<TD WIDTH=582>
      <p align="center">&nbsp;</p>
      <p align="center">&nbsp;</p>
      <p align="center">&nbsp;</p>
      <p align="center">&nbsp;</p>
      <p align="center"><font size="4" color="#800000">Library Menu</font></p>
    </TD>
	<TD></TD>
   </TR>
  </TABLE>

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=640>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=20 HEIGHT =20><IMG SRC="../assets/images/dot_clear.gif" WIDTH =20 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=540><IMG SRC="../assets/images/dot_clear.gif" WIDTH =540 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=80><IMG SRC="../assets/images/dot_clear.gif" WIDTH =80 HEIGHT =1 BORDER=0></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=540><P><B><FONT SIZE="+1">Select your option below.</B></FONT></TD>

	<TD></TD>
   </TR>
  </TABLE>

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=640>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=20 HEIGHT =19><IMG SRC="../assets/images/dot_clear.gif" WIDTH =20 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=520><IMG SRC="../assets/images/dot_clear.gif" WIDTH =520 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=100><IMG SRC="../assets/images/dot_clear.gif" WIDTH =100 HEIGHT =1 BORDER=0></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =9></TD>
	<TD WIDTH=520 ALIGN="left" VALIGN="top"></TD>
	<TD></TD>
   </TR>
  </TABLE>
<TABLE CELLPADDING=0 CELLSPACING=0 BORDER=0 WIDTH=640>
<TR VALIGN="top" ALIGN="left">
<TD>

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=200>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=20 HEIGHT =11><IMG SRC="../assets/images/dot_clear.gif" WIDTH =20 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=85><IMG SRC="../assets/images/dot_clear.gif" WIDTH =85 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=95><IMG SRC="../assets/images/dot_clear.gif" WIDTH =95 HEIGHT =1 BORDER=0></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=180 COLSPAN=2><P><A HREF="../html/search.html">Search for a Book</A></TD>

   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=3 HEIGHT =20></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=180 COLSPAN=2><P><A HREF="../html/book_list.asp">Browse the Listings</A></TD>

   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=3 HEIGHT =20></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=180 COLSPAN=2><P>Check In Book</TD>

   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=3 HEIGHT =8></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =24></TD>
	<TD WIDTH=85><INPUT TYPE="submit" NAME="CheckIn" VALUE="Check In" ></TD>
	<TD></TD>
   </TR>
  </TABLE>
</TD>
<TD>

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=440>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=21 HEIGHT =92><IMG SRC="../assets/images/dot_clear.gif" WIDTH =21 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=100><IMG SRC="../assets/images/dot_clear.gif" WIDTH =100 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=319><IMG SRC="../assets/images/dot_clear.gif" WIDTH =319 HEIGHT =1 BORDER=0></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =24></TD>
	<TD WIDTH=100><SELECT NAME="BookID" >
<%
Do Until RSBooks.EOF
%>
	<OPTION VALUE="<% Response.Write RSBooks("BookID") %>"><% Response.Write RSBooks("Title") %></OPTION>
<%
	RSBooks.MoveNext
loop
%>		
	</SELECT></TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=3 HEIGHT =27></TD>
   </TR>
  </TABLE>
</TD>
</TR>
</TABLE>

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=640>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=20 HEIGHT =28><IMG SRC="../assets/images/dot_clear.gif" WIDTH =20 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=520><IMG SRC="../assets/images/dot_clear.gif" WIDTH =520 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=100><IMG SRC="../assets/images/dot_clear.gif" WIDTH =100 HEIGHT =1 BORDER=0></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =9></TD>
	<TD WIDTH=520 ALIGN="left" VALIGN="top"><a HREF="management_menu.asp">Management Menu</a></TD>
	<TD></TD>
   </TR>
  </TABLE>

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=640>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=20 HEIGHT =31><IMG SRC="../assets/images/dot_clear.gif" WIDTH =20 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=180><IMG SRC="../assets/images/dot_clear.gif" WIDTH =180 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=440><IMG SRC="../assets/images/dot_clear.gif" WIDTH =440 HEIGHT =1 BORDER=0></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=180><P><% If Session("Manager") = 1 then	%><% end if %></TD>

	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=3 HEIGHT =240></TD>
   </TR>
  </TABLE>

 </FORM></BODY>
</HTML>
