using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace CM
{
    public partial class JQueryAjaxProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


     

        [WebMethod]
        public static bool UpdateChurchMember(string strPersonid, string lastName, string firstName, string middleInitial, string gender, string DOB, string homePhone, string cellPhone, string businessPhone, string Email, string Fellowship,
            string bChristain, string bCharterMember, string bShowinDirectory, string bActive) 
        {
            bool isUpdateSucceeded = false;
            DataAccess da = new DataAccess();
      
            // now update the Target Volume
            isUpdateSucceeded = da.UpdateChurchMember(Convert.ToInt32(strPersonid), lastName, firstName, middleInitial, gender, DOB, homePhone, cellPhone, businessPhone, Email, Fellowship,
                bChristain.Trim().ToLower() == "true" ? 1 : 0, bCharterMember.Trim().ToLower() == "true" ? 1 : 0, bShowinDirectory.Trim().ToLower() == "true" ? 1 : 0, bActive.Trim().ToLower() == "true" ? 1 : 0);


            return isUpdateSucceeded;
        }


        [WebMethod]
        public static bool AddAdultChurchMember(string FamilyID, string lastName, string firstName, string middleInitial, string gender, string DOB, string homePhone, string cellPhone, string businessPhone, string Email, string Fellowship,
            string bChristain, string bCharterMember, string bShowinDirectory, string bActive)
        {
            bool isAddMemberSucceeded = false;
            DataAccess da = new DataAccess();

            // now update the Target Volume
            isAddMemberSucceeded = da.AddAdultChurchMember(Convert.ToInt32(FamilyID), lastName, firstName, middleInitial, gender, DOB, homePhone, cellPhone, businessPhone, Email, Fellowship,
                bChristain.Trim().ToLower() == "true" ? 1 : 0, bCharterMember.Trim().ToLower() == "true" ? 1 : 0, bShowinDirectory.Trim().ToLower() == "true" ? 1 : 0, bActive.Trim().ToLower() == "true" ? 1 : 0);


            return isAddMemberSucceeded;
        }
    }
}