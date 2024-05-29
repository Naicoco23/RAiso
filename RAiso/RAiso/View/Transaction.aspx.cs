using RAiso.Controller;
using RAiso.Models;
using RAiso.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;

namespace RAiso.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public void RefreshList()
        {
            Response<List<TransactionHeader>> response = TransactionHeaderController.GetAllTransaction();
            if (response.IsSuccess == true || response.Payload.Any())
            {
                lblAlert.Text = response.Message;
                lblAlert.Visible = true;
                lblAlert.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblAlert.Text = response.Message;
                lblAlert.Visible = true;
                lblAlert.ForeColor = System.Drawing.Color.Red;
            }
            Repeater.DataSource = response.Payload;
            Repeater.DataBind();
        }
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

                    RefreshList();
                }
            }


        }
        
        //protected void btnDetail_Click(object sender, EventArgs e)
        //{
            
        //}

        protected void RepeaterCard_Command(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Detail")
            {
                int TransactionId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"~/View/TransactionDetail.aspx?TransactionId={TransactionId}");
            }
        }
    }
}