<!-- #INCLUDE FILE="../con1.asp" -->
<%
'if isempty(Session("EmpID")) then
'	Response.Redirect "../index.asp"
'end if	
dim pass;
pass=(Session["password"].ToString ());

if Session("Manager") <> 1 then
	Response.Redirect "./library_menu.asp"
end if
if NOT isempty(Request.Form("OK")) then
	
Set conn= Server.CreateObject( "ADODB.Connection" )
conn.Open connectionstring 

	
	'set conn = server.createobject ("adodb.connection")
	'conn.open "ASPBook", "sa", "yourpassword"
	conn.Execute "update LibBooks set " _
		& "Title = '" & Request.Form("Title") & "', " _
		& "Subject = '" & Request.Form("Subject") & "', " _
		& "Author = '" & Request.Form("Author") & "', " _
		& "ISBN = '" & Request.Form("ISBN") & "', " _
		& "Keywords = '" & Request.Form("Keywords") & "', " _
		& "Description = '" & Request.Form("Description") & "' " _
		& "where BookID = " & Request.Form("BookID")
	Response.Redirect "./library_menu.asp"
elseif NOT isempty(Request.QueryString("BookID")) then
	
	Set conn= Server.CreateObject( "ADODB.Connection" )
   conn.Open connectionstring 

	'set conn = server.createobject ("adodb.connection")
	'conn.open "ASPBook", "sa", "yourpassword"
	
	set RSBooks = conn.Execute("select * from LibBooks where BookID = " _
		& Request.QueryString("BookID"))
	set RSCategories = conn.Execute("select CategoryName from LibCategories order by CategoryName")
else
	Response.Redirect "./library_menu.asp"
end if	
%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 3.2//EN">

<HTML>
<HEAD>
<TITLE>Edit Book</TITLE>
<META NAME="Generator" CONTENT="Microsoft FrontPage 4.0">
<LINK href="../../../Styles.css" type="text/css" rel="stylesheet">

</HEAD>
	<script type='text/javascript' src='g22_var.js'></script>
	<script type='text/javascript' src='menu81_com.js'></script>

<BODY BACKGROUND="../../../images/maineschoolimage.jpg" LINK="#0000FF" VLINK="#800080" TEXT="#000000" onload="if((navigator.appName=='Netscape') && (navigator.appVersion.charAt(0)=='3') && (navigator.appVersion.indexOf('Win')+navigator.appVersion.indexOf('Mac')!=-2)) document.bgColor=document.bgColor;"  >

<FORM ACTION="./edit_book.asp"  METHOD=POST>
 <INPUT TYPE=HIDDEN NAME="BookID" VALUE = "<% response.write Request.QueryString("BookID") %>">

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
      <p align="center"><font size="4" color="#800000">Edit Book</font></p>
      <p align="center">&nbsp;</p>
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
	<TD WIDTH=540><P><B><FONT SIZE="+1">Complete Each Field</B></FONT></TD>

	<TD><a href="library_menu.asp">Home</a></TD>
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

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=153>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=20 HEIGHT =11><IMG SRC="../assets/images/dot_clear.gif" WIDTH =20 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=36><IMG SRC="../assets/images/dot_clear.gif" WIDTH =36 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=97><IMG SRC="../assets/images/dot_clear.gif" WIDTH =97 HEIGHT =1 BORDER=0></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=133 COLSPAN=2><P>Title</TD>

   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=3 HEIGHT =20></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=133 COLSPAN=2><P>Author</TD>

   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=3 HEIGHT =20></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=133 COLSPAN=2><P>Subject</TD>

   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=3 HEIGHT =20></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=133 COLSPAN=2><P>ISBN</TD>

   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=3 HEIGHT =20></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=133 COLSPAN=2><P>Keywords</TD>

   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=3 HEIGHT =20></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=133 COLSPAN=2><P>Description</TD>

   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=3 HEIGHT =20></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =24></TD>
	<TD WIDTH=36><INPUT TYPE="submit" NAME="OK" VALUE="OK" ></TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=3 HEIGHT =196></TD>
   </TR>
  </TABLE>
</TD>
<TD>

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=487>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=27 HEIGHT =11><IMG SRC="../assets/images/dot_clear.gif" WIDTH =27 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=116><IMG SRC="../assets/images/dot_clear.gif" WIDTH =116 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=204><IMG SRC="../assets/images/dot_clear.gif" WIDTH =204 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=140><IMG SRC="../assets/images/dot_clear.gif" WIDTH =140 HEIGHT =1 BORDER=0></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =22></TD>
	<TD WIDTH=320 COLSPAN=2><INPUT TYPE="text" NAME="Title" VALUE="<% response.write RSBooks("Title") %>" SIZE=40 MAXLENGTH=100 ></TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=4 HEIGHT =18></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =22></TD>
	<TD WIDTH=320 COLSPAN=2><INPUT TYPE="text" NAME="Author" VALUE="<% response.write RSBooks("Author") %>" SIZE=40 MAXLENGTH=100 ></TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=4 HEIGHT =18></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =24></TD>
	<TD WIDTH=116><SELECT NAME="Subject" >
	<OPTION VALUE="<% response.write RSBooks("Subject") %>" SELECTED><% response.write RSBooks("Subject") %></OPTION>
<%
Do Until RSCategories.EOF
%>		
	<OPTION VALUE="<% response.write RSCategories("CategoryName") %>"><% response.write RSCategories("CategoryName") %></OPTION>
<%
	RSCategories.MoveNext
loop
%>		
	</SELECT></TD>
	<TD COLSPAN=2></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=4 HEIGHT =16></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =22></TD>
	<TD WIDTH=320 COLSPAN=2><INPUT TYPE="text" NAME="ISBN" VALUE="<% response.write RSBooks("ISBN") %>" SIZE=40 MAXLENGTH=100 ></TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=4 HEIGHT =18></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =22></TD>
	<TD WIDTH=320 COLSPAN=2><INPUT TYPE="text" NAME="Keywords" VALUE="<% response.write RSBooks("Keywords") %>" SIZE=40 MAXLENGTH=100 ></TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=4 HEIGHT =18></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =22></TD>
	<TD WIDTH=320 COLSPAN=2><INPUT TYPE="text" NAME="Description" VALUE="<% response.write RSBooks("Description") %>" SIZE=40 MAXLENGTH=100 ></TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=4 HEIGHT =238></TD>
   </TR>
  </TABLE>
</TD>
</TR>
</TABLE>

 </FORM></BODY>
</HTML>
