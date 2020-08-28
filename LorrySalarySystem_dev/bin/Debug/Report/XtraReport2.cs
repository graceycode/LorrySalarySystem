using System;
using System.Drawing;
using System.Collections;
using System.Text;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.ConnectionParameters;
using System.Globalization;

namespace LorrySalarySystem_dev.Report
{
    public partial class XtraReport2 : DevExpress.XtraReports.UI.XtraReport
    {
        CustomSqlQuery oriQuery = new CustomSqlQuery();

        public XtraReport2()
        {
            InitializeComponent();
            DateTime first = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime last = first.AddMonths(1).AddSeconds(-1);
            p_DO_date_from.Value = first;
            p_DO_date_to.Value = last;
            DateTime addOneMonth = first.AddMonths(1);
            p_Report_Month.Value = addOneMonth;

            this.DataSourceDemanded += XtraReport2_DataSourceDemanded;

            string strQuery = ((CustomSqlQuery)sqlDataSource1.Queries[0]).Sql;
            oriQuery.Sql = strQuery;
        }

        void XtraReport2_DataSourceDemanded(object sender, EventArgs e)
        {
            CustomSqlQuery query = this.sqlDataSource1.Queries[0] as CustomSqlQuery;
            query.Sql = oriQuery.Sql;

            DateTime p_dt_date_from = Convert.ToDateTime(p_DO_date_from.Value);
            string p_str_date_from = p_dt_date_from.ToString("yyyy-MM-dd");

            DateTime p_dt_date_to = Convert.ToDateTime(p_DO_date_to.Value);
            string p_str_date_to = p_dt_date_to.ToString("yyyy-MM-dd");

            //CustomSqlQuery query = new CustomSqlQuery();
            //query.Name = "SalaryQuery";
            //query.Sql = string.Format("Select * from {0}", "vw_Salary");


            StringBuilder builder_lorry = new StringBuilder();
            StringBuilder builder_driver = new StringBuilder();
            StringBuilder builder_DOdate = new StringBuilder();
            int lorrycount, drivercount;
            //For lorryNo query
            lorrycount = (this.p_lorry.Value as IList).Count;
            //if (string.IsNullOrEmpty(this.p_lorry.Value.ToString()))
            //{ lorrycount = 0; }
            //else
            //{ lorrycount = 1; }

            if (lorrycount == 0)
            {
                //return; 
            }
            else
            {

                builder_lorry.Append(" LorryNo in (");
                for (int i = 0; i < lorrycount; i++)
                {
                    builder_lorry.Append('\''); // Uncomment this line when parsing a string parameter value.
                    builder_lorry.Append((this.p_lorry.Value as IList)[i]);
                    builder_lorry.Append('\''); // Uncomment this line when parsing a string parameter value.
                    if (i != lorrycount - 1)
                        builder_lorry.Append(',');
                }
                builder_lorry.Append(')');
            }
            //For driver querry
            drivercount = (this.p_driver.Value as IList).Count;
            //if (string.IsNullOrEmpty(this.p_driver.Value.ToString()))
            //{ drivercount = 0; }
            //else
            //{ drivercount = 1; }

            if (drivercount == 0)
            {
                //return;
            }
            else
                    
            {

                if (lorrycount == 0)
                    builder_driver.Append(" DriverName in (");
                else
                    builder_driver.Append(" And DriverName in (");

                for (int i = 0; i < drivercount; i++)
                {
                    string str = (this.p_driver.Value as IList)[i].ToString();
                    str.Replace("'", "''");
                    (this.p_driver.Value as IList)[i] = str;
                    builder_driver.Append('\''); // Uncomment this line when parsing a string parameter value.
                    builder_driver.Append((this.p_driver.Value as IList)[i]);
                    builder_driver.Append('\''); // Uncomment this line when parsing a string parameter value.
                    if (i != drivercount - 1)
                        builder_driver.Append(',');
                }
                builder_driver.Append(')');
            }

            //For DO Date querry

            if (lorrycount == 0 && drivercount == 0)
                builder_DOdate.AppendFormat(" DODate between \'{0}\' and \'{1}\'", p_str_date_from, p_str_date_to);
            else
                builder_DOdate.AppendFormat(" And DODate between \'{0}\' and \'{1}\'", p_str_date_from, p_str_date_to);

            //Combine all query
            if (builder_lorry.Length != 0 || builder_driver.Length != 0 || builder_DOdate.Length != 0)
            { query.Sql += " Where " + builder_lorry.ToString() + builder_driver.ToString() + builder_DOdate.ToString(); }
            //sqlDataSource1.Queries.Clear();
            //sqlDataSource1.Queries.Add(query);
            sqlDataSource1.RebuildResultSchema();
            
        }

        //private SqlDataSource BindToData()
        //{
        //    MsSqlConnectionParameters connectionParameters = new MsSqlConnectionParameters("(LocalDB)\v11.0", "dbLorrySalary.mdf", "", "", MsSqlAuthorizationType.Windows);
        //    SqlDataSource ds = new SqlDataSource(connectionParameters);
        //    CustomSqlQuery query = new CustomSqlQuery();
        //    query.Name = "customQuery";
        //    query.Sql = "SELECT * FROM vw_Salary";
        //    ds.Queries.Add(query);
        //    ds.RebuildResultSchema();

        //    return ds;
        //}
    }
}
