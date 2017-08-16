<!-- #INCLUDE FILE="con1.asp" -->
<%

'if isempty(Session("EmpID")) then
'	Response.Redirect "../index.asp"
'end if	
'if Session("Manager") <> 1 then
'	Response.Redirect "./library_menu.asp"
'end if
dim pass;
pass=(Session["password"].ToString ());

if NOT isempty(Request.Form("Edit")) then
	Response.Redirect "./edit_book.asp?BookID=" & Request.Form("EditBookID")
end if

Set conn= Server.CreateObject( "ADODB.Connection" )
conn.Open connectionstring 

'set conn = server.createobject ("adodb.connection")
'conn.open "ASPBook", "sa", "yourpassword"
if NOT isempty(Request.Form("Delete")) then
	conn.Execute "delete from LibBooks where BookID = " & Request.Form("DeleteBookID")
end if
if NOT isempty(Request.Form("Add")) then
	conn.Execute "insert into LibCategories (CategoryName, ParentCategory) values (" _
		& "'" & Request.Form("CategoryName") & "', " _
		& "'" & Request.Form("ParentCategory") & "')"
	Response.Redirect "./management_menu.asp"
end if
set RSBooks = conn.Execute("select BookID, Title from LibBooks order by Title")
Do Until RSBooks.Eof
	BookOptions = BookOptions & "<OPTION VALUE=""" & RSBooks("BookID") & """>" _
		& RSBooks("Title") & "</OPTION>"
	RSBooks.MoveNext
Loop
set RSCategories = conn.Execute("select CategoryName from LibCategories order by CategoryName")
	
%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 3.2//EN">

<HTML>
<HEAD>
<TITLE>Management Menu</TITLE>
<META NAME="Generator" CONTENT="Microsoft FrontPage 4.0">
<LINK href="../../../Styles.css" type="text/css" rel="stylesheet">
</HEAD>

<BODY BACKGROUND="../../../images/maineschoolimage.jpg" LINK="#0000FF" VLINK="#800080" TEXT="#000000" onload="if((navigator.appName=='Netscape') && (navigator.appVersion.charAt(0)=='3') && (navigator.appVersion.indexOf('Win')+navigator.appVersion.indexOf('Mac')!=-2)) document.bgColor=document.bgColor;"  >
	<script type='text/javascript' src='g22_var.js'></script>
	<script type='text/javascript' src='menu81_com.js'></script>

<FORM ACTION="./management_menu.asp"  METHOD=POST>

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
      <p align="center"><font size="6" color="#800000">Management&nbsp; Menu</font></p>
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

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=200>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=19 HEIGHT =11><IMG SRC="../assets/images/dot_clear.gif" WIDTH =19 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=1><IMG SRC="../assets/images/dot_clear.gif" WIDTH =1 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=43><IMG SRC="../assets/images/dot_clear.gif" WIDTH =43 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=26><IMG SRC="../assets/images/dot_clear.gif" WIDTH =26 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=110><IMG SRC="../assets/images/dot_clear.gif" WIDTH =110 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=1><IMG SRC="../assets/images/dot_clear.gif" WIDTH =1 HEIGHT =1 BORDER=0></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=2></TD>
	<TD WIDTH=180 COLSPAN=4><P><A HREF="../html/add_book.asp">Add a new book</A></TD>

   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=6 HEIGHT =19></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=180 COLSPAN=4><P>Edit This Book</TD>

	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=6 HEIGHT =11></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=2 HEIGHT =24></TD>
	<TD WIDTH=43><INPUT TYPE="submit" NAME="Edit" VALUE="Edit" ></TD>
	<TD COLSPAN=3></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=6 HEIGHT =26></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=2></TD>
	<TD WIDTH=180 COLSPAN=4><P>Delete This Book</TD>

   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=6 HEIGHT =20></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=2 HEIGHT =24></TD>
	<TD WIDTH=69 COLSPAN=2><INPUT TYPE="submit" NAME="Delete" VALUE="Delete" ></TD>
	<TD COLSPAN=2></TD>
   </TR>
  </TABLE>
</TD>
<TD>

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=440>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=20 HEIGHT =51><IMG SRC="../assets/images/dot_clear.gif" WIDTH =20 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=100><IMG SRC="../assets/images/dot_clear.gif" WIDTH =100 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=320><IMG SRC="../assets/images/dot_clear.gif" WIDTH =320 HEIGHT =1 BORDER=0></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =24></TD>
	<TD WIDTH=100><SELECT NAME="EditBookID" ><% Response.Write BookOptions %></SELECT></TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=3 HEIGHT =56></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =24></TD>
	<TD WIDTH=100><SELECT NAME="DeleteBookID" ><% Response.Write BookOptions %></SELECT></TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=3 HEIGHT =40></TD>
   </TR>
  </TABLE>
</TD>
</TR>
</TABLE>

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=640>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=20 HEIGHT =16><IMG SRC="../assets/images/dot_clear.gif" WIDTH =20 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=520><IMG SRC="../assets/images/dot_clear.gif" WIDTH =520 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=100><IMG SRC="../assets/images/dot_clear.gif" WIDTH =100 HEIGHT =1 BORDER=0></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =9></TD>
	<TD WIDTH=520 ALIGN="left" VALIGN="top"></TD>
	<TD></TD>
   </TR>
  </TABLE>

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=640>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=20 HEIGHT =11><IMG SRC="../assets/images/dot_clear.gif" WIDTH =20 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=540><IMG SRC="../assets/images/dot_clear.gif" WIDTH =540 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=80><IMG SRC="../assets/images/dot_clear.gif" WIDTH =80 HEIGHT =1 BORDER=0></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=540><P><B><FONT SIZE="+1">Add New Category</B></FONT></TD>

	<TD></TD>
   </TR>
  </TABLE>
<TABLE CELLPADDING=0 CELLSPACING=0 BORDER=0 WIDTH=640>
<TR VALIGN="top" ALIGN="left">
<TD>

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=200>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=20 HEIGHT =13><IMG SRC="../assets/images/dot_clear.gif" WIDTH =20 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=46><IMG SRC="../assets/images/dot_clear.gif" WIDTH =46 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=134><IMG SRC="../assets/images/dot_clear.gif" WIDTH =134 HEIGHT =1 BORDER=0></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=180 COLSPAN=2><P>Category Name</TD>

   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=3 HEIGHT =26></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=180 COLSPAN=2><P>Parent Category</TD>

   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=3 HEIGHT =20></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =24></TD>
	<TD WIDTH=46><INPUT TYPE="submit" NAME="Add" VALUE="Add" ></TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=3 HEIGHT =96></TD>
   </TR>
  </TABLE>
</TD>
<TD>

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=440>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=20 HEIGHT =13><IMG SRC="../assets/images/dot_clear.gif" WIDTH =20 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=134><IMG SRC="../assets/images/dot_clear.gif" WIDTH =134 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=186><IMG SRC="../assets/images/dot_clear.gif" WIDTH =186 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=100><IMG SRC="../assets/images/dot_clear.gif" WIDTH =100 HEIGHT =1 BORDER=0></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =22></TD>
	<TD WIDTH=320 COLSPAN=2><INPUT TYPE="text" NAME="CategoryName" VALUE="" SIZE=40 MAXLENGTH=50 ></TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=4 HEIGHT =24></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =24></TD>
	<TD WIDTH=134><SELECT NAME="ParentCategory" ><OPTION VALUE="Top Level" SELECTED>Top Level</OPTION>
<%
Do Until RSCategories.EOF
%>	
	<OPTION VALUE="<% response.write RSCategories("CategoryName") %>"><% response.write RSCategories("CategoryName") %></OPTION>
<%
	RSCategories.MoveNext
Loop
%>		
	</SELECT></TD>
	<TD COLSPAN=2></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=4 HEIGHT =136></TD>
   </TR>
  </TABLE>
</TD>
</TR>
</TABLE>

 </FORM></BODY>
</HTML>
