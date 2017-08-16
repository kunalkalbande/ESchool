/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/   

  #    region Directive...
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
using RMG;
using System.Text;
using eschool.Classes;
# endregion

namespace eschool.Roles
{
	/// <summary>
	/// Summary description for Roles_Privileges.
	/// </summary>
	public class Roles_Privileges : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtRoleName;
		protected System.Web.UI.WebControls.TextBox txtDesc;
		protected System.Web.UI.WebControls.TextBox TxtName;
		protected System.Web.UI.WebControls.DropDownList DropName;
		protected System.Web.UI.WebControls.Label lblLogPriv;
		protected System.Web.UI.WebControls.DropDownList DropLogin;
		protected System.Web.UI.WebControls.Label lblSelect;
		protected System.Web.UI.WebControls.CheckBox Checkbox223;
		protected System.Web.UI.WebControls.CheckBox Checkbox224;
		protected System.Web.UI.WebControls.CheckBox Checkbox225;
		protected System.Web.UI.WebControls.CheckBox Checkbox226;
		protected System.Web.UI.WebControls.CheckBox Checkbox227;
		protected System.Web.UI.WebControls.CheckBox Checkbox228;
		protected System.Web.UI.WebControls.CheckBox Checkbox229;
		protected System.Web.UI.WebControls.CheckBox Checkbox230;
		protected System.Web.UI.WebControls.CheckBox Checkbox231;
		protected System.Web.UI.WebControls.CheckBox Checkbox232;
		protected System.Web.UI.WebControls.CheckBox Checkbox233;
		protected System.Web.UI.WebControls.CheckBox Checkbox234;
		protected System.Web.UI.WebControls.CheckBox Checkbox235;
		protected System.Web.UI.WebControls.CheckBox Checkbox236;
		protected System.Web.UI.WebControls.CheckBox Checkbox237;
		protected System.Web.UI.WebControls.CheckBox Checkbox238;
		protected System.Web.UI.WebControls.CheckBox Checkbox239;
		protected System.Web.UI.WebControls.CheckBox Checkbox240;
		protected System.Web.UI.WebControls.CheckBox Checkbox241;
		protected System.Web.UI.WebControls.CheckBox Checkbox242;
		protected System.Web.UI.WebControls.CheckBox Checkbox243;
		protected System.Web.UI.WebControls.CheckBox Checkbox244;
		protected System.Web.UI.WebControls.CheckBox Checkbox245;
		protected System.Web.UI.WebControls.CheckBox Checkbox246;
		protected System.Web.UI.WebControls.CheckBox Checkbox247;
		protected System.Web.UI.WebControls.CheckBox Checkbox248;
		protected System.Web.UI.WebControls.CheckBox Checkbox249;
		protected System.Web.UI.WebControls.CheckBox Checkbox250;
		protected System.Web.UI.WebControls.CheckBox chkView1;
		protected System.Web.UI.WebControls.CheckBox chkAdd1;
		protected System.Web.UI.WebControls.CheckBox chkEdit1;
		protected System.Web.UI.WebControls.CheckBox chkDel1;
		protected System.Web.UI.WebControls.CheckBox chkView2;
		protected System.Web.UI.WebControls.CheckBox chkAdd2;
		protected System.Web.UI.WebControls.CheckBox chkEdit2;
		protected System.Web.UI.WebControls.CheckBox chkDel2;
		protected System.Web.UI.WebControls.CheckBox chkView3;
		protected System.Web.UI.WebControls.CheckBox chkAdd3;
		protected System.Web.UI.WebControls.CheckBox chkEdit3;
		protected System.Web.UI.WebControls.CheckBox chkDel3;
		protected System.Web.UI.WebControls.CheckBox chkView4;
		protected System.Web.UI.WebControls.CheckBox chkAdd4;
		protected System.Web.UI.WebControls.CheckBox chkEdit4;
		protected System.Web.UI.WebControls.CheckBox chkDel4;
		protected System.Web.UI.WebControls.CheckBox chkView5;
		protected System.Web.UI.WebControls.CheckBox chkAdd5;
		protected System.Web.UI.WebControls.CheckBox chkEdit5;
		protected System.Web.UI.WebControls.CheckBox chkDel5;
		protected System.Web.UI.WebControls.CheckBox chkView7;
		protected System.Web.UI.WebControls.CheckBox chkAdd7;
		protected System.Web.UI.WebControls.CheckBox chkEdit7;
		protected System.Web.UI.WebControls.CheckBox chkDel7;
		protected System.Web.UI.WebControls.CheckBox chkView8;
		protected System.Web.UI.WebControls.CheckBox chkAdd8;
		protected System.Web.UI.WebControls.CheckBox chkEdit8;
		protected System.Web.UI.WebControls.CheckBox chkDel8;
		protected System.Web.UI.WebControls.CheckBox chkView26;
		protected System.Web.UI.WebControls.CheckBox chkAdd26;
		protected System.Web.UI.WebControls.CheckBox chkEdit26;
		protected System.Web.UI.WebControls.CheckBox chkDel26;
		protected System.Web.UI.WebControls.CheckBox chkView27;
		protected System.Web.UI.WebControls.CheckBox chkAdd27;
		protected System.Web.UI.WebControls.CheckBox chkEdit27;
		protected System.Web.UI.WebControls.CheckBox chkDel27;
		protected System.Web.UI.WebControls.CheckBox chkView28;
		protected System.Web.UI.WebControls.CheckBox chkAdd28;
		protected System.Web.UI.WebControls.CheckBox chkEdit28;
		protected System.Web.UI.WebControls.CheckBox chkDel28;
		protected System.Web.UI.WebControls.CheckBox chkView29;
		protected System.Web.UI.WebControls.CheckBox chkAdd29;
		protected System.Web.UI.WebControls.CheckBox chkEdit29;
		protected System.Web.UI.WebControls.CheckBox chkDel29;
		protected System.Web.UI.WebControls.CheckBox chkView30;
		protected System.Web.UI.WebControls.CheckBox chkAdd30;
		protected System.Web.UI.WebControls.CheckBox chkEdit30;
		protected System.Web.UI.WebControls.CheckBox chkDel30;
		protected System.Web.UI.WebControls.CheckBox chkView31;
		protected System.Web.UI.WebControls.CheckBox chkAdd31;
		protected System.Web.UI.WebControls.CheckBox chkEdit31;
		protected System.Web.UI.WebControls.CheckBox chkDel31;
		protected System.Web.UI.WebControls.CheckBox chkView35;
		protected System.Web.UI.WebControls.CheckBox chkAdd35;
		protected System.Web.UI.WebControls.CheckBox chkEdit35;
		protected System.Web.UI.WebControls.CheckBox chkDel35;
		protected System.Web.UI.WebControls.CheckBox chkView43;
		protected System.Web.UI.WebControls.CheckBox chkAdd43;
		protected System.Web.UI.WebControls.CheckBox chkEdit43;
		protected System.Web.UI.WebControls.CheckBox chkDel43;
		protected System.Web.UI.WebControls.CheckBox chkView46;
		protected System.Web.UI.WebControls.CheckBox chkAdd46;
		protected System.Web.UI.WebControls.CheckBox chkEdit46;
		protected System.Web.UI.WebControls.CheckBox chkDel46;
		protected System.Web.UI.WebControls.CheckBox chkView47;
		protected System.Web.UI.WebControls.CheckBox chkAdd47;
		protected System.Web.UI.WebControls.CheckBox chkEdit47;
		protected System.Web.UI.WebControls.CheckBox chkDel47;
		protected System.Web.UI.WebControls.CheckBox chkView49;
		protected System.Web.UI.WebControls.CheckBox chkAdd49;
		protected System.Web.UI.WebControls.CheckBox chkEdit49;
		protected System.Web.UI.WebControls.CheckBox chkDel49;
		protected System.Web.UI.WebControls.CheckBox chkView50;
		protected System.Web.UI.WebControls.CheckBox chkAdd50;
		protected System.Web.UI.WebControls.CheckBox chkEdit50;
		protected System.Web.UI.WebControls.CheckBox chkDel50;
		protected System.Web.UI.WebControls.CheckBox chkView52;
		protected System.Web.UI.WebControls.CheckBox chkAdd52;
		protected System.Web.UI.WebControls.CheckBox chkEdit52;
		protected System.Web.UI.WebControls.CheckBox chkDel52;
		protected System.Web.UI.WebControls.CheckBox chkView66;
		protected System.Web.UI.WebControls.CheckBox chkAdd66;
		protected System.Web.UI.WebControls.CheckBox chkEdit66;
		protected System.Web.UI.WebControls.CheckBox chkDel66;
		protected System.Web.UI.WebControls.CheckBox chkView67;
		protected System.Web.UI.WebControls.CheckBox chkAdd67;
		protected System.Web.UI.WebControls.CheckBox chkEdit67;
		protected System.Web.UI.WebControls.CheckBox chkDel67;
		protected System.Web.UI.WebControls.CheckBox chkView68;
		protected System.Web.UI.WebControls.CheckBox chkAdd68;
		protected System.Web.UI.WebControls.CheckBox chkEdit68;
		protected System.Web.UI.WebControls.CheckBox chkDel68;
		protected System.Web.UI.WebControls.CheckBox chkView69;
		protected System.Web.UI.WebControls.CheckBox chkAdd69;
		protected System.Web.UI.WebControls.CheckBox chkEdit69;
		protected System.Web.UI.WebControls.CheckBox chkDel69;
		protected System.Web.UI.WebControls.CheckBox chkView70;
		protected System.Web.UI.WebControls.CheckBox chkAdd70;
		protected System.Web.UI.WebControls.CheckBox chkEdit70;
		protected System.Web.UI.WebControls.CheckBox chkDel70;
		protected System.Web.UI.WebControls.CheckBox chkView71;
		protected System.Web.UI.WebControls.CheckBox chkAdd71;
		protected System.Web.UI.WebControls.CheckBox chkEdit71;
		protected System.Web.UI.WebControls.CheckBox chkDel71;
		protected System.Web.UI.WebControls.CheckBox chkView72;
		protected System.Web.UI.WebControls.CheckBox chkAdd72;
		protected System.Web.UI.WebControls.CheckBox chkEdit72;
		protected System.Web.UI.WebControls.CheckBox chkDel72;
		protected System.Web.UI.WebControls.CheckBox chkView74;
		protected System.Web.UI.WebControls.CheckBox chkAdd74;
		protected System.Web.UI.WebControls.CheckBox chkEdit74;
		protected System.Web.UI.WebControls.CheckBox chkDel74;
		protected System.Web.UI.WebControls.CheckBox chkView75;
		protected System.Web.UI.WebControls.CheckBox chkAdd75;
		protected System.Web.UI.WebControls.CheckBox chkEdit75;
		protected System.Web.UI.WebControls.CheckBox chkDel75;
		protected System.Web.UI.WebControls.CheckBox chkView76;
		protected System.Web.UI.WebControls.CheckBox chkAdd76;
		protected System.Web.UI.WebControls.CheckBox chkEdit76;
		protected System.Web.UI.WebControls.CheckBox chkDel76;
		protected System.Web.UI.WebControls.CheckBox chkView79;
		protected System.Web.UI.WebControls.CheckBox chkView80;
		protected System.Web.UI.WebControls.CheckBox chkAdd79;
		protected System.Web.UI.WebControls.CheckBox chkEdit79;
		protected System.Web.UI.WebControls.CheckBox chkDel79;
		protected System.Web.UI.WebControls.CheckBox chkAdd80;
		protected System.Web.UI.WebControls.CheckBox chkEdit80;
		protected System.Web.UI.WebControls.CheckBox chkDel80;
		protected System.Web.UI.WebControls.CheckBox chkView83;
		protected System.Web.UI.WebControls.CheckBox chkAdd83;
		protected System.Web.UI.WebControls.CheckBox chkEdit83;
		protected System.Web.UI.WebControls.CheckBox chkDel83;
		protected System.Web.UI.WebControls.CheckBox chkView84;
		protected System.Web.UI.WebControls.CheckBox chkAdd84;
		protected System.Web.UI.WebControls.CheckBox chkEdit84;
		protected System.Web.UI.WebControls.CheckBox chkDel84;
		protected System.Web.UI.WebControls.CheckBox chkView87;
		protected System.Web.UI.WebControls.CheckBox chkAdd87;
		protected System.Web.UI.WebControls.CheckBox chkEdit87;
		protected System.Web.UI.WebControls.CheckBox chkDel87;
		protected System.Web.UI.WebControls.CheckBox chkView91;
		protected System.Web.UI.WebControls.CheckBox chkAdd91;
		protected System.Web.UI.WebControls.CheckBox chkEdit91;
		protected System.Web.UI.WebControls.CheckBox chkDel91;
		protected System.Web.UI.WebControls.CheckBox chkView93;
		protected System.Web.UI.WebControls.CheckBox chkAdd93;
		protected System.Web.UI.WebControls.CheckBox chkEdit93;
		protected System.Web.UI.WebControls.CheckBox chkDel93;
		protected System.Web.UI.WebControls.CheckBox chkAdd94;
		protected System.Web.UI.WebControls.CheckBox chkEdit94;
		protected System.Web.UI.WebControls.CheckBox chkDel94;
		protected System.Web.UI.WebControls.CheckBox chkDailySelectAll;
		protected System.Web.UI.WebControls.CheckBox chkExamSelectAll;
		protected System.Web.UI.WebControls.CheckBox chkCertificateSelectAll;
		protected System.Web.UI.WebControls.CheckBox chkPersonalSelectAll;
		protected System.Web.UI.WebControls.CheckBox ChkTTMselectall;
		protected System.Web.UI.WebControls.CheckBox chkLogisticSelectAll;
		protected System.Web.UI.WebControls.CheckBox chkLibSelectAll;
		protected System.Web.UI.WebControls.CheckBox chkAccountSelectAll;
		protected System.Web.UI.WebControls.CheckBox chkStuReport;
		protected System.Web.UI.WebControls.CheckBox chkSalaryRepSelectAll;
		protected System.Web.UI.WebControls.CheckBox chkTTRepSelectAll;
		protected System.Web.UI.WebControls.CheckBox chkAccRepSelectAll;
		protected System.Web.UI.WebControls.CheckBox chkCertiRepSelectAll;
		protected System.Web.UI.WebControls.CheckBox chkAdminSelectAll;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnEditSave;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.CheckBox chkView78;
		protected System.Web.UI.WebControls.CheckBox chkAdd78;
		protected System.Web.UI.WebControls.CheckBox chkEdit78;
		protected System.Web.UI.WebControls.CheckBox chkDel78;
		protected System.Web.UI.WebControls.CheckBox chkDel1031;
		protected System.Web.UI.WebControls.CheckBox chkhostSelectAll;
		protected System.Web.UI.WebControls.CheckBox chkView9;
		protected System.Web.UI.WebControls.CheckBox chkAdd9;
		protected System.Web.UI.WebControls.CheckBox chkEdit9;
		protected System.Web.UI.WebControls.CheckBox chkDel9;
		protected System.Web.UI.WebControls.CheckBox chkView10;
		protected System.Web.UI.WebControls.CheckBox chkAdd10;
		protected System.Web.UI.WebControls.CheckBox chkEdit10;
		protected System.Web.UI.WebControls.CheckBox chkDel10;
		protected System.Web.UI.WebControls.CheckBox chkView11;
		protected System.Web.UI.WebControls.CheckBox chkAdd11;
		protected System.Web.UI.WebControls.CheckBox chkEdit11;
		protected System.Web.UI.WebControls.CheckBox chkDel11;
		protected System.Web.UI.WebControls.CheckBox chkView12;
		protected System.Web.UI.WebControls.CheckBox chkAdd12;
		protected System.Web.UI.WebControls.CheckBox chkEdit12;
		protected System.Web.UI.WebControls.CheckBox chkDel12;
		protected System.Web.UI.WebControls.CheckBox chkView13;
		protected System.Web.UI.WebControls.CheckBox chkAdd13;
		protected System.Web.UI.WebControls.CheckBox chkEdit13;
		protected System.Web.UI.WebControls.CheckBox chkDel13;
		protected System.Web.UI.WebControls.CheckBox chkView14;
		protected System.Web.UI.WebControls.CheckBox chkAdd14;
		protected System.Web.UI.WebControls.CheckBox chkEdit14;
		protected System.Web.UI.WebControls.CheckBox chkDel14;
		protected System.Web.UI.WebControls.CheckBox chkView15;
		protected System.Web.UI.WebControls.CheckBox chkAdd15;
		protected System.Web.UI.WebControls.CheckBox chkEdit15;
		protected System.Web.UI.WebControls.CheckBox chkDel15;
		protected System.Web.UI.WebControls.CheckBox chkView16;
		protected System.Web.UI.WebControls.CheckBox chkAdd16;
		protected System.Web.UI.WebControls.CheckBox chkEdit16;
		protected System.Web.UI.WebControls.CheckBox chkDel16;
		protected System.Web.UI.WebControls.CheckBox chkView73;
		protected System.Web.UI.WebControls.CheckBox chkAdd73;
		protected System.Web.UI.WebControls.CheckBox chkEdit73;
		protected System.Web.UI.WebControls.CheckBox chkDel73;
		protected System.Web.UI.WebControls.CheckBox chkView18;
		protected System.Web.UI.WebControls.CheckBox chkAdd18;
		protected System.Web.UI.WebControls.CheckBox chkEdit18;
		protected System.Web.UI.WebControls.CheckBox chkDel18;
		protected System.Web.UI.WebControls.CheckBox chkView19;
		protected System.Web.UI.WebControls.CheckBox chkAdd19;
		protected System.Web.UI.WebControls.CheckBox chkEdit19;
		protected System.Web.UI.WebControls.CheckBox chkDel19;
		protected System.Web.UI.WebControls.CheckBox chkView20;
		protected System.Web.UI.WebControls.CheckBox chkAdd20;
		protected System.Web.UI.WebControls.CheckBox chkEdit20;
		protected System.Web.UI.WebControls.CheckBox chkDel20;
		protected System.Web.UI.WebControls.CheckBox chkView21;
		protected System.Web.UI.WebControls.CheckBox chkAdd21;
		protected System.Web.UI.WebControls.CheckBox chkEdit21;
		protected System.Web.UI.WebControls.CheckBox chkDel21;
		protected System.Web.UI.WebControls.CheckBox chkView22;
		protected System.Web.UI.WebControls.CheckBox chkAdd22;
		protected System.Web.UI.WebControls.CheckBox chkEdit22;
		protected System.Web.UI.WebControls.CheckBox chkView23;
		protected System.Web.UI.WebControls.CheckBox chkAdd23;
		protected System.Web.UI.WebControls.CheckBox chkEdit23;
		protected System.Web.UI.WebControls.CheckBox chkDel23;
		protected System.Web.UI.WebControls.CheckBox chkView24;
		protected System.Web.UI.WebControls.CheckBox chkAdd24;
		protected System.Web.UI.WebControls.CheckBox chkEdit24;
		protected System.Web.UI.WebControls.CheckBox chkDel24;
		protected System.Web.UI.WebControls.CheckBox chkView25;
		protected System.Web.UI.WebControls.CheckBox chkAdd25;
		protected System.Web.UI.WebControls.CheckBox chkEdit25;
		protected System.Web.UI.WebControls.CheckBox chkDel25;
		protected System.Web.UI.WebControls.CheckBox chkView32;
		protected System.Web.UI.WebControls.CheckBox chkAdd32;
		protected System.Web.UI.WebControls.CheckBox chkEdit32;
		protected System.Web.UI.WebControls.CheckBox chkDel32;
		protected System.Web.UI.WebControls.CheckBox chkView33;
		protected System.Web.UI.WebControls.CheckBox chkAdd33;
		protected System.Web.UI.WebControls.CheckBox chkEdit33;
		protected System.Web.UI.WebControls.CheckBox chkDel33;
		protected System.Web.UI.WebControls.CheckBox chkView34;
		protected System.Web.UI.WebControls.CheckBox chkAdd34;
		protected System.Web.UI.WebControls.CheckBox chkEdit34;
		protected System.Web.UI.WebControls.CheckBox chkDel34;
		protected System.Web.UI.WebControls.CheckBox chkView36;
		protected System.Web.UI.WebControls.CheckBox chkAdd36;
		protected System.Web.UI.WebControls.CheckBox chkEdit36;
		protected System.Web.UI.WebControls.CheckBox chkDel36;
		protected System.Web.UI.WebControls.CheckBox chkView37;
		protected System.Web.UI.WebControls.CheckBox chkAdd37;
		protected System.Web.UI.WebControls.CheckBox chkEdit37;
		protected System.Web.UI.WebControls.CheckBox chkDel37;
		protected System.Web.UI.WebControls.CheckBox chkView38;
		protected System.Web.UI.WebControls.CheckBox chkAdd38;
		protected System.Web.UI.WebControls.CheckBox chkEdit38;
		protected System.Web.UI.WebControls.CheckBox chkDel38;
		protected System.Web.UI.WebControls.CheckBox chkView39;
		protected System.Web.UI.WebControls.CheckBox chkAdd39;
		protected System.Web.UI.WebControls.CheckBox chkEdit39;
		protected System.Web.UI.WebControls.CheckBox chkDel39;
		protected System.Web.UI.WebControls.CheckBox chkView40;
		protected System.Web.UI.WebControls.CheckBox chkAdd40;
		protected System.Web.UI.WebControls.CheckBox chkEdit40;
		protected System.Web.UI.WebControls.CheckBox chkDel40;
		protected System.Web.UI.WebControls.CheckBox chkView41;
		protected System.Web.UI.WebControls.CheckBox chkAdd41;
		protected System.Web.UI.WebControls.CheckBox chkEdit41;
		protected System.Web.UI.WebControls.CheckBox chkDel41;
		protected System.Web.UI.WebControls.CheckBox chkView42;
		protected System.Web.UI.WebControls.CheckBox chkAdd42;
		protected System.Web.UI.WebControls.CheckBox chkEdit42;
		protected System.Web.UI.WebControls.CheckBox chkDel42;
		protected System.Web.UI.WebControls.CheckBox chkView44;
		protected System.Web.UI.WebControls.CheckBox chkAdd44;
		protected System.Web.UI.WebControls.CheckBox chkEdit44;
		protected System.Web.UI.WebControls.CheckBox chkDel44;
		protected System.Web.UI.WebControls.CheckBox chkView45;
		protected System.Web.UI.WebControls.CheckBox chkAdd45;
		protected System.Web.UI.WebControls.CheckBox chkEdit45;
		protected System.Web.UI.WebControls.CheckBox chkDel45;
		protected System.Web.UI.WebControls.CheckBox chkView48;
		protected System.Web.UI.WebControls.CheckBox chkAdd48;
		protected System.Web.UI.WebControls.CheckBox chkEdit48;
		protected System.Web.UI.WebControls.CheckBox chkDel48;
		protected System.Web.UI.WebControls.CheckBox chkView51;
		protected System.Web.UI.WebControls.CheckBox chkAdd51;
		protected System.Web.UI.WebControls.CheckBox chkEdit51;
		protected System.Web.UI.WebControls.CheckBox chkDel51;
		protected System.Web.UI.WebControls.CheckBox chkView54;
		protected System.Web.UI.WebControls.CheckBox chkAdd54;
		protected System.Web.UI.WebControls.CheckBox chkEdit54;
		protected System.Web.UI.WebControls.CheckBox chkDel54;
		protected System.Web.UI.WebControls.CheckBox chkView55;
		protected System.Web.UI.WebControls.CheckBox chkAdd55;
		protected System.Web.UI.WebControls.CheckBox chkEdit55;
		protected System.Web.UI.WebControls.CheckBox chkDel55;
		protected System.Web.UI.WebControls.CheckBox chkView56;
		protected System.Web.UI.WebControls.CheckBox chkAdd56;
		protected System.Web.UI.WebControls.CheckBox chkEdit56;
		protected System.Web.UI.WebControls.CheckBox chkDel56;
		protected System.Web.UI.WebControls.CheckBox chkView57;
		protected System.Web.UI.WebControls.CheckBox chkAdd57;
		protected System.Web.UI.WebControls.CheckBox chkEdit57;
		protected System.Web.UI.WebControls.CheckBox chkDel57;
		protected System.Web.UI.WebControls.CheckBox chkView58;
		protected System.Web.UI.WebControls.CheckBox chkAdd58;
		protected System.Web.UI.WebControls.CheckBox chkEdit58;
		protected System.Web.UI.WebControls.CheckBox chkDel58;
		protected System.Web.UI.WebControls.CheckBox chkView59;
		protected System.Web.UI.WebControls.CheckBox chkAdd59;
		protected System.Web.UI.WebControls.CheckBox chkEdit59;
		protected System.Web.UI.WebControls.CheckBox chkDel59;
		protected System.Web.UI.WebControls.CheckBox chkView60;
		protected System.Web.UI.WebControls.CheckBox chkAdd60;
		protected System.Web.UI.WebControls.CheckBox chkEdit60;
		protected System.Web.UI.WebControls.CheckBox chkDel60;
		protected System.Web.UI.WebControls.CheckBox chkView61;
		protected System.Web.UI.WebControls.CheckBox chkAdd61;
		protected System.Web.UI.WebControls.CheckBox chkEdit61;
		protected System.Web.UI.WebControls.CheckBox chkDel61;
		protected System.Web.UI.WebControls.CheckBox chkView62;
		protected System.Web.UI.WebControls.CheckBox chkAdd62;
		protected System.Web.UI.WebControls.CheckBox chkEdit62;
		protected System.Web.UI.WebControls.CheckBox chkDel62;
		protected System.Web.UI.WebControls.CheckBox chkView63;
		protected System.Web.UI.WebControls.CheckBox chkAdd63;
		protected System.Web.UI.WebControls.CheckBox chkEdit63;
		protected System.Web.UI.WebControls.CheckBox chkDel63;
		protected System.Web.UI.WebControls.CheckBox chkView64;
		protected System.Web.UI.WebControls.CheckBox chkAdd64;
		protected System.Web.UI.WebControls.CheckBox chkEdit64;
		protected System.Web.UI.WebControls.CheckBox chkDel64;
		protected System.Web.UI.WebControls.CheckBox chkView65;
		protected System.Web.UI.WebControls.CheckBox chkAdd65;
		protected System.Web.UI.WebControls.CheckBox chkEdit65;
		protected System.Web.UI.WebControls.CheckBox chkDel65;
		protected System.Web.UI.WebControls.CheckBox chkView77;
		protected System.Web.UI.WebControls.CheckBox chkAdd77;
		protected System.Web.UI.WebControls.CheckBox chkEdit77;
		protected System.Web.UI.WebControls.CheckBox chkDel77;
		protected System.Web.UI.WebControls.CheckBox chkView81;
		protected System.Web.UI.WebControls.CheckBox chkAdd81;
		protected System.Web.UI.WebControls.CheckBox chkEdit81;
		protected System.Web.UI.WebControls.CheckBox chkDel81;
		protected System.Web.UI.WebControls.CheckBox chkView82;
		protected System.Web.UI.WebControls.CheckBox chkAdd82;
		protected System.Web.UI.WebControls.CheckBox chkEdit82;
		protected System.Web.UI.WebControls.CheckBox chkDel82;
		protected System.Web.UI.WebControls.CheckBox chkView85;
		protected System.Web.UI.WebControls.CheckBox chkAdd85;
		protected System.Web.UI.WebControls.CheckBox chkEdit85;
		protected System.Web.UI.WebControls.CheckBox chkDel85;
		protected System.Web.UI.WebControls.CheckBox chkView86;
		protected System.Web.UI.WebControls.CheckBox chkAdd86;
		protected System.Web.UI.WebControls.CheckBox chkEdit86;
		protected System.Web.UI.WebControls.CheckBox chkDel86;
		protected System.Web.UI.WebControls.CheckBox chkView88;
		protected System.Web.UI.WebControls.CheckBox chkAdd88;
		protected System.Web.UI.WebControls.CheckBox chkEdit88;
		protected System.Web.UI.WebControls.CheckBox chkDel88;
		protected System.Web.UI.WebControls.CheckBox chkView89;
		protected System.Web.UI.WebControls.CheckBox chkAdd89;
		protected System.Web.UI.WebControls.CheckBox chkEdit89;
		protected System.Web.UI.WebControls.CheckBox chkDel89;
		protected System.Web.UI.WebControls.CheckBox chkView90;
		protected System.Web.UI.WebControls.CheckBox chkAdd90;
		protected System.Web.UI.WebControls.CheckBox chkEdit90;
		protected System.Web.UI.WebControls.CheckBox chkDel90;
		protected System.Web.UI.WebControls.CheckBox chkView94;
		protected System.Web.UI.WebControls.CheckBox chkView17;
		protected System.Web.UI.WebControls.CheckBox chkAdd17;
		protected System.Web.UI.WebControls.CheckBox chkEdit17;
		protected System.Web.UI.WebControls.CheckBox chkDel17;
		protected System.Web.UI.WebControls.CheckBox chkAddSelectAll;
		protected System.Web.UI.WebControls.CheckBox chkhealthSelectAll;
		protected System.Web.UI.WebControls.CheckBox chkLabSelectAll;
		protected System.Web.UI.WebControls.CheckBox chkcoachSelectAll;
		protected System.Web.UI.WebControls.CheckBox chklogistSelectAll;
		protected System.Web.UI.WebControls.CheckBox chkAptaSelectAll;
		protected System.Web.UI.WebControls.CheckBox chkHealthrSelectAll;
		protected System.Web.UI.WebControls.CheckBox chklibaSelectAll;
		protected System.Web.UI.WebControls.CheckBox chkTTadjSelectAll;
		protected System.Web.UI.WebControls.CheckBox Checkbox9;
		protected System.Web.UI.WebControls.CheckBox chkView95;
		protected System.Web.UI.WebControls.CheckBox chkAdd95;
		protected System.Web.UI.WebControls.CheckBox chkEdit95;
		protected System.Web.UI.WebControls.CheckBox chkDel95;
		protected System.Web.UI.WebControls.CheckBox chkView96;
		protected System.Web.UI.WebControls.CheckBox chkAdd96;
		protected System.Web.UI.WebControls.CheckBox chkEdit96;
		protected System.Web.UI.WebControls.CheckBox chkDel96;
		protected System.Web.UI.WebControls.CheckBox chkView6;
		protected System.Web.UI.WebControls.CheckBox chkAdd6;
		protected System.Web.UI.WebControls.CheckBox chkEdit6;
		protected System.Web.UI.WebControls.CheckBox chkDel6;
		protected System.Web.UI.WebControls.CheckBox chkView53;
		protected System.Web.UI.WebControls.CheckBox chkAdd53;
		protected System.Web.UI.WebControls.CheckBox chkEdit53;
		protected System.Web.UI.WebControls.CheckBox chkDel53;
		protected System.Web.UI.WebControls.CheckBox chkView92;
		protected System.Web.UI.WebControls.CheckBox chkAdd92;
		protected System.Web.UI.WebControls.CheckBox chkEdit92;
		protected System.Web.UI.WebControls.CheckBox chkDel92;
		protected System.Web.UI.WebControls.CheckBox chkDel22;
		protected System.Web.UI.WebControls.CheckBox chkmastSelectAll;
		protected System.Web.UI.WebControls.CompareValidator compval1;
		protected System.Web.UI.WebControls.ValidationSummary Summary1;
		string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for perticular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString ());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Roles_Privileges.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+pass);		
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
				if(!IsPostBack)
				{
					# region Dropdown Login Name
					DropName.Visible=false;
					DropLogin.Visible=true;
					
					btnSave.Visible=true;
					//btnSetPrevileges.Visible=false;
					//btnEdit.Visible=false;
					btnEditSave.Visible=false;

					//Add the login name into the dropdownbox.

					SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
					SqlDataReader SqlDtr;
					string sql;
					sql="select LoginName from User_Master";
					SqlDtr=obj.GetRecordSet(sql);
					DropLogin.Items.Add("--Select--");
					DropName.Items.Add("--Select--");
					while(SqlDtr.Read())
					{
						DropName.Items.Add(SqlDtr.GetValue(0).ToString()); 
						DropLogin.Items.Add(SqlDtr.GetValue(0).ToString()); 
					}
					SqlDtr.Close();
					# endregion
				}	
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="1";
					string SubModule="2";
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
					if(Add_Flag=="False" && Edit_Flag=="False" && Del_Flag=="False" && View_flag=="False")
					{
						Response.Redirect("/eschool/AccessDeny.aspx",false);
						return;
					}
					if(Add_Flag=="False")
						btnSave.Enabled=false;
					//if(Edit_Flag=="False")
						//btnEdit.Enabled=false;
					//if(View_flag=="False")
						//btnSetPrevileges.Enabled=false;
					#endregion
				}
				CreateLogFiles.ErrorLog(" Form : Roles_Privileges.aspx,Method  PageLoad,  Userid :  "+ pass   );		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Roles_Privileges.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			} 
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			///
			/// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			///
			InitializeComponent();
			base.OnInit(e);
		}
			
			/// <summary>
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>
		private void InitializeComponent()
		{    
			this.DropName.SelectedIndexChanged += new System.EventHandler(this.DropName_SelectedIndexChanged);
			this.DropLogin.SelectedIndexChanged += new System.EventHandler(this.DropLogin_SelectedIndexChanged);
			this.chkAdminSelectAll.CheckedChanged += new System.EventHandler(this.chkAdminSelectAll_CheckedChanged);
			this.chkmastSelectAll.CheckedChanged += new System.EventHandler(this.chkmastSelectAll_CheckedChanged);
			this.chkPersonalSelectAll.CheckedChanged += new System.EventHandler(this.chkPersonalSelectAll_CheckedChanged);
			this.chkAddSelectAll.CheckedChanged += new System.EventHandler(this.chkAddSelectAll_CheckedChanged);
			this.chkDailySelectAll.CheckedChanged += new System.EventHandler(this.chkDailySelectAll_CheckedChanged);
			this.chkExamSelectAll.CheckedChanged += new System.EventHandler(this.chkExamSelectAll_CheckedChanged);
			this.chkCertificateSelectAll.CheckedChanged += new System.EventHandler(this.chkCertificateSelectAll_CheckedChanged);
			this.chkhealthSelectAll.CheckedChanged += new System.EventHandler(this.chkhealthSelectAll_CheckedChanged);
			this.chkLabSelectAll.CheckedChanged += new System.EventHandler(this.chkLabSelectAll_CheckedChanged);
			this.ChkTTMselectall.CheckedChanged += new System.EventHandler(this.ChkTTMselectall_CheckedChanged);
			this.chkLibSelectAll.CheckedChanged += new System.EventHandler(this.chkLibSelectAll_CheckedChanged);
			this.chkAccountSelectAll.CheckedChanged += new System.EventHandler(this.chkAccountSelectAll_CheckedChanged);
			this.Checkbox9.CheckedChanged += new System.EventHandler(this.Checkbox9_CheckedChanged);
			this.chkLogisticSelectAll.CheckedChanged += new System.EventHandler(this.chkLogisticSelectAll_CheckedChanged);
			this.chkhostSelectAll.CheckedChanged += new System.EventHandler(this.chkhostSelectAll_CheckedChanged);
			this.chkcoachSelectAll.CheckedChanged += new System.EventHandler(this.chkcoachSelectAll_CheckedChanged);
			this.chkAccRepSelectAll.CheckedChanged += new System.EventHandler(this.chkAccRepSelectAll_CheckedChanged);
			this.chkCertiRepSelectAll.CheckedChanged += new System.EventHandler(this.chkCertiRepSelectAll_CheckedChanged);
			this.chkHealthrSelectAll.CheckedChanged += new System.EventHandler(this.chkHealthrSelectAll_CheckedChanged);
			this.chklibaSelectAll.CheckedChanged += new System.EventHandler(this.chklibaSelectAll_CheckedChanged);
			this.chklogistSelectAll.CheckedChanged += new System.EventHandler(this.chklogistSelectAll_CheckedChanged);
			this.chkAptaSelectAll.CheckedChanged += new System.EventHandler(this.chkAptaSelectAll_CheckedChanged);
			this.chkSalaryRepSelectAll.CheckedChanged += new System.EventHandler(this.chkSalaryRepSelectAll_CheckedChanged);
			this.chkStuReport.CheckedChanged += new System.EventHandler(this.chkStuReport_CheckedChanged);
			this.chkTTRepSelectAll.CheckedChanged += new System.EventHandler(this.chkTTRepSelectAll_CheckedChanged);
			this.chkTTadjSelectAll.CheckedChanged += new System.EventHandler(this.chkTTadjSelectAll_CheckedChanged);
			this.btnEditSave.Click += new System.EventHandler(this.btnEditSave_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method use to fetch rolename from privileges table and check if role not blank then return flag as 1 value.
		/// </summary>
		public int login()
		{
			try
			{
				SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
				string name=DropLogin.SelectedItem.Text.ToString();
				SqlDataReader SqlDtr;
				string sql;
				sql="select Rolename  from Privileges where LoginName='"+name+"'";
				SqlDtr=obj.GetRecordSet(sql);
				string roll="";
				while(SqlDtr.Read())
				{
					roll=SqlDtr.GetValue(0).ToString();
				}
				SqlDtr.Close();
				int flag =0;
				if(roll.Equals("")||roll==null)
				{
					flag=0;
				}
				else
				{
					flag=1;
				}
				return flag;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Roles_Privileges.aspx,Method  login,  Exception: "+ex.Message+" , Userid :  "+ pass);		
				return 0;
			}
		}

		/// <summary>
		/// this method use to fetch value from user_master and hide some controls from user.	
		/// </summary>
		public void newUser()
		{
			TxtName.Text="";
			txtRoleName.Text="";
			txtDesc.Text="";
			SqlConnection con;
			SqlCommand cmdselect;
			SqlDataReader dtrdrive;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				string sLogName=DropLogin.SelectedItem.Text.ToString().Trim();
				cmdselect = new SqlCommand("select UserFName,UserMName,UserLName,Role_Name,Description from User_Master where LoginName='" + sLogName.ToString() + "'",con);
				dtrdrive = cmdselect.ExecuteReader();
				while(dtrdrive.Read())
				{
					TxtName.Text=Convert.ToString(dtrdrive.GetValue(0).ToString()+" "+dtrdrive.GetValue(1).ToString()+" "+dtrdrive.GetValue(2).ToString()); 
					txtRoleName.Text=Convert.ToString(dtrdrive.GetValue(3).ToString());
					txtDesc.Text=Convert.ToString(dtrdrive.GetValue(4).ToString());
				}
				dtrdrive.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :Roles_Privileges.aspx,Method  DropName_SelectedIndexChanged,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			} 
		}

		/// <summary>
		/// this method use to fetch value from user_master and hide some controls from user.	
		/// </summary>
		private void DropName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			clear1();
			if(DropName.SelectedIndex==0)
			{
				TxtName.Text="";
				txtRoleName.Text="";
				txtDesc.Text="";
			}
			else
			{
				SqlConnection con;
				SqlCommand cmdselect;
				SqlDataReader dtrdrive;
				try
				{
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					string sLogName=DropName.SelectedItem.Text.ToString().Trim();
					cmdselect = new SqlCommand("select UserFName,UserMName,UserLName,Role_Name,Description from User_Master where LoginName='" + sLogName.ToString() + "'",con);
					dtrdrive = cmdselect.ExecuteReader();
					while(dtrdrive.Read())
					{
						TxtName.Text=Convert.ToString(dtrdrive.GetValue(0).ToString())+" " +Convert.ToString(dtrdrive.GetValue(1).ToString())+" "+Convert.ToString(dtrdrive.GetValue(2).ToString()); 
						txtRoleName.Text=Convert.ToString(dtrdrive.GetValue(3).ToString());
						txtDesc.Text=Convert.ToString(dtrdrive.GetValue(4).ToString());
					}
					dtrdrive.Close();
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog(" Form :Roles_Privileges.aspx,Method  DropName_SelectedIndexChanged,  Exception: "+ex.Message+" , Userid :  "+ Session["Password"].ToString()   );		
				} 
			}
		}

		string m;
		/// <summary>
		/// this method use Get NextID from Privileges table.
		/// </summary>
		private void fillID()
		{
			SqlConnection con;
			SqlCommand cmd;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				SqlDataReader SqlDtr; 
				cmd=new SqlCommand("select max(privileges_Id)+1 from privileges",con);
				SqlDtr=cmd.ExecuteReader();
				if(SqlDtr.HasRows )
				{
					while(SqlDtr.Read ())
					{
						m=SqlDtr.GetValue(0).ToString();
						if(m.Equals(""))
						{
							m="0";
							m=System.Convert.ToString(System.Convert.ToInt32(m)+1);
						}
					}
				}
				SqlDtr.Close (); 
				con.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// this Method use to save data in to privileges table.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{				
				if(DropLogin.SelectedIndex==0)
					
				{
					MessageBox.Show("Please Select the Login Name");
				}
				else
				{
					SqlConnection con;
					SqlCommand cmdselect;
					SqlDataReader dtrdrive;
				 
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					fillID();
					string sLName=DropLogin.SelectedItem.Text.ToString().Trim();
					
					cmdselect = new SqlCommand( "Select Count(LoginName)  From Privileges where LoginName='" + sLName + "'", con );
					dtrdrive = cmdselect.ExecuteReader();
					int iCount=0;
					while(dtrdrive.Read())
					{
						iCount=Convert.ToInt32(dtrdrive.GetSqlValue(0).ToString());
					}
					if(iCount==0)
					{
						SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
						int Modules=11;
						int a=0;
						
						int[] SubModules={5,11,5,11,3,3,8,3,4,1,42};
						CheckBox[] ChkView={chkView1, chkView2, chkView3, chkView4, chkView5, chkView6, chkView7, chkView8, chkView9, chkView10, chkView11, chkView12, chkView13, chkView14, chkView15,chkView16, chkView17, chkView18, chkView19, chkView20, chkView21, chkView22, chkView23, chkView24, chkView25,chkView26, chkView27, chkView28, chkView29, chkView30, chkView31, chkView32, chkView33, chkView34, chkView35, chkView36, chkView37, chkView38, chkView39, chkView40, chkView41,chkView42, chkView43, chkView44, chkView45, chkView46, chkView47, chkView48, chkView49, chkView50, chkView51, chkView52,chkView53, chkView54, chkView55, chkView56, chkView57, chkView58, chkView59, chkView60,chkView61, chkView62,chkView63,chkView64,chkView65,chkView66,chkView67,chkView68,chkView69,chkView70,chkView71,chkView72,chkView73,chkView74,chkView75,chkView76,chkView77,chkView78,chkView79,chkView80,chkView81,chkView82,chkView83,chkView84,chkView85,chkView86,chkView87,chkView88,chkView89,chkView90,chkView91,chkView92,chkView93,chkView94,chkView95,chkView96};
						CheckBox[] ChkAdd={chkAdd1, chkAdd2, chkAdd3, chkAdd4, chkAdd5,chkAdd6, chkAdd7, chkAdd8, chkAdd9, chkAdd10, chkAdd11, chkAdd12, chkAdd13, chkAdd14, chkAdd15,chkAdd16, chkAdd17, chkAdd18, chkAdd19, chkAdd20, chkAdd21, chkAdd22, chkAdd23, chkAdd24, chkAdd25,chkAdd26, chkAdd27, chkAdd28, chkAdd29, chkAdd30, chkAdd31, chkAdd32, chkAdd33, chkAdd34, chkAdd35, chkAdd36, chkAdd37, chkAdd38, chkAdd39, chkAdd40, chkAdd41,chkAdd42, chkAdd43, chkAdd44, chkAdd45, chkAdd46, chkAdd47, chkAdd48, chkAdd49, chkAdd50, chkAdd51, chkAdd52,chkAdd53, chkAdd54, chkAdd55, chkAdd56, chkAdd57, chkAdd58, chkAdd59, chkAdd60,chkAdd61, chkAdd62,chkAdd63,chkAdd64, chkAdd65, chkAdd66,chkAdd67,chkAdd68,chkAdd69,chkAdd70,chkAdd71,chkAdd72,chkAdd73,chkAdd74,chkAdd75,chkAdd76,chkAdd77,chkAdd78,chkAdd79,chkAdd80,chkAdd81,chkAdd82,chkAdd83,chkAdd84,chkAdd85,chkAdd86,chkAdd87,chkAdd88,chkAdd89,chkAdd90,chkAdd91,chkAdd92,chkAdd93,chkAdd94,chkAdd95,chkAdd96};
						CheckBox[] ChkEdit={chkEdit1, chkEdit2, chkEdit3, chkEdit4, chkEdit5, chkEdit6, chkEdit7, chkEdit8, chkEdit9, chkEdit10, chkEdit11, chkEdit12, chkEdit13, chkEdit14, chkEdit15,chkEdit16, chkEdit17, chkEdit18, chkEdit19, chkEdit20, chkEdit21, chkEdit22, chkEdit23, chkEdit24, chkEdit25,chkEdit26, chkEdit27, chkEdit28, chkEdit29, chkEdit30, chkEdit31, chkEdit32, chkEdit33, chkEdit34, chkEdit35, chkEdit36, chkEdit37, chkEdit38, chkEdit39, chkEdit40, chkEdit41,chkEdit42, chkEdit43,chkEdit44, chkEdit45, chkEdit46, chkEdit47, chkEdit48, chkEdit49, chkEdit50, chkEdit51, chkEdit52, chkEdit53, chkEdit54, chkEdit55, chkEdit56, chkEdit57, chkEdit58, chkEdit59, chkEdit60,chkEdit61, chkEdit62,chkEdit63,chkEdit64,chkEdit65,chkEdit66,chkEdit67,chkEdit68,chkEdit69,chkEdit70,chkEdit71,chkEdit72,chkEdit73,chkEdit74,chkEdit75,chkEdit76,chkEdit77,chkEdit78,chkEdit79,chkEdit80,chkEdit81,chkEdit82,chkEdit83,chkEdit84,chkEdit85,chkEdit86,chkEdit87,chkEdit88,chkEdit89,chkEdit90,chkEdit91, chkEdit92,chkEdit93,chkEdit94,chkEdit95,chkEdit96};
						CheckBox[] ChkDel={chkDel1, chkDel2, chkDel3, chkDel4, chkDel5,chkDel6, chkDel7, chkDel8, chkDel9, chkDel10, chkDel11, chkDel12, chkDel13, chkDel14, chkDel15,chkDel16, chkDel17, chkDel18, chkDel19, chkDel20, chkDel21, chkDel22, chkDel23, chkDel24, chkDel25,chkDel26, chkDel27, chkDel28, chkDel29, chkDel30, chkDel31, chkDel32, chkDel33, chkDel34, chkDel35, chkDel36, chkDel37, chkDel38, chkDel39, chkDel40, chkDel41,chkDel42, chkDel43,  chkDel44, chkDel45, chkDel46, chkDel47, chkDel48, chkDel49, chkDel50, chkDel51, chkDel52,chkDel53, chkDel54, chkDel55, chkDel56, chkDel57, chkDel58, chkDel59, chkDel60,chkDel61, chkDel62,chkDel63,chkDel64, chkDel65,chkDel66,chkDel67,chkDel68,chkDel69,chkDel70,chkDel71,chkDel72,chkDel73,chkDel74,chkDel75,chkDel76,chkDel77,chkDel78,chkDel79,chkDel80,chkDel81,chkDel82,chkDel83,chkDel84,chkDel85,chkDel86,chkDel87,chkDel88,chkDel89,chkDel90,chkDel91,chkDel92,chkDel93,chkDel94,chkDel95,chkDel96};

						for(int i=0;i<Modules;i++)
						{
							for(int j=0;j<SubModules[i];j++)
							{
								obj.LoginName=DropLogin.SelectedItem.Text.ToString().Trim();
								obj.RoleName=txtRoleName.Text.ToString().Trim();
								obj.Description=txtDesc.Text.ToString().Trim();
								obj.Module_id=System.Convert.ToString(i+1);
								obj.SubModule_id=System.Convert.ToString(j+1);
								if(ChkView[a].Checked)
								{
									obj.View_flg="1";
								}
								else
									obj.View_flg="0";
								if(ChkAdd[a].Checked)
								{
									obj.Add_flg="1";								
								}
								else
									obj.Add_flg="0";
								if(ChkEdit[a].Checked)
								{
									obj.Edit_flg="1";								
								}
								else
									obj.Edit_flg="0";
								if(ChkDel[a].Checked)								
								{
									obj.Delete_flg="1";									
								}
								else
									obj.Delete_flg="0";
								obj.privileges_Id=m.ToString();
										
								obj.InsertPrevileges();
								a++;
							}
						}							
						MessageBox.Show("Privileges Successfully Saved"); 
						CreateLogFiles.ErrorLog(" Form :Roles_Privileges.aspx,Method  btnSave_Click,Privileges saved for Login Name :"+DropName.SelectedItem.Text.ToString().Trim()+" ,and Roll Name :"+ txtRoleName.Text.ToString().Trim()+",Userid :  "+ Session["Password"].ToString()   );							
						clear();
						btnSave.Visible=false;
						btnEditSave.Visible=true;
					}
					else
					{
						MessageBox.Show("You have already set privileges for this login name");
						clear();
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :Roles_Privileges.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ Session["Password"].ToString()   );		
			} 
		}
		
		/// <summary>
		/// this method use to check user new or all ready exist. if exist then fetch information from privileges table. and update the information.
		/// </summary>
		private void DropLogin_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			clear1();                              
			int n=login();
			if( n==0)
			{
				btnSave.Visible=true;
				btnEditSave.Visible=false;
				newUser();
			}
			else
			{
				btnSave.Visible=false;
				btnEditSave.Visible=true;
				if(DropLogin.SelectedIndex==0)
				{
					TxtName.Text="";
					txtRoleName.Text="";
					txtDesc.Text="";
					
				}
				else
				{
					SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
					SqlDataReader SqlDtr;
					string sql;
					string sLoginName=DropLogin.SelectedItem.Text.ToString().Trim();

					try
					{
						sql="select distinct RoleName,Description from Privileges where LoginName='" + sLoginName.ToString() + "'";
						SqlDtr=obj.GetRecordSet(sql);
						while(SqlDtr.Read())
						{
							txtRoleName.Text= Convert.ToString(SqlDtr.GetValue(0).ToString()); 
							txtDesc.Text= Convert.ToString(SqlDtr.GetValue(1).ToString()); 
						}
						SqlDtr.Close();
						string sql1="select UserFName,UserMName,UserLName from User_Master where LoginName='" + sLoginName.ToString() + "'";
						SqlDtr=obj.GetRecordSet(sql1);
						while(SqlDtr.Read())
						{
							TxtName.Text= Convert.ToString(SqlDtr.GetValue(0).ToString()+" "+SqlDtr.GetValue(1).ToString()+" "+SqlDtr.GetValue(2).ToString()); 
						}
						SqlDtr.Close();

						int Modules=11;
						int a=0;
						int[] SubModules={5,11,5,11,3,3,8,3,4,1,42};
						CheckBox[] ChkView={chkView1, chkView2, chkView3, chkView4, chkView5, chkView6, chkView7, chkView8, chkView9, chkView10, chkView11, chkView12, chkView13, chkView14, chkView15,chkView16, chkView17, chkView18, chkView19, chkView20, chkView21, chkView22, chkView23, chkView24, chkView25,chkView26, chkView27, chkView28, chkView29, chkView30, chkView31, chkView32, chkView33, chkView34, chkView35, chkView36, chkView37, chkView38, chkView39, chkView40, chkView41,chkView42, chkView43, chkView44, chkView45, chkView46, chkView47, chkView48, chkView49, chkView50, chkView51, chkView52,chkView53, chkView54, chkView55, chkView56, chkView57, chkView58, chkView59, chkView60,chkView61, chkView62,chkView63,chkView64,chkView65,chkView66,chkView67,chkView68,chkView69,chkView70,chkView71,chkView72,chkView73,chkView74,chkView75,chkView76,chkView77,chkView78,chkView79,chkView80,chkView81,chkView82,chkView83,chkView84,chkView85,chkView86,chkView87,chkView88,chkView89,chkView90,chkView91,chkView92,chkView93,chkView94,chkView95,chkView96};
						CheckBox[] ChkAdd={chkAdd1, chkAdd2, chkAdd3, chkAdd4, chkAdd5,chkAdd6, chkAdd7, chkAdd8, chkAdd9, chkAdd10, chkAdd11, chkAdd12, chkAdd13, chkAdd14, chkAdd15,chkAdd16, chkAdd17, chkAdd18, chkAdd19, chkAdd20, chkAdd21, chkAdd22, chkAdd23, chkAdd24, chkAdd25,chkAdd26, chkAdd27, chkAdd28, chkAdd29, chkAdd30, chkAdd31, chkAdd32, chkAdd33, chkAdd34, chkAdd35, chkAdd36, chkAdd37, chkAdd38, chkAdd39, chkAdd40, chkAdd41,chkAdd42, chkAdd43, chkAdd44, chkAdd45, chkAdd46, chkAdd47, chkAdd48, chkAdd49, chkAdd50, chkAdd51, chkAdd52,chkAdd53, chkAdd54, chkAdd55, chkAdd56, chkAdd57, chkAdd58, chkAdd59, chkAdd60,chkAdd61, chkAdd62,chkAdd63,chkAdd64, chkAdd65, chkAdd66,chkAdd67,chkAdd68,chkAdd69,chkAdd70,chkAdd71,chkAdd72,chkAdd73,chkAdd74,chkAdd75,chkAdd76,chkAdd77,chkAdd78,chkAdd79,chkAdd80,chkAdd81,chkAdd82,chkAdd83,chkAdd84,chkAdd85,chkAdd86,chkAdd87,chkAdd88,chkAdd89,chkAdd90,chkAdd91,chkAdd92,chkAdd93,chkAdd94,chkAdd95,chkAdd96};
						CheckBox[] ChkEdit={chkEdit1, chkEdit2, chkEdit3, chkEdit4, chkEdit5, chkEdit6, chkEdit7, chkEdit8, chkEdit9, chkEdit10, chkEdit11, chkEdit12, chkEdit13, chkEdit14, chkEdit15,chkEdit16, chkEdit17, chkEdit18, chkEdit19, chkEdit20, chkEdit21, chkEdit22, chkEdit23, chkEdit24, chkEdit25,chkEdit26, chkEdit27, chkEdit28, chkEdit29, chkEdit30, chkEdit31, chkEdit32, chkEdit33, chkEdit34, chkEdit35, chkEdit36, chkEdit37, chkEdit38, chkEdit39, chkEdit40, chkEdit41,chkEdit42, chkEdit43,chkEdit44, chkEdit45, chkEdit46, chkEdit47, chkEdit48, chkEdit49, chkEdit50, chkEdit51, chkEdit52, chkEdit53, chkEdit54, chkEdit55, chkEdit56, chkEdit57, chkEdit58, chkEdit59, chkEdit60,chkEdit61, chkEdit62,chkEdit63,chkEdit64,chkEdit65,chkEdit66,chkEdit67,chkEdit68,chkEdit69,chkEdit70,chkEdit71,chkEdit72,chkEdit73,chkEdit74,chkEdit75,chkEdit76,chkEdit77,chkEdit78,chkEdit79,chkEdit80,chkEdit81,chkEdit82,chkEdit83,chkEdit84,chkEdit85,chkEdit86,chkEdit87,chkEdit88,chkEdit89,chkEdit90,chkEdit91, chkEdit92,chkEdit93,chkEdit94,chkEdit95,chkEdit96};
						CheckBox[] ChkDel={chkDel1, chkDel2, chkDel3, chkDel4, chkDel5,chkDel6, chkDel7, chkDel8, chkDel9, chkDel10, chkDel11, chkDel12, chkDel13, chkDel14, chkDel15,chkDel16, chkDel17, chkDel18, chkDel19, chkDel20, chkDel21, chkDel22, chkDel23, chkDel24, chkDel25,chkDel26, chkDel27, chkDel28, chkDel29, chkDel30, chkDel31, chkDel32, chkDel33, chkDel34, chkDel35, chkDel36, chkDel37, chkDel38, chkDel39, chkDel40, chkDel41,chkDel42, chkDel43,  chkDel44, chkDel45, chkDel46, chkDel47, chkDel48, chkDel49, chkDel50, chkDel51, chkDel52,chkDel53, chkDel54, chkDel55, chkDel56, chkDel57, chkDel58, chkDel59, chkDel60,chkDel61, chkDel62,chkDel63,chkDel64, chkDel65,chkDel66,chkDel67,chkDel68,chkDel69,chkDel70,chkDel71,chkDel72,chkDel73,chkDel74,chkDel75,chkDel76,chkDel77,chkDel78,chkDel79,chkDel80,chkDel81,chkDel82,chkDel83,chkDel84,chkDel85,chkDel86,chkDel87,chkDel88,chkDel89,chkDel90,chkDel91,chkDel92,chkDel93,chkDel94,chkDel95,chkDel96};

						
						sql="select * from privileges where LoginName='"+ sLoginName +"'";
						SqlDtr=obj.GetRecordSet(sql);
						while(SqlDtr.Read())
						{	
							a=0; 
							for(int i=1;i<=Modules;i++)
							{
								for(int j=1;j<=SubModules[i-1];j++)
								{
									int aa=System.Convert.ToInt32(SqlDtr.GetValue(4));
									int bb=System.Convert.ToInt32(SqlDtr.GetValue(5));
									if((i==System.Convert.ToInt32(SqlDtr.GetValue(4)))&&(j==System.Convert.ToInt32(SqlDtr.GetValue(5))))
									{ 
										if(Convert.ToInt32(SqlDtr.GetValue(6))==1)
											ChkView[a].Checked=true;
										if(Convert.ToInt32(SqlDtr.GetValue(7))==1)
											ChkAdd[a].Checked=true;
										if(Convert.ToInt32(SqlDtr.GetValue(8))==1)
											ChkEdit[a].Checked=true;
										if(Convert.ToInt32(SqlDtr.GetValue(9))==1)
											ChkDel[a].Checked=true;
									}
									a++;
								}
							}
						}
						SqlDtr.Close();
						CreateLogFiles.ErrorLog(" Form :Roles_Privileges.aspx,Method  DropLogin_SelectedIndexChanged, Userid :  "+ Session["Password"].ToString()   );		
					}
					catch(Exception ex)
					{
						CreateLogFiles.ErrorLog(" Form :Roles_Privileges.aspx,Method  DropLogin_SelectedIndexChanged,  Exception: "+ex.Message+" , Userid :  "+ Session["Password"].ToString()   );		
						
					} 
				}
			}
		}
		

		/// <summary>
		/// this method use to clear the form.
		/// </summary>
		public void clear()
		{
			CheckBox[] ChkView={chkView1, chkView2, chkView3, chkView4, chkView5, chkView6, chkView7, chkView8, chkView9, chkView10, chkView11, chkView12, chkView13, chkView14, chkView15,chkView16, chkView17, chkView18, chkView19, chkView20, chkView21, chkView22, chkView23, chkView24, chkView25,chkView26, chkView27, chkView28, chkView29, chkView30, chkView31, chkView32, chkView33, chkView34, chkView35, chkView36, chkView37, chkView38, chkView39, chkView40, chkView41,chkView42, chkView43, chkView44, chkView45, chkView46, chkView47, chkView48, chkView49, chkView50, chkView51, chkView52,chkView53, chkView54, chkView55, chkView56, chkView57, chkView58, chkView59, chkView60,chkView61, chkView62,chkView63,chkView64,chkView65,chkView66,chkView67,chkView68,chkView69,chkView70,chkView71,chkView72,chkView73,chkView74,chkView75,chkView76,chkView77,chkView78,chkView79,chkView80,chkView81,chkView82,chkView83,chkView84,chkView85,chkView86,chkView87,chkView88,chkView89,chkView90,chkView91,chkView92,chkView93,chkView94,chkView95,chkView96};
			CheckBox[] ChkAdd={chkAdd1, chkAdd2, chkAdd3, chkAdd4, chkAdd5,chkAdd6, chkAdd7, chkAdd8, chkAdd9, chkAdd10, chkAdd11, chkAdd12, chkAdd13, chkAdd14, chkAdd15,chkAdd16, chkAdd17, chkAdd18, chkAdd19, chkAdd20, chkAdd21, chkAdd22, chkAdd23, chkAdd24, chkAdd25,chkAdd26, chkAdd27, chkAdd28, chkAdd29, chkAdd30, chkAdd31, chkAdd32, chkAdd33, chkAdd34, chkAdd35, chkAdd36, chkAdd37, chkAdd38, chkAdd39, chkAdd40, chkAdd41,chkAdd42, chkAdd43, chkAdd44, chkAdd45, chkAdd46, chkAdd47, chkAdd48, chkAdd49, chkAdd50, chkAdd51, chkAdd52,chkAdd53, chkAdd54, chkAdd55, chkAdd56, chkAdd57, chkAdd58, chkAdd59, chkAdd60,chkAdd61, chkAdd62,chkAdd63,chkAdd64, chkAdd65, chkAdd66,chkAdd67,chkAdd68,chkAdd69,chkAdd70,chkAdd71,chkAdd72,chkAdd73,chkAdd74,chkAdd75,chkAdd76,chkAdd77,chkAdd78,chkAdd79,chkAdd80,chkAdd81,chkAdd82,chkAdd83,chkAdd84,chkAdd85,chkAdd86,chkAdd87,chkAdd88,chkAdd89,chkAdd90,chkAdd91,chkAdd92,chkAdd93,chkAdd94,chkAdd95,chkAdd96};
			CheckBox[] ChkEdit={chkEdit1, chkEdit2, chkEdit3, chkEdit4, chkEdit5, chkEdit6, chkEdit7, chkEdit8, chkEdit9, chkEdit10, chkEdit11, chkEdit12, chkEdit13, chkEdit14, chkEdit15,chkEdit16, chkEdit17, chkEdit18, chkEdit19, chkEdit20, chkEdit21, chkEdit22, chkEdit23, chkEdit24, chkEdit25,chkEdit26, chkEdit27, chkEdit28, chkEdit29, chkEdit30, chkEdit31, chkEdit32, chkEdit33, chkEdit34, chkEdit35, chkEdit36, chkEdit37, chkEdit38, chkEdit39, chkEdit40, chkEdit41,chkEdit42, chkEdit43,chkEdit44, chkEdit45, chkEdit46, chkEdit47, chkEdit48, chkEdit49, chkEdit50, chkEdit51, chkEdit52, chkEdit53, chkEdit54, chkEdit55, chkEdit56, chkEdit57, chkEdit58, chkEdit59, chkEdit60,chkEdit61, chkEdit62,chkEdit63,chkEdit64,chkEdit65,chkEdit66,chkEdit67,chkEdit68,chkEdit69,chkEdit70,chkEdit71,chkEdit72,chkEdit73,chkEdit74,chkEdit75,chkEdit76,chkEdit77,chkEdit78,chkEdit79,chkEdit80,chkEdit81,chkEdit82,chkEdit83,chkEdit84,chkEdit85,chkEdit86,chkEdit87,chkEdit88,chkEdit89,chkEdit90,chkEdit91, chkEdit92,chkEdit93,chkEdit94,chkEdit95,chkEdit96};
			CheckBox[] ChkDel={chkDel1, chkDel2, chkDel3, chkDel4, chkDel5,chkDel6, chkDel7, chkDel8, chkDel9, chkDel10, chkDel11, chkDel12, chkDel13, chkDel14, chkDel15,chkDel16, chkDel17, chkDel18, chkDel19, chkDel20, chkDel21, chkDel22, chkDel23, chkDel24, chkDel25,chkDel26, chkDel27, chkDel28, chkDel29, chkDel30, chkDel31, chkDel32, chkDel33, chkDel34, chkDel35, chkDel36, chkDel37, chkDel38, chkDel39, chkDel40, chkDel41,chkDel42, chkDel43,  chkDel44, chkDel45, chkDel46, chkDel47, chkDel48, chkDel49, chkDel50, chkDel51, chkDel52,chkDel53, chkDel54, chkDel55, chkDel56, chkDel57, chkDel58, chkDel59, chkDel60,chkDel61, chkDel62,chkDel63,chkDel64, chkDel65,chkDel66,chkDel67,chkDel68,chkDel69,chkDel70,chkDel71,chkDel72,chkDel73,chkDel74,chkDel75,chkDel76,chkDel77,chkDel78,chkDel79,chkDel80,chkDel81,chkDel82,chkDel83,chkDel84,chkDel85,chkDel86,chkDel87,chkDel88,chkDel89,chkDel90,chkDel91,chkDel92,chkDel93,chkDel94,chkDel95,chkDel96};
			CheckBox[] ChkAll={chkAdminSelectAll,chkmastSelectAll,chkPersonalSelectAll,chkAddSelectAll,chkDailySelectAll,chkExamSelectAll,chkCertificateSelectAll,chkhealthSelectAll,chkLabSelectAll,ChkTTMselectall,chkLibSelectAll,chkAccountSelectAll,Checkbox9,chkLogisticSelectAll,chkhostSelectAll,chkcoachSelectAll,chkAccRepSelectAll,chkCertiRepSelectAll,chkHealthrSelectAll,chklibaSelectAll,chklogistSelectAll,chkAptaSelectAll,chkSalaryRepSelectAll,chkStuReport,chkTTRepSelectAll,chkTTadjSelectAll};
			
			DropLogin.SelectedIndex=0;
			for(int i=0;i<96;i++)
			{
				ChkAdd[i].Checked=false;
				ChkEdit[i].Checked=false;
				ChkView[i].Checked=false;
				ChkDel[i].Checked=false;
			}
			for(int j=0;j<26;j++)
			{
				
				ChkAll[j].Checked=false;
			}
			
			DropName.SelectedIndex=0;
			DropLogin.SelectedIndex=0;
			TxtName.Text="";
			txtRoleName.Text="";
			txtDesc.Text="";
					
		}

		/// <summary>
		/// this method use to clear the form.
		/// </summary>
		public void clear1()
		{
			CheckBox[] ChkView={chkView1, chkView2, chkView3, chkView4, chkView5, chkView6, chkView7, chkView8, chkView9, chkView10, chkView11, chkView12, chkView13, chkView14, chkView15,chkView16, chkView17, chkView18, chkView19, chkView20, chkView21, chkView22, chkView23, chkView24, chkView25,chkView26, chkView27, chkView28, chkView29, chkView30, chkView31, chkView32, chkView33, chkView34, chkView35, chkView36, chkView37, chkView38, chkView39, chkView40, chkView41,chkView42, chkView43, chkView44, chkView45, chkView46, chkView47, chkView48, chkView49, chkView50, chkView51, chkView52,chkView53, chkView54, chkView55, chkView56, chkView57, chkView58, chkView59, chkView60,chkView61, chkView62,chkView63,chkView64,chkView65,chkView66,chkView67,chkView68,chkView69,chkView70,chkView71,chkView72,chkView73,chkView74,chkView75,chkView76,chkView77,chkView78,chkView79,chkView80,chkView81,chkView82,chkView83,chkView84,chkView85,chkView86,chkView87,chkView88,chkView89,chkView90,chkView91,chkView92,chkView93,chkView94,chkView95,chkView96};
			CheckBox[] ChkAdd={chkAdd1, chkAdd2, chkAdd3, chkAdd4, chkAdd5,chkAdd6, chkAdd7, chkAdd8, chkAdd9, chkAdd10, chkAdd11, chkAdd12, chkAdd13, chkAdd14, chkAdd15,chkAdd16, chkAdd17, chkAdd18, chkAdd19, chkAdd20, chkAdd21, chkAdd22, chkAdd23, chkAdd24, chkAdd25,chkAdd26, chkAdd27, chkAdd28, chkAdd29, chkAdd30, chkAdd31, chkAdd32, chkAdd33, chkAdd34, chkAdd35, chkAdd36, chkAdd37, chkAdd38, chkAdd39, chkAdd40, chkAdd41,chkAdd42, chkAdd43, chkAdd44, chkAdd45, chkAdd46, chkAdd47, chkAdd48, chkAdd49, chkAdd50, chkAdd51, chkAdd52,chkAdd53, chkAdd54, chkAdd55, chkAdd56, chkAdd57, chkAdd58, chkAdd59, chkAdd60,chkAdd61, chkAdd62,chkAdd63,chkAdd64, chkAdd65, chkAdd66,chkAdd67,chkAdd68,chkAdd69,chkAdd70,chkAdd71,chkAdd72,chkAdd73,chkAdd74,chkAdd75,chkAdd76,chkAdd77,chkAdd78,chkAdd79,chkAdd80,chkAdd81,chkAdd82,chkAdd83,chkAdd84,chkAdd85,chkAdd86,chkAdd87,chkAdd88,chkAdd89,chkAdd90,chkAdd91,chkAdd92,chkAdd93,chkAdd94,chkAdd95,chkAdd96};
			CheckBox[] ChkEdit={chkEdit1, chkEdit2, chkEdit3, chkEdit4, chkEdit5, chkEdit6, chkEdit7, chkEdit8, chkEdit9, chkEdit10, chkEdit11, chkEdit12, chkEdit13, chkEdit14, chkEdit15,chkEdit16, chkEdit17, chkEdit18, chkEdit19, chkEdit20, chkEdit21, chkEdit22, chkEdit23, chkEdit24, chkEdit25,chkEdit26, chkEdit27, chkEdit28, chkEdit29, chkEdit30, chkEdit31, chkEdit32, chkEdit33, chkEdit34, chkEdit35, chkEdit36, chkEdit37, chkEdit38, chkEdit39, chkEdit40, chkEdit41,chkEdit42, chkEdit43,chkEdit44, chkEdit45, chkEdit46, chkEdit47, chkEdit48, chkEdit49, chkEdit50, chkEdit51, chkEdit52, chkEdit53, chkEdit54, chkEdit55, chkEdit56, chkEdit57, chkEdit58, chkEdit59, chkEdit60,chkEdit61, chkEdit62,chkEdit63,chkEdit64,chkEdit65,chkEdit66,chkEdit67,chkEdit68,chkEdit69,chkEdit70,chkEdit71,chkEdit72,chkEdit73,chkEdit74,chkEdit75,chkEdit76,chkEdit77,chkEdit78,chkEdit79,chkEdit80,chkEdit81,chkEdit82,chkEdit83,chkEdit84,chkEdit85,chkEdit86,chkEdit87,chkEdit88,chkEdit89,chkEdit90,chkEdit91, chkEdit92,chkEdit93,chkEdit94,chkEdit95,chkEdit96};
			CheckBox[] ChkDel={chkDel1, chkDel2, chkDel3, chkDel4, chkDel5,chkDel6, chkDel7, chkDel8, chkDel9, chkDel10, chkDel11, chkDel12, chkDel13, chkDel14, chkDel15,chkDel16, chkDel17, chkDel18, chkDel19, chkDel20, chkDel21, chkDel22, chkDel23, chkDel24, chkDel25,chkDel26, chkDel27, chkDel28, chkDel29, chkDel30, chkDel31, chkDel32, chkDel33, chkDel34, chkDel35, chkDel36, chkDel37, chkDel38, chkDel39, chkDel40, chkDel41,chkDel42, chkDel43,  chkDel44, chkDel45, chkDel46, chkDel47, chkDel48, chkDel49, chkDel50, chkDel51, chkDel52,chkDel53, chkDel54, chkDel55, chkDel56, chkDel57, chkDel58, chkDel59, chkDel60,chkDel61, chkDel62,chkDel63,chkDel64, chkDel65,chkDel66,chkDel67,chkDel68,chkDel69,chkDel70,chkDel71,chkDel72,chkDel73,chkDel74,chkDel75,chkDel76,chkDel77,chkDel78,chkDel79,chkDel80,chkDel81,chkDel82,chkDel83,chkDel84,chkDel85,chkDel86,chkDel87,chkDel88,chkDel89,chkDel90,chkDel91,chkDel92,chkDel93,chkDel94,chkDel95,chkDel96};
			CheckBox[] ChkAll={chkAdminSelectAll,chkmastSelectAll,chkPersonalSelectAll,chkAddSelectAll,chkDailySelectAll,chkExamSelectAll,chkCertificateSelectAll,chkhealthSelectAll,chkLabSelectAll,ChkTTMselectall,chkLibSelectAll,chkAccountSelectAll,Checkbox9,chkLogisticSelectAll,chkhostSelectAll,chkcoachSelectAll,chkAccRepSelectAll,chkCertiRepSelectAll,chkHealthrSelectAll,chklibaSelectAll,chklogistSelectAll,chkAptaSelectAll,chkSalaryRepSelectAll,chkStuReport,chkTTRepSelectAll,chkTTadjSelectAll};
			for(int i=0;i<96;i++)
			{
				ChkAdd[i].Checked=false;
				ChkEdit[i].Checked=false;
				ChkView[i].Checked=false;
				ChkDel[i].Checked=false;
			}
			for(int j=0;j<26;j++)
			{
				
				ChkAll[j].Checked=false;
			}
		}

		/// <summary>
		/// this Method use to Save privileges of each user in to privileges table.
		/// </summary>
		private void btnEditSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(DropLogin.SelectedIndex==0)
				{
					MessageBox.Show("Please select the login name");
				}
				else
				{
					SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
					int Modules=11;
					int aa=0;

					int[] SubModules={5,11,5,11,3,3,8,3,4,1,42};
					CheckBox[] ChkView={chkView1, chkView2, chkView3, chkView4, chkView5, chkView6, chkView7, chkView8, chkView9, chkView10, chkView11, chkView12, chkView13, chkView14, chkView15,chkView16, chkView17, chkView18, chkView19, chkView20, chkView21, chkView22, chkView23, chkView24, chkView25,chkView26, chkView27, chkView28, chkView29, chkView30, chkView31, chkView32, chkView33, chkView34, chkView35, chkView36, chkView37, chkView38, chkView39, chkView40, chkView41,chkView42, chkView43, chkView44, chkView45, chkView46, chkView47, chkView48, chkView49, chkView50, chkView51, chkView52,chkView53, chkView54, chkView55, chkView56, chkView57, chkView58, chkView59, chkView60,chkView61, chkView62,chkView63,chkView64,chkView65,chkView66,chkView67,chkView68,chkView69,chkView70,chkView71,chkView72,chkView73,chkView74,chkView75,chkView76,chkView77,chkView78,chkView79,chkView80,chkView81,chkView82,chkView83,chkView84,chkView85,chkView86,chkView87,chkView88,chkView89,chkView90,chkView91,chkView92,chkView93,chkView94,chkView95,chkView96};
					CheckBox[] ChkAdd={chkAdd1, chkAdd2, chkAdd3, chkAdd4, chkAdd5,chkAdd6, chkAdd7, chkAdd8, chkAdd9, chkAdd10, chkAdd11, chkAdd12, chkAdd13, chkAdd14, chkAdd15,chkAdd16, chkAdd17, chkAdd18, chkAdd19, chkAdd20, chkAdd21, chkAdd22, chkAdd23, chkAdd24, chkAdd25,chkAdd26, chkAdd27, chkAdd28, chkAdd29, chkAdd30, chkAdd31, chkAdd32, chkAdd33, chkAdd34, chkAdd35, chkAdd36, chkAdd37, chkAdd38, chkAdd39, chkAdd40, chkAdd41,chkAdd42, chkAdd43, chkAdd44, chkAdd45, chkAdd46, chkAdd47, chkAdd48, chkAdd49, chkAdd50, chkAdd51, chkAdd52,chkAdd53, chkAdd54, chkAdd55, chkAdd56, chkAdd57, chkAdd58, chkAdd59, chkAdd60,chkAdd61, chkAdd62,chkAdd63,chkAdd64, chkAdd65, chkAdd66,chkAdd67,chkAdd68,chkAdd69,chkAdd70,chkAdd71,chkAdd72,chkAdd73,chkAdd74,chkAdd75,chkAdd76,chkAdd77,chkAdd78,chkAdd79,chkAdd80,chkAdd81,chkAdd82,chkAdd83,chkAdd84,chkAdd85,chkAdd86,chkAdd87,chkAdd88,chkAdd89,chkAdd90,chkAdd91,chkAdd92,chkAdd93,chkAdd94,chkAdd95,chkAdd96};
					CheckBox[] ChkEdit={chkEdit1, chkEdit2, chkEdit3, chkEdit4, chkEdit5, chkEdit6, chkEdit7, chkEdit8, chkEdit9, chkEdit10, chkEdit11, chkEdit12, chkEdit13, chkEdit14, chkEdit15,chkEdit16, chkEdit17, chkEdit18, chkEdit19, chkEdit20, chkEdit21, chkEdit22, chkEdit23, chkEdit24, chkEdit25,chkEdit26, chkEdit27, chkEdit28, chkEdit29, chkEdit30, chkEdit31, chkEdit32, chkEdit33, chkEdit34, chkEdit35, chkEdit36, chkEdit37, chkEdit38, chkEdit39, chkEdit40, chkEdit41,chkEdit42, chkEdit43,chkEdit44, chkEdit45, chkEdit46, chkEdit47, chkEdit48, chkEdit49, chkEdit50, chkEdit51, chkEdit52, chkEdit53, chkEdit54, chkEdit55, chkEdit56, chkEdit57, chkEdit58, chkEdit59, chkEdit60,chkEdit61, chkEdit62,chkEdit63,chkEdit64,chkEdit65,chkEdit66,chkEdit67,chkEdit68,chkEdit69,chkEdit70,chkEdit71,chkEdit72,chkEdit73,chkEdit74,chkEdit75,chkEdit76,chkEdit77,chkEdit78,chkEdit79,chkEdit80,chkEdit81,chkEdit82,chkEdit83,chkEdit84,chkEdit85,chkEdit86,chkEdit87,chkEdit88,chkEdit89,chkEdit90,chkEdit91, chkEdit92,chkEdit93,chkEdit94,chkEdit95,chkEdit96};
					CheckBox[] ChkDel={chkDel1, chkDel2, chkDel3, chkDel4, chkDel5,chkDel6, chkDel7, chkDel8, chkDel9, chkDel10, chkDel11, chkDel12, chkDel13, chkDel14, chkDel15,chkDel16, chkDel17, chkDel18, chkDel19, chkDel20, chkDel21, chkDel22, chkDel23, chkDel24, chkDel25,chkDel26, chkDel27, chkDel28, chkDel29, chkDel30, chkDel31, chkDel32, chkDel33, chkDel34, chkDel35, chkDel36, chkDel37, chkDel38, chkDel39, chkDel40, chkDel41,chkDel42, chkDel43,  chkDel44, chkDel45, chkDel46, chkDel47, chkDel48, chkDel49, chkDel50, chkDel51, chkDel52,chkDel53, chkDel54, chkDel55, chkDel56, chkDel57, chkDel58, chkDel59, chkDel60,chkDel61, chkDel62,chkDel63,chkDel64, chkDel65,chkDel66,chkDel67,chkDel68,chkDel69,chkDel70,chkDel71,chkDel72,chkDel73,chkDel74,chkDel75,chkDel76,chkDel77,chkDel78,chkDel79,chkDel80,chkDel81,chkDel82,chkDel83,chkDel84,chkDel85,chkDel86,chkDel87,chkDel88,chkDel89,chkDel90,chkDel91,chkDel92,chkDel93,chkDel94,chkDel95,chkDel96};

					for(int ii=0;ii<Modules;ii++)
					{
						for(int jj=0;jj<SubModules[ii];jj++)
						{				
							obj.LoginName=DropLogin.SelectedItem.Text.ToString().Trim();
							obj.RoleName=txtRoleName.Text.ToString().Trim();
							obj.Description=txtDesc.Text.ToString().Trim();
							obj.Module_id=System.Convert.ToString(ii+1);
							obj.SubModule_id=System.Convert.ToString(jj+1);
							if(ChkView[aa].Checked)
								obj.View_flg="1";
							else
								obj.View_flg="0";
							if(ChkAdd[aa].Checked)
								obj.Add_flg="1";
							else
								obj.Add_flg="0";
							if(ChkEdit[aa].Checked)
								obj.Edit_flg="1";
							else
								obj.Edit_flg="0";
							if(ChkDel[aa].Checked)
								obj.Delete_flg="1";
							else
								obj.Delete_flg="0";
							obj.UpdatePrevileges();
							aa++;
						}
					}
					TxtName.Visible=true;
					btnSave.Visible=true;
					btnEditSave.Visible=false;
					MessageBox.Show("Privileges Successfully Updated"); 
					CreateLogFiles.ErrorLog(" Form :Roles_Privileges.aspx,Method  btnUpdate_Click,  Privileges update for LoginName: "+DropLogin.SelectedItem.Text.ToString().Trim()+" and Roll Name "+txtRoleName.Text.ToString().Trim()+", Userid :  "+ Session["Password"].ToString()   );							
					clear();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :Roles_Privileges.aspx,Method  btnUpdate_Click,  Exception: "+ex.Message+" , Userid :  "+ Session["Password"].ToString()   );		
			} 
		}

		/// <summary>
		/// This Method Not in use.
		/// </summary>
		private void chkSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}
		

		/// <summary>
		/// Student Daily Activity Select All Check Box...
		/// </summary>
		private void chkDailySelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkStuDActivity ={chkView25, chkView26,chkAdd25, chkAdd26,chkEdit25, chkEdit26,chkDel25, chkDel26};
			
			if(chkDailySelectAll.Checked==true)
			{
				for(int i=0;i<chkStuDActivity.Length;i++)
				{
					chkStuDActivity[i].Checked=true;
				}
			}
			else if(chkDailySelectAll.Checked==false)
			{
				for(int i=0;i<chkStuDActivity.Length;i++)
				{
					chkStuDActivity[i].Checked=false;
				}
			}
		}

		/// <summary>
		/// Student Examination Select All Check Box...
		/// </summary>
		private void chkExamSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkStuExam ={chkView27, chkView28,chkAdd27, chkAdd28,chkEdit27, chkEdit28,chkDel27, chkDel28};
			if(chkExamSelectAll.Checked==true)
			{
				for(int i=0;i<chkStuExam.Length;i++)
				{
					chkStuExam[i].Checked=true;
				}
			}
			else if(chkExamSelectAll.Checked==false)
			{
				for(int i=0;i<chkStuExam.Length;i++)
				{
					chkStuExam[i].Checked=false;
				}
			}
		}

		/// <summary>
		/// Student Certificate Select All Check Box...
		/// </summary>
		private void chkCertificateSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			
			CheckBox[] chkCertificate ={chkView29,chkView30,chkAdd29,chkAdd30,chkEdit29,chkEdit30,chkDel29,chkDel30};
			
			if(chkCertificateSelectAll.Checked==true)
			{
				for(int i=0;i<chkCertificate.Length;i++)
				{
					chkCertificate[i].Checked=true;
				}
			}
			else if(chkCertificateSelectAll.Checked==false)
			{
				for(int i=0;i<chkCertificate.Length;i++)
				{
					chkCertificate[i].Checked=false;
				}
			}
		}

		/// <summary>
		/// Student PTA Select All Check Box...
		/// </summary>
		private void chkPTASelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}
		
		/// <summary>
		/// Select All Functionality in Personal Module...
		/// </summary>
		private void chkPersonalSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkPersonal ={chkView17,chkView18, chkView19,chkView20,chkView21, chkAdd17,chkAdd18,chkAdd19,chkAdd20,chkAdd21,chkEdit17,chkEdit18, chkEdit19,chkEdit20,chkEdit21,chkDel17,chkDel18, chkDel19,chkDel20,chkDel21};
			
			if(chkPersonalSelectAll.Checked==true)
			{
				for(int i=0;i<chkPersonal.Length;i++)
				{
					chkPersonal[i].Checked=true;
				}
			}
			else if(chkPersonalSelectAll.Checked==false)
			{
				for(int i=0;i<chkPersonal.Length;i++)
				{
					chkPersonal[i].Checked=false;
				}
			}
		}

		/// <summary>
		/// Select All Functionality in Time Table Module...
		/// </summary>
		private void ChkTTMselectall_CheckedChanged(object sender, System.EventArgs e)
		{
			
			CheckBox[] chkTimeTable ={chkView33, chkView34,chkView35,chkAdd33,chkAdd34,chkAdd35,chkEdit33, chkEdit34,chkEdit35,chkDel33, chkDel34,chkDel35};
			
			if(ChkTTMselectall.Checked==true)
			{
				for(int i=0;i<chkTimeTable.Length;i++)
				{
					chkTimeTable[i].Checked=true;
				}
			}
			else if(ChkTTMselectall.Checked==false)
			{
				for(int i=0;i<chkTimeTable.Length;i++)
				{
					chkTimeTable[i].Checked=false;
				}
			}
		}

		/// <summary>
		/// Select All Functionality in Logistics Module...
		/// </summary>
		private void chkLogisticSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			
			CheckBox[] chkLogistics ={chkView47,chkView48,chkView49,chkAdd47,chkAdd48,chkAdd49,chkEdit47,chkEdit48,chkEdit49,chkDel47,chkDel48,chkDel49};
			
			if(chkLogisticSelectAll.Checked==true)
			{
				for(int i=0;i<chkLogistics.Length;i++)
				{
					chkLogistics[i].Checked=true;
				}
			}
			else if(chkLogisticSelectAll.Checked==false)
			{
				for(int i=0;i<chkLogistics.Length;i++)
				{
					chkLogistics[i].Checked=false;
				}
			}
		}

		/// <summary>
		/// Select All Functionality in Library Module...
		/// </summary>
		private void chkLibSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			
			CheckBox[] chkLibrary ={chkView36,chkView37,chkView38,chkAdd36,chkAdd37,chkAdd38,chkEdit36,chkEdit37,chkEdit38,chkDel36,chkDel37,chkDel38};
			if(chkLibSelectAll.Checked==true)
			{
				for(int i=0;i<chkLibrary.Length;i++)
				{
					chkLibrary[i].Checked=true;
				}
			}
			else if(chkLibSelectAll.Checked==false)
			{
				for(int i=0;i<chkLibrary.Length;i++)
				{
					chkLibrary[i].Checked=false;
				}
			}
		}

		/// <summary>
		/// Select All Functionality in Accounts Module...
		/// </summary>
		private void chkAccountSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkAccount ={chkView39,chkView40,chkView41, chkView42,chkView43, chkView44,chkAdd39,chkAdd40,chkAdd41,chkAdd42,chkAdd43,chkAdd44,chkEdit39,chkEdit40, chkEdit41,chkEdit42, chkEdit43,chkEdit44,chkDel39,chkDel40, chkDel41,chkDel42,chkDel43,chkDel44};
			if(chkAccountSelectAll.Checked==true)
			{
				for(int i=0;i<chkAccount.Length;i++)
				{
					chkAccount[i].Checked=true;
				}
			}
			else if(chkAccountSelectAll.Checked==false)
			{
				for(int i=0;i<chkAccount.Length;i++)
				{
					chkAccount[i].Checked=false;
				}
			}
		}
		
		/// <summary>
		/// Student Select All Check Box...
		/// </summary>
		private void chkStuReport_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkStudentReport ={chkView82, chkView83,chkView84,chkView85, chkView86,chkView87,chkView88,chkView89,chkView90,chkAdd82,chkAdd83,chkAdd84,chkAdd85,chkAdd86,chkAdd87,chkAdd88,chkAdd89,chkAdd90,chkEdit82, chkEdit83,chkEdit84,chkEdit85, chkEdit86,chkEdit87,chkEdit88,chkEdit89,chkEdit90,chkDel82, chkDel83,chkDel84,chkDel85, chkDel86,chkDel87,chkDel88,chkDel89,chkDel90};
			
			if(chkStuReport.Checked==true)
			{
				for(int i=0;i<chkStudentReport.Length;i++)
				{
					chkStudentReport[i].Checked=true;
				}
			}
			else if(chkStuReport.Checked==false)
			{
				for(int i=0;i<chkStudentReport.Length;i++)
				{
					chkStudentReport[i].Checked=false;
				}
			}
		}

		/// <summary>
		/// Salary Select All Check Box...
		/// </summary>
		private void chkSalaryRepSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkSalaryReport ={chkView77,chkView78, chkView79,chkView80, chkView81,chkAdd77,chkAdd78,chkAdd79,chkAdd80,chkAdd81,chkEdit77,chkEdit78, chkEdit79,chkEdit80,chkEdit81,chkDel77,chkDel78, chkDel79,chkDel80,chkDel81};
			
			if(chkSalaryRepSelectAll.Checked==true)
			{
				for(int i=0;i<chkSalaryReport.Length;i++)
				{
					chkSalaryReport[i].Checked=true;
				}
			}
			else if(chkSalaryRepSelectAll.Checked==false)
			{
				for(int i=0;i<chkSalaryReport.Length;i++)
				{
					chkSalaryReport[i].Checked=false;
				}
			}
		}

		/// <summary>
		/// Time Table Select All Check Box...
		/// </summary>
		private void chkTTRepSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkTTReport ={chkView91,chkView92,chkView93,chkView94,chkAdd91,chkAdd92,chkAdd93,chkAdd94,chkEdit91,chkEdit92,chkEdit93,chkEdit94,chkDel91,chkDel92,chkDel93,chkDel94};
			
			if(chkTTRepSelectAll.Checked==true)
			{
				for(int i=0;i<chkTTReport.Length;i++)
				{
					chkTTReport[i].Checked=true;
				}
			}
			else if(chkTTRepSelectAll.Checked==false)
			{
				for(int i=0;i<chkTTReport.Length;i++)
				{
					chkTTReport[i].Checked=false;
				}
			}
		}
		
		/// <summary>
		/// Account Select All Check Box...
		/// </summary>
		private void chkAccRepSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkAccRep ={chkView55,chkView56,chkView57,chkView58,chkView59,chkView60,chkView61,chkView62,chkView63,chkView64,chkView65,chkView66,chkView67,chkAdd55,chkAdd56,chkAdd57,chkAdd58,chkAdd59,chkAdd60,chkAdd61,chkAdd62,chkAdd63,chkAdd64,chkAdd65,chkAdd66,chkAdd67,chkEdit55,chkEdit56,chkEdit57,chkEdit58, chkEdit59,chkEdit60,chkEdit61,chkEdit62,chkEdit63,chkEdit64,chkEdit65,chkEdit66,chkEdit67,chkDel55,chkDel56,chkDel57,chkDel58, chkDel59,chkDel60,chkDel61,chkDel62, chkDel63,chkDel64, chkDel65,chkDel66,chkDel67};
			if(chkAccRepSelectAll.Checked==true)
			{
				for(int i=0;i<chkAccRep.Length;i++)
				{
					chkAccRep[i].Checked=true;
				}
			}
			else if(chkAccRepSelectAll.Checked==false)
			{
				for(int i=0;i<chkAccRep.Length;i++)
				{
					chkAccRep[i].Checked=false;
				}
			}
		}

		/// <summary>
		/// Certificate Select All Check Box...
		/// </summary>
		private void chkCertiRepSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkCertificateRep ={chkView68,chkView69,chkAdd68,chkAdd69,chkEdit68,chkEdit69,chkDel68,chkDel69};
			if(chkCertiRepSelectAll.Checked==true)
			{
				for(int i=0;i<chkCertificateRep.Length;i++)
				{
					chkCertificateRep[i].Checked=true;
				}
			}
			else if(chkCertiRepSelectAll.Checked==false)
			{
				for(int i=0;i<chkCertificateRep.Length;i++)
				{
					chkCertificateRep[i].Checked=false;
				}
			}
		}
		
		/// <summary>
		/// Select All Functionality in Administrator Module...
		/// </summary>
		private void chkAdminSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkAdminRep ={chkView1, chkView2,chkView3,chkView4,chkView5,chkAdd1,chkAdd2,chkAdd3,chkAdd4,chkAdd5,chkEdit1, chkEdit2,chkEdit3,chkEdit4,chkEdit5,chkDel1,chkDel2,chkDel3,chkDel4,chkDel5};
			
			if(chkAdminSelectAll.Checked==true)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=true;
				}
			}
			else if(chkAdminSelectAll.Checked==false)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=false;
				}
			}
		}
		/// <summary>
		/// Select All Functionality in chkStudent...
		/// </summary>
		private void chkStudent_CheckedChanged(object sender, System.EventArgs e)
		{	
		}

		/// <summary>
		/// Select All Functionality in ChkPersonal...
		/// </summary>
		private void ChkPersonal_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}
		/// <summary>
		/// Select All Functionality in chkTimeTable...
		/// </summary>
		private void chkTimeTable_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}
		/// <summary>
		/// Select All Functionality in chkLogistic...
		/// </summary>
		private void chkLogistic_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}
		/// <summary>
		/// Select All Functionality in chkLibrary...
		/// </summary>
		private void chkLibrary_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}
		/// <summary>
		/// Select All Functionality in chkAcounts...
		/// </summary>
		private void chkAcounts_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}

		/// <summary>
		/// Select All Functionality in chkReports...
		/// </summary>
		private void chkReports_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}
		/// <summary>
		/// Select All Functionality in chkAdmin...
		/// </summary>
		private void chkAdmin_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}
		/// <summary>
		/// Select All Functionality in checkmast...
		/// </summary>
		private void checkmast_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}
		/// <summary>
		/// Select All Functionality in checkhelth...
		/// </summary>
		private void checkhelth_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}

		/// <summary>
		/// Select All Functionality in chkmastSelectAll...
		/// </summary>
		private void chkmastSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkAdminRep ={chkView6,chkView7,chkView8,chkView9,chkView10, chkView11,chkView12,chkView13,chkView14, chkView15,chkView16,chkAdd6,chkAdd7,chkAdd8,chkAdd9,chkAdd10,chkAdd11,chkAdd12,chkAdd13,chkAdd14,chkAdd15,chkAdd16,chkEdit6,chkEdit7,chkEdit8,chkEdit9,chkEdit10, chkEdit11,chkEdit12,chkEdit13,chkEdit14, chkEdit15,chkEdit16,chkDel6,chkDel7,chkDel8,chkDel9,chkDel10, chkDel11,chkDel12,chkDel13,chkDel14, chkDel15,chkDel16};
			
			if(chkmastSelectAll.Checked==true)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=true;
				}
			}
			else if(chkmastSelectAll.Checked==false)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=false;
				}
			}
		}

		/// <summary>
		/// Select All Functionality in chkhostSelectAll...
		/// </summary>
		private void chkhostSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkAdminRep ={chkView50, chkView51,chkView52,chkView53,chkAdd50,chkAdd51,chkAdd52,chkAdd53,chkEdit50,chkEdit51,chkEdit52,chkEdit53,chkDel50,chkDel51,chkDel52,chkDel53};
			
			if(chkhostSelectAll.Checked==true)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=true;
				}
			}
			else if(chkhostSelectAll.Checked==false)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=false;
				}
			}
		}
		/// <summary>
		/// Select All Functionality in chkAddSelectAll...
		/// </summary>
		private void chkAddSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkAdminRep ={chkView22, chkView23,chkView24,chkAdd22,chkAdd23,chkAdd24,chkEdit22, chkEdit23,chkEdit24,chkDel22, chkDel23,chkDel24};
			if(chkAddSelectAll.Checked==true)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=true;
				}
			}
			else if(chkAddSelectAll.Checked==false)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=false;
				}
			}
		}
		/// <summary>
		/// Select All Functionality in chkhealthSelectAll...
		/// </summary>
		private void chkhealthSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkAdminRep ={chkView31,chkAdd31,chkEdit31,chkDel31};
			if(chkhealthSelectAll.Checked==true)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=true;
				}
			}
			else if(chkhealthSelectAll.Checked==false)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=false;
				}
			}
		}
		/// <summary>
		/// Select All Functionality in chkLabSelectAll...
		/// </summary>
		private void chkLabSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkAdminRep ={chkView32,chkAdd32,chkEdit32,chkDel32};
			if(chkLabSelectAll.Checked==true)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=true;
				}
			}
			else if(chkLabSelectAll.Checked==false)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=false;
				}
			}
		}
		/// <summary>
		/// Select All Functionality in chkcoachSelectAll...
		/// </summary>
		private void chkcoachSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkAdminRep ={chkView54,chkAdd54,chkEdit54,chkDel54};
			if(chkcoachSelectAll.Checked==true)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=true;
				}
			}
			else if(chkcoachSelectAll.Checked==false)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=false;
				}
			}
		}
		/// <summary>
		/// Select All Functionality in chkHealthrSelectAll...
		/// </summary>
		private void chkHealthrSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkAdminRep ={chkView70,chkView71,chkAdd70,chkAdd71,chkEdit70,chkEdit71,chkDel70,chkDel71};
			if(chkHealthrSelectAll.Checked==true)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=true;
				}
			}
			else if(chkHealthrSelectAll.Checked==false)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=false;
				}
			}
		}

		private void Checkbox113_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}
		/// <summary>
		/// Select All Functionality in chkAptaSelectAll...
		/// </summary>
		private void chkAptaSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkAdminRep ={chkView75,chkView76,chkAdd75,chkAdd76,chkEdit75,chkEdit76,chkDel75,chkDel76};
			if(chkAptaSelectAll.Checked==true)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=true;
				}
			}
			else if(chkAptaSelectAll.Checked==false)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=false;
				}
			}
		}

		/// <summary>
		/// Select All Functionality in checkecoach...
		/// </summary>
		private void checkecoach_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}
		/// <summary>
		/// Select All Functionality in chklibaSelectAll...
		/// </summary>
		private void chklibaSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkAdminRep ={chkView72,chkView73,chkAdd72,chkAdd73,chkEdit72,chkEdit73,chkDel72,chkDel73};
			if(chklibaSelectAll.Checked==true)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=true;
				}
			}
			else if(chklibaSelectAll.Checked==false)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=false;
				}
			}
		
		}
		/// <summary>
		/// Select All Functionality in chklogistSelectAll...
		/// </summary>
		private void chklogistSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkAdminRep ={chkView74,chkAdd74,chkEdit74,chkDel74};
			if(chklogistSelectAll.Checked==true)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=true;
				}
			}
			else if(chklogistSelectAll.Checked==false)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=false;
				}
			}
		}
		/// <summary>
		/// Select All Functionality in chkTTadjSelectAll...
		/// </summary>
		private void chkTTadjSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkAdminRep ={chkView95,chkView96,chkAdd95,chkAdd96,chkEdit95,chkEdit96,chkDel95,chkDel96};
			if(chkTTadjSelectAll.Checked==true)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=true;
				}
			}
			else if(chkTTadjSelectAll.Checked==false)
			{
				for(int i=0;i<chkAdminRep.Length;i++)
				{
					chkAdminRep[i].Checked=false;
				}
			}
		}
		/// <summary>
		/// Select All Functionality in chkReports...
		/// </summary>
		private void Checkbox9_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox[] chkAccount ={chkView45,chkView46,chkAdd45,chkAdd46,chkEdit45, chkEdit46,chkDel45, chkDel46};
			if(Checkbox9.Checked==true)
			{
				for(int i=0;i<chkAccount.Length;i++)
				{
					chkAccount[i].Checked=true;
				}
			}
			else if(Checkbox9.Checked==false)
			{
				for(int i=0;i<chkAccount.Length;i++)
				{
					chkAccount[i].Checked=false;
				}
			}
		}
	}
}

		

		
			
	

		
	



	

