<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="AdvanceFeesReport.aspx.cs" AutoEventWireup="false" Inherits="eschool.StudentFees.AdvanceFeesReport" %>
<%@ Import namespace="RMG"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="System.Data.SqlClient"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Advance & Pending Fees Report</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body>
		<form id="AdvanceFeesReport" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td align="center"><asp:label id="Label2" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td vAlign="top" align="center"><b>ADVANCE &amp; PENDING FEES REPORT</b>
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<TBODY>
								<TR>
									<TD align="center" colSpan="24">Class&nbsp;<asp:dropdownlist id="DropClass" Runat="server" CssClass="FontStyle">
											<asp:ListItem Value="Select">Select</asp:ListItem>
										</asp:dropdownlist>&nbsp;&nbsp; Section&nbsp;<asp:dropdownlist id="DropSec" Runat="server" CssClass="FontStyle">
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
										</asp:dropdownlist>
										&nbsp;&nbsp;Advance Duration From&nbsp;
										<asp:textbox id="Txtfromdate" BorderStyle="Groove" runat="server" CssClass="FontStyle" Width="70px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.AdvanceFeesReport.Txtfromdate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To&nbsp;
										<asp:textbox id="Txttodate" BorderStyle="Groove" runat="server" CssClass="FontStyle" Width="70px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.AdvanceFeesReport.Txttodate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A>
									</TD>
								</TR>
								<TR>
									<TD align="center" colSpan="24">Current Duration From&nbsp;&nbsp;&nbsp;
										<asp:textbox id="Txtcurdatef" BorderStyle="Groove" runat="server" CssClass="FontStyle" Width="70px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.AdvanceFeesReport.Txtcurdatef);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To&nbsp;<asp:textbox id="Txtcurdatet" BorderStyle="Groove" runat="server" CssClass="FontStyle" Width="70px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.AdvanceFeesReport.Txtcurdatet);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A> &nbsp;&nbsp;<BUTTON class="FormButtonStyle" id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
											accessKey="S" type="button" runat="server"><IMG id="txtsearch" style="WIDTH: 16px; HEIGHT: 7px" height="7" src="../../HeaderFooter/images/search.gif"
												width="16"><U>S</U>earch</BUTTON>&nbsp;&nbsp;<BUTTON class="FormButtonStyle" id="print" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
											accessKey="S" type="button" runat="server">Print</BUTTON> &nbsp;&nbsp;<BUTTON class="FormButtonStyle" id="Excel" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
											accessKey="E" type="button" runat="server">Excel</BUTTON>
									</TD>
								</TR>
								<%
								if(DropClass.SelectedIndex!=0)
								{
									%>
								<TR bgColor="#663300">
									<TD><b><font color="#ffffff">SNo</font></b></TD>
									<TD><b><font color="#ffffff">Rec No</font></b></TD>
									<TD><b><font color="#ffffff">R.Date</font></b></TD>
									<TD><b><font color="#ffffff">SID</font></b></TD>
									<TD><b><font color="#ffffff">Category</font></b></TD>
									<TD><b><font color="#ffffff">Student Name</font></b></TD>
									<TD><b><font color="#ffffff">Tution</font></b></TD>
									<TD><b><font color="#ffffff">Comp</font></b></TD>
									<TD><b><font color="#ffffff">Hous</font></b></TD>
									<TD><b><font color="#ffffff">Game</font></b></TD>
									<TD><b><font color="#ffffff">Scie</font></b></TD>
									<TD><b><font color="#ffffff">Regi</font></b></TD>
									<TD><b><font color="#ffffff">Late</font></b></TD>
									<TD><b><font color="#ffffff">Admis</font></b></TD>
									<TD><b><font color="#ffffff">Trans</font></b></TD>
									<TD><b><font color="#ffffff">Env</font></b></TD>
									<TD><b><font color="#ffffff">Diar</font></b></TD>
									<TD><b><font color="#ffffff">Annu</font></b></TD>
									<td><b><font color="#ffffff">Secur</font></b></td>
									<TD><b><font color="#ffffff">Total</font></b></TD>
									<TD><b><font color="#ffffff">Fees Pending</font></b></TD>
									<TD><b><font color="#ffffff">Fees Advance</font></b></TD>
								</TR>
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
										gdue=0;
										gadvance=0;
										student_id="";
										sname="";
										bool flag=false;
										int i=1;
										if(DropClass.SelectedIndex!=0)
										{
											if(!Txtfromdate.Text.Equals("")&&!Txttodate.Text.Equals("")&&!Txtcurdatef.Text.Equals("")&&!Txtcurdatet.Text.Equals(""))
											{
												DateTime period1=System.Convert.ToDateTime(ToMMddYYYY(Txtcurdatef.Text));
												DateTime periodto1=System.Convert.ToDateTime(ToMMddYYYY(Txtcurdatet.Text));
												DateTime period2=System.Convert.ToDateTime(ToMMddYYYY(Txtfromdate.Text));
												DateTime periodto2=System.Convert.ToDateTime(ToMMddYYYY(Txttodate.Text));
												System.TimeSpan diff2=period2.Subtract(period1);
												int idays2=diff2.Days;
												System.TimeSpan diff3=periodto2.Subtract(periodto1);
												int idays3=diff3.Days;
												System.TimeSpan diff4=period2.Subtract(periodto1);
												int idays4=diff4.Days;
												if(idays2<=0||idays3<=0||idays4<=0)
												{
													MessageBox.Show("Please Enter a valid advance duration"); 
													//return ;
												}
												else
												{
													if(DropClass.SelectedItem.Value.ToString().Equals("All"))
													{
														//strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where period='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"'))";  
														//strSelect ="select * from recuringreceipt where  FeeSubdt between'"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and GenUtil.str2MMDDYYYY(Txttodate.Text) and student_id in (select student_id from student_record)";
														//02.02.08--strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')) order by student_class,seq_student_id,student_fname";  
														strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')) and student_id not in (select student_id from tc1) order by student_class,seq_student_id,student_fname";  
														SqlDtr=obj.GetRecordSet(strSelect);
														flag=true;
													}
													else
													{
														//strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where period='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"'";  
														//feesubdt beetween '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"'))";  
														//strSelect ="select * from recuringreceipt where  FeeSubdt between'"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and GenUtil.str2MMDDYYYY(Txttodate.Text) and student_id in (select student_id from student_record where student_class='"+ DropClass.SelectedItem.Text.Trim()+"' and Seq_Student_id='"+DropSection.SelectedItem.Text.Trim()+"')";
														//strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where period='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"'"; 
														//02.02.08--strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"'  order by student_class,seq_student_id,student_fname";   
														strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' and student_id not in (select student_id from tc1) order by student_class,seq_student_id,student_fname";   
														SqlDtr=obj.GetRecordSet(strSelect);
														flag=true;
													}
													if(flag==true)
													{
														if(SqlDtr.HasRows)
														{
															%>
								<tr>
									<td align="center" colSpan="22">Advance</td>
								</tr>
								<%
															while(SqlDtr.Read())
															{
																student_id=SqlDtr.GetValue(0).ToString().Trim();
																feesdecisionmonthly(student_id);
																%>
								<tr class="datagriditem">
									<td align="center"><%=i.ToString()%></td>
									<td align="center"><%=recid.ToString()%></td>
									<td><%=recdate.ToString()%></td>
									<td align="center"><%=student_id.ToString()%></td>
									<td align="center"><%=category.ToString()%></td>
									<td><%=sname.ToString()%></td>
									<td align="right"><%=tutionfee.ToString()%></td>
									<td align="right"><%=computerfee.ToString()%></td>
									<td align="right"><%=housefee.ToString()%></td>
									<td align="right"><%=gamefee.ToString()%></td>
									<td align="right"><%=sciencefee.ToString()%></td>
									<td align="right"><%=registraionfee.ToString()%></td>
									<td align="right"><%=latefee.ToString()%></td>
									<td align="right"><%=admissionfee.ToString()%></td>
									<td align="right"><%=transportfee.ToString()%></td>
									<td align="right"><%=developmentfee.ToString()%></td>
									<td align="right"><%=dairyfee.ToString()%></td>
									<td align="right"><%=annualfee.ToString()%></td>
									<td align="right">0</td>
									<td align="right"><%=total.ToString()%></td>
									<td align="right"><%="N/A" %></td>
									<td align="right"><%=advance.ToString()%></td>
								</tr>
								<%
																i++;
															}
														}
														SqlDtr.Close();
													}
													flag=false;
												}
											}
											if(DropClass.SelectedItem.Value.ToString().Equals("All"))
											{
												//strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"'))";  
												//02.02.08--strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text.ToString())+"')) and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' order by student_class,seq_student_id,student_fname";//added by vishnu 15/10
												strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text.ToString())+"')) and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and student_id not in (select student_id from tc1) order by student_class,seq_student_id,student_fname";//added by vishnu 15/10
												SqlDtr=obj.GetRecordSet(strSelect);
												flag=true;
											}
											else
											{
												//strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"'";   
												//02.02.08--strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and '"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text.ToString())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' order by student_class,seq_student_id,student_fname" ;  //added by vishnu on 15/10
												strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and '"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text.ToString())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and student_id not in (select student_id from tc1) order by student_class,seq_student_id,student_fname" ;  //added by vishnu on 15/10
												SqlDtr=obj.GetRecordSet(strSelect);
												flag=true;
											}
											if(flag==true)
											{
												if(SqlDtr.HasRows)
												{
													%>
								<tr>
									<td align="center" colSpan="22">Pending</td>
								</tr>
								<%
													while(SqlDtr.Read())
													{
														student_id=SqlDtr.GetValue(0).ToString().Trim();
														feesdecisionmonthlydue(student_id);
														%>
								<tr class="datagriditem">
									<td align="center"><%=i.ToString()%></td>
									<td align="center"><%="N/A" %></td>
									<td><%="N/A" %></td>
									<td align="center"><%=student_id.ToString()%></td>
									<td align="center"><%=category.ToString()%></td>
									<td><%=sname.ToString()%></td>
									<td align="right"><%="N/A" %></td>
									<td align="right"><%="N/A" %></td>
									<td align="right"><%="N/A" %></td>
									<td align="right"><%="N/A" %></td>
									<td align="right"><%="N/A" %></td>
									<td align="right"><%="N/A" %></td>
									<td align="right"><%="N/A" %></td>
									<td align="right"><%="N/A" %></td>
									<td align="right"><%="N/A" %></td>
									<td align="right"><%="N/A" %></td>
									<td align="right"><%="N/A" %></td>
									<td align="right"><%="N/A" %></td>
									<td align="right"><%="N/A" %></td>
									<td align="right"><%=total.ToString()%></td>
									<td align="right"><%=due.ToString()%></td>
									<td align="right"><%="N/A" %></td>
								</tr>
								<%
														i++;
													}
												}
												SqlDtr.Close();
											}	
											flag=false;
										}
										///	added code for complete from here
										if(DropClass.SelectedItem.Value.ToString().Equals("All"))
										{
											///strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and r.student_id!=0 and r.student_id=s.student_id union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime)between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"')  and r1.student_id=0) order by s.student_id";
											strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"') and r.student_id!=0 and r.student_id=s.student_id and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' and regid!=0) and r1.student_id=0 and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')";
											SqlDtr=obj.GetRecordSet(strSelect);
											flag=true;
										}
										else
										{
											//strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"') and r.student_id!=0 and r.student_id=s.student_id and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' and regid!=0 ) and student_class='"+DropClass.SelectedItem.Value.ToString()+"'  and r1.student_id=0 and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"')";
											//19.09.08 strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"') and r.student_id!=0 and r.student_id=s.student_id and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' and regid!=0 ) and student_class='"+DropClass.SelectedItem.Value.ToString()+"'  and r1.student_id=0 and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')";
											strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"') and r.student_id!=0 and r.student_id=s.student_id and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')";
											SqlDtr=obj.GetRecordSet(strSelect);
											flag=true;
										}
										if(flag==true)
										{
											string str1="";
											string feetype="";
											if(SqlDtr.HasRows)
											{
												%>
								<tr>
									<td align="center" colSpan="22">Collection</td>
								</tr>
								<%
													while(SqlDtr.Read())
													{
														recid=SqlDtr.GetValue(0).ToString().Trim();
														feetype=SqlDtr.GetValue(1).ToString().Trim();
														feesdecisionmonthlycomplete(recid,feetype);
														%>
								<tr class="DataGridItem">
									<td align="center"><%=i.ToString()%></td>
									<td align="center"><%=recid.ToString()%></td>
									<td><%=recdate.ToString()%></td>
									<td align="center"><%=student_id.ToString()%></td>
									<td align="center"><%=category.ToString()%></td>
									<td><%=sname.ToString()%></td>
									<td align="right"><%=tutionfee.ToString()%></td>
									<td align="right"><%=computerfee.ToString()%></td>
									<td align="right"><%=housefee.ToString()%></td>
									<td align="right"><%=gamefee.ToString()%></td>
									<td align="right"><%=sciencefee.ToString()%></td>
									<td align="right"><%=registraionfee.ToString()%></td>
									<td align="right"><%=latefee.ToString()%></td>
									<td align="right"><%=admissionfee.ToString() %></td>
									<td align="right"><%=transportfee.ToString() %></td>
									<td align="right"><%=developmentfee.ToString()%></td>
									<td align="right"><%=dairyfee.ToString()%></td>
									<td align="right"><%=annualfee.ToString()%></td>
									<td align="right"><%=security.ToString()%></td>
									<td align="right"><%=total.ToString()%></td>
									<td align="right"><%="N/A"%></td>
									<td align="right"><%="N/A"%></td>
								</tr>
								<%
														i++;
													}
												}
												SqlDtr.Close();
											}
											%>
								<tr bgColor="#663300">
									<td colSpan="1"><b><font color="#ffffff">Grand Total</font></b></td>
									<td>&nbsp;</td>
									<td>&nbsp;</td>
									<td>&nbsp;</td>
									<td>&nbsp;</td>
									<td style="WIDTH: 103px">&nbsp;</td>
									<td align="right"><b><font color="#ffffff"><%=gtutionfee.ToString()%></font></b></td>
									<td align="right"><b><font color="#ffffff"><%=gcomputerfee.ToString()%></font></b></td>
									<td align="right"><b><font color="#ffffff"><%=ghousefee.ToString()%></font></b></td>
									<td align="right"><b><font color="#ffffff"><%=ggamefee.ToString()%></font></b></td>
									<td align="right"><b><font color="#ffffff"><%=gsciencefee.ToString()%></font></b></td>
									<td align="right"><b><font color="#ffffff"><%=gregistraionfee.ToString()%></font></b></td>
									<td align="right"><b><font color="#ffffff"><%=glatefee.ToString()%></font></b></td>
									<td align="right"><b><font color="#ffffff"><%=gadmissionfee.ToString()%></font></b></td>
									<td align="right"><b><font color="#ffffff"><%=gtransportfee.ToString()%></font></b></td>
									<td align="right"><b><font color="#ffffff"><%=gdevelopmentfee.ToString()%></font></b></td>
									<td align="right"><b><font color="#ffffff"><%=gdairyfee.ToString()%></font></b></td>
									<td align="right"><b><font color="#ffffff"><%=gannualfee.ToString()%></font></b></td>
									<td align="right"><b><font color="#ffffff"><%=gsecurity.ToString()%></font></b></td>
									<td align="right"><b><font color="#ffffff"><%=gtotal.ToString()%></font></b></td>
									<td align="right"><b><font color="#ffffff"><%=gdue.ToString()%></font></b></td>
									<td align="right"><b><font color="#ffffff"><%=gadvance.ToString()%></font></b></td>
								</tr>
								<%
									}
									catch(Exception ex)
									{
										//CreateLogFiles.ErrorLog(" Form :AdvanceFeesReceipt.aspx,Method HTML part,  Exception: "+ex.Message+" ,"" );		
									}
								}
								%>
							</TBODY>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td colSpan="3"></td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm"
				frameBorder="0" width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
