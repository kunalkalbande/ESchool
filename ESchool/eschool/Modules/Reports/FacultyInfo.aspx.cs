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
using System.Data .SqlClient ;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using eschool.Classes;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using RMG;

namespace eschool.e_Coaching.Form
{
	/// <summary>
	/// Summary description for FacultyInfo.
	/// </summary>
	public class FacultyInfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnPrint1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList Dropstype;
		protected System.Web.UI.WebControls.DropDownList Dropsopt;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Btnexcel;
		protected System.Web.UI.WebControls.DataGrid dgrdFaculty;
		protected System.Web.UI.WebControls.Panel panal1;
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
				CreateLogFiles.ErrorLog(" Form :FacultyInfo.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				//Response.Redirect("../Form/HolidayEntryForm.aspx"); 
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
									
				/*LibraryClass.ItemClass obj=new LibraryClass .ItemClass();
					DataSet ds=new DataSet();
					if (Dropstype.SelectedIndex!=0)
					{
						ds=obj.ShowstaffInfo(Dropstype.SelectedItem.Text,Dropsopt.SelectedItem.Text);
						dgrdFaculty.DataSource=ds;
						dgrdFaculty.DataBind();
					}*/
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="26";
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
						return;
					}
					#endregion
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FacultyInfo.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
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
			this.Dropstype.SelectedIndexChanged += new System.EventHandler(this.Dropstype_SelectedIndexChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.btnPrint1.Click += new System.EventHandler(this.btnPrint1_Click);
			this.Btnexcel.Click += new System.EventHandler(this.Btnexcel_Click);
			this.dgrdFaculty.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgrdFaculty_PageIndexChanged);
			this.dgrdFaculty.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgrdFaculty_EditCommand);
			this.dgrdFaculty.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgrdFaculty_UpdateCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Method used for the page index of the datagrid.
		/// </summary>
		private void dgrdFaculty_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgrdFaculty .CurrentPageIndex = e.NewPageIndex;
			try
			{
				DataBind(); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FacultyInfo.aspx,Method  dgrdFaculty_PageIndexChanged,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}  
		} 

		/// <summary>
		/// this method use to show the Report on Datagrid.first Call ShowIssuestudentInfo function for getting the query after that GetRecordSet to getting the record. 
		/// this method not in use.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			LibraryClass.ItemClass obj=new LibraryClass.ItemClass();
			InventoryClass obj1=new InventoryClass();
			SqlDataReader rdr;
			try
			{
				if (Dropstype.SelectedIndex!=0)
				{  
					string str=obj.ShowIssuestudentInfo(Dropstype.SelectedItem.Text,Dropsopt.SelectedItem.Text);
					rdr=obj1.GetRecordSet(str);
					if(rdr.Read())
					{
						dgrdFaculty.DataSource =rdr;
						dgrdFaculty.DataBind();
					}
					else
					{
						MessageBox.Show("Data Not Available");
						return;
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : staff_information.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to get index of datagrid.
		/// </summary>
		private void dgrdFaculty_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				dgrdFaculty.EditItemIndex = e.Item.ItemIndex;
				DataBind();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FacultyInfo.aspx,Method  dgrdFaculty_EditCommand,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
 
			} 
		}

		private void dgrdFaculty_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
 
		}
		/// <summary>
		/// this method not in use.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				Response .Redirect("../PrintPreview/FacilityInfo.aspx");
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FacultyInfo.aspx,Method  BtnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				 
			} 
		}

		/// <summary>
		/// this Method for creating the report in text format and save it in the eschoolprintservices. and data fetch from staff_infromation table.
		/// </summary>
		public void MakingReport()
		{
			LibraryClass.ItemClass obj=new LibraryClass .ItemClass();
			InventoryClass obj4=new InventoryClass();
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2);
			string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\FacultyinfoReport.txt";
			StreamWriter sw = new StreamWriter(path);
			try
			{
				SqlDataReader SqlDtr;
				string sql="";
				if(Dropstype.SelectedItem.Text.Equals("Group D"))
				{
					if(Dropsopt .SelectedItem .Text .Equals ("All"))
						sql="select staff_ID,Staff_Type,Staff_Name,Staff_LocalAddress,Staff_EmailID,Phone_No,Mobile_No,Subject_Take,Staff_education,Staff_exp,prof_qui,sex,maritial_status,doj,age,father_name,natapp from  staff_information where groupd='1'";
					else
						sql="select staff_ID,Staff_Type,Staff_Name,Staff_LocalAddress,Staff_EmailID,Phone_No,Mobile_No,Subject_Take,Staff_education,Staff_exp,prof_qui,sex,maritial_status,doj,age,father_name,natapp from  staff_information  where staff_type='"+Dropsopt .SelectedItem.Text+"' ";
				}
				else if(Dropstype.SelectedItem.Text.Equals("Teaching"))
				{
					if(Dropsopt .SelectedItem .Text .Equals ("All"))
						sql="select staff_ID,Staff_Type,doj,natapp,Staff_Name,father_name,Staff_education,prof_qui,age ,Staff_exp,sex,maritial_status,Staff_EmailID,Subject_Take,Phone_No,Mobile_No,Staff_LocalAddress from  staff_information where teaching='1'";
					else
						sql="select staff_ID,Staff_Type,Staff_Name,Staff_LocalAddress,Staff_EmailID,Phone_No,Mobile_No,Subject_Take,Staff_education,Staff_exp,prof_qui,sex,maritial_status,doj,age,father_name,natapp from  staff_information where staff_type='"+Dropsopt .SelectedItem.Text+"'";
				}
				else if(Dropstype.SelectedItem.Text.Equals("Non Teaching"))
				{
					if(Dropsopt .SelectedItem .Text .Equals ("All"))
						sql="select staff_ID,Staff_Type,Staff_Name,Staff_LocalAddress,Staff_EmailID,Phone_No,Mobile_No,Subject_Take,Staff_education,Staff_exp,prof_qui,sex,maritial_status,doj,age,father_name,natapp from  staff_information where nonteaching='1'";
					else
						sql="select staff_ID,Staff_Type,Staff_Name,Staff_LocalAddress,Staff_EmailID,Phone_No,Mobile_No,Subject_Take,Staff_education,Staff_exp,prof_qui,sex,maritial_status,doj,age,father_name,natapp from  staff_information  where staff_type='"+Dropsopt.SelectedItem.Text+"' ";
				}
		
				else if(Dropstype.SelectedItem.Text.Equals("All"))
				{
					sql="select staff_ID,Staff_Type,Staff_Name,Staff_LocalAddress,Staff_EmailID,Phone_No,Mobile_No,Subject_Take,Staff_education,Staff_exp,prof_qui,sex,maritial_status,doj,age,father_name,natapp from  staff_information ";
				}
				SqlDtr=obj4.GetRecordSet(sql);
				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)0);
				sw.Write((char)12);
				sw.Write((char)27);
				sw.Write((char)78);
				sw.Write((char)5);
				sw.Write((char)27);
				sw.Write((char)15);				
				string des = "+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+---------------+------------+-----------+--------------------+";
				sw.WriteLine(GenUtil.GetCenterAddr("------------------------",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Staff  Information Report",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("--------------------------",des.Length));
				//sw.WriteLine("");
				string info = "",info2 = "",info3 = "",info4="";
				//sw.WriteLine("");
				//sw.WriteLine("");
				if(Dropstype.SelectedItem.Text.Equals ("All"))
				{
					sw.WriteLine("+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+---------------+------------+-----------+--------------------+");
					sw.WriteLine("|StaffID |Designation   |Joining   | Nat App  |Emp Name                 |F Name              | Quali    |Prof Quali|    Dob   |Exp| Gender|MStatus| EMail ID           |  Subject Take |   Phone No | Mobile No |   Loc Address       ");
					sw.WriteLine("+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+---------------+------------+-----------+--------------------+");
					//			   12345678	12345678901234 1234567890 1234567890 1234567890123456789012345 12345678901234567890 1234567890 1234567890 1234567890 123 1234567 1234567 12345678901234567890 124567890123456 123456789012 12345678901 12345678901234567890
					info = " {0,-8:S} {1,-14:S} {2,10:S} {3,-10:S} {4,-25:S} {5,-20:S} {6,-10:S} {7,-10:S} {8,10:S} {9,3:S} {10,-7:S} {11,7:S} {12,-20:S} {13,-16:S} {14,12:S} {15,11:S} {16,-20:S}";//for all
				
				}
				else if(Dropstype.SelectedItem.Text.Equals ("Teaching"))
				{
					sw.WriteLine("+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+---------------+------------+-----------+--------------------+");
					sw.WriteLine("|StaffID |Designation   |Joining   | Nat App  |Emp Name                 |F Name              | Quali    |Prof Quali|    Age   |Exp| Gender|MStatus| EMail ID           |  Subject Take |   Phone No | Mobile No |   Loc Address       ");
					sw.WriteLine("+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+---------------+------------+-----------+--------------------+");
					//			   12345678	12345678901234 1234567890 1234567890 1234567890123456789012345 12345678901234567890 1234567890 1234567890 1234567890 123 1234567 1234567 12345678901234567890 124567890123456 123456789012 12345678901 12345678901234567890
					info2 = " {0,-8:S} {1,-14:S} {2,10:S} {3,-10:S} {4,-25:S} {5,-20:S} {6,-10:S} {7,-10:S} {8,10:S} {9,3:S} {10,-7:S} {11,7:S} {12,-20:S} {13,-16:S} {14,12:S} {15,11:S} {16,-20:S}";//for teaching
				}
				
				else if(Dropstype.SelectedItem.Text.Equals ("Non Teaching"))
				{
					sw.WriteLine("+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+------------+-----------+--------------------+");
					sw.WriteLine("|StaffID |Designation   |Joining   | Nat App  |Emp Name                 |F Name              | Quali    |Prof Quali|    Age   |Exp| Gender|MStatus| EMail ID           | Phone No   | Mobile No |   Loc Address      |");
					sw.WriteLine("+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+------------+-----------+--------------------+");
					//			   12345678	12345678901234 1234567890 1234567890 1234567890123456789012345 12345678901234567890 1234567890 1234567890 1234567890 123 1234567 1234567 12345678901234567890 123456789012 12345678901 12345678901234567890

					info3 = " {0,-8:S} {1,-14:S} {2,10:S} {3,-10:S} {4,-25:S} {5,-20:S} {6,-10:S} {7,-10:S} {8,10:S} {9,3:S} {10,-7:S} {11,7:S} {12,-20:S} {13,12:S} {14,11:S} {15,-20:S}";//non teaching
				}
				else if(Dropstype.SelectedItem.Text.Equals ("Group D"))
				{
					sw.WriteLine("+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+------------+-----------+--------------------+");
					sw.WriteLine("|StaffID |Designation   |Joining   | Nat App  |Emp Name                 |F Name              | Quali    |Prof Quali|    Age   |Exp| Gender|MStatus| EMail ID           |   Phone No | Mobile No |   Loc Address      | ");
					sw.WriteLine("+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+------------+-----------+--------------------+");
					//			   12345678	12345678901234 1234567890 1234567890 1234567890123456789012345 12345678901234567890 1234567890 1234567890 1234567890 123 1234567 1234567 12345678901234567890 123456789012 12345678901 12345678901234567890
				
					info4 = " {0,-8:S} {1,-14:S} {2,10:S} {3,-10:S} {4,-25:S} {5,-20:S} {6,-10:S} {7,-10:S} {8,10:S} {9,3:S} {10,-7:S} {11,7:S} {12,-20:S} {13,12:S} {14,11:S} {15,-20:S}";//group d
				}
				while(SqlDtr.Read())
				{
					if (Dropstype.SelectedIndex!=0)
					{
						if(Dropstype.SelectedItem.Text.Equals("Teaching"))
						{
							sw.WriteLine (info2,SqlDtr["Staff_ID"].ToString(),
								GenUtil.TrimLength(SqlDtr["Staff_Type"].ToString(),14),
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["doj"].ToString())),
								GenUtil.TrimLength(SqlDtr["natapp"].ToString(),10),
								GenUtil.TrimLength(SqlDtr["Staff_Name"].ToString(),25),
								GenUtil.TrimLength(SqlDtr["father_name"].ToString(),20),
								GenUtil.TrimLength(SqlDtr["Staff_education"].ToString(),10),
								GenUtil.TrimLength(SqlDtr["prof_qui"].ToString(),10),
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["age"].ToString())),
								SqlDtr["Staff_exp"].ToString(),
								SqlDtr["sex"].ToString(),
								SqlDtr["maritial_status"].ToString(),
								GenUtil.TrimLength(SqlDtr["Staff_EmailID"].ToString(),20),
								GenUtil.TrimLength(SqlDtr["Subject_take"].ToString(),10),
								SqlDtr["Phone_No"].ToString(),
								GenUtil.TrimLength(SqlDtr["Mobile_No"].ToString(),11),
								GenUtil.TrimLength(SqlDtr["Staff_LocalAddress"].ToString(),20)
								);	
							
						}	

						else if(Dropstype.SelectedItem.Text.Equals("Non Teaching"))
						{
							sw.WriteLine (info3,SqlDtr["Staff_ID"].ToString(),
								GenUtil.TrimLength(SqlDtr["Staff_Type"].ToString(),14),
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["doj"].ToString())),
								GenUtil.TrimLength(SqlDtr["natapp"].ToString(),10),
								GenUtil.TrimLength(SqlDtr["Staff_Name"].ToString(),25),
								GenUtil.TrimLength(SqlDtr["father_name"].ToString(),20),
								GenUtil.TrimLength(SqlDtr["Staff_education"].ToString(),10),
								GenUtil.TrimLength(SqlDtr["prof_qui"].ToString(),10),
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["age"].ToString())),
								SqlDtr["Staff_exp"].ToString(),
								SqlDtr["sex"].ToString(),
								SqlDtr["maritial_status"].ToString(),
								GenUtil.TrimLength(SqlDtr["Staff_EmailID"].ToString(),20),
								SqlDtr["Phone_No"].ToString(),
								GenUtil.TrimLength(SqlDtr["Mobile_No"].ToString(),11),
								GenUtil.TrimLength(SqlDtr["Staff_LocalAddress"].ToString(),20)
								);	
						}
						else if(Dropstype.SelectedItem.Text.Equals("Group D"))
						{
							sw.WriteLine (info4,SqlDtr["Staff_ID"].ToString(),
								GenUtil.TrimLength(SqlDtr["Staff_Type"].ToString(),14),
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["doj"].ToString())),
								GenUtil.TrimLength(SqlDtr["natapp"].ToString(),10),
								GenUtil.TrimLength(SqlDtr["Staff_Name"].ToString(),25),
								GenUtil.TrimLength(SqlDtr["father_name"].ToString(),20),
								GenUtil.TrimLength(SqlDtr["Staff_education"].ToString(),10),
								GenUtil.TrimLength(SqlDtr["prof_qui"].ToString(),10),
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["age"].ToString())),
								SqlDtr["Staff_exp"].ToString(),
								SqlDtr["sex"].ToString(),
								SqlDtr["maritial_status"].ToString(),
								GenUtil.TrimLength(SqlDtr["Staff_EmailID"].ToString(),20),
								SqlDtr["Phone_No"].ToString(),
								GenUtil.TrimLength(SqlDtr["Mobile_No"].ToString(),11),
								GenUtil.TrimLength(SqlDtr["Staff_LocalAddress"].ToString(),20)
								);	
						}
						if(Dropstype.SelectedItem.Text.Equals("All"))
						{
							sw.WriteLine (info,SqlDtr["Staff_ID"].ToString(),
								GenUtil.TrimLength(SqlDtr["Staff_Type"].ToString(),14),
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["doj"].ToString())),
								GenUtil.TrimLength(SqlDtr["natapp"].ToString(),10),
								GenUtil.TrimLength(SqlDtr["Staff_Name"].ToString(),25),
								GenUtil.TrimLength(SqlDtr["father_name"].ToString(),20),
								GenUtil.TrimLength(SqlDtr["Staff_education"].ToString(),10),
								GenUtil.TrimLength(SqlDtr["prof_qui"].ToString(),10),
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["age"].ToString())),
								SqlDtr["Staff_exp"].ToString(),
								SqlDtr["sex"].ToString(),
								SqlDtr["maritial_status"].ToString(),
								GenUtil.TrimLength(SqlDtr["Staff_EmailID"].ToString(),20),
								GenUtil.TrimLength(SqlDtr["Subject_Take"].ToString(),10),
								SqlDtr["Phone_No"].ToString(),
								GenUtil.TrimLength(SqlDtr["Mobile_No"].ToString(),11),
								GenUtil.TrimLength(SqlDtr["Staff_LocalAddress"].ToString(),20)
								);	
						}	
						
					}
				}
				SqlDtr.Close();
				sw.WriteLine("+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+---------------+------------+-----------+--------------------+");

				sw.Close(); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FacultyInfo.aspx,Method  MakingReport,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				
			} 
		}

		/// <summary>
		/// Method for sending the text file to the printer and issueing the print command.
		/// </summary>
		private void btnPrint1_Click(object sender, System.EventArgs e)
		{
			try 
			{
				byte[] bytes=new byte[1024];
				/// Connect to a remote device.
				MakingReport();
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\FacultyinfoReport.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :FacultyInfo.aspx,Method  btnPrint1_Click,  Staff Information Report Printed , Userid :  "+ pass   );		              
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :FacultyInfo.aspx,Method  btnPrint1_Click,  Exception: "+ane.Message+" , Userid :  "+ pass   );		
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :FacultyInfo.aspx,Method  btnPrint1_Click,  Exception: "+se.Message+" , Userid :  "+ pass   );		
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :FacultyInfo.aspx,Method  btnPrint1_Click,  Exception: "+es.Message+" , Userid :  "+ pass   );		
				}
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :FacultyInfo.aspx,Method  btnPrint1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to fill the dropdown from staff_information table according to selected item of this dropdown. 
		/// </summary>
		private void Dropstype_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			panal1.Visible=false;
			InventoryClass obj=new InventoryClass();
			SqlDataReader SqlDtr;
			string str="";
			Dropsopt .Enabled=true;
			Dropsopt .Items.Clear();
			Dropsopt .Items.Add("All");
			if(Dropstype  .SelectedItem.Text.Equals("Group D"))
			{
				str="select distinct staff_type from staff_information where groupd='1'";
				SqlDtr=obj.GetRecordSet(str);
				while(SqlDtr.Read())
				{
					Dropsopt .Items.Add(SqlDtr.GetValue(0).ToString());
				}
			}
			else if(Dropstype .SelectedItem.Text.Equals("Teaching"))
			{
				str="select distinct staff_type from staff_information where teaching='1'";
				SqlDtr=obj.GetRecordSet(str);
				while(SqlDtr.Read())
				{
					Dropsopt .Items.Add(SqlDtr.GetValue(0).ToString());
				}
			}
			else if(Dropstype .SelectedItem.Text.Equals("Non Teaching"))
			{
				str="select distinct staff_type from staff_information where nonteaching='1'";
				SqlDtr=obj.GetRecordSet(str);
				while(SqlDtr.Read())
				{
					Dropsopt .Items.Add(SqlDtr.GetValue(0).ToString());
				}
			}
			else if(Dropstype .SelectedItem.Text.Equals("Activity"))
			{
				str="select distinct staff_type from staff_information where Activity='1'";
				SqlDtr=obj.GetRecordSet(str);
				while(SqlDtr.Read())
				{
					Dropsopt .Items.Add(SqlDtr.GetValue(0).ToString());
				}
			}
			else
			{
				Dropsopt .Enabled=false;
				Dropsopt.Items.Add("All");
				Dropsopt .SelectedIndex=1;
			}
		}

		/// <summary>
		/// this method use to call ShowstaffInfo() function to fetch data from staff_information table.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			LibraryClass.ItemClass obj=new LibraryClass.ItemClass ();
			try
			{
				DataSet ds=new DataSet();
				if (Dropstype.SelectedIndex!=0)
				{  
					ds=obj.ShowstaffInfo(Dropstype.SelectedItem.Text,Dropsopt.SelectedItem.Text);
					dgrdFaculty.DataSource =ds;
					dgrdFaculty.DataBind();
					if(dgrdFaculty.Items.Count==0)
					{
						panal1.Visible=false;
						MessageBox.Show("Record Not Found");
						return;
					}
					else
					{
						panal1.Visible=true;
					}
					
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : FacultyInfo.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}
		
		/// <summary>
		/// this method use to call ConvertIntoExcel() function.
		/// </summary>
		private void Btnexcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				ConvertIntoExcel();
				MessageBox.Show("Successfully Convert File into Excel Format");
				CreateLogFiles.ErrorLog("Form:AdvanceFeesReport.aspx,Method: btnExcel_Click, Advance Fees Report Convert Into Excel Format ,  userid  "+pass);
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:AdvanceFeesReport.aspx,Method:btnExcel_Click   Advance Fees Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+pass);
			}
		}

		/// <summary>
		/// this method use to create a report in excel format. data fetch from staff_information table.
		/// </summary>
		public void ConvertIntoExcel()
		{
			LibraryClass.ItemClass obj=new LibraryClass .ItemClass();
			InventoryClass obj4=new InventoryClass();
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2);
			
			string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\eSchool_ExcelFile\FacultyinfoReport1.xls";

			//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\FacultyinfoReport.txt";
			StreamWriter sw = new StreamWriter(path);
			try
			{
				SqlDataReader SqlDtr;
				string sql="";
				if(Dropstype.SelectedItem.Text.Equals("Group D"))
				{
					if(Dropsopt .SelectedItem .Text .Equals ("All"))
						sql="select staff_ID,Staff_Type,Staff_Name,Staff_LocalAddress,Staff_EmailID,Phone_No,Mobile_No,Subject_Take,Staff_education,Staff_exp,prof_qui,sex,maritial_status,doj,age,father_name,natapp from  staff_information where groupd='1'";
					else
						sql="select staff_ID,Staff_Type,Staff_Name,Staff_LocalAddress,Staff_EmailID,Phone_No,Mobile_No,Subject_Take,Staff_education,Staff_exp,prof_qui,sex,maritial_status,doj,age,father_name,natapp from  staff_information  where staff_type='"+Dropsopt .SelectedItem.Text+"' ";
				}
				else if(Dropstype.SelectedItem.Text.Equals("Teaching"))
				{
					if(Dropsopt .SelectedItem .Text .Equals ("All"))
						sql="select staff_ID,Staff_Type,doj,natapp,Staff_Name,father_name,Staff_education,prof_qui,age ,Staff_exp,sex,maritial_status,Staff_EmailID,Subject_Take,Phone_No,Mobile_No,Staff_LocalAddress from  staff_information where teaching='1'";
					else
						sql="select staff_ID,Staff_Type,Staff_Name,Staff_LocalAddress,Staff_EmailID,Phone_No,Mobile_No,Subject_Take,Staff_education,Staff_exp,prof_qui,sex,maritial_status,doj,age,father_name,natapp from  staff_information where staff_type='"+Dropsopt .SelectedItem.Text+"'";
				}
				else if(Dropstype.SelectedItem.Text.Equals("Non Teaching"))
				{
					if(Dropsopt .SelectedItem .Text .Equals ("All"))
						sql="select staff_ID,Staff_Type,Staff_Name,Staff_LocalAddress,Staff_EmailID,Phone_No,Mobile_No,Subject_Take,Staff_education,Staff_exp,prof_qui,sex,maritial_status,doj,age,father_name,natapp from  staff_information where nonteaching='1'";
					else
						sql="select staff_ID,Staff_Type,Staff_Name,Staff_LocalAddress,Staff_EmailID,Phone_No,Mobile_No,Subject_Take,Staff_education,Staff_exp,prof_qui,sex,maritial_status,doj,age,father_name,natapp from  staff_information  where staff_type='"+Dropsopt.SelectedItem.Text+"' ";
				}
		
				else if(Dropstype.SelectedItem.Text.Equals("All"))
				{
					sql="select staff_ID,Staff_Type,Staff_Name,Staff_LocalAddress,Staff_EmailID,Phone_No,Mobile_No,Subject_Take,Staff_education,Staff_exp,prof_qui,sex,maritial_status,doj,age,father_name,natapp from  staff_information ";
				}
				SqlDtr=obj4.GetRecordSet(sql);
						
				string des = "+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+---------------+------------+-----------+--------------------+";
				sw.WriteLine(GenUtil.GetCenterAddr("------------------------",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Staff  Information Report",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("--------------------------",des.Length));
				sw.WriteLine("");
				if(Dropstype.SelectedItem.Text.Equals ("All"))
				{
					//sw.WriteLine("+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+---------------+------------+-----------+--------------------+");
					sw.WriteLine("StaffID\tDesignation\tJoining\tNat App\tEmp Name\tF Name\tQuali\tProf Quali\tDob\tExp\tGender\tMStatus\tEMail ID\tSubject Take\tPhone No\tMobile No\tLoc Address");
					//sw.WriteLine("+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+---------------+------------+-----------+--------------------+");
					//			   12345678	12345678901234 1234567890 1234567890 1234567890123456789012345 12345678901234567890 1234567890 1234567890 1234567890 123 1234567 1234567 12345678901234567890 124567890123456 123456789012 12345678901 12345678901234567890
					//info = " {0,-8:S} {1,-14:S} {2,10:S} {3,-10:S} {4,-25:S} {5,-20:S} {6,-10:S} {7,-10:S} {8,10:S} {9,3:S} {10,-7:S} {11,7:S} {12,-20:S} {13,-16:S} {14,12:S} {15,11:S} {16,-20:S}";//for all
				
				}
				else if(Dropstype.SelectedItem.Text.Equals ("Teaching"))
				{
					//sw.WriteLine("+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+---------------+------------+-----------+--------------------+");
					sw.WriteLine("StaffID\tDesignation\tJoining\tNat App\tEmp Name\tF Name\tQuali\tProf Quali\tAge\tExp\tGender\tMStatus\tEMail ID\tSubject Take\tPhone No\tMobile No\tLoc Address");
					//sw.WriteLine("+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+---------------+------------+-----------+--------------------+");
					//			   12345678	12345678901234 1234567890 1234567890 1234567890123456789012345 12345678901234567890 1234567890 1234567890 1234567890 123 1234567 1234567 12345678901234567890 124567890123456 123456789012 12345678901 12345678901234567890
					//info2 = " {0,-8:S} {1,-14:S} {2,10:S} {3,-10:S} {4,-25:S} {5,-20:S} {6,-10:S} {7,-10:S} {8,10:S} {9,3:S} {10,-7:S} {11,7:S} {12,-20:S} {13,-16:S} {14,12:S} {15,11:S} {16,-20:S}";//for teaching
				}
				
				else if(Dropstype.SelectedItem.Text.Equals ("Non Teaching"))
				{
					//sw.WriteLine("+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+------------+-----------+--------------------+");
					sw.WriteLine("StaffID\tDesignation\tJoining\tNat App\tEmp Name\tF Name\tQuali\tProf Quali\tAge\tExp\tGender\tMStatus\tEMail ID\tPhone No\tMobile No\tLoc Address");
					//sw.WriteLine("+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+------------+-----------+--------------------+");
					//			   12345678	12345678901234 1234567890 1234567890 1234567890123456789012345 12345678901234567890 1234567890 1234567890 1234567890 123 1234567 1234567 12345678901234567890 123456789012 12345678901 12345678901234567890

					//info3 = " {0,-8:S} {1,-14:S} {2,10:S} {3,-10:S} {4,-25:S} {5,-20:S} {6,-10:S} {7,-10:S} {8,10:S} {9,3:S} {10,-7:S} {11,7:S} {12,-20:S} {13,12:S} {14,11:S} {15,-20:S}";//non teaching
				}
				else if(Dropstype.SelectedItem.Text.Equals ("Group D"))
				{
					//sw.WriteLine("+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+------------+-----------+--------------------+");
					sw.WriteLine("StaffID\tDesignation\tJoining\tNat App\tEmp Name\tF Name\tQuali\tProf Quali\tAge\tExp\tGender\tMStatus\tEMail ID\tPhone No\tMobile No\tLoc Address");
					//sw.WriteLine("+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+------------+-----------+--------------------+");
					//			   12345678	12345678901234 1234567890 1234567890 1234567890123456789012345 12345678901234567890 1234567890 1234567890 1234567890 123 1234567 1234567 12345678901234567890 123456789012 12345678901 12345678901234567890
				
					//info4 = " {0,-8:S} {1,-14:S} {2,10:S} {3,-10:S} {4,-25:S} {5,-20:S} {6,-10:S} {7,-10:S} {8,10:S} {9,3:S} {10,-7:S} {11,7:S} {12,-20:S} {13,12:S} {14,11:S} {15,-20:S}";//group d
				}
				while(SqlDtr.Read())
				{
					if (Dropstype.SelectedIndex!=0)
					{
						if(Dropstype.SelectedItem.Text.Equals("Teaching"))
						{
							sw.WriteLine (SqlDtr["Staff_ID"].ToString()+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_Type"].ToString(),14)+"\t"+
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["doj"].ToString()))+"\t"+
								GenUtil.TrimLength(SqlDtr["natapp"].ToString(),10)+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_Name"].ToString(),25)+"\t"+
								GenUtil.TrimLength(SqlDtr["father_name"].ToString(),20)+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_education"].ToString(),10)+"\t"+
								GenUtil.TrimLength(SqlDtr["prof_qui"].ToString(),10)+"\t"+
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["age"].ToString()))+"\t"+
								SqlDtr["Staff_exp"].ToString()+"\t"+
								SqlDtr["sex"].ToString()+"\t"+
								SqlDtr["maritial_status"].ToString()+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_EmailID"].ToString(),20)+"\t"+
								GenUtil.TrimLength(SqlDtr["Subject_take"].ToString(),10)+"\t"+
								SqlDtr["Phone_No"].ToString()+"\t"+
								GenUtil.TrimLength(SqlDtr["Mobile_No"].ToString(),11)+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_LocalAddress"].ToString(),20)
								);	
							
						}	

						else if(Dropstype.SelectedItem.Text.Equals("Non Teaching"))
						{
							sw.WriteLine (SqlDtr["Staff_ID"].ToString()+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_Type"].ToString(),14)+"\t"+
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["doj"].ToString()))+"\t"+
								GenUtil.TrimLength(SqlDtr["natapp"].ToString(),10)+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_Name"].ToString(),25)+"\t"+
								GenUtil.TrimLength(SqlDtr["father_name"].ToString(),20)+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_education"].ToString(),10)+"\t"+
								GenUtil.TrimLength(SqlDtr["prof_qui"].ToString(),10)+"\t"+
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["age"].ToString()))+"\t"+
								SqlDtr["Staff_exp"].ToString()+"\t"+
								SqlDtr["sex"].ToString()+"\t"+
								SqlDtr["maritial_status"].ToString()+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_EmailID"].ToString(),20)+"\t"+
								SqlDtr["Phone_No"].ToString()+"\t"+
								GenUtil.TrimLength(SqlDtr["Mobile_No"].ToString(),11)+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_LocalAddress"].ToString(),20)
								);	
						}
						else if(Dropstype.SelectedItem.Text.Equals("Group D"))
						{
							sw.WriteLine (SqlDtr["Staff_ID"].ToString()+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_Type"].ToString(),14)+"\t"+
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["doj"].ToString()))+"\t"+
								GenUtil.TrimLength(SqlDtr["natapp"].ToString(),10)+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_Name"].ToString(),25)+"\t"+
								GenUtil.TrimLength(SqlDtr["father_name"].ToString(),20)+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_education"].ToString(),10)+"\t"+
								GenUtil.TrimLength(SqlDtr["prof_qui"].ToString(),10)+"\t"+
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["age"].ToString()))+"\t"+
								SqlDtr["Staff_exp"].ToString()+"\t"+
								SqlDtr["sex"].ToString()+"\t"+
								SqlDtr["maritial_status"].ToString()+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_EmailID"].ToString(),20)+"\t"+
								SqlDtr["Phone_No"].ToString()+"\t"+
								GenUtil.TrimLength(SqlDtr["Mobile_No"].ToString(),11)+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_LocalAddress"].ToString(),20)
								);	
						}
						if(Dropstype.SelectedItem.Text.Equals("All"))
						{
							sw.WriteLine (SqlDtr["Staff_ID"].ToString()+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_Type"].ToString(),14)+"\t"+
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["doj"].ToString()))+"\t"+
								GenUtil.TrimLength(SqlDtr["natapp"].ToString(),10)+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_Name"].ToString(),25)+"\t"+
								GenUtil.TrimLength(SqlDtr["father_name"].ToString(),20)+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_education"].ToString(),10)+"\t"+
								GenUtil.TrimLength(SqlDtr["prof_qui"].ToString(),10)+"\t"+
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["age"].ToString()))+"\t"+
								SqlDtr["Staff_exp"].ToString()+"\t"+
								SqlDtr["sex"].ToString()+"\t"+
								SqlDtr["maritial_status"].ToString()+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_EmailID"].ToString(),20)+"\t"+
								GenUtil.TrimLength(SqlDtr["Subject_Take"].ToString(),10)+"\t"+
								SqlDtr["Phone_No"].ToString()+"\t"+
								GenUtil.TrimLength(SqlDtr["Mobile_No"].ToString(),11)+"\t"+
								GenUtil.TrimLength(SqlDtr["Staff_LocalAddress"].ToString(),20)
								);	
						}	
						
					}
				}
				SqlDtr.Close();
				//sw.WriteLine("+--------+--------------+----------+----------+-------------------------+--------------------+----------+----------+----------+---+-------+-------+--------------------+---------------+------------+-----------+--------------------+");

				sw.Close(); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FacultyInfo.aspx,Method  MakingReport,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				
			} 
		}
	}
}
