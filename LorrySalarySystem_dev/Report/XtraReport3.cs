using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using System.Text;

namespace LorrySalarySystem_dev.Report
{
    public partial class XtraReport3 : DevExpress.XtraReports.UI.XtraReport
    {
        CustomSqlQuery oriQuery = new CustomSqlQuery();
        public XtraReport3()
        {
            InitializeComponent();
            DateTime first = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime last = first.AddMonths(1).AddSeconds(-1);
            DateTime addOneMonth = first.AddMonths(1);
            p_report_month_title.Value = addOneMonth;
            p_date_from.Value = first;
            p_date_to.Value = last;

            //string strQuery = ((CustomSqlQuery)sqlDataSource1.Queries[0]).Sql;
            //oriQuery.Sql = strQuery;

        }

        //private void xrTableCell32_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        //{

        //}
 
      

        private void XtraReport3_DataSourceDemanded(object sender, EventArgs e)
        {
            CustomSqlQuery query = this.sqlDataSource1.Queries[0] as CustomSqlQuery;
            query.Sql = oriQuery.Sql;

            DateTime p_dt_date_from = Convert.ToDateTime(p_date_from.Value);
            string p_str_date_from = p_dt_date_from.ToString("yyyy-MM-dd");

            DateTime p_dt_date_to = Convert.ToDateTime(p_date_to.Value);
            string p_str_date_to = p_dt_date_to.ToString("yyyy-MM-dd");

            StringBuilder str = new StringBuilder();

            StringBuilder sb_driver = new StringBuilder();
            int drivercount;

            drivercount = (this.p_driver.Value as IList).Count;

            if (drivercount == 0)
            { }
            else
            {
                sb_driver.Append(" and DriverName in (");
                for (int i = 0; i < drivercount; i++)
                {
                    string temp = (this.p_driver.Value as IList)[i].ToString();
                    temp.Replace("'", "''");
                    (this.p_driver.Value as IList)[i] = temp;
                    sb_driver.Append('\''); // Uncomment this line when parsing a string parameter value.
                    sb_driver.Append((this.p_driver.Value as IList)[i]);
                    sb_driver.Append('\''); // Uncomment this line when parsing a string parameter value.
                    if (i != drivercount - 1)
                        sb_driver.Append(',');
                }
                sb_driver.Append(')');

            }

            //str.Append("select  DriverIC, DriverName, SUM(Amount) as Amount from vw_Salary where vw_Salary.TripTypeName = 'Trip' " + sb_driver.ToString() + " and  DODate between \'" + p_str_date_from + "\' and \'" + p_str_date_to + "\' group by DriverIC, DriverName");

            str.Append("select  DriverIC, DriverName, sum([Amount] * [CommissionRate] / 100) as Amount from vw_Salary where vw_Salary.CommissionRate = 0 " + sb_driver.ToString() + " and  DODate between \'" + p_str_date_from + "\' and \'" + p_str_date_to + "\' group by DriverIC, DriverName");

            query.Sql = str.ToString();

            sqlDataSource1.RebuildResultSchema();
        }
    }
}
