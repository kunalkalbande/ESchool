<%@ Page language="c#" Codebehind="SetStudentRollNo.aspx.cs" AutoEventWireup="false" Inherits="eschool.Form.SetStudentRollNo_" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="DBOperations"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="RMG"%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Set Student Roll No</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			
			<table height="250" width="778" align="center" >
					<tr>
					<td align=center><b>SET STUDENT ROLL NO</b>
						<table cellpadding=1 cellspacing=1 align="center" border="5"  borderColorLight="#663300">
						<tr><td><table>
							<tr>
								<td colspan=20>&nbsp;&nbsp;
								Class&nbsp;<font color=red size=1>*</font>&nbsp;<asp:DropDownList CssClass="ComboBox" ID="DropClass" Runat="server"></asp:DropDownList>
								<asp:CompareValidator ID=compvali1 Runat=server ValueToCompare=Select ControlToValidate=DropClass Operator=NotEqual ErrorMessage="Please Select Class">&nbsp;*</asp:CompareValidator>
								&nbsp;&nbsp;Section&nbsp;<font color=red size=1>*</font>&nbsp;<asp:DropDownList CssClass="ComboBox" ID="DropSection" Runat="server">
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
											<asp:ListItem Value="J">j</asp:ListItem></asp:DropDownList>
											<asp:CompareValidator ID="Compvali2" Runat=server ValueToCompare=Select ControlToValidate=DropSection Operator=NotEqual ErrorMessage="Please Select Section">&nbsp;*</asp:CompareValidator>
								&nbsp;&nbsp;Stream&nbsp;&nbsp;<asp:DropDownList CssClass="ComboBox" ID="DropStream" Runat="server">
											<asp:ListItem Value="None">None</asp:ListItem>
											<asp:ListItem Value="Bio Group">Bio Group</asp:ListItem>
											<asp:ListItem Value="Commerce Group">Commerce Group</asp:ListItem>
											<asp:ListItem Value="Math Group">Math Group</asp:ListItem>
											</asp:DropDownList>
											
								&nbsp;&nbsp;Session&nbsp;<font color=red size=1>*</font>&nbsp;<asp:dropdownlist CssClass="ComboBox" id="DropSession" Runat="server" AutoPostBack=False>
											<asp:ListItem Value="Select">Select</asp:ListItem>
											<asp:ListItem Value="2006:2007">2006:2007</asp:ListItem>
											<asp:ListItem Value="2007:2008">2007:2008</asp:ListItem>
											<asp:ListItem Value="2008:2009">2008:2009</asp:ListItem>
											<asp:ListItem Value="2009:2010">2009:2010</asp:ListItem>
											<asp:ListItem Value="2010:2011">2010:2011</asp:ListItem>
											<asp:ListItem Value="2011:2012">2011:2012</asp:ListItem>
											<asp:ListItem Value="2012:2013">2012:2013</asp:ListItem>
											<asp:ListItem Value="2013:2014">2013:2014</asp:ListItem>
											<asp:ListItem Value="2014:2015">2014:2015</asp:ListItem>
											<asp:ListItem Value="2015:2016">2015:2016</asp:ListItem>
											<asp:ListItem Value="2016:2017">2016:2017</asp:ListItem>
											<asp:ListItem Value="2017:2018">2017:2018</asp:ListItem>
											<asp:ListItem Value="2018:2019">2018:2019</asp:ListItem>
											<asp:ListItem Value="2019:2020">2019:2020</asp:ListItem>
											<asp:ListItem Value="2020:2021">2020:2021</asp:ListItem>
										</asp:dropdownlist>
										<asp:CompareValidator ID="Compvali3" Runat=server ValueToCompare=Select ControlToValidate=DropSession Operator=NotEqual ErrorMessage="Please Select Session">&nbsp;*</asp:CompareValidator></td></tr>
										<tr><td colspan=20 align=center>
										&nbsp;&nbsp;<asp:Button ID=btnShow Runat=server CssClass=formbuttonstyle Text=Show></asp:Button>
										&nbsp;&nbsp;<asp:Button ID="btnSubmit" Runat=server CssClass=formbuttonstyle Text=Submit OnClick="update"></asp:Button>
										&nbsp;&nbsp;<asp:ValidationSummary ID=Summary1 Runat=server ShowMessageBox=True ShowSummary=False></asp:ValidationSummary></td></tr></table>
							<%
							InventoryClass obj=new InventoryClass();
							InventoryClass obj1=new InventoryClass();
							SqlDataReader SqlDtr=null,rdr=null; 
							string sql,str;
							%>					
							<%
							int i=0;
							if(DropClass.SelectedIndex!=0)
							{
								//11.03.08--sql="select * from Student_Record where Student_Class='"+DropClass.SelectedItem.Text+"' and Student_Stream='"+DropStream.SelectedItem.Text+"' and Seq_Student_ID='"+DropSection.SelectedItem.Text+"' order by Student_FName";
								sql="select * from Student_Record where Student_Class='"+DropClass.SelectedItem.Text+"' and Student_Stream='"+DropStream.SelectedItem.Text+"' and Seq_Student_ID='"+DropSection.SelectedItem.Text+"' and Year='"+DropSession.SelectedItem.Text+"' order by Student_FName";
								SqlDtr=obj.GetRecordSet(sql);
								
								if(SqlDtr.HasRows) 
								{
									%>
									<table border=1 bordercolor=#663300 width=100%>
									<tr bgcolor=#663300>
										<th colspan=4 width=20%><font color=#ffffff>Student ID</font></th>
										<th colspan=4 width=20%><font color=#ffffff>Roll No</font></th>
										<th colspan=12 width=60%><font color=#ffffff>Student Name</font></th>
									</tr>
								<%
									while(SqlDtr.Read())
									{
										//11.03.08--str="select RollNo from student_roll where studentid='"+SqlDtr["Student_ID"].ToString()+"'";
										str="select RollNo from student_roll where studentid='"+SqlDtr["Student_ID"].ToString()+"' and Year='"+DropSession.SelectedItem.Text+"'";
										rdr=obj1.GetRecordSet(str);
										%>
										<tr>
											<td colspan=4 align=center>&nbsp;<%=SqlDtr["Student_ID"].ToString()%><input type=hidden name="txtsid<%=i%>" value="<%=SqlDtr["Student_ID"].ToString()%>"></td>
											<%
											if(rdr.Read())
											{
												%>						
												<td colspan=4><input type=text value="<%=rdr["RollNo"].ToString()%>" name="txtRollNo<%=i%>" onkeypress="return GetOnlyNumbers(this, event, true,true);" size=10 style="BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"></td>
												<%
											}
											else
											{
												%>
												<td colspan=4><input type=text name="txtRollNo<%=i%>" onkeypress="return GetOnlyNumbers(this, event, true,true);" size=10 style="BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove" ></td>
												<%
											}
											rdr.Close();
											%>
											<td colspan=12>&nbsp;&nbsp;<%=SqlDtr["Student_FName"].ToString()%><input type=hidden name="txtsname<%=i%>" value="<%=SqlDtr["Student_FName"].ToString()%>"></td>
										</tr>
										<%
										i++;
									}
									%>
								
							<%
								}
								else
								{
									MessageBox.Show("Data Not Available");
									//return;
								}
								SqlDtr.Close();
								
							}
							%>
							</table>
							</td></tr>
						</table>
					</td>
				</tr>
				<tr>
				<td colspan=6><input type=hidden name=count value="<%=i%>"></td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer>
		</form>
	</body>
</HTML>
<script language=C# runat =server >

/// <Summary>
/// This Method use to save the roll number of student with the help of InsertStudentRollNo(). and also use 'ProUpdateStudentRollNo' procedure.
/// </Summary>
public void update(Object sender, EventArgs e )
{  
	try
    {
		InventoryClass obj=new InventoryClass(); 
		SqlDataReader SqlDtr;
		//string sid="",class="",stream="",sec="",name="";
		int count=System.Convert.ToInt32(Request.Params.Get("count"));
		for(int i=0;i<count;i++)
		{
			obj.Student_ID=Request.Params.Get("txtsid"+i);
			//obj.Class=Request.Params.Get("txtsclass"+i);
			obj.Class=DropClass.SelectedItem.Text;
			obj.StudentName=Request.Params.Get("txtsname"+i);
			//obj.Section=Request.Params.Get("txtssec"+i);
			obj.Section=DropSection.SelectedItem.Text;
			obj.RoleNo=Request.Params.Get("txtRollNo"+i);
			//obj.Stream=Request.Params.Get("txtsstream"+i);
			obj.Stream=DropStream.SelectedItem.Text;
			obj.Year=DropSession.SelectedItem.Text;
			obj.InsertStudentRollNo();
		}
		MessageBox.Show("Student Roll No. Successfully Set");
		DropClass.SelectedIndex=0;
		DropStream.SelectedIndex=0;
		DropSession.SelectedIndex=0;
		DropSection.SelectedIndex=0;
	}
	catch(Exception ex)
	{
	    CreateLogFiles.ErrorLog ("Form: SetStudentRollNo.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + Session["password"] );
	}
}

</script>