/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/


using System;

namespace eschool.Classes
{
	/// <summary>
	/// Summary description for StringUtil.
	/// </summary>
	public class StringUtil
	{
		/// <summary>
		/// this Method for getting the first character capital of every string.		
		/// </summary>
		public static string FirstCharUpper(string s)
		{ 
			string str = s;
			string fChar = "";
			string rStr  = "";     
			string strResult = "";

			if (str != "")
			{
				fChar = str.Substring(0,1);
				rStr  = str.Substring(1);
				strResult = fChar.ToUpper() + rStr.ToLower();
			}
			return strResult;     
		}
	}
}
