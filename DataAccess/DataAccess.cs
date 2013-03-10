using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;


namespace CM
{
    public class DataAccess
    {
        StringBuilder stringBuilder;
        private string ChurchManagementConnectionString;

        public DataAccess()
        {
            ChurchManagementConnectionString = ConfigurationManager.ConnectionStrings["ChurchManagementConnectionString"].ToString();
        }

        public DataTable GetSelectDataTable(string queryString, string connectionString)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = connectionString;
                string sql = queryString;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in DataAcesss: GetSelectDataTable()", ex);
            }
            finally
            {
                conn.Close();
            }

        }

        private string GetSelectScalar(string queryString, string connectionString)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = connectionString;
                string sql = queryString;
                string result = string.Empty;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                conn.Open();
                Object obj = cmd.ExecuteScalar();
                result = (obj == null ? "" : obj.ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in DataAcesss: GetSelectScalar()", ex);
            }
            finally
            {
                conn.Close();
            }
        }


        /// <summary>
        /// Generic method used to insert data into database
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="connectionString"></param>
        private void SetInsertData(string queryString, string connectionString)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = connectionString;

                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = queryString;
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error In DataAccess: SetInsertData()", ex);
            }
            finally
            {
                conn.Close();
            }

        }

        public DataTable GetFamilyList(string strFamilyStatus)
        {
            DataTable dtFamilyList = new DataTable();

            try
            {
                // Get data from the Hamilton Stoage Database
                stringBuilder = new StringBuilder();

                stringBuilder.Remove(0, stringBuilder.Length);
                stringBuilder.Append("Select *, Street_Address + ', ' + Town + '. ' + State + '. ' + ZipCode + ', ' + Country as Address from  Family (nolock) ");


                if (!String.IsNullOrEmpty(strFamilyStatus))
                {
                    if (strFamilyStatus == "yes")
                    {
                        stringBuilder.Append("where isactive = 1 or isactive is null");
                    }
                    else if (strFamilyStatus == "no")
                    {
                        stringBuilder.Append("where isactive = 0");
                    }
                }
                dtFamilyList = GetSelectDataTable(stringBuilder.ToString(), ChurchManagementConnectionString);
            }
            catch (Exception ex)
            {
            
            }

            return dtFamilyList;

        }

        public DataTable GetFamilyBasicInfo(int intFamilyId)
        {
            DataTable dtFamilyInfo = new DataTable();

            try
            {
                // Get data from the Hamilton Stoage Database
                stringBuilder = new StringBuilder();

                stringBuilder.Remove(0, stringBuilder.Length);
                stringBuilder.Append("Select * from  Family (nolock) ");

                stringBuilder.Append(String.Format("where familyid = {0}", intFamilyId));


                dtFamilyInfo = GetSelectDataTable(stringBuilder.ToString(), ChurchManagementConnectionString);
            }
            catch (Exception ex)
            {

            }

            return dtFamilyInfo;

        }

        public DataTable GetFamilyMemberList(int intFamilyId)
        {
            DataTable dtFamilyMemberList = new DataTable();

            try
            {
                // Get data from the Hamilton Stoage Database
                stringBuilder = new StringBuilder();

                stringBuilder.Remove(0, stringBuilder.Length);
                stringBuilder.Append("select cm.FamilyID, cm.First_name + ' ' + cm.Last_Name as name, cm.sex, cm.PersonID, 'A' as MemberTable, cm.Home_Phone, cm.Email, cm.isChristian, cm.isActive ");

                stringBuilder.Append(String.Format("from churchmember cm (nolock) where familyid = {0}", intFamilyId));

                stringBuilder.Append("union select cl.FamilyID, cl.First_name + ' ' + cl.Last_Name as Name, cl.sex, cl.PersonID, 'C' as MemberTable, '_' as Home_Phone, cl.Email, cl.isChristian, cl.isActive ");

                stringBuilder.Append(String.Format("from Childrenlist cl (nolock)  where familyid = {0}", intFamilyId));

              
                dtFamilyMemberList = GetSelectDataTable(stringBuilder.ToString(), ChurchManagementConnectionString);
            }
            catch (Exception ex)
            {

            }

            return dtFamilyMemberList;

        }

        public bool UpdateFaimlyInfo(int intFamilyId, string strFamilyLastNames, string strStreet_Address, string strTown, string strState, string strZipCode,
            string strCountry, string strPhone, int isActive)
        {
            bool isUpdateFamilySucceeded = false;

            stringBuilder = new StringBuilder();

            stringBuilder.Remove(0, stringBuilder.Length);

            stringBuilder.Append("update Family ");
          
            stringBuilder.Append(String.Format("Set FamilyLastNames = '{0}', Street_Address = '{1}', Town = '{2}', State = '{3}', ZipCode = '{4}', ", strFamilyLastNames, strStreet_Address,  strTown, strState, strZipCode));

            stringBuilder.Append(String.Format("Country = '{0}', Phone = '{1}',  isActive = {2} ",  strCountry, strPhone, isActive));
     
            stringBuilder.Append(String.Format("where FamilyID = {0}", intFamilyId));
   
            SetInsertData(stringBuilder.ToString(), ChurchManagementConnectionString);

            isUpdateFamilySucceeded = true;

            return isUpdateFamilySucceeded;
        }

        public DataTable GetMemberDetails(int intFamilyId, int PersonID, string MemberTable)
        {
            DataTable dtMemberDetails = new DataTable();

            try
            {
                string strTableName = "ChurchMember";

                if (MemberTable.ToUpper().Trim() == "C")
                {
                    strTableName = "ChildrenList";
                }
                // Get data from the Hamilton Stoage Database
                stringBuilder = new StringBuilder();

                stringBuilder.Remove(0, stringBuilder.Length);

                if (MemberTable.ToUpper().Trim() == "C")
                {
                    stringBuilder.Append(String.Format("select * from {0}  where familyid = {1} and  PersonId = {2}", strTableName, intFamilyId, PersonID));
                }
                else
                {
                    stringBuilder.Append(String.Format("select cm.*, fs.Fellowship from {0} cm join Fellowship fs on cm.fellowshipid = fs.fellowshipId  where familyid = {1} and  PersonId = {2}", strTableName, intFamilyId, PersonID));
                }


                dtMemberDetails = GetSelectDataTable(stringBuilder.ToString(), ChurchManagementConnectionString);
            }
            catch (Exception ex)
            {

            }

            return dtMemberDetails;

        }

        public bool UpdateChurchMember(int PersonID, string lastName, string firstName, string middleInitial, string gender, string DOB, string homePhone, string cellPhone, string businessPhone, string Email, string Fellowship,
           int bChristain, int bCharterMember,int bShowinDirectory, int bActive) 
        {
            bool isUpdateFamilySucceeded = false;


            stringBuilder = new StringBuilder();

            stringBuilder.Remove(0, stringBuilder.Length);

            stringBuilder.Append("update ChurchMember ");

            stringBuilder.Append(String.Format("Set Last_Name = '{0}', First_Name = '{1}', MiddlelInitial = '{2}', Sex = '{3}',  ", lastName, firstName, middleInitial, gender));

            //stringBuilder.Append(String.Format("Set Last_Name = '{0}', First_Name = '{1}', MiddlelInitial = '{2}', Sex = '{3}', DOB = Convert(smalldatetime, '{4}', 101), ", lastName, firstName, middleInitial, gender, DOB));

            stringBuilder.Append(String.Format("Home_Phone = '{0}', Cell_Phone = '{1}', Business_Phone = '{2}', Email = '{3}', FellowshipID = (select fellowshipid  from Fellowship where Fellowship = '{4}'), ", homePhone, cellPhone, businessPhone, Email, Fellowship));

            stringBuilder.Append(String.Format("isChristian = {0}, isChartMember = {1},  isShowInDirectory = {2}, isActive = {3} ", bChristain, bCharterMember, bShowinDirectory, bActive));

            stringBuilder.Append(String.Format("where PersonID = {0}", PersonID));

            SetInsertData(stringBuilder.ToString(), ChurchManagementConnectionString);

            isUpdateFamilySucceeded = true;

            return isUpdateFamilySucceeded;
        }

        public bool AddAdultChurchMember(int FamilyID, string lastName, string firstName, string middleInitial, string gender, string DOB, string homePhone, string cellPhone, string businessPhone, string Email, string Fellowship,
         int bChristain, int bCharterMember, int bShowinDirectory, int bActive)
        {
            bool isAddMemberSucceeded = false;


            stringBuilder = new StringBuilder();

            stringBuilder.Remove(0, stringBuilder.Length);

            stringBuilder.Append("INSERT INTO ChurchMember(FamilyID,Last_Name,First_Name,MiddlelInitial,Sex,DOB,Home_Phone,Cell_Phone,Business_Phone, ");

            stringBuilder.Append("Email,FellowshipID,isChristian,isChartMember,isShowInDirectory,isActive)  VALUES ");

            stringBuilder.Append(String.Format("{0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}',  ", FamilyID, lastName, firstName, middleInitial,  gender,  DOB,  homePhone,  cellPhone,  businessPhone));

            stringBuilder.Append(String.Format("{0}, '{1}', {2}, {3}, {4}, {5'",  Email, Fellowship,  bChristain, bCharterMember,  bShowinDirectory, bActive));
           
            SetInsertData(stringBuilder.ToString(), ChurchManagementConnectionString);

            isAddMemberSucceeded = true;

            return isAddMemberSucceeded;
        }


        public string GetFellowshipName(int FamilyID)
        {
            string strRunStatus = String.Empty;

            try
            {
                // Get data from the Hamilton Stoage Database
                stringBuilder = new StringBuilder();

                stringBuilder.Remove(0, stringBuilder.Length);

                stringBuilder.Append("Select Fellowship from Fellowship where fellowshipID in (select top 1 FellowshipID from ChurchMember ");
                stringBuilder.Append(String.Format("where FamilyID = {0})", FamilyID));

                strRunStatus = GetSelectScalar(stringBuilder.ToString(), ChurchManagementConnectionString);

            }
            catch (Exception ex)
            {
                throw new Exception("Error In DataAccesss.GetRunStutus()", ex);
            }

            return strRunStatus;
        }

        public DataTable GetMemberList(string strMemberStatus)
        {
            DataTable dtMemberList = new DataTable();

            try
            {
                // Get data from the Hamilton Stoage Database
                stringBuilder = new StringBuilder();

                stringBuilder.Remove(0, stringBuilder.Length);
                stringBuilder.Append("select cm.FamilyID, cm.First_name + ' ' + cm.Last_Name as name, cm.sex, cm.PersonID, 'A' as MemberTable, cm.Home_Phone, cm.Email, cm.isChristian, cm.isActive ");

                stringBuilder.Append("from churchmember cm (nolock)  ");

                if (!String.IsNullOrEmpty(strMemberStatus))
                {
                    if (strMemberStatus == "yes")
                    {
                        stringBuilder.Append("where isactive = 1 or isactive is null");
                    }
                    else if (strMemberStatus == "no")
                    {
                        stringBuilder.Append("where isactive = 0");
                    }
                }

                stringBuilder.Append(" union select cl.FamilyID, cl.First_name + ' ' + cl.Last_Name as Name, cl.sex, cl.PersonID, 'C' as MemberTable, '_' as Home_Phone, cl.Email, cl.isChristian, cl.isActive ");

                stringBuilder.Append("from Childrenlist cl (nolock) ");

                if (!String.IsNullOrEmpty(strMemberStatus))
                {
                    if (strMemberStatus == "yes")
                    {
                        stringBuilder.Append("where isactive = 1 or isactive is null");
                    }
                    else if (strMemberStatus == "no")
                    {
                        stringBuilder.Append("where isactive = 0");
                    }
                }

                dtMemberList = GetSelectDataTable(stringBuilder.ToString(), ChurchManagementConnectionString);

               
            }
            catch (Exception ex)
            {

            }

            return dtMemberList;

        }


    }
}
