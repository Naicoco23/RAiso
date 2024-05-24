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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Error.Visible = false;
            if (Session["User"] != null || Request.Cookies["UserCookie"] != null)
            {
                Response.Redirect("~/View/Home.aspx");
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Error.ForeColor = System.Drawing.Color.Red;

            String Username = Name.Text;
            String Pass = Password.Text;
            Boolean Rememberme = RememberMe.Checked;

            Response<MsUser> response = MsUserController.LoginUser(Username, Pass);
            if(response.IsSuccess)
            {
                
                if (Rememberme)
                {
                    HttpCookie cookie = new HttpCookie("UserCookie");
                    cookie.Value = response.Payload.UserName;
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                }
                Session["User"] = response.Payload;
                Session["UserId"] = response.Payload.UserID;
                Response.Redirect("~/View/Home.aspx");
            }
            else
            {
                Error.Text=response.Message;
                Error.Visible = true;
            }
        }

        protected void RegisterLinks_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Register.aspx");
        }
    }
}