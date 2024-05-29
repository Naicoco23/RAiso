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
    public partial class Cart : System.Web.UI.Page
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
                if (Session["UserId"] != null && int.TryParse(Session["UserId"].ToString(), out int userId))
                {

                    RefreshList(userId);
                }
            }
            

        }

        protected void reptCart_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split('|');
          
            int userId = Convert.ToInt32(args[0]);
            int stationeryId = Convert.ToInt32(args[1]);

            if(e.CommandName == "Remove")
            {
                Response<RAiso.Models.Cart> curr =  CartController.RemoveItem(userId, stationeryId);
                if (curr.IsSuccess)
                {
                    lblAlert.Text = curr.Message;
                    lblAlert.ForeColor = System.Drawing.Color.Green;
                    lblAlert.Visible = true;
                }
                else
                {

                    lblAlert.Text = curr.Message;
                    lblAlert.ForeColor = System.Drawing.Color.Red;
                    lblAlert.Visible = true;
                }

                RefreshList(userId);
            }
            else if(e.CommandName == "Update")
            {
                Response.Redirect($"~/View/UpdateCart.aspx?userId={userId}&stationeryId={stationeryId}");
            }
            
        }

        public void RefreshList(int userId)
        {
            Response<List<RAiso.Models.Cart>> cartItems = CartController.GetCartList(userId);
            if (!cartItems.IsSuccess || !cartItems.Payload.Any())
            {
                lblAlert.Text = cartItems.Message;
                lblAlert.Visible = true;
                lblAlert.ForeColor = System.Drawing.Color.Blue;
                btnPurchase.Visible = false;
            }
            else
            {
                btnPurchase.Visible = true;
            }
            reptCart.DataSource = cartItems.Payload;
            reptCart.DataBind();
        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            MsUser curr = Session["User"] as MsUser;
            int userId = curr.UserID;

            // Ini diisi AddToTransactionHeader
            Response<TransactionHeader> th = TransactionHeaderController.CreateTransactionHeader(userId);
            int transId = th.Payload.TransactionID;
            // disini diisi GetQuantityById sebelum diapus
            Response <List<RAiso.Models.Cart>> response = CartController.GetAllItemByUserId(userId);
            TransactionDetailController.SetTransactionDetailQty(response, transId);
            CartController.CheckOutItem(userId);
            RefreshList(userId);
        }
    }
}