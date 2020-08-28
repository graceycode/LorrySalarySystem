using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using System.Text;

namespace LorrySalarySystem_dev.Report
{
    public partial class XtraReport4_obsolete : DevExpress.XtraReports.UI.XtraReport
    {
        CustomSqlQuery oriQuery = new CustomSqlQuery();
        public XtraReport4_obsolete()
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

        private void XtraReport4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void XtraReport4_DataSourceDemanded(object sender, EventArgs e)
        {
            CustomSqlQuery query = this.sqlDataSource1.Queries[0] as CustomSqlQuery;
            query.Sql = oriQuery.Sql;
         

            DateTime p_dt_date_from = Convert.ToDateTime(p_date_from.Value);
            string p_str_date_from = p_dt_date_from.ToString("yyyy-MM-dd");

            DateTime p_dt_date_to = Convert.ToDateTime(p_date_to.Value);
            string p_str_date_to = p_dt_date_to.ToString("yyyy-MM-dd");

            StringBuilder str = new StringBuilder();

            str.Append("select  DriverIC, DriverName, SUM(Amount) as Amount from vw_Salary where vw_Salary.TripTypeName = 'Ton' and  DODate between \'" + p_str_date_from + "\' and \'" + p_str_date_to + "\' group by DriverIC, DriverName");

            query.Sql = str.ToString();

            sqlDataSource1.RebuildResultSchema();
        }
    }
}
