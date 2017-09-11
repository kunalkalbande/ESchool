
/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using RMG;
using eschool.Classes;
using System.IO;
using System.Text;  
using System.Net;
using System.Net.Sockets; 


namespace eschool.Reports
{
	/// <summary>
	/// Summary description for Student_Information.
	/// </summary>
	public class Student_Information : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DataGrid dgrdStudentInfo;
		protected System.Web.UI.HtmlControls.HtmlButton Print1;
		protected System.Web.UI.WebControls.DropDownList Dropsopt;
		protected System.Web.UI.WebControls.DropDownList DropSection;
		protected System.Web.UI.WebControls.TextBox txtStudentid;
		protected System.Web.UI.WebControls.Label lblOption;
		protected System.Web.UI.WebControls.DropDownList Dropstype;
		protected System.Web.UI.HtmlControls.HtmlButton excel;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.Panel GridPanal;
		public int i=1;
	    public string Student_Name="",Scategory="",Student_Fname="",Addr="",Phone="",Class="",Sec="",Stream="",House="",Rank="",Categ="",DoAdm="",DOB="";
		protected System.Web.UI.WebControls.Panel GridStudWise;
		public int Student_Id;
		string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString());
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : student_information.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				LibraryClass.ItemClass obj=new LibraryClass .ItemClass();
				InventoryClass obj1=new InventoryClass();
				SqlDataReader rdr;
				if(!Page.IsPostBack)
				{
					string sql="";
					if (Dropstype.SelectedIndex!=0)
					{
						sql=obj.ShowIssuestudentInfo(Dropstype.SelectedItem.Text,Dropsopt.SelectedItem.Text);
						rdr=obj1.GetRecordSet(sql);
						if(rdr.HasRows)
						{
							dgrdStudentInfo.DataSource=rdr;
							dgrdStudentInfo.DataBind();
							dgrdStudentInfo.Visible=true;
						}
						else
						{
							MessageBox.Show("Data Not Available");
							dgrdStudentInfo.Visible=false;
							return;
						}
					}
					txtStudentid.Visible=false;
					DropSection.Visible=false;
				}	
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="33";
					string[,] Priv=(string[,]) Session["Privileges"];
					for(i=0;i<Priv.GetLength(0);i++)
					{
						if(Priv[i,0]== Module &&  Priv[i,1]==SubModule)
						{						
							View_flag=Priv[i,2];
							Add_Flag=Priv[i,3];
							Edit_Flag=Priv[i,4];
							Del_Flag=Priv[i,5];
							break;
						}
					}	
					if(View_flag=="False")
					{
						Response.Redirect("/eschool/AccessDeny.aspx",false);
					}
					#endregion
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : student_information.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Dropstype.SelectedIndexChanged += new System.EventHandler(this.DropStudID_SelectedIndexChanged);
			this.Dropsopt.SelectedIndexChanged += new System.EventHandler(this.Dropsopt_SelectedIndexChanged);
			this.DropSection.SelectedIndexChanged += new System.EventHandler(this.DropSection_SelectedIndexChanged);
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.Print1.ServerClick += new System.EventHandler(this.Print1_ServerClick);
			this.excel.ServerClick += new System.EventHandler(this.excel_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method use to show Report on Datagrid. in case of show all record then use to ShowIssuestudentInfo() function else also ShowIssuestudentInfo() function but number of argument is different.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			LibraryClass.ItemClass obj=new LibraryClass.ItemClass ();
			InventoryClass obj1 = new InventoryClass();
			SqlDataReader rdr;
			try
			{
				if(Dropstype .SelectedIndex ==0)
				{
					MessageBox .Show ("pls select the option");
				}
				string sql="";
				if (Dropstype.SelectedIndex!=0)
				{  
					if(DropSection.Visible==true)
					{
						sql=obj.ShowIssuestudentInfo(Dropstype.SelectedItem.Text,Dropsopt.SelectedItem.Text,DropSection.SelectedItem.Text);
						rdr = obj1.GetRecordSet(sql);
						if(rdr.HasRows)
						{
							dgrdStudentInfo.DataSource =rdr;
							dgrdStudentInfo.DataBind();
							GridPanal.Visible=true;
							GridStudWise.Visible=false;
							dgrdStudentInfo.Visible=true;
						}
						else
						{
							MessageBox.Show("Data Not Available");
							GridPanal.Visible=false;
							GridStudWise.Visible=false;
						}
						rdr.Close();
					}
					else if(txtStudentid.Visible==true)
					{
						sql=obj.ShowIssuestudentInfo(Dropstype.SelectedItem.Text,txtStudentid.Text);
						rdr = obj1.GetRecordSet(sql);
						if(rdr.HasRows)
						{
								while(rdr.Read())
							   {
								   Student_Id=Convert.ToInt32(rdr["Student_ID"]);
								   Student_Name=rdr["Student_FName"].ToString().Trim();
								   Scategory=rdr["scategory"].ToString().Trim();
								   Student_Fname=rdr["Student_FatherName"].ToString().Trim();
								   Addr=rdr["Student_PAddress"].ToString().Trim()+","+rdr["Student_LCity"].ToString().Trim()+"("+rdr["Student_LState"].ToString().Trim()+")";
								   Phone=rdr["Student_PHNo"].ToString().Trim();
								   Class=rdr["Student_Class"].ToString().Trim();
								   Sec=rdr["Seq_Student_id"].ToString().Trim();
								   Stream=rdr["Student_Stream"].ToString().Trim();
								   House=rdr["house"].ToString().Trim();
								   Rank=rdr["rank"].ToString().Trim();
								   Categ=rdr["Student_Category"].ToString().Trim();
								   DoAdm=GenUtil.trimDate(GenUtil.str2DDMMYYYY(rdr["Student_AdmissionDate"].ToString().Trim()));
								   DOB=GenUtil.trimDate(GenUtil.str2DDMMYYYY(rdr["Student_BirthDate"].ToString().Trim()));
							   }
							GridPanal.Visible=false;
							GridStudWise.Visible=true;
						}
						else
						{
							MessageBox.Show("Data Not Available");
							GridStudWise.Visible=false;
							GridPanal.Visible=false;
						}
						rdr.Close();
					}
					else
					{
						sql=obj.ShowIssuestudentInfo(Dropstype.SelectedItem.Text,Dropsopt.SelectedItem.Text);
						rdr = obj1.GetRecordSet(sql);
						if(rdr.HasRows)
						{	
							dgrdStudentInfo.DataSource =rdr;
							dgrdStudentInfo.DataBind();
							GridStudWise.Visible=false;
							GridPanal.Visible=true;
						}
						else
						{
							MessageBox.Show("Data Not Available");
							GridStudWise.Visible=false;
							GridPanal.Visible=false;
						}
						rdr.Close();
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : student_information.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}
 
		/// <summary>
		/// Method for issueing the print command to the printer for printing the text file.
		/// </summary>
		public void Print()
		{		
			byte[] bytes = new byte[1024];
			/// Connect to a remote device.
			try 
			{
				/// Establish the remote endpoint for the socket.
				/// The name of the
				/// remote device is "host.contoso.com".
				IPHostEntry ipHostInfo = Dns.Resolve("127.0.0.1");
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress,63000);
				/// Create a TCP/IP  socket.
				Socket sender1 = new Socket(AddressFamily.InterNetwork, 
					SocketType.Stream, ProtocolType.Tcp );
				/// Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender1.Connect(remoteEP);
					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());
					/// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2);
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentInfoReport.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();					
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form : StudentInformation.aspx,Method  Print,  Exception: "+ane.Message+" , Userid :  "+ pass );	 
					
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form : StudentInformation.aspx,Method  Print,  Exception: "+se.Message+" , Userid :  "+ pass   );
					
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form : StudentInformation.aspx,Method  Print,  Exception: "+es.Message+" , Userid :  "+ pass   );					
				}						
			} 			
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : StudentInformation.aspx,Method  Print,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}
		
		/// <summary>
		/// Method for writing the Report into the text file and call method for issuing the print command to printer.
		/// </summary>
		private void Print1_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentInfoReport.txt";
				StreamWriter sw = new StreamWriter(path); 
				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)0);
				sw.Write((char)12);
				sw.Write((char)27);
				sw.Write((char)78);
				sw.Write((char)5);
				sw.Write((char)27);
				sw.Write((char)15);
				string des="+-----+------+-------------+--------------------+--------------------+--------------------+------------+";
				//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Student Information Report",des.Length));
				if(Dropstype.SelectedIndex==2)
			    	{
					  sw.WriteLine(GenUtil.GetCenterAddr("Search By Class :"+Dropsopt.SelectedItem.Text.ToString()+" And Section :"+DropSection.SelectedItem.Text.ToString(),des.Length));     
					}	
				else if(Dropstype.SelectedIndex==1)
                      sw.WriteLine(GenUtil.GetCenterAddr("Search Studentid Wise",des.Length));
				sw.WriteLine("");
				sw.WriteLine("+-----+------+-------------+--------------------+--------------------+--------------------+------------+");
				sw.WriteLine("| SNo |StuID |  SCategory  |   Student Name     |    Father Name     |      Address       |  Phone No  |");
				sw.WriteLine("+-----+------+-------------+--------------------+--------------------+--------------------+------------+");
				//             12345 123456 1234567890123 12345678901234567890 12345678901234567890 12345678901234567890 123456789012 12345 123
				info = " {0,-5:S} {1,-6:S} {2,-13:S} {3,-20:S} {4,-20:S} {5,-20:S} {6,12:S}";
				try
				{
					LibraryClass.ItemClass obj=new LibraryClass .ItemClass();
					InventoryClass obj2=new InventoryClass();
					SqlDataReader SqlDtr;
					string sql="";
					if(Dropstype.SelectedItem.Text.Equals("Category Wise"))
					{
						if(Dropsopt .SelectedItem .Text .Equals ("All"))
							sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,student_fathername from  Student_Record order by student_class,seq_student_id,Student_fname";  //add by vikas sharma 6.11.07
						else
							sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,student_fathername from  Student_Record  where Student_Category='"+Dropsopt .SelectedItem.Text+"' order by student_class,seq_student_id,Student_fname "; //add by vikas sharma 6.11.07
					}
					else if(Dropstype.SelectedItem.Text.Equals("Rank Wise"))
					{
						if(Dropsopt .SelectedItem .Text .Equals ("All"))
							sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,student_fathername from  Student_Record order by student_class,seq_student_id,Student_fname";     //add by vikas sharma 6.11.07
						else
							sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,student_fathername from  Student_Record  where rank='"+Dropsopt .SelectedItem.Text+"'order by student_class,seq_student_id,Student_fname ";    //add by vikas sharma 6.11.07
					}
					else if(Dropstype.SelectedItem.Text.Equals("SCategory Wise"))
					{
						if(Dropsopt .SelectedItem .Text .Equals ("All"))
							sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,student_fathername from  Student_Record order by student_class,seq_student_id,Student_fname"; //add by vikas sharma 6.11.07
						else
							sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,student_fathername from  Student_Record  where scategory='"+Dropsopt .SelectedItem.Text+"' order by student_class,seq_student_id,Student_fname "; //add by vikas sharma 6.11.07
					}
					else if(Dropstype.SelectedItem.Text.Equals("StudentID Wise"))
					{
						if(txtStudentid.Text.ToUpper().Equals("ALL"))
							sql="select Student_ID,Seq_Student_id,student_pcity,student_pstate,Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,student_fathername from  Student_Record "; //add by vikas sharma 6.11.07
						else
							sql="select Student_ID,Seq_Student_id,student_pcity,student_pstate,Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,student_fathername from  Student_Record  where Student_ID='"+txtStudentid.Text+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)";  //add by vikas sharma 22.02.08
							
					}			
					else if(Dropstype.SelectedItem.Text.Equals("Class Wise"))
					{
						if(Dropsopt .SelectedItem .Text .Equals ("All"))
							sql="select Student_ID,Seq_Student_id,student_pcity,student_pstate, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record where  student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off) order by student_class,seq_student_id,Student_fname"; //add by vikas sharma date on 23.02.08
						else
						{			
							if(DropSection .SelectedItem .Text.ToUpper().Equals ("ALL"))
								sql="select Student_ID,Seq_Student_id,student_pcity,student_pstate,Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record where student_class='"+Dropsopt .SelectedItem.Text+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off) order by student_class,seq_student_id,Student_fname"; //add by vikas sharma date on 23.02.08
							else
								sql="select Student_ID,Seq_Student_id,student_pcity,student_pstate,Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record  where Student_Class='"+Dropsopt .SelectedItem.Text+"' and seq_student_id='"+DropSection .SelectedItem.Text+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off) order by student_class,seq_student_id,Student_fname";     //add by vikas sharma date on 23.02.08
						}
					}
					SqlDtr=obj2.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
                		Student_Id=Convert.ToInt32(SqlDtr["Student_ID"]);
						Student_Name=SqlDtr["Student_FName"].ToString().Trim();
						Scategory=SqlDtr["scategory"].ToString().Trim();
						Student_Fname=SqlDtr["Student_FatherName"].ToString().Trim();
						Addr=SqlDtr["Student_PAddress"].ToString().Trim()+","+SqlDtr["Student_PCity"].ToString().Trim().ToUpper()+"("+SqlDtr["Student_PState"].ToString().Trim().ToUpper()+")";
						Phone=SqlDtr["Student_PHNo"].ToString().Trim();
						Class=SqlDtr["Student_Class"].ToString().Trim();
						Sec=SqlDtr["Seq_Student_id"].ToString().Trim();
						Stream=SqlDtr["Student_Stream"].ToString().Trim();
						House=SqlDtr["house"].ToString().Trim();
						Rank=SqlDtr["rank"].ToString().Trim();
						Categ=SqlDtr["Student_Category"].ToString().Trim();
						DoAdm=GenUtil.trimDate(GenUtil.str2DDMMYYYY(SqlDtr["Student_AdmissionDate"].ToString().Trim()));
						DOB=GenUtil.trimDate(GenUtil.str2DDMMYYYY(SqlDtr["Student_BirthDate"].ToString().Trim()));
						sw.WriteLine (info,i.ToString(),
							SqlDtr["Student_ID"].ToString(),
							GenUtil.TrimLength(SqlDtr["scategory"].ToString(),13),
							GenUtil.TrimLength(SqlDtr["Student_FName"].ToString(),20),
							GenUtil.TrimLength(SqlDtr["Student_FatherName"].ToString(),20),
							GenUtil.TrimLength(SqlDtr["Student_PAddress"].ToString(),20),
    						GenUtil.TrimLength(SqlDtr["Student_PHNo"].ToString(),12)
	 				);
						i++;
							
					}
					SqlDtr.Close();
					sw.WriteLine("+-----+------+-------------+--------------------+--------------------+--------------------+------------+");
					sw.Close(); 
					Print();
					CreateLogFiles.ErrorLog(" Form : StudentInformation.aspx,Method  Print_Click,  Student Information Report View , Userid :  "+ pass   );
				}
				catch(Exception ex)
				{
					//Response.Write(ex.ToString()); 
					CreateLogFiles.ErrorLog(" Form : StudentInformation.aspx,Method  Print_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
				}	
			}
			catch(Exception ex)
			{
				//Response.Write(ex.ToString()); 
				CreateLogFiles.ErrorLog(" Form : StudentInformation.aspx,Method  Print_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}

		private void dgrdStudentInfo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this Method use to add data in dropdown. according to selected value of dropstudentID.
		/// </summary>
		private void DropStudID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				dgrdStudentInfo.Visible=false;
				GridStudWise.Visible=false;
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr;
				string str="";
				lblOption.Text="Select Option";
				Dropsopt .Enabled=true;
				Dropsopt.Visible=true;
				txtStudentid.Visible=false;
				txtStudentid.Text="";
				Dropsopt .Items.Clear();
				Dropsopt .Items.Add("All");
				if(Dropstype  .SelectedItem.Text.Equals("Category Wise"))
				{
					DropSection.Visible=false;
					str="select distinct Student_Category from Student_Record where student_category!=''";
					SqlDtr=obj.GetRecordSet(str);
					while(SqlDtr.Read())
					{
						Dropsopt .Items.Add(SqlDtr.GetValue(0).ToString());
					}
				}
				else if(Dropstype .SelectedItem.Text.Equals("Rank Wise"))
				{
					DropSection.Visible=false;
					str="select distinct rank from Student_Record  ";
					SqlDtr=obj.GetRecordSet(str);
					while(SqlDtr.Read())
					{
						Dropsopt .Items.Add(SqlDtr.GetValue(0).ToString());
					}
				}
				else if(Dropstype .SelectedItem.Text.Equals("SCategory Wise"))
				{
					DropSection.Visible=false;
					str="select distinct scategory from Student_Record  ";
					SqlDtr=obj.GetRecordSet(str);
					while(SqlDtr.Read())
					{
						Dropsopt .Items.Add(SqlDtr.GetValue(0).ToString());
					}
				}
				else if(Dropstype .SelectedItem.Text.Equals("StudentID Wise"))
				{
					DropSection.Visible=false;
					Dropsopt.Visible=false;
					txtStudentid.Visible=true;
					lblOption.Visible=true;
					lblOption.Text="Enter Stu.ID";
				}
				else if(Dropstype .SelectedItem.Text.Equals("Class Wise"))
				{
				
					DropSection.Visible=true;
					//str="select distinct Student_Class from Student_Record order by Student_Class";
					str="select Class_name from class order by Class_id";
					SqlDtr=obj.GetRecordSet(str);
					while(SqlDtr.Read())
					{
						Dropsopt.Items.Add(SqlDtr.GetValue(0).ToString());
					}
				}
				else
				{
					Dropsopt .Enabled=false;
					Dropsopt.Items.Add("All");
					Dropsopt .SelectedIndex=1;
					
				}
			}
			catch(Exception ex)
			{
				//Response.Write(ex.ToString()); 
				CreateLogFiles.ErrorLog(" Form : StudentInformation.aspx,Method  DropStudID_SelectedIndexChanged,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}

		}

		private void Dropsopt_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void DropSection_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		/// <summary>
		/// this method use to call ConvertIntoExcel file.
		/// </summary>
		private void excel_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				ConvertIntoExcel();
				MessageBox.Show("Successfully Convert File into Excel Format");
				CreateLogFiles.ErrorLog("Form:BankReport.aspx,Method: btnExcel_Click, Bank Report Convert Into Excel Format ,  userid  "+pass);
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:BankReport.aspx,Method:btnExcel_Click   Bank Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+pass);
			}	
		}

		/// <summary>
		/// Method for writing the Report into the excel file.
		/// </summary>
		public void ConvertIntoExcel()
		{
			try
			{
				int i=1;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\StudentInfo_Report.xls";
				StreamWriter sw = new StreamWriter(path); 
				string des="+-----+------+-------------+--------------------+--------------------+--------------------+------------+";
				//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Student Information Report",des.Length));
				if(Dropstype.SelectedIndex==2)
				{
					sw.WriteLine(GenUtil.GetCenterAddr("Search By Class :"+Dropsopt.SelectedItem.Text.ToString()+" And Section :"+DropSection.SelectedItem.Text.ToString(),des.Length));     
				}	
				else if(Dropstype.SelectedIndex==1)
					sw.WriteLine(GenUtil.GetCenterAddr("Search Studentid Wise",des.Length));
					sw.WriteLine("  SNo\tStuID\tSCategory\tStudent Name\tFather Name\tAddress\tPhone No\tClass\tSec");
				try
				{
					LibraryClass.ItemClass obj=new LibraryClass .ItemClass();
					InventoryClass obj2=new InventoryClass();
					SqlDataReader SqlDtr;
					string sql="";
					if(Dropstype.SelectedItem.Text.Equals("Category Wise"))
					{
						if(Dropsopt .SelectedItem .Text .Equals ("All"))
							sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,student_fathername from  Student_Record order by student_class,seq_student_id,Student_fname";  //add by vikas sharma 6.11.07
						else
							sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,student_fathername from  Student_Record  where Student_Category='"+Dropsopt .SelectedItem.Text+"' order by student_class,seq_student_id,Student_fname "; //add by vikas sharma 6.11.07
					}
					else if(Dropstype.SelectedItem.Text.Equals("Rank Wise"))
					{
						if(Dropsopt .SelectedItem .Text .Equals ("All"))
							sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,student_fathername from  Student_Record order by student_class,seq_student_id,Student_fname";     //add by vikas sharma 6.11.07
						else
							sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,student_fathername from  Student_Record  where rank='"+Dropsopt .SelectedItem.Text+"'order by student_class,seq_student_id,Student_fname ";    //add by vikas sharma 6.11.07
					}
					else if(Dropstype.SelectedItem.Text.Equals("SCategory Wise"))
					{
						if(Dropsopt .SelectedItem .Text .Equals ("All"))
							sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,student_fathername from  Student_Record order by student_class,seq_student_id,Student_fname"; //add by vikas sharma 6.11.07
						else
							sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,student_fathername from  Student_Record  where scategory='"+Dropsopt .SelectedItem.Text+"' order by student_class,seq_student_id,Student_fname "; //add by vikas sharma 6.11.07
						
					}
					else if(Dropstype.SelectedItem.Text.Equals("StudentID Wise"))
					{
						if(txtStudentid.Text.ToUpper().Equals("ALL"))
							sql="select Student_ID,Seq_Student_id,student_pcity,student_pstate,Student_FName,student_pcity,student_pstate,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,student_fathername from  Student_Record "; //add by vikas sharma 6.11.07
						else
							sql="select Student_ID,Seq_Student_id,Student_FName,student_pcity,student_pstate,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,student_fathername from  Student_Record  where Student_ID='"+txtStudentid.Text+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)";  //add by vikas sharma 6.11.07
						
					}
					else if(Dropstype.SelectedItem.Text.Equals("Class Wise"))
					{
						if(Dropsopt .SelectedItem .Text .Equals ("All"))
							sql="select Student_ID,Seq_Student_id,student_pcity,student_pstate, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record where  student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off) order by student_class,seq_student_id,Student_fname"; //add by vikas sharma date on 23.02.08
						else
						{   
    						if(DropSection .SelectedItem .Text.ToUpper().Equals ("ALL"))
								sql="select Student_ID,Seq_Student_id,student_pcity,student_pstate, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record where student_class='"+Dropsopt .SelectedItem.Text+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off) order by student_class,seq_student_id,Student_fname"; //add by vikas sharma date on 23.02.08
							else
								sql="select Student_ID,Seq_Student_id,student_pcity,student_pstate, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record  where Student_Class='"+Dropsopt .SelectedItem.Text+"' and seq_student_id='"+DropSection .SelectedItem.Text+"'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off) order by student_class,seq_student_id,Student_fname";     //add by vikas sharma date on 23.02.08
						}
					}
		            SqlDtr=obj2.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						Student_Id=Convert.ToInt32(SqlDtr["Student_ID"]);
						Student_Name=SqlDtr["Student_FName"].ToString().Trim();
						Scategory=SqlDtr["scategory"].ToString().Trim();
						Student_Fname=SqlDtr["Student_FatherName"].ToString().Trim();
						Addr=SqlDtr["Student_PAddress"].ToString().Trim()+","+SqlDtr["Student_PCity"].ToString().Trim().ToUpper()+"("+SqlDtr["Student_PState"].ToString().Trim().ToUpper()+")";
						Phone=SqlDtr["Student_PHNo"].ToString().Trim();
						Class=SqlDtr["Student_Class"].ToString().Trim();
						Sec=SqlDtr["Seq_Student_id"].ToString().Trim();
						Stream=SqlDtr["Student_Stream"].ToString().Trim();
						House=SqlDtr["house"].ToString().Trim();
						Rank=SqlDtr["rank"].ToString().Trim();
						Categ=SqlDtr["Student_Category"].ToString().Trim();
						DoAdm=GenUtil.trimDate(GenUtil.str2DDMMYYYY(SqlDtr["Student_AdmissionDate"].ToString().Trim()));
						DOB=GenUtil.trimDate(GenUtil.str2DDMMYYYY(SqlDtr["Student_BirthDate"].ToString().Trim()));
     					sw.WriteLine (i.ToString()+"\t"+
						SqlDtr["Student_ID"].ToString()+"\t"+
						GenUtil.TrimLength(SqlDtr["scategory"].ToString(),13)+"\t"+
						GenUtil.TrimLength(SqlDtr["Student_FName"].ToString(),20)+"\t"+
						GenUtil.TrimLength(SqlDtr["Student_FatherName"].ToString(),20)+"\t"+
						GenUtil.TrimLength(SqlDtr["Student_PAddress"].ToString(),20)+"\t"+
						GenUtil.TrimLength(SqlDtr["Student_PHNo"].ToString(),12)+"\t"+
						SqlDtr["Student_Class"].ToString()+"\t"+
						SqlDtr["seq_Student_ID"].ToString()
					);
						i++;	
					}
					SqlDtr.Close();
					sw.Close(); 
					CreateLogFiles.ErrorLog(" Form : StudentInformation.aspx,Method  Print_Click,  Student Information Report View , Userid :  "+ pass   );
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog(" Form : StudentInformation.aspx,Method  Print_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
				}	
			}
			catch(Exception ex)
			{
				//Response.Write(ex.ToString()); 
				CreateLogFiles.ErrorLog(" Form : StudentInformation.aspx,Method  Print_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
					
		}
	
	
	}
}