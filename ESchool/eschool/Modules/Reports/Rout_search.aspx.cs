/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/
    # region Directives...
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
using System.Data .SqlClient ;
using RMG;
using eschool.Classes;
using System.IO;
using System.Text;  
using System.Net;
using System.Net.Sockets; 

# endregion

namespace eschool.localuserReports
{
	/// <summary>
	/// Summary description for Rout_search.
	/// </summary>
	public class Rout_search : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGridsearch;
		protected System.Web.UI.WebControls.ValidationSummary vsRouteSearch;
		protected System.Web.UI.HtmlControls.HtmlButton BtnPrint;
		protected System.Web.UI.WebControls.DropDownList Dropstype;
		protected System.Web.UI.WebControls.DropDownList Dropsopt;
		protected System.Web.UI.WebControls.DropDownList DropSection;
		protected System.Web.UI.HtmlControls.HtmlButton BtnExcel;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.WebControls.Panel pangrid;
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
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog ("Form: Route_search.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				LibraryClass.ItemClass obj=new LibraryClass .ItemClass();
				DataSet ds=new DataSet();
				if(!Page.IsPostBack)
				{
					InventoryClass obj1=new InventoryClass();
					SqlDataReader SqlDtr;
					string str="";
					if (Dropstype.SelectedIndex!=0)// && Dropsopt.SelectedIndex!=0)
					{
						//ds=obj.ShowstudentrouteInfo(Dropstype.SelectedItem.Text,Dropsopt.SelectedItem.Text);
						str=obj.ShowstudentrouteInfo(Dropstype.SelectedItem.Text,Dropsopt.SelectedItem.Text);
						SqlDtr=obj1.GetRecordSet(str);
						DataGridsearch.DataSource=SqlDtr;
						DataGridsearch.DataBind();
					}
					DropSection.Visible=false;	 
				}
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="20";
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
				CreateLogFiles.ErrorLog(" Form :Rout_search.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
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
			this.Dropsopt.SelectedIndexChanged += new System.EventHandler(this.Dropsopt_SelectedIndexChanged);
			this.DropSection.SelectedIndexChanged += new System.EventHandler(this.DropSection_SelectedIndexChanged);
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.BtnPrint.ServerClick += new System.EventHandler(this.BtnPrint_ServerClick);
			this.BtnExcel.ServerClick += new System.EventHandler(this.BtnExcel_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// this method use to show the report call ShowstudentrouteInfo() function. fetch data from student_record table.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			LibraryClass.ItemClass obj=new LibraryClass.ItemClass ();
			InventoryClass obj1=new InventoryClass();
			SqlDataReader SqlDtr;
			try
			{
				if(Dropstype .SelectedIndex ==0)
				{
					MessageBox .Show ("Please select the option");
				}
				string str="";
				//DataSet ds=new DataSet();
				if (Dropstype.SelectedIndex!=0) // && Dropsopt.SelectedIndex!=0)
				{  
					if(DropSection.Visible==true)
					{
						str=obj.ShowstudentrouteInfo(Dropstype.SelectedItem.Text,Dropsopt.SelectedItem.Text,DropSection .SelectedItem .Text );
						SqlDtr=obj1.GetRecordSet(str);
						//						DataGridsearch.DataSource =ds;
						//						DataGridsearch.DataBind();
						if(SqlDtr.HasRows)
						{
							DataGridsearch.DataSource =SqlDtr;
							DataGridsearch.DataBind();
							DataGridsearch.Visible=true;
							pangrid.Visible=true;
						}
						else
						{
							DataGridsearch.Visible=false;
							pangrid.Visible=false;
							MessageBox.Show("Data Not Available");
						}
					}
					else
					{
						str=obj.ShowstudentrouteInfo(Dropstype.SelectedItem.Text,Dropsopt.SelectedItem.Text);
						SqlDtr=obj1.GetRecordSet(str);
						if(SqlDtr.HasRows)
						{
							DataGridsearch.DataSource =SqlDtr;
							DataGridsearch.DataBind();
							DataGridsearch.Visible=true;
							pangrid.Visible=true;
						}
						else
						{
							DataGridsearch.Visible=false;
							pangrid.Visible=false;
							MessageBox.Show("Data Not Available");
						}
					}
					SqlDtr.Close();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Route_serch.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ Session["Password"].ToString()   );		
			}		  
		}

		
		/// <summary>
		/// Add the route name to the DropdownBox as per the selection of the driver name.
		/// this method not in use.  
		/// </summary>
		private void Dropdrivername_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*
			InventoryClass obj=new InventoryClass();
			SqlDataReader SqlDtr;
			string str="";
			Dropsopt .Enabled=true;
			
			Dropsopt .Items.Clear();
			Dropsopt .Items.Add("All");
			if(Dropstype  .SelectedItem.Text.Equals("Route Name Wise"))
			{
				str="select distinct routename from Route ";
				SqlDtr=obj.GetRecordSet(str);
				while(SqlDtr.Read())
				{
					
					Dropsopt .Items.Add(SqlDtr.GetValue(0).ToString());
				}
			}
			else if(Dropstype .SelectedItem.Text.Equals("Route No Wise"))
			{
				str="select distinct Route_km from Route  ";
				SqlDtr=obj.GetRecordSet(str);
				while(SqlDtr.Read())
				{
					Dropsopt .Items.Add(SqlDtr.GetValue(0).ToString());
				}
			}

//			else if(Dropstype .SelectedItem.Text.Equals("SCategory Wise"))
//			{
//				str="select distinct scategory from Student_Record  ";
//				SqlDtr=obj.GetRecordSet(str);
//				while(SqlDtr.Read())
//				{
//					Dropsopt .Items.Add(SqlDtr.GetValue(0).ToString());
//				}
//			}
		
			else if(Dropstype .SelectedItem.Text.Equals("StudentID Wise"))
			{
				str="select distinct Student_ID from Student_Record  ";
				SqlDtr=obj.GetRecordSet(str);
				while(SqlDtr.Read())
				{
					Dropsopt .Items.Add(SqlDtr.GetValue(0).ToString());
				}
			}
		
			else if(Dropstype .SelectedItem.Text.Equals("Class Wise"))
			{
				
				
				DropSection.Visible=true;
				str="select distinct Student_Class from Student_Record order by Student_Class";
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
			}*/
			
			
			//			SqlConnection con4;
			//			SqlCommand cmd;
			// 
			//			Droproutname.Items.Clear();
			//			Droproutname.Items.Add("---Select---");
			//			con4=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			//			con4.Open ();
			//			string str="select route_name from route where route_id=(select route_id from driver_table where driver_firstname='"+Dropdrivername.SelectedItem.Text.ToString()+"')";
			//			cmd=new SqlCommand(str,con4);
			//			SqlDataReader dr=cmd.ExecuteReader();
			//			while(dr.Read())
			//			{
			//				Droproutname.Items.Add(dr.GetValue(0).ToString());
			//			}
			//			dr.Close();
		}
		//Add the Busno. to the Dropdownbox as per the selection of the route name.
		//		private void Droproutname_SelectedIndexChanged(object sender, System.EventArgs e)
		//		{
		//			SqlConnection con4;
		//			SqlCommand cmd;
		//	 
		//			Dropbusno.Items.Clear();
		//			Dropbusno.Items.Add("---Select---");
		//			con4=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
		//			con4.Open ();
		//	        string str="select bus_no from driver_table where route_id=(select route_id from route where route_name='"+Droproutname.SelectedItem.Text.ToString()+"')";
		//			cmd=new SqlCommand(str,con4);
		//			SqlDataReader dr=cmd.ExecuteReader();
		//			while(dr.Read())
		//			{
		//				Dropbusno.Items.Add(dr.GetValue(0).ToString());
		//
		//			}
		//			dr.Close();
		//		}

		/// <summary>
		/// Method for writing the Report to the text file and call the method to print the Report.
		/// </summary>
		private void BtnPrint_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\RouteSearchReport.txt";
				StreamWriter sw = new StreamWriter(path); 
				SqlConnection con4 ;
				LibraryClass.ItemClass obj=new LibraryClass.ItemClass ();
				SqlCommand cmdInsert=null;
				SqlDataReader SqlDtr=null;
				con4=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con4.Open ();
			
				string str="";
				//				if(Dropdrivername.SelectedIndex==0 && Droproutname.SelectedIndex==0 && Dropbusno.SelectedIndex==0)
				//				{
				//					str="Select Route_name,Bus_No,Driver_FirstName From Driver_Table,route where route.route_id=driver_table.route_id";
				//				}
				//				else if(Dropdrivername.SelectedIndex!=0 && Droproutname.SelectedIndex==0 && Dropbusno.SelectedIndex==0)
				//				{
				//
				//					str= "Select Route_name,Bus_No,Driver_FirstName From Driver_Table,route where route.route_id=driver_table.route_id and Driver_FirstName='"+Dropdrivername.SelectedItem.Text.ToString()+"'";
				//
				//				}
				//				else if(Dropdrivername.SelectedIndex!=0 && Droproutname.SelectedIndex!=0 && Dropbusno.SelectedIndex==0)
				//				{
				//					str= "Select Route_name,Bus_No,Driver_FirstName From Driver_Table,route where route.route_id=driver_table.route_id and Driver_FirstName='"+Dropdrivername.SelectedItem.Text.ToString()+"' and route_name='"+Droproutname.SelectedItem.Text.ToString()+"'";
				//				}
				//				else if(Dropdrivername.SelectedIndex!=0 && Droproutname.SelectedIndex!=0 && Dropbusno.SelectedIndex==0)
				//				{
				//					str= "Select Route_name,Bus_No,Driver_FirstName From Driver_Table,route where route.route_id=driver_table.route_id and Driver_FirstName='"+Dropdrivername.SelectedItem.Text.ToString()+"' and bus_No='"+Dropbusno.SelectedItem.Text.ToString()+"'";
				//				}
				//	else
				//{
				//str="Select Route_name,Bus_No,Driver_FirstName From Driver_Table,route where  route.route_id=driver_table.route_id and  Route_name ='"+Droproutname.SelectedItem.Text .ToString ()+"'and  Bus_No='"+Dropbusno.SelectedItem .Text .ToString ()+"' and  Driver_FirstName='"+Dropdrivername.SelectedItem.Text .ToString ()+"'";
					
					
				//}
				//string str="";
				if (Dropstype.SelectedIndex!=0)// && Dropsopt.SelectedIndex!=0)
				{  
					
						
					if(DropSection.Visible==true)
					{
						str=obj.ShowstudentrouteInfo(Dropstype.SelectedItem.Text,Dropsopt.SelectedItem.Text,DropSection .SelectedItem .Text );
						//						DataGridsearch.DataSource =ds;
						//						DataGridsearch.DataBind();
					}
					else
					{
						str=obj.ShowstudentrouteInfo(Dropstype.SelectedItem.Text,Dropsopt.SelectedItem.Text);
						//						DataGridsearch.DataSource =ds;
						//						DataGridsearch.DataBind();
					}
				}
				//				MessageBox.Show ("str is"+str);
				cmdInsert=new SqlCommand (str,con4);

				//string des="+-------+------------------+------+--------------+-----+-------+--------------+----------+--------+--+-----------+-------------+";
				string des="+-------+----------------------+------+------------------+-----+---+----------+----------+--------+--+-------------+-------------+";
				sw.WriteLine(GenUtil.GetCenterAddr("=====================",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Route Search Report",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("=====================",des.Length));
				sw.WriteLine("");
				sw.WriteLine("+-------+----------------------+------+------------------+-----+---+----------+----------+--------+--+-------------+-------------+");
				sw.WriteLine("|RouteNo|      Route Name      |RollNo|   Student Name   |Class|Sec|  Stream  | Scategory|  Rank  |BG|   Address   |  Phone No   |");
				sw.WriteLine("+-------+----------------------+------+------------------+-----+---+----------+----------+--------+--+-------------+-------------+");
				//1234567 1234567890123456789012 123456 123456789012345678 12345 123 1234567890 1234567890 12345678 12 1234567890123 1234567890123
				//info = " {0,-10:S}  {1,-10:S}   {2,-15:S} ";
				info = " {0,-7:S} {1,-22:S} {2,-6:S} {3,-18:S} {4,5:S} {5,-3:S} {6,-10:S} {7,-10:S} {8,-8:S} {9,-2:S} {10,-13:S} {11,-13:S}";
				SqlDtr = cmdInsert.ExecuteReader ();
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read ())
					{
						sw.WriteLine(info,SqlDtr.GetValue(10).ToString ().Trim (),
							GenUtil.TrimLength(SqlDtr.GetValue(9).ToString ().Trim (),22),
							SqlDtr.GetValue(0).ToString ().Trim (),
							GenUtil.TrimLength(SqlDtr.GetValue(2).ToString ().Trim (),18),
							//17.02.09 SqlDtr.GetValue(5).ToString ().Trim (),
						GenUtil.TrimLength(SqlDtr.GetValue(5).ToString().Trim (),5),
							SqlDtr.GetValue(1).ToString ().Trim (),
							GenUtil.TrimLength(SqlDtr.GetValue(6).ToString ().Trim (),10),
							SqlDtr.GetValue(3).ToString ().Trim (),
							SqlDtr.GetValue(4).ToString ().Trim (),
							SqlDtr.GetValue(11).ToString ().Trim (),
							GenUtil.TrimLength(SqlDtr.GetValue(7).ToString ().Trim (),13),
							SqlDtr.GetValue(8).ToString ().Trim ()
							);
					}
				}
				SqlDtr.Close ();
				//sw.WriteLine("+-------+------------------+------+--------------+-----+-------+--------------+----------+--------+--+-----------+-------------+");
				sw.WriteLine("+-------+----------------------+------+------------------+-----+---+----------+----------+--------+--+-------------+-------------+");
				sw.Close();
				Print();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :Rout_search.aspx,Method  BtnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ Session["Password"].ToString()   );		
			}
		}

		/// <summary>
		/// Print Method sending the text file to the printer and issue the print command to the to print the report.
		/// </summary>
		public void Print()
		{
			byte[] bytes = new byte[1024];

			// Connect to a remote device.
			try 
			{
				// Establish the remote endpoint for the socket.
				// The name of the
				// remote device is "host.contoso.com".
				IPHostEntry ipHostInfo = Dns.Resolve("127.0.0.1");
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress,63000);

				// Create a TCP/IP  socket.
				Socket sender1 = new Socket(AddressFamily.InterNetwork, 
					SocketType.Stream, ProtocolType.Tcp );

				// Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender1.Connect(remoteEP);
					//CreateLogFiles.ErrorLog("Form:StudentInformation.aspx,Method:Print"+uid);
					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());

					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2);
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\RouteSearchReport.txt<EOF>");
					//													\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\RouteSearchReport.txt

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :Rout_search.aspx,Method  BtnPrint_Click, Route SEarch report Printed, Userid :  "+ Session["Password"].ToString());
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :Rout_search.aspx,Method  BtnPrint_Click, Exception:"+ane.Message +" Route SEarch report Printed, Userid :  "+ Session["Password"].ToString());
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :Rout_search.aspx,Method  BtnPrint_Click, Exception:"+se.Message +" Route SEarch report Printed, Userid :  "+ Session["Password"].ToString());
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :Rout_search.aspx,Method  BtnPrint_Click, Exception:"+es.Message +" Route SEarch report Printed, Userid :  "+ Session["Password"].ToString());
				}
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :Rout_search.aspx,Method  BtnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ Session["Password"].ToString()   );		
			}
		}

		private void Dropsopt_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this method use to add Route name from Route table.
		/// </summary>
		private void Dropstype_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				pangrid.Visible=false;
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr;
				string str="";
				Dropsopt .Enabled=true;
				Dropsopt .Items.Clear();
				Dropsopt .Items.Add("All");
				if(Dropstype  .SelectedItem.Text.Equals("Route Name Wise"))
				{
					DropSection.Visible=false;
					str="select distinct Route_name from Route ";
					SqlDtr=obj.GetRecordSet(str);
					while(SqlDtr.Read())
					{
						Dropsopt .Items.Add(SqlDtr.GetValue(0).ToString());
					}
				}
				else if(Dropstype.SelectedItem.Text.Equals("Route No Wise"))
				{
					DropSection.Visible=false;
					str="select distinct Route_km from Route  ";
					SqlDtr=obj.GetRecordSet(str);
					while(SqlDtr.Read())
					{
						Dropsopt .Items.Add(SqlDtr.GetValue(0).ToString());
					}
				}
				else if(Dropstype .SelectedItem.Text.Equals("StudentID Wise"))
				{
					DropSection.Visible=false;
					str="select distinct Student_ID from Student_Record  ";
					SqlDtr=obj.GetRecordSet(str);
					while(SqlDtr.Read())
					{
						Dropsopt .Items.Add(SqlDtr.GetValue(0).ToString());
					}
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
				CreateLogFiles.ErrorLog(" Form :Rout_search.aspx,Method  Dropstype_SelectedIndexChanged,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}
		
		/// <summary>
		/// this method use to call ConvertIntoExcel() function.
		/// </summary>
		private void BtnExcel_ServerClick(object sender, System.EventArgs e)
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
		/// Method for writing the Report to the excel file and call the method to print the Report.
		/// </summary>
		public void ConvertIntoExcel()
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "";
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\RouteSearchReport.xls";
				//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\RouteSearchReport.txt";
				StreamWriter sw = new StreamWriter(path); 
				SqlConnection con4 ;
				LibraryClass.ItemClass obj=new LibraryClass.ItemClass ();
				SqlCommand cmdInsert=null;
				SqlDataReader SqlDtr=null;
				con4=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con4.Open ();
			
				string str="";
				
				if (Dropstype.SelectedIndex!=0)
				{  
					
						
					if(DropSection.Visible==true)
					{
						str=obj.ShowstudentrouteInfo(Dropstype.SelectedItem.Text,Dropsopt.SelectedItem.Text,DropSection .SelectedItem .Text );
						
					}
					else
					{
						str=obj.ShowstudentrouteInfo(Dropstype.SelectedItem.Text,Dropsopt.SelectedItem.Text);
						
					}
				}
				cmdInsert=new SqlCommand (str,con4);

				string des="+-------+------------------+------+--------------+-----+-------+--------------+----------+--------+--+-----------+-------------+";
				sw.WriteLine(GenUtil.GetCenterAddr("=====================",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Route Search Report",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("=====================",des.Length));
				sw.WriteLine("");
				//sw.WriteLine("+-------+----------------------+------+------------------+-----+---+----------+----------+--------+--+-------------+-------------+");
				sw.WriteLine("RouteNo\tRoute Name\tRollNo\tStudent Name \tClass\tSec\tStream\tScategory\tRank\tBG\tAddress\tPhone No");
				//sw.WriteLine("+-------+----------------------+------+------------------+-----+---+----------+----------+--------+--+-------------+-------------+");
				
				info = " {0,-7:S} {1,-22:S} {2,-6:S} {3,-18:S} {4,5:S} {5,-3:S} {6,-10:S} {7,-10:S} {8,-8:S} {9,-2:S} {10,-13:S} {11,-13:S}";
				SqlDtr = cmdInsert.ExecuteReader ();
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read ())
					{
						sw.WriteLine(SqlDtr.GetValue(10).ToString ().Trim ()+"\t"+
							GenUtil.TrimLength(SqlDtr.GetValue(9).ToString ().Trim (),22)+"\t"+
							SqlDtr.GetValue(0).ToString ().Trim ()+"\t"+
							GenUtil.TrimLength(SqlDtr.GetValue(2).ToString ().Trim (),18)+"\t"+
							SqlDtr.GetValue(5).ToString ().Trim ()+"\t"+
							SqlDtr.GetValue(1).ToString ().Trim ()+"\t"+
							GenUtil.TrimLength(SqlDtr.GetValue(6).ToString ().Trim (),10)+"\t"+
							SqlDtr.GetValue(3).ToString ().Trim ()+"\t"+
							SqlDtr.GetValue(4).ToString ().Trim ()+"\t"+
							SqlDtr.GetValue(11).ToString ().Trim ()+"\t"+
							GenUtil.TrimLength(SqlDtr.GetValue(7).ToString ().Trim (),13)+"\t"+
							SqlDtr.GetValue(8).ToString ().Trim ()
							);
					}

				}
				SqlDtr.Close ();
				//sw.WriteLine("+-------+------------------+------+--------------+-----+-------+--------------+----------+--------+--+-----------+-------------+");
				sw.Close();
				//Print();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :Rout_search.aspx,Method  BtnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		private void DropSection_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}

