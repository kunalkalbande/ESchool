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
using eschool.SchoolClass;
using eschool.Classes;
using RMG;

namespace eschool.Form
{
	/// <summary>
	/// Summary description for BankMaster.
	/// </summary>
	public class BankMaster : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList Dropname;
		protected System.Web.UI.WebControls.TextBox txtbankname;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.TextBox txtBranch;
		protected System.Web.UI.WebControls.Label lblid;
		protected System.Web.UI.WebControls.Button btnDelete;
		string pass;
		/// <summary>
		/// Page Load...
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				
				pass=(Session["password"].ToString ());
				# region Dropdown ClassName
				if(!Page.IsPostBack)
				{	
					fillID();
					nextID();
				}
				# endregion
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error"+ex.Message);
				CreateLogFiles.ErrorLog ("Form: BankMaster.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			if(! IsPostBack)
			{
				btnSave.Visible=true;
				btnDelete.Visible=true;
				btnEdit.Visible=true;
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="2";
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
				if(Add_Flag=="False"&&Edit_Flag=="False"&&Del_Flag=="False"&&View_flag=="False")
				{
					Response.Redirect("/eschool/AccessDeny.aspx",false);
				}
				if(Add_Flag=="False")
				{
					btnSave.Enabled=false;
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
			this.Dropname.SelectedIndexChanged += new System.EventHandler(this.Dropname_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		/// <summary>
		/// Clear Function... For clearing the records in controls.
		/// </summary>
	    public void Clear()
	     {
		   txtbankname.Text="";
		   Dropname.SelectedIndex=0;
		   txtBranch.Text="";
		   nextID();
	     }
		/// <summary>
		/// Fill Bank Id.
		/// </summary>
		public void fillID()
		{
			SqlConnection con;
			SqlCommand cmdselect;
			SqlDataReader dtrdrive;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				cmdselect = new SqlCommand( "Select distinct bankid, bankname  From Bankinfo order by bankid asc", con );
				dtrdrive = cmdselect.ExecuteReader();
				Dropname.Items.Clear ();  
				Dropname.Items .Add ("Select"); 
				while (dtrdrive.Read()) 
				{
					Dropname.Items.Add(dtrdrive.GetValue(0)+":"+dtrdrive.GetString(1));
				}
				dtrdrive.Close();
				con.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: BankMaster.aspx.cs, Method: FillId. Exception: " + ex.Message + " User: " + pass );

			}
		}
		/// <summary>
		/// Save The Bank Information.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			
			try
			{
				if(txtbankname.Text=="")
				{
					MessageBox.Show("Please Enter the Bank Name ");
					return;
				}
				else
				{
					string sBank=txtbankname.Text;
					string sBranch=txtBranch.Text;
		
					SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					scon.Open();
					SqlCommand scom=new SqlCommand("Select Count(Bankname) from BankInfo where bankname='" + sBank.ToUpper() +"' and  banklocation='"+sBranch.ToUpper()+"'",scon);
					SqlDataReader sdtr=scom.ExecuteReader();
					int iCount=0;
					while(sdtr.Read())
					{
						iCount=Convert.ToInt32(sdtr.GetSqlValue(0).ToString());
					}
					if(iCount==0)														//check whether inserted subject already in database.
					{
						SqlConnection con;
						string strInsert;
						SqlCommand cmdInsert;
						con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						con.Open ();
						fillID();
						strInsert = "Insert into  BankInfo values (@Bankid,@Bankname,@BankLocation)";
						cmdInsert=new SqlCommand (strInsert,con);
						cmdInsert.Parameters .Add ("@Bankid",lblid.Text);
						if(txtbankname.Text=="")
							cmdInsert.Parameters .Add ("@Bankname","");
						else
							cmdInsert.Parameters .Add ("@Bankname",txtbankname.Text.Trim().ToUpper());
						if(txtBranch.Text=="")
							cmdInsert.Parameters .Add ("@BankLocation","");
						else
							cmdInsert.Parameters .Add ("@BankLocation",txtBranch.Text.Trim().ToUpper());
						int i=0;
						i=cmdInsert.ExecuteNonQuery();
						con.Close ();
						if(i>0)
						{
							LedgerCreation();
							MessageBox.Show(" New Bank Inserted Successfully ");
						}
					
						CreateLogFiles.ErrorLog ("Form: BankMaster.aspx.cs, Method: btnSave_Click. New Bank: " + txtbankname.Text.Trim().ToUpper() + " is saved. User: " + pass );
						Clear();
						btnSave.Visible=true;
						btnDelete.Visible=true;
						btnEdit.Visible=true;
						fillID();
						
					}
					else
					{
						MessageBox.Show("This Bank Name Already Exists");
						return;
					}
					scon.Close();
				}
			}
			catch(Exception ex)
			{
				   CreateLogFiles.ErrorLog ("Form: BankMaster.aspx.cs, Method: FillId. Exception: " + ex.Message + " User: " + pass );
			}
		}

		public void LedgerCreation()
		{
			try
			{
				nextLedgerid();
				SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon.Open();
				SqlCommand scom=new SqlCommand();
				scom.CommandType=CommandType.StoredProcedure;
				scom.CommandText="BankLedgerCreation";
				scom.Connection=scon;
				scom.Parameters.Add("@Ledger_Id",Convert.ToInt32(nextLedgerid()));
				scom.Parameters.Add("@Ledger_name",txtbankname.Text.Trim());
				scom.Parameters.Add("@Balance_Type","Dr");
				scom.Parameters.Add("@Op_Balance","0");
				scom.ExecuteNonQuery();
				scon.Close();
			}
			catch(Exception ex)
			{

			}
		}

		string ledger_id="0";
		public string nextLedgerid()
		{
			try
			{
				SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon.Open();
				string str="Select max(Ledger_id)+1 from Ledger_Master";
				SqlCommand scom=new SqlCommand(str,scon);
				SqlDataReader sdtr=scom.ExecuteReader();
				if(sdtr.HasRows)
				{
					while(sdtr.Read())
					{
						ledger_id=sdtr.GetValue(0).ToString();
						if(ledger_id.Trim().Equals(""))
						{
							ledger_id="1001";
						}
                    }
				}
				scom.Dispose();
				sdtr.Close();
				scon.Close();
				return ledger_id;
			}
			catch(Exception ex)
			{
				return ledger_id;
			}
		}

		/// <summary>
		/// Generated Next id For Bank Master.
		/// </summary>
		void nextID()
		{
			SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			scon.Open();
			SqlCommand scom=new SqlCommand("Select max(bankid) from BankInfo",scon);
			SqlDataReader sdtr=scom.ExecuteReader();
			string id="";
			if(sdtr.Read())
			{
				if(!sdtr.GetSqlValue(0).ToString().Equals("Null"))
				{
					if(!sdtr.GetSqlValue(0).ToString().Equals(""))
						id=Convert.ToString((Convert.ToInt32(sdtr.GetSqlValue(0).ToString())+1));
					else
						id="0";
				}
				else
				{
					id="1";
				}
			}
			else
			{
				id="1";
			}
			lblid.Text=id.ToString().Trim();
			sdtr.Close();
		}
		/// <summary>
		/// Update The Bank Information.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			SqlConnection con2;
			SqlCommand cmdselect2;
			SqlDataReader dtredit2;
			string strUpdate;
			try
			{
				if(txtbankname.Text.Trim()=="")
				{
					MessageBox.Show("Blank record can not be inserted");
				}
				else
				{
					con2=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con2.Open ();
					strUpdate = "Update  BankInfo set bankname=@bankname,banklocation=@branch  where bankid='"+lblid.Text+"'";
     				cmdselect2 = new SqlCommand( strUpdate, con2);
					if (txtbankname.Text=="")
						cmdselect2.Parameters .Add ("@bankname","");
					else
						cmdselect2.Parameters .Add ("@bankname",txtbankname.Text.Trim().ToUpper());
					if (txtBranch.Text=="")
						cmdselect2.Parameters .Add ("@branch","");
					else
						cmdselect2.Parameters .Add ("@branch",txtBranch.Text.Trim().ToUpper());
					dtredit2 = cmdselect2.ExecuteReader();

					updateleder();

					con2.Close();
					MessageBox.Show("Bank name Updated ");
					btnSave.Visible=true;
					btnDelete.Visible=true;
					btnEdit.Visible=true;
					CreateLogFiles.ErrorLog ("Form: BankMaster.aspx.cs, Method: btnSEdit_Click. Class: " + Dropname.SelectedItem.ToString () + " updated. User: " + pass ); 
					Clear();
					fillID();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: BankMaster.aspx.cs, Method: btnSEdit_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This function use to update ledger.
		/// </summary>
		public void updateleder()
		{
			SqlConnection con2;
			SqlCommand cmdselect2;
			SqlDataReader dtredit2;
			string strUpdate;
			string ledger_id="",ledgername="";
			ledgername=Dropname.SelectedItem.Value.ToString().Trim();
			string[] ledgernam=ledgername.Split(new char[]{':'});
			con2=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			con2.Open ();

			strUpdate = "Select Ledger_id from Ledger_Master where ledger_Name='"+ledgernam[1].ToString().Trim()+"'";
			cmdselect2 = new SqlCommand( strUpdate, con2);
			dtredit2 = cmdselect2.ExecuteReader();
			while(dtredit2.Read())
			{
				ledger_id=dtredit2.GetValue(0).ToString();
			}
            cmdselect2.Dispose();
			dtredit2.Close();

			strUpdate = "Update  Ledger_Master set Ledger_Name=@bankname where ledger_Id='"+ledger_id.ToString().Trim()+"'";
			cmdselect2 = new SqlCommand( strUpdate, con2);
			if (txtbankname.Text=="")
				cmdselect2.Parameters .Add ("@bankname"," ");
			else
				cmdselect2.Parameters .Add ("@bankname",txtbankname.Text.Trim().ToUpper());
			
			cmdselect2.ExecuteNonQuery();
			cmdselect2.Dispose();
			con2.Close();
		}
		/// <summary>
		/// Fetch All Bank Detail From DataBase
		/// </summary>
		private void Dropname_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(Dropname.SelectedIndex==0)
				{
				}
				else
				{
					string name=Dropname.SelectedItem.Text.ToString().Trim();
					lblid.Text=name.Substring(0,name.IndexOf(":"));
					txtbankname.Text=name.Substring(name.IndexOf(":")+1,(name.Length-name.IndexOf(":")-1));
					SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					scon.Open();
					SqlCommand scom=new SqlCommand("Select banklocation from BankInfo where bankid='"+lblid.Text+"'",scon);
					SqlDataReader sdtr=scom.ExecuteReader();
					if(sdtr.Read())
					{
							if(!sdtr.GetString(0).Trim().Equals(""))
							txtBranch.Text=sdtr.GetString(0).Trim();
					}
					else
							txtBranch.Text="";
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: BankMaster.aspx.cs, Method:Dropname_SelectedIndexChanged . Exception: " + ex.Message + " User: " + pass );
			}
		}
		#region 

			/// <summary>
			/// Delete Button...For deleting the Bank name.
			/// </summary>
			private void btnDelete_Click(object sender, System.EventArgs e)
			{
				SqlConnection con10;
				SqlCommand cmdselect10;
				SqlDataReader dtredit10;
				string strdelete10;
				try
				{
					Dropname.Visible=true;
					if(Dropname.SelectedIndex==0)
					{
						MessageBox.Show("Please select the Bank id and name to be deleted");
					}
					else
					{
						string name=Dropname.SelectedItem.Text.ToString().Trim();
						string id=name.Substring(0,name.IndexOf(":"));
						con10=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						con10.Open ();
						strdelete10 = "Delete from BankInfo where bankid ='"+id+"'";
						cmdselect10 = new SqlCommand( strdelete10, con10);
						dtredit10 = cmdselect10.ExecuteReader();
						con10.Close();
						MessageBox.Show("Bank Deleted");
						CreateLogFiles.ErrorLog ("Form: BankMaster.aspx.cs, Method: btnDelete_Click. Bank: " + Dropname.SelectedItem.ToString () + " deleted. User: " + Session["password"].ToString() ); 
						Clear();
						btnSave.Visible=true;
						btnDelete.Visible=true;
						btnEdit.Visible=true;
						fillID();
					}
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog ("Form: BankMaster.aspx.cs, Method: btnDelete_Click. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
				}
			}
		# endregion
	}
}
