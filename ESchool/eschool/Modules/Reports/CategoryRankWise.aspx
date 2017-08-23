<%@ Import namespace="RMG"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="DBOperations"%>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Page language="c#" Codebehind="CategoryRankWise.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.CategoryRankWise" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Student Strength Report</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
				</tr>
				<tr>
					<td align="center"><B>STUDENT STRENGTH REPORT</B>
						<%
				
				double gTotal=0,ggt=0,gtransport=0,gtt=0,gcomputer=0;		
		try
		{
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"],true);
		InventoryClass obj=new InventoryClass();
		SqlDataReader rdr,rdr1=null,rdr2=null,rdr3=null,rdr4=null,rdr5=null,rdr6=null,rdr7=null,rdr8=null,rdr9=null,rdr10=null,rdr11=null,rdr12=null,rdr13=null;
		string str="";%>
						<table cellSpacing="1" cellPadding="0" width="90%" align="center" borderColorLight="#663300"
							border="5">
							<tr bgcolor="#663300">
								<th align="center">
									<b><font color="#ffffff">SNO</font></b></th>
								<th align="center">
									<b><font color="#ffffff">CLASS</font></b></th>
								<th align="center">
									<b><font color="#ffffff">SECTION</font></b></th>
								<!--th align="center">
									MWO</th>
								<th align="center">
									SGT</th>
								<th align="center">
									NCE</th>
								<th align="center">
									AFO</th>
								<th align="center">
									CIV</th>
								<th align="center">
									STAFF</th>
								<th align="center">
									EX.IAF</th>
								<th align="center">
									MES</th>
								<th align="center">
									AFCIF</th-->
								<%dbobj.SelectQuery("select distinct catname from category",ref rdr13);
								while(rdr13.Read())
								{%>
								<th align="center">
									<b><font color="#ffffff">
											<%=rdr13.GetValue(0).ToString()%>
										</font></b>
								</th>
								<%}%>
								<th align="center">
									<b><font color="#ffffff">TOTAL</font></b></th>
								<th align="center">
									<b><font color="#ffffff">G.T.</font></b></th>
								<th align="center">
									<b><font color="#ffffff">TRANSPORT</font></b></th>
								<th align="center">
									<b><font color="#ffffff">T.T</font></b></th>
								<th align="center">
									<b><font color="#ffffff">COMPUTER</font></b></th></tr>
							<%
		str="select class_name from class";
		rdr = obj.GetRecordSet(str);
		int i=1;
		while(rdr.Read())
		{
			//int gt1=0,gt2=0,gt3=0,gt4=0;
			//double tt1=0,tt2=0,tt3=0,tt4=0,Tot=0;
			double tt=0,Tot=0;
			dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='A'",ref rdr1);
			//22.02.08--dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='A' and routeno<>0 and student_id not in (select student_id from tc1)",ref rdr11);
			//22.02.08--dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='A' and computer='Yes' and student_id not in (select student_id from tc1)",ref rdr12);
			dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='A' and routeno<>0 and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr11);
			dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='A' and computer='Yes' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr12);
			//rankTotal=new int[int.Parse(rdr4.Read().ToString())];
			if(rdr1.Read())
			{
		%>
							<tr>
								<td align="center"><%=i++%></td>
								<td align="center"><%=rdr1["Student_Class"].ToString()%></td>
								<td align="center"><%=rdr1["Seq_Student_ID"].ToString()%></td>
								<%
					double Total=0;
					dbobj.SelectQuery("select distinct catname from category",ref rdr3);
					while(rdr3.Read()){
					//22.02.08--dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='A' and scategory='"+rdr3.GetValue(0).ToString()+"'and student_id not in (select student_id from tc1)",ref rdr4);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='A' and scategory='"+rdr3.GetValue(0).ToString()+"'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr4);
					int l=0;
					if(rdr4.Read()){
		%>
								<td align="center"><%=rdr4.GetValue(0).ToString()%><%if(rdr4.GetValue(0).ToString()!="")Total+=double.Parse(rdr4.GetValue(0).ToString());
								//MessageBox.Show("Total"+double.Parse(rdr4.GetValue(0).ToString()));
								%></td>
								<%}else{%>
								<td align="center">&nbsp;</td>
								<%}}%>
								<td align="center"><%=Total.ToString()%><%Tot+=Total;gTotal+=Total;%></td>
								<%dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='B' or seq_student_id='C' or seq_student_id='D' or seq_student_id='E')",ref rdr5);
					if(rdr5.Read()==false){
					%>
								<td align="center"><%=Tot%></td>
								<%}else{%>
								<td>&nbsp;</td>
								<%			}
							
							
							
					if(rdr11.Read())
					{
						tt+=double.Parse(rdr11.GetValue(0).ToString());
						gtransport+=double.Parse(rdr11.GetValue(0).ToString());
		%>
								<td align="center"><%=rdr11.GetValue(0).ToString()%></td>
								<%
					}
					else
					{
		%>
								<td align="center">0</td>
								<%
					}
		%>
								<%dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='B' or seq_student_id='C' or seq_student_id='D' or seq_student_id='E')",ref rdr5);
					if(rdr5.HasRows==false){
					%>
								<td align="center"><%=tt%></td>
								<%}else{%>
								<td>&nbsp;</td>
								<%}if(rdr12.Read()){%>
								<td align="center"><%=rdr12.GetValue(0).ToString()%><%gcomputer+=double.Parse(rdr12.GetValue(0).ToString());%></td>
								<%}%>
							</tr>
							<%dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='B' or seq_student_id='C' or seq_student_id='D' or seq_student_id='E')",ref rdr5);
					if(rdr5.HasRows==false){
					%>
							<tr>
							</tr>
							<%}%>
							<%
			}
			dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='B'",ref rdr1);
			//22.02.08--dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='B' and routeno<>0 and student_id not in (select student_id from tc1)",ref rdr11);
			//22.02.08--dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='B' and computer='Yes'and student_id not in (select student_id from tc1)",ref rdr12);
			dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='B' and routeno<>0 and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr11);
			dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='B' and computer='Yes'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr12);
			if(rdr1.Read())
			{
		%>
							<tr>
								<td align="center"><%=i++%></td>
								<td align="center"><%=rdr1["Student_Class"].ToString()%></td>
								<td align="center"><%=rdr1["Seq_Student_ID"].ToString()%></td>
								<%
					double Total=0;
					dbobj.SelectQuery("select distinct catname from category",ref rdr3);
					while(rdr3.Read()){
					//22.02.08--dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='B' and scategory='"+rdr3.GetValue(0).ToString()+"'and student_id not in (select student_id from tc1)",ref rdr4);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='B' and scategory='"+rdr3.GetValue(0).ToString()+"'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr4);
					
					if(rdr4.Read()){
		%>
								<td align="center"><%=rdr4.GetValue(0).ToString()%><%if(rdr4.GetValue(0).ToString()!="") Total+=double.Parse(rdr4.GetValue(0).ToString());%></td>
								<%}else{%>
								<td align="center">&nbsp;</td>
								<%}}%>
								<td align="center"><%=Total.ToString()%><%Tot+=Total;gTotal+=Total;%></td>
								<%dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='C' or seq_student_id='D' or seq_student_id='E')",ref rdr5);
					if(rdr5.Read()==false){
					%>
								<td align="center"><%=Tot%></td>
								<%}else{%>
								<td>&nbsp;</td>
								<%			}
					if(rdr11.Read())
					{
						tt+=double.Parse(rdr11.GetValue(0).ToString());
						gtransport+=double.Parse(rdr11.GetValue(0).ToString());
		%>
								<td align="center"><%=rdr11.GetValue(0).ToString()%></td>
								<%
					}
					else
					{
		%>
								<td align="center">0</td>
								<%
					}
		%>
								<%dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='C' or seq_student_id='D' or seq_student_id='E')",ref rdr5);
					if(rdr5.HasRows==false){
					%>
								<td align="center"><%=tt%></td>
								<%}else{%>
								<td>&nbsp;</td>
								<%}if(rdr12.Read()){%>
								<td align="center"><%=rdr12.GetValue(0).ToString()%><%gcomputer+=double.Parse(rdr12.GetValue(0).ToString());%></td>
								<%}%>
							</tr>
							<%dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='C' or seq_student_id='D' or seq_student_id='E')",ref rdr5);
					if(rdr5.HasRows==false){
					%>
							<tr>
								<td></td>
							</tr>
							<%}%>
							<%
			}
			dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='C'",ref rdr1);
			//22.02.08--dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='C' and routeno<> 0 and student_id not in (select student_id from tc1)",ref rdr11);
			//22.02.08--dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='C' and computer='Yes' and student_id not in (select student_id from tc1)",ref rdr12);
			dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='C' and routeno<> 0 and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr11);
			dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='C' and computer='Yes' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr12);
			if(rdr1.Read())
			{
		%>
							<tr>
								<td align="center"><%=i++%></td>
								<td align="center"><%=rdr1["Student_Class"].ToString()%></td>
								<td align="center"><%=rdr1["Seq_Student_ID"].ToString()%></td>
								<%
					double Total=0;
					dbobj.SelectQuery("select distinct catname from category",ref rdr3);
					while(rdr3.Read()){
					//22.02.08--dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='C' and scategory='"+rdr3.GetValue(0).ToString()+"'and student_id not in (select student_id from tc1)",ref rdr4);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='C' and scategory='"+rdr3.GetValue(0).ToString()+"'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr4);
					if(rdr4.Read()){
		%>
								<td align="center"><%=rdr4.GetValue(0).ToString()%><%if(rdr4.GetValue(0).ToString()!="") Total+=double.Parse(rdr4.GetValue(0).ToString());%></td>
								<%}else{%>
								<td align="center">&nbsp;</td>
								<%}}%>
								<td align="center"><%=Total.ToString()%><%Tot+=Total;gTotal+=Total;%></td>
								<%dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='D' or seq_student_id='E')",ref rdr5);
					if(rdr5.Read()==false){
					%>
								<td align="center"><%=Tot%></td>
								<%}else{%>
								<td>&nbsp;</td>
								<%			}
					if(rdr11.Read())
					{
						tt+=double.Parse(rdr11.GetValue(0).ToString());
						gtransport+=double.Parse(rdr11.GetValue(0).ToString());
		%>
								<td align="center"><%=rdr11.GetValue(0).ToString()%></td>
								<%
					}
					else
					{
		%>
								<td align="center">0</td>
								<%
					}
		%>
								<%dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='D' or seq_student_id='E')",ref rdr5);
					if(rdr5.HasRows==false){
					%>
								<td align="center"><%=tt%></td>
								<%}else{%>
								<td>&nbsp;</td>
								<%}if(rdr12.Read()){%>
								<td align="center"><%=rdr12.GetValue(0).ToString()%><%gcomputer+=double.Parse(rdr12.GetValue(0).ToString());%></td>
								<%}%>
							</tr>
							<%dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='D' or seq_student_id='E')",ref rdr5);
					if(rdr5.HasRows==false){
					%>
							<tr>
								<td></td>
							</tr>
							<%}%>
							<%
			}
			dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='D'",ref rdr1);
			//22.02.08--dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='D' and routeno<>0 and student_id not in (select student_id from tc1)",ref rdr11);
			//22.02.08--dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='D' and computer='Yes'and student_id not in (select student_id from tc1)",ref rdr12);
			dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='D' and routeno<>0 and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr11);
			dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='D' and computer='Yes'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr12);
			if(rdr1.Read())
			{
		%>
							<tr>
								<td align="center"><%=i++%></td>
								<td align="center"><%=rdr1["Student_Class"].ToString()%></td>
								<td align="center"><%=rdr1["Seq_Student_ID"].ToString()%></td>
								<%
					double Total=0;
					dbobj.SelectQuery("select distinct catname from category",ref rdr3);
					while(rdr3.Read()){
					//22.02.08--dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='D' and scategory='"+rdr3.GetValue(0).ToString()+"'and student_id not in (select student_id from tc1)",ref rdr4);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='D' and scategory='"+rdr3.GetValue(0).ToString()+"'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr4);
					if(rdr4.Read()){
		%>
								<td align="center"><%=rdr4.GetValue(0).ToString()%><%if(rdr4.GetValue(0).ToString()!="") Total+=double.Parse(rdr4.GetValue(0).ToString());%></td>
								<%}else{%>
								<td align="center">&nbsp;</td>
								<%}}%>
								<td align="center"><%=Total.ToString()%><%Tot+=Total;gTotal+=Total;%></td>
								<%dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E'",ref rdr5);
					if(rdr5.Read()==false){
					%>
								<td align="center"><%=Tot%></td>
								<%}else{%>
								<td>&nbsp;</td>
								<%			}
					
					if(rdr11.Read())
					{
						tt+=double.Parse(rdr11.GetValue(0).ToString());
						gtransport+=double.Parse(rdr11.GetValue(0).ToString());
		%>
								<td align="center"><%=rdr11.GetValue(0).ToString()%></td>
								<%
					}
					else{
		%>
								<td align="center">0</td>
								<%}
		%>
								<%dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E'",ref rdr5);
					if(rdr5.HasRows==false){
					%>
								<td align="center"><%=tt%></td>
								<%}else{%>
								<td>&nbsp;</td>
								<%}if(rdr12.Read()){%>
								<td align="center"><%=rdr12.GetValue(0).ToString()%><%gcomputer+=double.Parse(rdr12.GetValue(0).ToString());%></td>
								<%}%>
							</tr>
							<%dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E'",ref rdr5);
					if(rdr5.HasRows==false){
					%>
							<tr>
								<td></td>
							</tr>
							<%}%>
							<%
			}
			dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E'",ref rdr1);
			//22.02.08--dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E' and routeno<>0 and student_id not in (select student_id from tc1)",ref rdr11);
			//22.02.08--dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E' and computer='Yes' and student_id not in (select student_id from tc1)",ref rdr12);
			dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E' and routeno<>0 and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr11);
			dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E' and computer='Yes' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr12);
			if(rdr1.Read())
			{
		%>
							<tr>
								<td align="center"><%=i++%></td>
								<td align="center"><%=rdr1["Student_Class"].ToString()%></td>
								<td align="center"><%=rdr1["Seq_Student_ID"].ToString()%></td>
								<%
					double Total=0;
					dbobj.SelectQuery("select distinct catname from category",ref rdr3);
					while(rdr3.Read()){
					//22.02.08--dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E' and scategory='"+rdr3.GetValue(0).ToString()+"' and student_id not in (select student_id from tc1)",ref rdr4);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E' and scategory='"+rdr3.GetValue(0).ToString()+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr4);
					if(rdr4.Read()){
		%>
								<td align="center"><%=rdr4.GetValue(0).ToString()%><%if(rdr4.GetValue(0).ToString()!="") Total+=double.Parse(rdr4.GetValue(0).ToString());%></td>
								<%}else{%>
								<td align="center">&nbsp;</td>
								<%}}%>
								<td align="center"><%=Total.ToString()%><%Tot+=Total;gTotal+=Total;%></td>
								<%dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='F'",ref rdr5);
					if(rdr5.Read()==false){
					%>
								<td align="center"><%=Tot%></td>
								<%}else{%>
								<td>&nbsp;</td>
								<%			}
					if(rdr11.Read())
					{
						tt+=double.Parse(rdr11.GetValue(0).ToString());
						gtransport+=double.Parse(rdr11.GetValue(0).ToString());
		%>
								<td align="center"><%=rdr11.GetValue(0).ToString()%></td>
								<%
					}
					else
					{
		%>
								<td align="center">0</td>
								<%
					}
		%>
								<%dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='F'",ref rdr5);
					if(rdr5.HasRows==false){
					%>
								<td align="center"><%=tt%></td>
								<%}else{%>
								<td>&nbsp;</td>
								<%}if(rdr12.Read()){%>
								<td align="center"><%=rdr12.GetValue(0).ToString()%><%gcomputer+=double.Parse(rdr12.GetValue(0).ToString());%></td>
								<%}%>
							</tr>
							<%dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='F'",ref rdr5);
					if(rdr5.HasRows==false){
					%>
							<tr>
								<td></td>
							</tr>
							<%}%>
							<%
			}			
		}
			//**********************************
			
			
		rdr.Close();
		}
		catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: CategoryRankWise.aspx, Method: ASP/HTML CODING. Exception: " + ex.Message + " User: " + Session["password"] );
			}
			%>
							<tr>
								<td>Total</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<%
			try
			{
			DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"],true);
	    	InventoryClass obj1=new InventoryClass();
		    SqlDataReader rdr14=null,rdr=null;
		    dbobj.SelectQuery("select distinct catname from category",ref rdr14);
								while(rdr14.Read())
								{
									 //22.02.08--dbobj.SelectQuery("select count(*) from student_record where scategory='"+rdr14.GetValue(0).ToString()+"' and student_id not in (select student_id from tc1)",ref rdr);
									 dbobj.SelectQuery("select count(*) from student_record where scategory='"+rdr14.GetValue(0).ToString()+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr);
									 if(rdr.Read())
									{
								%>
								<td align="center"><%=rdr.GetValue(0).ToString()%>
								</td>
								<%}
								}%>
								<td align="center"><%=gTotal%></td>
								<td align="center"><%=gTotal%></td>
								<td align="center"><%=gtransport%></td>
								<td align="center"><%=gtransport%></td>
								<td align="center"><%=gcomputer%></td>
								<%}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: CategoryRankWise.aspx, Method: ASP/HTML CODING. Exception: " + ex.Message + " User: " + Session["password"] );
			}
			%>
							</tr>
							<tr>
								<td align="center" colSpan="17"><asp:button id="btnPrint" Runat="server" Height="21" Width="85px" CssClass="formbuttonstyle"
										Text="Print" BorderColor="Black" Font-Size="X-Small"></asp:button>&nbsp;&nbsp;&nbsp;
									<asp:button id="btnexcel" Runat="server" Width="85" Height="21" CssClass="formbuttonstyle" Text="Excel"
										BorderColor="Black" Font-Size="X-Small"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
