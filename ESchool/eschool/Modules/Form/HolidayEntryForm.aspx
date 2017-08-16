<!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
<%@ Page language="c#" Codebehind="HolidayEntryForm.aspx.cs" AutoEventWireup="false" Inherits="eschool.Forms.HolidayEntryForm" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/Header2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>HolidayEntryForm</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="HolidayEntryForm" method="post" runat="server">
			<uc1:header id="Header2" runat="server"></uc1:header>
			<table height="278" width="778" align="center">
				<tr>
					<td colSpan="3"></td>
				</tr>
				<tr>
					<td>
					<td vAlign="middle" align="center"><FONT color="#ff0033" size="5">&nbsp; </FONT>
						<table width="60%" align="center">
							<tr>
								<td align="center">
									<P align="center"><FONT color="#ff0033" size="5"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="4">&nbsp; 
													Your Session Has&nbsp; Been Expired&nbsp;</FONT></STRONG></FONT></P>
									<P align="center"><FONT color="#ff0033" size="5"><STRONG><FONT size="4">Please Login Again </FONT>
											</STRONG></FONT>
									</P>
									<A href="../../LoginHome/Login.aspx"><STRONG><FONT size="4"><FONT color="#0000ff">Login</FONT>:</FONT></STRONG></A>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
