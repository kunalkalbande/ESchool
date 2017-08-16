<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Page language="c#" Codebehind="FessDecision.aspx.cs" AutoEventWireup="false" Inherits="eschool.StudentFees.FessDecision" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Fees Decision</title> 
		<!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		// this method use to show rank according to category.
		function ShowRank(t,tr)
		{
			var ind=t.selectedIndex
			var Value=t.options[ind].text
			var Catrank=document.FessDecision.tempcatrank.value
			var Cat=Catrank.split(',')
			var rank=new Array()
			var l=0
			tr.length=1
			for(var i=0;i<Cat.length-1;i++)
			{
				rank=Cat[i].split(':')
				var Rank=rank[1]
				if(Value==rank[0])
				{
					l++
					tr.add(new Option)
					tr.options[l].text=Rank
				}
			}
		}
		
		// this method use to assign value in hdden textbox.
		function getrank(t)
		{
		  var ind=t.selectedIndex
		  var value=t.options[ind].text
		  document.FessDecision.temprank.value=value
		  
		}
		</script>
</HEAD>
	<body>
		<form id="FessDecision" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td vAlign="top" align="center"><asp:label id="Label3" runat="server" Font-Bold="True"><B>FEES 
								DECISION</B></asp:label>
						<TABLE align="center" borderColorLight="#663300" border="5">
							<TBODY>
								<TR>
									<TD colSpan="4"><asp:label id="Label4" runat="server" ForeColor="Red">&nbsp;asterisk (*) fields are mandatory</asp:label><input id="tempcatrank" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text"
											name="tempcatrank" runat="server"> <input id="temprank" style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" type="text"
											name="temprank" runat="server"></TD>
								</TR>
								<tr>
									<td>&nbsp;Fees ID</td>
									<td colSpan="3"><asp:dropdownlist id="DropFeeID" AutoPostBack="True" Runat="server" CssClass="ComboBox"></asp:dropdownlist>&nbsp;<asp:label id="lblFeeID" ForeColor="blue" Runat="server"></asp:label>&nbsp;<asp:button id="btnEdtt" Runat="server" CssClass="formeditbuttonstyle" CausesValidation="False"
											Text="..." tooltip="Edit"></asp:button></td>
								</tr>
								<TR>
									<TD vAlign="top" style="HEIGHT: 64px">&nbsp;Student Class&nbsp;<font color="#ff3300" size="1">*</font></TD>
									<TD style="HEIGHT: 64px"><asp:listbox id="DropClass" runat="server" CssClass="ComboBox" Height="72px" SelectionMode="Multiple"
											Rows="1"></asp:listbox>&nbsp;
										<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Atleast One  Class"
											ControlToValidate="DropClass">*</asp:requiredfieldvalidator>&nbsp;</TD>
									<TD style="HEIGHT: 64px">&nbsp;Stream&nbsp;</TD>
									<TD style="HEIGHT: 64px"><asp:dropdownlist id="DropStream" runat="server" AutoPostBack="false" CssClass="ComboBox">
											<asp:ListItem Value="None">None</asp:ListItem>
											<asp:ListItem Value="Bio Group">Bio Group</asp:ListItem>
											<asp:ListItem Value="Commerce Group">Commerce Group</asp:ListItem>
											<asp:ListItem Value="Math Group">Math Group</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<tr>
									<td>&nbsp;Fee Type&nbsp;<font color="#ff3300" size="1">*</font></td>
									<TD><asp:dropdownlist id="Dropfeetype" AutoPostBack="True" Runat="server" CssClass="ComboBox">
											<asp:ListItem Value="Select">Select</asp:ListItem>
											<asp:ListItem Value="Monthly">Monthly</asp:ListItem>
											<asp:ListItem Value="One Time">One Time</asp:ListItem>
											<asp:ListItem Value="Yearly">Yearly</asp:ListItem>
										</asp:dropdownlist><asp:comparevalidator id="Comparevalidator13" runat="server" ErrorMessage="Please select Fee Type" ControlToValidate="Dropfeetype"
											Operator="NotEqual" ValueToCompare="Select">*</asp:comparevalidator></TD>
									<td>&nbsp;SCategory&nbsp;<font color="#ff3300" size="1">*</font></td>
									<td><asp:dropdownlist id="dropscategory" Runat="server" CssClass="ComboBox" onchange="ShowRank(this,document.FessDecision.DropRank)"></asp:dropdownlist><asp:comparevalidator id="Comparevalidator14" runat="server" ErrorMessage="Please select SCategory" ControlToValidate="dropscategory"
											Operator="NotEqual" ValueToCompare="Select">*</asp:comparevalidator><select class="ComboBox" id="DropRank" onchange="getrank(this)" runat="server"><option value="Select" selected>Select</option>
										</select><asp:comparevalidator id="Comparevalidator15" runat="server" ErrorMessage="Please Select Rank" ControlToValidate="DropRank"
											Operator="NotEqual" ValueToCompare="Select">*</asp:comparevalidator></td>
								</tr>
								<asp:panel id="panOneTime" Runat="server">
        <TR>
          <TD>&nbsp;Admission&nbsp;Fees</TD>
          <TD>
<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtadf BorderStyle="Groove" runat="server" CssClass="TextBoxForms" Width="60px" MaxLength="5"></asp:textbox>
<asp:comparevalidator id=Comparevalidator8 Runat="server" ControlToValidate="txtadf" ErrorMessage="Transportation fees must be numeric" Operator="DataTypeCheck" Display="Dynamic" Type="Double">*</asp:comparevalidator></TD>
          <TD>&nbsp;Security&nbsp;Fees</TD>
          <TD>
<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtcmf BorderStyle="Groove" runat="server" CssClass="TextBoxForms" Width="60px" MaxLength="5"></asp:textbox>
<asp:comparevalidator id=Comparevalidator9 Runat="server" ControlToValidate="txtcmf" ErrorMessage="Uniform fees must be numeric" Operator="DataTypeCheck" Display="Dynamic" Type="Double">*</asp:comparevalidator></TD></TR>
								</asp:panel><asp:panel id="panYearly" Runat="server">
        <TR>
          <TD>&nbsp;Diary&nbsp;Fees</TD>
          <TD>
<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtdf BorderStyle="Groove" runat="server" CssClass="TextBoxForms" Width="60px" MaxLength="5"></asp:textbox>
<asp:comparevalidator id=cmppin Runat="server" ControlToValidate="txtdf" ErrorMessage="Development fees must be numeric" Operator="DataTypeCheck" Display="Dynamic" Type="Double">*</asp:comparevalidator></TD>
          <TD>&nbsp;Annual&nbsp;Fees</TD>
          <TD>
<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtanf BorderStyle="Groove" runat="server" CssClass="TextBoxForms" Width="60px" MaxLength="5"></asp:textbox>
<asp:comparevalidator id=Comparevalidator10 Runat="server" ControlToValidate="txtanf" ErrorMessage="Books &amp; Stationary fees must be numeric" Operator="DataTypeCheck" Display="Dynamic" Type="Double">*</asp:comparevalidator></TD></TR>
        <TR>
          <TD>&nbsp;Env.&nbsp;Fees</TD>
          <TD>
<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtef BorderStyle="Groove" runat="server" CssClass="TextBoxForms" Width="60px" MaxLength="5"></asp:textbox>
<asp:comparevalidator id=Comparevalidator11 Runat="server" ControlToValidate="txtef" ErrorMessage="Library fees must be numeric" Operator="DataTypeCheck" Display="Dynamic" Type="Double">*</asp:comparevalidator></TD>
          <TD></TD>
          <TD></TD></TR>
								</asp:panel><asp:panel id="panMonthly" Runat="server">
        <TR>
          <TD>&nbsp;Tution&nbsp;Fess <FONT color=#ff0033>*</FONT></TD>
          <TD>
<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txttf BorderStyle="Groove" runat="server" CssClass="TextBoxForms" Width="60px" MaxLength="5"></asp:textbox>
<asp:comparevalidator id=Comparevalidator1 Runat="server" ControlToValidate="txttf" ErrorMessage="Tution fees must be numeric" Operator="DataTypeCheck" Display="Dynamic" Type="Double">*</asp:comparevalidator></TD>
          <TD>&nbsp;Games Fees</TD>
          <TD>
<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtgf BorderStyle="Groove" runat="server" CssClass="TextBoxForms" Width="60px" MaxLength="5"></asp:textbox>
<asp:comparevalidator id=Comparevalidator5 Runat="server" ControlToValidate="txtgf" ErrorMessage="Mess fees must be numeric" Operator="DataTypeCheck" Display="Dynamic" Type="Double">*</asp:comparevalidator></TD></TR>
        <TR>
          <TD>&nbsp;Science&nbsp;Fees</TD>
          <TD>
<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtsf BorderStyle="Groove" runat="server" CssClass="TextBoxForms" Width="60px" MaxLength="5"></asp:textbox>
<asp:comparevalidator id=Comparevalidator3 Runat="server" ControlToValidate="txtsf" ErrorMessage="Lab fees must be numeric" Operator="DataTypeCheck" Display="Dynamic" Type="Double">*</asp:comparevalidator></TD>
          <TD>&nbsp;Transport&nbsp;Fees</TD>
          <TD>
<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txttrf BorderStyle="Groove" runat="server" CssClass="TextBoxForms" Width="60px" MaxLength="5" ReadOnly="True"></asp:textbox>
<asp:comparevalidator id=Comparevalidator7 Runat="server" ControlToValidate="txttrf" ErrorMessage="Donation fees must be numeric" Operator="DataTypeCheck" Display="Dynamic" Type="Double">*</asp:comparevalidator></TD></TR>
        <TR>
          <TD style="WIDTH: 82px">&nbsp;Computer&nbsp;Fess</TD>
          <TD>
<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtcf BorderStyle="Groove" runat="server" CssClass="TextBoxForms" Width="60px" MaxLength="5"></asp:textbox>
<asp:comparevalidator id=Comparevalidator2 Runat="server" ControlToValidate="txtcf" ErrorMessage="Sports fees must be numeric" Operator="DataTypeCheck" Display="Dynamic" Type="Double">*</asp:comparevalidator></TD>
          <TD>&nbsp;Late&nbsp;Fees</TD>
          <TD>
<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtlf BorderStyle="Groove" runat="server" CssClass="TextBoxForms" Width="60px" MaxLength="5" ReadOnly="True"></asp:textbox>
<asp:comparevalidator id=Comparevalidator6 Runat="server" ControlToValidate="txtlf" ErrorMessage="Exam fees must be numeric" Operator="DataTypeCheck" Display="Dynamic" Type="Double">*</asp:comparevalidator></TD></TR>
        <TR>
          <TD style="WIDTH: 82px">&nbsp;House Fees</TD>
          <TD>
<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txthf BorderStyle="Groove" runat="server" CssClass="TextBoxForms" Width="60px" MaxLength="5"></asp:textbox>
<asp:comparevalidator id=Comparevalidator12 Runat="server" ControlToValidate="txthf" ErrorMessage="Books &amp; Stationary fees must be numeric" Operator="DataTypeCheck" Display="Dynamic" Type="Double">*</asp:comparevalidator></TD>
          <TD></TD>
          <TD></TD></TR>
								</asp:panel>
								<tr>
									<TD style="WIDTH: 82px">&nbsp;Remark's</TD>
									<TD><asp:textbox id="txtremark" runat="server" CssClass="TextBoxForms" Height="20px" MaxLength="5"
											Width="130px" TextMode="MultiLine"></asp:textbox></TD>
								</tr>
								<tr>
									<TD style="WIDTH: 82px">&nbsp;Duration From</TD>
									<TD><asp:textbox id="Txtfromdate" BorderStyle="Groove" runat="server" CssClass="Fontstyle" MaxLength="5"
											Width="70px" ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.FessDecision.Txtfromdate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
									<TD style="WIDTH: 82px">To</TD>
									<TD><asp:textbox id="Txttodate" BorderStyle="Groove" runat="server" CssClass="Fontstyle" MaxLength="5"
											Width="70px" ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.FessDecision.Txttodate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
								</tr>
								<TR>
									<TD align="center" colSpan="6"><asp:button id="btnSave" runat="server" CssClass="formbuttonstyle" Text="Save"></asp:button>&nbsp;
										<asp:button id="btnEdit" runat="server" CssClass="formbuttonstyle" CausesValidation="False"
											Text="Update"></asp:button>&nbsp;
										<asp:button id="BtnReset" Runat="server" CssClass="formbuttonstyle" CausesValidation="False"
											Text="Reset"></asp:button><asp:validationsummary id="svFeesDecision" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
								</TR>
							</TBODY>
						</TABLE>
					</td>
				</tr>
			</table>
			<!--/TD></TR></table></TD></TR></TBODY></TABLE--><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
