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
using RMG;
using eschool.Classes;
using System.Data.SqlClient;
using DBOperations;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace eschool.Reports
{
	/// <summary>
	/// Summary description for GreenSheetReport.
	/// </summary>
	public class GreenSheetReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropClass;
		protected System.Web.UI.WebControls.Button btnShow;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Panel PanSixToTen;
		protected System.Web.UI.WebControls.Panel PanElevanBioTwelve;
		protected System.Web.UI.WebControls.DropDownList DropStream;
		protected System.Web.UI.WebControls.Panel PanElavenMathTwelve;
		protected System.Web.UI.WebControls.DropDownList DropSec;
		protected System.Web.UI.WebControls.TextBox txtrem;
		public static string[,] Ist=new string[50,100];
		public static string[,] unit=new string[50,100];
		public static string[,] Assgn=new string[50,100];
		public static string[,] IInd=new string[50,100];
		public static string[,] Third=new string[50,100];
		public static string[,] Test1=new string[50,100];
		public static string[,] Test2=new string[50,100];
		public static string[,] Test3=new string[50,100];
		public static string[,] maxMarks=new string[7,50];
		public static string[,] grade=new string[50,100];
		public static double[] gtotal=new double[100] ;
		public static string[] ggrade=new string[100];
		public static double[] rank=new double[100] ;
		public static string[,] mtotal=new string[50,100];
		public static string[,] NIst=new string[50,100];
		public static string[,] Nunit=new string[50,100];
		public static string[,] NAssgn=new string[50,100];
		public static string[,] NIInd=new string[50,100];
		public static string[,] NThird=new string[50,100];
		public static string[,] NTest1=new string[50,100];
		public static string[,] NTest2=new string[50,100];
		public static string[,] NTest3=new string[50,100];
		public static string[,] NmaxMarks=new string[7,50];
		public static string[,] Ngrade=new string[50,100];
		public static double[] Ngtotal=new double[100] ;
		public static string[] Nggrade=new string[100];
		public static double[] Nrank=new double[100] ;
		public static string[,] Nmtotal=new string[50,100];
		public int i1=10,count1=0;
		public static int count=0,i=0,View=0;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.Button Btnexcel;
		protected System.Web.UI.WebControls.Panel PanFirstToSecond;
		public static string[] Subject=null;
		public static double STotal=0,NSTotal=0;
		public static double PSTotal=0,PNSTotal=0;
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
				CreateLogFiles.ErrorLog ("Form: GreenSheetReport.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			
			if(! IsPostBack)
			{
				View=0;
			    InventoryClass obj=new InventoryClass();
                SqlDataReader sdtr=null;
				string sql="Select class_name from class order by class_id";
                sdtr=obj.GetRecordSet(sql);
				while(sdtr.Read())
				{
					DropClass.Items.Add(sdtr.GetValue(0).ToString().Trim());
                }
				sdtr.Close();
				PanFirstToSecond.Visible=false;
				//PanThirdToTwelve.Visible=false;

				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="11";
				string SubModule="29";
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
				if(Add_Flag=="False"&&Edit_Flag=="False"&&Del_Flag=="False"&&View_flag=="False")
				{
					//10.05.08--Response.Redirect("../AccessDeny.aspx");
					Response.Redirect("/eschool/AccessDeny.aspx",false);
				}
				if(View_flag=="False")
				{
					btnShow.Enabled=false;
				}
				
				#endregion
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
			this.DropClass.SelectedIndexChanged += new System.EventHandler(this.DropClass_SelectedIndexChanged);
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.Btnexcel.Click += new System.EventHandler(this.Btnexcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method use to show report. in this method first get subject from classwisesubject table. after that get max marks of every subject and every type of exam from exammarksdecision table and store
		/// in a array. after that get students all type exam markas from studentmarks or studentmarksentryIandII table and save in 2D array. and also check grade and get rank with the help of rank() function.
		/// and store in array.
		/// </summary>
		private void btnShow_Click(object sender, System.EventArgs e)
		{
			try
			{
				bool unit1=false,unit2=false,unit3=false,test1=false,test2=false,test3=false,assgn=false;		
				count=0;
				count1=0;
				View=1;
				double mmarks=0;
				InventoryClass obj = new InventoryClass();
				SqlDataReader SqlDtr;
				string str="",cls="";
				for(int k=0;k<100;k++)
				{
					gtotal[k]=0;
					rank[k]=0;
				}
				
				for(int p=0;p<50;p++)
					for(int q=0;q<100;q++)
					{
						mtotal[p,q]="0";
						NIst[p,q]="0"; 
						Ist[p,q]="0";
						IInd[p,q]="0";
						NIInd[p,q]="0";
						Test1[p,q]="0"; 
						Test2[p,q]="0"; 
						Test3[p,q]="0"; 
						NTest1[p,q]="0"; 
						NTest2[p,q]="0"; 
						NTest3[p,q]="0"; 
						grade[p,q]="0";
						unit[p,q]="0";
						Assgn[p,q]="0";//Mahesh
						NAssgn[p,q]="0";//Mahesh
					}
				if(DropClass.SelectedIndex!=0 && DropSec.SelectedIndex!=0)
				{
					/*if(DropClass.SelectedItem.Text=="I")
						cls="1";
					else if(DropClass.SelectedItem.Text=="II")
						cls="2";
					else if(DropClass.SelectedItem.Text=="III")
						cls="3";
					else if(DropClass.SelectedItem.Text=="IV")
						cls="4";
					else if(DropClass.SelectedItem.Text=="V")
						cls="5";
					else if(DropClass.SelectedItem.Text=="VI")
						cls="6";
					else if(DropClass.SelectedItem.Text=="VII")
						cls="7";
					else if(DropClass.SelectedItem.Text=="VIII")
						cls="8";
					else if(DropClass.SelectedItem.Text=="IX")
						cls="9";
					else if(DropClass.SelectedItem.Text=="X")
						cls="10";
					else if(DropClass.SelectedItem.Text=="XI")
						cls="11";
					else if(DropClass.SelectedItem.Text=="XII")
						cls="12";*/

					if(DropClass.SelectedItem.Text.Equals("Nursery"))
						cls="1";
					else if(DropClass.SelectedItem.Text.Equals("LKG"))
						cls="2";
					else if(DropClass.SelectedItem.Text.Equals("UKG"))
						cls="3";
					else if(DropClass.SelectedItem.Text.Equals("I"))
						cls="4";
					else if(DropClass.SelectedItem.Text.Equals("II"))
						cls="5";
					else if(DropClass.SelectedItem.Text.Equals("III"))
						cls="6";
					else if(DropClass.SelectedItem.Text.Equals("IV"))
						cls="7";
					else if(DropClass.SelectedItem.Text.Equals("V"))
						cls="8";
					else if(DropClass.SelectedItem.Text.Equals("VI"))
						cls="9";
					else if(DropClass.SelectedItem.Text.Equals("VII"))
						cls="10";
					else if(DropClass.SelectedItem.Text.Equals("VIII"))
						cls="11";
					else if(DropClass.SelectedItem.Text.Equals("IX"))
						cls="12";
					else if(DropClass.SelectedItem.Text.Equals("X"))
						cls="13";
					else if(DropClass.SelectedItem.Text.Equals("XI"))
						cls="14";
					else if(DropClass.SelectedItem.Text.Equals("XII"))
						cls="15";
					
					string strstr="";

					//if(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II")
					if(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG")
					{
						strstr="English,Hindi,Math,EVS,Computer,Phy_edu,Music,Art,Craft,Dance";
					}
					else
					{
						strstr=GenUtil.AddColumnNames(cls,DropStream.SelectedItem.Text);
					}

					Subject=strstr.Split(new char[] {','},strstr.Length);

					if(strstr=="")
					{
						MessageBox.Show("Subject Not Available");
						View=0;
						//PanThirdToTwelve.Visible=false;
						return;
					}
					//if(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II")
					if(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG")
					{
						PanFirstToSecond.Visible=true;
						//PanThirdToTwelve.Visible=false;
					}
					else
					{
						PanFirstToSecond.Visible=false;
						//PanThirdToTwelve.Visible=true;
					}

					//if(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II")
					if(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG")
					{
						
						str="select (cast(Eng_Read as float) +cast(Eng_Writing as float)+cast(Eng_Con as float)+cast(Eng_Spelling as int)+cast(Eng_Compre as int)) as English,cast(Hindi_Read as float)+cast(Hindi_Writing as float)+cast(Hindi_Con as float)+cast(Hindi_spelling as float)+cast( Hindi_Com as float) as Hindi,cast(Math_FNumber as float)+cast( Math_BConcept as float) as Math,cast( Math_Computation as float)+cast( evs_observation as float)+cast( evs_Identification as float)+cast( Evs_know as float) as EVS,Computer_tot,Phy_edu,Music,Art,Craft,Dance from exammarksdecision where exam_type='Ist Unit Test' and class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'";
					}
					else
					{
						str="select " +strstr+" from exammarksdecision where exam_type='Ist Unit Test' and class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'";
					}

					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.HasRows)
					{
						while(SqlDtr.Read())
						{
							

							for(int j=0,k=0;j<SqlDtr.FieldCount;j++)
							{
								if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery"||DropClass .SelectedItem .Text=="LKG"||DropClass .SelectedItem .Text=="UKG")))//THIS FOR NON SCHOLASTIC
								{
									count++;
									maxMarks[0,k] = SqlDtr.GetValue(j).ToString();
									
									k++;
								}
								else if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery"||DropClass .SelectedItem .Text=="LKG"||DropClass .SelectedItem .Text=="UKG"))
								{
									count++;
									maxMarks[0,k] = SqlDtr.GetValue(j).ToString();
									
									k++;
								}
							}
							//add by vikas 06.09.08

							for(int j=0,k=0;j<SqlDtr.FieldCount;j++)//non scholastic
							{
								if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery"||DropClass .SelectedItem .Text=="LKG"||DropClass .SelectedItem .Text=="UKG")))//THIS FOR NON SCHOLASTIC
								{
									NmaxMarks[0,k] = SqlDtr.GetValue(j).ToString();
									
									k++;
								}
								else if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery"||DropClass .SelectedItem .Text=="LKG"||DropClass .SelectedItem .Text=="UKG"))
								{
									NmaxMarks[0,k] = SqlDtr.GetValue(j).ToString();
									
									k++;
								}
							}



						}
					}
					SqlDtr.Close();

					//if(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II")
					if(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG")
					{
					
						str="select (cast(Eng_Read as float) +cast(Eng_Writing as float)+cast(Eng_Con as float)+cast(Eng_Spelling as int)+cast(Eng_Compre as int)) as English,cast(Hindi_Read as float)+cast(Hindi_Writing as float)+cast(Hindi_Con as float)+cast(Hindi_spelling as float)+cast( Hindi_Com as float) as Hindi,cast(Math_FNumber as float)+cast( Math_BConcept as float) as Math,cast( Math_Computation as float)+cast( evs_observation as float)+cast( evs_Identification as float)+cast( Evs_know as float) as EVS,Computer_tot,Phy_edu,Music,Art,Craft,Dance from exammarksdecision where exam_type='IInd Unit Test' and class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'";
					}
					else
					{
						str="select " +strstr+" from exammarksdecision where exam_type='IInd Unit Test' and class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'";
					}

					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.HasRows)
					{
						while(SqlDtr.Read())
						{
							
							for(int j=0,k=0;j<SqlDtr.FieldCount;j++)
							{
								if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery"||DropClass .SelectedItem .Text=="LKG"||DropClass .SelectedItem .Text=="UKG")))//THIS FOR NON SCHOLASTIC
								{
									maxMarks[1,k] = SqlDtr.GetValue(j).ToString();
									
									k++;
								}
								else if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery"||DropClass .SelectedItem .Text=="LKG"||DropClass .SelectedItem .Text=="UKG"))
								{
									maxMarks[1,k] = SqlDtr.GetValue(j).ToString();
										
									k++;
								}
							}

							for(int j=0,k=0;j<SqlDtr.FieldCount;j++)//non scholastic
							{
								if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery"||DropClass .SelectedItem .Text=="LKG"||DropClass .SelectedItem .Text=="UKG")))//THIS FOR NON SCHOLASTIC
								{
									NmaxMarks[1,k] = SqlDtr.GetValue(j).ToString();
									
									k++;
								}
								else if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery"||DropClass .SelectedItem .Text=="LKG"||DropClass .SelectedItem .Text=="UKG"))
								{
									NmaxMarks[1,k] = SqlDtr.GetValue(j).ToString();
									
									k++;
								}
							}
						}
					}
					SqlDtr.Close();
					
					//if(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II")
					if(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG")
					{
						
						str="select (cast(Eng_Read as float) +cast(Eng_Writing as float)+cast(Eng_Con as float)+cast(Eng_Spelling as int)+cast(Eng_Compre as int)) as English,cast(Hindi_Read as float)+cast(Hindi_Writing as float)+cast(Hindi_Con as float)+cast(Hindi_spelling as float)+cast( Hindi_Com as float) as Hindi,cast(Math_FNumber as float)+cast( Math_BConcept as float) as Math,cast( Math_Computation as float)+cast( evs_observation as float)+cast( evs_Identification as float)+cast( Evs_know as float) as EVS,Computer_tot,Phy_edu,Music,Art,Craft,Dance from exammarksdecision where exam_type='IIIrd Unit Test' and class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'";
					}
					else
					{
						str="select " +strstr+" from exammarksdecision where exam_type='IIIrd Unit Test' and class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'";
					}
					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.HasRows)
					{
						while(SqlDtr.Read())
						{
							
							for(int j=0,k=0;j<SqlDtr.FieldCount;j++)
							{
								if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II" ||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))//THIS FOR NON SCHOLASTIC
								{
									maxMarks[2,k] = SqlDtr.GetValue(j).ToString();
									
									k++;
								}
								else if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								{
									maxMarks[2,k] = SqlDtr.GetValue(j).ToString();
									
									k++;
								}
							}

							for(int j=0,k=0;j<SqlDtr.FieldCount;j++)//non scholastic
							{
								if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))//THIS FOR NON SCHOLASTIC
								{
									NmaxMarks[2,k] = SqlDtr.GetValue(j).ToString();
									
									k++;
								}
								else if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								{
									NmaxMarks[2,k] = SqlDtr.GetValue(j).ToString();
									//MessageBox.Show(NmaxMarks[2,k].ToString());
									k++;
									
								}
							}
						}
					}
					SqlDtr.Close();


					if(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")
					{
						
						str="select (cast(Eng_Read as float) +cast(Eng_Writing as float)+cast(Eng_Con as float)+cast(Eng_Spelling as int)+cast(Eng_Compre as int)) as English,cast(Hindi_Read as float)+cast(Hindi_Writing as float)+cast(Hindi_Con as float)+cast(Hindi_spelling as float)+cast( Hindi_Com as float) as Hindi,cast(Math_FNumber as float)+cast( Math_BConcept as float) as Math,cast( Math_Computation as float)+cast( evs_observation as float)+cast( evs_Identification as float)+cast( Evs_know as float) as EVS,Computer_tot,Phy_edu,Music,Art,Craft,Dance from exammarksdecision where exam_type='IVth Unit Test' and class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'";
					}
					else
					{
						str="select " +strstr+" from exammarksdecision where exam_type='Ist Term' and class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'";
					}
					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.HasRows)
					{
						while(SqlDtr.Read())
						{
							//count1++; Mahesh
							for(int j=0,k=0;j<SqlDtr.FieldCount;j++)
							{
								if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))
								{
									count++;
									maxMarks[3,k] = SqlDtr.GetValue(j).ToString();
									
									k++;
								}
								else if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								{
									count++;
									maxMarks[3,k] = SqlDtr.GetValue(j).ToString();
									
									k++;
								}
							}
							for(int j=0,k=0;j<SqlDtr.FieldCount;j++)
							{
								if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))
								{
									NmaxMarks[3,k] = SqlDtr.GetValue(j).ToString();
									
									k++;
								}
								else if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								{
									NmaxMarks[3,k] = SqlDtr.GetValue(j).ToString();
									
									k++;
								}
							}
						}
					}
					SqlDtr.Close();

					if(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")
					{
						
						str="select (cast(Eng_Read as float) +cast(Eng_Writing as float)+cast(Eng_Con as float)+cast(Eng_Spelling as int)+cast(Eng_Compre as int)) as English,cast(Hindi_Read as float)+cast(Hindi_Writing as float)+cast(Hindi_Con as float)+cast(Hindi_spelling as float)+cast( Hindi_Com as float) as Hindi,cast(Math_FNumber as float)+cast( Math_BConcept as float) as Math,cast( Math_Computation as float)+cast( evs_observation as float)+cast( evs_Identification as float)+cast( Evs_know as float) as EVS,Computer_tot,Phy_edu,Music,Art,Craft,Dance from exammarksdecision where exam_type='Vth Unit Test' and class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'";
					}
					else
					{
						str="select " +strstr+" from exammarksdecision where exam_type='IInd Term' and class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'";
					}
					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.HasRows)
					{
						while(SqlDtr.Read())
						{
							
							for(int j=0,k=0;j<SqlDtr.FieldCount;j++)
							{
								if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))
								{
									maxMarks[4,k] = SqlDtr.GetValue(j).ToString();
									
									k++;
								}
								else if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								{
									maxMarks[4,k] = SqlDtr.GetValue(j).ToString();
									k++;
								}
							}
							for(int j=0,k=0;j<SqlDtr.FieldCount;j++)
							{
								if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))
								{
									NmaxMarks[4,k] = SqlDtr.GetValue(j).ToString();
									
									k++;
								}
								else if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								{
									NmaxMarks[4,k] = SqlDtr.GetValue(j).ToString();
									
									k++;
								}
							}
						}
					}
					SqlDtr.Close();

					if(!(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
					{
						str="select " +strstr+" from exammarksdecision where exam_type='IIIrd Term' and class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'";
				
						SqlDtr=obj.GetRecordSet(str);
						if(SqlDtr.HasRows)
						{
							while(SqlDtr.Read())
							{
								
								for(int j=0,k=0;j<SqlDtr.FieldCount;j++)
								{
									if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))
									{
										maxMarks[5,k] = SqlDtr.GetValue(j).ToString();
										
										k++;
									}
									else if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
									{
										maxMarks[5,k] = SqlDtr.GetValue(j).ToString();
										
										k++;
									}
								}
								for(int j=0,k=0;j<SqlDtr.FieldCount;j++)
								{
									if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))
									{
										NmaxMarks[5,k] = SqlDtr.GetValue(j).ToString();
										
										k++;
									}
									else if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
									{
										NmaxMarks[5,k] = SqlDtr.GetValue(j).ToString();
										
										k++;
									}
								}
							}
						}
						SqlDtr.Close();
					}
					
					if(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")
					{
						str="select (cast(Eng_Read as float) +cast(Eng_Writing as float)+cast(Eng_Con as float)+cast(Eng_Spelling as int)+cast(Eng_Compre as int)) as English,cast(Hindi_Read as float)+cast(Hindi_Writing as float)+cast(Hindi_Con as float)+cast(Hindi_spelling as float)+cast( Hindi_Com as float) as Hindi,cast(Math_FNumber as float)+cast( Math_BConcept as float) as Math,cast( Math_Computation as float)+cast( evs_observation as float)+cast( evs_Identification as float)+cast( Evs_know as float) as EVS,Computer_tot,Phy_edu,Music,Art,Craft,Dance from exammarksdecision where exam_type='Assign & Project' and class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'";
					}
					else
					{
						str="select " +strstr+" from exammarksdecision where exam_type='Assign & Project' and class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'";
					}
					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.HasRows)
					{
						while(SqlDtr.Read())
						{
								
							for(int j=0,k=0;j<SqlDtr.FieldCount;j++)
							{
								if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))//THIS FOR NON SCHOLASTIC
								{
									maxMarks[6,k] = SqlDtr.GetValue(j).ToString();
										
									k++;
								}
								else if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								{
									maxMarks[6,k] = SqlDtr.GetValue(j).ToString();
										
									k++;
								}
									//<Mahesh>
								else
								{
									maxMarks[6,k]="0";
									k++;
								}
							}
							for(int j=0,k=0;j<SqlDtr.FieldCount;j++)
							{
								if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))//THIS FOR NON SCHOLASTIC
								{
									NmaxMarks[6,k] = SqlDtr.GetValue(j).ToString();
										
									k++;
								}
								else if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								{
									NmaxMarks[6,k] = SqlDtr.GetValue(j).ToString();
										
									k++;
								}
									//<Mahesh>
								else
								{
									NmaxMarks[6,k]="0";
									k++;
								}
							}
						}
					}
					SqlDtr.Close();
				

					if(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")
					{
						
						str="select st.rollno,sr.sname,(cast(Eng_Read as float) +cast(Eng_Writing as float)+cast(Eng_Con as float)+cast(Eng_Spelling as int)+cast(Eng_Compre as int)) as English,cast(Hindi_Read as float)+cast(Hindi_Writing as float)+cast(Hindi_Con as float)+cast(Hindi_spelling as float)+cast( Hindi_Com as float) as Hindi,cast(Math_FNumber as float)+cast( Math_BConcept as float) as Math,cast( Math_Computation as float)+cast( evs_observation as float)+cast( evs_Identification as float)+cast( Evs_know as float) as EVS,st.Computer_tot,Phy_edu,Music,Art,Craft,Dance  FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and st.exam_type='Ist Unit Test'  and sr.st_section = '"+DropSec.SelectedItem.Text+"'"; //for class I and II
					}
					else
					{
						str="select sr.rollno RollNo,sm.Student_name StudentName,"+strstr+" from studentmarks sm,student_roll sr where sm.roleno=sr.studentid and sm.exam_type='Ist Unit Test' and sm.class ='"+DropClass.SelectedItem.Text+"' and sm.stream='"+DropStream.SelectedItem.Text+"' and sm.st_section='"+DropSec.SelectedItem.Text+"'";
					}
					
					SqlDtr=obj.GetRecordSet(str);
					int Flag=0;
					if(SqlDtr.HasRows)
					{
						Flag++;
						i=0;
						while(SqlDtr.Read())
						{
							count1++;
							
							for(int j=0,k=0;j<SqlDtr.FieldCount;j++)
							{
								string s=SqlDtr.GetValue(j).ToString();
								string ss=SqlDtr.GetName(j).ToUpper().ToString();
								if(j>=2)
								{
									if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))
									{
										
										if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&& SqlDtr.GetValue(j).ToString()!="A")
										{
											Ist[i,k] = SqlDtr.GetValue(j).ToString();
											
											unit1 =true;
										}
										else
											Ist[i,k] = "0";
										k++;
										
									}
									else if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
									{
										
										if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&& SqlDtr.GetValue(j).ToString()!="A")
										{
											
											Ist[i,k] = SqlDtr.GetValue(j).ToString();
											
											unit1 =true;
										}
										else
											Ist[i,k] = "0";
										k++;
										
									}
								}
								else
								{
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&& SqlDtr.GetValue(j).ToString()!="A")
									{
										
										Ist[i,k] = SqlDtr.GetValue(j).ToString();
										unit1 =true;
									}
									else
									{
										Ist[i,k]="0";
										
									}
									k++;
								}
							} 
							for(int j=2,k=0;j<SqlDtr.FieldCount;j++)
							{
								string s=SqlDtr.GetValue(j).ToString();
								string ss=SqlDtr.GetName(j).ToUpper();
								//if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE" || SqlDtr.GetName(j).ToUpper()=="COMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))
								if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))
								{
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&& SqlDtr.GetValue(j).ToString()!="A")
									{
										NIst[i,k] = SqlDtr.GetValue(j).ToString();
											
										unit1 =true;
									}
									else
										NIst[i,k] = "0";
									k++;
								}
									//else if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								else if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE" || SqlDtr.GetName(j).ToUpper()=="COMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								{
										
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&& SqlDtr.GetValue(j).ToString()!="A")
									{
										string sss=SqlDtr.GetValue(j).ToString();
										NIst[i,k] = SqlDtr.GetValue(j).ToString();
										unit1 =true;
									}
									else
										NIst[i,k] = "0";
									k++;
								}
							}
							i++;
						}
					}
					else
					{
						for(int p=0;p<Ist.Length/100;p++)
						{
							for(int j=0;j<100;j++)
							{
								Ist[p,j] = "0";
								NIst[p,j] = "0";
							}
						}
					}
					SqlDtr.Close();

					if(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")
					{
						
						str="select st.rollno,sr.sname,(cast(Eng_Read as float) +cast(Eng_Writing as float)+cast(Eng_Con as float)+cast(Eng_Spelling as int)+cast(Eng_Compre as int)) as English,cast(Hindi_Read as float)+cast(Hindi_Writing as float)+cast(Hindi_Con as float)+cast(Hindi_spelling as float)+cast( Hindi_Com as float) as Hindi,cast(Math_FNumber as float)+cast( Math_BConcept as float) as Math,cast( Math_Computation as float)+cast( evs_observation as float)+cast( evs_Identification as float)+cast( Evs_know as float) as EVS,st.Computer_tot,Phy_edu,Music,Art,Craft,Dance  FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and st.exam_type='IInd Unit Test'  and sr.st_section = '"+DropSec.SelectedItem.Text+"'"; 
					}
					else
					{
						str="select sr.rollno RollNo,sm.Student_name StudentName,"+strstr+" from studentmarks sm,student_roll sr where sm.roleno=sr.studentid and sm.exam_type='IInd Unit Test' and sm.class ='"+DropClass.SelectedItem.Text+"' and sm.stream='"+DropStream.SelectedItem.Text+"' and sm.st_section='"+DropSec.SelectedItem.Text+"'";
					}
					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.HasRows)
					{
						Flag++;
						i=0;
						while(SqlDtr.Read())
						{
							
							for(int j=2,k=0;j<SqlDtr.FieldCount;j++)
							{
								
								if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))//THIS FOR NON SCHOLASTIC
								{
									
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&&SqlDtr.GetValue(j).ToString()!="A")
									{
										IInd[i,k] = SqlDtr.GetValue(j).ToString();
										unit2=true;
									}
									else
									{
										
										IInd[i,k]="0";
									}
									k++;
								}
								else if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								{
									
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&&SqlDtr.GetValue(j).ToString()!="A")
									{
										IInd[i,k] = SqlDtr.GetValue(j).ToString();
										unit2=true;
									}
								
									else
									{
										
										IInd[i,k]="0";
									}
									k++;
								}
							}
							for(int j=2,k=0;j<SqlDtr.FieldCount;j++)
							{
								string s=SqlDtr.GetValue(j).ToString();
								if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))
								{
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&& SqlDtr.GetValue(j).ToString()!="A")
									{
										NIInd [i,k] = SqlDtr.GetValue(j).ToString();
										
										unit2 =true;
									}
									else
										NIInd [i,k] = "0";
									k++;
								}
								else if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								{
									
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&& SqlDtr.GetValue(j).ToString()!="A")
									{
										
										NIInd [i,k] = SqlDtr.GetValue(j).ToString();
										
										unit2 =true;
									}
									else
										NIInd[i,k] = "0";
									k++;
								}
							}
							i++;
							
						}
					}
					else
					{
						for(int p=0;p<IInd.Length/100;p++)
						{
							for(int j=0;j<100;j++)
							{
								IInd[p,j] = "0";
								NIInd[p,j]="0";
							}
						}
					}
					SqlDtr.Close();

					if(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")
					{
						
						str="select st.rollno,sr.sname,(cast(Eng_Read as float) +cast(Eng_Writing as float)+cast(Eng_Con as float)+cast(Eng_Spelling as int)+cast(Eng_Compre as int)) as English,cast(Hindi_Read as float)+cast(Hindi_Writing as float)+cast(Hindi_Con as float)+cast(Hindi_spelling as float)+cast( Hindi_Com as float) as Hindi,cast(Math_FNumber as float)+cast( Math_BConcept as float) as Math,cast( Math_Computation as float)+cast( evs_observation as float)+cast( evs_Identification as float)+cast( Evs_know as float) as EVS,st.Computer_tot,Phy_edu,Music,Art,Craft,Dance  FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and st.exam_type='IIIrd Unit Test'  and sr.st_section = '"+DropSec.SelectedItem.Text+"'";
					}
					else
					{
						str="select sr.rollno RollNo,sm.Student_name StudentName,"+strstr+" from studentmarks sm,student_roll sr where sm.roleno=sr.studentid and sm.exam_type='IIIrd Unit Test' and sm.class ='"+DropClass.SelectedItem.Text+"' and sm.stream='"+DropStream.SelectedItem.Text+"' and sm.st_section='"+DropSec.SelectedItem.Text+"'";
					}

					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.HasRows)
					{
						Flag++;
						i=0;
						while(SqlDtr.Read())
						{
							
							for(int j=2,k=0;j<SqlDtr.FieldCount;j++)
							{
								if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))
								{
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&&SqlDtr.GetValue(j).ToString()!="A")
									{
									
										Third[i,k] = SqlDtr.GetValue(j).ToString();
										unit3=true;
									}
									else
									{
										
										Third[i,k]="0";
									}
									k++;
								}
								
								else if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								{
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&&SqlDtr.GetValue(j).ToString()!="A")
									{
									
										Third[i,k] = SqlDtr.GetValue(j).ToString();
										unit3=true;
									}
									else
									{
									
										Third[i,k]="0";
									}
									k++;
								}
							}

							for(int j=2,k=0;j<SqlDtr.FieldCount;j++)
							{
								string s=SqlDtr.GetValue(j).ToString();
								if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))
								{
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&& SqlDtr.GetValue(j).ToString()!="A")
									{
										NThird [i,k] = SqlDtr.GetValue(j).ToString();
										
										unit3 =true;
									}
									else
										NThird [i,k] = "0";
									k++;
								}
								else if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								{
									
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&& SqlDtr.GetValue(j).ToString()!="A")
									{
										
										NThird [i,k] = SqlDtr.GetValue(j).ToString();
										
										unit3 =true;
									}
									else
										NThird[i,k] = "0";
									k++;
								}
							}

							i++;
						}
					}
					else
					{
						for(int p=0;p<Third.Length/100;p++)
						{
							for(int j=0;j<100;j++)
							{
								Third[p,j] = "0";
								NThird[p,j] = "0";
							}
						}
					}
					SqlDtr.Close();
					if(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")
					{
						
						str="select st.rollno,sr.sname,(cast(Eng_Read as float) +cast(Eng_Writing as float)+cast(Eng_Con as float)+cast(Eng_Spelling as int)+cast(Eng_Compre as int)) as English,cast(Hindi_Read as float)+cast(Hindi_Writing as float)+cast(Hindi_Con as float)+cast(Hindi_spelling as float)+cast( Hindi_Com as float) as Hindi,cast(Math_FNumber as float)+cast( Math_BConcept as float) as Math,cast( Math_Computation as float)+cast( evs_observation as float)+cast( evs_Identification as float)+cast( Evs_know as float) as EVS ,st.Computer_tot,Phy_edu,Music,Art,Craft,Dance  FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and st.exam_type='Assign & Project'  and sr.st_section = '"+DropSec.SelectedItem.Text+"'";
					}
					else
					{
						str="select sr.rollno RollNo,sm.Student_name StudentName,"+strstr+" from studentmarks sm,student_roll sr where sm.roleno=sr.studentid and sm.exam_type='Assign & Project' and sm.class ='"+DropClass.SelectedItem.Text+"' and sm.stream='"+DropStream.SelectedItem.Text+"' and sm.st_section='"+DropSec.SelectedItem.Text+"'";
					}

					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.HasRows)
					{
						Flag++;
						i=0;
						while(SqlDtr.Read())
						{
							
							for(int j=2,k=0;j<SqlDtr.FieldCount;j++)
							{
								if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))//THIS FOR NON SCHOLASTIC
								{
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&&SqlDtr.GetValue(j).ToString()!="A")
									{
										Assgn[i,k] = SqlDtr.GetValue(j).ToString();
										assgn =true;
									}
									else
									{
										Assgn[i,k]="0";
									}
									k++;
								}
								else if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								{ 
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&&SqlDtr.GetValue(j).ToString()!="A")
									{
										Assgn[i,k] = SqlDtr.GetValue(j).ToString();
										assgn =true;
									}
									else
									{
										Assgn[i,k]="0";
									}
									k++;
								}
							}

							for(int j=0,k=0;j<SqlDtr.FieldCount;j++)
							{
								string s=SqlDtr.GetValue(j).ToString();
								if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))
								{
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&& SqlDtr.GetValue(j).ToString()!="A")
									{
										NAssgn [i,k] = SqlDtr.GetValue(j).ToString();
								
										assgn =true;
									}
									else
										NAssgn [i,k] = "0";
									k++;
								}
								else if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								{
									
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&& SqlDtr.GetValue(j).ToString()!="A")
									{
										
										NAssgn [i,k] = SqlDtr.GetValue(j).ToString();
										
										assgn =true;
									}
									else
										NAssgn[i,k] = "0";
									k++;
								}
							}

							i++;
						}
					}
					else
					{
						for(int p=0;p<Assgn.Length/100;p++)
						{
							for(int j=0;j<100;j++)
							{
								Assgn[p,j] = "0";
								NAssgn[p,j]="0";
								
							}
						}
					}
					SqlDtr.Close();
					
					int checkClass=0;
		
					if(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")
					{
						
						str="select st.rollno,sr.sname,(cast(Eng_Read as float) +cast(Eng_Writing as float)+cast(Eng_Con as float)+cast(Eng_Spelling as int)+cast(Eng_Compre as int)) as English,cast(Hindi_Read as float)+cast(Hindi_Writing as float)+cast(Hindi_Con as float)+cast(Hindi_spelling as float)+cast( Hindi_Com as float) as Hindi,cast(Math_FNumber as float)+cast( Math_BConcept as float) as Math,cast( Math_Computation as float)+cast( evs_observation as float)+cast( evs_Identification as float)+cast( Evs_know as float) as EVS,st.Computer_tot,Phy_edu,Music,Art,Craft,Dance  FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and st.exam_type='IVth Unit Test'  and sr.st_section = '"+DropSec.SelectedItem.Text+"'"; //for class I and II
						checkClass=0;
					}
					else
					{
						str="select sr.rollno RollNo,sm.Student_name StudentName,"+strstr+" from studentmarks sm,student_roll sr where sm.roleno=sr.studentid and sm.exam_type='Ist Term' and sm.class ='"+DropClass.SelectedItem.Text+"' and sm.stream='"+DropStream.SelectedItem.Text+"' and sm.st_section='"+DropSec.SelectedItem.Text+"'";
						checkClass=1;
					}


					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.HasRows)
					{
						Flag++;
						i=0;
						while(SqlDtr.Read())
						{
							if(checkClass==1)
								count1++;//Mahesh
						
							for(int j=0,k=0;j<SqlDtr.FieldCount;j++)
							{
								string s=SqlDtr.GetValue(j).ToString();
								if(j>=2)
								{
									if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))//THIS FOR NON SCHOLASTIC
									{
										if(SqlDtr.GetValue(j).ToString()!="")
										{
											
											Test1[i,k] = SqlDtr.GetValue(j).ToString();
											test1=true;
											k++;
										}
										else
										{
											Test1[i,k] = "0";
											
											k++;
										}
									}	
									
									else if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
									{
										if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&&SqlDtr.GetValue(j).ToString()!="A")
										{
										
											Test1[i,k] = SqlDtr.GetValue(j).ToString();
											test1=true;
											k++;
										}
										else
										{
											Test1[i,k] = "0";
											
											k++;
										}
									}

								}
								else
								{
									
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&&SqlDtr.GetValue(j).ToString()!="A")
									{
										
										Test1[i,k] = SqlDtr.GetValue(j).ToString();
										test1=true;
									}
									else
									{
										
										Test1[i,k]="0";
									
									}
									k++;
								}
								
							}
							for(int j=2,k=0;j<SqlDtr.FieldCount;j++)
							{
								string s=SqlDtr.GetValue(j).ToString();
								if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))
								{
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&& SqlDtr.GetValue(j).ToString()!="A")
									{
										NTest1[i,k] = SqlDtr.GetValue(j).ToString();
										
										test1 =true;
									}
									else
										NTest1 [i,k] = "0";
									k++;
								}
								else if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								{
								
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&& SqlDtr.GetValue(j).ToString()!="A")
									{
										
										NTest1 [i,k] = SqlDtr.GetValue(j).ToString();
										
										test1 =true;
									}
									else
										NTest1[i,k] = "0";
									k++;
								}
							}
							i++;
						}
					}
					else
					{
						for(int p=0;p<Test1.Length/100;p++)
						{
							for(int j=0;j<100;j++)
							{
								Test1[p,j] = "0";
								NTest1[p,j] = "0";
							}
						}
					}
					SqlDtr.Close();

					if(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")
					{
						str="select st.rollno,sr.sname,(cast(Eng_Read as float) +cast(Eng_Writing as float)+cast(Eng_Con as float)+cast(Eng_Spelling as int)+cast(Eng_Compre as int)) as English,cast(Hindi_Read as float)+cast(Hindi_Writing as float)+cast(Hindi_Con as float)+cast(Hindi_spelling as float)+cast( Hindi_Com as float) as Hindi,cast(Math_FNumber as float)+cast( Math_BConcept as float) as Math,cast( Math_Computation as float)+cast( evs_observation as float)+cast( evs_Identification as float)+cast( Evs_know as float) as EVS,st.Computer_tot,Phy_edu,Music,Art,Craft,Dance  FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and st.exam_type='Vth Unit Test'  and sr.st_section = '"+DropSec.SelectedItem.Text+"'"; 
					}
					else
					{
						str="select sr.rollno RollNo,sm.Student_name StudentName,"+strstr+" from studentmarks sm,student_roll sr where sm.roleno=sr.studentid and sm.exam_type='IInd Term' and sm.class ='"+DropClass.SelectedItem.Text+"' and sm.stream='"+DropStream.SelectedItem.Text+"' and sm.st_section='"+DropSec.SelectedItem.Text+"'";
					}

					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.HasRows)
					{
						Flag++;
						i=0;
						while(SqlDtr.Read())
						{
							
							for(int j=2,k=0;j<SqlDtr.FieldCount;j++)
							{
								if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))
								{
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&&SqlDtr.GetValue(j).ToString()!="A")
									{
										
										Test2[i,k] = SqlDtr.GetValue(j).ToString();
										k++;
										test2 =true;
									}
								}
								
								else if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								{
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&&SqlDtr.GetValue(j).ToString()!="A")
									{
										
										Test2[i,k] = SqlDtr.GetValue(j).ToString();
										k++;
										test2 =true;
									}
								}
							}
							for(int j=2,k=0;j<SqlDtr.FieldCount;j++)
							{
								string s=SqlDtr.GetValue(j).ToString();
								if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))
								{
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&& SqlDtr.GetValue(j).ToString()!="A")
									{
										NTest2[i,k] = SqlDtr.GetValue(j).ToString();
										
										test2 =true;
									}
									else
										NTest2 [i,k] = "0";
									k++;
								}
								else if((SqlDtr.GetName(j).ToUpper()=="MUSIC"||SqlDtr.GetName(j).ToUpper()=="ART"||SqlDtr.GetName(j).ToUpper()=="CRAFT"||SqlDtr.GetName(j).ToUpper()=="PHY_EDU"||SqlDtr.GetName(j).ToUpper()=="DANCE"||SqlDtr.GetName(j).ToUpper()=="GK"||SqlDtr.GetName(j).ToUpper()=="GSTUDIES"||SqlDtr.GetName(j).ToUpper()=="ART_AND_CRAFT"||SqlDtr.GetName(j).ToUpper()=="WORK_EXP"||SqlDtr.GetName(j).ToUpper()=="MORAL_SCIENCE"||SqlDtr.GetName(j).ToUpper()=="MUSIC_AND_DANCE"||SqlDtr.GetName(j).ToUpper()=="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								{
									
									if(SqlDtr.GetValue(j).ToString()!=null&&SqlDtr.GetValue(j).ToString()!=""&& SqlDtr.GetValue(j).ToString()!="A")
									{
										
										NTest2 [i,k] = SqlDtr.GetValue(j).ToString();
										
										test2 =true;
									}
									else
										NTest2[i,k] = "0";
									k++;
								}
							}
							i++;
						}
					}
					else
					{
						for(int p=0;p<Test2.Length/100;p++)
						{
							for(int j=0;j<100;j++)
							{
								Test2[p,j] = "0";
								NTest2[p,j] = "0";
							}
						}
					}
					SqlDtr.Close();

					
					if(!(DropClass .SelectedItem .Text=="I"||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
					{
						//str="select sr.rollno RollNo,sm.Student_name StudentName,"+strstr+" from studentmarks sm,student_roll sr where sm.roleno=sr.studentid and sm.exam_type='IIIrd Unit Test' and sm.class ='"+DropClass.SelectedItem.Text+"' and sm.stream='"+DropStream.SelectedItem.Text+"' and sm.st_section='"+DropSec.SelectedItem.Text+"'";
						str="select sr.rollno RollNo,sm.Student_name StudentName,"+strstr+" from studentmarks sm,student_roll sr where sm.roleno=sr.studentid and sm.exam_type='IIIrd Term' and sm.class ='"+DropClass.SelectedItem.Text+"' and sm.stream='"+DropStream.SelectedItem.Text+"' and sm.st_section='"+DropSec.SelectedItem.Text+"'";
					
						SqlDtr=obj.GetRecordSet(str);
						if(SqlDtr.HasRows)
						{
							Flag++;
							i=0;
							while(SqlDtr.Read())
							{
								
								for(int j=2,k=0;j<SqlDtr.FieldCount;j++)
								{
									if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(!(DropClass .SelectedItem .Text=="I" ||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")))
									{
										
										Test3[i,k] = SqlDtr.GetValue(j).ToString();
										k++;
										test3 =true;
									}
									
									else if((SqlDtr.GetName(j).ToUpper()!="MUSIC"&&SqlDtr.GetName(j).ToUpper()!="ART"&&SqlDtr.GetName(j).ToUpper()!="CRAFT"&&SqlDtr.GetName(j).ToUpper()!="PHY_EDU"&&SqlDtr.GetName(j).ToUpper()!="DANCE"&&SqlDtr.GetName(j).ToUpper()!="GK"&&SqlDtr.GetName(j).ToUpper()!="GSTUDIES"&&SqlDtr.GetName(j).ToUpper()!="ART_AND_CRAFT"&&SqlDtr.GetName(j).ToUpper()!="WORK_EXP"&&SqlDtr.GetName(j).ToUpper()!="MORAL_SCIENCE"&&SqlDtr.GetName(j).ToUpper()!="MUSIC_AND_DANCE"&&SqlDtr.GetName(j).ToUpper()!="CUMPUTER_TOT")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
									{
										
										Test3[i,k] = SqlDtr.GetValue(j).ToString();
										k++;
										test3 =true;
									}
								}
								i++;
							}
						}
						else
						{
							for(int p=0;p<Test3.Length/100;p++)
							{
								for(int j=0;j<100;j++)
								{
									Test3[p,j] = "0";
								}
							}
						}
						SqlDtr.Close();
					}
					
					if(count1>0)
					{
						for(int p=0;p<count1;p++)
						{
							for(int q=0;q<count;q++)
							{
								double marks=0;
								if(!(DropClass.SelectedItem .Text=="I"||DropClass .SelectedItem .Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG"))
								{
									if(unit1==true && unit2==true&&unit3==true)
									{
									
										if(DropClass.SelectedItem.Text=="IX"||DropClass.SelectedItem.Text=="XI")
										{
											unit[p,q]=GenUtil.strNumericFormat((((System.Convert.ToDouble(Ist[p,q+2])+System.Convert.ToDouble(IInd[p,q])+System.Convert.ToDouble(Third[p,q]))/(System.Convert.ToDouble(maxMarks[0,q])+System.Convert.ToDouble(maxMarks[1,q])+System.Convert.ToDouble(maxMarks[2,q])))*5).ToString ());
										}
										else
										{
											unit[p,q]=GenUtil.strNumericFormat((((System.Convert.ToDouble(Ist[p,q+2])+System.Convert.ToDouble(IInd[p,q])+System.Convert.ToDouble(Third[p,q]))/(System.Convert.ToDouble(maxMarks[0,q])+System.Convert.ToDouble(maxMarks[1,q])+System.Convert.ToDouble(maxMarks[2,q])))*20).ToString ());
										}
									}
									else if(unit1==true && unit2==true)
									{
										if(DropClass.SelectedItem.Text=="IX"||DropClass.SelectedItem.Text=="XI")
										{
											unit[p,q]=GenUtil.strNumericFormat((((System.Convert.ToDouble(Ist[p,q+2])+System.Convert.ToDouble(IInd[p,q]))/(System.Convert.ToDouble(maxMarks[0,q])+System.Convert.ToDouble(maxMarks[1,q])))*5).ToString ());
										}
										else
										{
											
											unit[p,q]=GenUtil.strNumericFormat((((System.Convert.ToDouble(Ist[p,q+2])+System.Convert.ToDouble(IInd[p,q]))/(System.Convert.ToDouble(maxMarks[0,q])+System.Convert.ToDouble(maxMarks[1,q])))*20).ToString ());
										}
									}
									else if(unit1==true)
									{
										if(DropClass.SelectedItem.Text=="IX"||DropClass.SelectedItem.Text=="XI")
										{
											unit[p,q]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Ist[p,q+2])*5)/(System.Convert.ToDouble(maxMarks[0,q]))).ToString());
										}
										else
										{
											unit[p,q]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Ist[p,q+2])*20)/(System.Convert.ToDouble(maxMarks[0,q]))).ToString());
										}
									}
									if(test1==true)
									{
										if(DropClass.SelectedItem.Text=="IX"||DropClass.SelectedItem.Text=="XI")
										{
											Test1[p,q+2]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Test1[p,q+2])*20)/(System.Convert.ToDouble(maxMarks[3,q]))).ToString());
										}
										else
										{
											Test1[p,q+2]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Test1[p,q+2])*10)/(System.Convert.ToDouble(maxMarks[3,q]))).ToString());
										}
									}
									
									if(test2==true)
									{
										if(DropClass.SelectedItem.Text=="IX"||DropClass.SelectedItem.Text=="XI")
										{
											Test2[p,q]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Test2[p,q])*20)/(System.Convert.ToDouble(maxMarks[4,q]))).ToString());
											
										}
										else
										{
											
											Test2[p,q]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Test2[p,q])*10)/(System.Convert.ToDouble(maxMarks[4,q]))).ToString());
											
										}
									}
									
									if(test3==true)
									{
										if(DropClass.SelectedItem.Text=="IX"||DropClass.SelectedItem.Text=="XI")
										{
											Test3[p,q]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Test3[p,q])*50)/(System.Convert.ToDouble(maxMarks[5,q]))).ToString());
											
										}
										else
										{
											
											Test3[p,q]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Test3[p,q])*40)/(System.Convert.ToDouble(maxMarks[5,q]))).ToString());
											
										}
									}
									
									if(assgn ==true)
									{
										if(DropClass.SelectedItem.Text=="IX"||DropClass.SelectedItem.Text=="XI")
										{
											
											Assgn[p,q]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Assgn[p,q])*5)/(System.Convert.ToDouble(maxMarks[6,q]))).ToString());
											
										}
										else
										{
											
											Assgn[p,q]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Assgn[p,q])*20)/(System.Convert.ToDouble(maxMarks[6,q]))).ToString());
											
										}
									}
									
									//marks=System.Convert.ToDouble(unit[p,q])+System.Convert.ToDouble(Test1[p,q+2])+System.Convert.ToDouble(Assgn[p,q])+System.Convert.ToDouble(Test2[p,q])+System.Convert.ToDouble(Test3[p,q]);
									//19.02.09 marks=System.Convert.ToDouble(Test1[p,q+2])+System.Convert.ToDouble(Assgn[p,q])+System.Convert.ToDouble(Test2[p,q]);
									marks=System.Convert.ToDouble(unit[p,q])+System.Convert.ToDouble(Assgn[p,q])+System.Convert.ToDouble(Test1[p,q+2])+System.Convert.ToDouble(Test2[p,q]);
									gtotal[p]+=marks;
									

								}
								else if(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass .SelectedItem .Text=="Nursery" ||DropClass .SelectedItem .Text=="LKG" ||DropClass .SelectedItem .Text=="UKG")
								{
									if(unit1==true && unit2==true&&unit3==true)
									
									{
										if(DropClass.SelectedItem.Text=="IX"||DropClass.SelectedItem.Text=="XI")
										{
											unit[p,q]=GenUtil.strNumericFormat((((System.Convert.ToDouble(Ist[p,q+2])+System.Convert.ToDouble(IInd[p,q])+System.Convert.ToDouble(Third[p,q]))/(System.Convert.ToDouble(maxMarks[0,q])+System.Convert.ToDouble(maxMarks[1,q])+System.Convert.ToDouble(maxMarks[2,q])))*5).ToString ());
										}
										else
										{
											unit[p,q]=GenUtil.strNumericFormat((((System.Convert.ToDouble(Ist[p,q+2])+System.Convert.ToDouble(IInd[p,q])+System.Convert.ToDouble(Third[p,q]))/(System.Convert.ToDouble(maxMarks[0,q])+System.Convert.ToDouble(maxMarks[1,q])+System.Convert.ToDouble(maxMarks[2,q])))*20).ToString ());
											
											if(unit[p,q]=="NaN.00")//Mahesh06.09.008
												unit[p,q]="0";
										}
									}
									else if(unit1==true && unit2==true)
									{
										if(DropClass.SelectedItem.Text=="IX"||DropClass.SelectedItem.Text=="XI")
										{
											unit[p,q]=GenUtil.strNumericFormat((((System.Convert.ToDouble(Ist[p,q+2])+System.Convert.ToDouble(IInd[p,q]))/(System.Convert.ToDouble(maxMarks[0,q])+System.Convert.ToDouble(maxMarks[1,q])))*5).ToString ());
										}
										else
										{
											unit[p,q]=GenUtil.strNumericFormat((((System.Convert.ToDouble(Ist[p,q+2])+System.Convert.ToDouble(IInd[p,q]))/(System.Convert.ToDouble(maxMarks[0,q])+System.Convert.ToDouble(maxMarks[1,q])))*20).ToString ());
											if(unit[p,q]=="NaN.00")//Mahesh06.09.008
												unit[p,q]="0";
										}
									}
									else if(unit1==true)
									{
										if(DropClass.SelectedItem.Text=="IX"||DropClass.SelectedItem.Text=="XI")
										{
											unit[p,q]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Ist[p,q+2])*5)/(System.Convert.ToDouble(maxMarks[0,q]))).ToString());
										}
										else
										{
											unit[p,q]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Ist[p,q+2])*20)/(System.Convert.ToDouble(maxMarks[0,q]))).ToString());
											if(unit[p,q]=="NaN.00")//Mahesh06.09.008
												unit[p,q]="0";
										}
									}
									if(test1==true)
									{
										if(DropClass.SelectedItem.Text=="IX"||DropClass.SelectedItem.Text=="XI")
										{
									
										
											Test1[p,q+2]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Test1[p,q+2])*20)/(System.Convert.ToDouble(maxMarks[3,q]))).ToString());
											
										}
										else
										{
											
											Test1[p,q+2]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Test1[p,q+2])*10)/(System.Convert.ToDouble(maxMarks[3,q]))).ToString());
											if(Test1[p,q+2]=="NaN.00")//Mahesh06.09.008
												Test1[p,q+2]="0";
										}
									}
									if(test2==true)
									{
										if(DropClass.SelectedItem.Text=="IX"||DropClass.SelectedItem.Text=="XI")
										{
											Test2[p,q]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Test2[p,q])*20)/(System.Convert.ToDouble(maxMarks[4,q]))).ToString());
											
										}
										else
										{
											
											Test2[p,q]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Test2[p,q])*10)/(System.Convert.ToDouble(maxMarks[4,q]))).ToString());
											if(Test2[p,q]=="NaN.00")//Mahesh06.09.008
												Test2[p,q]="0";
										}
									}
									if(test3==true)
									{
										if(DropClass.SelectedItem.Text=="IX"||DropClass.SelectedItem.Text=="XI")
										{
											Test3[p,q]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Test3[p,q])*50)/(System.Convert.ToDouble(maxMarks[5,q]))).ToString());
										}
										else
										{
											Test3[p,q]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Test3[p,q])*40)/(System.Convert.ToDouble(maxMarks[5,q]))).ToString());
											if(Test3[p,q]=="NaN.00")//Mahesh06.09.008
												Test3[p,q]="0";
										}
									}
									if(assgn ==true)
									{
										if(DropClass.SelectedItem.Text=="IX"||DropClass.SelectedItem.Text=="XI")
										{
											
											Assgn [p,q]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Assgn[p,q])*5)/(System.Convert.ToDouble(maxMarks[6,q]))).ToString());
											if(Assgn[p,q]=="NaN.00")//Mahesh06.09.008
												Assgn[p,q]="0";
										}
										else
										{
											
											Assgn[p,q]=GenUtil.strNumericFormat(((System.Convert.ToDouble(Assgn[p,q])*20)/(System.Convert.ToDouble(maxMarks[6,q]))).ToString());
											if(Assgn[p,q]=="NaN.00")//Mahesh06.09.008
												Assgn[p,q]="0";
										}
									}
									//marks=System.Convert.ToDouble(unit[p,q])+System.Convert.ToDouble(Test1[p,q+2])+System.Convert.ToDouble(Assgn[p,q])+System.Convert.ToDouble(Test2[p,q])+System.Convert.ToDouble(Test3[p,q]);
									//19.02.09 marks=System.Convert.ToDouble(unit[p,q])+System.Convert.ToDouble(Test1[p,q+2])+System.Convert.ToDouble(Assgn[p,q])+System.Convert.ToDouble(Test2[p,q])+System.Convert.ToDouble(Test3[p,q]);
									marks=System.Convert.ToDouble(unit[p,q])+System.Convert.ToDouble(Assgn[p,q])+System.Convert.ToDouble(Test1[p,q+2])+System.Convert.ToDouble(Test2[p,q]);
									gtotal[p]+=marks;
									
								}
								//if(unit1==true && unit2==true&&unit3==true && test1==true&&test2==true&&test3==true)
								if(test1==true&&test2==true&&test3==true)
								{
									if(marks>=95 && marks <=100)
										grade[p,q]="A+";
									else  if(marks>=85 && marks <95)
										grade[p,q]="A";
									else  if(marks>=75 && marks <85)
										grade[p,q]="B+";
									else  if(marks>=65 && marks <75)
										grade[p,q]="B";
									else  if(marks>=55 && marks <65)
										grade[p,q]="C+";
									else  if(marks>=45 && marks <55)
										grade[p,q]="C";
									else  if(marks>=40 && marks <45)
										grade[p,q]="D";
									else  if(marks<40)
										grade[p,q]="E";
									else 
										grade[p,q]="N/A";
									
									double m=gtotal[p]/(double)(q+1);
									
									if(m>=95 && m <=100)
										ggrade[p]="A+";
									else  if(m>=85 && m <95)
										ggrade[p]="A";
									else  if(m>=75 && m <85)
										ggrade[p]="B+";
									else  if(m>=65 && m <75)
										ggrade[p]="B";
									else  if(m>=55 && m <65)
										ggrade[p]="C+";
									else  if(m>=45 && m <55)
										ggrade[p]="C";
									else  if(m>=40 && m <45)
										ggrade[p]="D";
									else  if(m<40)
										ggrade[p]="E";
									else 
										ggrade[p]="N/A";
								}
									//else if(unit1==true && unit2==true&&unit3==true && test1==true&&test2==true)
								else if(test1==true&&test2==true)
								{
									if(marks>=95 && marks <=100)
										grade[p,q]="A+";
									else  if(marks>=85 && marks <95)
										grade[p,q]="A";
									else  if(marks>=75 && marks <85)
										grade[p,q]="B+";
									else  if(marks>=65 && marks <75)
										grade[p,q]="B";
									else  if(marks>=55 && marks <65)
										grade[p,q]="C+";
									else  if(marks>=45 && marks <55)
										grade[p,q]="C";
									else  if(marks>=40 && marks <45)
										grade[p,q]="D";
									else  if(marks<40)
										grade[p,q]="E";
									else 
										grade[p,q]="N/A";
									
									double m=gtotal[p]/(double)(q+1);
									
									if(m>=95 && m <=100)
										ggrade[p]="A+";
									else  if(m>=85 && m <95)
										ggrade[p]="A";
									else  if(m>=75 && m <85)
										ggrade[p]="B+";
									else  if(m>=65 && m <75)
										ggrade[p]="B";
									else  if(m>=55 && m <65)
										ggrade[p]="C+";
									else  if(m>=45 && m <55)
										ggrade[p]="C";
									else  if(m>=40 && m <45)
										ggrade[p]="D";
									else  if(m<40)
										ggrade[p]="E";
									else 
										ggrade[p]="N/A";
								}
								else
								{
									ggrade[p]="0";
									grade[p,q]="0";
								}

							}
							
						}
					}
					else
					{
						for(int b=0;b<grade.Length/100;b++)
						{
							
							for(int c=0;c<100;c++)
							{
								grade[b,c]="";
							}
						}
					}
					getRank();
				}
				else
					MessageBox.Show("Plese Select The Student Class, Section & Stream ");
				
			}
			catch(Exception ex)
			{
				
				CreateLogFiles.ErrorLog("Form:GreenSheetReport,Method: Show_Click,Show GreenSheet "+"  EXCEPTION "+ex.Message+"  userid  ");
				return;
			}
		}

		/// <summary>
		/// this method use to get rank of every student. 
		/// </summary>
		void  getRank()
		{
			int i,j,k;
			double[] a =new double [100];
			double m;
			for( k=0;k<count1;k++)
			{
				a[k]=gtotal[k];
			}
			for(j=1;j<count1;j++)
			{
				m=a[j];
				i=j-1;
				while(i>=0&&a[i]>m)
				{
					a[i+1]=a[i];
					i--;
				}
				a[i+1]=m;
			}
			for(i=count1-1,k=0;i>=0;i--,k++)
			{
				for(j=0;j<count1;j++)
				{
					if(gtotal[j]==a[i])
					{
						rank[k]=j+1;
						break;
					}
				}
			}
		}

		/// <summary>
		/// this method use to create report in text format. in this method first get subject from classwisesubject table. after that get max marks of every subject and every type of exam from exammarksdecision table and store
		/// in a array. after that get students all type exam markas from studentmarks or studentmarksentryIandII table and save in 2D array. and also check grade and get rank with the help of rank() function.
		/// and store in array.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(View!=0)
				{
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2);
					string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\GreenSheetReport.txt";
					StreamWriter sw = new StreamWriter(path);
					string info="";

					if(DropClass.SelectedIndex!=0 && DropSec.SelectedIndex!=0)
					{
						InventoryClass obj=new InventoryClass();
						SqlDataReader SqlDtr=null;
						string cls="";
						/*if(DropClass.SelectedItem.Text=="I")
							cls="1";
						else if(DropClass.SelectedItem.Text=="II")
							cls="2";
						else if(DropClass.SelectedItem.Text=="III")
							cls="3";
						else if(DropClass.SelectedItem.Text=="IV")
							cls="4";
						else if(DropClass.SelectedItem.Text=="V")
							cls="5";
						else if(DropClass.SelectedItem.Text=="VI")
							cls="6";
						else if(DropClass.SelectedItem.Text=="VII")
							cls="7";
						else if(DropClass.SelectedItem.Text=="VIII")
							cls="8";
						else if(DropClass.SelectedItem.Text=="IX")
							cls="9";
						else if(DropClass.SelectedItem.Text=="X")
							cls="10";
						else if(DropClass.SelectedItem.Text=="XI")
							cls="11";
						else if(DropClass.SelectedItem.Text=="XII")
							cls="12";*/
					
						sw.Write((char)27);
						sw.Write((char)67);
						sw.Write((char)0);
						sw.Write((char)12);			
						sw.Write((char)27);
						sw.Write((char)78);
						sw.Write((char)5);							
						sw.Write((char)27);
						sw.Write((char)15);
						sw.Write((char)27);
						sw.Write((char)81);
						sw.Write((char)0);				
						string Header="";
						string Header1="";
						string Header2="";
						string desdes="";
						if((DropClass.SelectedItem.Text=="I" || DropClass.SelectedItem.Text=="II"|| DropClass.SelectedItem.Text=="Nursery"|| DropClass.SelectedItem.Text=="LKG"|| DropClass.SelectedItem.Text=="UKG")&& DropSec.SelectedIndex!=0)// && DropStream.SelectedIndex!=0)
						{
							Header="|R.No |";
							Header+="Student Name |";
							desdes="+-----+-------------+";
							Header1="                    ";
							Header2="+-----+-------------";
							if(Subject.Length>0)
							{
								for(int ii=0;ii<Subject.Length;ii++)
								{
									string temp="",temp1="";
									if(Subject[ii].ToUpper()!="MUSIC"&&Subject[ii].ToUpper()!="ART"&&Subject[ii].ToUpper()!="CRAFT"&&Subject[ii].ToUpper()!="PHY_EDU"&&Subject[ii].ToUpper()!="DANCE"&&Subject[ii].ToUpper()!="GK"&&Subject[ii].ToUpper()!="GSTUDIES"&&Subject[ii].ToUpper()!="ART_AND_CRAFT"&&Subject[ii].ToUpper()!="WORK_EXP"&&Subject[ii].ToUpper()!="MORAL_SCIENCE"&&Subject[ii].ToUpper()!="MUSIC_AND_DANCE"&&Subject[ii].ToUpper()!="COMPUTER")//THIS FOR NON SCHOLASTIC
									{
										//19.02.09 temp="|UTest|Pr/AS|ITerm|2Term|Anual|Total";
										//19.02.09 temp1="+-----+-----+-----+-----+-----+-----";
										temp="|UTest|Pr/AS|ITerm|2Term|Total";
										temp1="+-----+-----+-----+-----+-----";

										for(int j=0;j<(temp.Length-Subject[ii].ToString().Length-1)/2;j++)
										{
											Header+=" ";
										}
										Header+=Subject[ii].ToString().ToUpper();
										for(int j=0;j<(temp.Length-Subject[ii].ToString().Length)/2;j++)
										{
											Header+=" ";
										}
										Header+="|";
										Header1+=temp;
										Header2+=temp1;
										for(int j=0;j<temp.Length-1;j++)
										{
											desdes+="-";
										}
										desdes+="+";
									}
								}
								for(int ii=0;ii<Subject.Length;ii++)
								{
									string temp="",temp1="";
									if(Subject[ii].ToString().ToUpper()=="MUSIC"||Subject[ii].ToString().ToUpper()=="ART"||Subject[ii].ToString().ToUpper()=="CRAFT"||Subject[ii].ToString().ToUpper()=="PHY_EDU"||Subject[ii].ToString().ToUpper()=="DANCE"||Subject[ii].ToString().ToUpper()=="GK"||Subject[ii].ToString().ToUpper()=="GSTUDIES"||Subject[ii].ToString().ToUpper()=="ART & CRAFT"||Subject[ii].ToString().ToUpper()=="WORK_EXP"||Subject[ii].ToString().ToUpper()=="COMPUTER")//THIS FOR NON SCHOLASTIC
									{
										temp="|Grade";
										temp1="+-----";

										for(int j=0;j<(temp.Length-Subject[ii].ToString().Length-1)/2;j++)
										{
											Header+=" ";
										}
										Header+=GenUtil.TrimLength(Subject[ii].ToString().ToUpper(),5);
										for(int j=0;j<(temp.Length-Subject[ii].ToString().Length)/2;j++)
										{
											Header+=" ";
										}
										Header+="|";
										Header1+=temp;
										Header2+=temp1;
										for(int j=0;j<temp.Length-1;j++)
										{
											desdes+="-";
										}
										desdes+="+";
									}
								}
							}
							Header+="G.Total|Gra|Rank|  Remark  |";
							desdes+="-------+---+----+----------+";
							Header1+="|       |   |    |          |";
							Header2+="+-------+---+----+----------+";
						}
						//else if(DropClass.SelectedIndex >= 2 && DropSec.SelectedIndex!=0)
						else if(DropClass.SelectedIndex >= 5 && DropSec.SelectedIndex!=0)
						{
							Header="|R.No |";
							Header+="Student Name |";
							desdes="+-----+-------------+";
							Header1="                    ";
							Header2="+-----+-------------";
							if(Subject.Length>0)
							{
								for(int ii=0;ii<Subject.Length;ii++)
								{
									string temp="",temp1="";
									if(Subject[ii].ToUpper()!="MUSIC"&&Subject[ii].ToUpper()!="ART"&&Subject[ii].ToUpper()!="CRAFT"&&Subject[ii].ToUpper()!="PHY_EDU"&&Subject[ii].ToUpper()!="DANCE"&&Subject[ii].ToUpper()!="GK"&&Subject[ii].ToUpper()!="GSTUDIES"&&Subject[ii].ToUpper()!="ART_AND_CRAFT"&&Subject[ii].ToUpper()!="WORK_EXP"&&Subject[ii].ToUpper()!="MORAL_SCIENCE"&&Subject[ii].ToUpper()!="MUSIC_AND_DANCE")
									{
										//19.02.09 temp="|UTest|Pr/AS|ITerm|2Term|Anual|Total";
										//19.02.09 temp1="+-----+-----+-----+-----+-----+-----";
										temp="|UTest|Pr/AS|ITerm|2Term|Total";
										temp1="+-----+-----+-----+-----+-----";

										for(int j=0;j<(temp.Length-Subject[ii].ToString().Length-1)/2;j++)
										{
											Header+=" ";
										}
										Header+=Subject[ii].ToString().ToUpper();
										for(int j=0;j<(temp.Length-Subject[ii].ToString().Length)/2;j++)
										{
											Header+=" ";
										}
									
										Header+="|";
										Header1+=temp;
										Header2+=temp1;
										for(int j=0;j<temp.Length-1;j++)
										{
											desdes+="-";
										}
										desdes+="+";
									}
								}
								Header+="G.Total|Gra|Rank|  Remark  |";
								desdes+="-------+---+----+----------+";
								Header1+="|       |   |    |          |";
								Header2+="+-------+---+----+----------+";
							}
							else
							{
								MessageBox.Show("Subject Not Available");
								DropClass.SelectedIndex=0;DropSec.SelectedIndex=0;DropStream.SelectedIndex=0;
								return;
							}						
						}
						//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School,Gwalior",desdes.Length)) ;
						sw.WriteLine(GenUtil.GetCenterAddr("------------------",desdes.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("GREEN SHEET REPORT",desdes.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("------------------",desdes.Length));
						sw.WriteLine(" Class : "+DropClass.SelectedItem.Text+",  Section : "+DropSec .SelectedItem.Text+",  Stream : "+DropStream.SelectedItem.Text);
						//            12345678 12345678901234567890 12345 123456 1234567 1234567890 12345 123456 1234567 1234567890 12345 123456 1234567 1234567890 12345 123456 1234567 1234567890 12345 123456 1234567 1234567890 12345 12345 12345 1234 12345678 1234567
						sw.WriteLine(desdes);
						sw.WriteLine(Header);
						sw.WriteLine(Header1);
						sw.WriteLine(Header2);
						if(i>0)
						{
							for(int p=0;p<i;p++)
							{
								sw.Write("|"+Ist[p,0].ToString());
								for(int i3=0;i3<5-Ist[p,0].ToString().Length;i3++)
								{
									sw.Write(" ");
								}
								sw.Write("|"+GenUtil.TrimLength (Ist[p,1].ToString(),13));//name
								for(int i3=0;i3<=12-Ist[p,1].ToString().Length;i3++)
								{
									sw.Write(" ");
								}
								sw.Write("|");
								PSTotal=0;
								for(int j=0;j<count;j++)
								{
									if((Subject[j].ToUpper()!="MUSIC"&&Subject[j].ToUpper()!="ART"&&Subject[j].ToUpper()!="CRAFT"&&Subject[j].ToUpper()!="PHY_EDU"&&Subject[j].ToUpper()!="DANCE"&&Subject[j].ToUpper()!="GK"&&Subject[j].ToUpper()!="GSTUDIES"&&Subject[j].ToUpper()!="ART_AND_CRAFT"&&Subject[j].ToUpper()!="WORK_EXP"&&Subject[j].ToUpper()!="MORAL_SCIENCE"&&Subject[j].ToUpper()!="MUSIC_AND_DANCE"&&Subject[j].ToUpper()!="COMPUTER")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG"))  //THIS FOR NON SCHOLASTIC
									{
										sw.Write(unit[p,j].ToString());
										PSTotal+=Convert.ToDouble(unit[p,j]);   //add by vikas 19.02.09
										for(int i3=0; i3<5-unit[p,j].ToString().Length;i3++)
										{
											sw.Write(" ");
										}
										sw.Write("|");
										sw.Write(Assgn[p,j].ToString());
										PSTotal+=Convert.ToDouble(Assgn[p,j]);     //add by vikas 19.02.09
										for(int i3=0;i3<5-Assgn[p,j].ToString().Length;i3++)
										{
											sw.Write(" ");
										}
										sw.Write("|");
										sw.Write(Test1[p,j+2].ToString());
										PSTotal+=Convert.ToDouble(Test1[p,j+2]);     //add by vikas 19.02.09
										for(int i3=0;i3<5-Test1[p,j+2].ToString().Length;i3++)
										{
											sw.Write(" ");
										}
										sw.Write("|");
										sw.Write(Test2[p,j].ToString());
										PSTotal+=Convert.ToDouble(Test2[p,j]);     //add by vikas 19.02.09
										for(int i3=0;i3<5-Test2[p,j].ToString().Length;i3++)
										{
											sw.Write(" ");
										}
										if((!(DropClass.SelectedItem.Text=="I" ||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG"))&&DropClass.SelectedIndex>0)
										{
											sw.Write("|");
											sw.Write(Test3[p,j].ToString());
											PSTotal+=Convert.ToDouble(Test3[p,j]);     //add by vikas 19.02.09
											for(int i3=0;i3<5-Test3[p,j].ToString().Length;i3++)
											{
												sw.Write(" ");
											}
										}
										/*else  if(DropClass.SelectedItem.Text=="I" ||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG")
										{
											sw.Write("|");
											sw.Write("-");
											for(int i3=0;i3<4;i3++)
											{
												sw.Write(" ");
											}
										}*/
										sw.Write("|");
										//MessageBox.Show(grade[p,j].ToString());
										sw.Write(grade[p,j].ToString());
										for(int i3=0;i3<5-grade[p,j].ToString().Length;i3++)
										{
											sw.Write(" ");
										}
										sw.Write("|");
									}
									else if(!(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG"))
									{
										sw.Write(unit[p,j].ToString());
										for(int i3=0;i3<5-unit[p,j].ToString().Length;i3++)
										{
											sw.Write(" ");
										}
										sw.Write("|");
										sw.Write(Assgn[p,j].ToString());
										PSTotal+=Convert.ToDouble(Assgn[p,j]);     //add by vikas 19.02.09
										for(int i3=0;i3<5-Assgn[p,j].ToString().Length;i3++)
										{
											sw.Write(" ");
										}
										sw.Write("|");
										sw.Write(Test1[p,j+2].ToString());
										PSTotal+=Convert.ToDouble(Test1[p,j+2]);     //add by vikas 19.02.09
										for(int i3=0;i3<5-Test1[p,j+2].ToString().Length;i3++)
										{
											sw.Write(" ");
										}
										sw.Write("|");
										sw.Write(Test2[p,j].ToString());
										PSTotal+=Convert.ToDouble(Test2[p,j]);     //add by vikas 19.02.09
										for(int i3=0;i3<5-Test2[p,j].ToString().Length;i3++)
										{
											sw.Write(" ");
										}
										if((!(DropClass.SelectedItem.Text=="I" ||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG"))&&DropClass.SelectedIndex>0)
										{
											sw.Write("|");
											sw.Write(Test3[p,j].ToString());
											PSTotal+=Convert.ToDouble(Test3[p,j]);     //add by vikas 19.02.09
											for(int i3=0;i3<5-Test3[p,j].ToString().Length;i3++)
											{
												sw.Write(" ");
											}
										}
										else  if(DropClass.SelectedItem.Text=="I" ||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG")
										{
											sw.Write("|");
											sw.Write("-");
											for(int i3=0;i3<4;i3++)
											{
												sw.Write(" ");
											}
										}
										sw.Write("|");
										sw.Write(grade[p,j].ToString());
										for(int i3=0;i3<5-grade[p,j].ToString().Length;i3++)
										{
											sw.Write(" ");
										}
										sw.Write("|");
									}
								}
								int k=0;
								for(int j=0;j<Subject.Length;j++)
								{
									if(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG")
									{
										if(Subject[j].ToString().ToUpper()=="MUSIC"||Subject[j].ToString().ToUpper()=="ART"||Subject[j].ToString().ToUpper()=="CRAFT"||Subject[j].ToString().ToUpper()=="PHY_EDU"||Subject[j].ToString().ToUpper()=="DANCE"||Subject[j].ToString().ToUpper()=="GK"||Subject[j].ToString().ToUpper()=="GSTUDIES"||Subject[j].ToString().ToUpper()=="ART & CRAFT"||Subject[j].ToString().ToUpper()=="WORK_EXP"||Subject[j].ToString().ToUpper()=="COMPUTER")//THIS FOR NON SCHOLASTIC
										{
											sw.Write(NIst [p,k].ToString());
											PSTotal+=Convert.ToDouble(NIst [p,k]);     //add by vikas 19.02.09
											for(int i3=0;i3<5-NIst[p,k] .ToString().Length;i3++)
											{
												sw.Write(" ");
											}
											sw.Write("|");
											k++;
										}
									}
								}
								//19.02.09 sw.Write(gtotal[p].ToString());
								sw.Write(PSTotal.ToString());
								for(int i3=0;i3<7-gtotal[p].ToString().Length;i3++)
								{
									sw.Write(" ");
								}
								sw.Write("|");
								sw.Write(ggrade[p].ToString());
								for(int i3=0;i3<3-ggrade[p].ToString().Length;i3++)
								{
									sw.Write(" ");
								}
								sw.Write("|");
							
								sw.Write(rank[p].ToString());
								for(int i3=0;i3<4-rank[p].ToString().Length;i3++)
								{
									sw.Write(" ");
								}
								sw.Write("|");
								string rem=Request.Params.Get("txtrem"+p);
								sw.Write(GenUtil.TrimLength (rem.Trim (),10));
								for(int i3=0;i3<10-rem.Trim().Length;i3++)
								{
									sw.Write(" ");
								}
								sw.Write("|");
								sw.WriteLine("");
							}
							sw.WriteLine(Header2);
						}
						else
						{
							MessageBox.Show("Numbers Not Available");
						}
						sw.Close ();
						Print();				
					}
				}
				else
					MessageBox.Show("Please Click Show Button First");
			}
			catch(Exception ex)
			{
				
				CreateLogFiles.ErrorLog("Form:GreenSheetReport,Method: btnprint_Click,GreenSheet Report Printed "+"  EXCEPTION   "+ex.Message+"  userid  ");
				return;
			}
		
		}

		/// <summary>
		/// this method use to create connection between remot device.
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\eschool\\eschoolprintservice\\GreenSheet.txt<EOF>");
					/// Send the data through the socket.http://localhost/eRetail/Forms/Reports/NozzleReport.aspx
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
					CreateLogFiles.ErrorLog("Form:GreenSheetReport,Method: btnprint_Click, EXCEPTION   "+ane.Message+"  userid  ");
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:GreenSheetReport,Method: btnprint_Click, EXCEPTION   "+se.Message+"  userid  ");
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:GreenSheetReport,Method: btnprint_Click, EXCEPTION   "+es.Message+"  userid  ");
				}
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:GreenSheetReport,Method: btnprint_Click,Class:PetrolPumpClass "+" Customerwise Sales Report Printed "+"  EXCEPTION   "+ex.Message+"  userid  ");
			}
		}

		private void DropClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		
		/// <summary>
		/// this method use to call ConvertIntoExcel() function.
		/// </summary>
		private void Btnexcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(View!=0)
				{
					ConvertIntoExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:AdvanceFeesReport.aspx,Method: btnExcel_Click, Advance Fees Report Convert Into Excel Format ,  userid  "+pass);
				}
				else
					MessageBox.Show("Please Click The Show Button First");
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:AdvanceFeesReport.aspx,Method:btnExcel_Click   Advance Fees Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+pass);
			}
		}

		/// <summary>
		/// this method use to create report in excel format. in this method first get subject from classwisesubject table. after that get max marks of every subject and every type of exam from exammarksdecision table and store
		/// in a array. after that get students all type exam markas from studentmarks or studentmarksentryIandII table and save in 2D array. and also check grade and get rank with the help of rank() function.
		/// and store in array.
		/// </summary>
		public void ConvertIntoExcel()
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\GreenSheetReport1.xls";
				//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\GreenSheetReport.txt";
				StreamWriter sw = new StreamWriter(path);
				string info="";
				if(DropClass.SelectedIndex!=0 && DropSec.SelectedIndex!=0)
				{
					InventoryClass obj=new InventoryClass();
					SqlDataReader SqlDtr=null;
					string cls="";
					/*if(DropClass.SelectedItem.Text=="I")
						cls="1";
					else if(DropClass.SelectedItem.Text=="II")
						cls="2";
					else if(DropClass.SelectedItem.Text=="III")
						cls="3";
					else if(DropClass.SelectedItem.Text=="IV")
						cls="4";
					else if(DropClass.SelectedItem.Text=="V")
						cls="5";
					else if(DropClass.SelectedItem.Text=="VI")
						cls="6";
					else if(DropClass.SelectedItem.Text=="VII")
						cls="7";
					else if(DropClass.SelectedItem.Text=="VIII")
						cls="8";
					else if(DropClass.SelectedItem.Text=="IX")
						cls="9";
					else if(DropClass.SelectedItem.Text=="X")
						cls="10";
					else if(DropClass.SelectedItem.Text=="XI")
						cls="11";
					else if(DropClass.SelectedItem.Text=="XII")
						cls="12";*/
				
					if(DropClass.SelectedItem.Text.Equals("Nursery"))
						cls="1";
					else if(DropClass.SelectedItem.Text.Equals("LKG"))
						cls="2";
					else if(DropClass.SelectedItem.Text.Equals("UKG"))
						cls="3";
					else if(DropClass.SelectedItem.Text.Equals("I"))
						cls="4";
					else if(DropClass.SelectedItem.Text.Equals("II"))
						cls="5";
					else if(DropClass.SelectedItem.Text.Equals("III"))
						cls="6";
					else if(DropClass.SelectedItem.Text.Equals("IV"))
						cls="7";
					else if(DropClass.SelectedItem.Text.Equals("V"))
						cls="8";
					else if(DropClass.SelectedItem.Text.Equals("VI"))
						cls="9";
					else if(DropClass.SelectedItem.Text.Equals("VII"))
						cls="10";
					else if(DropClass.SelectedItem.Text.Equals("VIII"))
						cls="11";
					else if(DropClass.SelectedItem.Text.Equals("IX"))
						cls="12";
					else if(DropClass.SelectedItem.Text.Equals("X"))
						cls="13";
					else if(DropClass.SelectedItem.Text.Equals("XI"))
						cls="14";
					else if(DropClass.SelectedItem.Text.Equals("XII"))
						cls="15";

					string Header="";
					string Header1="";
					string Header2="";
					string desdes="";
					if((DropClass.SelectedItem.Text=="I" || DropClass.SelectedItem.Text=="II" || DropClass.SelectedItem.Text=="Nursery" || DropClass.SelectedItem.Text=="LKG" || DropClass.SelectedItem.Text=="UKG")&& DropSec.SelectedIndex!=0)// && DropStream.SelectedIndex!=0)
					{
						Header="R.No \t";
						Header+="Student Name \t";
						//desdes="+-----+-------------+";
						Header1="\t";
						//Header2="+-----+-------------";
						if(Subject.Length>0)
						{
							for(int ii=0;ii<Subject.Length;ii++)
							{
								string temp="",temp1="";
								if(Subject[ii].ToUpper()!="MUSIC"&&Subject[ii].ToUpper()!="ART"&&Subject[ii].ToUpper()!="CRAFT"&&Subject[ii].ToUpper()!="PHY_EDU"&&Subject[ii].ToUpper()!="DANCE"&&Subject[ii].ToUpper()!="GK"&&Subject[ii].ToUpper()!="GSTUDIES"&&Subject[ii].ToUpper()!="ART_AND_CRAFT"&&Subject[ii].ToUpper()!="WORK_EXP"&&Subject[ii].ToUpper()!="MORAL_SCIENCE"&&Subject[ii].ToUpper()!="MUSIC_AND_DANCE"&&Subject[ii].ToUpper()!="COMPUTER")//THIS FOR NON SCHOLASTIC
								{
									//20.02.09 temp="\tUTest\tPr/AS\tITerm\t2Term\tAnual\tTotal";
									temp="\tUTest\tPr/AS\tITerm\t2Term\tOverAll";
									temp1="+-----+-----+-----+-----+-----+-----";
									//20.02.09 for(int j=0;j<(temp.Length-Subject[ii].ToString().Length-1)/2;j++)
									//20.02.09 {
									//20.02.09	Header+=" ";
									//20.02.09 }
									Header+="\t\t"+Subject[ii].ToString().ToUpper()+"\t\t";
									//20.02.09 for(int j=0;j<(temp.Length-Subject[ii].ToString().Length)/2;j++)
									//20.02.09 {
									//20.02.09	Header+=" ";
									//20.02.09 }
									Header+="\t";
									Header1+=temp;
									Header2+=temp1;
									/*20.02.09 for(int j=0;j<temp.Length-1;j++)
									{
										desdes+="-";
									}*/
									desdes+="+";
								}
							}

							for(int ii=0;ii<Subject.Length;ii++)
							{
								string temp="",temp1="";
								if(Subject[ii].ToString().ToUpper()=="MUSIC"||Subject[ii].ToString().ToUpper()=="ART"||Subject[ii].ToString().ToUpper()=="CRAFT"||Subject[ii].ToString().ToUpper()=="PHY_EDU"||Subject[ii].ToString().ToUpper()=="DANCE"||Subject[ii].ToString().ToUpper()=="GK"||Subject[ii].ToString().ToUpper()=="GSTUDIES"||Subject[ii].ToString().ToUpper()=="ART & CRAFT"||Subject[ii].ToString().ToUpper()=="WORK_EXP"||Subject[ii].ToString().ToUpper()=="COMPUTER")//THIS FOR NON SCHOLASTIC
								{
									//20.02.09 temp="\tGrade";
									temp="\t";
									temp1="+-----";

									/* 20.02.09 for(int j=0;j<(temp.Length-Subject[ii].ToString().Length-1)/2;j++)
									{
										Header+=" ";
									}*/
									Header+=GenUtil.TrimLength(Subject[ii].ToString().ToUpper(),5);
									/* 20.02.09 for(int j=0;j<(temp.Length-Subject[ii].ToString().Length)/2;j++)
									{
										Header+=" ";
									}*/
									Header+="\t";
									Header1+=temp;
									Header2+=temp1;
									/*20.02.09 for(int j=0;j<temp.Length-1;j++)
									{
										desdes+="-";
									}*/
									desdes+="+";
								}
							}
						}
						Header+="G.Total\tGra\tRank\tRemark";
						//desdes+="-------+---+----+----------+";
						Header1+="\t\t\t\t";
						
						//Header2+="+-------+---+----+----------+";
					}
					//else if(DropClass.SelectedIndex >= 2 && DropSec.SelectedIndex!=0)
					else if(DropClass.SelectedIndex >= 5 && DropSec.SelectedIndex!=0)
					{
						Header="R.No \t";
						Header+="Student Name\t";
						desdes="+-----+-------------+";
						Header1="                    ";
						Header2="+-----+-------------";
				
						if(Subject.Length>0)
						{
							for(int ii=0;ii<Subject.Length;ii++)
							{
								string temp="",temp1="";
								if(Subject[ii].ToUpper()!="MUSIC"&&Subject[ii].ToUpper()!="ART"&&Subject[ii].ToUpper()!="CRAFT"&&Subject[ii].ToUpper()!="PHY_EDU"&&Subject[ii].ToUpper()!="DANCE"&&Subject[ii].ToUpper()!="GK"&&Subject[ii].ToUpper()!="GSTUDIES"&&Subject[ii].ToUpper()!="ART_AND_CRAFT"&&Subject[ii].ToUpper()!="WORK_EXP"&&Subject[ii].ToUpper()!="MORAL_SCIENCE"&&Subject[ii].ToUpper()!="MUSIC_AND_DANCE")
								{
									temp="\tUTest\tPr/AS\tITerm\t2Term\tOverAll";
									temp1="+-----+-----+-----+-----+-----+-----";

									/* 20.02.09 for(int j=0;j<(temp.Length-Subject[ii].ToString().Length-1)/2;j++)
									{
										Header+=" ";
									}*/
									Header+=Subject[ii].ToString().ToUpper();
									/* 20.02.09 for(int j=0;j<(temp.Length-Subject[ii].ToString().Length)/2;j++)
									{
										Header+=" ";
									}*/
									
									Header+="\t";
									Header1+=temp;
									Header2+=temp1;
									/* 20.02.09 for(int j=0;j<temp.Length-1;j++)
									{
										desdes+="-";
									}*/
									
									desdes+="+";


								}
							}
							Header+="G.Total\tGra\tRank\tRemark ";
							//desdes+="-------+---+----+----------+";
							Header1+="\t\t\t\t";
							//Header2+="+-------+---+----+----------+";
						}
						else
						{
							MessageBox.Show("Subject Not Available");
							DropClass.SelectedIndex=0;
							DropSec.SelectedIndex=0;
							DropStream.SelectedIndex=0;
							return;
						}						
					}
					//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School,Gwalior",desdes.Length)) ;
					sw.WriteLine(GenUtil.GetCenterAddr("------------------",desdes.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("GREEN SHEET REPORT",desdes.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("------------------",desdes.Length));
					sw.WriteLine(" Class : "+DropClass.SelectedItem.Text+",  Section : "+DropSec .SelectedItem.Text+",  Stream : "+DropStream.SelectedItem.Text);
					//             12345678 12345678901234567890 12345 123456 1234567 1234567890 12345 123456 1234567 1234567890 12345 123456 1234567 1234567890 12345 123456 1234567 1234567890 12345 123456 1234567 1234567890 12345 12345 12345 1234 12345678 1234567
					//sw.WriteLine(desdes);
					sw.WriteLine(Header);
					sw.WriteLine(Header1);
					//sw.WriteLine(Header2);
					//sw.WriteLine("R.No\tStudent Name\t");
					
					if(i>0)
					{
						for(int p=0;p<i;p++)
						{
							sw.Write(Ist[p,0].ToString()+"\t");
							/*20.02.09 for(int i3=0;i3<5-Ist[p,0].ToString().Length;i3++)
							{
								sw.Write(" ");
							}*/
							sw.Write(GenUtil.TrimLength (Ist[p,1].ToString(),13));//name
							/*20.02.09 for(int i3=0;i3<=12-Ist[p,1].ToString().Length;i3++)
							{
								sw.Write(" ");
							}*/
							sw.Write("\t");
							PSTotal=0;
							for(int j=0;j<count;j++)
							{
								if((Subject[j].ToUpper()!="MUSIC"&&Subject[j].ToUpper()!="ART"&&Subject[j].ToUpper()!="CRAFT"&&Subject[j].ToUpper()!="PHY_EDU"&&Subject[j].ToUpper()!="DANCE"&&Subject[j].ToUpper()!="GK"&&Subject[j].ToUpper()!="GSTUDIES"&&Subject[j].ToUpper()!="ART_AND_CRAFT"&&Subject[j].ToUpper()!="WORK_EXP"&&Subject[j].ToUpper()!="MORAL_SCIENCE"&&Subject[j].ToUpper()!="MUSIC_AND_DANCE"&&Subject[j].ToUpper()!="COMPUTER")&&(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG"))  //THIS FOR NON SCHOLASTIC
								{
									sw.Write(unit[p,j].ToString());
									PSTotal+=Convert.ToDouble(unit[p,j]);
									/*20.02.09 for(int i3=0;i3<5-unit[p,j].ToString().Length;i3++)
									{
										sw.Write(" ");
									}*/
									sw.Write("\t");
									sw.Write(Assgn[p,j].ToString());
									PSTotal+=Convert.ToDouble(Assgn[p,j]);
									/*20.02.09 for(int i3=0;i3<5-Assgn[p,j].ToString().Length;i3++)
									{
										sw.Write(" ");
									}*/
									sw.Write("\t");
									sw.Write(Test1[p,j+2].ToString());
									PSTotal+=Convert.ToDouble(Test1[p,j+2]);
									/*20.02.09 for(int i3=0;i3<5-Test1[p,j+2].ToString().Length;i3++)
									{
										sw.Write(" ");
									}*/
									sw.Write("\t");
									sw.Write(Test2[p,j].ToString());
									PSTotal+=Convert.ToDouble(Test2[p,j]);
									/*20.02.09 for(int i3=0;i3<5-Test2[p,j].ToString().Length;i3++)
									{
										sw.Write(" ");
									}*/
									if((!(DropClass.SelectedItem.Text=="I" ||DropClass.SelectedItem.Text=="II" ||DropClass.SelectedItem.Text=="Nursery" ||DropClass.SelectedItem.Text=="LKG" ||DropClass.SelectedItem.Text=="UKG"))&&DropClass.SelectedIndex>0)
									{
										sw.Write("\t");
										sw.Write(Test3[p,j].ToString());
										PSTotal+=Convert.ToDouble(Test3[p,j]);
										/*20.02.09 for(int i3=0;i3<5-Test3[p,j].ToString().Length;i3++)
										{
											sw.Write(" ");
										}*/
									}
									/*20.02.09 else if(DropClass.SelectedItem.Text=="I" ||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery" ||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG")
									{
										sw.Write("\t");
										sw.Write("-");
										for(int i3=0;i3<4;i3++)
										{
											sw.Write(" ");
										}
									}*/
									sw.Write("\t");
									sw.Write(grade[p,j].ToString());
									//PSTotal+=Convert.ToDouble(grade[p,j]);
									/*20.02.09 for(int i3=0;i3<5-grade[p,j].ToString().Length;i3++)
									{
										sw.Write(" ");
									}*/
									sw.Write("\t");
								}
								else if(!(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery" ||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG"))
								{
									sw.Write(unit[p,j].ToString());
									PSTotal+=Convert.ToDouble(unit[p,j]);
									/* 20.02.09 for(int i3=0;i3<5-unit[p,j].ToString().Length;i3++)
									{
										sw.Write(" ");
									}*/
									sw.Write("\t");
									sw.Write(Assgn[p,j].ToString());
									PSTotal+=Convert.ToDouble(Assgn[p,j]);
									/*20.02.09 for(int i3=0;i3<5-Assgn[p,j].ToString().Length;i3++)
									{
										sw.Write(" ");
									}*/
									sw.Write("\t");
									sw.Write(Test1[p,j+2].ToString());
									PSTotal+=Convert.ToDouble(Test1[p,j+2]);
									/* 20.02.09 for(int i3=0;i3<5-Test1[p,j+2].ToString().Length;i3++)
									{
										sw.Write(" ");
									}*/
									sw.Write("\t");
									sw.Write(Test2[p,j].ToString());
									PSTotal+=Convert.ToDouble(Test2[p,j]);
									/*20.02.09 for(int i3=0;i3<5-Test2[p,j].ToString().Length;i3++)
									{
										sw.Write(" ");
									}*/
									if((!(DropClass.SelectedItem.Text=="I" ||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery" ||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG"))&&DropClass.SelectedIndex>0)
									{
										sw.Write("\t");
										sw.Write(Test3[p,j].ToString());
										PSTotal+=Convert.ToDouble(Test3[p,j]);
										/* 20.02.09 for(int i3=0;i3<5-Test3[p,j].ToString().Length;i3++)
										{
											sw.Write(" ");
										}*/
									}
									else if(DropClass.SelectedItem.Text=="I" ||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery" ||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG")
									{
										sw.Write("\t");
										sw.Write("-");
										/*20.02.09 for(int i3=0;i3<4;i3++)
										{
											sw.Write(" ");
										}*/
									}
									sw.Write("\t");
									//sw.Write(grade[p,j].ToString());
									/*20.02.09 for(int i3=0;i3<5-grade[p,j].ToString().Length;i3++)
									{
										sw.Write(" ");
									}*/
									sw.Write("\t");
								}
							}
							int k=0;
							for(int j=0;j<Subject.Length;j++)
							{
								
								if(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery" ||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG")
								{
									if(Subject[j].ToString().ToUpper()=="MUSIC"||Subject[j].ToString().ToUpper()=="ART"||Subject[j].ToString().ToUpper()=="CRAFT"||Subject[j].ToString().ToUpper()=="PHY_EDU"||Subject[j].ToString().ToUpper()=="DANCE"||Subject[j].ToString().ToUpper()=="GK"||Subject[j].ToString().ToUpper()=="GSTUDIES"||Subject[j].ToString().ToUpper()=="ART & CRAFT"||Subject[j].ToString().ToUpper()=="WORK_EXP"||Subject[j].ToString().ToUpper()=="COMPUTER")//THIS FOR NON SCHOLASTIC
									{
										sw.Write(NIst[p,k].ToString());
										PSTotal+=Convert.ToDouble(NIst[p,k]);
										/*20.02.09 for(int i3=0;i3<5-NIst[p,k] .ToString().Length;i3++)
										{
											sw.Write(" ");
										}*/
										sw.Write("\t");
										k++;
									}
									
								}
							}

							sw.Write(PSTotal.ToString());
							//20.02.09 sw.Write(gtotal[p].ToString());
							/*20.02.09 for(int i3=0;i3<7-gtotal[p].ToString().Length;i3++)
							{
								sw.Write(" ");
							}*/
							sw.Write("\t");
							sw.Write(ggrade[p].ToString());
							/*20.02.09 for(int i3=0;i3<3-ggrade[p].ToString().Length;i3++)
							{
								sw.Write(" ");
							}*/
							sw.Write("\t");
							
							sw.Write(rank[p].ToString());
							/*20.02.09 for(int i3=0;i3<4-rank[p].ToString().Length;i3++)
							{
								sw.Write(" ");
							}*/
							sw.Write("\t");

							string rem=Request.Params.Get("txtrem"+p);
							
							sw.Write(GenUtil.TrimLength (rem.Trim (),10));
							/*20.02.09 for(int i3=0;i3<10-rem.Trim().Length;i3++)
							{
								sw.Write(" ");
							}*/
							sw.Write("\t");
							sw.WriteLine("");
						}
						//sw.WriteLine(Header2);
					}
					else
					{
						MessageBox.Show("Numbers Not Available");
					}
					sw.Close ();
					//Print();				
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:GreenSheetReport,Method: btnprint_Click,GreenSheet Report Printed "+"  EXCEPTION   "+ex.Message+"  userid  ");
				return;
			}
		}
	}
}
