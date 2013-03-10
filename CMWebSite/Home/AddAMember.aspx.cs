using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace CM
{
    public partial class AddAMember : System.Web.UI.Page
    {
        DataAccess da;

        public string szFamilyID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["FamilyID"] != null && Request.QueryString["homePhone"] != null && Request.QueryString["MemberTable"] != null)
                {
                    szFamilyID = Request.QueryString["FamilyID"];
                    populateMemberInfo();
                }
            }
        }

        private void populateMemberInfo()
        {
            string strFamilyID = Request.QueryString["FamilyID"].ToString();

            string strHomePhone = Request.QueryString["homePhone"].ToString();
            

            string strMemberTable = Request.QueryString["MemberTable"].ToString();

            da = new DataAccess();

            string strFellowship = da.GetFellowshipName(Convert.ToInt32( strFamilyID));

            // now get member details

            if (strMemberTable == "A")
            {
                txtHomePhone.Text = strHomePhone;
                txtFellowship.Text = strFellowship;
                
            }
            else
            {
                  
                tdBusinessPhone.Visible = false;
                tdCellPhone.Visible = false;
                tdHomePhone.Visible = false;
                tdFellowship.Visible = false;

                tdPhone.Visible = true;
            }


                
                
            rdoActive.Checked = true;
              
            rdoChristainNo.Checked = true;
                
            rdoCharterMemberNo.Checked = true;
     
            rdoShowinDirectoryYes.Checked = true;
             

    

        }

    }
}