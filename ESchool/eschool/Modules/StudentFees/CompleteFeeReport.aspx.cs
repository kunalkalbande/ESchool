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

namespace eschool.StudentFees
{
	/// <summary>
	/// Summary description for CompleteReport.
	/// </summary>
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
	using System.Data.SqlClient;
	using RMG;
	using eschool.Classes;
	using System.IO ;
	using System.Text;
	using System.Net ;
	using System.Net.Sockets;
	# endregion

	public class CompleteReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList DropClass;
		protected System.Web.UI.WebControls.DropDownList DropSec;
		protected System.Web.UI.WebControls.TextBox Txtfromdate;
		protected System.Web.UI.WebControls.TextBox Txttodate;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.HtmlControls.HtmlButton print;
		public string rank="";
		public string student_id="";
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
		public string recid="";
		public string recdate="";
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
		public double gTempCaution=0;
		protected System.Web.UI.HtmlControls.HtmlButton Exel;
		public string duration="";
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
				CreateLogFiles.ErrorLog (" Form : Completefees_Report.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				//string pass;
				//pass=(Session["password"].ToString ());
				if(!Page .IsPostBack)
				{
					Txtfromdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					Txttodate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					InventoryClass obj=new InventoryClass();
					SqlDataReader sdred=null;
					//string str="select distinct student_class from student_record sr,recuringreceipt rr where rr.student_id=sr.student_id";
					string str="select class_name from class order by class_id";
					sdred=obj.GetRecordSet(str);
					DropClass.Items.Clear();
					DropClass.Items.Add("Select");
					DropClass.Items.Add("All");
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
					string SubModule="4";
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
				CreateLogFiles.ErrorLog(" Form :CompleteFeeReport.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				return;
			}	
		}

		/// <summary>
		/// this method use to DateConversion in to MMDDYYY formate. 
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
			this.Exel.ServerClick += new System.EventHandler(this.Exel_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// this method use to Show report data fetch from recuringreceipt table and student_record table also. 
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
			duration="";
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr=null;
				string  strSelect="";
				if(DropClass.SelectedIndex!=0)
				{
					if(!Txtfromdate.Text.Equals("")&&!Txttodate.Text.Equals(""))
					{
						if(DropClass.SelectedItem.Value.ToString().Equals("All"))
						{
							//17.10.2008 strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and r.student_id!=0 and r.student_id=s.student_id union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime)between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"')  and r1.student_id=0) order by s.student_id";
							strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"'  and r.student_id!=0 and r.student_id=s.student_id union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime)between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime)between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"'  and r1.student_id=0) order by s.student_id";
							string sid="";
							string feetype="";
							SqlDtr=obj.GetRecordSet(strSelect);
							while(SqlDtr.Read())
							{
								sid=SqlDtr.GetValue(0).ToString().Trim();
								feetype=SqlDtr.GetValue(1).ToString();
								bool flag=feesdecisionmonthly(sid,feetype);
								if(flag==false)
									return;
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
								strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"') and r.student_id!=0 and r.student_id=s.student_id and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' and regid!=0 ) and student_class='"+DropClass.SelectedItem.Value.ToString()+"'  and r1.student_id=0 and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"')";
								string sid="";
								string feetype="";
								SqlDtr=obj.GetRecordSet(strSelect);
								while(SqlDtr.Read())
								{
									sid=SqlDtr.GetValue(0).ToString().Trim();
									feetype=SqlDtr.GetValue(1).ToString();
									bool flag=feesdecisionmonthly(sid,feetype);
									if(flag==false)
										return;
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
				CreateLogFiles.ErrorLog(" Form :CompleteFeeReport.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method not in use. 
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				Response .Redirect("../PrintPreview/feesduerptPrint.aspx");
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :CompleteFeeReport.aspx,Method BtnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				 
			}	
		}

		/// <summary>
		/// this method use to create in text report data fetch from recuringreceipt table and student_record table also. 
		/// </summary>
		private void print_ServerClick(object sender, System.EventArgs e)
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
			gCaution=0;
			gTempCaution=0;
			gtotal=0;
			double ptutionfee=0;
			double pcomputerfee=0;
			double phousefee=0;
			double pgamefee=0;
			double psciencefee=0;
			double pannualfee=0;
			double pregistraionfee=0;
			double platefee=0;
			double padmissionfee=0;
			double ptransportfee=0;
			double pdevelopmentfee=0;
			double pdairyfee=0;
			double psecurity=0;
			double pCaution=0;
			double ptotal=0;
			try
			{
				string home_drive = Environment.SystemDirectory ;
				string info = "";
				home_drive = home_drive.Substring (0,2);
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\CompleteFeeReport.txt";
				StreamWriter sw = new StreamWriter(path); 
				gtotal=0;
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr=null;
				string  strSelect="";
				if(DropClass.SelectedIndex!=0)
				{
					if(!Txtfromdate.Text.Equals("")&&!Txttodate.Text.Equals(""))
					{
						if(DropClass.SelectedItem.Value.ToString().Equals("All"))
						{
							strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and r.student_id!=0 and r.student_id=s.student_id and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' and regid!=0) and r1.student_id=0 and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"')";
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
								strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"') and r.student_id!=0 and r.student_id=s.student_id and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' and regid!=0 ) and student_class='"+DropClass.SelectedItem.Value.ToString()+"'  and r1.student_id=0 and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"')";
								SqlDtr=obj.GetRecordSet(strSelect);
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
				int n=12*6;
				sw.Write((char)27);     //initialization
				sw.Write((char)67);     //
				sw.Write((char)n);      //Page Size or No of lines or inches
				sw.Write((char)27);		//initialization
				sw.Write((char)78);     //jumping perforation
				sw.Write((char)6);      //How many line for perforation
				sw.Write((char)27);     //condenced mode 
				sw.Write((char)15);     //condenced mode
				int i=1;
				int c=1,d=5;
				string des="+---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------";
				//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School",des.Length));
				//sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------------",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr(" COMPLETE FEES REPORT From "+ Txtfromdate.Text.Trim() + " TO "+Txttodate.Text.Trim(),des.Length));
				//sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------------",des.Length));
				sw.WriteLine("");
				string info5="{0,-80:S} {1,40:S}";
				sw.WriteLine(info5,"","Page No:"+c.ToString());
				info = " {0,-3:S} {1,-5:S} {2,-8:S} {3,-5:S}{4,-12:S} {5,4:S} {6,-1:S} {7,-11:S}{8,5:S} {9,5:S} {10,5:S} {11,5:S} {12,5:S} {13,4:S} {14,4:S} {15,5:S} {16,5:S} {17,4:S} {18,4:S} {19,5:S} {20,5:S} {21,6:S}";
				sw.WriteLine("+---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
				sw.WriteLine("|SN0|RecID|R.Date  |St.ID|Student Name| Cls|S| Duration |Tutio|Comp.| Hous|Game |Scie.|Regi|Late|Admis|Tran |Env.|Diar|Annua|Secur|Total ");
				sw.WriteLine("+---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
				//123 12345 12345678 12345 123456789012 1234 1 12345678901 12345 12345 12345 12345 1234512345 1234 12345 12345 1234 1234 12345 12345 123456
				string feetype="";
				int x=60,y=1;
				
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{	
						recid=SqlDtr.GetValue(0).ToString().Trim();
						feetype=SqlDtr.GetValue(1).ToString().Trim();
						bool flag=feesdecisionmonthly(recid,feetype);
						if(flag==false)
							return;
						string year=recdate.Substring(recdate.IndexOf("/",recdate.IndexOf("/")+1)+3,2);
						string mon=recdate.Substring(0,recdate.IndexOf("/",recdate.IndexOf("/")+1)+1);
						recdate=mon+year;
						sw.WriteLine(info,i.ToString(),recid.ToString(),recdate.ToString(),student_id.ToString(),GenUtil.TrimLength(sname.Trim(),12),GenUtil.TrimLength(classid.ToString(),3),
							GenUtil.TrimLength(section.ToString().Trim(),1),GenUtil.TrimLength(duration.ToString(),11),tutionfee.ToString(),computerfee.ToString(),housefee.ToString(),gamefee.ToString(),sciencefee.ToString(),
							registraionfee.ToString(),latefee.ToString(),admissionfee.ToString(),transportfee.ToString(),developmentfee.ToString(),
							dairyfee.ToString(),annualfee.ToString(),security.ToString(),total.ToString());
						ptutionfee+=tutionfee;
						pcomputerfee+=computerfee;
						phousefee+=housefee;
						pgamefee+=gamefee;
						psciencefee+=sciencefee;
						pannualfee+=annualfee;
						pregistraionfee+=registraionfee;
						platefee+=latefee;
						padmissionfee+=admissionfee;
						ptransportfee+=transportfee;
						pdevelopmentfee+=developmentfee;
						pdairyfee+=dairyfee;
						psecurity+=security;
						ptotal+=total;
						d++;
						if(d>(x*(c-1)+(c+4))&&d%x==y&&c>=2)
						{
							sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
							string info3="Page Total                                              {0,5:S} {1,5:S} {2,5:S} {3,5:S} {4,5:S} {5,4:S} {6,4:S} {7,5:S} {8,5:S} {9,4:S} {10,4:S} {11,5:S} {12,5:S} {13,6:S}";
							sw.WriteLine(info3,ptutionfee.ToString(),pcomputerfee.ToString(),phousefee.ToString(),pgamefee.ToString(),psciencefee.ToString(),
								pregistraionfee.ToString(),platefee.ToString(),padmissionfee.ToString(),ptransportfee.ToString(),pdevelopmentfee.ToString(),
								pdairyfee.ToString(),pannualfee.ToString(),psecurity.ToString(),ptotal.ToString());
							sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
							c++;
							x=60;
							sw.WriteLine();
							sw.WriteLine(info5,"","Page No:"+c.ToString());
							sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
							sw.WriteLine("SN0|RecID|R.Date  +St.ID|Student Name| Cls|S| Duration |Tutio|Comp.| Hous|Game |Scie.|Regi|Late|Admis|Tran |Env.|Diar|Annua|Secur|Total ");
							sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
							d+=3;
							y++;
							ptutionfee=0;
							pcomputerfee=0;
							phousefee=0;
							pgamefee=0;
							psciencefee=0;
							pannualfee=0;
							pregistraionfee=0;
							platefee=0;
							padmissionfee=0;
							ptransportfee=0;
							pdevelopmentfee=0;
							pdairyfee=0;
							psecurity=0;
							pCaution=0;
							ptotal=0;
		
						}
						else if(d%59==1&&c==1)
						{
							sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
							string info3="Page Total                                              {0,5:S} {1,5:S} {2,5:S} {3,5:S} {4,5:S} {5,4:S} {6,4:S} {7,5:S} {8,5:S} {9,4:S} {10,4:S} {11,5:S} {12,5:S} {13,6:S}";
							sw.WriteLine(info3,ptutionfee.ToString(),pcomputerfee.ToString(),phousefee.ToString(),pgamefee.ToString(),psciencefee.ToString(),
								pregistraionfee.ToString(),platefee.ToString(),padmissionfee.ToString(),ptransportfee.ToString(),pdevelopmentfee.ToString(),
								pdairyfee.ToString(),pannualfee.ToString(),psecurity.ToString(),ptotal.ToString());
							sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
							c++;
							sw.WriteLine(info5,"","Page No:"+c.ToString());
							sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
							sw.WriteLine("SN0|RecID|R.Date  +St.ID|Student Name| Cls|S| Duration |Tutio|Comp.| Hous|Game |Scie.|Regi|Late|Admis|Tran |Env.|Diar|Annua|Secur|Total ");
							sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
							d+=3;
							ptutionfee=0;
							pcomputerfee=0;
							phousefee=0;
							pgamefee=0;
							psciencefee=0;
							pannualfee=0;
							pregistraionfee=0;
							platefee=0;
							padmissionfee=0;
							ptransportfee=0;
							pdevelopmentfee=0;
							pdairyfee=0;
							psecurity=0;
							pCaution=0;
							ptotal=0;
						}		
						i++;
					}
				}
				SqlDtr.Close();		
				sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
				string info2="Page Total                                              {0,5:S} {1,5:S} {2,5:S} {3,5:S} {4,5:S} {5,4:S} {6,4:S} {7,5:S} {8,5:S} {9,4:S} {10,4:S} {11,5:S} {12,5:S} {13,6:S}";
				sw.WriteLine(info2,ptutionfee.ToString(),pcomputerfee.ToString(),phousefee.ToString(),pgamefee.ToString(),psciencefee.ToString(),
					pregistraionfee.ToString(),platefee.ToString(),padmissionfee.ToString(),ptransportfee.ToString(),pdevelopmentfee.ToString(),
					pdairyfee.ToString(),pannualfee.ToString(),psecurity.ToString(),ptotal.ToString());
				sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
				sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
				string info1="Grand Total                                             {0,5:S} {1,5:S} {2,5:S} {3,5:S} {4,5:S} {5,4:S} {6,4:S} {7,5:S} {8,5:S} {9,4:S} {10,4:S} {11,5:S} {12,5:S} {13,6:S}";
				sw.WriteLine(info1,gtutionfee.ToString(),gcomputerfee.ToString(),ghousefee.ToString(),ggamefee.ToString(),gsciencefee.ToString(),
					gregistraionfee.ToString(),glatefee.ToString(),gadmissionfee.ToString(),gtransportfee.ToString(),gdevelopmentfee.ToString(),
					gdairyfee.ToString(),gannualfee.ToString(),gsecurity.ToString(),gtotal.ToString());
				sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
				sw.Close();
				Print();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :CompleteFeeReport.aspx,Method  BtnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to generate in excel format data fetch from recuringreceipt table and student_record table also. 
		/// </summary>
		public void ConvertIntoExcel()
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
			gCaution=0;
			gTempCaution=0;
			gtotal=0;
			double ptutionfee=0;
			double pcomputerfee=0;
			double phousefee=0;
			double pgamefee=0;
			double psciencefee=0;
			double pannualfee=0;
			double pregistraionfee=0;
			double platefee=0;
			double padmissionfee=0;
			double ptransportfee=0;
			double pdevelopmentfee=0;
			double pdairyfee=0;
			double psecurity=0;
			double pCaution=0;
			double ptotal=0;
			try
			{
				int i=1;
				SqlDataReader SqlDtr=null;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\CompleteFeeReport.xls";
				StreamWriter sw = new StreamWriter(path);
				string info="";
				gtotal=0;
				InventoryClass obj=new InventoryClass();
				string  strSelect="";
				if(DropClass.SelectedIndex!=0)
				{
					if(!Txtfromdate.Text.Equals("")&&!Txttodate.Text.Equals(""))
					{
						if(DropClass.SelectedItem.Value.ToString().Equals("All"))
						{
							strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"') and r.student_id!=0 and r.student_id=s.student_id and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' and regid!=0) and r1.student_id=0 and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"')";
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
								strSelect="(select s.student_id,r.fees_type from student_record s,recuringreceipt r where s.student_id in (select student_id from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"') and r.student_id!=0 and r.student_id=s.student_id and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' union select distinct s1.student_id,r1.fees_type from student_registration s1,recuringreceipt r1 where s1.student_id in (select regid from recuringreceipt where cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"' and regid!=0 ) and student_class='"+DropClass.SelectedItem.Value.ToString()+"'  and r1.student_id=0 and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim())+"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"')";
								SqlDtr=obj.GetRecordSet(strSelect);
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
				int n=12*6;
				int c=1,d=5;
				string des="----+-----+--------+-----+------------+----+-+--------+-----+-----+-----+----+-----+-----+----+-----+-----+-----+-----+-----+-----+------";
				//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School",des.Length));
				//sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------------",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr(" COMPLETE FEES REPORT From "+ Txtfromdate.Text.Trim() + " TO "+Txttodate.Text.Trim(),des.Length));
				
				//sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------------",des.Length));
				string info5="{0,-80:S} {1,40:S}";
				//sw.WriteLine(info5,"","Page No:"+c.ToString());
				sw.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t"+"Page No:\t"+c.ToString());
				info = " {0,-3:S} {1,-5:S} {2,-8:S} {3,-5:S}{4,-12:S} {5,4:S} {6,-1:S} {7,-11:S}{8,5:S} {9,5:S} {10,5:S} {11,5:S} {12,5:S} {13,4:S} {14,4:S} {15,5:S} {16,5:S} {17,4:S} {18,4:S} {19,5:S} {20,5:S} {21,6:S}";
				sw.WriteLine("SN0\tRecID\tR.Date\tSt.ID\tStudent Name\tCls\tS\t Duration \tTutio\tComp.\t Hous\tGame\tScie.\tRegi\tLate\tAdmis\tTrans\tEnv.\tDiar\tAnnua\tSecur\tTotal ");
				//123 12345 12345678 12345 123456789012 1234 1 12345678901 12345 12345 12345 12345 1234512345 1234 12345 12345 1234 1234 12345 12345 123456
				string feetype="";
				int x=60,y=1;
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{	
						recid=SqlDtr.GetValue(0).ToString().Trim();
						feetype=SqlDtr.GetValue(1).ToString().Trim();
						bool flag=feesdecisionmonthly(recid,feetype);
						if(flag==false)
							return;
						string year=recdate.Substring(recdate.IndexOf("/",recdate.IndexOf("/")+1)+3,2);
						string mon=recdate.Substring(0,recdate.IndexOf("/",recdate.IndexOf("/")+1)+1);
						recdate=mon+year;
						sw.WriteLine(i.ToString()+"\t"+recid.ToString()+"\t"+recdate.ToString()+"\t"+student_id.ToString()+"\t"+GenUtil.TrimLength(sname.Trim(),13)+"\t"+classid.ToString()+"\t"+
							section.ToString()+"\t"+duration.ToString()+"\t"+tutionfee.ToString()+"\t"+computerfee.ToString()+"\t"+housefee.ToString()+"\t"+gamefee.ToString()+"\t"+sciencefee.ToString()+"\t"+
							registraionfee.ToString()+"\t"+latefee.ToString()+"\t"+admissionfee.ToString()+"\t"+transportfee.ToString()+"\t"+developmentfee.ToString()+"\t"+
							dairyfee.ToString()+"\t"+annualfee.ToString()+"\t"+security.ToString()+"\t"+total.ToString());
						ptutionfee+=tutionfee;
						pcomputerfee+=computerfee;
						phousefee+=housefee;
						pgamefee+=gamefee;
						psciencefee+=sciencefee;
						pannualfee+=annualfee;
						pregistraionfee+=registraionfee;
						platefee+=latefee;
						padmissionfee+=admissionfee;
						ptransportfee+=transportfee;
						pdevelopmentfee+=developmentfee;
						pdairyfee+=dairyfee;
						psecurity+=security;
						ptotal+=total;
						d++;
						if(d>(x*(c-1)+(c+4))&&d%x==y&&c>=2)
						{
							//sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
							sw.WriteLine();
							string info3="Page Total                                              {0,5:S} {1,5:S} {2,5:S} {3,5:S} {4,5:S} {5,4:S} {6,4:S} {7,5:S} {8,5:S} {9,4:S} {10,4:S} {11,5:S} {12,5:S} {13,6:S}";
							sw.WriteLine("\t\t\t\t\t\t\tPage Total\t"+ptutionfee.ToString()+"\t"+pcomputerfee.ToString()+"\t"+phousefee.ToString()+"\t"+pgamefee.ToString()+"\t"+psciencefee.ToString()+"\t"+
								pregistraionfee.ToString()+"\t"+platefee.ToString()+"\t"+padmissionfee.ToString()+"\t"+ptransportfee.ToString()+"\t"+pdevelopmentfee.ToString()+"\t"+
								pdairyfee.ToString()+"\t"+pannualfee.ToString()+"\t"+psecurity.ToString()+"\t"+ptotal.ToString());
							//sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
							sw.WriteLine();
							c++;
							x=60;
							sw.WriteLine();
							sw.WriteLine(info5,"","Page No:"+c.ToString());
							//sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
							sw.WriteLine();
							sw.WriteLine("SN0\tRecID\tR.Date\tSt.ID\tStudent Name\tCls\tS\t Duration \tTutio\tComp.\t Hous\tGame\tScie.\tRegi\tLate\tAdmis\tTrans\tEnv.\tDiar\tAnnua\tSecur\tTotal ");
							//sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
							sw.WriteLine();
							d+=3;
							y++;
							ptutionfee=0;
							pcomputerfee=0;
							phousefee=0;
							pgamefee=0;
							psciencefee=0;
							pannualfee=0;
							pregistraionfee=0;
							platefee=0;
							padmissionfee=0;
							ptransportfee=0;
							pdevelopmentfee=0;
							pdairyfee=0;
							psecurity=0;
							pCaution=0;
							ptotal=0;
						
						}
						else if(d%59==1&&c==1)
						{
							//sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
							sw.WriteLine();
							string info3="Page Total                                              {0,5:S} {1,5:S} {2,5:S} {3,5:S} {4,5:S} {5,4:S} {6,4:S} {7,5:S} {8,5:S} {9,4:S} {10,4:S} {11,5:S} {12,5:S} {13,6:S}";
							
							sw.WriteLine("\t\t\t\t\t\t\tGrand Total\t"+ptutionfee.ToString()+"\t"+pcomputerfee.ToString()+"\t"+phousefee.ToString()+"\t"+pgamefee.ToString()+"\t"+psciencefee.ToString()+"\t"+
								pregistraionfee.ToString()+"\t"+platefee.ToString()+"\t"+padmissionfee.ToString()+"\t"+ptransportfee.ToString()+"\t"+pdevelopmentfee.ToString()+"\t"+
								pdairyfee.ToString()+"\t"+pannualfee.ToString()+"\t"+psecurity.ToString()+"\t"+ptotal.ToString());

							//sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
							sw.WriteLine();
													
							c++;
							sw.WriteLine(info5,"","Page No:"+c.ToString());
							//sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
							sw.WriteLine();
							
							sw.WriteLine("SN0\tRecID\tR.Date\tSt.ID\tStudent Name\tCls\tS\t Duration \tTutio\tComp.\t Hous\tGame\tScie.\tRegi\tLate\tAdmis\tTrans\tEnv.\tDiar\tAnnua\tSecur\tTotal ");
							//sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
							sw.WriteLine();
							d+=3;
							ptutionfee=0;
							pcomputerfee=0;
							phousefee=0;
							pgamefee=0;
							psciencefee=0;
							pannualfee=0;
							pregistraionfee=0;
							platefee=0;
							padmissionfee=0;
							ptransportfee=0;
							pdevelopmentfee=0;
							pdairyfee=0;
							psecurity=0;
							pCaution=0;
							ptotal=0;
						}		
						i++;
					}
				}
				SqlDtr.Close();		
				//sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
				sw.WriteLine();
				string info2="Page Total                                              {0,5:S} {1,5:S} {2,5:S} {3,5:S} {4,5:S} {5,4:S} {6,4:S} {7,5:S} {8,5:S} {9,4:S} {10,4:S} {11,5:S} {12,5:S} {13,6:S}";
				
				sw.WriteLine("\t\t\t\t\t\t\tPage Total\t"+ptutionfee.ToString()+"\t"+pcomputerfee.ToString()+"\t"+phousefee.ToString()+"\t"+pgamefee.ToString()+"\t"+psciencefee.ToString()+"\t"+
					pregistraionfee.ToString()+"\t"+platefee.ToString()+"\t"+padmissionfee.ToString()+"\t"+ptransportfee.ToString()+"\t"+pdevelopmentfee.ToString()+"\t"+
					pdairyfee.ToString()+"\t"+pannualfee.ToString()+"\t"+psecurity.ToString()+"\t"+ptotal.ToString());

				//sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
				sw.WriteLine();
				
				//sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
				//sw.WriteLine();
				string info1="Grand Total                                             {0,5:S} {1,5:S} {2,5:S} {3,5:S} {4,5:S} {5,4:S} {6,4:S} {7,5:S} {8,5:S} {9,4:S} {10,4:S} {11,5:S} {12,5:S} {13,6:S}";
				sw.WriteLine("\t\t\t\t\t\t\tGrand Total\t"+ptutionfee.ToString()+"\t"+pcomputerfee.ToString()+"\t"+phousefee.ToString()+"\t"+pgamefee.ToString()+"\t"+psciencefee.ToString()+"\t"+
					pregistraionfee.ToString()+"\t"+platefee.ToString()+"\t"+padmissionfee.ToString()+"\t"+ptransportfee.ToString()+"\t"+pdevelopmentfee.ToString()+"\t"+
					pdairyfee.ToString()+"\t"+pannualfee.ToString()+"\t"+psecurity.ToString()+"\t"+ptotal.ToString());

				//sw.WriteLine("---+-----+--------+-----+------------+----+-+----------+-----+-----+-----+-----+-----+----+----+-----+-----+----+----+-----+-----+------");
				sw.WriteLine();
				sw.Close();
		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :CompleteFeeReport.aspx,Method  BtnExcel_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}
		
		/// <summary>
		/// Method for sending the text file to the printer
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\CompleteFeeReport.txt<EOF>");
					//													\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\CompleteFeeReport.txt
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :CompleteFeeReport.aspx,Method  Print_Click, Fees Due Report Printed, Userid :  "+ pass);
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :CompleteFeeReport.aspx,Method  Print_Click, Exception"+ ane.Message+",  Complete Fee Report Printed, Userid :  "+ pass);
				} 
     
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :CompleteFeeReport.aspx,Method  Print_Click, Exception"+ se.Message+",  Complete Fee Report Printed, Userid :  "+ pass);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :CompleteFeeReport.aspx,Method  Print_Click, Exception"+ es.Message+",  Complete Fee Report Printed, Userid :  "+ pass);
				}
			} 
			
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :CompleteFeeReport.aspx,Method  Print_Click,Esception:"+ex.Message +", Complete Fee Report Printed, Userid :  "+ pass);
			}

		}

		/// <summary>
		/// this method use to get fees from feesdecision table. 
		/// </summary>
		public bool feesdecisionmonthly(string student_id1,string feestype1)
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
					str2="select recuringid,fees_type from recuringreceipt where  regid='" +student_id1+"' and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"'";
				}
				else
				{
					str2="select recuringid,fees_type from recuringreceipt where student_id='"+student_id1+"'and cast(floor(cast(cast(feesubdt as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (Txtfromdate.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (Txttodate.Text.Trim())+"'";
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
					str2="select RecuringID,fees_type,securityfee,Latefee,RegFee,feesubdt,diary_fee,tution_fee,computer_fee,science_fee,game_fee,transport_fee,admission_fee,annual_fee,envp_fee,hostel_fee,fees_amount from recuringreceipt where (student_id='"+student_id+"' or regid='"+student_id+"') and feesubdt between '"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text) +"' and recuringid='"+recid+"'" ;
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
		/// this method use to call ConvertIntoExcel() 
		/// </summary>
		private void Exel_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				ConvertIntoExcel();
				MessageBox.Show("Successfully Convert File into Excel Format");
				CreateLogFiles.ErrorLog("Form:CompleteFeesReport.aspx,Method: btnExcel_Click, Complete Fees Report Convert Into Excel Format ,  userid  "+pass);
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:CompleteFeesReport.aspx,Method:btnExcel_Click   Complete Fees Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+pass);
			}
		}
	}
}
