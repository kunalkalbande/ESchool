
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
# endregion

namespace eschool.Hostel
{
	/// <summary>
	/// Summary description for Room_mast.
	/// </summary>
	public class Room_mast : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtroomno;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.ValidationSummary vsRoomMaster;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtincharge;
		protected System.Web.UI.WebControls.ListBox listtotal;
		protected System.Web.UI.WebControls.ListBox Listdefective;
		protected System.Web.UI.WebControls.Button btntodef;
		protected System.Web.UI.WebControls.TextBox txtnobeds;
		protected System.Web.UI.WebControls.Button btnBedID;
		protected System.Web.UI.WebControls.Button btntotoal;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Label lblbedid;
		protected System.Web.UI.WebControls.DropDownList DropEdit;
        string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// also Generated Next LedgerID.
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
				CreateLogFiles.ErrorLog (" Form : Room_Master.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				//string pass;
				//pass=(Session["password"].ToString ());
				CreateLogFiles.ErrorLog(" Form : Room_mast.aspx.cs,Method : Page_Load, Userid :  " + pass   );
				
				if(! IsPostBack)
				{
					btnBedID.Enabled =false;
					DropEdit.Visible =false;
			 	 
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="9";
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
					if(Add_Flag=="False"&&Edit_Flag=="False"&&Del_Flag=="False"&&View_flag=="False")
					{
						Response.Redirect("/eschool/AccessDeny.aspx",false);
					}
					if(Add_Flag=="False")
					{
						btnSave.Enabled=false;
					}
					GetNextBEDID();
					#endregion
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Room_mast.aspx.cs,Method : Page_Load  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}
		
		/// <summary>
		/// this method use to get next id from room_mast table.
		/// </summary>
		public void GetNextBEDID()
		{
			SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
			SqlDataReader SqlDtr;
			string sql;
			try
			{
				
				sql="select max(BED_ID)+1 from Room_mast";
				SqlDtr =obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					lblbedid.Text=SqlDtr.GetSqlValue(0).ToString ();
					if (lblbedid.Text=="Null")
						lblbedid.Text ="1";
				}		
				SqlDtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :Room_mast.aspx,Method  GetNextBEDID,  Exception: "+ex.Message+" , Userid :  "+ Session["Password"].ToString()   );		
 
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
			this.DropEdit.SelectedIndexChanged += new System.EventHandler(this.DropEdit_SelectedIndexChanged);
			this.txtnobeds.TextChanged += new System.EventHandler(this.txtnobeds_TextChanged);
			this.btnBedID.Click += new System.EventHandler(this.btnBedID_Click);
			this.btntodef.Click += new System.EventHandler(this.btntodef_Click);
			this.btntotoal.Click += new System.EventHandler(this.btntotoal_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method use to Clear page.
		/// </summary>
		public void Clear()
		{
			txtroomno.Text="";
            listtotal.Items.Clear();
			Listdefective.Items.Clear();
			txtnobeds.Text="";
			txtincharge.Text ="";
		}
	
		/// <summary>
		/// this method use to Clear page.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			Clear();
		}

		/// <summary>
		/// This method use to save alloted bed information in to room_mast and tbed table. and also update the information of allocated bed in both table.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			int i=0;
			string msg="";
			try
			{
				if(listtotal.Items.Count==0)
				{
					MessageBox.Show ("First Click the Get Bed IDs button");
					return;
				}
				SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
				SqlDataReader SqlDtr;
				if(btnSave.Text.Equals("Save"))
				{
					string sql="select * from Room_mast";
					SqlDtr =obj.GetRecordSet(sql);
					string rno="";
					if(SqlDtr.HasRows )
					{
						while(SqlDtr.Read())
						{
							rno=SqlDtr.GetValue(1).ToString();
							if(rno.Equals(txtroomno.Text))
							{
								MessageBox.Show ("Room Details Already Exist");
								Clear(); 
								return;
							}
						}
					}
				}
				SqlConnection con4;
				SqlCommand cmdInsert4;
				string strInsert4=null;
				con4=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con4.Open ();
				if(btnSave.Text.Equals ("Save"))
				{
					strInsert4 = "Insert Room_mast(bed_id,Roomno,No_of_beds,Defective_beds,room_incharge)values (@bedid,@Roomno,@No_of_beds,@Defective_beds,@incharge)";
					msg="Saved.";
					cmdInsert4=new SqlCommand (strInsert4,con4);
					cmdInsert4.Parameters .Add ("@bedid",lblbedid.Text.ToString ().Trim ());
				}
				else
				{
					strInsert4="update Room_mast set bed_id=@bedid,roomno=@roomno,no_of_beds=@no_of_beds,defective_beds=@Defective_beds,room_incharge=@incharge where bed_id='" + DropEdit.SelectedItem.Value .ToString () + "'";
					msg="Updated.";
					cmdInsert4=new SqlCommand (strInsert4,con4);
					cmdInsert4.Parameters .Add ("@bedid",DropEdit.SelectedItem.Value .ToString ());
				}
				if(txtroomno .Text=="")
					cmdInsert4.Parameters .Add ("@Roomno","");
				else
					cmdInsert4.Parameters .Add ("@Roomno",txtroomno.Text.Trim().ToUpper());
				if(txtnobeds .Text=="")
					cmdInsert4.Parameters .Add ("@No_of_beds","");
				else
					cmdInsert4.Parameters .Add ("@No_of_beds",txtnobeds.Text.Trim().ToUpper());
				cmdInsert4.Parameters .Add ("@Defective_beds",Listdefective.Items.Count);
				if(txtincharge .Text=="")
					cmdInsert4.Parameters .Add ("@incharge","");
				else
					cmdInsert4.Parameters .Add ("@incharge",txtincharge.Text.ToUpper());
				i = cmdInsert4.ExecuteNonQuery();
				MessageBox.Show ("Room details " + msg);
				if(i>0)
				{
					int total =  listtotal.Items.Count;
					for(int j=0;j<=total-1;j++)
					{
						string bedno1=listtotal.Items[j].Text.ToString();
						if(msg.ToString().Equals ("Saved.")) 
						{
							strInsert4 = "Insert tbed(bed_id,bed_no,roomno,allocated)values (@bedid,@bedno,@roomno,'N')";
							cmdInsert4=new SqlCommand (strInsert4,con4);
							cmdInsert4.Parameters.Add("@bedid",lblbedid.Text.ToString());
						}
						else
						{
							strInsert4 = "update tbed set bed_id=@bedid,bed_no=@bedno,roomno=@roomno,allocated='N' where bed_id='" + DropEdit.SelectedItem.Value .ToString () + "' and bed_no='" + listtotal.Items[j].Text.ToString()+ "'";
							cmdInsert4=new SqlCommand (strInsert4,con4);
							cmdInsert4.Parameters.Add("@bedid",DropEdit.SelectedItem.Value.ToString());
						}
						cmdInsert4.Parameters.Add("@bedno",listtotal.Items[j].Text.ToString());
						cmdInsert4.Parameters.Add("@roomno",txtroomno.Text.ToString().Trim());
						cmdInsert4.ExecuteNonQuery();
					}
					int def =  Listdefective.Items.Count;
					for(int j=0;j<=def-1;j++)
					{
						string bedno1=Listdefective.Items[j].Text.ToString();
						if(msg.ToString().Equals ("Saved.")) 
						{
							strInsert4 = "Insert tbed(bed_id,bed_no,roomno,allocated)values (@bedid,@bedno,@roomno,'Defective')";
							cmdInsert4=new SqlCommand (strInsert4,con4);
							cmdInsert4.Parameters.Add("@bedid",lblbedid.Text.ToString());
						}
						else
						{
							strInsert4 = "update tbed set bed_id=@bedid,bed_no=@bedno,roomno=@roomno,allocated='Defective' where bed_id='" + DropEdit.SelectedItem.Value .ToString () + "' and bed_no='" + Listdefective.Items[j].Text.ToString() + "'";
							cmdInsert4=new SqlCommand (strInsert4,con4);
							cmdInsert4.Parameters.Add("@bedid",DropEdit.SelectedItem.Value.ToString());
						}
						cmdInsert4.Parameters.Add("@bedno",Listdefective.Items[j].Text.ToString());
						cmdInsert4.Parameters.Add("@roomno",txtroomno.Text.ToString().Trim());
						cmdInsert4.ExecuteNonQuery();
					}
				}
				con4.Close ();
				CreateLogFiles.ErrorLog(" Form : Room_mast.aspx.cs,Method : btnSave_Click  , Record Saved for Room No:"+ txtroomno.Text.Trim().ToUpper() +",      Userid :  " + pass   );
				GetNextBEDID();
				btnSave.Text="Save";
				btnEdit.Visible =true;
				DropEdit.Visible =false;
				lblbedid.Visible =true;
				btnBedID.Enabled=false;
				Clear();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Room_mast.aspx.cs,Method : btnSave_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void Textbox1_TextChanged(object sender, System.EventArgs e)
		{
			listtotal.Items.Clear();
			for(int i=1;i<=int.Parse(txtnobeds.Text.Trim());i++)
			{
				listtotal.Items.Add(i.ToString());
			}
		}

		/// <summary>
		/// this method use to Add selected bed id in defective List Box.
		/// </summary>
		private void btntodef_Click(object sender, System.EventArgs e)
		{
			try
			{
				string add="";
				add=listtotal.SelectedItem.Text.ToString();
				Listdefective.Items.Add(add);  
				listtotal.Items.Remove(add);
			}
			catch(Exception ex)
			{
					CreateLogFiles.ErrorLog(" Form : Room_mast.aspx.cs,Method : btnSave_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}

		/// <summary>
		/// this method use to Add selected bed id in Total List Box.
		/// </summary>
		private void btntotoal_Click(object sender, System.EventArgs e)
		{
			try
			{
				string add="";
				add=Listdefective.SelectedItem.Text.ToString();
				listtotal.Items.Add (add);  
				Listdefective.Items.Remove(add);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Room_mast.aspx.cs,Method : btnSave_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}

		/// <summary>
		/// this method use to enabled button.
		/// </summary>
		private void txtnobeds_TextChanged(object sender, System.EventArgs e)
		{
			btnBedID.Enabled =true;
		}

		/// <summary>
		/// this method use to add total bed id in to listbox.
		/// </summary>
		private void btnBedID_Click(object sender, System.EventArgs e)
		{
			listtotal.Items.Clear();
			for(int i=1;i<=int.Parse(txtnobeds.Text.Trim());i++)
			{
				listtotal.Items.Add(i.ToString());
			}
		}

		/// <summary>
		/// this method use to fill dropedit data fetch from room_mast table. 
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			btnSave.Text ="Update";
			btnEdit.Visible =false;
			lblbedid.Visible =false;
			DropEdit.Visible =true;
			SqlConnection con4;
			SqlCommand cmdInsert4;
			SqlDataReader sdr=null; 
			try
			{
				con4=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con4.Open ();
				cmdInsert4=new SqlCommand ("select * from room_mast order by bed_id",con4); 
				sdr=cmdInsert4.ExecuteReader ();
				DropEdit.Items .Clear ();
				DropEdit.Items .Add ("---Select---");
				if(sdr.HasRows )
				{
					while(sdr.Read ())
					{
						DropEdit.Items.Add (sdr.GetValue (0).ToString ());
					}
				}
				sdr.Close ();
				con4.Close ();
				CreateLogFiles.ErrorLog(" Form : Room_mast.aspx.cs,Method : btnEdit_Click, Userid :  " + pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Room_mast.aspx.cs,Method : btnEdit_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}

		/// <summary>
		/// this method use to show the data in the form by control data fetch from room_mast table.
		/// </summary>
		private void DropEdit_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SqlConnection con4;
			SqlCommand cmdInsert4;
			SqlDataReader sdr=null; 
			try
			{
				con4=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con4.Open ();
				cmdInsert4=new SqlCommand ("select * from room_mast where bed_id='" + DropEdit.SelectedItem.Value .ToString () + "'",con4); 
                sdr=cmdInsert4.ExecuteReader ();
				if(sdr.HasRows )
				{
					while(sdr.Read ())
					{
						txtroomno.Text=sdr.GetValue (1).ToString ();
						txtincharge.Text=sdr.GetValue (3).ToString ();
						txtnobeds.Text =sdr.GetValue (2).ToString (); 
					}
				}
				sdr.Close ();
				cmdInsert4=new SqlCommand ("select * from tbed where bed_id='" + DropEdit.SelectedItem.Value .ToString () + "' and allocated<>'Y' order by bed_no",con4); 
				sdr=cmdInsert4.ExecuteReader ();
				listtotal.Items.Clear ();
				Listdefective.Items .Clear ();
				if(sdr.HasRows )
				{
					while(sdr.Read ())
					{
						if(sdr.GetValue (4).ToString().Equals ("Defective "))
							Listdefective.Items.Add (sdr.GetValue (1).ToString ());
						else
							listtotal.Items .Add (sdr.GetValue (1).ToString ());
					}
				}
				sdr.Close ();
				con4.Close (); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Room_mast.aspx.cs,Method : DropEdit_SelectedIndexChanged  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}

		/// <summary>
		/// This method use to delete the a particular record from room_mast table and also from tbed table.
		/// </summary>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			SqlConnection con4;
			SqlCommand cmdInsert4;
			try
			{
				con4=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con4.Open ();
				cmdInsert4=new SqlCommand ("delete from room_mast where bed_id='" + DropEdit.SelectedItem.Value .ToString () + "'",con4); 
				cmdInsert4.ExecuteNonQuery();
				cmdInsert4=new SqlCommand ("delete from tbed where bed_id='" + DropEdit.SelectedItem.Value .ToString () + "'",con4); 
				cmdInsert4.ExecuteNonQuery();
				MessageBox.Show ("Room details deleted");
				con4.Close (); 
				CreateLogFiles.ErrorLog(" Form : Room_mast.aspx.cs,Method : btnDelete_Click, Userid :  " + pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Room_mast.aspx.cs,Method : btnDelete_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}
	}
}
