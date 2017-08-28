<%@ Page language="c#" Codebehind="Ledger.aspx.cs" AutoEventWireup="false" EnableEventValidation="false" Inherits="eschool.Modules.Accounts.Ledgre" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Ledger Creation</title> <!--
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
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<script language="javascript">
		       function getGroup(t)
		       {
		         var typeindex = t.selectedIndex
                 var typetext  = t.options[typeindex].text
					 document.Form1.TxtSub.value = "";
                 var mainarr = new Array();
                 var secarr  = new Array();
                 var n =0;
                 var hidarr  = document.Form1.txtValue.value;
					mainarr = hidarr.split("#");
					document.Form1.DropGroup.length = 1;
                 if(typetext == "Other")
                 {
                    document.Form1.TxtSub.disabled = false;
                    hidarr  = document.Form1.txtGrp.value;
					secarr = hidarr.split("~");
                    for(var j=0;j<secarr.length-1;j++)
					{
						document.Form1.DropGroup.add(new Option) 
						if(secarr[j]  != "")
						{		
							document.Form1.DropGroup.options[n+1].text=secarr[j];                  
							n = n+1;
						}
					}
			         document.Form1.DropGroup.add(new Option)  
		             document.Form1.DropGroup.options[n+1].text="Other";
                  }
                 else
                 {
                 //alert("else");
                 
                  document.Form1.TxtSub.disabled = true;
                 for(var i=0;i < mainarr.length;i++)
                 {
                 secarr = mainarr[i].split("~");
                 if(typetext == secarr[0])
                    {
                     document.Form1.DropGroup.add(new Option)  
                     document.Form1.DropGroup.options[n+1].text=secarr[1];
                     n = n + 1;                   
                     if(secarr[2] == "Assets")
                     {
                     document.Form1.RadioAsset.checked = true;
                     }
                     else if(secarr[2] == "Liabilities")
                     {
                     document.Form1.RadioLiab.checked = true;
                     }
                     else if(secarr[2] == "Expenses")
                     {
                     document.Form1.RadioExp.checked = true;
                     }
                     else
                     {
                     document.Form1.RadioIncome.checked = true;
                     }
                            
                                       
                    } 
                 
                 }
                   document.Form1.DropGroup.selectedIndex = 1;
                   document.Form1.DropGroup.add(new Option)  
                   document.Form1.DropGroup.options[n+1].text="Other";
                    
                   setNature(t);
                 
               
                 
                 }
                 
               }  
               
               function setNature(t)
               {
                
               var typeindex = t.selectedIndex
                var typetext  = t.options[typeindex].text
                var mainarr = new Array();
                 var secarr  = new Array();
                 var hidarr  = document.Form1.txtValue.value;
                 mainarr = hidarr.split("#");               
                var typeindex = document.Form1.DropGroup.selectedIndex
                 var typetext1  = document.Form1.DropGroup.options[typeindex].text
                 document.Form1.txtTempGrp.value = typetext1;
                 if(typetext1  == "Other")
                 {
                  document.Form1.TxtGroup.disabled = false;
                  document.Form1.RadioAsset.checked = true;
                 }
                 else
                 {
                 document.Form1.TxtGroup.disabled = true;
                 document.Form1.TxtGroup.value = "";
                 for(var i=0;i < mainarr.length;i++)
                 {
                 secarr = mainarr[i].split("~");
                 if(typetext == secarr[0] && typetext1 == secarr[1] )
                    {
                     if(secarr[2] == "Assets")
                     {
                     document.Form1.RadioAsset.checked = true;
                     }
                     else if(secarr[2] == "Liabilities")
                     {
                     document.Form1.RadioLiab.checked = true;
                     }
                     else if(secarr[2] == "Expenses")
                     {
                     document.Form1.RadioExp.checked = true;
                     }
                     else
                     {
                     document.Form1.RadioIncome.checked = true;
                     }
                            
                                       
                    } 
                    }
                 
                 }
               }
		       
		</script>
</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<TABLE height="250" width="778" align="center">
				<TR>
					<TD vAlign="top" align="center"><b>LEDGER CREATION</b>
						<TABLE cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<TR>
								<TD colSpan="2"><FONT color="#ff0000">asterisk (*) fields are mandatory</FONT><INPUT id="txtValue" style="Z-INDEX: 102; LEFT: 144px; WIDTH: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
										type="hidden" size="1" name="txtValue" runat="server"> <INPUT id="txtTempGrp" style="Z-INDEX: 103; LEFT: 160px; WIDTH: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 24px"
										type="hidden" size="1" name="txtTempGrp" runat="server"> <INPUT id="txtGrp" style="Z-INDEX: 104; LEFT: 176px; WIDTH: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 24px"
										type="hidden" size="1" name="txtGrp" runat="server">
								</TD>
							</TR>
							<TR>
								<TD align="left">&nbsp;Ledger Name&nbsp; <FONT color="#ff0000" size="1">*</FONT> <FONT color="red">
									</FONT>
								</TD>
								<TD><asp:dropdownlist id="dropLedgerName" CssClass="ComboBox" runat="server" Visible="False" AutoPostBack="True"
										Width="229px">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist><asp:textbox id="TxtLedger" onkeypress="return GetAnyNumber(this, event);" runat="server" Width="229px"
										MaxLength="40" CssClass="TextBoxForms" BorderStyle="Groove"></asp:textbox>
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtLedger" ErrorMessage="Please Enter Ledger Name">*</asp:requiredfieldvalidator><asp:button id="btnEdit1" runat="server" Text="..." ToolTip="Click Here For Edit" CausesValidation="False"
										CssClass="formEDITbuttonstyle"></asp:button></TD>
							</TR>
							<TR>
								<TD align="left">&nbsp;SubGroup Name <FONT color="#ff3333" size="1">*</FONT></TD>
								<TD><asp:dropdownlist id="DropSub" runat="server" Width="170px" onChange="return getGroup(this);" CssClass="ComboBox">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist>&nbsp;<FONT color="#0000ff">(if another, Specify)</FONT>
									<asp:textbox id="TxtSub" runat="server" Width="110px" CssClass="TextBoxForms" BorderStyle="Groove"></asp:textbox></TD>
							</TR>
							<TR>
								<TD width="98">&nbsp;Group Name <FONT color="#ff0000" size="1">*</FONT>
								</TD>
								<TD><asp:dropdownlist id="DropGroup" runat="server" Width="170px" onchange="return setNature(document.Form1.DropSub);"
										CssClass="ComboBox">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist><FONT color="#0000ff">(if another, Specify)</FONT>&nbsp;
									<asp:textbox id="TxtGroup" runat="server" Width="110px" CssClass="TextBoxForms" BorderStyle="Groove"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="left">&nbsp;Nature of Group <FONT color="#ff0000">&nbsp;&nbsp;&nbsp;</FONT></TD>
								<TD>
									<P align="left"><asp:radiobutton id="RadioAsset" runat="server" Text="Asset" Checked="True" GroupName="Nature"></asp:radiobutton>s&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:radiobutton id="RadioLiab" runat="server" Text="Liabilities" GroupName="Nature"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:radiobutton id="RadioExp" runat="server" Text="Expenses" GroupName="Nature"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:radiobutton id="RadioIncome" runat="server" Text="Income" GroupName="Nature"></asp:radiobutton></P>
								</TD>
							</TR>
							<!--	<TR>
								<TD style="HEIGHT: 30px" align="left" colSpan="4">&nbsp;Effective 
									From&nbsp;&nbsp;&nbsp;
									<asp:textbox id="TxtFrom" runat="server" Width="84px"></asp:textbox>&nbsp;&nbsp;&nbsp;<A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDate);return false;"><IMG class="PopcalTrigger" id="Img3" alt="" src="../../DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A>&nbsp;&nbsp;&nbsp;&nbsp; 
									&nbsp;&nbsp;Effective TO
									<asp:textbox id="TxtTo" runat="server" Width="60px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDate);return false;"><IMG class="PopcalTrigger" id="Img1" alt="" src="../../DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A>
								</TD>
							</TR>-->
							<TR>
								<TD>&nbsp;Opening Balance&nbsp;</TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="TxtOpeningBal"
										runat="server" Width="120px" CssClass="TextBoxForms" BorderStyle="Groove"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:dropdownlist id="DropBalType" runat="server" Width="40px" CssClass="FontStyle">
										<asp:ListItem Value="Debit">Dr</asp:ListItem>
										<asp:ListItem Value="Credit">Cr</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2"><asp:button id="btnSave" runat="server" Width="70px" Text="Add" CssClass="formbuttonstyle"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnEdit" runat="server" Width="70px" Text="Update" CssClass="formbuttonstyle"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									&nbsp;<asp:button id="btnDelete" runat="server" Width="71px" Text="Delete" CausesValidation="False"
										CssClass="formbuttonstyle"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD>
				</TR>
			</TABLE>
			<!--<IFRAME id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></IFRAME>--><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../DTPicker/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form></FORM>
	</body>
</HTML>
