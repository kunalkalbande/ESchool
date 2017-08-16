<%@ Page language="c#" Codebehind="Routeedit.aspx.cs" AutoEventWireup="false" Inherits="eschool.Logistics.Routeedit" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Route Master</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="True" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		
		//this method use to show route information save in hidden text box.
		function Showval(t)
		{
			var ind=t.selectedIndex
			var val=t.options[ind].value
			val=val.substring(val.indexOf(':')+1,val.length)
			var totdata=document.Routeedit.temproutdata.value
			//alert(totdata)
			var splitrow=new Array()
			var splitfeild=new Array()
			splitrow=totdata.split(',')
			for(var i=0;i<splitrow.length-1;i++)
			{
				var	temp=splitrow[i]
				splitfeild=temp.split(';')
				if(val==splitfeild[0])
				{
					document.Routeedit.txtrname.value=splitfeild[1]
					document.Routeedit.txtrkm.value=splitfeild[2]
					document.Routeedit.txttrfee.value=splitfeild[3]
					document.Routeedit.Txtfromdate.value=splitfeild[4]
					document.Routeedit.Txttodate.value=splitfeild[5]
					document.Routeedit.tempold.value=splitfeild[1]
				}
		   }
		   if(ind==0)
		   {
				var date=new Date()
				var dateformate=new Array()
				//var d=(date.getMonth()+1)+"/"+date.getDate()+"/"+date.getFullYear();
				var d=date.getDate()+"/"+(date.getMonth()+1)+"/"+date.getFullYear();
				document.Routeedit.txtrname.value=""
				document.Routeedit.txtrkm.value=""
				document.Routeedit.txttrfee.value=""
				document.Routeedit.Txtfromdate.value=d
				document.Routeedit.Txttodate.value=d
				document.Routeedit.Button1.value="Add"
		   }
		   else
		   {
				document.Routeedit.Button1.value="Update"
		   }
		}
		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Routeedit" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td align="center"><asp:label id="Label1" runat="server" Font-Bold="True"></asp:label><input id="temproutdata" type="hidden" name="temproutdata" runat="server">
						<input id="tempval" type="hidden" name="tempval" runat="server"> <input id="tempold" type="hidden" name="tempold" runat="server"></td>
				</tr>
				<tr>
					<td vAlign="top" align="center"><B>ROUTE MASTER</B>
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<TBODY>
								<tr>
									<td colSpan="2"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></td>
								</tr>
								<TR>
									<TD>&nbsp;Route Name</TD>
									<TD><asp:dropdownlist id="DropDownList1" runat="server" Width="200px" CssClass="ComboBox" onchange="Showval(this)"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD>&nbsp;Route Name&nbsp;<font color="red" size="1">*</font></TD>
									<TD><asp:textbox onkeypress="return GetAnyNumber(this, event);" id="txtrname" runat="server" Width="200px"
											CssClass="TextBoxForms" MaxLength="30"></asp:textbox><asp:requiredfieldvalidator id="reqvali1" ErrorMessage="Please Enter Route Name" ControlToValidate="txtrname"
											Runat="server">*</asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;Route No&nbsp;<font color="red" size="1">*</font></TD>
									<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id="txtrkm" runat="server"
											Width="200px" CssClass="TextBoxForms" MaxLength="10"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" ErrorMessage="Please Enter Route No" ControlToValidate="txtrkm"
											Runat="server">*</asp:requiredfieldvalidator></TD>
								</TR>
					</td>
				<tr>
					<td>&nbsp;Transport Fee&nbsp;<font color="red" size="1">*</font></td>
					<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id="txttrfee" Width="200px"
							CssClass="TextBoxForms" MaxLength="10" Runat="server"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator2" ErrorMessage="Please Enter Transport fee" ControlToValidate="txttrfee"
							Runat="server">*</asp:requiredfieldvalidator></td>
				</tr>
				<tr>
					<TD>&nbsp;Duration From
					</TD>
					<TD><asp:textbox id="Txtfromdate" BorderStyle="Groove" runat="server" Width="70px" CssClass="Fontstyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Routeedit.Txtfromdate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
								border="0"></A></TD>
				</tr>
				<TR>
					<TD>&nbsp;To</TD>
					<TD><asp:textbox id="Txttodate" BorderStyle="Groove" runat="server" Width="70px" CssClass="Fontstyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Routeedit.Txttodate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
								border="0"></A></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px" align="center" colSpan="6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="Button1" runat="server" CssClass="formbuttonstyle" Text="Add "></asp:button>
						<asp:button id="btnsave" runat="server" CssClass="formbuttonstyle" Text="Update"></asp:button>&nbsp;&nbsp;<asp:button id="btnEdit" runat="server" CssClass="formbuttonstyle" Text="Edit  " Visible="False"></asp:button>&nbsp;&nbsp;<asp:button id="btnDel" runat="server" CssClass="formbuttonstyle" Text="Delete"></asp:button>
						<asp:validationsummary id="vsRoute" runat="server" Width="158px" ShowMessageBox="True" ShowSummary="False"
							Height="32px"></asp:validationsummary></TD>
				</TR>
			</table>
			</TD></TR></TBODY></TABLE><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no"
				height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
