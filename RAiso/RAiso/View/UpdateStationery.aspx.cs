using RAiso.Controller;
using RAiso.Models;
using RAiso.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.View
{
    public partial class UpdateStationery : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                string stationeryID = Request.QueryString["stationeryID"];
                if (!string.IsNullOrEmpty(stationeryID))
                {
                    if (decimal.TryParse(stationeryID, out decimal IDTemp))
                    {
                        int ID = (int)Math.Round(IDTemp);
                        LoadStatDetail(ID);
                    }
                }
                else // No StationeryID
                {
                    Response.Redirect("~/View/Home.aspx");
                }
            }
        }

        public void LoadStatDetail(int ID)
        {
            Response<MsStationery> stationery = MsStationeryController.GetStationeryById(ID);
            if (stationery != null)
            {
                MsStationery curr = stationery.Payload;
                Name.Text = curr.StationeryName;
                Price.Text = curr.StationeryPrice.ToString();
            }
        }

        protected void UpdateStationeryBtn_Click(object sender, EventArgs e)
        {
            String name = Name.Text;
            String price = Price.Text;
            int ID=0;
            string stationeryID = Request.QueryString["stationeryID"];
            if (!string.IsNullOrEmpty(stationeryID))
            {
                if (decimal.TryParse(stationeryID, out decimal IDTemp))
                {
                    ID = (int)Math.Round(IDTemp);
                    LoadStatDetail(ID);
                }
            }
            Response<MsStationery> response = MsStationeryController.UpdateStationery(ID, name, price);
            if (response.IsSuccess)
            {
                Error.ForeColor = System.Drawing.Color.Green;
                Error.Text = response.Message;
                Error.Visible = true;
                LoadStatDetail(ID);
            }
            else
            {
                Error.ForeColor = System.Drawing.Color.Red;
                Error.Text = response.Message;
                Error.Visible = true;
            }
        }
    }
}