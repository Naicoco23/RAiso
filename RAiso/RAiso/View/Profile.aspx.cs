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
    public partial class Profile : System.Web.UI.Page
    {
        private Boolean success = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            Error.Text = "";
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
                if (role.Equals("Admin") == false && role.Equals("User") == false)
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
                FillTB();
            }


        }

        public void FillTB()
        {
            MsUser curr = Session["User"] as MsUser;
            DateTime date = curr.UserDOB;
            TBName.Text = curr.UserName;
            TBDoB.Text = date.ToString("yyyy-MM-dd");

            String gender = curr.UserGender;
            if (gender == "Male")
            {
                MaleRadio.Checked = true;
            }
            else if (gender == "Female")
            {
                FemaleRadio.Checked = true;

            }
            TBAddress.Text = curr.UserAddress;
            TBPassword.Text = curr.UserPassword;
            TBPhone.Text = curr.UserPhone;
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            MsUser curr = Session["User"] as MsUser;
            int id = curr.UserID;
            string name = TBName.Text;
            DateTime dob = DateTime.MinValue;
            try
            {
                dob = DateTime.Parse(TBDoB.Text);
            }
            catch (FormatException) { }
            String gender = "";
            if (MaleRadio.Checked)
            {
                gender = "Male";
            }
            else if (FemaleRadio.Checked)
            {
                gender = "Female";
            }
            String add = TBAddress.Text;
            String pass = string.IsNullOrEmpty(TBPassword.Text) ? curr.UserPassword : TBPassword.Text;
            String phone = TBPhone.Text;
            Response<MsUser> response = MsUserController.UpdateUser(id, name, gender, dob, phone, add, pass);
            if (response.IsSuccess)
            {
                Error.ForeColor = System.Drawing.Color.Green;
                Error.Text = response.Message;
                Error.Visible = true;
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