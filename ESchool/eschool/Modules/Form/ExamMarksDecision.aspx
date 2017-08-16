<%@ Page language="c#" Codebehind="ExamMarksDecision.aspx.cs" AutoEventWireup="false" Inherits="eschool.Form.ExamMarksDecision" %>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="DBOperations"%>
<%@ Import namespace="eschool.Classes"%> 
<%@ Import namespace="RMG"%>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>  
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<html>
  <head>
	<title>eSchool : Exam Marks Decision</title>
	<script language=javascript>
 // This method use to Calculate total of Theory and practical numbers.
 function total(t,t1,t2)
 {
	var theo
	var prac
	var tot=0
	if(t.value=="" ||t.value==null)
		theo=0
	else
	    theo=t.value
	
	if(t1.value==""||t1.value==null)
		prac=0
	else    
		prac=t1.value
    
    tot=eval(theo)+eval(prac)
	t2.value=tot
	if(t2.value>100)
	{
		t.value=""
		t1.value=""
		t2.value=""
		alert("Tot Not More then 100")
	}
 }
 
function Check(t)
{
    //alert(t.name);
}

// This Method use to fill value in examtype dropdown. but this method not in used. 
function FillIandII(t,d)
{
    var index=t.selectedIndex
    var val=t.options[index].value
    alert(index);
    //alert(d.name);
    
    if(val=="I" || val=="II")
    {
      d.clear
      d.length=1
      d.add(new Option)  
      d.options[1].text="Ist Unit Test"
      d.add(new Option)	
      d.options[2].text="IInd Unit Test"
      d.add(new Option)
      d.options[3].text="IIIrd Unit Test"
      d.add(new Option)
      d.options[4].text="IVth Unit Test"
      d.add(new Option)
      d.options[5].text="Vth Unit Test"
      d.add(new Option)
      d.options[6].text="Assign & Project"
    }
    else
    {
      d.clear
      d.length=1
      d.add(new Option)  
      d.options[1].text="Ist Term"
      d.add(new Option)
      d.options[2].text="IInd Term"
      d.add(new Option)
      d.options[3].text="IIIrd Term"
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
			<table width="778" height=250 align="center">
					<tr>
						<td align="center"><b>EXAM MARKS DECISION</b>
							<table align="center" borderColorLight="#663300" border="5">
								<tr>
									<td colspan=22 align=center>&nbsp;Class&nbsp;<font color=red size=1>*</font>&nbsp;<asp:DropDownList CssClass="ComboBox"  ID=DropClass Runat=server Width=80><asp:ListItem Value=Select>Select</asp:ListItem></asp:DropDownList>
										&nbsp;Stream&nbsp;<asp:DropDownList CssClass="ComboBox" ID="DropStream" Runat=server Width=130>
										<asp:ListItem Value="None">None</asp:ListItem>
										<asp:ListItem Value="Biology">Bio Group</asp:ListItem>
										<asp:ListItem Value="Commerce">Commerce Group</asp:ListItem>
										<asp:ListItem Value="Mathematics">Math Group</asp:ListItem>
										</asp:DropDownList>&nbsp;<font color=red size=1>*</font>&nbsp;
										Exam Type&nbsp;<asp:DropDownList CssClass="ComboBox" ID="DropExamType" Runat=server>
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="Ist Unit Test">Ist Unit Test</asp:ListItem>
										<asp:ListItem Value="IInd Unit Test">IInd Unit Test</asp:ListItem>
										<asp:ListItem Value="IIIrd Unit Test">IIIrd Unit Test</asp:ListItem>
										<asp:ListItem Value="IVth Unit Test">IVth Unit Test</asp:ListItem>
										<asp:ListItem Value="Vth Unit Test">Vth Unit Test</asp:ListItem>
										<asp:ListItem Value="Assign & Project">Assign & Project</asp:ListItem>
										<asp:ListItem Value="Ist Term">Ist Term</asp:ListItem>
										<asp:ListItem Value="IInd Term">IInd Term</asp:ListItem>
										<asp:ListItem Value="IIIrd Term">IIIrd Term</asp:ListItem>
										</asp:DropDownList>&nbsp;
										Session&nbsp;<font color=red size=1>*</font>&nbsp;<asp:dropdownlist CssClass="ComboBox" id="DropSession" Runat="server" AutoPostBack=False>
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
										</asp:dropdownlist>&nbsp;
									</td>
								</tr>
								<tr>
									<td align=center colspan=22>
										<asp:Button  ID=btnShow Runat=server Text="Show" Width=70 CssClass=formbuttonstyle></asp:Button>&nbsp;
										<asp:Button ID="btnSubmit" Runat=server Text="Submit" Width=70 CssClass=formbuttonstyle OnClick="update"></asp:Button>&nbsp;
										<asp:Button ID="btnEdit" Runat=server Text="Edit" Width=47 CssClass=formbuttonstyle Visible=False></asp:Button>
									</td>
								</tr>
								<%
									if(flage==true)		
									{
										if(DropClass.SelectedIndex!=0)
										{
											try
											{
												DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"],true);
												InventoryClass obj=new InventoryClass();
												SqlDataReader SqlDtr=null,rdr=null;
												string sql;
												strstr="";
												int Prod_No=0,Group=1,Count=0,pp=0;
												if(DropExamType.SelectedIndex!=0 && DropSession.SelectedIndex!=0)
												{
													string[] no_of_subject=obj.GetSubject1(DropClass.SelectedItem.Text,DropStream.SelectedItem.Text);
													if(no_of_subject.Length==0)
													{
														 if(DropClass.SelectedIndex!=1 && DropClass.SelectedIndex!=2 && DropClass.SelectedIndex!=3 && DropClass.SelectedIndex!=4 &&DropClass.SelectedIndex!=5)
														{
															MessageBox.Show("Subjects Not Available");
												 		}
													}
													else
													{
														for(int p=0;p<no_of_subject.Length;p++)
														{
															if(no_of_subject[p]=="PHYSICS")// || no_of_subject[p]=="CHEMISTRY" || no_of_subject[p]=="ZOLOGY" || no_of_subject[p]=="BOTNEY")
															{
																strstr=strstr+","+"PHYSICS_TH,PHYSICS_PR,PHYSICS_TOT";
															}	
															else if(no_of_subject[p]=="CHEMISTRY")// || no_of_subject[p]=="ZOLOGY" || no_of_subject[p]=="BOTNEY")
															{
																strstr=strstr+","+"chemistry_TH,chemistry_PR,chemistry_TOT";
															}
															else if(no_of_subject[p]=="BIOLOGY")
															{
																strstr=strstr+","+"biology_TH,biology_PR,biology_TOT";
															}
															else if(no_of_subject[p]=="COMPUTER"&&(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII")))//&&!DropClass.SelectedItem.Text.Equals("III")&&!DropClass.SelectedItem.Text.Equals("IV"))
															{
																strstr=strstr+","+"computer_TH,computer_PR,computer_TOT";
															}
															//else if((no_of_subject[p]=="COMPUTER"||no_of_subject[p]=="ENGLISH"||no_of_subject[p]=="HINDI"||no_of_subject[p]=="MATHEMATICS"||no_of_subject[p]=="EVS")&&(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")))
															else if((no_of_subject[p]=="COMPUTER"||no_of_subject[p]=="ENGLISH"||no_of_subject[p]=="HINDI"||no_of_subject[p]=="MATHEMATICS"||no_of_subject[p]=="EVS")&&(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")||DropClass.SelectedItem.Text.Equals("Nursery")||DropClass.SelectedItem.Text.Equals("LKG")||DropClass.SelectedItem.Text.Equals("UKG")))
															{
																if(no_of_subject[p]=="COMPUTER")
																{
																	strstr=strstr+","+"computer_tot";
																}
																else if(no_of_subject[p]=="ENGLISH")
																{
																	strstr=strstr+","+"Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre";
																}
																else if(no_of_subject[p]=="HINDI")
																{
																	strstr=strstr+","+"Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com";
																}
																else if(no_of_subject[p]=="MATHEMATICS")
																{
																	strstr=strstr+","+"Math_FNumber,Math_BConcept,Math_Computation";
																}
																else if(no_of_subject[p]=="EVS")
																{
																	strstr=strstr+","+"evs_observation,evs_Identification,Evs_know";
																}
															}	
															else if((no_of_subject[p]=="COMPUTER")&&!(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII")||DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")||DropClass.SelectedItem.Text.Equals("Nursery")||DropClass.SelectedItem.Text.Equals("LKG")||DropClass.SelectedItem.Text.Equals("UKG")))
															{
																strstr=strstr+","+"computer_TOT";
															}	
															else
															{
																strstr=strstr+","+no_of_subject[p];
															}
														}
														strstr=strstr.Substring(1).ToLower();
														strstr=strstr.Replace(" ","_");
														strstr=strstr.Replace("&","and");
													}
													if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")||DropClass.SelectedItem.Text.Equals("Nursery")||DropClass.SelectedItem.Text.Equals("LKG")||DropClass.SelectedItem.Text.Equals("UKG"))
													{
														string str="select "+strstr+" from ExamMarksDecision where class='"+DropClass.SelectedItem.Text+"' and Stream='"+DropStream.SelectedItem.Text+"' and Exam_Type='"+DropExamType.SelectedItem.Text+"' and Year='"+DropSession.SelectedItem.Text+"'";
														string []a= strstr.Split(',');
														bool flag=true;
														if(a.Length<22)
														{
															//MessageBox.Show("All Subject May be not available,in Case of I and II class All subject required");
															MessageBox.Show("In Case of Nursery, LKG, UKG,I and II Class All Subject Required");
															flag=false;
															//return;
														}
														SqlDtr=obj.GetRecordSet(str);
														if(flag==true)
														{
															%>
															<tr bgcolor=#663300>
																<td align=center colspan=5><b><font color=#ffffff>English</font></b></td>
																<td align=center colspan=5><b><font color=#ffffff>Hindi</font></b></td>
																<td align=center colspan=3><b><font color=#ffffff>Maths</font></b></td>
																<td align=center colspan=3><b><font color=#ffffff>EVS</font></b></td>
																<td align=center colspan=6><b><font color=#ffffff>Non Scholastic</font></b></td>
															</tr>
															<tr bgcolor=#663000>
																<td align=center><b><font color=#ffffff>RR</font></b></td>
																<td align=center><b><font color=#ffffff>WR</font></b></td>
																<td align=center><b><font color=#ffffff>CON</font></b></td>
																<td align=center><b><font color=#ffffff>SP</font></b></td>
																<td align=center><b><font color=#ffffff>COM</font></b></td>
																<td align=center><b><font color=#ffffff>RR</font></b></td>
																<td align=center><b><font color=#ffffff>WR</font></b></td>
																<td align=center><b><font color=#ffffff>CON</font></b></td>
																<td align=center><b><font color=#ffffff>SP</font></b></td>
																<td align=center><b><font color=#ffffff>COM</font></b></td>
																<td align=center><b><font color=#ffffff>FN</font></b></td>
																<td align=center><b><font color=#ffffff>UBC</font></b></td>
																<td align=center><b><font color=#ffffff>CA</font></b></td>
																<td align=center><b><font color=#ffffff>OBS</font></b></td>
																<td align=center><b><font color=#ffffff>ID</font></b></td>
																<td align=center><b><font color=#ffffff>KL</font></b></td>
																<td align=center><b><font color=#ffffff>Ph.Edu</font></b></td>
																<td align=center><b><font color=#ffffff>Music</font></b></td>
																<td align=center><b><font color=#ffffff>Art</font></b></td>
																<td align=center><b><font color=#ffffff>Craft</font></b></td>
																<td align=center><b><font color=#ffffff>Dance</font></b></td>
																<td align=center><b><font color=#ffffff>CS</font></b></td>
															</tr>
															<%
															if(SqlDtr.Read())
															{
																Group=3;
																%>
																<tr>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["Eng_read"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["Eng_writing"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["Eng_con"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["Eng_spelling"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["Eng_compre"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["Hindi_read"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["Hindi_writing"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["Hindi_con"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["Hindi_spelling"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["Hindi_com"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["math_fnumber"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["math_bconcept"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["math_computation"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>		
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["Evs_observation"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["Evs_identification"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["Evs_know"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["phy_edu"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["music"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["art"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["craft"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["dance"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr["computer_tot"].ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
								    						    </tr>
																<tr bgcolor=#663300>
																	<td colspan=22><b><font color=#ffffff>RR = Reading / Recitation , WR = Writing , CON = Conversation , SP = Spelling , COM = Comprehension , FN = Forming Numbers Correctly  </font></b></td>
																</tr>
																<tr bgcolor=#663300>
																	<td colspan=22><b><font color=#ffffff>UBC = Understanding Basic Concept , CA = Computation Ability , OBS = Observation , ID=Identification, KL = Knowledge, CS=Computer</font></b></td>
																</tr>
																<%
															}		
															else
															{
																%>
																<tr>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>"  size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>"  size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>"  size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>"  size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>"  size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>"  size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>"  size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>"  size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>"  size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>"  size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>"  size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>"  size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>"  size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>"  size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>"  size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>"  size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																	<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																</tr>
																<tr bgcolor=#663300>
																	<td colspan=22><b><font color=#ffffff>RR = Reading / Recitation , WR = Writing , CON = Conversation , SP = Spelling , COM = Comprehension , FN = Forming Numbers Correctly  </font></b></td>
																</tr>
																<tr bgcolor=#663300>
																	<td colspan=22><b><font color=#ffffff>UBC = Understanding Basic Concept , CA = Computation Ability , OBS = Observation , ID=Identification, KL = Knowledge, CS=Computer</font></b></td>
																</tr>
																<%
															}
														}
														SqlDtr.Close();
													}
													else
													{
														if(no_of_subject.Length!=0)
														{
															%>
															<tr bgcolor=#663300>
															<%
																for(int p=0;p<no_of_subject.Length;p++)
																{
																	%>
																	<td align=center><b><font color=#ffffff><%=no_of_subject[p].ToString()%></font></b></BR>
																	<%
																	if((no_of_subject[p]=="COMPUTER")&&(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII")))
																	{
																		%>
																		<table width=100% cellpadding=1 cellspacing=1>
																			<tr bgcolor=#663300>
																				<td align=center><b><font color=#ffffff>TH.</font></b></td>
																				<td align=center><b><font color=#ffffff>Prac.</font></b></td>
																				<td align=center><b><font color=#ffffff>Tot</font></b></td>
																			</tr>
																		</table>
																		<%
																	}
																	else if(no_of_subject[p]=="PHYSICS" || no_of_subject[p]=="CHEMISTRY" || no_of_subject[p]=="BIOLOGY")
																	{
																		%>
																		<table width=100% cellpadding=1 cellspacing=1>
																			<tr bgcolor=#663300>
																				<td align=center><b><font color=#ffffff>TH.</font></b></td>
																				<td align=center><b><font color=#ffffff>Prac.</font></b></td>
																				<td align=center><b><font color=#ffffff>Tot</font></b></td>
																			</tr>
																		</table>
																		<%
																	}
																	%>
																	</td>
																	<%
																	Group=2;
																}
																%>
														</tr>
														<tr align=center>
															<%
															Count=0;
															for(int p=0,q=0;p<no_of_subject.Length;p++,q++)
															{
																%>
																<td align=center>
																<%
																	string str="select "+strstr+" from ExamMarksDecision where class='"+DropClass.SelectedItem.Text+"' and Stream='"+DropStream.SelectedItem.Text+"' and Exam_Type='"+DropExamType.SelectedItem.Text+"' and Year='"+DropSession.SelectedItem.Text+"'";
																	SqlDtr=obj.GetRecordSet(str);
																	if(SqlDtr.Read())
																	{
																		if(no_of_subject[p]=="COMPUTER"&&(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII")))
																		{
																			%>
																			<table width=100% cellpadding=1 cellspacing=1>
																				<tr>
																					<td align=center><input type=text style= name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr.GetValue(q).ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																					<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr.GetValue(++q).ToString()%>" size=1 class="TextForms" onblur="Check(this),total(this,document.Form1.txtsub<%=Prod_No%><%=Count-2%>,document.Form1.txtsub<%=Prod_No%><%=Count%>)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																					<td align=center><input readonly=true type=text name="txtsub<%=Prod_No%><%=Count%>" value="<%=SqlDtr.GetValue(++q).ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																				</tr>
																			</table>
																			<%	
																		}
																		else if(no_of_subject[p]=="PHYSICS" || no_of_subject[p]=="CHEMISTRY" || no_of_subject[p]=="BIOLOGY")
																		{
																			%>
																			<table width=100% cellpadding=1 cellspacing=1>
																				<tr>
																					<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr.GetValue(q).ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																					<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>" value="<%=SqlDtr.GetValue(++q).ToString()%>" size=1 class="TextForms" onblur="Check(this),total(this,document.Form1.txtsub<%=Prod_No%><%=Count-2%>,document.Form1.txtsub<%=Prod_No%><%=Count%>)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																					<td align=center><input readonly=true type=text name="txtsub<%=Prod_No%><%=Count%>" value="<%=SqlDtr.GetValue(++q).ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																				</tr>
																			</table>
																			<%
																		}
																		else
																		{
																			%>
																			<table width=100% cellpadding=1 cellspacing=1>
																				<tr>
																					<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count%>"  value="<%=SqlDtr.GetValue(q).ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																				</tr>
																			</table>
																			
																			<%
																		}
																	}
																	else   
																	{
																		if((no_of_subject[p]=="COMPUTER")&&(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII")))//||DropClass.SelectedItem.Text.Equals("III")||DropClass.SelectedItem.Text.Equals("IV")))
																		{
																			%>
																			<table width=100% cellpadding=1 cellspacing=1>
																				<tr>
																					<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>"  size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																					<td align=center><input type=text name="txtsub<%=Prod_No%><%=Count++%>"  size=1 class="TextForms" onblur="Check(this),total(this,document.Form1.txtsub<%=Prod_No%><%=Count-2%>,document.Form1.txtsub<%=Prod_No%><%=Count%>)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																					<td align=center><input readonly=true type=text name="txtsub<%=Prod_No%><%=Count%>"  size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																				</tr>
																			</table>
																			<%	
																		}
																		else if(no_of_subject[p]=="PHYSICS" || no_of_subject[p]=="CHEMISTRY" || no_of_subject[p]=="BIOLOGY")
																		{
																			%>
																			<table width=100% cellpadding=1 cellspacing=1>
																				<tr>
																					<td align=center><input type=text name=txtsub<%=Prod_No%><%=Count++%> size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																					<td align=center><input type=text name=txtsub<%=Prod_No%><%=Count++%> size=1 class="TextForms" onblur="Check(this),total(this,document.Form1.txtsub<%=Prod_No%><%=Count-2%>,document.Form1.txtsub<%=Prod_No%><%=Count%>)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																					<td align=center><input readonly=true type=text name=txtsub<%=Prod_No%><%=Count%> size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																				</tr>
																			</table>
																			<%	
																		}
																		else
																		{
																			%>
																			<table width=100% cellpadding=1 cellspacing=1>
																				<tr>
																					<td align=center><input type=text name=txtsub<%=Prod_No%><%=Count%> size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
																				</tr>
																			</table>
																			
																			<%
																		}
																	}		
																	SqlDtr.Close();
																	%>
																	</td>
																	<%
																	Count++;
																	Group=3;
																}
															
																%>
																</tr>
																<%
															}
															Prod_No++;
															if(Group==2)
															{
																MessageBox.Show("Subject Not Available");
																//return;
															}
															%>
															
													<input type=hidden name=Total_Prod value=<%=Prod_No%>>
													<input type=hidden name=Total_Sub value=<%=Count%>>
													<input type=hidden name=strstr value=<%=strstr%>>
												
											<%
											}
									}
									else if(DropExamType.SelectedIndex==0)
									{
										MessageBox.Show("Please Select Exam Type");
										//return;
									}
									else if(DropSession.SelectedIndex==0)
									{
										MessageBox.Show("Please Select Session");
										//return;
									}
								}
								catch(Exception ex)
								{
									//MessageBox.Show("There is Some Problem Occures, Please Try Again");
									CreateLogFiles.ErrorLog("Form : ExamMarksDecision,Method: btnshow_click "+" ExamMarksDecision  "+"  EXCEPTION   "+ex.Message+"  userid  ");
									//return;
 								}
							}
							else 
							{
								MessageBox.Show("Please Select Class");
								//return;
							}
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

	/// <Summary>
	/// This Method use to update the exammarksdecision  in to exammarkdecision table.
	/// </Summary>
	public void update(Object sender, EventArgs e )
	{  
		try
		{
		if(DropClass.SelectedIndex!=0)
		{
			if(DropExamType.SelectedIndex!=0)
			{			
				if(DropSession.SelectedIndex!=0)
				{
					insertrow();
					DropClass.SelectedIndex=0;
					DropStream.SelectedIndex=0;
					DropExamType.SelectedIndex=0;
					//return;
				}
				else
				{
					MessageBox.Show("Please Select Session");
				}
			}
			else
			{
				MessageBox.Show("Please Select Exam Type");
			}
		}
		else
		{
			MessageBox.Show("Please Select Class");
		}
		}
		catch(Exception ex)
		{	
			//MessageBox.Show(ex.Message);
			CreateLogFiles.ErrorLog("Form:ExamMarksDecision.aspx,Method:update().   EXCEPTION " +ex.Message +"  User_ID : "+ Session["password"]);
		}
	}
	
	public void edit(Object sender, EventArgs e )
	{
		//int i=0;
		//	Request.Params.Set("txtsub"+i+i)="2";
	}
	
	/// <Summary>
	/// This Method use to insert and update the Record of exammarks decision. first delete record from exammarksdecision table. after that 
	/// fetch class id from class table. after that get subject name with the help of GenUtil.AddColumnNames1() function.
	/// after that save record in exammarksdecision table.
	/// </Summary>
	public void insertrow()
	{
		string []subject=new string[20];
		try
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			InventoryClass obj=new InventoryClass(); 
			SqlDataReader SqlDtr;
			SqlCommand SqlCmd;
			int Total_Subject=0,Total_Sub=0;
			string prod_cat="",sql,str="",cls="",stm="";
			int flag = 0;
			int x=0;
			double total=0;
			SqlCon.Open();
			
			//11.03.08--str="delete from exammarksdecision where class='"+DropClass.SelectedItem.ToString()+"' and stream='"+DropStream.SelectedItem.ToString()+"' and exam_type='"+DropExamType.SelectedItem.Text+"'";
			str="delete from exammarksdecision where class='"+DropClass.SelectedItem.ToString()+"' and stream='"+DropStream.SelectedItem.ToString()+"' and exam_type='"+DropExamType.SelectedItem.Text+"' and Year='"+DropSession.SelectedItem.Text+"'";
			SqlCmd = new SqlCommand( str,SqlCon);
			//SqlDtr = SqlCmd.ExecuteReader();
			SqlCmd.ExecuteNonQuery();
			//SqlDtr.Close();
			
			string id="",str1="";
			
			SqlCommand scom=new SqlCommand("select class_id from class where class_name='"+DropClass.SelectedItem.ToString()+"'",SqlCon);
			SqlDataReader sdtr=scom.ExecuteReader();
				
			//if(!DropClass.SelectedItem.ToString().Equals("I")&&!DropClass.SelectedItem.ToString().Equals("II"))
			if(!DropClass.SelectedItem.ToString().Equals("I")&&!DropClass.SelectedItem.ToString().Equals("II")&&!DropClass.SelectedItem.ToString().Equals("Nursery")&&!DropClass.SelectedItem.ToString().Equals("LKG")&&!DropClass.SelectedItem.ToString().Equals("UKG"))
			{
				//SqlCommand scom=new SqlCommand("select class_id from class where class_name='"+DropClass.SelectedItem.ToString()+"'",SqlCon);//commented by vishnu30/11
				//SqlDataReader sdtr=scom.ExecuteReader(); //commented by vishnu30/11
				while(sdtr.Read())
				{
					str1=sdtr.GetValue(0).ToString();
				}
			}
			sdtr.Close();
			
			str1=GenUtil.AddColumnNames1(str1,DropStream.SelectedItem.ToString());
			int i=0,count=0;
			while(i<str1.Length)
			{
				if(str1.Substring(i,1).Equals(","))
				{
					count++;
				}
				i++;
			}
			count++;
			i=0;
			//if(DropClass.SelectedItem.ToString().Equals("I")||DropClass.SelectedItem.ToString().Equals("II"))
			if(DropClass.SelectedItem.ToString().Equals("I")||DropClass.SelectedItem.ToString().Equals("II")||DropClass.SelectedItem.ToString().Equals("Nursery")||DropClass.SelectedItem.ToString().Equals("UKG")||DropClass.SelectedItem.ToString().Equals("LKG"))
			{
				count=22;
			}
			string marks="";
			while(i<count)
			{
			   	if(Request.Params.Get("txtsub0"+i)!="")
			   		marks=marks+Request.Params.Get("txtsub0"+i);
			   	else
			   		marks=marks+"0";
				i++;
				marks=marks+",";		
			}	
			if(marks!="")
				marks=marks.Substring(0,marks.Length-1);
			
			string strInsert;
			SqlCommand cmdInsert;
			
			//if(DropClass.SelectedItem.ToString().Equals("I")||DropClass.SelectedItem.ToString().Equals("II"))
			if(DropClass.SelectedItem.ToString().Equals("I")||DropClass.SelectedItem.ToString().Equals("II")||DropClass.SelectedItem.ToString().Equals("Nursery")||DropClass.SelectedItem.ToString().Equals("UKG")||DropClass.SelectedItem.ToString().Equals("LKG"))
			{
				//11.03.08--strInsert = "Insert into exammarksdecision(class,stream,exam_type,Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre,Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com,Math_FNumber,Math_BConcept,Math_Computation,evs_observation,evs_Identification,Evs_know,phy_edu,music,art,craft,dance,computer_tot) values ('"+DropClass.SelectedItem.ToString()+"','"+DropStream.SelectedItem.ToString()+"','"+DropExamType.SelectedItem.ToString()+"',"+marks+")";
				strInsert = "Insert into exammarksdecision(class,stream,exam_type,Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre,Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com,Math_FNumber,Math_BConcept,Math_Computation,evs_observation,evs_Identification,Evs_know,phy_edu,music,art,craft,dance,computer_tot,Year) values ('"+DropClass.SelectedItem.ToString()+"','"+DropStream.SelectedItem.ToString()+"','"+DropExamType.SelectedItem.ToString()+"',"+marks+",'"+DropSession.SelectedItem.Text+"')";
				cmdInsert=new SqlCommand (strInsert,SqlCon);			
				cmdInsert.ExecuteNonQuery();
			}
			else
			{
			    //11.03.08--strInsert = "Insert into exammarksdecision(class,stream,exam_type,"+str1+") values ('"+DropClass.SelectedItem.ToString()+"','"+DropStream.SelectedItem.ToString()+"','"+DropExamType.SelectedItem.ToString()+"',"+marks+")";
			    strInsert = "Insert into exammarksdecision(class,stream,exam_type,"+str1+",Year) values ('"+DropClass.SelectedItem.ToString()+"','"+DropStream.SelectedItem.ToString()+"','"+DropExamType.SelectedItem.ToString()+"',"+marks+",'"+DropSession.SelectedItem.Text+"')";
				cmdInsert=new SqlCommand (strInsert,SqlCon);			
				cmdInsert.ExecuteNonQuery();
			}
			DropSession.SelectedIndex=0;
			MessageBox.Show("Exam Marks Successfully Saved");
			
		}
		catch(Exception ex)
		{
		        CreateLogFiles.ErrorLog("Form:ExamMarksDecision.aspx,Method:Insert().   EXCEPTION " +ex.Message +"  User_ID : "+ Session["User_Name"].ToString());
		}
			
	}
</script>
