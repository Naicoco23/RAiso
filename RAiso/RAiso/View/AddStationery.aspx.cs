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
    public partial class AddStationery : System.Web.UI.Page
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
            if(Session["User"] != null)
                {
                MsUser curr = Session["User"] as MsUser;
                String role = curr.UserRole;
                if (role.Equals("Admin")==false)
                {
                    Response.Redirect("~/View/Home.aspx");
                }
            }
            else
            {
                Response.Redirect("~/View/Home.aspx");
            }
        }

        protected void AddStationeryBtn_Click(object sender, EventArgs e)
        {
            String name = Name.Text;
            String price = Price.Text;
            Response<MsStationery> response = MsStationeryController.AddStationery(name, price);
            if(response.IsSuccess == false)
            {
                Error.ForeColor = System.Drawing.Color.Red;
                Error.Text = response.Message;
                Error.Visible = true;
            }
            else
            {
                Error.ForeColor = System.Drawing.Color.Green;
                Error.Text = response.Message;
                Error.Visible = true;
            }
        }
    }
}