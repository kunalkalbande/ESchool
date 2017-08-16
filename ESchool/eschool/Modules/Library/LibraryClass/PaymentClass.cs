
/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/

using System;
using System.Data.SqlClient;
using System.Data;
namespace eschool.LibraryClass
{
	/// <summary>
	/// Summary description for PaymentClass.
	/// </summary>
	public class PaymentClass
	{
		
		SqlConnection sqcon;
	
	
		SqlDataAdapter sqdr;
		DataSet ds;
	
		
        
		#region vars & Prop 
		string _PurchaseID;
		string _PaymentID;
		string _Company_Name;
		string _Mode_Of_Payment;
		string _Payment_Rupees;
		string _Date_Of_Payment;
		public string Payment_Rupees
		{
			get
			{
				return _Payment_Rupees;
			}
			set
			{
				_Payment_Rupees=value;
			}
		}

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


		
		public string PaymentID
		{
			get
			{
			return _PaymentID;
		}
			set
			{
				_PaymentID=value;
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
		
		public string Mode_Of_Payment
		{
			get
			{
				return _Mode_Of_Payment;
			}
			set
			{
				_Mode_Of_Payment=value;
			}
		}
		
		public string Date_Of_Payment
		{
			get
			{
				return _Date_Of_Payment;
			}
			set
			{
				_Date_Of_Payment=value;
			}
		}
#endregion

		/// <summary>
		/// this method use to create a connection between database.
		/// </summary>
		public PaymentClass()
		{
			sqcon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			sqcon.Open();
		}

		/// <summary>
		/// this method use to Show Payment Information in Grid
		/// </summary>
		public DataSet ShowPaymentInformation()
		{
			sqdr=new SqlDataAdapter("ShowPaymentInformation",sqcon);
			ds=new DataSet();
			sqdr.Fill(ds);
			sqcon.Close();
			sqcon.Dispose();
			return ds;

		}

		/// <summary>
		/// this method use to Show Due Payment Information in Grid	
		/// </summary>
		public DataSet ShowDataDuePaymentInformation()
		{
			sqdr=new SqlDataAdapter("ShowDuePaymentInformation",sqcon);
			ds=new DataSet();
			sqdr.Fill(ds);
			sqcon.Close();
			sqcon.Dispose();
			return ds;
		}
		
		
	}
}


