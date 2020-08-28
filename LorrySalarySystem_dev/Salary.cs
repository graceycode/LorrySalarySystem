using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LorrySalarySystem_dev
{
    public class Salary
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LorrySalarySystem_dev.Properties.Settings.dbLorrrySalaryConnectionString"].ToString());
        #region
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int DriverID { get; set; }
        public int LorryID { get; set; }
        public int TripTypeID { get; set; }
        public decimal CommissionRate { get; set; }
        public string DONo { get; set; }
        public DateTime DODate { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Goods { get; set; }
        public decimal Qty { get; set; }
        public int RateId { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastChangeBy { get; set; }
        public DateTime LastChangeOn { get; set; }
        public decimal AdditionalRate { get; set; }
        #endregion


        //public int TripTypeID(string TripTypeName)
        //{
        //    return 0;
        //}

    }
}
