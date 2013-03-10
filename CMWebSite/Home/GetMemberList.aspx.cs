using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CM
{
    public partial class GetMemberList : System.Web.UI.Page
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

            DataTable dtListMember = new DataTable();

            da = new DataAccess();

            try
            {
                if (Request.QueryString["MemberStatus"] != null)
                {
                    string strMemberStatus = String.Empty;
                    strMemberStatus = Request.QueryString["MemberStatus"].ToString().ToLower().Trim();
                    dtListMember = da.GetMemberList(strMemberStatus);
                }
            }
            catch (Exception ex)
            {

            }
            reportRepeater.DataSource = dtListMember;
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