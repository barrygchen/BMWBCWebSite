using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM
{
    public partial class MemberList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setupInitialFamilyDropDown();
            }
        }

        protected void setupInitialFamilyDropDown()
        {

            ddlListMember.Items.Insert(0, "All");
            ddlListMember.Items.Insert(1, "Active");
            ddlListMember.Items.Insert(2, "Inactive");
            ddlListMember.SelectedIndex = 0;
        }
    }
}