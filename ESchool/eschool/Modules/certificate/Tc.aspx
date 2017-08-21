<%@ Page language="c#" Codebehind="Tc.aspx.cs" AutoEventWireup="false" Inherits="eschool.certificate.Tc" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Transefer Certificate</title> 
		<!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<script language="javascript">
		</script>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<script language="javascript" id="Validations1" src="../../HeaderFooter/shareables/jsfiles/Searchdrop.js"></script>
		<meta content="JavaScript" name="vs_defaultClientScript">
		<link href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		// this method use to clear page.
		function clear()
		{
			document.Tc.Dropstudentid.value="Select";
			document.Tc.txtstudentname.value="";
			document.Tc.txtfaname.value="";
			document.Tc.txtadddta.value="";
			document.Tc.txtdob.value="";
			document.Tc.txtcat.value="";
			document.Tc.txtduefee.value="";
			
		}
		//this method use to hide and visible textbox on the page.
		function Other(t)
		{
			if(t.name=="txtreason")
			{
				var index=t.selectedIndex
				var name = t.options[index].text
				if(name=="Other")
				{ 
					document.all.txtItemOther.style.visibility="visible"
				}
				else
				{
					document.all.txtItemOther.style.visibility="hidden"
				}
			}
		}
		
		// this method use to show fees from hidden text box.
		function Showfees(t1,text)
		{
			document.Tc.txtduefee.value=""
			var ind=document.Tc.ListIssueBookID.selectedIndex
			var value=document.Tc.ListIssueBookID.options[ind].text
	        var value1=new Array()
		    value1=value.split(':')
			var idname=t1
			var name=new Array()
			var id=new Array()
			name=idname.split(",")
			for(var i=0; i<(name.length);i++)
			{
				id=name[i].split(";")
				for(var j=0;j<(id.length);j++)
				{
					if(id[0]==value1[1])
					{
						text.value=id[1]
					}
				}
			}
		}
    
		// this method use to show information from hidden textbox.
		function Showname(t1)
		{
			document.Tc.txtstudentname.value =""
			document.Tc.txtfaname.value =""
			document.Tc.txtadddta.value =""
			document.Tc.txtdob.value =""
			document.Tc.txtcat.value =""
			//var ind=t.selectedIndex
			var ind=document.Tc.ListIssueBookID.selectedIndex
			//var value=t.options[ind].text
			var value=document.Tc.ListIssueBookID.options[ind].text
			var value1=new Array()
			value1=value.split(':')
			var idname=t1
			var name=new Array()
			var id=new Array()
			name=idname.split(",")
			for(var i=0; i<(name.length);i++)
			{
				id=name[i].split(";")
				for(var j=0;j<(id.length);j++)
				{
					if(id[0]==value1[1])
					{
						document.Tc.txtstudentname.value =id[1]
						document.Tc.txtfaname.value =id[2]
						document.Tc.txtadddta.value =id[3]
						document.Tc.txtdob.value =id[4]
						document.Tc.txtcat.value =id[5]
					}
				}
			}
		}
		</script>
</HEAD>
	<body>
		<form id="Tc" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><input id="texthidden" style="WIDTH: 1px" type="hidden" name="texthidden" runat="server">
			<input id="texthidden1" style="WIDTH: 1px" type="hidden" name="texthidden1" runat="server">
			<input id="texthidden2" style="WIDTH: 1px" type="hidden" name="texthidden2" runat="server">
			<table height="232" width="778" align="center">
				<tr>
					<td vAlign="top" align="center"><asp:label id="Label1" runat="server" Font-Bold="True">TRANSFER CERTIFICATE</asp:label>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="70%" borderColorLight="#663300"
							border="5">
							<TR>
								<TD colSpan="4"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="tcid11" runat="server">&nbsp;Tc ID</asp:label>&nbsp;</TD>
								<td colSpan="6"><asp:dropdownlist CssClass="ComboBox" id="DropEdit" runat="server" AutoPostBack="True" Width="83px"	Height="15px">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist>&nbsp;<asp:label id="tcid" ForeColor="blue" runat="server"></asp:label>&nbsp;
									</td>
							</TR>
							<TR>
								<TD>&nbsp;Class&nbsp;<FONT color="#ff0000" size="1">*</FONT></TD>
								<TD><asp:dropdownlist OnChange="clear();" CssClass="ComboBox" id="Dropclass" runat="server" AutoPostBack="True">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist>&nbsp;<asp:CompareValidator ID="compvalid1" Runat="server" ControlToValidate="Dropclass" Operator="NotEqual"
										ValueToCompare="---Select---" ErrorMessage="Please Select Class">*</asp:CompareValidator></TD>
								<TD>&nbsp;Student ID&nbsp;<FONT color="#ff0000" size="1">*</FONT></TD>
								<TD><input class="TextBoxStyle" id="Dropstudentid" onkeyup="search3(this,document.Tc.ListIssueBookID,document.Tc.texthidden.value),arrowkeydown(this,event,document.Tc.ListIssueBookID,document.Tc.texthidden),Selectbyenter(document.Tc.ListIssueBookID,event,document.Tc.Dropstudentid,document.Tc.txtcat),Showname(document.Tc.texthidden1.value),Showfees(document.Tc.texthidden2.value,document.Tc.txtduefee)"
										style="Z-INDEX: 10; VISIBILITY: visible; WIDTH: 150px; HEIGHT: 18px" onclick="search1(document.Tc.ListIssueBookID,document.Tc.texthidden),dropshow(document.Tc.ListIssueBookID)"
										value="Select" name="Dropstudentid" runat="server"><input style="HEIGHT: 18px" class="ComboBoxSearchButtonStyle" onclick="search1(document.Tc.ListIssueBookID,document.Tc.texthidden),dropshow(document.Tc.ListIssueBookID)"
										readOnly type="text" name="temp"><asp:CompareValidator ID=valicom1 Runat=server ControlToValidate=Dropstudentid ValueToCompare=Select Operator=NotEqual ErrorMessage="Please select Student id">&nbsp;*</asp:CompareValidator><br>
									<div id="Layer1" style="Z-INDEX: 2; POSITION: absolute"><select class="ListBoxBorderStyle" onmousemove="MouseMove(this)" onkeypress="Selectbyenter(this,event,document.Tc.Dropstudentid,document.Tc.txtcat)"
											id="ListIssueBookID" ondblclick="select(this,document.Tc.Dropstudentid),Showname(document.Tc.texthidden1.value),Showfees(document.Tc.texthidden2.value,document.Tc.txtduefee)"
											onkeyup="arrowkeyselect(this,event,document.Tc.txtcat,document.Tc.Dropstudentid),Showname(document.Tc.texthidden1.value),Showfees(document.Tc.texthidden2.value,document.Tc.txtduefee)"
											style="Z-INDEX: 10; VISIBILITY: hidden; WIDTH: 170px; HEIGHT: 0px" onfocusout="HideList(this,document.Tc.Dropstudentid)" multiple name="ListIssueBookID"
											type="select-one"></select></div>
								</TD>
							</TR>
							<TR>
								<TD>&nbsp;Student Name</TD>
								<TD><asp:textbox CssClass="TextBoxForms" id="txtstudentname"  runat="server"></asp:textbox></TD>
								<TD>&nbsp;Father Name&nbsp;</TD>
								<TD><asp:textbox CssClass="TextBoxForms" id="txtfaname"  Runat="server"></asp:textbox></TD>
							</TR>
							<tr>
								<td>&nbsp;Admission Date</td>
								<td><asp:textbox CssClass="TextBoxForms" id="txtadddta"  runat="server"></asp:textbox></td>
								<td>&nbsp;Date of Birth</td>
								<td><asp:textbox CssClass="TextBoxForms" id="txtdob"  Runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td>&nbsp;Category</td>
								<td><asp:textbox CssClass="TextBoxForms" id="txtcat" onkeypress="return GetOnlyChars(this, event);"
										MaxLength="10" Runat="server"></asp:textbox></td>
								<td>&nbsp;Nationality</td>
								<td><asp:textbox CssClass="TextBoxForms" id="txtnat" onkeypress="return GetOnlyChars(this, event);"
										MaxLength="15" Runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td>&nbsp;Ncc Cadet</td>
								<td><asp:dropdownlist CssClass="ComboBox" id="dropncadet" Runat="server">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="Boy Scout">Boy Scout</asp:ListItem>
										<asp:ListItem Value="Girl Guide">Girl Guide</asp:ListItem>
									</asp:dropdownlist></td>
								<td>&nbsp;Fee Paid</td>
								<td><asp:textbox CssClass="TextBoxForms" id="txtduefee"  Runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td>&nbsp;TWorking Day</td>
								<td><asp:textbox CssClass="TextBoxForms" id="txttwd" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										MaxLength="3" Runat="server"></asp:textbox></td>
								<td>&nbsp;TDays Present</td>
								<td><asp:textbox CssClass="TextBoxForms" id="txttdp" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										MaxLength="3" Runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td>&nbsp;Curricular Act</td>
								<td><asp:textbox CssClass="TextBoxForms" id="txtcurriact" onkeypress="return GetAnyNumber(this, event);"
										MaxLength="30" Runat="server"></asp:textbox></td>
								<td>&nbsp;Result&nbsp;<FONT color="#ff0000" size="1">*</FONT></td>
								<td><asp:dropdownlist CssClass="ComboBox" id="Dropclassres" runat="server">
										<asp:ListItem Value="Select"></asp:ListItem>
										<asp:ListItem Value="Pass"></asp:ListItem>
										<asp:ListItem Value="Fail"></asp:ListItem>
										<asp:ListItem Value="Same Class"></asp:ListItem>
										</asp:dropdownlist>&nbsp;<asp:CompareValidator ID="Compalidator3" Runat="server" ControlToValidate="Dropclassres" Operator="NotEqual"
										ValueToCompare="Select" ErrorMessage="Please Select Result">*</asp:CompareValidator></td>
							</tr>
							<tr>
								<td>&nbsp;Pramotion For Class</td>
								<td><asp:textbox CssClass="TextBoxForms" id="txtpramonation" onkeypress="return GetAnyNumber(this, event);"
										MaxLength="10" Runat="server"></asp:textbox></td>
								<td>&nbsp;Fee Concession</td>
								<td><asp:textbox CssClass="TextBoxForms" id="txtfeecon" onkeypress="return GetAnyNumber(this, event);"
										MaxLength="10" Runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td>&nbsp;General Conduct</td>
								<td><asp:textbox CssClass="TextBoxForms" id="txtgconduct" onkeypress="return GetAnyNumber(this, event);"
										MaxLength="30" Runat="server"></asp:textbox></td>
								<td>&nbsp;Remark</td>
								<td><asp:textbox CssClass="TextBoxForms" id="txtremark" onkeypress="return GetAnyNumber(this, event);"
										MaxLength="30" Runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td>&nbsp;Apply Date</td>
								<td><asp:textbox CssClass="Fontstyle"  Width=70px BorderStyle=Groove id="txtadate" Runat="server"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Tc.txtadate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A></td>
								<td>&nbsp;TC Date&nbsp;<FONT color="#ff0000">*</FONT></td>
								<td><asp:textbox CssClass="Fontstyle"  Width=70px BorderStyle=Groove id="txttcdt" runat="server"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Tc.txttcdt);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txttcdt" ErrorMessage="you must be enter tc date">*</asp:requiredfieldvalidator><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Tc.txtisdate);return false;"></A></td>
							</tr>
							<TR>
								<TD>&nbsp;Reason&nbsp;<font color="red" size="1">*</font></TD>
								<TD colSpan="3"><asp:dropdownlist CssClass="ComboBox" id="txtreason" Runat="server" onchange="Other(this)">
										<asp:ListItem Value="Select"></asp:ListItem>
										<asp:ListItem Value="Posted Out"></asp:ListItem>
										<asp:ListItem Value="Pass Out"></asp:ListItem>
										<asp:ListItem Value="Change Of School"></asp:ListItem>
										<asp:ListItem Value="Personal Reason"></asp:ListItem>
										<asp:ListItem Value="Other"></asp:ListItem>
									</asp:dropdownlist>&nbsp;<asp:CompareValidator ID="Comparevalidator1" Runat="server" ControlToValidate="txtreason" Operator="NotEqual"
										ValueToCompare="Select" ErrorMessage="Please Select Reason">*</asp:CompareValidator><input id="txtItemOther" class=TextBoxForms style="VISIBILITY: hidden" type="text"
										name="txtItemOther"></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="4">
									<asp:button id="btnSave" BorderStyle="Groove" runat="server" ForeColor="Black" Width="56px"
										CssClass="formbuttonstyle" Text="Save"></asp:button>
									&nbsp;&nbsp;&nbsp;<asp:button id="BtnEdit" BorderStyle="Groove" runat="server" ForeColor="Black" CausesValidation="False"
										Width="60px" CssClass="formbuttonstyle" Text="Edit"></asp:button>
									&nbsp;&nbsp;&nbsp;<asp:button id="BtnEditSave" BorderStyle="Groove" runat="server" ForeColor="Black" CssClass="formbuttonstyle"
										Text="Update"></asp:button>
									&nbsp;&nbsp;&nbsp;<asp:button id="BtnDelete" BorderStyle="Groove" runat="server" ForeColor="Black" CssClass="formbuttonstyle"
										Text="Delete" Visible="False"></asp:button>
									&nbsp;&nbsp;&nbsp;<asp:button id="btnreset" CausesValidation="False" BorderStyle="Groove" runat="server" ForeColor="Black"
										Width="59px" CssClass="formbuttonstyle" Text="Reset"></asp:button>
									&nbsp;&nbsp;&nbsp;<asp:button id="btnprint" BorderStyle="Groove" runat="server" ForeColor="Black" Width="59px"
										CssClass="formbuttonstyle" Text="Print"></asp:button>
									&nbsp;&nbsp;&nbsp;<asp:button id="btnword" BorderStyle="Groove" runat="server" ForeColor="Black" Width="59px"
										CssClass="formbuttonstyle" Text="Word"></asp:button><asp:validationsummary id="vsTC" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
							</TR>
						</TABLE>
					</td>
					<td></td>
				</tr>
				<tr>
					<td colSpan="3"></td>
				</tr>
			</table>
			<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
