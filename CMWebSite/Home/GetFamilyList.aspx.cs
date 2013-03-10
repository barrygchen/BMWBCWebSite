using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CM
{
    public partial class GetFamilyList : System.Web.UI.Page
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
                if (Request.QueryString["FamilyStatus"] != null)
                {
                    string strFamilyStatus = String.Empty;
                    strFamilyStatus = Request.QueryString["FamilyStatus"].ToString().ToLower().Trim();
                    dtListFamily = da.GetFamilyList(strFamilyStatus);
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
    }
}