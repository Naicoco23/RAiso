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
using System.Xml.Linq;

namespace RAiso.View
{
    public partial class UpdateCart : System.Web.UI.Page
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
                if (role.Equals("Admin"))
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
                string stationeryId = Request.QueryString["stationeryId"];
                string userId = Request.QueryString["userId"];

                if (!int.TryParse(stationeryId, out int stationeryID) || !int.TryParse(userId, out int userID))
                {
                    Response.Redirect("~/View/Home.aspx");
                }
                else
                {
                    LoadStatDetail(userID, stationeryID);
                }
            }
        }

        public void LoadStatDetail(int userId, int statId)
        {
            Response<RAiso.Models.Cart> cart = CartController.GetUpdateItem(userId, statId);
            Response<MsStationery> stat = MsStationeryController.GetStationeryById(statId);
            if (cart != null)
            {
                lblStationery.Text = stat.Payload.StationeryName;
                lblPrice.Text = "Rp. " + stat.Payload.StationeryPrice.ToString();
                txtQty.Text = cart.Payload.Quantity.ToString();
                
            }
        }

        protected void updateCartbtn_Click(object sender, EventArgs e)
        {
            string stationeryId = Request.QueryString["stationeryId"];
            string userId = Request.QueryString["userId"];

            if (!int.TryParse(stationeryId, out int stationeryID) || !int.TryParse(userId, out int userID))
            {
                Response.Redirect("~/View/Home.aspx");
            }
            else
            {
                int qty = Convert.ToInt32(txtQty.Text);
                Response<RAiso.Models.Cart> curr = CartController.UpdateItem(userID, stationeryID, qty);
                if (curr.IsSuccess)
                {
                    Error.ForeColor = System.Drawing.Color.Green;
                    Error.Text = curr.Message;
                    Error.Visible = true;
                    LoadStatDetail(userID, stationeryID);
                }
                else
                {
                    Error.ForeColor = System.Drawing.Color.Red;
                    Error.Text = curr.Message;
                    Error.Visible = true;
                }
            }
        }
    }
}