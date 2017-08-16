<%@ Page language="c#" Codebehind="BackupRestore.aspx.cs" AutoEventWireup="false" Inherits="Eschool.BackupRestore" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Backup & Restore</title>
		<script language="javascript">
	/*function Check(t)
	{
		
		if(t.value!="")
		{
			//alert(t.value.indexOf(".LDF"));
			if(t.value.indexOf(".LDF")>0)
			{
				document.Form1.btnRestore.disabled=false;
			}
			else
			{
				alert("Please Select Appropriate '.LDF' File");
				document.Form1.btnRestore.disabled=true;
				return;
			}
		}
		else
		{
			alert("Please Select The 'LDF' File");
			document.Form1.btnRestore.disabled=false;
			return;
		}
	}*/
	
	// this method use to check if selected file .bak then restore button enabled else desabled.
	function Check(t)
	{
		var str=t.value
		if(t.value!="" && str.indexOf(".")>0)
		{
			str=str.substring(0,str.indexOf("."));
			//if(t.value.indexOf(".LDF")>0)
			if(t.value.toLowerCase().indexOf(".bak")>0)
			{
				document.Form1.btnRestore.disabled=false;
				document.Form1.tempPath.value=str;
			}
			else
			{
				alert("Please Select Appropriate '.bak' File");
				document.Form1.btnRestore.disabled=true;
				return;
			}
		}
		else
		{
			//alert("Please Select The 'LDF' File");
			alert("Please Select The 'bak' File");
			document.Form1.btnRestore.disabled=false;
			return;
		}
	}
	
	//var count=0;
	// this method use to show if work is proccessing then lable is visible.
	function Progressbar()
	{
		document.Form1.lblPro.style.visibility="visible"
		document.Form1.lblPro.style.font.bold=true
	}
		</script> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server" DESIGNTIMEDRAGDROP="11"></uc1:header>
			<input type="hidden" id="tempPath" name="tempPath" runat="server">
			<table height="250" width="718" align="center">
				<tr>
					<td align="center">
				<!--P align="left"><FONT color="red" size="3"><FONT size="2"><STRONG><FONT color="#000000"><U><FONT color="#ff0000">Note</FONT></U></FONT><FONT color="#ff0000">:</FONT>
									</STRONG><FONT color="#000033">Before Backup&nbsp;or Restore, 
										you&nbsp;must&nbsp;stop the <STRONG>MS-SQL Server</STRONG>.</FONT></FONT>&nbsp;&nbsp;
								<FONT color="#000033" size="2">To Stop <STRONG>MS_SQL Server,</STRONG>&nbsp;click 
									on <STRONG>Start</STRONG>&nbsp; ---&gt; &nbsp; <STRONG>Programs&nbsp; </STRONG>---&gt;&nbsp;&nbsp;
									<STRONG>Microsoft SQL Server 2005</STRONG>&nbsp; ---&gt; <STRONG>Configuration 
										Tools</STRONG> ---&gt; <STRONG>SQL Server Configuration Manager </STRONG>--&gt;<STRONG>SQL 
										Server 2005 Services</STRONG> &amp; right click on <STRONG>SQL Server 
										(SQLEXPRESS)</STRONG></FONT> <FONT color="#000033" size="2">and click on <STRONG>
										Stop</STRONG>wait for a minute. After Backup or Restore, you must start the <STRONG>
										MS_SQL Server</STRONG>. To start <STRONG>MS_SQL Server</STRONG> , follow 
									the same steps as given above but in last step&nbsp;click on <STRONG>Start</STRONG>
									and wait for a minute.</FONT>
						</P-->
				<tr>
					<td>
					</td>
				</tr>
				</td>
				<TR>
					<td>
						<p align="center"><input type="button" NAME="lblPro" style="BORDER-RIGHT: palegoldenrod thin; TABLE-LAYOUT: auto; BORDER-TOP: palegoldenrod thin; DISPLAY: block; FONT-WEIGHT: bold; VISIBILITY: hidden; BORDER-LEFT: palegoldenrod thin; WIDTH: 200px; CURSOR: wait; COLOR: firebrick; DIRECTION: ltr; TEXT-INDENT: 25px; BORDER-BOTTOM: palegoldenrod thin; BORDER-COLLAPSE: collapse; HEIGHT: 30px; BACKGROUND-COLOR: palegoldenrod"
								value="Processing Please Wait..."></p>
						<P align="center"><!--FONT color=#ff0000 size=3 
      >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
      </FONT--><FONT size="5"><INPUT id="ff1" style="BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
									type="file" onchange="Check(this);" size="40" name="ff1">
								<asp:button id="btnBackup" runat="server" Height="22px" CssClass="formbuttonstyle" Text="Backup"></asp:button>
								<asp:button id="btnRestore" runat="server" Height="22px" CssClass="formbuttonstyle" Text="Restore"></asp:button></FONT></P>
						<FONT size="2"><FONT color="black" size="1">
						
								<!--P align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<STRONG><U>Remark:</U></STRONG>
								&nbsp;&nbsp;The 
									backup process stores the copy of your data&nbsp;in the home drive in a folder <STRONG>
										eSchoolBackup</STRONG>.&nbsp;&nbsp;
									<br>
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For 
								example if your home drive is C: then your backup is copied in C:\eSchoolBackup 
								folder.&nbsp;</FONT></P--> </FONT></FONT>
					</td>
					</FONT></FONT></TR><tr><td><P align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<STRONG><U>Remark:</U></STRONG>
								&nbsp;&nbsp;The 
									backup process stores the copy of your data&nbsp;in the home drive in a folder <STRONG>
										eSchoolBackup</STRONG>.&nbsp;&nbsp;
									<br>
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For 
								example if your home drive is C: then your backup is copied in C:\eSchoolBackup 
								folder.&nbsp;</FONT></P></td></tr>
				</TD></tr></table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
