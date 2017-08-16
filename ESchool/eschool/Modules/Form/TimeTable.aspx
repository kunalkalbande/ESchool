<%@ Page language="c#" Codebehind="TimeTable.aspx.cs" AutoEventWireup="false" Inherits="eschool.Form.TimeTable" %>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="DBOperations"%>
<%@ Import namespace="eschool.Classes"%> 
<%@ Import namespace="RMG"%>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %> 
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<html>
<HEAD>
<title>eSchool : Teacher Time Table</title>
		<script language=javascript>
		//this method use to check the in textbox first latter must be numeric.
	function Check(t)
	{
		var name=new String(t.value);
		var flag=false;
		//alert("Name:"+name);
		//alert("Search:"+name.indexOf(" "));
		if(name.charAt(0)=="1")
		{
			flag=true; 
		}
		else if(name.charAt(0)=="2")
		{
			flag=true;
		}
		else if(name.charAt(0)=="3")
		{
			flag=true;
		}
		else if(name.charAt(0)=="4")
		{
			flag=true;
		}
		else if(name.charAt(0)=="5")
		{
			flag=true;
		}
		else if(name.charAt(0)=="6")
		{
			flag=true;
		}
		else if(name.charAt(0)=="7")
		{
			flag=true;
		}
		else if(name.charAt(0)=="8")
		{
			flag=true;
		}
		else if(name.charAt(0)=="9")
		{
			flag=true;
		}
		else
		{
			flag=false;
		}
		if(name.indexOf(" ")>0)
		{
			alert("Space not allowed");
			alert("Please Insert as 1Ahindi");
			t.value="";
		}
		if(flag==false)
		{
			alert("Not allowed");
			alert("Please Insert as 1Ahindi first character must be a digit");
			t.value="";
		}
	}

</script>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<LINK rel="stylesheet" type="text/css" href="../../HeaderFooter/shareables/Style/Styles.css">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
		<uc1:Header id="Header1" runat="server"></uc1:Header>
			<% 
				DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"],true);
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr=null,rdr=null;
				string sql;
				int Prod_No=0,Group=1,Count=0,pp=0;
			%>
			<table width="778" height=250 align="center">
				<tr><td><asp:label id="tcid" runat="server"  Visible=False ForeColor="Red"></asp:Label></td>
				</tr>
				<tr>
					<td align=center><b>TEACHER TIME TABLE</b>
					<table align="center" borderColorLight="#663300" border="5">
						<tr>
							<td>
								<table>
									<tr>
										<td>Designation&nbsp;<font color=red size=1>*</font></td>
										<td><asp:DropDownList CssClass="ComboBox" ID=DropDesign Runat=server Width=150></asp:DropDownList><asp:CompareValidator ID=validat1 Runat=server ControlToValidate=DropDesign ValueToCompare=Select ErrorMessage="Please Select Designation" Operator=NotEqual>*</asp:CompareValidator></td>
										<td>
											<asp:Button ID=btnShow Runat=server Text="Show" Width=70 CssClass=formbuttonstyle></asp:Button>&nbsp;
											<asp:Button ID="btnSubmit" Runat=server Text="Submit" Width=70 CssClass=formbuttonstyle OnClick="update"></asp:Button>
											<asp:ValidationSummary ShowSummary=False ID=summary1 Runat=server ShowMessageBox=True></asp:ValidationSummary>
										</td>
									</tr>
								</table>
							</td>
						</tr>
						
								<%
									string[] no_of_teacher=obj.GetTeacher(DropDesign.SelectedItem.Text);
									string[] no_of_teacherID=obj.GetTeacherID(DropDesign.SelectedItem.Text);
									string[] Days={"Mon1","Mon2","Mon3","Mon4","Mon5","Mon6","Mon7","Mon8","Tues1","Tues2","Tues3","Tues4","Tues5","Tues6","Tues7","Tues8","Wed1","Wed2","Wed3","Wed4","Wed5","Wed6","Wed7","Wed8","Thu1","Thu2","Thu3","Thu4","Thu5","Thu6","Thu7","Thu8","Fri1","Fri2","Fri3","Fri4","Fri5","Fri6","Fri7","Fri8","Sat1","Sat2","Sat3","Sat4","Sat5","Sat6","Sat7","Sat8"};
									if(DropDesign.SelectedIndex!=0)
									{
										%>
										<tr>
											<td>
												<table cellpadding=0 cellspacing=0>
													<tr bgcolor=#663300>
														<td align=center><b><font color=#ffffff><asp:Label ID=lblteachername Runat=server Width=150>Teacher Name</asp:Label></font></b></td>
														<td align=center><b><font color=#ffffff>Teacher Code</font></b></td>
														<%
														for(int j=0;j<Days.Length;j++)
														{
															%>
															<td align=center><b><font color= #ffffff><%=Days[j]%></font></b></td>
															<%
															Group=2;
														}
														if(Group==1)
														{
															MessageBox.Show("Student Record Not Available");
															return;
														}
														%>
													</tr>
													<%
													//for(int k=0,i=1;k<no_of_teacher.Length;k++,i++)
													for(int k=0,i=1;k<no_of_teacher.Length;k++)
													{
													 %>
													 <tr>
														<td>&nbsp;<%=no_of_teacher[k].ToString()%><input  type=hidden name=txtteachername<%=k%> value="<%=no_of_teacherID[k]%>"></td>
														<%
														//string str="select * from TeacherTimeTable where employee_id=(select staff_id from staff_information where staff_name='"+no_of_teacher[k].ToString()+"')";
														string str="select * from TeacherTimeTable where employee_id='"+no_of_teacherID[k].ToString()+"'";
														SqlDtr=obj.GetRecordSet(str);
														if(SqlDtr.Read())
														{
															%>
															<td><input type=text name=txttcode<%=k%> value="<%=SqlDtr.GetValue(i).ToString()%>" style="BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove; width:60;font-size:8pt;height:20"></td>
															<%
															for(int j=0,l=2;j<48;j++,l++)
															{
																%>
																<td><input type=text name="txtsub<%=k%>To<%=j%>" value="<%=SqlDtr.GetValue(l).ToString()%>" onchange="Check(this)" style="BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove; width:60;font-size:8pt;height:20"></td>
																<%
															}
														}
														else
														{	
															%>
															<td><input MaxLength=10 type=text name=txttcode<%=k%>  style="BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove; width:60;font-size:8pt;height:20"></td>
															<%
															//for(int j=0,l=2;j<Days.Length;j++,l++)
															for(int j=0;j<Days.Length;j++)//added by vishnu
															{
																%>
																<td><input MaxLength=10 type=text name="txtsub<%=k%>To<%=j%>" onchange="Check(this)" style="BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove; width:60;font-size:8pt;height:20"></td>
																<%
															}
														}	
														SqlDtr.Close();
														%>
													</tr>
													<%
													Group=2;
												}
												if(Group==1)
												{
													MessageBox.Show("Student Record Not Available");
													return;
												}%>
												<tr>
													<td><!--input type=hidden value=<%=no_of_teacher.Length%> name="teacher"--></td>
													<td><input type=hidden value=<%=no_of_teacherID.Length%> name="teacher"></td>
													<td><input type=hidden name=Total_Prod value=<%=Prod_No%>></td>
													<td><input type=hidden name=Total_Sub value=<%=Count%>></td>
												</tr>
											</table>
										</td>
									</tr>
										<%
									}
								%>
		
					</table>
				</td>
			</tr>
		</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
			name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
		</iframe>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>
<script language=C# runat =server >
/*
public void update(Object sender, EventArgs e )
{
	int teacher=System.Convert.ToInt32(Request.Params.Get("teacher"));
	for(int p=0;p<teacher;p++)
	{
		for(int k=0;k<10;k++)
		{
			MessageBox.Show(Request.Params.Get("sub"+p+k));
		}
	}
}*/

/// <Summary>
/// This method use to save or update the information in teachertimetable.
/// </Summary>
public void update(Object sender, EventArgs e )
{
    try
    {
		InventoryClass obj=new InventoryClass(); 
		int teacher=0,j=0,count=0,v=0;
		//int sno=Convert.ToInt32(tcid.Text);
		teacher=System.Convert.ToInt32(Request.Params.Get("teacher"));
	 
	            SqlConnection cn;
				SqlCommand cmd;
				SqlDataReader dr;
				cn=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				cn.Open();
		 //MessageBox.Show("Teachers"+teacher);
		//MessageBox.Show(Request.Params.Get("txtteachername1") );
		//for(int p=0;p<teacher;p++)
		//for(int p=0;p<9;p++)
		for(int p=0;p<(teacher);p++)
		{
		        string str="select count(*) from teachertimetable where employee_id="+Request.Params.Get("txtteachername"+p); //+" and shortname='"+Request.Params.Get("txttcode"+p)+"' and sno="+sno;
				cmd=new SqlCommand(str,cn);
				int icount=0;
                dr=cmd.ExecuteReader();
				if(dr.Read())
				{
					icount=Convert.ToInt32(dr.GetValue(0).ToString().Trim());
				}
				cmd.Dispose();
				dr.Close();
			obj.TeacherName=Request.Params.Get("txtteachername"+p);
			obj.TeacherCode=Request.Params.Get("txttcode"+p);
		
			j=0;
		
			//MessageBox.Show(Request.Params.Get("txtsub"+p+"To"+j)+ p+j);
		
			//for(int kk=0;kk<20;kk++)
			//{
			//MessageBox.Show(Request.Params.Get("txtsub"+p+kk));
			//j++;
			//}
			//	break;
			count=0;
			
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub0=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub0="";
			j++;
			
			//MessageBox.Show(Request.Params.Get("txtsub"+p+"To"+j)+ p+j);
			
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub1=Request.Params.Get("txtsub"+p+"To"+j);
				//MessageBox.Show(Request.Params.Get("txtsub"+p+"To"+j)+ p+j);
				count++;
			}
			else
				obj.sub1="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub2=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub2="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub3=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub3="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub4=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub4="";
			j++;
			
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub5=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub5="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub6=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub6="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub7=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub7="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub8=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub8="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub9=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub9="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub10=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub10="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub11=Request.Params.Get("txtsub"+p+"To"+j);
				//MessageBox.Show(Request.Params.Get("txtsub"+p+"To"+j)+ p+j);
				count++;
			}
			else
				obj.sub11="";
			j++;
			////MessageBox.Show(Request.Params.Get("txtsub"+p+"To"+j)+ p+j);
			//MessageBox.Show("J:"+ p+j);
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub12=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub12="";
			j++;
			//MessageBox.Show("J:"+ p+j);
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub13=Request.Params.Get("txtsub"+p+"To"+j);
				//MessageBox.Show("J:"+ p+j);
				
				count++;
			}
			else
				obj.sub13="";
			j++;
			//MessageBox.Show("J:"+ p+j);
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub14=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub14="";
			j++;
			//MessageBox.Show("J:"+ p+j);
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub15=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub15="";
			j++;
			//MessageBox.Show("J:"+ p+j);
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub16=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub16="";
			j++;
			//MessageBox.Show("J:"+ p+j);
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub17=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub17="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub18=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub18="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub19=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub19="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub20=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub20="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub21=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub21="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub22=Request.Params.Get("txtsub"+p+"To"+j);
				
				count++;
			}
			else
				obj.sub22="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub23=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub23="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub24=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub24="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub25=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub25="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub26=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub26="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub27=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub27="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub28=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub28="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub29=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub29="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub30=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub30="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub31=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub31="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub32=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub32="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub33=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub33="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub34=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub34="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub35=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub35="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub36=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub36="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub37=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub37="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub38=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub38="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub39=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub39="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub40=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub40="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub41=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub41="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub42=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub42="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub43=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub43="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub44=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub44="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub45=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub45="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub46=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub46="";
			j++;
			if(Request.Params.Get("txtsub"+p+"To"+j)!="")
			{
				obj.sub47=Request.Params.Get("txtsub"+p+"To"+j);
				count++;
			}
			else
				obj.sub47="";
				//MessageBox.Show("J:"+ p+j);
		obj.SNo=p;
		//obj.SNo=sno;
		//sno++;
		obj.TPD=count;
		        if(icount>0)
				{  
					  string str1="delete from teachertimetable where employee_id='"+Request.Params.Get("txtteachername"+p)+"'";
				      cmd=new SqlCommand(str1,cn);
				      cmd.ExecuteNonQuery();
				      cmd.Dispose();
				      //dr.Close(); 
				      obj.InsertTimeTable();
				     // MessageBox.Show("Teacher Time Table Update");
				}
				else
				 {
		              obj.InsertTimeTable();
		              //MessageBox.Show("Teacher Time Table Save");
		         }
		
	 }
	 MessageBox.Show("Teacher TimeTable Successfully Saved");
	 DropDesign.SelectedIndex=0;
	 }
	 catch(Exception ex)
	 {
	       CreateLogFiles.ErrorLog ("Form: TimeTable.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + Session["password"] );
	 }
}

</script>
