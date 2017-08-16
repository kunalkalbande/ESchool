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
using System.IO ;
using System.Text;
using System.Net ;
using System.Net.Sockets;
namespace eschool.StudentFees
{
	/// <summary>
	/// Summary description for AdvanceFeesReport.
	/// </summary>
	public class AdvanceFeesReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList DropClass;
		protected System.Web.UI.WebControls.DropDownList DropSec;
		protected System.Web.UI.WebControls.TextBox Txttodate;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.WebControls.TextBox Txtfromdate;
		protected System.Web.UI.HtmlControls.HtmlButton print;
		public string rank="";
		public string duration="";
		public string student_id="";
		public string recid="";
		public string recdate="";
		public string category="";
		public string section="";
		public string classid="";
		public string sname="";
		public string stream="";
		public double tutionfee=0;
		public double computerfee=0;
		public double housefee=0;
		public double gamefee=0;
		public double sciencefee=0;
		public double annualfee=0;
		public double registraionfee=0;
		public double latefee=0;
		public double admissionfee=0;
		public double transportfee=0;
		public double developmentfee=0;
		public double dairyfee=0;
		public double security=0;
		public double total=0;
		public double Caution=0;
		public double TempCaution=0;
		public double gtutionfee=0;
		public double gcomputerfee=0;
		public double ghousefee=0;
		public double ggamefee=0;
		public double gsciencefee=0;
		public double gannualfee=0;
		public double gregistraionfee=0;
		public double glatefee=0;
		public double gadmissionfee=0;
		public double gtransportfee=0;
		public double gdevelopmentfee=0;
		public double gdairyfee=0;
		public double gsecurity=0;
		public double gtotal=0;
		public double gCaution=0;
		public double due=0;
		public double gdue=0;
		public double advance=0;
		public double gadvance=0;
		protected System.Web.UI.WebControls.TextBox Txtcurdatef;
		protected System.Web.UI.WebControls.TextBox Txtcurdatet;
		protected System.Web.UI.HtmlControls.HtmlButton Excel;
		public double gTempCaution=0;
		string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for perticular user
		///</summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString());
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"./HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Advance_&_Pending_Report.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				//string pass;
				//pass=(Session["password"].ToString ());
				if(!Page.IsPostBack)
				{
					Txtfromdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					Txttodate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					Txtcurdatef.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					Txtcurdatet.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					InventoryClass obj=new InventoryClass();
					SqlDataReader sdred=null;
					//string str="select distinct student_class from student_record sr,recuringreceipt rr where rr.student_id=sr.student_id order by student_class";
					string str="select class_name from class order by class_id";
					sdred=obj.GetRecordSet(str);
					DropClass.Items.Clear();
					DropClass.Items.Add("Select");
					while(sdred.Read())
					{
						DropClass.Items .Add (sdred.GetValue(0).ToString());
					}		
					sdred.Close();
				}
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="1";
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
				CreateLogFiles.ErrorLog(" Form :AdvanceFeesReport.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				return;
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
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.print.ServerClick += new System.EventHandler(this.print_ServerClick);
			this.Excel.ServerClick += new System.EventHandler(this.Excel_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method use to convert date DDMMYYYY to MM/DD/YYYY
		/// </summary>
		public DateTime ToMMddYYYY(string str)
		{
			int dd,mm,yy;
			string [] strarr = new string[3];			
			strarr=str.Split(new char[]{'/'},str.Length);
			dd=Int32.Parse(strarr[0]);
			mm=Int32.Parse(strarr[1]);
			yy=Int32.Parse(strarr[2]);
			DateTime dt=new DateTime(yy,mm,dd);			
			return(dt);
		}

		/// <summary>
		/// this method use to show report. in this method first student id fetch from student_record table. and this id pass in to feesdecisionmonthly() function.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{ 
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
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr=null;
				string  strSelect="";
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
							return ;
						}
						else
						{
							if(DropClass.SelectedItem.Value.ToString().Equals("All"))
							{
								strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')) and student_id not in (select student_id from tc1) order by student_class,seq_student_id,student_fname";  
								SqlDtr=obj.GetRecordSet(strSelect);
								while(SqlDtr.Read())
								{
									student_id=SqlDtr.GetValue(0).ToString().Trim();
									feesdecisionmonthly(student_id);
								}
								SqlDtr.Close();
							}
							else
							{
								if(DropClass.SelectedIndex==0 && DropSec.SelectedIndex==0)
								{
									MessageBox.Show("Please Select The Information ");
								}
								else if(DropClass.SelectedIndex!=0 && DropSec.SelectedIndex==0)
								{
									MessageBox.Show("Please Select The Section ");
								}
								else 
								{
									strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' and student_id not in (select student_id from tc1) order by student_class,seq_student_id,student_fname";   
									SqlDtr=obj.GetRecordSet(strSelect);
									while(SqlDtr.Read())
									{
										student_id=SqlDtr.GetValue(0).ToString().Trim();
										feesdecisionmonthly(student_id);
									}
									SqlDtr.Close();
								}
							}
						}
						//Due();
					}
					else
					{
						MessageBox.Show("Please enter the date");
						return;
					}
				}
				else
				{
					MessageBox.Show("Please select the class");
					return;
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: AdvanceFeesReport.aspx.cs, Method: btnSearch_Click. Exception: " + ex.Message + " User: " + pass );
			}	
		}

		/// <summary>
		/// this method use to fetch studentid from student_record table and check this not in Recuringreceipt table. and this id pass in to feesdecisionmonthlydue() function. 
		/// </summary>
		void Due()
		{
			gdue=0;
			try
			{
				InventoryClass obj=new InventoryClass   ();
				SqlDataReader SqlDtr=null;     
				string  strSelect="";
				if(DropClass.SelectedIndex!=0)
				{
					if(!Txtcurdatef.Text.Equals("")&&!Txtcurdatet.Text.Equals(""))
					{
						if(DropClass.SelectedItem.Value.ToString().Equals("All"))
						{
							strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txtcurdatet .Text.ToString())+"')) and student_admissiondate <='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' order by student_class,seq_student_id,student_fname";  
							SqlDtr=obj.GetRecordSet(strSelect);
							while(SqlDtr.Read())
							{
								student_id=SqlDtr.GetValue(0).ToString().Trim();
								feesdecisionmonthlydue(student_id);
							}
							SqlDtr.Close();
						}
						else
						{
							if(DropClass.SelectedIndex==0 && DropSec.SelectedIndex ==0)
							{
								MessageBox.Show("Please select The Information ");
							}
							else
							{
								strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and '"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text.ToString())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' order by student_class,seq_student_id,student_fname" ;  
								SqlDtr=obj.GetRecordSet(strSelect);
								while(SqlDtr.Read())
								{
									student_id=SqlDtr.GetValue(0).ToString().Trim();
									feesdecisionmonthlydue(student_id);
								}
								SqlDtr.Close();
							}
						}
					}
					else
					{
						MessageBox.Show("Please enter the date");
						return;
					}
				}
				else
				{
					MessageBox.Show("Please select the class");
					return;
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FeesDueReport.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}	
		}

		/// <summary>
		/// this method use to call printFunction().
		/// </summary>
		private void print_ServerClick(object sender, System.EventArgs e)
		{
			PrinFunction();

		}

		/// <summary>
		/// this method use to generate a report in excel format. first select student id from student record table and this id pass feesdecisionmonthly() method.
		/// in this function save data in variable. and this variable use in print.
		/// </summary>
		public void ConvertIntoExcel()
		{
			try
			{
				int i=1;
				SqlDataReader SqlDtr=null;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\Advance_PendingFeesReport.xls";
				StreamWriter sw = new StreamWriter(path);
				InventoryClass obj=new InventoryClass();
				string strSelect="";
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
							return ;
						}
						else
						{
							if(DropClass.SelectedItem.Value.ToString().Equals("All"))
							{
								strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')) and student_id not in (select student_id from tc1) order by student_class,seq_student_id,student_fname";  
								SqlDtr=obj.GetRecordSet(strSelect);
							}
							else
							{
								if(DropClass.SelectedIndex==0 && DropSec.SelectedIndex ==0)
								{
									MessageBox.Show("Please select The Information ");
								}
								else
								{
									strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' and student_id not in (select student_id from tc1) order by student_class,seq_student_id,student_fname";   
									SqlDtr=obj.GetRecordSet(strSelect);
								}
							}
							string des="----+-----+--------+-----+-------------+----+-+-------+-----+-----+-----+----+-----+-----+----+-----+-----+-----+-----+-----+-----+------";
							//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School",des.Length));
							//sw.WriteLine(GenUtil.GetCenterAddr("---------------------------------------------------------------",des.Length));    //add by vikas sharma date 03.03.09
							sw.WriteLine(GenUtil.GetCenterAddr("ADVANCE / PENDING FEES REPORT For Class:"+DropClass.SelectedItem.Text+" And Section :"+DropSec.SelectedItem.Text ,des.Length));    //add by vikas sharma date 21.11.07
							//sw.WriteLine(GenUtil.GetCenterAddr("ADVANCE / PENDING FEES REPORT ",des.Length));
							//sw.WriteLine(GenUtil.GetCenterAddr(" For Class:"+DropClass.SelectedItem.Text+" And Section :"+DropSec.SelectedItem.Text ,des.Length));
							//sw.WriteLine(GenUtil.GetCenterAddr("---------------------------------------------------------------",des.Length));    //add by vikas sharma date 03.03.09
							sw.WriteLine(GenUtil.GetCenterAddr("Date From "+Txtfromdate.Text+" To "+Txttodate.Text ,des.Length));
							sw.WriteLine("S.N0\tReceiID\tR.Date\tStudID\tStudent Name\tCategory\tTutio\tComp.\tHouse\tGame\tScien\tRegis\tLate\tAdmis\tTrans\tEnv\tDiary\tAnnual\tSecur\tTotal\tPendi\tAdvan");
							string duration="",mon="";
							mon=GenUtil.ConvertMonthName(Txtfromdate.Text.ToString());
							if(mon.Length>=3)
								mon=mon.Substring(0,3);
							duration=mon + "-";
							mon=GenUtil.ConvertMonthName(Txttodate.Text.ToString());
							if(mon.Length>=3)
								mon=mon.Substring(0,3);
							duration=duration+mon;
							if(SqlDtr.HasRows)
							{
								sw.WriteLine(""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+"ADVANCE"+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+"");
								while(SqlDtr.Read())
								{	
									student_id=SqlDtr.GetValue(0).ToString().Trim();
									feesdecisionmonthly(student_id);
									string year=recdate.Substring(recdate.IndexOf("/",recdate.IndexOf("/")+1)+3,2);
									mon=recdate.Substring(0,recdate.IndexOf("/",recdate.IndexOf("/")+1)+1);
									recdate=mon+year;
									/*sw.WriteLine(i.ToString()+"\t"+recid.ToString()+"\t"+recdate.ToString()+"\t"+student_id.ToString()+"\t"+GenUtil.TrimLength(sname.Trim(),13)+"\t"+
									category.ToString()+"\t"+"N/A"+"\t"+"N/A"+"\t"+"N/A"+"\t"+"N/A"+"\t"+"N/A"+"\t"+
									"N/A"+"\t"+"N/A"+"\t"+"N/A"+"\t"+"N/A"+"\t"+"N/A"+"\t"+
									"N/A"+"\t"+"N/A"+"\t"+"N/A"+"\t"+total.ToString()+"\t"+"N/A"+"\t"+advance.ToString());*/

									sw.WriteLine(i.ToString()+"\t"+recid.ToString()+"\t"+recdate.ToString()+"\t"+student_id.ToString()+"\t"+GenUtil.TrimLength(sname.Trim(),13)+"\t"+
										category.ToString()+"\t"+tutionfee.ToString()+"\t"+computerfee.ToString()+"\t"+housefee.ToString()+"\t"+gamefee.ToString()+"\t"+sciencefee.ToString()+"\t"+
										registraionfee.ToString()+"\t"+latefee.ToString()+"\t"+admissionfee.ToString()+"\t"+transportfee.ToString()+"\t"+developmentfee.ToString()+"\t"+
										dairyfee.ToString()+"\t"+annualfee.ToString()+"\t"+0+"\t"+total.ToString()+"\t"+"N/A"+"\t"+advance.ToString());
									
									i++;
								}
							}
							SqlDtr.Close();
							try                                                     
							{
								if(DropClass.SelectedIndex!=0)
								{
									if(!Txtcurdatef.Text.Equals("")&&!Txtcurdatet.Text.Equals(""))
									{
										if(DropClass.SelectedItem.Value.ToString().Equals("All"))
										{
											strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txtcurdatet .Text.ToString())+"')) and student_admissiondate <='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' order by student_class,seq_student_id,student_fname";
											SqlDtr=obj.GetRecordSet(strSelect);
											if(SqlDtr.HasRows)
											{
												sw.WriteLine(""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+"PENDING"+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+"");
												while(SqlDtr.Read())
												{
													student_id=SqlDtr.GetValue(0).ToString().Trim();
													feesdecisionmonthlydue(student_id);
													sw.WriteLine(i.ToString()+"\t"+recid.ToString()+"\t"+recdate.ToString()+"\t"+student_id.ToString()+"\t"+GenUtil.TrimLength(sname.Trim(),13)+"\t"+classid.ToString()+"\t"+
														category.ToString()+"\t"+tutionfee.ToString()+"\t"+computerfee.ToString()+"\t"+housefee.ToString()+"\t"+gamefee.ToString()+"\t"+sciencefee.ToString()+"\t"+
														registraionfee.ToString()+"\t"+latefee.ToString()+"\t"+admissionfee.ToString()+"\t"+transportfee.ToString()+"\t"+developmentfee.ToString()+"\t"+
														dairyfee.ToString()+"\t"+annualfee.ToString()+"\t"+security.ToString()+"\t"+total.ToString());
													i++;
												}
											}
											SqlDtr.Close();
										}
										else
										{
											if(DropClass.SelectedIndex==0 && DropSec.SelectedIndex ==0)
											{
												MessageBox.Show("Please select The Information ");
											}
											else
											{
												strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and '"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text.ToString())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and student_id not in (select student_id from tc1) order by student_class,seq_student_id,student_fname" ;  //added by vishnu on 15/10
												SqlDtr=obj.GetRecordSet(strSelect);
												if(SqlDtr.HasRows)
												{
													sw.WriteLine(""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+"PENDING"+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+"");
													while(SqlDtr.Read())
													{
														student_id=SqlDtr.GetValue(0).ToString().Trim();
														feesdecisionmonthlydue(student_id);
														/*sw.WriteLine(i.ToString()+"\t"+"N/A"+"\t"+"N/A"+"\t"+student_id.ToString()+"\t"+GenUtil.TrimLength(sname.Trim(),13)+"\t"+
														category.ToString()+"\t"+tutionfee.ToString()+"\t"+computerfee.ToString()+"\t"+housefee.ToString()+"\t"+gamefee.ToString()+"\t"+sciencefee.ToString()+"\t"+
														registraionfee.ToString()+"\t"+latefee.ToString()+"\t"+admissionfee.ToString()+"\t"+transportfee.ToString()+"\t"+developmentfee.ToString()+"\t"+
														dairyfee.ToString()+"\t"+annualfee.ToString()+"\t"+security.ToString()+"\t"+total.ToString()+"\t"+due.ToString()+"\t"+"N/A");*/
													
														sw.WriteLine(i.ToString()+"\t"+"N/A"+"\t"+"N/A"+"\t"+student_id.ToString()+"\t"+GenUtil.TrimLength(sname.Trim(),13)+"\t"+
															category.ToString()+"\t"+"N/A"+"\t"+"N/A"+"\t"+"N/A"+"\t"+"N/A"+"\t"+"N/A"+"\t"+
															"N/A"+"\t"+"N/A"+"\t"+"N/A"+"\t"+"N/A"+"\t"+"N/A"+"\t"+
															"N/A"+"\t"+"N/A"+"\t"+"N/A"+"\t"+total.ToString()+"\t"+due.ToString()+"\t"+"N/A");
													
														i++;
													}
													
												}
												SqlDtr.Close();
												if(DropClass.SelectedItem.Value.ToString().Equals("All"))
												{
													strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"') and r.student_id!=0 and r.student_id=s.student_id and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' and regid!=0) and r1.student_id=0 and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')";
													SqlDtr=obj.GetRecordSet(strSelect);
													  
												}
												else
												{
													//20.09.08 strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"') and r.student_id!=0 and r.student_id=s.student_id and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' and regid!=0 ) and student_class='"+DropClass.SelectedItem.Value.ToString()+"'  and r1.student_id=0 and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')";
													strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"') and r.student_id!=0 and r.student_id=s.student_id and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')";// union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' and regid!=0 ) and student_class='"+DropClass.SelectedItem.Value.ToString()+"'  and r1.student_id=0 and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')";
													SqlDtr=obj.GetRecordSet(strSelect);
												}
												
											{
												string feetype="";
												if(SqlDtr.HasRows)
												{
													sw.WriteLine(""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+"COLLECTION"+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+""+"\t"+"");
													while(SqlDtr.Read())
													{
														recid=SqlDtr.GetValue(0).ToString().Trim();
														feetype=SqlDtr.GetValue(1).ToString();
														feesdecisionmonthlycomplete(recid,feetype);
														string year=recdate.Substring(recdate.IndexOf("/",recdate.IndexOf("/")+1)+3,2);
														mon=recdate.Substring(0,recdate.IndexOf("/",recdate.IndexOf("/")+1)+1);
														recdate=mon+year;
														sw.WriteLine(i.ToString()+"\t"+recid.ToString()+"\t"+recdate.ToString()+"\t"+student_id.ToString()+"\t"+GenUtil.TrimLength(sname.Trim(),13)+"\t"+
															GenUtil.TrimLength(category.ToString(),5)+"\t"+tutionfee.ToString()+"\t"+computerfee.ToString()+"\t"+housefee.ToString()+"\t"+gamefee.ToString()+"\t"+sciencefee.ToString()+"\t"+
															registraionfee.ToString()+"\t"+latefee.ToString()+"\t"+admissionfee.ToString()+"\t"+transportfee.ToString()+"\t"+developmentfee.ToString()+"\t"+
															dairyfee.ToString()+"\t"+annualfee.ToString()+"\t"+security.ToString()+"\t"+total.ToString()+"\t"+"N/A" +"\t"+"N/A");
														i++;
													}
												}
												SqlDtr.Close();
											}
											}
										}
									}
									else
									{
										MessageBox.Show("Please enter the date");
										return;
									}
								}
								else
								{
									MessageBox.Show("Please select the class");
									return;
								}
							}
							catch(Exception ex)
							{
								CreateLogFiles.ErrorLog(" Form :AdvanceFeeReport.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
							}	
							sw.WriteLine("\t\t\t\t\t"+"Grand Total"+"\t"+gtutionfee.ToString()+"\t"+gcomputerfee.ToString()+"\t"+ghousefee.ToString()+"\t"+ggamefee.ToString()+"\t"+gsciencefee.ToString()+"\t"+
								gregistraionfee.ToString()+"\t"+glatefee.ToString()+"\t"+gadmissionfee.ToString()+"\t"+gtransportfee.ToString()+"\t"+gdevelopmentfee.ToString()+"\t"+
								gdairyfee.ToString()+"\t"+gannualfee.ToString()+"\t"+gsecurity.ToString()+"\t"+gtotal.ToString()+"\t"+gdue.ToString()+"\t"+gadvance.ToString());
							sw.Close();
							CreateLogFiles.ErrorLog(" Form :AdvanceFeeReport.aspx,Method  Button1_Click, DailyFeeReport View , Userid :  "+ pass   );
						}
					}
				}
				
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :AdvanceFeeReport.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}

		/// <summary>
		/// this method use to generate a report in text format. first select student id from student record table and this id pass feesdecisionmonthly() method.
		/// in this function save data in variable. and this variable use in print.
		/// </summary>
		public void PrinFunction()
		{
			try
			{
				int i=1,ii=0,Ok=0;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "",strSelect="";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\Advance_PendingFeesReport.txt";
				StreamWriter sw = new StreamWriter(path); 
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr=null;
				int[] St_id=new int[15];
				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)72);				
				sw.Write((char)27);
				sw.Write((char)78);
				sw.Write((char)6);
				sw.Write((char)27);
				sw.Write((char)15);
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
							return ;
						}
						else
						{
							if(DropClass.SelectedItem.Value.ToString().Equals("All"))
							{
								strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')) and student_id not in (select student_id from tc1) order by student_class,seq_student_id,student_fname";  
								SqlDtr=obj.GetRecordSet(strSelect);
							}
							else
							{
								if(DropClass.SelectedIndex==0 && DropSec.SelectedIndex ==0)
								{
									MessageBox.Show("Please select The Information ");
								}
								else
								{
									strSelect = "select * from student_record where student_id in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' and student_id not in (select student_id from tc1) order by student_class,seq_student_id,student_fname";   
									SqlDtr=obj.GetRecordSet(strSelect);
								}
							}
							//string des="----+-----+--------+-----+-------------+----+-+-------+-----+-----+-----+----+-----+-----+----+-----+-----+-----+-----+-----+-----+------";
							string des="+----+-----+--------+-----+-------------+----+-----+-----+----+----+-----+----+----+----+-----+-----+----+-----+-----+------+-----+-----+";
							string Class=DropClass.SelectedItem.Text;
							string Section=DropSec.SelectedItem.Text;
							//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School",des.Length));
							sw.WriteLine(GenUtil.GetCenterAddr("ADVANCE/PENDING FEES REPORT For Class:"+DropClass.SelectedItem.Text+" And Section :"+DropSec.SelectedItem.Text ,des.Length));    //add by vikas sharma date 21.11.07
							sw.WriteLine(GenUtil.GetCenterAddr("  Date From "+Txtfromdate.Text+" To "+Txttodate.Text ,des.Length));
							info = " {0,-4:S} {1,-5:S} {2,-8:S} {3,-5:S} {4,-13:S} {5,4:S} {6,5:S} {7,5:S} {8,4:S} {9,4:S} {10,5:S} {11,4:S} {12,4:S} {13,4:S} {14,5:S} {15,5:S} {16,4:S} {17,5:S} {18,5:S} {19,6:S} {20,5:S}{21,5:S}";
							sw.WriteLine("+----+-----+--------+-----+-------------+----+-----+-----+----+----+-----+----+----+----+-----+-----+----+-----+-----+------+-----+-----+");
							sw.WriteLine("|S.N0|RecID|R.Date  |St.ID|Student Name |Cate|Tutio|Comp.|Hous|Game|Scien|Regi|Late|Admi|Trans| Env |Diar|Annua|Secur|Total |Pendi|Advan");
							sw.WriteLine("+----+-----+--------+-----+-------------+----+-----+-----+----+----+-----+----+----+----+-----+-----+----+-----+-----+------+-----+-----+");
							/// 1234 12345 12345678 12345 1234567890123 1234 12345 12345 1234 1234 12345 1234 1234 1234 12345 12345 1234 12345 12345 123456 12345 12345 
							string duration="",mon="";
							mon=GenUtil.ConvertMonthName(Txtfromdate.Text.ToString());
							if(mon.Length>=3)
								mon=mon.Substring(0,3);
							duration=mon + "-";
							mon=GenUtil.ConvertMonthName(Txttodate.Text.ToString());
							if(mon.Length>=3)
								mon=mon.Substring(0,3);
							duration=duration+mon;
							if(SqlDtr.HasRows)
							{
								//sw.WriteLine(info,"","","","","","","","","","","ADVANCE","","","","","","","","","","","");
								sw.WriteLine(GenUtil.GetCenterAddr("ADVANCE",des.Length));
								while(SqlDtr.Read())
								{	
									student_id=SqlDtr.GetValue(0).ToString().Trim();
									St_id[ii]=Convert.ToInt32(SqlDtr.GetValue(0));
									feesdecisionmonthly(student_id);
									string year=recdate.Substring(recdate.IndexOf("/",recdate.IndexOf("/")+1)+3,2);
									mon=recdate.Substring(0,recdate.IndexOf("/",recdate.IndexOf("/")+1)+1);
									recdate=mon+year;
									/*sw.WriteLine(info,i.ToString(),recid.ToString(),recdate.ToString(),student_id.ToString(),GenUtil.TrimLength(sname.Trim(),13),
									category.ToString(),"N/A","N/A","N/A","N/A","N/A",
									"N/A","N/A","N/A","N/A","N/A",
									"N/A","N/A","N/A",total.ToString(),"N/A",advance.ToString());*/

									sw.WriteLine(info,i.ToString(),recid.ToString(),recdate.ToString(),student_id.ToString(),GenUtil.TrimLength(sname.Trim(),13),
										category.ToString(),tutionfee.ToString(),computerfee.ToString(),housefee.ToString(),gamefee.ToString(),sciencefee.ToString(),
										registraionfee.ToString(),latefee.ToString(),admissionfee.ToString(),transportfee.ToString(),developmentfee.ToString(),
										dairyfee.ToString(),annualfee.ToString(),"0",total.ToString(),"N/A",advance.ToString());
									i++;
									ii++;
								}
							}
							SqlDtr.Close();
							try                                                     
							{
								if(DropClass.SelectedIndex!=0)
								{
									if(!Txtcurdatef.Text.Equals("")&&!Txtcurdatet.Text.Equals(""))
									{
										if(DropClass.SelectedItem.Value.ToString().Equals("All"))
										{
											strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txtcurdatet .Text.ToString())+"')) and student_admissiondate <='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' order by student_class,seq_student_id,student_fname"; 
											SqlDtr=obj.GetRecordSet(strSelect);
											if(SqlDtr.HasRows)
											{
												//sw.WriteLine(info,"","","","","","","","","","","PENDING","","","","","","","","","","","");
												sw.WriteLine(GenUtil.GetCenterAddr("PENDING",des.Length));
												while(SqlDtr.Read())
												{
													student_id=SqlDtr.GetValue(0).ToString().Trim();
													feesdecisionmonthlydue(student_id);
													/*sw.WriteLine(info,i.ToString(),recid.ToString(),recdate.ToString(),student_id.ToString(),GenUtil.TrimLength(sname.Trim(),13),classid.ToString(),
													category.ToString(),tutionfee.ToString(),computerfee.ToString(),housefee.ToString(),gamefee.ToString(),sciencefee.ToString(),
													registraionfee.ToString(),latefee.ToString(),admissionfee.ToString(),transportfee.ToString(),developmentfee.ToString(),
													dairyfee.ToString(),annualfee.ToString(),security.ToString(),total.ToString());*/

													sw.WriteLine(info,i.ToString(),recid.ToString(),recdate.ToString(),student_id.ToString(),GenUtil.TrimLength(sname.Trim(),13),
														category.ToString(),"N/A","N/A","N/A","N/A","N/A",
														"N/A","N/A","N/A","N/A","N/A",
														"N/A","N/A","N/A",total.ToString(),due.ToString(),"N/A");
													i++;
												}
											}
											SqlDtr.Close();
										}
										else
										{
											if(DropClass.SelectedIndex==0 && DropSec.SelectedIndex ==0)
											{
												MessageBox.Show("Please select The Information ");
											}
											else
											{
												strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and '"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text.ToString())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text.ToString())+"' and student_id not in (select student_id from tc1) order by student_class,seq_student_id,student_fname" ;  //added by vishnu on 15/10
												SqlDtr=obj.GetRecordSet(strSelect);
												if(SqlDtr.HasRows)
												{
													//sw.WriteLine(info,"","","","","","","","","","","PENDING","","","","","","","","","","","");
													sw.WriteLine(GenUtil.GetCenterAddr("PENDING",des.Length));
													while(SqlDtr.Read())
													{
														student_id=SqlDtr.GetValue(0).ToString().Trim();
														feesdecisionmonthlydue(student_id);
														/*sw.WriteLine(info,i.ToString(),"N/A","N/A",student_id.ToString(),GenUtil.TrimLength(sname.Trim(),13),
														category.ToString(),tutionfee.ToString(),computerfee.ToString(),housefee.ToString(),gamefee.ToString(),sciencefee.ToString(),
														registraionfee.ToString(),latefee.ToString(),admissionfee.ToString(),transportfee.ToString(),developmentfee.ToString(),
														dairyfee.ToString(),annualfee.ToString(),security.ToString(),total.ToString(),due.ToString(),"N/A");*/

														sw.WriteLine(info,i.ToString(),"N/A","N/A",student_id.ToString(),GenUtil.TrimLength(sname.Trim(),13),
															category.ToString(),"N/A","N/A","N/A","N/A","N/A",
															"N/A","N/A","N/A","N/A","N/A",
															"N/A","N/A","N/A",total.ToString(),due.ToString(),"N/A");
														i++;
													}
													
												}
												SqlDtr.Close();
												if(DropClass.SelectedItem.Value.ToString().Equals("All"))
												{
													strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"') and r.student_id!=0 and r.student_id=s.student_id and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' and regid!=0) and r1.student_id=0 and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')";
													SqlDtr=obj.GetRecordSet(strSelect);
												}
												else
												{
													//19.09.08 strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"') and r.student_id!=0 and r.student_id=s.student_id and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' and regid!=0 ) and student_class='"+DropClass.SelectedItem.Value.ToString()+"'  and r1.student_id=0 and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')";
													strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"') and r.student_id!=0 and r.student_id=s.student_id and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')";// union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"' and regid!=0 ) and student_class='"+DropClass.SelectedItem.Value.ToString()+"'  and r1.student_id=0 and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"')";
													SqlDtr=obj.GetRecordSet(strSelect);
						                               
												}
											{
												string feetype="";
												if(SqlDtr.HasRows)
												{
													//sw.WriteLine(info,"","","","","","","","","","","COLLECTION","","","","","","","","","","","");
													sw.WriteLine(GenUtil.GetCenterAddr("COLLECTION",des.Length));
													while(SqlDtr.Read())
													{  
														recid=SqlDtr.GetValue(0).ToString().Trim();
														feetype=SqlDtr.GetValue(1).ToString();
														feesdecisionmonthlycomplete(recid,feetype);
														string year=recdate.Substring(recdate.IndexOf("/",recdate.IndexOf("/")+1)+3,2);
														mon=recdate.Substring(0,recdate.IndexOf("/",recdate.IndexOf("/")+1)+1);
														recdate=mon+year;
														sw.WriteLine(info,i.ToString(),recid.ToString(),recdate.ToString(),student_id.ToString(),GenUtil.TrimLength(sname.Trim(),13),
															GenUtil.TrimLength(category.ToString(),5),tutionfee.ToString(),computerfee.ToString(),housefee.ToString(),gamefee.ToString(),sciencefee.ToString(),
															registraionfee.ToString(),latefee.ToString(),admissionfee.ToString(),transportfee.ToString(),developmentfee.ToString(),
															dairyfee.ToString(),annualfee.ToString(),security.ToString(),total.ToString(),"N/A" ,"N/A");
														i++;
													}
														
												}
												SqlDtr.Close();
											}
											}
										}
									}
									else
									{
										MessageBox.Show("Please enter the date");
										return;
									}
								}
								else
								{
									MessageBox.Show("Please select the class");
									return;
								}
								
							}
							catch(Exception ex)
							{
								CreateLogFiles.ErrorLog(" Form :AdvanceFeeReport.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
							}	
							sw.WriteLine(des);
							string info1="Grand Total                                   {0,5:S} {1,5:S} {2,4:S} {3,4:S} {4,5:S}{5,5:S} {6,4:S} {7,4:S} {8,5:S} {9,5:S} {10,4:S} {11,5:S} {12,5:S} {13,6:S} {14,5:S}{15,6:S}";
							sw.WriteLine(info1,gtutionfee.ToString(),gcomputerfee.ToString(),GenUtil.TrimLength(ghousefee.ToString(),4),GenUtil.TrimLength(ggamefee.ToString(),4),gsciencefee.ToString(),
								gregistraionfee.ToString(),glatefee.ToString(),gadmissionfee.ToString(),gtransportfee.ToString(),gdevelopmentfee.ToString(),
								gdairyfee.ToString(),gannualfee.ToString(),gsecurity.ToString(),gtotal.ToString(),gdue.ToString(),gadvance.ToString());
							sw.WriteLine(des);
							sw.Close();
							Print();
							CreateLogFiles.ErrorLog(" Form :AdvanceFeeReport.aspx,Method  Button1_Click, DailyFeeReport View , Userid :  "+ pass   );
						}
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :AdvanceFeeReport.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\Advance_PendingFeeReport.txt<EOF>");
					///													\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\Advance_PendingFeeReport.txt
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :AdvanceFeeReport.aspx,Method :  Print(),  DailyFeeReport Printed , Userid :  "+ pass   );							 
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :AdvanceFeeReport.aspx,Method  Button1_Click,  Exception: "+ane.Message+" , Userid :  "+ pass   );
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :AdvanceFeeReport.aspx,Method  Button1_Click,  Exception: "+se.Message+" , Userid :  "+ pass   );
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :AdvanceFeeReport.aspx,Method  Button1_Click,  Exception: "+es.Message+" , Userid :  "+ pass   );
				}
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :AdvanceFeeReport.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}

		/// <summary>
		/// this method first get information from recuringreceipt table base on passed student id.after that get from student_record table. and also get fees from recuringreceipt table.
		/// </summary>
		public void feesdecisionmonthly(string student_id1)
		{
			rank="";
			category="";
			section="";
			classid="";
			sname="";
			stream="";
			tutionfee=0;
			computerfee=0;
			housefee=0;
			gamefee=0;
			sciencefee=0;
			annualfee=0;
			registraionfee=0;
			latefee=0;
			admissionfee=0;
			transportfee=0;
			developmentfee=0;
			dairyfee=0;
			security=0;
			total=0;
			Caution=0;
			advance=0;
			TempCaution=0;
			recid="";
			recdate="";
			string computer="";
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr1=null;
				InventoryClass obj1=new InventoryClass();
				string str2="";
				str2="select recuringid,FeeSubDt from recuringreceipt where student_id='"+student_id1+"'";
				SqlDtr1=obj.GetRecordSet(str2);
				if(SqlDtr1.Read())
				{
					recid=SqlDtr1.GetValue(0).ToString();
					recdate=GenUtil.trimDate(SqlDtr1.GetDateTime(1).ToString());
				}
				SqlDtr1.Close();
				if(!student_id.Equals("0"))
				{
					str2="select student_fname,seq_student_id,student_class,rank,scategory,student_stream,computer from student_record where student_id='"+student_id1+"'";
					SqlDtr1=obj.GetRecordSet(str2);
					if(SqlDtr1.Read())
					{
						sname=SqlDtr1.GetString(0).ToString();
						section=SqlDtr1.GetString(1).ToString();
						classid=SqlDtr1.GetString(2).ToString();
						rank=SqlDtr1.GetString(3).ToString();
						category=SqlDtr1.GetString(4).ToString();
						stream=SqlDtr1.GetString(5).ToString();
						computer=SqlDtr1.GetString(6).ToString();
					}
					SqlDtr1.Close();
					str2="select RecuringID,fees_type,securityfee,Latefee,RegFee,feesubdt,diary_fee,tution_fee,computer_fee,science_fee,game_fee,transport_fee,admission_fee,annual_fee,envp_fee,hostel_fee,fees_amount,period,periodto from recuringreceipt where student_id='"+student_id+"' and feesubdt between '"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text)+"' and period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and periodto='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"'" ;
					SqlDtr1=obj.GetRecordSet(str2);
					if(SqlDtr1.Read())
					{
						security=double.Parse(SqlDtr1.GetValue(2).ToString());
						latefee=double.Parse(SqlDtr1.GetValue(3).ToString());
						registraionfee=double.Parse(SqlDtr1.GetValue(4).ToString());
						recdate=GenUtil.trimDate(SqlDtr1.GetDateTime(5).ToString());
						dairyfee=double.Parse(SqlDtr1.GetValue(6).ToString());
						tutionfee=double.Parse(SqlDtr1.GetValue(7).ToString());
						computerfee=double.Parse(SqlDtr1.GetValue(8).ToString());
						sciencefee=double.Parse(SqlDtr1.GetValue(9).ToString());
						housefee=double.Parse(SqlDtr1.GetValue(15).ToString());
						gamefee=double.Parse(SqlDtr1.GetValue(10).ToString());
						annualfee=double.Parse(SqlDtr1.GetValue(13).ToString());
						admissionfee=double.Parse(SqlDtr1.GetValue(12).ToString());
						transportfee=double.Parse(SqlDtr1.GetValue(11).ToString());
						developmentfee=double.Parse(SqlDtr1.GetValue(14).ToString());
						total=double.Parse(SqlDtr1.GetValue(16).ToString());
						DateTime period=System.Convert.ToDateTime(ToMMddYYYY(GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr1.GetDateTime(17).ToString()))));
						DateTime periodto=System.Convert.ToDateTime(ToMMddYYYY(GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr1.GetDateTime(18).ToString()))));
						System.TimeSpan diff=periodto.Subtract(period);
						int idays=diff.Days;
						DateTime period1=System.Convert.ToDateTime(ToMMddYYYY(Txtcurdatef.Text));
						DateTime periodto1=System.Convert.ToDateTime(ToMMddYYYY(Txtcurdatet.Text));
						DateTime period2=System.Convert.ToDateTime(ToMMddYYYY(Txtfromdate.Text));
						DateTime periodto2=System.Convert.ToDateTime(ToMMddYYYY(Txttodate.Text));
						System.TimeSpan diff2=period2.Subtract(period1);
						int idays2=diff2.Days;
						System.TimeSpan diff1=periodto1.Subtract(period1);
						int idays1=diff1.Days;
						int mon=0;
						if((idays/idays1)>0)
							mon=idays/idays1;
						if(mon>1)
						{
							// 7/02/09 annualfee=annualfee/mon;
							// 7/02/09 developmentfee=developmentfee/mon;
							// 7/02/09 dairyfee=dairyfee/mon;
							// 7/02/09 latefee=latefee/mon;
							//dairyfee=dairyfee/mon;
							// 7/02/09 admissionfee=admissionfee/mon;
							annualfee=0;
							developmentfee=0;
							dairyfee=0;
							latefee=0;
							admissionfee=0;
							
							//********************************Start******************************************* 
							//add by vikas sharma date on 11.02.09 advance transport fees show wrong.
							string start_period=SqlDtr1.GetValue(1).ToString().Trim();
							string Recuring_id =SqlDtr1.GetValue(0).ToString().Trim();
							start_period=start_period.Substring(0,3);
							//end_period=end_period.Substring(0,end_period.IndexOf('/'));
							if(!start_period.Equals("Apr"))
							{
								transportfee=transportfee/mon;
							}
							else
							{
								//int duration=Convert.ToInt32(end_period)-Convert.ToInt32(start_period);
								int month=idays/30;
								month=month-1;
								double onemonthfee=transportfee/month;
								transportfee=transportfee+onemonthfee;
								transportfee=transportfee/mon;
							}
							//************************end****************************************************
							// 7/02/09 transportfee=transportfee/mon;

							tutionfee=tutionfee/mon;
							computerfee=computerfee/mon;
							sciencefee=sciencefee/mon;
							gamefee=gamefee/mon;
							housefee=housefee/mon;
							// 07/02/09 total=total/mon;
							total=tutionfee+computerfee+sciencefee+gamefee+housefee+transportfee;
						}
						// add by vikas sharma 20.09.08
						gannualfee=annualfee;
						gdevelopmentfee=developmentfee;
						gdairyfee=dairyfee;
						glatefee=latefee;
						gadmissionfee=admissionfee;
						gtransportfee=transportfee;
						gtutionfee=tutionfee;
						gcomputerfee=computerfee;
						gsciencefee=sciencefee;
						ggamefee=gamefee;
						ghousefee=housefee;
						gtotal+=total;
						advance=total;
						gadvance+=advance;
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Some Database Problem");
				CreateLogFiles.ErrorLog(" Form :AdvanceFeesReceipt.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				return ;
			}
		}

		/// <summary>
		/// this method use to call ConvertExcelFile.
		/// </summary>
		private void Excel_ServerClick(object sender, System.EventArgs e)
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
		/// this method use to get complete fees from fees decision table.
		/// </summary>
		public bool feesdecisionmonthlycomplete(string student_id1,string feestype1)//added by vishnu on 02/02/2008
		{
			rank="";
			category="";
			section="";
			classid="";
			sname="";
			stream="";
			tutionfee=0;
			computerfee=0;
			housefee=0;
			gamefee=0;
			sciencefee=0;
			annualfee=0;
			registraionfee=0;
			latefee=0;
			admissionfee=0;
			transportfee=0;
			developmentfee=0;
			dairyfee=0;
			security=0;
			total=0;
			Caution=0;
			TempCaution=0;
			student_id=""; 
			string recuringid="";
			string computer="";
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr1=null;
				InventoryClass obj1=new InventoryClass();
				string str2="";
				if(feestype1.Equals("RegistrationFee"))
				{
					str2="select recuringid,fees_type from recuringreceipt where  regid='" +student_id1+"' and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"'";
				}
				else
				{
					str2="select recuringid,fees_type from recuringreceipt where student_id='"+student_id1+"'and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtcurdatef.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txtcurdatet.Text.Trim())+"'";
				}
               
				SqlDtr1=obj.GetRecordSet(str2);
				if(SqlDtr1.Read())
				{
					student_id=student_id1;
					recid=SqlDtr1.GetValue(0).ToString();
				}
				SqlDtr1.Close();
				if(!student_id.Equals("0"))
				{
					str2="select student_fname,seq_student_id,student_class,scategory,student_stream from student_record where student_id='"+student_id+"' union select student_fname,student_stream,student_class,student_category,student_stream from student_registration where student_id='"+student_id+"' order by student_class,Seq_student_id,student_fname";
					SqlDtr1=obj.GetRecordSet(str2);
					if(SqlDtr1.Read())
					{
						sname=SqlDtr1.GetString(0).ToString();
						section=SqlDtr1.GetString(1).ToString();
						classid=SqlDtr1.GetString(2).ToString();
						category=SqlDtr1.GetString(3).ToString();
						stream=SqlDtr1.GetString(4).ToString();

					}
					SqlDtr1.Close();
					str2="select RecuringID,fees_type,securityfee,Latefee,RegFee,feesubdt,diary_fee,tution_fee,computer_fee,science_fee,game_fee,transport_fee,admission_fee,annual_fee,envp_fee,hostel_fee,fees_amount from recuringreceipt where (student_id='"+student_id+"' or regid='"+student_id+"') and feesubdt between '"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text) +"' and recuringid='"+recid+"'" ;//added 2/2/2008
					SqlDtr1=obj.GetRecordSet(str2);
					if(SqlDtr1.Read())
					{
						recuringid=SqlDtr1.GetValue(0).ToString();
						duration=SqlDtr1.GetString(1).ToString().Trim();
						if(duration.Length>9&&duration.IndexOf(":")>0)
						{
							string[] s=duration.Split(new char[] {':'},duration.Length);
							duration="";
							duration=s[0].Substring(0,3)+s[0].Substring(5,2);
							duration=duration+":"+s[1].Substring(0,3)+s[1].Substring(5,2);
						}
											
						if(SqlDtr1.GetValue(2).ToString()!=null && SqlDtr1.GetValue(2).ToString()!="")
							security=double.Parse(SqlDtr1.GetValue(2).ToString());
						else
							security=0;

						if(SqlDtr1.GetValue(3).ToString()!=null && SqlDtr1.GetValue(3).ToString()!="")
							latefee=double.Parse(SqlDtr1.GetValue(3).ToString());
						else
							latefee=0;

						if(SqlDtr1.GetValue(4).ToString()!=null && SqlDtr1.GetValue(4).ToString()!="")
							registraionfee=double.Parse(SqlDtr1.GetValue(4).ToString());
						else
							registraionfee=0;

						if(SqlDtr1.GetValue(5).ToString()!=null && SqlDtr1.GetValue(5).ToString()!="")
							recdate=GenUtil.trimDate(SqlDtr1.GetDateTime(5).ToString());
						else
							recdate="";

						if(SqlDtr1.GetValue(6).ToString()!=null && SqlDtr1.GetValue(6).ToString()!="")
							dairyfee=double.Parse(SqlDtr1.GetValue(6).ToString());
						else
							dairyfee=0;

						if(SqlDtr1.GetValue(7).ToString()!=null && SqlDtr1.GetValue(7).ToString()!="")
							tutionfee=double.Parse(SqlDtr1.GetValue(7).ToString());
						else
							tutionfee=0;

						if(SqlDtr1.GetValue(8).ToString()!=null && SqlDtr1.GetValue(8).ToString()!="")
							computerfee=double.Parse(SqlDtr1.GetValue(8).ToString());
						else
							computerfee=0;

						if(SqlDtr1.GetValue(9).ToString()!=null && SqlDtr1.GetValue(9).ToString()!="")
							sciencefee=double.Parse(SqlDtr1.GetValue(9).ToString());
						else
							sciencefee=0;

						if(SqlDtr1.GetValue(15).ToString()!=null && SqlDtr1.GetValue(15).ToString()!="")
							housefee=double.Parse(SqlDtr1.GetValue(15).ToString());
						else
							housefee=0;

						if(SqlDtr1.GetValue(10).ToString()!=null && SqlDtr1.GetValue(10).ToString()!="")
							gamefee=double.Parse(SqlDtr1.GetValue(10).ToString());
						else
							gamefee=0;

						if(SqlDtr1.GetValue(13).ToString()!=null && SqlDtr1.GetValue(13).ToString()!="")
							annualfee=double.Parse(SqlDtr1.GetValue(13).ToString());
						else
							annualfee=0;

						if(SqlDtr1.GetValue(12).ToString()!=null && SqlDtr1.GetValue(12).ToString()!="")
							admissionfee=double.Parse(SqlDtr1.GetValue(12).ToString());
						else
							admissionfee=0;

						if(SqlDtr1.GetValue(11).ToString()!=null && SqlDtr1.GetValue(11).ToString()!="")
							transportfee=double.Parse(SqlDtr1.GetValue(11).ToString());
						else
							transportfee=0;

						if(SqlDtr1.GetValue(14).ToString()!=null && SqlDtr1.GetValue(14).ToString()!="")
							developmentfee=double.Parse(SqlDtr1.GetValue(14).ToString());
						else
							developmentfee=0;

						if(SqlDtr1.GetValue(16).ToString()!=null && SqlDtr1.GetValue(16).ToString()!="")
							total=double.Parse(SqlDtr1.GetValue(16).ToString());
						else
							total=0;

						gannualfee+=annualfee;
						gdevelopmentfee+=developmentfee;
						gdairyfee+=dairyfee;
						glatefee+=latefee;
						gadmissionfee+=admissionfee;
						gtransportfee+=transportfee;
						gtutionfee+=tutionfee;
						gcomputerfee+=computerfee;
						gsciencefee+=sciencefee;
						ggamefee+=gamefee;
						ghousefee+=housefee;
						gtotal+=total;
						gsecurity+=security;	
						gregistraionfee+=registraionfee;
					}
				}
				
			}
			catch(Exception ex)
			{
				MessageBox.Show("Please Updated Recuring Receipt");
				CreateLogFiles.ErrorLog(" Form :CompleteFeeReport.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
			return true;
		}

		/// <summary>
		/// this method use to get due fees from fees decision table.
		/// </summary>
		public void feesdecisionmonthlydue(string student_id1)//added by vishnu
		{
			rank="";
			category="";
			section="";
			classid="";
			sname="";
			stream="";
			tutionfee=0;
			computerfee=0;
			housefee=0;
			gamefee=0;
			sciencefee=0;
			annualfee=0;
			registraionfee=0;
			latefee=0;
			admissionfee=0;
			transportfee=0;
			developmentfee=0;
			dairyfee=0;
			security=0;
			total=0;
			Caution=0;
			TempCaution=0;
			due=0;
			double TempYearly=0;
			double tempcomp=0;
			string computer="";
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr1=null;
				InventoryClass obj1=new InventoryClass();
				SqlDataReader SqlDtr=null,rdr=null;
				string str="",str1="";
				string str2="";
				if(!student_id.Equals("0"))
				{
					str2="select student_fname,seq_student_id,student_class,rank,scategory,student_stream,computer from student_record where student_id='"+student_id1+"'";
					SqlDtr1=obj.GetRecordSet(str2);
					if(SqlDtr1.Read())
					{
						sname=SqlDtr1.GetString(0).ToString();
						section=SqlDtr1.GetString(1).ToString();
						classid=SqlDtr1.GetString(2).ToString();
						rank=SqlDtr1.GetString(3).ToString();
						category=SqlDtr1.GetString(4).ToString();
						stream=SqlDtr1.GetString(5).ToString();
						computer=SqlDtr1.GetString(6).ToString();
					}
					SqlDtr1.Close();
					string startfrom=""; 
					string endto="";
					int count=0;
					int Flag=0;
					if(!rank.Equals("")&&!category.Equals(""))
					{
						count=0;
						str="select * from feesdecision where class_id=(select class_id from class where class_name='"+classid+"') and Student_Stream='"+stream+"' and feemode='Monthly' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text)+"'";
						startfrom=GenUtil.ConvertMonthName(Txtfromdate.Text);
						startfrom=startfrom.Substring(0,startfrom.Trim().Length-4).Trim();
						endto=GenUtil.ConvertMonthName(Txttodate.Text);
						endto=endto.Substring(0,endto.Trim().Length-4).Trim();
						System.TimeSpan diff=ToMMddYYYY(Txtcurdatet.Text).Subtract(ToMMddYYYY(Txtcurdatef.Text));
						int idays=diff.Days;
						count=(idays+1)/30;
						SqlDtr=obj.GetRecordSet(str);
						if(SqlDtr.Read())
						{
							if(startfrom.Equals("April"))
							{
								str="select * from feesdecision where class_id=(select class_id from class where class_name='"+classid+"') and Student_Stream='"+stream+"' and feemode='Yearly' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text)+"'";
								rdr=obj1.GetRecordSet(str);
								if(rdr.Read())
								{
									annualfee=double.Parse(rdr["annual_fee"].ToString());
									developmentfee=double.Parse(rdr["envp_fee"].ToString());
									dairyfee=double.Parse(rdr["diary_fee"].ToString());
									TempYearly=double.Parse(rdr["Total"].ToString());
									Caution+=double.Parse(rdr["Total"].ToString());
									gannualfee+=annualfee;
									gdevelopmentfee+=developmentfee;
									gdairyfee+=dairyfee;
									Flag++;
								}
								else
								{
									MessageBox.Show("Please enter the yearly fees in Fees Decision table");
									return;
								}
								rdr.Close();
							}
							else
							{
								annualfee=0;
								developmentfee=0;
								dairyfee=0;
								TempYearly=0;
								Caution+=0;
								Flag++;
							}

							if(count>=0)
							{
								if(computer.Trim().Equals("No"))
								{
									computerfee=0;
									tempcomp=count*double.Parse(SqlDtr["computer_fee"].ToString());
								}
								else 
								{
									computerfee=count*double.Parse(SqlDtr["computer_fee"].ToString());
									tempcomp=0;
								}
								tutionfee=count*double.Parse(SqlDtr["tution_fee"].ToString());
								sciencefee=count*double.Parse(SqlDtr["science_fee"].ToString());
								if(!startfrom.Equals("")&&!endto.Equals(""))
								{
									if(startfrom.Equals("April") && classid.Equals("XI"))
									{
										str1="select trfee from route where route_km=(select routeno from student_record where student_id='"+student_id+"' and service_bus='Yes') and fromdate<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text)+"'";
										rdr=obj1.GetRecordSet(str1);
										if(rdr.Read())
										{
											transportfee=0;
										}
										else
										{
											transportfee=0;
										}
										rdr.Close();
									}
									else if(startfrom.Equals("April"))
									{
										str1="select trfee from route where route_km=(select routeno from student_record where student_id='"+student_id+"' and service_bus='Yes') and fromdate<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text)+"'";
										rdr=obj1.GetRecordSet(str1);
										if(rdr.Read())
										{
											transportfee=(count-1)*double.Parse(rdr["trfee"].ToString());
										}
										else
										{
											transportfee=0;
										}
										rdr.Close();
									}
									else
									{
										//str1="select trfee from route where route_km=(select routeno from student_record where student_id='"+student_id+"' and service_bus='Yes') and fromdate<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text)+"'";
										str1="select trfee from route where route_km=(select routeno from student_record where student_id='"+student_id+"' and service_bus='Yes') and fromdate<='"+GenUtil.str2MMDDYYYY(Txtcurdatef.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txtcurdatet.Text)+"'";
										rdr=obj1.GetRecordSet(str1);
										if(rdr.Read())
										{
											transportfee=count*double.Parse(rdr["trfee"].ToString());
										}
										else
										{
											transportfee=0;
										}
										rdr.Close();
									}
								}
								else
								{
									transportfee=0;
								}
								gamefee=count*double.Parse(SqlDtr["games_fee"].ToString());
								housefee=count*double.Parse(SqlDtr["hostel_fee"].ToString());
								total=count*double.Parse(SqlDtr["Total"].ToString());
								if(computer.Trim().Equals("No"))          
								{
									total=total-tempcomp;
								}
								total=total+transportfee;
								// 20.09.08  
								//gtutionfee+=tutionfee;
								//gcomputerfee+=computerfee;
								//gsciencefee+=sciencefee;
								//gtransportfee+=transportfee;
								//ggamefee+=gamefee;
								//ghousefee+=housefee;
								Caution+=total;
								total=Caution+latefee;
								gtotal+=total;	
								due=total;
								gdue+=due;
								
							}
						}
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Some Database problem");
				CreateLogFiles.ErrorLog(" Form :AdvanceFeeReport.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}  
		}
	}
}
