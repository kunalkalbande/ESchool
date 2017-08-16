<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Page language="c#" Codebehind="Leaveallowed.aspx.cs" AutoEventWireup="false" Inherits="eschool.Form.Leaveallowed" %>
<%@ import namespace="eschool.Classes"%>
<%@ import namespace="System.Data.SqlClient"%>
<%@ import namespace="RMG"%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Leave Sanction</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
<script language=JavaScript>

	//This method use to select the all checkboxes
	function selectAll()
	{
		var f=document.f1
		if(f.chkSelectAll.checked)
		{
			for(var i=0;i<f.length;i++)
			f.elements[i].checked=true
		}
		else
		{
			for(var i=0;i<f.length;i++)
			f.elements[i].checked=false
		}
	}
	</script>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form name="f1" id="f1" method="post" runat=server>
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table width=778 height=250 align="center">
				<TR>
					<TH align="center">
					</TH>
				</TR>
				<tr>
					<td align=center><B>LEAVE SANCTION</B>
						<table border=5 borderColorLight="#663300">
							<tr bgcolor=#663300>
								<td align="center"><b><font color=#ffffff>Employee ID</font></b></td>
								<td align="center"><b><font color=#ffffff>Name</font></b></td>
								<td align="center"><b><font color=#ffffff>From</font></b></td>
								<td align="center"><b><font color=#ffffff>To</font></b></td>
								<td align="center"><b><font color=#ffffff>Reason</font></b></td>
								<td align="center"><b><font color=#ffffff>Accept</font></b></td>
							</tr>
							<%
								EmployeeClass obj=new EmployeeClass();
								SqlDataReader SqlDtr;
								string sql;
								int Row_No=0;
								DateTime da;
								
								string str;
								string str1;
						
								DateTime dt;
								DateTime dt1;

							
								//sql="select e.emp_id, emp_name, Date_From, Date_To, Reason, isSanction from employee e, Leave_Register lr where e.emp_id= lr.emp_id  and lr.isSanction=0 order by e.emp_id";
								sql="select sl.staff_id,si.staff_name, staff_leavefromdt,staff_leavefromto, Leave_type,staffleave_id from staff_leave sl, staff_information si where si.staff_id=sl.staff_id and adjustment=0";
								SqlDtr=obj.GetRecordSet(sql);
								while(SqlDtr.Read())
								{
								
							str=SqlDtr.GetValue(2).ToString();
							dt=System.Convert.ToDateTime(str);
							str1=SqlDtr.GetValue(3).ToString();
							dt1=System.Convert.ToDateTime(str1);
							
							
							
							%>
							
							<tr>
								<td align=center>&nbsp;<%=SqlDtr.GetValue(0).ToString()%><input type=hidden name=lblEmpID<%=Row_No%> value="<%=SqlDtr.GetValue(0).ToString()%>"></td>
								<td>&nbsp;<%=SqlDtr.GetValue(1).ToString()%><input type=hidden name=lblEmpName<%=Row_No%> value="<%=SqlDtr.GetValue(1).ToString()%>"></td>
								<td>&nbsp;<%=GenUtil.str2DDMMYYYY(dt.ToString("d"))%><input type=hidden name=lblDateFrom<%=Row_No%> value="<%=dt.ToString("d")%>"></td>
								<td>&nbsp;<%=GenUtil.str2DDMMYYYY(dt1.ToString("d"))%><input type=hidden name=lblDateTo<%=Row_No%> value="<%=dt1.ToString("d")%>"></td>
								<td>&nbsp;<%=SqlDtr.GetValue(4).ToString()%><input type=hidden name=lblReason<%=Row_No%> value="<%=SqlDtr.GetValue(5).ToString()%>"></td>
								<%	//if(SqlDtr.GetValue(5).ToString()=="1")
									//{
								%>
										<td align=center><input type=checkbox name=chk<%=Row_No%>></td>
								<%	//}
									//else
									//{
								 %>
										<!--td align=center><input type=checkbox name=chk<%=Row_No%>></td-->
								<%	//}
								%>
							</tr>
							<%	Row_No++;
								}
							%>
							<tr><td colspan=5 bgcolor="#663300" align=right><input type=hidden name=lblTotal_Row value=<%=Row_No%>><font color=#ffffff><b>Select All</b></font></td><td align=center bgcolor="#663300"><input type=checkbox name=chkSelectAll onclick="selectAll();"></td></tr>
						<TR>
					<td colspan=8 align=center ><asp:Button ID=Btnsave Runat=server Text=Submit  CssClass=FormButtonStyle OnClick="save1" BorderColor=#663300 ForeColor=black Width=70></asp:Button></td>
				</TR>
						</table>
					</td>
				</tr>
				
			</table>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>
<script language=C# runat=server >

		private void Page_Load(object sender, System.EventArgs e)
		{
		/*
			try
			{
				string pass;
				pass=(Session["User_Name"].ToString());
			}
			catch
			{
				CreateLogFiles.ErrorLog ("Form: Leave_Assignment.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				//Response.Redirect("../../ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack )
			{
				//DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
			
			}
		*/	
		}
		
		/// <Summary>
		/// This method use to save information in to staff_leave with the help of 'ProLeaveUpdate' Procedure.
		/// </Summary>
		public void save1(Object sender, EventArgs e)
		{ 
			try
			{
				EmployeeClass obj=new EmployeeClass(); 
				int Total_Rows=0;
				int f=0;
				Total_Rows=System.Convert.ToInt32(Request.Params.Get("lblTotal_Row"));
				for(int i=0;i<Total_Rows;i++)
				{
					if(Request.Params.Get("Chk"+i)!=null)
					{
						obj.Emp_Name=Request.Params.Get("lblReason"+i); 
						obj.Date_From=Request.Params.Get("lblDateFrom"+i); 
						obj.Date_To=Request.Params.Get("lblDateTo"+i); 
						obj.Reason=Request.Params.Get("lblReason"+i); 
						obj.isSanction="1";
						obj.UpdateLeave(); 
						f =1;
						CreateLogFiles.ErrorLog("Form:Leave_Assignment.aspx,Method:save1().  Leave Sanctioned for employee "+Request.Params.Get("lblEmpName"+i)+" of date from "+Request.Params.Get("lblDateFrom"+i)+" to date "+Request.Params.Get("lblDateTo"+i)+".  USERID  "+ Session["password"]);
					}
					else
					{
			
					}
				}
				if(f == 1)
					MessageBox.Show("Leave Sanctioned"); 
				else
					MessageBox.Show("Data Not Available"); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Leave_Assignment.aspx,Method:save1().  Exception: "+ex.Message+"  USERID  "+Session["password"]);
			}
		}
</script>
