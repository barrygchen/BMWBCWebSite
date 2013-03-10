using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CM
{
    public partial class ProcessMember : System.Web.UI.Page
    {
        DataAccess da;

        public string szFamilyID;

        public string strPersonID;

        public string szFamilyListOpen;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["FamilyID"] != null && Request.QueryString["PersonID"] != null && Request.QueryString["MemberTable"] != null && Request.QueryString["FamilyListOpen"] != null)
                {
                    szFamilyID = Request.QueryString["FamilyID"];

                    szFamilyListOpen = Request.QueryString["FamilyListOpen"].ToLower(); 
                    populateMemberInfo();
                }
            }
        }


        private void populateMemberInfo()
        {
            string strFamilyID = Request.QueryString["FamilyID"].ToString();

            strPersonID = Request.QueryString["PersonID"].ToString();

            string strMemberTable = Request.QueryString["MemberTable"].ToString();

            da = new DataAccess();

            // now get member details

            DataTable dtMemberDetails = da.GetMemberDetails(Convert.ToInt32(strFamilyID), Convert.ToInt32(strPersonID), strMemberTable);

            foreach (DataRow dr in dtMemberDetails.Rows)
            {
                txtLastName.Text = DataHelper.GetString(dr["Last_Name"]);
                txtFirstName.Text = DataHelper.GetString(dr["First_Name"]);
                txtMiddleInitial.Text = DataHelper.GetString(dr["MiddlelInitial"]);
                txtGender.Text = DataHelper.GetString(dr["Sex"]);
                txtDOB.Text = DataHelper.GetDateTime(dr["DOB"]).ToString();
                
                if (strMemberTable == "A")
                {
                    txtHomePhone.Text =  DataHelper.GetString(dr["Home_Phone"]);
                    txtCellPhone.Text =  DataHelper.GetString(dr["Cell_Phone"]);
                    txtBusinessPhone.Text =  DataHelper.GetString(dr["Business_Phone"]);
                    txtFellowship.Text = DataHelper.GetString(dr["Fellowship"]);
                }
                else
                {
                    txtPhone.Text =  DataHelper.GetString(dr["Phone"]);
                    tdBusinessPhone.Visible = false;
                    tdCellPhone.Visible = false;
                    tdHomePhone.Visible = false;
                    tdFellowship.Visible = false;

                    tdPhone.Visible = true;
                }
                
                TxtEmail.Text =  DataHelper.GetString(dr["Email"]);
   
                string strActive = DataHelper.GetString(dr["isActive"]);

                if (String.IsNullOrEmpty(strActive) || Convert.ToBoolean(strActive) == true)
                {
                    rdoActive.Checked = true;
                }
                else
                {
                    rdoInActive.Checked = true;
                }

                string strChristian = DataHelper.GetString(dr["isChristian"]);
                if (String.IsNullOrEmpty(strChristian) || Convert.ToBoolean(strChristian) == true)
                {
                    rdoChristainYes.Checked = true;
                }
                else
                {
                    rdoChristainNo.Checked = true;
                }

                string strChartMember = DataHelper.GetString(dr["isChartMember"]);
                if (String.IsNullOrEmpty(strChartMember) || Convert.ToBoolean(strChartMember) == true)
                {
                    rdoCharterMemberYes.Checked = true;
                }
                else
                {
                    rdoCharterMemberNo.Checked = true;
                }

                string strShowInDirectory = DataHelper.GetString(dr["isShowInDirectory"]);
                if (String.IsNullOrEmpty(strShowInDirectory) || Convert.ToBoolean(strShowInDirectory) == true)
                {
                    rdoShowinDirectoryYes.Checked = true;
                }
                else
                {
                    rdoShowinDirectoryNo.Checked = true;
                }


                break;
            }

        }
    }
}