using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM
{
    public partial class FamilyList : System.Web.UI.Page
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
           
            ddlListFamily.Items.Insert(0, "All");
            ddlListFamily.Items.Insert(1, "Active");
            ddlListFamily.Items.Insert(2, "Inactive");
            ddlListFamily.SelectedIndex = 0;
        }

    }
}