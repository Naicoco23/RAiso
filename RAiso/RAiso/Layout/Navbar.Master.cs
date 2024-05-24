using RAiso.Controller;
using RAiso.Models;
using RAiso.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.Layout
{
    public partial class Site1 : System.Web.UI.MasterPage
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

                Login.Visible=false;
                Register.Visible=false;

                ProfileUpdate.Visible = true;
                ProfileUpdateText.Visible = true;
                LogOut.Visible = true;
                ProfileUpdateText.Text = "Hello, " + curr.UserName;
                if (role.Equals("Admin"))
                {
                    TransactionReport.Visible = true;
                }
                else if (role.Equals("User"))
                {
                    Cart.Visible = true;
                    Transaction.Visible = true;
                }
            }
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home.aspx");
        }

        protected void Transaction_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Transaction.aspx");
        }

        protected void Cart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Cart.aspx");
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            Response.Cookies["UserCookie"].Expires = DateTime.Now.AddDays(-1);
            Session["User"] = null;
            Response.Redirect("~/View/Home.aspx");
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Login.aspx");
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Register.aspx");
        }

        protected void ProfileUpdate_Click(object sender, ImageClickEventArgs e)
        {
            
            Response.Redirect("~/View/Profile.aspx");
        }

        protected void ProfileUpdateText_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/View/Profile.aspx");
        }

        protected void TransactionReport_Click(object sender, EventArgs e)
        {

        }
    }
}