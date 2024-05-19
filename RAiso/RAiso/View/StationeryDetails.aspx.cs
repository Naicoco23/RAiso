using RAiso.Controller;
using RAiso.Models;
using RAiso.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.View
{
    public partial class StationeryDetails : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                string stationeryID = Request.QueryString["stationeryID"];
                if (!string.IsNullOrEmpty(stationeryID))
                {
                    if (decimal.TryParse(stationeryID, out decimal IDTemp))
                    {
                        int ID = (int)Math.Round(IDTemp);
                        StatDetail(ID);
                    }
                }
                else // No StationeryID
                {
                    Response.Redirect("~/View/Home.aspx");
                }
            }
        }

        public void StatDetail(int ID)
        {
            Response<MsStationery> response = MsStationeryController.GetStationeryById(ID);
            if (response.IsSuccess)
            {
                MsStationery stationery = response.Payload;
                Name.Text = stationery.StationeryName;
                Price.Text = stationery.StationeryPrice.ToString();
            }
        }

        protected void AddCartBtn_Click(object sender, EventArgs e)
        {

        }

        protected void PurchaseBtn_Click(object sender, EventArgs e)
        {

        }
    }
}