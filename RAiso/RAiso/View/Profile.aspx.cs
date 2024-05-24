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
                if (role.Equals("Admin") == false && role.Equals("User") == false )
                {
                    Response.Redirect("~/View/Home.aspx");
                }
            }
            else
            {
                Response.Redirect("~/View/Home.aspx");
            }
            FillTB();
        }

        public void FillTB()
        {
            MsUser curr = Session["User"] as MsUser;
            DateTime date = curr.UserDOB;
            TBName.Text = curr.UserName;
            TBDoB.Text = date.ToString("yyyy-MM-dd");
            
            String gender = curr.UserGender;
            if(gender == "Male")
            {
                MaleRadio.Checked = true;
            }
            else if(gender =="Female")
            {
                FemaleRadio.Checked = true;

            }
            TBAddress.Text = curr.UserAddress;
            TBPassword.Text = curr.UserPassword;
            TBPhone.Text= curr.UserPhone;
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            //apakah postback
            string name = TBName.Text;
            try
            {
                DateTime dob = DateTime.Parse(TBDoB.Text);
            }
            catch (FormatException) { }
            String gender = "";
            if(MaleRadio.Checked)
            {
                gender = "Male";
            }
            else if (FemaleRadio.Checked)
            {
                gender = "Female";
            }
            String add = TBAddress.Text;
            String pass = TBPassword.Text;
            String phone = TBPhone.Text;
        }
    }
}