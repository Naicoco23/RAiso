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

            MsUser user = Session["User"] as MsUser;
            if (user != null && user.UserRole.ToLower() == "admin")
            {
                AddCartBtn.Visible = false;
                PurchaseBtn.Visible = false;
                Quantity.Visible = false;
                Utility1.Visible = false;
                BtnContainer.Visible = false;
            }
            else if (user != null && user.UserRole.ToLower() == "user")
            {
                AddCartBtn.Visible = true;
                PurchaseBtn.Visible = true;
                Quantity.Visible = true;
                Utility1.Visible = true;
                BtnContainer.Visible = true;
            }
            else
            {
                AddCartBtn.Visible = false;
                PurchaseBtn.Visible = false;
                Quantity.Visible = false;
                Utility1.Visible = false;
                BtnContainer.Visible = false;
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

            MsUser user = Session["User"] as MsUser;
            int userId = user.UserID;
            int statId = -1;
            int qty = Convert.ToInt32(Quantity.Text);

            string stationeryID = Request.QueryString["stationeryID"];
            if (!string.IsNullOrEmpty(stationeryID))
            {
                if (decimal.TryParse(stationeryID, out decimal IDTemp))
                {
                    statId = (int)Math.Round(IDTemp);
                }
            }
            Response<RAiso.Models.Cart> cart = CartController.AddToCart(userId, statId, qty);
            
            if(cart.IsSuccess == false)
            {
                lblAlert.ForeColor = System.Drawing.Color.Red;
                lblAlert.Text = cart.Message;
                lblAlert.Visible = true;
            }
            else
            {
                lblAlert.ForeColor = System.Drawing.Color.Green;
                lblAlert.Text = cart.Message;
                lblAlert.Visible = true;
            }
        }

        protected void PurchaseBtn_Click(object sender, EventArgs e)
        {

        }
    }
}