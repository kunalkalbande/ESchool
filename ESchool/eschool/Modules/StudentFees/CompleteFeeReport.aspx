<%@ Import namespace="RMG"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="System.Web.SessionState"%>
<%@ Page language="c#" Codebehind="CompleteFeeReport.aspx.cs" AutoEventWireup="false" Inherits="eschool.StudentFees.CompleteReport" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Complete Fees Report</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="CompleteFeeReport" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<!--td align="center"><asp:label id="Label2" runat="server"></asp:label></td-->
					<td valign="top" align="center"><b>COMPLETE FEES REPORT</b>
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="70%" borderColorLight="#663300"
							border="5">
							<TR>
								<TD align="center" colSpan="22">class&nbsp;&nbsp;<asp:dropdownlist id="DropClass" Runat="server" CssClass="ComboBox">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist>&nbsp;&nbsp;&nbsp; Section&nbsp;&nbsp;<asp:dropdownlist id="DropSec" Runat="server" CssClass="ComboBox">
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
									</asp:dropdownlist>&nbsp;&nbsp;Duration From&nbsp;&nbsp;&nbsp;
									<asp:textbox id="Txtfromdate" CssClass="FontStyle" BorderStyle="Groove" runat="server" Width="70px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.CompleteFeeReport.Txtfromdate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>&nbsp;&nbsp; To&nbsp;&nbsp;<asp:textbox id="Txttodate" CssClass="FontStyle" BorderStyle="Groove" runat="server" Width="70px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.CompleteFeeReport.Txttodate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>&nbsp;
								</TD>
							</TR>
							<tr>
								<td colspan="22" align="center">&nbsp;<BUTTON id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 103px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 22px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server"><IMG id="txtsearch" style="WIDTH: 16px; HEIGHT: 7px" height="7" src="../../HeaderFooter/images/search.gif"
											width="16"> <U>S</U>earch</BUTTON>&nbsp;&nbsp;<BUTTON id="print" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 22px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server">Print</BUTTON> &nbsp;&nbsp;<BUTTON id="Exel" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 22px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="E" type="button" runat="server">Excel</BUTTON>
								</td>
							</tr>
							<%
				try
				{
         		InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr=null;
				string  strSelect="";
				gtutionfee=0;
				gcomputerfee=0;
				ghousefee=0;
				ggamefee=0;
				gsciencefee=0;
				gannualfee=0;
				gregistraionfee=0;
				glatefee=0;
				gadmissionfee=0;
				gtransportfee=0;
				gdevelopmentfee=0;
				gdairyfee=0;
				gsecurity=0;
				gtotal=0;
				gCaution=0;
				gTempCaution=0;
				gtotal=0;
				student_id="";
				sname="";
				bool flag=false;
				duration="";
				int i=1;
				
				if(DropClass.SelectedIndex!=0)
				{
				%>
							<TR bgcolor="#663300">
								<TD><b><font color="#ffffff">SNo</font></b></TD>
								<TD><b><font color="#ffffff">Rec No</font></b></TD>
								<TD><b><font color="#ffffff">R.Date</font></b></TD>
								<TD><b><font color="#ffffff">SID</font></b></TD>
								<TD><b><font color="#ffffff">Student Name</font></b></TD>
								<TD><b><font color="#ffffff">Class</font></b></TD>
								<TD><b><font color="#ffffff">Section</font></b></TD>
								<td><b><font color="#ffffff">Duration</font></b></td>
								<TD><b><font color="#ffffff">Tution</font></b></TD>
								<TD><b><font color="#ffffff">Computer</font></b></TD>
								<TD><b><font color="#ffffff">House</font></b></TD>
								<TD><b><font color="#ffffff">Game</font></b></TD>
								<TD><b><font color="#ffffff">Science</font></b></TD>
								<TD><b><font color="#ffffff">Registration</font></b></TD>
								<TD><b><font color="#ffffff">Late</font></b></TD>
								<TD><b><font color="#ffffff">Admission</font></b></TD>
								<TD><b><font color="#ffffff">Transport</font></b></TD>
								<TD><b><font color="#ffffff">Env</font></b></TD>
								<TD><b><font color="#ffffff">Diary</font></b></TD>
								<TD><b><font color="#ffffff">Annual</font></b></TD>
								<td><b><font color="#ffffff">Security</font></b></td>
								<TD><b><font color="#ffffff">Total</font></b></TD>
							</TR>
							<%
									
				if(!Txtfromdate.Text.Equals("")&&!Txttodate.Text.Equals(""))
				{
					if(DropClass.SelectedItem.Value.ToString().Equals("All"))
					{
						//strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where period='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"'))";  
						//strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where period='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.ToString()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.ToString())+"'))";  
						//strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt  where feesubdt between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.ToString()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.ToString())+"')";  
						
						//strSelect ="select distinct(recuringid) from recuringreceipt where  FeeSubdt between '"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"' and student_id in (select student_id from student_record)";
						
						//strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where feesubdt between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') order by student_class,seq_student_id,student_fname ";  
						//strSelect ="select student_id,student_class,seq_student_id,student_fname from student_record where student_id in (select student_id from recuringreceipt where feesubdt between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') union select student_id,student_class,student_stream,student_fname from student_registration where student_id in (select regid from recuringreceipt where feesubdt between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') order by student_class,seq_student_id,student_fname";
						///strSelect ="select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') union select s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"')"; date on 25.01.08
						///strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and r.student_id!=0 and r.student_id=s.student_id union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime)between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"')  and r1.student_id=0) order by s.student_id";
						///17.10.08 strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and r.student_id!=0 and r.student_id=s.student_id and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' and regid!=0) and r1.student_id=0 and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"')";
						strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"'  and r.student_id!=0 and r.student_id=s.student_id union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime)between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime)between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"'  and r1.student_id=0) order by s.student_id";
						SqlDtr=obj.GetRecordSet(strSelect);
						flag=true;
					}
					else
					{
						 //strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where period='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.ToString()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.ToString())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"'";  
						 //strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where  feesubdt between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.ToString()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.ToString())+"') and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"'";  
						 //strSelect ="select distinct(recuringid) from recuringreceipt where  FeeSubdt between '"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and '" + GenUtil.str2MMDDYYYY(Txttodate.Text)+"' and student_id in (select student_id from student_record where student_class='"+ DropClass.SelectedItem.Text.Trim()+"' and Seq_Student_id='"+DropSec.SelectedItem.Text.Trim()+"')";
						
						 //strSelect ="select * from student_record where student_id in (select student_id from recuringreceipt where feesubdt between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' order by student_class,seq_student_id,student_fname";
						
						 //strSelect ="select student_id,student_class,seq_student_id,student_fname from student_record where student_id in (select student_id from recuringreceipt where feesubdt between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' union select student_id,student_class,student_stream,student_fname from student_registration where student_id in (select regid from recuringreceipt where feesubdt between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"')  and student_class='"+DropClass.SelectedItem.Value.ToString()+"' order by student_class,seq_student_id,student_fname";    comment by vikas sharma date on 11.01.08
						 //strSelect ="select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' union select s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"'";//commented on 11/01/08
						
						  //strSelect ="select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' union select s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and student_class='"+DropClass.SelectedItem.Value.ToString()+"'";//added on 11/01/08
						 ///strSelect="select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' union select s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where  cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and student_class='"+DropClass.SelectedItem.Value.ToString()+"'"; date on 25.01.08
						  strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"') and r.student_id!=0 and r.student_id=s.student_id and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' and regid!=0 ) and student_class='"+DropClass.SelectedItem.Value.ToString()+"'  and r1.student_id=0 and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"')";
						 						
						SqlDtr=obj.GetRecordSet(strSelect);
						flag=true;
					}
					if(flag==true)
					{
					    string str1="";
						string feetype="";
						while(SqlDtr.Read())
						{
							recid=SqlDtr.GetValue(0).ToString().Trim();
							feetype=SqlDtr.GetValue(1).ToString();
							
							feesdecisionmonthly(recid,feetype);
							%>
							<tr class="DataGridItem">
								<td align="center"><%=i.ToString()%></td>
								<td align="center"><%=recid.ToString()%></td>
								<td><%=recdate.ToString()%></td>
								<td align="center"><%=student_id.ToString()%></td>
								<td><%=sname.ToString()%></td>
								<td align="center"><%=classid.ToString()%></td>
								<td align="center"><%=section.ToString()%></td>
								<td><%=duration.ToString()%>
								</td>
								<td align="center"><%=tutionfee.ToString()%></td>
								<td align="center"><%=computerfee.ToString()%></td>
								<td align="center"><%=housefee.ToString()%></td>
								<td align="center"><%=gamefee.ToString()%></td>
								<td align="center"><%=sciencefee.ToString()%></td>
								<td align="center"><%=registraionfee.ToString()%></td>
								<td align="center"><%=latefee.ToString()%></td>
								<td align="center"><%=admissionfee.ToString()%></td>
								<td align="center"><%=transportfee.ToString()%></td>
								<td align="center"><%=developmentfee.ToString()%></td>
								<td align="center"><%=dairyfee.ToString()%></td>
								<td align="center"><%=annualfee.ToString()%></td>
								<td align="center"><%=security.ToString()%></td>
								<td align="center"><%=total.ToString()%></td>
							</tr>
							<%
							i++;
						}
						SqlDtr.Close();
					}
							
					flag=false;
				}
				%>
							<tr bgcolor="#663300">
								<td align="center" colSpan="8"><b><font color="#ffffff">Grand Total</font></b></td>
								<td align="center"><b><font color="#ffffff"><%=gtutionfee.ToString()%></font></b></td>
								<td align="center"><b><font color="#ffffff"><%=gcomputerfee.ToString()%></font></b></td>
								<td align="center"><b><font color="#ffffff"><%=ghousefee.ToString()%></font></b></td>
								<td align="center"><b><font color="#ffffff"><%=ggamefee.ToString()%></font></b></td>
								<td align="center"><b><font color="#ffffff"><%=gsciencefee.ToString()%></font></b></td>
								<td align="center"><b><font color="#ffffff"><%=gregistraionfee.ToString()%></font></b></td>
								<td align="center"><b><font color="#ffffff"><%=glatefee.ToString()%></font></b></td>
								<td align="center"><b><font color="#ffffff"><%=gadmissionfee.ToString()%></font></b></td>
								<td align="center"><b><font color="#ffffff"><%=gtransportfee.ToString()%></font></b></td>
								<td align="center"><b><font color="#ffffff"><%=gdevelopmentfee.ToString()%></font></b></td>
								<td align="center"><b><font color="#ffffff"><%=gdairyfee.ToString()%></font></b></td>
								<td align="center"><b><font color="#ffffff"><%=gannualfee.ToString()%></font></b></td>
								<td align="center"><b><font color="#ffffff"><%=gsecurity.ToString()%></font></b></td>
								<td align="center"><b><font color="#ffffff"><%=gtotal.ToString()%></font></b></td>
								<%
			}
					
								 } 
								 catch(Exception ex)
								 {
		
								CreateLogFiles.ErrorLog(" Form :CompleteFeeReport.aspx,Method  HTML Part,  Exception: "+ex.Message+" , Userid :  "+ Session["password"] );		
			    
								}	%>
							</tr>
						</TABLE>
					</td>
				</tr>
			</table>
			<IFRAME id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0"
				width="174" scrolling="no" height="189"></IFRAME>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
