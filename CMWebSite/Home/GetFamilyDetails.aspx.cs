using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CM
{
    public partial class GetFamilyDetails : System.Web.UI.Page
    {
        public string szFamilyID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["FamilyID"] != null)
                {
                    szFamilyID = Request.QueryString["FamilyID"].ToString();

                    // Now get the family info
                    PopulateFamily(szFamilyID);

                }
            }

        }

        private void PopulateFamily(string strFamilyID)
        {
            DataAccess da = new DataAccess();

            DataTable dtFamilyInfo = new DataTable();

            dtFamilyInfo = da.GetFamilyBasicInfo(Convert.ToInt32(strFamilyID));

            foreach (DataRow dr in dtFamilyInfo.Rows)
            {
                txtLastNames.Text = DataHelper.GetString(dr["FamilyLastNames"]);
                txtFamilyPhone.Text = DataHelper.GetString(dr["Phone"]);

                txtStreet.Text = DataHelper.GetString(dr["Street_Address"]);
                txtTown.Text = DataHelper.GetString(dr["Town"]);
                txtState.Text = DataHelper.GetString(dr["State"]);
                txtZip.Text = DataHelper.GetString(dr["ZipCode"]);


                txtCountry.Text = DataHelper.GetString(dr["Country"]);

                string strActive = DataHelper.GetString(dr["isActive"]);

                if (String.IsNullOrEmpty(strActive) || Convert.ToBoolean(strActive) == true)
                {
                    rdoActive.Checked = true;
                }
                else
                {
                    rdoInActive.Checked = true;
                }
            }

        }

        protected void btnUpdateFamily_Click(object sender, EventArgs e)
        {
            szFamilyID = Request.QueryString["FamilyID"].ToString();
            int intFamilyID = Convert.ToInt32(szFamilyID);

            DataAccess da = new DataAccess();

            // now update the family entry

            bool isUpdateFamilySucceeded = false;

            int isActive = 1;

            if (rdoInActive.Checked)
            {
                isActive = 0;
            }
            isUpdateFamilySucceeded = da.UpdateFaimlyInfo(intFamilyID, txtLastNames.Text.ToString(), txtStreet.Text.ToString(), txtTown.Text.ToString(),
                txtState.Text.ToString(), txtZip.Text.ToString(), txtCountry.Text.ToString(), txtFamilyPhone.Text.ToString(), isActive);
      
        }
    }
}