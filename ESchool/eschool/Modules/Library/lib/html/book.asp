<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 3.2//EN"> <!-- #INCLUDE FILE="../con1.asp" -->
<HTML>
	<HEAD>
		<TITLE>Book</TITLE>
		<%
		
	 dim pass;
     pass=(Session["password"].ToString ());
	
		 
		 Response.write pass
'if isempty(Session("EmpID")) then
'	Response.Redirect "../index.asp"
'end if	
if isempty(Request.QueryString("BookID")) then
	Response.Redirect "./search.html"
end if

Set conn= Server.CreateObject( "ADODB.Connection" )
conn.Open connectionstring 

'set conn = server.createobject ("adodb.connection")
'conn.open "ASPBook", "sa", "yourpassword"

Response.write (Session("password"))

if Not isempty(Request.QueryString("Action")) then
	conn.Execute "update LibBooks set Status = 'Checked Out', " _
		& "CheckedOutTo = " & Session("password") & " where BookID = " _
		& Request.QueryString("BookID")
	Response.Redirect "./library_menu.asp"
end if


'if Not isempty(Request.QueryString("Action")) then
'	conn.Execute "update LibBooks set Status = 'Checked Out', " _
'		& "CheckedOutTo = " & Session("EmpID") & " where BookID = " _
'		& Request.QueryString("BookID")
'	Response.Redirect "./library_menu.asp"
'end if



Set RSBooks = conn.Execute("select * from LibBooks where " _
	& "BookID = " & Request.QueryString ("BookID"))
if RSBooks("Status") = "Available" then
	LinkText = "<A HREF=""../html/book.asp?Action=CheckOut&BookID=" _
		& Request.QueryString("BookID") & """>Check this book out.</A>"
else
	LinkText = "<A HREF=""../html/library_menu.asp"">Book not available. Back to menu.</A>"
end if
%>
		<META NAME="Generator" CONTENT="Microsoft FrontPage 4.0">
		<LINK href="../../../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY BACKGROUND="../../../images/maineschoolimage.jpg" LINK="#0000ff" VLINK="#800080" TEXT="#000000" onload="if((navigator.appName=='Netscape') &amp;&amp; (navigator.appVersion.charAt(0)=='3') &amp;&amp; (navigator.appVersion.indexOf('Win')+navigator.appVersion.indexOf('Mac')!=-2)) document.bgColor=document.bgColor;">
			<script type='text/javascript' src='g22_var.js'></script>
		<script type='text/javascript' src='menu81_com.js'></script>

		<TABLE BORDER="0" CELLSPACING="0" CELLPADDING="0" WIDTH="640">
			<TR VALIGN="top" ALIGN="left">
				<TD WIDTH="20" HEIGHT="20"><IMG SRC="../assets/images/dot_clear.gif" WIDTH="20" HEIGHT="1" BORDER="0"></TD>
				<TD WIDTH="414"><IMG SRC="../assets/images/dot_clear.gif" WIDTH="414" HEIGHT="1" BORDER="0">
					<p>&nbsp;</p>
					<p>&nbsp;</p>
					<p>&nbsp;</p>
					<p>&nbsp;</p>
				</TD>
				<TD WIDTH="106"><IMG SRC="../assets/images/dot_clear.gif" WIDTH="106" HEIGHT="1" BORDER="0"></TD>
				<TD WIDTH="20"><IMG SRC="../assets/images/dot_clear.gif" WIDTH="20" HEIGHT="1" BORDER="0"></TD>
				<TD WIDTH="42"><IMG SRC="../assets/images/dot_clear.gif" WIDTH="42" HEIGHT="1" BORDER="0"></TD>
				<TD WIDTH="38"><IMG SRC="../assets/images/dot_clear.gif" WIDTH="38" HEIGHT="1" BORDER="0"></TD>
			</TR>
			<TR VALIGN="top" ALIGN="left">
				<TD HEIGHT="40"></TD>
				<TD WIDTH="582" COLSPAN="4">
					<p align="center"><font size="4" color="#800000">Book</font></p>
				</TD>
				<TD></TD>
			</TR>
			<TR VALIGN="top" ALIGN="left">
				<TD COLSPAN="6" HEIGHT="20"></TD>
			</TR>
			<TR VALIGN="top" ALIGN="left">
				<TD></TD>
				<TD WIDTH="540" COLSPAN="3"><P><B><FONT SIZE="+1"><% response.write RSBooks("Title") %></B></FONT></P>
				</TD>
				<TD COLSPAN="2"><a href="library_menu.asp">Home</a></TD>
			</TR>
			<TR VALIGN="top" ALIGN="left">
				<TD COLSPAN="6" HEIGHT="19"></TD>
			</TR>
			<TR VALIGN="top" ALIGN="left">
				<TD HEIGHT="20"></TD>
				<TD WIDTH="582" COLSPAN="4" ALIGN="left" VALIGN="top"></TD>
				<TD></TD>
			</TR>
			<TR VALIGN="top" ALIGN="left">
				<TD></TD>
				<TD WIDTH="520" COLSPAN="2"><P><B>Author:</B>
						<% response.write RSBooks("Author") %>
						<BR>
						<B>Subject:</B>
						<% response.write RSBooks("Subject") %>
						<BR>
						<B>ISBN:</B>
						<% response.write RSBooks("ISBN") %>
						<BR>
						<B>Keywords:</B>
						<% response.write RSBooks("Keywords") %>
						<BR>
						<B>Description:</B>
						<% response.write RSBooks("Description") %>
						<BR>
						<B>Status:</B>
						<% response.write RSBooks("Status") %>
					</P>
				</TD>
				<TD COLSPAN="3"></TD>
			</TR>
			<TR VALIGN="top" ALIGN="left">
				<TD COLSPAN="6" HEIGHT="20"></TD>
			</TR>
			<TR VALIGN="top" ALIGN="left">
				<TD></TD>
				<TD WIDTH="414"><P><A HREF="../html/book.html"><% response.write LinkText %></A></P>
				</TD>
				<TD COLSPAN="4"></TD>
			</TR>
			<TR VALIGN="top" ALIGN="left">
				<TD COLSPAN="6" HEIGHT="300"></TD>
			</TR>
		</TABLE>
	</BODY>
</HTML>
