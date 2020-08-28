using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace LorrySalarySystem_dev
{
    class Library
    {
       // const string conn = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|DBLORRRYSALARY.MDF;Integrated Security=True;";
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LorrySalarySystem_dev.Properties.Settings.dbLorrrySalaryConnectionString"].ToString());
        //SqlConnection con = new SqlConnection(conn);

       

        public bool logincheck(string username, string password)
        { 
            bool check = false;
            //SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("Select * from tblUser where Name=@username and Password=@password", con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            con.Close();
            int count = ds.Tables[0].Rows.Count;
            if(count == 1)
                 {check = true;}

            return check;
        }

        public int getUserRoleID(string username)
        {
            SqlCommand cmd = new SqlCommand("sp_GetUserInfo", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
            SqlParameter RoleId = cmd.Parameters.Add("@RoleID", SqlDbType.Int);
            RoleId.Direction = ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            int i = (int)RoleId.Value;
            //int RoleID = Convert.ToInt32(cmd.Parameters["@RoleID"].Value);
            con.Close();
            return i;
            
        }
        public void insertNewUser(string username, string password, int roleID, int statusid)
        {
            //SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_InsertNewUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username.ToUpper();
            cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
            cmd.Parameters.Add("@roleid", SqlDbType.Int).Value = roleID;

            
            //string strcmd = "insert into tblUser ([Name], [Password], [StatusID]) values ('" + username +"' ,'" + password +"' ,'1' )";
            //SqlCommand cmd = new SqlCommand(strcmd, con);
            cmd.ExecuteNonQuery();
            cmd.Clone();
            con.Close();   


        }

        public void insertNewSalary( DateTime p_date, int p_driverID, int p_lorryID, int p_triptypeID, decimal p_commRate, string p_DONo, DateTime p_DODate, string p_from, string p_to, string p_goods, decimal p_qty, int p_rateID, decimal p_rate,  decimal p_amount, string p_createdBy, DateTime p_createdOn, string p_lastchangeBy, DateTime p_lastchangeOn, int p_reportheaderid, decimal p_additionalrate)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_InsertNewSalary", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = p_date;
            cmd.Parameters.AddWithValue("@DriverID", SqlDbType.Int).Value = p_driverID;
            cmd.Parameters.AddWithValue("@LorryID", SqlDbType.Int).Value = p_lorryID;
            cmd.Parameters.AddWithValue("@TripTypeID", SqlDbType.Int).Value = p_triptypeID;
            cmd.Parameters.AddWithValue("@CommissionRate", SqlDbType.Decimal).Value = p_commRate;
            cmd.Parameters.AddWithValue("@DONo", SqlDbType.NVarChar).Value = p_DONo;
            cmd.Parameters.AddWithValue("@DODate", SqlDbType.Date).Value = p_DODate;
            cmd.Parameters.AddWithValue("@From", SqlDbType.NVarChar).Value = p_from;
            cmd.Parameters.AddWithValue("@To", SqlDbType.NVarChar).Value = p_to;
            cmd.Parameters.AddWithValue("@Goods", SqlDbType.NVarChar).Value = p_goods;
            cmd.Parameters.AddWithValue("@Qty", SqlDbType.Decimal).Value = p_qty;
            cmd.Parameters.AddWithValue("@RateID", SqlDbType.Int).Value = p_rateID;
            cmd.Parameters.AddWithValue("@Rate", SqlDbType.Decimal).Value = p_rate;
            cmd.Parameters.AddWithValue("@Amount", SqlDbType.Decimal).Value = p_amount;
            cmd.Parameters.AddWithValue("@CreatedBy", SqlDbType.NVarChar).Value = p_createdBy;
            cmd.Parameters.AddWithValue("@CreatedOn", SqlDbType.NVarChar).Value = p_createdOn;
            cmd.Parameters.AddWithValue("@LastChangeBy", SqlDbType.NVarChar).Value = p_lastchangeBy;
            cmd.Parameters.AddWithValue("@LastChangeOn", SqlDbType.NVarChar).Value = p_lastchangeOn;
            cmd.Parameters.AddWithValue("@ReportHeaderID", SqlDbType.Int).Value = p_reportheaderid;
            cmd.Parameters.AddWithValue("@AdditionalRate", SqlDbType.Int).Value = p_additionalrate;
            cmd.ExecuteNonQuery();
            cmd.Clone();
            con.Close(); 
        }

        public void updateSalary(int p_id, DateTime p_date, int p_driverID, int p_lorryID, int p_triptypeID, decimal p_commRate, string p_DONo, DateTime p_DODate, string p_from, string p_to, string p_goods, decimal p_qty, int p_rateID, decimal p_rate, decimal p_amount, string p_lastchangeBy, DateTime p_lastchangeOn, int p_reportheaderid, decimal p_additionalrate)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_updateSalary", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", SqlDbType.Date).Value = p_id;
            cmd.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = p_date;
            cmd.Parameters.AddWithValue("@DriverID", SqlDbType.Int).Value = p_driverID;
            cmd.Parameters.AddWithValue("@LorryID", SqlDbType.Int).Value = p_lorryID;
            cmd.Parameters.AddWithValue("@TripTypeID", SqlDbType.Int).Value = p_triptypeID;
            cmd.Parameters.AddWithValue("@CommissionRate", SqlDbType.Decimal).Value = p_commRate;
            cmd.Parameters.AddWithValue("@DONo", SqlDbType.NVarChar).Value = p_DONo;
            cmd.Parameters.AddWithValue("@DODate", SqlDbType.Date).Value = p_DODate;
            cmd.Parameters.AddWithValue("@From", SqlDbType.NVarChar).Value = p_from;
            cmd.Parameters.AddWithValue("@To", SqlDbType.NVarChar).Value = p_to;
            cmd.Parameters.AddWithValue("@Goods", SqlDbType.NVarChar).Value = p_goods;
            cmd.Parameters.AddWithValue("@Qty", SqlDbType.Decimal).Value = p_qty;
            cmd.Parameters.AddWithValue("@RateID", SqlDbType.Int).Value = p_rateID;
            cmd.Parameters.AddWithValue("@Rate", SqlDbType.Decimal).Value = p_rate;
            cmd.Parameters.AddWithValue("@Amount", SqlDbType.Decimal).Value = p_amount;
            //cmd.Parameters.AddWithValue("@CreatedBy", SqlDbType.NVarChar).Value = p_createdBy;
            //cmd.Parameters.AddWithValue("@CreatedOn", SqlDbType.NVarChar).Value = p_createdOn;
            cmd.Parameters.AddWithValue("@LastChangeBy", SqlDbType.NVarChar).Value = p_lastchangeBy;
            cmd.Parameters.AddWithValue("@LastChangeOn", SqlDbType.NVarChar).Value = p_lastchangeOn;
            cmd.Parameters.AddWithValue("@ReportHeaderID", SqlDbType.Int).Value = p_reportheaderid;
            cmd.Parameters.AddWithValue("@AdditionalRate", SqlDbType.Int).Value = p_additionalrate;
            cmd.ExecuteNonQuery();
            cmd.Clone();
            con.Close();
        }

        public void deleteSalary(int p_id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_DeleteSalary", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", SqlDbType.Date).Value = p_id;
            cmd.ExecuteNonQuery();
            cmd.Clone();
            con.Close();
        }

        public void massDeleteSalary(string p_salary_ids)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_MassDeleteSalary", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@strid", SqlDbType.VarChar, 500).Value = p_salary_ids;

            int result = (int)cmd.ExecuteNonQuery();
            con.Close();
        }

        public bool checkUserExists(string username)
        {
            object check;

            SqlCommand cmd = new SqlCommand("select UserID from tblUser where Name = @username", con);
            cmd.Parameters.AddWithValue("@username", username);
            con.Open();
            check =  cmd.ExecuteScalar();
            con.Close();
            if(check != DBNull.Value && check != null)
            { return true;}
            else
            { return false;}
        }

        public void insertNewRate(string p_from, string p_to, decimal p_weightRate, decimal p_tripRate, int p_Status)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_InsertNewRate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@from", SqlDbType.NVarChar).Value = p_from.ToUpper();
            cmd.Parameters.AddWithValue("@to", SqlDbType.NVarChar).Value = p_to.ToUpper();
            cmd.Parameters.AddWithValue("@weightRate", SqlDbType.Decimal).Value = p_weightRate;
            cmd.Parameters.AddWithValue("@tripRate", SqlDbType.Decimal).Value = p_tripRate;
            int result = (int)cmd.ExecuteNonQuery();
            con.Close();

            //con.Open();
            //string strcmd = "insert into tblRate	([From],[To],[WeightRate],[TripRate],[StatusID]) values	('" + p_from + "','" + p_to + "','" + p_weightRate + "','" + p_tripRate + "','" + p_Status + "')";
            //SqlCommand cmd = new SqlCommand(strcmd, con);
            //cmd.ExecuteNonQuery();
            //cmd.Clone();
            //con.Close();
        }

        public bool checkRateExist(string from, string to)
        {
            object check;
            SqlCommand cmd = new SqlCommand("select RateID from tblRate where [From] = @From and [To] = @to", con);
            con.Open();
            cmd.Parameters.AddWithValue("@from", from);
            cmd.Parameters.AddWithValue("@to", to);
            check = cmd.ExecuteScalar();
            con.Close();
            if(check != DBNull.Value &&　check != null)
            { return true; }
            else
            { return false; }
        }

        public void updateRate(int rateID, string from, string to, decimal weightRate, decimal tripRate, int Status)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_UpdateRate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@rateID", SqlDbType.Int).Value = rateID;
            //cmd.Parameters.AddWithValue("@from", SqlDbType.NVarChar).Value = from;
            //cmd.Parameters.AddWithValue("@to", SqlDbType.NVarChar).Value = to;
            //cmd.Parameters.AddWithValue("@weightRate", SqlDbType.Decimal).Value = weightRate;
            //cmd.Parameters["@weightRate"].Precision = 18;
            //cmd.Parameters["@weightRate"].Scale = 2;
            //cmd.Parameters.AddWithValue("@tripRate", SqlDbType.Decimal).Value = tripRate;
            //cmd.Parameters["@tripRate"].Precision = 18;
            //cmd.Parameters["@tripRate"].Scale = 2;

            cmd.Parameters.AddWithValue("@rateID", rateID);
            cmd.Parameters.AddWithValue("@from", from.ToUpper());
            cmd.Parameters.AddWithValue("@to", to.ToUpper());
            cmd.Parameters.AddWithValue("@weightRate", weightRate);
            cmd.Parameters.AddWithValue("@tripRate", tripRate);
            cmd.Parameters.AddWithValue("@statusId", Status);
            cmd.ExecuteNonQuery();
            con.Close();

            //con.Open();
            //string strcmd = "update tblRate	set [From] = '" + from + "',	[To] = '" + to + "',	[WeightRate] = '" + weightRate + "',		[TripRate] = '" + tripRate + "', 	[StatusID] = '2' where [RateID] = '" + rateID + "' ";
            //SqlCommand cmd = new SqlCommand(strcmd, con);
            //cmd.ExecuteNonQuery();
            //cmd.Clone();
            //con.Close();
        }

        public DataTable disp_rate()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from vw_Rate order by [From], [To] asc", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable disp_Salary()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from vw_Salary order by [Date], DODate, DriverName, LorryNo, TripTypeName, [From] asc", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable disp_driver()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from vw_Driver order by DriverName asc ", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable disp_lorry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from vw_Lorry order by LorryNo asc ", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable disp_userinfo()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from vw_UserInfo order by Name asc ", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public string checkDriverExists(string driverName)
        {
            //object check;

            //SqlCommand cmd = new SqlCommand("select Id from tblDriver where DriverName = @driverName", con);
            //cmd.Parameters.AddWithValue("@driverName", driverName);
            //con.Open();
            //check = cmd.ExecuteScalar();
            //con.Close();
            //if (check != DBNull.Value && check != null)
            //{ return true; }
            //else
            //{ return false; }

            con.Open();
            SqlCommand cmd = new SqlCommand("select Id from tblDriver where DriverName = @driverName and StatusID = 1", con);
            cmd.Parameters.AddWithValue("@driverName", driverName);
            string result = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return result;
        }

        public string checkLorryExists(string p_LorryNo)
        {
            //object check;

            //SqlCommand cmd = new SqlCommand("select LorryID from tblLorry where LorryNo = @lorryNo", con);
            //cmd.Parameters.AddWithValue("@lorryNo", LorryNo);
            //con.Open();
            //check = cmd.ExecuteScalar();
            //con.Close();
            //if (check != DBNull.Value && check != null)
            //{ return true; }
            //else
            //{ return false; }

            con.Open();
            SqlCommand cmd = new SqlCommand("select LorryID from tblLorry where LorryNo = @lorryNo", con);
            cmd.Parameters.AddWithValue("@LorryNo", p_LorryNo);
            string result = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return result;
        }

        public bool checkDOExists(string p_DO)
        {
            int n;
            bool isNumeric = int.TryParse(p_DO, out n);

            if(isNumeric) //if DO is numberic, prevent duplicate DO
            { 
                object check;

                SqlCommand cmd = new SqlCommand("select DONo from vw_Salary where DONo = @p_DO", con);
                cmd.Parameters.AddWithValue("@p_DO", p_DO);
                con.Open();
                check = cmd.ExecuteScalar();
                con.Close();
                if (check != DBNull.Value && check != null)
                { return true; }
                else
                { return false; }
            }
            else //if DO is just character, return false directly
            {
                return false;
            }
        }

        public bool checkDOExistsfromID(string p_DO, int p_id)
        {
            int n;
            bool isNumeric = int.TryParse(p_DO, out n);

            if (isNumeric) //check the DO is number, then need to prevent duplicate DO and ID
            {

                object check;

                SqlCommand cmd = new SqlCommand("select ID, DONo from vw_Salary where DONo = @p_DO and ID != @p_id", con);
                cmd.Parameters.AddWithValue("@p_DO", p_DO);
                cmd.Parameters.AddWithValue("@p_id", p_id);
                con.Open();
                check = cmd.ExecuteScalar();
                con.Close();
                if (check != DBNull.Value && check != null)
                { return true; }
                else
                { return false; }
            }
            else  //if DO is not number (character only), return true directly
            { return false;  }
        }

        public void insertNewDriver(string p_driverName, string p_driverIC, int p_statusID)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_InsertNewDriver", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@driverName", SqlDbType.NVarChar).Value = p_driverName.ToUpper();
            cmd.Parameters.AddWithValue("@driverIC", SqlDbType.NVarChar).Value = p_driverIC.ToUpper();
            cmd.Parameters.AddWithValue("@statusID", SqlDbType.Int).Value = p_statusID;
            int result = (int)cmd.ExecuteNonQuery();
            con.Close();
        }

        public void insertNewLorry(string p_lorryNo, decimal p_commissionRate, int p_statusID)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_InsertNewLorry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@lorryNo", SqlDbType.NVarChar).Value = p_lorryNo.ToUpper();
            cmd.Parameters.AddWithValue("@commissionRate", SqlDbType.Decimal).Value = p_commissionRate;
            cmd.Parameters.AddWithValue("@statusID", SqlDbType.Int).Value = p_statusID;
            int result = (int)cmd.ExecuteNonQuery();
            con.Close();
        }

        public void updateDriver(int p_id, string p_driverName, string p_driverIC, int p_statusID)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_UpdateDriver", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = p_id;
            cmd.Parameters.AddWithValue("@driverName", SqlDbType.NVarChar).Value = p_driverName.ToUpper();
            cmd.Parameters.AddWithValue("@driverIC", SqlDbType.NVarChar).Value = p_driverIC;
            cmd.Parameters.AddWithValue("@statusID", SqlDbType.Int).Value = p_statusID;
            int result = (int)cmd.ExecuteNonQuery();
            con.Close();
        }
        
        public void updateLorry(int p_id, string p_lorryNo, decimal p_commissionRate, int p_statusID)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_UpdateLorry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = p_id;
            cmd.Parameters.AddWithValue("@lorryNo", SqlDbType.NVarChar).Value = p_lorryNo.ToUpper();
            cmd.Parameters.AddWithValue("@commissionRate", SqlDbType.Decimal).Value = p_commissionRate;
            cmd.Parameters.AddWithValue("@statusID", SqlDbType.Int).Value = p_statusID;
            int result = (int)cmd.ExecuteNonQuery();
            con.Close();
        }

        public void updateReportHeader(int p_id, string p_CompanyTitle, string p_CompanyAdd1, string p_CompanyAdd2, string p_CompanyAdd3, string p_Tel, string p_Fax)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_UpdateReportHeader", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = p_id;
            cmd.Parameters.AddWithValue("@CompanyTitle", SqlDbType.NVarChar).Value = p_CompanyTitle.ToString();
            cmd.Parameters.AddWithValue("@AddressLine1", SqlDbType.NVarChar).Value = p_CompanyAdd1.ToString();
            cmd.Parameters.AddWithValue("@AddressLine2", SqlDbType.NVarChar).Value = p_CompanyAdd2.ToString();
            cmd.Parameters.AddWithValue("@AddressLine3", SqlDbType.NVarChar).Value = p_CompanyAdd3.ToString();
            cmd.Parameters.AddWithValue("@Tel", SqlDbType.NVarChar).Value = p_Tel.ToString();
            cmd.Parameters.AddWithValue("@Fax", SqlDbType.NVarChar).Value = p_Fax.ToString();

            int result = (int)cmd.ExecuteNonQuery();
            con.Close();
        }

        public void updateUserRoleStatus(int p_userid, string p_username, int p_roleid, int p_statusid)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_UpdateUserRoleStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", SqlDbType.NVarChar).Value = p_userid;
            cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = p_username;
            //cmd.Parameters.AddWithValue("@password", SqlDbType.NVarChar).Value = p_password;
            cmd.Parameters.AddWithValue("@RoleID", SqlDbType.NVarChar).Value = p_roleid;
            cmd.Parameters.AddWithValue("@StatusID", SqlDbType.NVarChar).Value = p_statusid;

            int result = (int)cmd.ExecuteNonQuery();
            con.Close();
        }

        public void updateUserPassword( string p_username, string p_newpassword )
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_UpdateUserPassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@username", SqlDbType.NVarChar).Value = p_username;
            cmd.Parameters.AddWithValue("@newpassword", SqlDbType.NVarChar).Value = p_newpassword;

            int result = (int)cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable disp_ToDestination(string p_from)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select [To] from vw_Rate where [From] = @from and StatusName = 'Approved' order by [To] asc", con);
            cmd.Parameters.AddWithValue("@from", p_from);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable disp_FromDestination()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select distinct [From] from vw_Rate where StatusName = 'Approved' order by [From] asc", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public string getCommissionRate(string p_LorryNo, string p_statusName)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select top 1 [CommissionRate] from vw_Lorry where StatusName = @StatusName and LorryNo = @LorryNo", con);
            cmd.Parameters.AddWithValue("@LorryNo", p_LorryNo);
            cmd.Parameters.AddWithValue("@StatusName", p_statusName);
            string result = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return result;
           
        }

        public DataTable getTripRate(string p_from, string p_to, string p_tripTypeRate, string p_statusName)
        {
            con.Open();
            //select [TripRate] from vw_Rate where [From] = 'sitiawan' and [To] = 'kl' and [StatusName] = 'Approved'
            string sqlCommandStatement = string.Format("select [{0}], [RateID] from vw_Rate where [From] = '{1}' and [To] = '{2}' and [StatusName] = '{3}'", p_tripTypeRate, p_from, p_to, p_statusName);
            SqlCommand cmd = new SqlCommand(sqlCommandStatement, con);
            //cmd.Parameters.AddWithValue("@p_tripTypeRate", p_tripTypeRate);
            //cmd.Parameters.AddWithValue("@p_from", p_from);
            //cmd.Parameters.AddWithValue("@p_to", p_to);
            //cmd.Parameters.AddWithValue("@StatusName", p_statusName);
            //string result = Convert.ToString(cmd.ExecuteScalar());
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable disp_search_salary(string FromDate, string ToDate, string driver, string lorry)
        {
            DataTable dt = new DataTable();

            string query = "select * from vw_salary where[DODate] between '" + FromDate + "' and '" + ToDate + "'";
            if (driver != "")
            {
                query = query + " and [DriverName] = '" + driver + "'";
            }
            if (lorry != "")
            {
                query = query + " and [LorryNo] = '" + lorry + "'";
            }


            //string sqlCommandStatement = string.Format("select * from vw_Salary where [DoDate] between {0} and {1}", FromDate, ToDate);
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            return dt;

        }

        public DataTable disp_report_header()
        {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tblReportHeader", con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                return dt;
            
        }

    }
}
