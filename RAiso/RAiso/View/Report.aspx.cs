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

            if (Session["User"] == null && Request.Cookies["UserCookie"] != null)
            {
                String cookie = Request.Cookies["UserCookie"].Value;
                Response<MsUser> response = MsUserController.LogInWithCookie(cookie);
                if (response.IsSuccess == false)
                {
                    Response.Cookies["UserCookie"].Expires = DateTime.Now.AddDays(-1);
                }
                Session["User"] = response.Payload;
            }
            if (Session["User"] != null)
            {
                MsUser curr = Session["User"] as MsUser;
                String role = curr.UserRole;
                if (role.Equals("Admin") == false)
                {
                    Response.Redirect("~/View/Home.aspx");
                }
            }
            else
            {
                Response.Redirect("~/View/Home.aspx");
            }

            CrystalReport3 report = new CrystalReport3();
            CrystalReportViewer1.ReportSource = report;
            Response<List<TransactionHeader>> temp = TransactionHeaderController.GetAllTransaction();
            MilDataSet data = getData(temp.Payload);
            report.SetDataSource(data);
        }

        private MilDataSet getData(List<TransactionHeader> TransactionHeaders)
        {
            MilDataSet data = new MilDataSet();
            var headerTable = data.TransactionHeaders;
            var detailTable = data.TransactionDetails;

            foreach (TransactionHeader t in TransactionHeaders)
            {
                var hrow = headerTable.NewRow();

                hrow["TransactionID"] = t.TransactionID;
                hrow["UserID"] = t.UserID;
                hrow["TransactionDate"] = t.TransactionDate;
                decimal grand = 0;


                foreach(TransactionDetail detail in t.TransactionDetails)
                {
                    Response<MsStationery> stat = MsStationeryController.GetStationeryById(detail.StationeryID);
                    var drow = detailTable.NewRow();
                    drow["TransactionID"] = detail.TransactionID;
                    drow["StationeryName"] = stat.Payload.StationeryName;
                    drow["Quantity"] = detail.Quantity;
                    drow["StationeryPrice"] = stat.Payload.StationeryPrice;
                    drow["SubTotal"] = detail.Quantity * stat.Payload.StationeryPrice;
                    grand+= detail.Quantity * stat.Payload.StationeryPrice;
                    detailTable.Rows.Add(drow);
                }
                hrow["GrandTotal"] = grand;
                headerTable.Rows.Add(hrow);
            }
            return data;
        }
    }
}