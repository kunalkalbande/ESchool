<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="FeesDueReport.aspx.cs" AutoEventWireup="false" Inherits="eschool.StudentFees.FeesDueReport" %>
<%@ Import namespace="RMG"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="System.Web.SessionState"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Due Fees Report</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252"> <!--
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
	</HEAD>
	<body>
		<form id="FeesDueReport" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td align="center"><asp:label id="Label2" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td vAlign="top" align="center"><b>DUE FEES REPORT</b>
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="70%" borderColorLight="#663300"
							border="5">
							<TR>
								<TD align="center" colSpan="6">class&nbsp;<asp:dropdownlist id="DropClass" CssClass="ComboBox" Runat="server">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist>&nbsp;Section&nbsp;<asp:dropdownlist id="DropSec" CssClass="ComboBox" Runat="server">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="A">A</asp:ListItem>
										<asp:ListItem Value="B">B</asp:ListItem>
										<asp:ListItem Value="C">C</asp:ListItem>
										<asp:ListItem Value="D">D</asp:ListItem>
										<asp:ListItem Value="E">E</asp:ListItem>
										<asp:ListItem Value="F">F</asp:ListItem>
										<asp:ListItem Value="G">G</asp:ListItem>
										<asp:ListItem Value="H">H</asp:ListItem>
										<asp:ListItem Value="I">I</asp:ListItem>
										<asp:ListItem Value="J">J</asp:ListItem>
									</asp:dropdownlist>&nbsp;Duration From&nbsp;<asp:textbox id="Txtfromdate" CssClass="FontStyle" BorderStyle="Groove" runat="server" Width="70px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.FeesDueReport.Txtfromdate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>To&nbsp;<asp:textbox id="Txttodate" CssClass="FontStyle" BorderStyle="Groove" runat="server" Width="70px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.FeesDueReport.Txttodate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>
								</TD>
							</TR>
							<tr>
								<td align="center" colspan="6"><BUTTON id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server"><IMG id="txtsearch" style="WIDTH: 14px; HEIGHT: 7px" height="7" src="../../HeaderFooter/images/search.gif"
											width="16"><U>S</U>earch</BUTTON>&nbsp;<BUTTON class="FormButtonStyle" id="print" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server">Print</BUTTON> &nbsp;<BUTTON class="FormButtonStyle" id="Exel" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server">Exel</BUTTON>
								</td>
							</tr>
							<%
				try
				{
				int j=1;
         		InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr=null;
				string  strSelect="";
				gtotal=0;
				student_id="";
				sname="";
				
				if(DropClass.SelectedIndex!=0)
				{
					%>
							<TR bgcolor="#663300" align="center">
								<td><b><font color="#ffffff">SNo</font></b></td>
								<td><b><font color="#ffffff">SID</font></b></td>
								<TD><b><font color="#ffffff">Student Name</font></b></TD>
								<TD><b><font color="#ffffff">Class</font></b></TD>
								<TD><b><font color="#ffffff">Section</font></b></TD>
								<TD><b><font color="#ffffff">Amount</font></b></TD>
							</TR>
							<%
					if(!Txtfromdate.Text.Equals("")&&!Txttodate.Text.Equals(""))
					{
						if(DropClass.SelectedItem.Value.ToString().Equals("All"))
						{
							//			strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"'))";  
							//			strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"')) and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"'";//commented by vishnu on 15/10
							//02.02.08--strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"')) and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"'  order by student_class,seq_student_id,student_fname";//added by vishnu 15/10
							//22.02.08--strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"')) and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id not in (select student_id from tc1) order by student_class,seq_student_id,student_fname";//added by vishnu 15/10
							strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"')) and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off) order by student_class,seq_student_id,student_fname";// add by vikas sharma date on 22.02.08
							SqlDtr=obj.GetRecordSet(strSelect);
							while(SqlDtr.Read())
							{
								student_id=SqlDtr.GetValue(0).ToString().Trim();
								feesdecisionmonthly(student_id);
								%>
							<tr>
								<td align="center"><%=j.ToString()%></td>
								<td align="center"><%=student_id.ToString()%></td>
								<td><%=sname.ToString()%></td>
								<td align="center"><%=classid.ToString()%></td>
								<td align="center"><%=section.ToString()%></td>
								<td align="right"><%=total.ToString()%></td>
							</tr>
							<%
								j++;
							}
							SqlDtr.Close();
						}
						else
						{
							if(DropClass.SelectedIndex==0 && DropSec.SelectedIndex ==0)
							{
								MessageBox.Show("Please select The Information ");
								//gridfeesDue.Visible=false;
							}
							else
							{
								//strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"'";  
								//strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"'";  //commented by vishnu
								//02.02.08--strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' order by student_class,seq_student_id,student_fname";  //added by vishnu
								//22.02.08--strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id not in (select student_id from tc1) order by student_class,seq_student_id,student_fname";  //added by vishnu
								strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off) order by student_class,seq_student_id,student_fname";  // add by vikas sharma date on 22.02.08
								SqlDtr=obj.GetRecordSet(strSelect);
								while(SqlDtr.Read())
								{
									student_id=SqlDtr.GetValue(0).ToString().Trim();
									feesdecisionmonthly(student_id);%>
							<tr>
								<td align="center"><%=j.ToString()%></td>
								<td align="center"><%=student_id.ToString()%></td>
								<td><%=sname.ToString()%></td>
								<td align="center"><%=classid.ToString()%></td>
								<td align="center"><%=section.ToString()%></td>
								<td align="right"><%=total.ToString()%></td>
							</tr>
							<%
									j++;
								}
								SqlDtr.Close();
							}
						}
					}
				%>
							<tr bgcolor="#663300">
								<td colSpan="1"><b><font color="#ffffff">Grand Total</font></b></td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td align="right"><b><font color="#ffffff"><%=gtotal.ToString()%></font></b></td>
							</tr>
							<%	
					
				}
				%>
							<%
    }
    catch(Exception ex)
    {
   		CreateLogFiles.ErrorLog(" Form :FeeDueReport.aspx,Method  HTML Part,  Exception: "+ex.Message+" , Userid :  "+ Session["password"]   );		
	}	
	%>
						</TABLE>
					</td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0"
				width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
