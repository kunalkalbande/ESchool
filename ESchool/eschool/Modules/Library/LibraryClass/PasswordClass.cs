
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
	/// Summary description for PasswordClass.
	/// </summary>
	public class PasswordClass
	{

		
		SqlConnection sqcon;
		SqlCommand sqcom;
		SqlDataReader sqdr;
	

		#region vars & Prop
		string u_name,u_pass;

		public string username
		{
			get
			{
				return u_name;
			}
			set
			{
				u_name=value;
			}
		}
		public string userpass
		{
			get
			{
				return u_pass;
			}
			set
			{
				u_pass=value;
			}
		}
		#endregion

		/// <summary>
		/// this method use to Making connection
		/// </summary>
		public PasswordClass()
		{
			sqcon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			sqcon.Open();
		}

		/// <summary>
		/// this method use to Valid Check User.
		/// </summary>
		public int CheckUser()
		{
			sqcom=new SqlCommand("select Users_Name,Users_Password from userspwd where Users_Name='"+username+"' and Users_Password='"+userpass+"'",sqcon);
			sqdr=sqcom.ExecuteReader();
			if(sqdr.Read())
			{
				username=sqdr.GetValue(0).ToString().Trim();
				userpass=sqdr.GetValue(1).ToString().Trim();
				return 0;
			}
			else
			{
				return 1;
			}
		
		}

	}
}
