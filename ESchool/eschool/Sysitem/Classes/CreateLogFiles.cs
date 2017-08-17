/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/


using System;
using System.IO;
using System.Text;

namespace eschool.Classes
{
	/// <summary>
	/// This class use to handel the Exception in text file.
	/// </summary>
	public class CreateLogFiles
	{
		
		//private string sErrorTime;
        static string fileName;
		static string sLogFormat;
		public CreateLogFiles()
		{
  			
		}

		/// <summary>
		/// Method for writing the Error Message to the text file in log folder.file name save as date.
		/// </summary>
		public static void ErrorLog(string sErrMsg)
		{
			
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				//fileName = home_drive+@"\Inetpub\wwwroot\eschool\Logs\" +DateTime.Today.Day.ToString()+ "-" +DateTime.Today.Month.ToString() + "-" + DateTime.Today.Year.ToString() + ".log";
				fileName = home_drive+@"\Inetpub\wwwroot\eschool\Sysitem\Logs\" +DateTime.Today.Day.ToString()+ "-" +DateTime.Today.Month.ToString() + "-" + DateTime.Today.Year.ToString() + ".log";
				sLogFormat = DateTime.Now.ToShortDateString().ToString()+" "+DateTime.Now.ToLongTimeString().ToString()+" ==> ";

            StreamWriter sw = new StreamWriter(fileName, true);

            sw.WriteLine(sLogFormat + sErrMsg);
            sw.Flush();
            sw.Close();
        }
	}
}



 



