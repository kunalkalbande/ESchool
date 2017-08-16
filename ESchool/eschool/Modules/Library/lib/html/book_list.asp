<!-- #INCLUDE FILE="con1.asp" -->
<%

'if isempty(Session("EmpID")) then
'	Response.Redirect "../index.asp"
'end if	

dim pass;
pass=(Session["password"].ToString ());

Set conn= Server.CreateObject( "ADODB.Connection" )
conn.Open connectionstring 

'set conn = server.createobject ("adodb.connection")
'conn.open "ASPBook", "sa", "yourpassword"
if isempty(Request.QueryString("Category")) then
	CurrentCategory = "Top Level"
else
	CurrentCategory = Request.QueryString("Category")
end if
set RSChildren = conn.Execute("select CategoryName from LibCategories where " _
	& "ParentCategory = '" & CurrentCategory & "' " _
	& " order by CategoryName")
set RSBooks = conn.Execute("select BookID, Title, Author, Subject,ISBN,Description from LibBooks " _
	& "where Subject = '" & CurrentCategory & "'")
%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 3.2//EN">

<HTML>
<HEAD>
<TITLE>Book List</TITLE>
<META NAME="Generator" CONTENT="Microsoft FrontPage 4.0">
<LINK href="../../../Styles.css" type="text/css" rel="stylesheet">
</HEAD>

<BODY BACKGROUND="../../../images/maineschoolimage.jpg" LINK="#0000FF" VLINK="#800080" TEXT="#000000" onload="if((navigator.appName=='Netscape') && (navigator.appVersion.charAt(0)=='3') && (navigator.appVersion.indexOf('Win')+navigator.appVersion.indexOf('Mac')!=-2)) document.bgColor=document.bgColor;"  >
	<script type='text/javascript' src='g22_var.js'></script>
		<script type='text/javascript' src='menu81_com.js'></script>

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=640>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=20 HEIGHT =20><IMG SRC="../assets/images/dot_clear.gif" WIDTH =20 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=200><IMG SRC="../assets/images/dot_clear.gif" WIDTH =200 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=320><IMG SRC="../assets/images/dot_clear.gif" WIDTH =320 HEIGHT =1 BORDER=0>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
    </TD>
	<TD WIDTH=62><IMG SRC="../assets/images/dot_clear.gif" WIDTH =62 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=38><IMG SRC="../assets/images/dot_clear.gif" WIDTH =38 HEIGHT =1 BORDER=0></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =40></TD>
	<TD WIDTH=582 COLSPAN=3>
      <p align="center"><font size="4" color="#800000">Book List</font></p>
    </TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=5 HEIGHT =20></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=520 COLSPAN=2><P><B><FONT SIZE="+1">Category: <% response.write CurrentCategory %></B></FONT></TD>

	<TD COLSPAN=2><a href="library_menu.asp">Home</a></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=5 HEIGHT =19></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =20></TD>
	<TD WIDTH=582 COLSPAN=3 ALIGN="left" VALIGN="top"></TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=520 COLSPAN=2><P><B><FONT SIZE="+1">Subcategorizes in this category</B></FONT></TD>

	<TD COLSPAN=2></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=5 HEIGHT =8></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=200><P>
<%
Do Until RSChildren.EOF
%>	
	<A HREF="../html/book_list.asp?Category=<% Response.Write RSChildren("CategoryName") %>"><% Response.Write RSChildren("CategoryName") %></A><BR>
<%
	RSChildren.MoveNext
loop
%>	
	</TD>

	<TD COLSPAN=3></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=5 HEIGHT =31></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =20></TD>
	<TD WIDTH=582 COLSPAN=3 ALIGN="left" VALIGN="top"></TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=520 COLSPAN=2><P><B><FONT SIZE="+1">Books in this Category</B></FONT></TD>

	<TD COLSPAN=2></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=5 HEIGHT =19></TD>
   </TR>
<%
Do Until RSBooks.EOF
%>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=520 COLSPAN=2><P><B>Title:</B> <% Response.Write RSBooks("Title") %><BR><B>Author:</B> <% Response.Write RSBooks("Author") %><BR><B>Subject:</B> <% Response.Write RSBooks("Subject") %><BR><B>ISBN:</B> <% Response.Write RSBooks("ISBN") %><BR><B>Description:</B> <% Response.Write RSBooks("Description") %></TD>

	<TD COLSPAN=2></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=5 HEIGHT =20></TD>
   </TR>
<%
	RSBooks.MoveNext
loop
%>
  </TABLE>
</BODY>
</HTML>
