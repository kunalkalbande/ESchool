<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="Classwisesubjects.aspx.cs" AutoEventWireup="false" Inherits="eschool.Classwisesubjects" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Class Wise Subject Insertion</title><!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Subject(dropdown)
		{
			var SubjectArray= new Array();
			SubjectArray[0]=document.Classwisesujects.Dropsub1.options[document.Classwisesujects.Dropsub1.selectedIndex].text
			SubjectArray[1]=document.Classwisesujects.Dropsub2.options[document.Classwisesujects.Dropsub2.selectedIndex].text
			SubjectArray[2]=document.Classwisesujects.Dropsub3.options[document.Classwisesujects.Dropsub3.selectedIndex].text
			SubjectArray[3]=document.Classwisesujects.Dropsub4.options[document.Classwisesujects.Dropsub4.selectedIndex].text
			SubjectArray[4]=document.Classwisesujects.Dropsub5.options[document.Classwisesujects.Dropsub5.selectedIndex].text
			SubjectArray[5]=document.Classwisesujects.Dropsub6.options[document.Classwisesujects.Dropsub6.selectedIndex].text
			SubjectArray[6]=document.Classwisesujects.Dropsub7.options[document.Classwisesujects.Dropsub7.selectedIndex].text
			SubjectArray[7]=document.Classwisesujects.Dropsub8.options[document.Classwisesujects.Dropsub8.selectedIndex].text
			
			var count = 0;
			for (var i=0;i<8;i++)
			{
				for (var j=0;j<8;j++)
				{
					if(SubjectArray[i]==SubjectArray[j] && SubjectArray[i]!="---Select---")
					{
						count=count+1;
						if(count>1)
						{
							alert("Subject Already Selected!");
							dropdown.selectedIndex = 0;
							return false;
						}
					}
					else
						continue;	
				}
				count = 0;
			}
			return true;
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 101; LEFT: 136px; POSITION: absolute; TOP: 16px" runat="server"
				Visible="False" Width="8px"></asp:textbox>
			<table height="250" width="778" align="center">
				<TR>
					<TH align="center">
					</TH>
				</TR>
				<tr>
					<td align="center"><b>CLASS WISE SUBJECT INSERTION</b>
						<TABLE cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<TBODY>
								<asp:panel id="panclswiseid" Runat="server">
									<TR>
										<TD colSpan="3">&nbsp;Assigned Subjects&nbsp;&nbsp;
											<asp:DropDownList id="dropClassWiseSubject" Width="120" Runat="server" AutoPostBack="True" CssClass="ComboBox"></asp:DropDownList></TD>
									</TR>
								</asp:panel>
								<TR>
									<TD colSpan="3" align="left">&nbsp;Class&nbsp;Name <FONT color="red" size="1">*</FONT>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:dropdownlist id="DropClass" CssClass="ComboBox" runat="server">
											<asp:ListItem Value="Select">Select</asp:ListItem>
										</asp:dropdownlist><asp:comparevalidator id="cvShiftName" runat="server" ValueToCompare="Select" Operator="NotEqual" ControlToValidate="DropClass"
											ErrorMessage="Please select the Class name">*</asp:comparevalidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Stream&nbsp;&nbsp;<asp:dropdownlist id="DropStream" CssClass="ComboBox" Runat="server">
											<asp:ListItem Value="None">None</asp:ListItem>
											<asp:ListItem Value="Math Group">Math Group</asp:ListItem>
											<asp:ListItem Value="Bio Group">Bio Group</asp:ListItem>
											<asp:ListItem Value="Commerce Group">Commerce Group</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD align="center" colspan="3"><FONT color="black"><b>Subjects&nbsp;Available</b></FONT>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT color="black"><b>Subjects&nbsp;Assigned</b>
											<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please Assign The Subject"
												ControlToValidate="ListSubjestAssigned">*</asp:RequiredFieldValidator></FONT></TD>
								</TR>
								<TR>
									<TD align="center"><asp:listbox id="ListSubjectAvailable" CssClass="ComboBox" runat="server" Width="160px" Height="180px"></asp:listbox></TD>
									<TD align="center">
										<P><asp:button id="btnIn" runat="server" Width="50px" CssClass="formbuttonstyle" Font-Bold="True"
												Text=">" CausesValidation="False" ForeColor="Black" ToolTip="Move selected items from available employee list to employee assigned list"></asp:button></P>
										<p><asp:button id="btnedit" runat="server" CssClass="formbuttonstyle" Text="Edit" CausesValidation="False"
												ForeColor="Black" width="50px"></asp:button></p>
										<P dir="ltr" align="justify"><asp:button id="btnout" runat="server" Width="50px" CssClass="formbuttonstyle" Font-Bold="True"
												Text="<" CausesValidation="False" ForeColor="Black" ToolTip="Move selected items from employee assigned list to available employee list "></asp:button></P>
										<P>&nbsp;</P>
									</TD>
									<TD align="center"><asp:listbox id="ListSubjestAssigned" CssClass="ComboBox" runat="server" Width="160px" Height="180px"></asp:listbox></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3"><asp:button id="btnSubmit" runat="server" Width="78px" CssClass="formbuttonstyle" Text="Submit"
											ForeColor="Black"></asp:button><asp:validationsummary id="vsShiftAssignment" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
								</TR>
							</TBODY>
						</TABLE>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
