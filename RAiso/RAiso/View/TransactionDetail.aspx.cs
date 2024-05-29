﻿using RAiso.Controller;
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
    public partial class TransactionDetails : System.Web.UI.Page
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

                    RefreshList();
                }
            }
        }
        //public void RefreshList()
        //{
        //    string id = Request.QueryString["TransactionId"];

        //    Response<List<RAiso.Models.TransactionDetail>> response = TransactionDetailController.GetAllTransactionDetailById();
        //    if (!response.IsSuccess == true || !response.Payload.Any())
        //    {

        //        lblAlert.Text = response.Message;
        //        lblAlert.Visible = true;
        //        lblAlert.ForeColor = System.Drawing.Color.Red;
        //    }
        //    else
        //    {
        //        lblAlert.Text = response.Message;
        //        lblAlert.Visible = true;
        //        lblAlert.ForeColor = System.Drawing.Color.Green;
        //    }
        //    Repeater.DataSource = response.Payload;
        //    Repeater.DataBind();
        //}

        public void RefreshList()
        {
            string id = Request.QueryString["TransactionId"];

            if (int.TryParse(id, out int transactionId))
            {

                Response<List<RAiso.Models.TransactionDetail>> response = TransactionDetailController.GetAllTransactionDetailById(transactionId);
                if (response.IsSuccess && response.Payload.Any())
                {
                    lblAlert.Text = response.Message;
                    lblAlert.ForeColor = System.Drawing.Color.Green;
                    lblAlert.Visible = true;

                    Repeater.DataSource = response.Payload;
                    Repeater.DataBind();
                }
                else
                {
                    lblAlert.Text = response.Message;
                    lblAlert.ForeColor = System.Drawing.Color.Red;
                    lblAlert.Visible = true;
                }
            }
        }

        protected void RepeaterCard_Command(object sender, RepeaterCommandEventArgs e)
        {


        }


    }
}