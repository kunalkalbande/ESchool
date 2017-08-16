

using System;
using System.Data.SqlClient;
using System.Data;


namespace eschool.LibraryClass
{
	/// <summary>
	/// Summary description for DuePaymentClass.
	/// </summary>
	public class DuePaymentClass
	{
        SqlConnection sqcon;
		SqlCommand sqcom;
        
		#region vars & Prop 
		string _PurchaseID;
		string _Payment_Due_ID;
		string _Company_Name;
		string _Due_Payment;
		string _Date_Of_Due;

		public string PurchaseID
		{
			get
			{
				return _PurchaseID;
			}
			set
			{
				_PurchaseID=value;
			}
		}


		
		public string Payment_Due_ID
		{
			get
			{
				return _Payment_Due_ID;
			}
			set
			{
				_Payment_Due_ID=value;
			}
		}
		
		public string Company_Name
		{
			get
			{
				return _Company_Name;
			}
			set
			{
				_Company_Name=value;
			}
		}
		
		public string Due_Payment
		{
			get
			{
				return _Due_Payment;
			}
			set
			{
				_Due_Payment=value;
			}
		}
		
		public string Date_Of_Due
		{
			get
			{
				return _Date_Of_Due;
			}
			set
			{
				_Date_Of_Due=value;
			}
		}
#endregion

		/// <summary>
		/// this method use to create connection between database.
		/// </summary>
		public DuePaymentClass()
		{
			sqcon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			sqcon.Open();
		}

		/// <summary>
		/// this method use to save information with the help of ProInsertDuePayment.
		/// </summary>
		public void InsertDuePayment()
		{ 
		
			sqcom=new SqlCommand("ProInsertDuePayment",sqcon);
			sqcom.CommandType =CommandType.StoredProcedure ;
			sqcom.Parameters .Add("@PurchaseID",PurchaseID);
			sqcom.Parameters .Add("@Payment_Due_ID",Payment_Due_ID);
			sqcom.Parameters.Add("@Company_Name",Company_Name);
			sqcom.Parameters.Add("@Due_Payment",Due_Payment);
			sqcom.Parameters.Add("@Date_Of_Due",Date_Of_Due);
			sqcom.ExecuteNonQuery();

		}
		

	}
}
