using RAiso.Controller;
using RAiso.Dataset;
using RAiso.Models;
using RAiso.Modules;
using RAiso.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.View
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReport3 report = new CrystalReport3();
            CrystalReportViewer1.ReportSource = report;
            Response<List<TransactionHeader>> temp = TransactionHeaderController.GetAllTransaction();
            DataSet1 data = getData(temp.Payload);
            report.SetDataSource(data);
        }

        private DataSet1 getData(List<TransactionHeader> TransactionHeaders)
        {
            DataSet1 data = new DataSet1();
            var headerTable = data.TransactionHeaders;
            var detailTable = data.TransactionDetails;
            var stationeryTable = data.MsStationeries;
            foreach (TransactionHeader t in TransactionHeaders)
            {
                var hrow = headerTable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["UserID"] = t.UserID;
                hrow["TransactionDate"] = t.TransactionDate;
                headerTable.Rows.Add(hrow);

                foreach(TransactionDetail detail in t.TransactionDetails)
                {
                    var drow = detailTable.NewRow();
                    drow["TransactionID"] = detail.TransactionID;
                    drow["StationeryID"] = detail.StationeryID;
                    drow["Quantity"] = detail.Quantity;
                }
            }
            return data;
        }
    }
}