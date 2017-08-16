<!-- #INCLUDE FILE="../con1.asp" -->
<%
'if isempty(Session("EmpID")) then
'	Response.Redirect "../index.asp"
'end if	
'if Session("Manager") <> 1 then
'	Response.Redirect "./library_menu.asp"
'end if

dim  pass;
pass=(Session["password"].ToString ());


Set conn= Server.CreateObject( "ADODB.Connection" )
conn.Open connectionstring 


'set conn = server.createobject ("adodb.connection")
'conn.open "ASPBook", "sa", "yourpassword"
if NOT isempty(Request.Form("OK")) then
	conn.Execute "insert into LibBooks (Title, Author, Subject, ISBN, Keywords, Status, " _
		& "Description) values (" _
		& "'" & Request.Form("Title") & "', " _
		& "'" & Request.Form("Author") & "', " _
		& "'" & Request.Form("Subject") & "', " _
		& "'" & Request.Form("ISBN") & "', " _
		& "'" & Request.Form("Keywords") & "', " _
		& "'" & Request.Form("Status") & "', " _
		& "'" & Request.Form("Description") & "')"
	Response.Redirect "./management_menu.asp"
end if
set RSCategories = conn.Execute("select CategoryName from LibCategories order by CategoryName")

%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 3.2//EN">

<HTML>
<HEAD>
<TITLE>Add Book</TITLE>
<META NAME="Generator" CONTENT="Microsoft FrontPage 4.0">

</HEAD>

<BODY BACKGROUND="../../../images/maineschoolimage.jpg" LINK="#0000FF" VLINK="#800080" TEXT="#000000" onload="if((navigator.appName=='Netscape') && (navigator.appVersion.charAt(0)=='3') && (navigator.appVersion.indexOf('Win')+navigator.appVersion.indexOf('Mac')!=-2)) document.bgColor=document.bgColor;"  >
	<script type='text/javascript' src='g22_var.js'></script>
	<script type='text/javascript' src='menu81_com.js'></script>

<FORM ACTION="./add_book.asp"  METHOD=POST style="float: right">

  <div align="right">

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=640 ALIGN="right>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=18 HEIGHT =23><IMG SRC="../assets/images/dot_clear.gif" WIDTH =18 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=582>&nbsp;
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p><IMG SRC="../assets/images/dot_clear.gif" WIDTH =582 HEIGHT =1 BORDER=0></p>
    </TD>
	<TD WIDTH=40><IMG SRC="../assets/images/dot_clear.gif" WIDTH =40 HEIGHT =1 BORDER=0></TD>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =40></TD>
	<TD WIDTH=582>
      <p align="center"><font color="#800000"><b>ADD Book</b></font></p>
    </TD>
	<TD></TD>
   </TR>
  </TABLE>

  </div>
  <div align="left">

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=640 ALIGN="right>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=20 HEIGHT =17><IMG SRC="../assets/images/dot_clear.gif" WIDTH =20 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=540><IMG SRC="../assets/images/dot_clear.gif" WIDTH =540 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=80><IMG SRC="../assets/images/dot_clear.gif" WIDTH =80 HEIGHT =1 BORDER=0></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD></TD>
	<TD WIDTH=540><P align="left"><B><FONT SIZE="+1">Complete Each Field</B></FONT></TD>

	<TD><a href="library_menu.asp">Home</a></TD>
   </TR>
  </TABLE>

  </div>

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=640 ALIGN="right>
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
<TABLE CELLPADDING=0 CELLSPACING=0 BORDER=0 WIDTH=468 ALIGN="right>
<TR VALIGN="top" ALIGN="left">
<TD width="159">

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=153 ALIGN="right>
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
	<TD></TD>
	<TD WIDTH=133 COLSPAN=2><P>Status</TD>

   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=3 HEIGHT =14></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =24></TD>
	<TD WIDTH=36><INPUT TYPE="submit" NAME="OK" VALUE="OK" ></TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=3 HEIGHT =162></TD>
   </TR>
  </TABLE>
</TD>
<TD width="746">

  <TABLE BORDER=0 CELLSPACING=0 CELLPADDING=0 WIDTH=487 ALIGN="right>
   <TR VALIGN="top" ALIGN="left">
	<TD WIDTH=27 HEIGHT =11><IMG SRC="../assets/images/dot_clear.gif" WIDTH =27 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=1><IMG SRC="../assets/images/dot_clear.gif" WIDTH =1 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=104><IMG SRC="../assets/images/dot_clear.gif" WIDTH =104 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=12><IMG SRC="../assets/images/dot_clear.gif" WIDTH =12 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=203><IMG SRC="../assets/images/dot_clear.gif" WIDTH =203 HEIGHT =1 BORDER=0></TD>
	<TD WIDTH=140><IMG SRC="../assets/images/dot_clear.gif" WIDTH =140 HEIGHT =1 BORDER=0></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =22></TD>
	<TD WIDTH=320 COLSPAN=4><INPUT TYPE="text" NAME="Title" VALUE="" SIZE=40 MAXLENGTH=100 ></TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=6 HEIGHT =18></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =22></TD>
	<TD WIDTH=320 COLSPAN=4><INPUT TYPE="text" NAME="Author" VALUE="" SIZE=40 MAXLENGTH=100 ></TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=6 HEIGHT =19></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=2 HEIGHT =24></TD>
	<TD WIDTH=116 COLSPAN=2><SELECT NAME="Subject" >
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
	<TD COLSPAN=6 HEIGHT =15></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =22></TD>
	<TD WIDTH=320 COLSPAN=4><INPUT TYPE="text" NAME="ISBN" VALUE="" SIZE=40 MAXLENGTH=100 ></TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=6 HEIGHT =18></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =22></TD>
	<TD WIDTH=320 COLSPAN=4><INPUT TYPE="text" NAME="Keywords" VALUE="" SIZE=40 MAXLENGTH=100 ></TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=6 HEIGHT =18></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD HEIGHT =22></TD>
	<TD WIDTH=320 COLSPAN=4><INPUT TYPE="text" NAME="Description" VALUE="" SIZE=40 MAXLENGTH=100 ></TD>
	<TD></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=6 HEIGHT =19></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=2 HEIGHT =24></TD>
	<TD WIDTH=104><SELECT NAME="Status" ><OPTION VALUE="Available" SELECTED>Available</OPTION><OPTION VALUE="Checked Out">Checked Out</OPTION></SELECT></TD>
	<TD COLSPAN=3></TD>
   </TR>
   <TR VALIGN="top" ALIGN="left">
	<TD COLSPAN=6 HEIGHT =195></TD>
   </TR>
  </TABLE>
</TD>
</TR>
</TABLE>

 </FORM></BODY>
</HTML>



