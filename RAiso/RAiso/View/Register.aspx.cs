using RAiso.Controller;
using RAiso.Models;
using RAiso.Modules;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.View
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Error.Visible = false;
            if (Session["User"] != null || Request.Cookies["UserCookie"] != null)
            {
                Response.Redirect("~/View/Home.aspx");
            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            String Username = Name.Text;
            DateTime DOB = DateTime.MinValue;
            try
            {
                DOB = DateTime.Parse(Date.Text);
            }
            catch (FormatException) { }

            String Gender = "";
            if (FemaleRadio.Checked)
            {
                Gender = "Female";
            }
            else if(MaleRadio.Checked)
            {
                Gender = "Male";
            }
            String Add = Address.Text;
            String Pass = Password.Text;
            String Phone = PhoneNumber.Text;
            Response<MsUser> response = MsUserController.RegisterUser(Username, Gender, DOB, Phone, Add, Pass);
            if (response.IsSuccess)
            {
                Response.Redirect("~/View/Login.aspx");
            }
            Error.ForeColor = System.Drawing.Color.Red;
            Error.Text = response.Message;
            Error.Visible = true;
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Login.aspx");
        }
    }
}