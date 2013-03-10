using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CM
{
    public partial class GetFamilyMemberDetails : System.Web.UI.Page
    {
        DataAccess da;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGrid();
            }
        }

        private void PopulateGrid()
        {

            DataTable dtListFamily = new DataTable();

            da = new DataAccess();

            try
            {
                if (Request.QueryString["FamilyID"] != null)
                {
                    string strFamilyID = String.Empty;
                    strFamilyID = Request.QueryString["FamilyID"].ToString().ToLower().Trim();
                    dtListFamily = da.GetFamilyMemberList(Convert.ToInt32(strFamilyID));
                }
            }
            catch (Exception ex)
            {

            }
            reportRepeater.DataSource = dtListFamily;
            reportRepeater.DataBind();

            // select distinct Convert(VARCHAR(50),  RunID) from dbo.reportmapping


        }

        protected string GetActiveStatus(string isActive)
        {
            string strActive = "Yes";

            if (!String.IsNullOrEmpty(isActive))
            {
                if (DataHelper.GetBoolean(isActive) == false)
                {
                    strActive = "No";
                }
            }


            return strActive;
        }

        protected string GetChristianStatus(string isChristian)
        {
            string strChristian = "No";

            if (!String.IsNullOrEmpty(isChristian))
            {
                if (DataHelper.GetBoolean(isChristian) == true)
                {
                    strChristian = "Yes";
                }
            }


            return strChristian;
        }
    }
}