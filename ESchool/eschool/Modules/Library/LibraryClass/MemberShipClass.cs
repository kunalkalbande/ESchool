/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/


using System;
using System.Data .SqlClient;
using System.Data;

namespace eschool.LibraryClass
{
	// 
	/// Summary description for MemberShipClass.
	/// </summary>
	public class MemberShipClass
	{
		SqlConnection sqcon;
		SqlCommand sqcom;
		SqlDataAdapter sqdr;
		SqlDataReader sqred;
		DataSet ds;

		#region Var & Prop
		string _CandidateID;
		string _First_Name;
		string _Middle_Name;
		string _Last_Name;
		string _Per_Address;
		string _Local_Address;
		string _City;
		string _PinCode;
		string _Phone_Number;
		string _EMail_ID;
		string _Date_OF_Birth;
		string _Course;
		string _Age;
		string _Gender;
		string _Father_Name;
		string _Mother_Name;
		string _marital_Status;
		string _desig;
		string _sclass;
        
		public string desig
		{
			get
			{
				return _desig;
			}
			set
			{
				_desig=value;
			}
		}
		public string sclass
		{
			get
			{
				return _sclass;
			}
			set
			{
				_sclass=value;
			}
		}
		public string CandidateID
		{
			get
			{
				return _CandidateID;
			}
			set
			{
				_CandidateID=value;
			}
		}
		public string First_Name
		{
			get
			{
				return _First_Name;
			}
			set
			{
				_First_Name=value;
			}
		}


		public string Middle_Name
		{
			get
			{
				return _Middle_Name;
			}
			set
			{
				_Middle_Name=value;
			}
		}
		public string Last_Name
		{
			get
			{
				return _Last_Name;
			}
			set
			{
				_Last_Name=value;
			}
		}

		public string Per_Address
		{
			get
			{
				return _Per_Address;
			}
			set
			{
				_Per_Address=value;
			}
		}
		public string Local_Address
		{
			get
			{
				return _Local_Address;
			}
			set
			{
				_Local_Address=value;
			}
		}

		public string City
		{
			get
			{
				return _City;
			}
			set
			{
				_City=value;
			}
		}
		public string PinCode
		{
			get
			{
				return _PinCode;
			}
			set
			{
				_PinCode=value;
			}
		}

		public string Phone_Number
		{
			get
			{
				return _Phone_Number;
			}
			set
			{
				_Phone_Number=value;
			}
		}
		public string EMail_ID
		{
			get
			{
				return _EMail_ID;
			}
			set
			{
				_EMail_ID=value;
			}
		}

		public string Date_OF_Birth
		{
			get
			{
				return _Date_OF_Birth;
			}
			set
			{
				_Date_OF_Birth=value;
			}
		}
		public string Course
		{
			get
			{
				return _Course;
			}
			set
			{
				_Course=value;
			}
		}

		public string Age
		{
			get
			{
				return _Age;
			}
			set
			{
				_Age=value;
			}
		}
		public string Gender
		{
			get
			{
				return _Gender;
			}
			set
			{
				_Gender=value;
			}
		}
		public string Father_Name
		{
			get
			{
				return _Father_Name;
			}
			set
			{
				_Father_Name=value;
			}
		}

		public string Mother_Name
		{
			get
			{
				return _Mother_Name;
			}
			set
			{
				_Mother_Name=value;
			}
		}

		public string marital_Status
		{
			get
			{
				return _marital_Status;
			}
			set
			{
				_marital_Status=value;
			}
		}

		
		
		#endregion

		/// <summary>
		/// this ethod use to create connection between database.
		/// </summary>
		public MemberShipClass()
		{
			sqcon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			sqcon.Open();
		}

		#region For insert New Member  

		/// <summary>
		/// this method use to insert data with the help of 'proInsertMember' procedure.
		/// </summary>
        public void InsertMember()
		{ 
			sqcom=new SqlCommand("proInsertMember",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure ;
            sqcom.Parameters .Add("@CandidateID",CandidateID);
			sqcom.Parameters .Add("@First_Name",First_Name );
			sqcom.Parameters .Add ("@Middle_Name",Middle_Name );
			sqcom.Parameters.Add("@Last_Name",Last_Name );
			sqcom.Parameters .Add("@Per_Address",Per_Address );
			sqcom.Parameters .Add("@Local_Address",Local_Address);
			sqcom.Parameters .Add("@City",City );
			sqcom.Parameters .Add("@PinCode",PinCode );
			sqcom.Parameters .Add("@Phone_Number",Phone_Number);
			sqcom.Parameters .Add("@EMail_ID",EMail_ID);
			sqcom.Parameters .Add("@Date_OF_Birth",Date_OF_Birth);
			sqcom.Parameters .Add("@Course",Course);
			sqcom.Parameters .Add("@Age",Age);
			sqcom.Parameters .Add("@Gender",Gender );
			sqcom.Parameters.Add("@Father_Name",Father_Name);
			sqcom.Parameters .Add("@Mother_Name",Mother_Name);
			sqcom.Parameters .Add("@marital_Status",marital_Status);
			sqcom.ExecuteNonQuery();
		}
		#endregion

		#region For Show Member Information

		/// <summary>
		/// this method use to get data with the help of 'proshowinformation' procedure.
		/// </summary>
		public DataSet ShowMemberInformation()
		{
			sqdr=new SqlDataAdapter("proShowInformation",sqcon);
			ds=new DataSet();
			sqdr.Fill(ds);
			sqcon.Close();
			sqcon.Dispose();
			return ds;
		}
		#endregion	

		/// <summary>
		/// For Auto Generated Candidate ID And auto Increments
		/// </summary>
		public SqlDataReader  getCandidateID()
		{
			sqcom=new SqlCommand ("select max(candidateID)+1 from membership",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}
	}
}