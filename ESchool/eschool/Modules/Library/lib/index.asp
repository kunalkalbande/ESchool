<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 3.2//EN"> <!-- #INCLUDE FILE="con1.asp" -->
<HTML>
	<HEAD>
		<TITLE>Log In</TITLE>
		<%Dim conn
if NOT isempty(Request.Form("OK")) then

Set conn= Server.CreateObject( "ADODB.Connection" )
conn.Open connectionstring 

	'set conn = server.createobject ("adodb.connection")
	'conn.open "ASPBook", "sa", "yourpassword"
	set RSFindEmp = conn.Execute("select EmpID, Manager from LibEmps where " _
	& "EmailAddress = '" & Request.Form("EmailAddress") & "' and " _
	& "Password = '" & Request.Form("Password") & "'")
	if RSFindEmp.EOF then
		TheMessage = "Invalid email address or password."
	else
		Session("EmpID") = RSFindEmp("EmpID")
		Session("Manager") = RSFindEmp("Manager")
		Response.Redirect "./html/library_menu.asp"
	end if	
else
	TheMessage = "Please use this page to log in to the Library."
end if

%>
		<META NAME="Generator" CONTENT="Microsoft FrontPage 4.0">
		<LINK href="../../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY BACKGROUND="../../images/home.gif" LINK="#0000ff" VLINK="#800080" TEXT="#000000" onload="if((navigator.appName=='Netscape') &amp;&amp; (navigator.appVersion.charAt(0)=='3') &amp;&amp; (navigator.appVersion.indexOf('Win')+navigator.appVersion.indexOf('Mac')!=-2)) document.bgColor=document.bgColor;">
		<script type='text/javascript' src='g22_var.js'></script>
		<script type='text/javascript' src='menu81_com.js'></script>
		<BR>
		<BR>
		<FORM ACTION="./index.asp" METHOD="post">
			<br>
			<BR>
			<BR>
			<BR>
			<BR>
			<TABLE BORDER="0" CELLSPACING="0" CELLPADDING="0" WIDTH="650">
				<TR VALIGN="top" ALIGN="left">
					<TD WIDTH="20" HEIGHT="20">
						<p align="left"><IMG SRC="./assets/images/dot_clear.gif" WIDTH="20" HEIGHT="1" BORDER="0"></p>
					</TD>
					<TD WIDTH="582">
						<p align="left"><IMG SRC="./assets/images/dot_clear.gif" WIDTH="582" HEIGHT="1" BORDER="0"></p>
					</TD>
					<TD WIDTH="48">
						<p align="left"><IMG SRC="./assets/images/dot_clear.gif" WIDTH="48" HEIGHT="1" BORDER="0"></p>
					</TD>
				</TR>
				<TR VALIGN="top" ALIGN="left">
					<TD HEIGHT="40">
						<p align="left"></p>
					</TD>
					<TD WIDTH="582">
						<p align="center">&nbsp;</p>
						<p align="center"><font color="#800000" size="5">Log&nbsp; In</font></p>
					</TD>
					<TD>
						<p align="left"></p>
					</TD>
				</TR>
			</TABLE>
			<TABLE BORDER="0" CELLSPACING="0" CELLPADDING="0" WIDTH="650">
				<TR VALIGN="top" ALIGN="left">
					<TD WIDTH="20" HEIGHT="20">
						<p align="left"><IMG SRC="./assets/images/dot_clear.gif" WIDTH="20" HEIGHT="1" BORDER="0"><a href="../../Form/Menu.aspx">Home</a></p>
					</TD>
					<TD WIDTH="540">
						<p align="left"><IMG SRC="./assets/images/dot_clear.gif" WIDTH="540" HEIGHT="1" BORDER="0"></p>
					</TD>
					<TD WIDTH="90">
						<p align="left"><IMG SRC="./assets/images/dot_clear.gif" WIDTH="90" HEIGHT="1" BORDER="0"></p>
					</TD>
				</TR>
				<TR VALIGN="top" ALIGN="left">
					<TD>
						<p align="left"></p>
					</TD>
					<TD WIDTH="540"><P align="left"><B><FONT SIZE="+1"><% response.write TheMessage %></B></FONT></P>
					</TD>
					<TD>
						<p align="left"></p>
					</TD>
				</TR>
			</TABLE>
			<TABLE BORDER="0" CELLSPACING="0" CELLPADDING="0" WIDTH="650">
				<TR VALIGN="top" ALIGN="left">
					<TD WIDTH="20" HEIGHT="19">
						<p align="left"><IMG SRC="./assets/images/dot_clear.gif" WIDTH="20" HEIGHT="1" BORDER="0"></p>
					</TD>
					<TD WIDTH="520">
						<p align="left"><IMG SRC="./assets/images/dot_clear.gif" WIDTH="520" HEIGHT="1" BORDER="0"></p>
					</TD>
					<TD WIDTH="110">
						<p align="left"><IMG SRC="./assets/images/dot_clear.gif" WIDTH="110" HEIGHT="1" BORDER="0"></p>
					</TD>
				</TR>
				<TR VALIGN="top" ALIGN="left">
					<TD HEIGHT="9">
						<p align="left"></p>
					</TD>
					<TD WIDTH="520" ALIGN="left" VALIGN="top">
						<p align="left"></p>
					</TD>
					<TD>
						<p align="left"></p>
					</TD>
				</TR>
			</TABLE>
			<TABLE CELLPADDING="0" CELLSPACING="0" BORDER="0" WIDTH="650">
				<TR VALIGN="top" ALIGN="left">
					<TD>
						<TABLE BORDER="0" CELLSPACING="0" CELLPADDING="0" WIDTH="200">
							<TR VALIGN="top" ALIGN="left">
								<TD WIDTH="20" HEIGHT="31">
									<p align="left"><IMG SRC="./assets/images/dot_clear.gif" WIDTH="20" HEIGHT="1" BORDER="0"></p>
								</TD>
								<TD WIDTH="1">
									<p align="left"><IMG SRC="./assets/images/dot_clear.gif" WIDTH="1" HEIGHT="1" BORDER="0"></p>
								</TD>
								<TD WIDTH="36">
									<p align="left"><IMG SRC="./assets/images/dot_clear.gif" WIDTH="36" HEIGHT="1" BORDER="0"></p>
								</TD>
								<TD WIDTH="143">
									<p align="left"><IMG SRC="./assets/images/dot_clear.gif" WIDTH="143" HEIGHT="1" BORDER="0"></p>
								</TD>
							</TR>
							<TR VALIGN="top" ALIGN="left">
								<TD>
									<p align="left"></p>
								</TD>
								<TD WIDTH="180" COLSPAN="3"><P align="left">Email Address</P>
								</TD>
							</TR>
							<TR VALIGN="top" ALIGN="left">
								<TD COLSPAN="4" HEIGHT="20">
									<p align="left"></p>
								</TD>
							</TR>
							<TR VALIGN="top" ALIGN="left">
								<TD>
									<p align="left"></p>
								</TD>
								<TD WIDTH="180" COLSPAN="3"><P align="left">Password</P>
								</TD>
							</TR>
							<TR VALIGN="top" ALIGN="left">
								<TD COLSPAN="4" HEIGHT="27">
									<p align="left"></p>
								</TD>
							</TR>
							<TR VALIGN="top" ALIGN="left">
								<TD COLSPAN="2" HEIGHT="24">
									<p align="left"></p>
								</TD>
								<TD WIDTH="36">
									<p align="left"><INPUT TYPE="submit" NAME="OK" VALUE="OK"></p>
								</TD>
								<TD>
									<p align="left"></p>
								</TD>
							</TR>
							<TR VALIGN="top" ALIGN="left">
								<TD COLSPAN="4" HEIGHT="629" align="right">
									<p align="left"></p>
								</TD>
							</TR>
						</TABLE>
					</TD>
					<TD>
						<TABLE BORDER="0" CELLSPACING="0" CELLPADDING="0" WIDTH="450">
							<TR VALIGN="top" ALIGN="left">
								<TD WIDTH="14" HEIGHT="32">
									<p align="left"><IMG SRC="./assets/images/dot_clear.gif" WIDTH="14" HEIGHT="1" BORDER="0"></p>
								</TD>
								<TD WIDTH="320">
									<p align="left"><IMG SRC="./assets/images/dot_clear.gif" WIDTH="320" HEIGHT="1" BORDER="0"></p>
								</TD>
								<TD WIDTH="116">
									<p align="left"><IMG SRC="./assets/images/dot_clear.gif" WIDTH="116" HEIGHT="1" BORDER="0"></p>
								</TD>
							</TR>
							<TR VALIGN="top" ALIGN="left">
								<TD HEIGHT="22">
									<p align="left"></p>
								</TD>
								<TD WIDTH="320">
									<p align="left"><INPUT TYPE="text" NAME="EmailAddress" SIZE="40" MAXLENGTH="50"></p>
								</TD>
								<TD>
									<p align="left"></p>
								</TD>
							</TR>
							<TR VALIGN="top" ALIGN="left">
								<TD COLSPAN="3" HEIGHT="18">
									<p align="left"></p>
								</TD>
							</TR>
							<TR VALIGN="top" ALIGN="left">
								<TD HEIGHT="22">
									<p align="left"></p>
								</TD>
								<TD WIDTH="320">
									<p align="left"><INPUT TYPE="password" NAME="Password" SIZE="40" MAXLENGTH="50"></p>
								</TD>
								<TD>
									<p align="left"></p>
								</TD>
							</TR>
							<TR VALIGN="top" ALIGN="left">
								<TD COLSPAN="3" HEIGHT="677">
									<p align="left"></p>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
