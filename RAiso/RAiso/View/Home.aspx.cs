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
    public partial class Home : System.Web.UI.Page
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
                updateStationery(null);
            }
        }

        public void updateStationery(String search)
        {
            Response<List<MsStationery>> result = MsStationeryController.GetStationery(search);
            List<MsStationery> stationery = result.Payload;
            StationeryRepeater.DataSource = stationery;
            StationeryRepeater.DataBind();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            String search = SearchInput.Text;
            updateStationery(search);
        }

        protected void StationeryRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var updateBtnAdmin = e.Item.FindControl("UpdateBtnAdmin") as Button;
                var deleteBtnAdmin = e.Item.FindControl("DeleteBtnAdmin") as Button;
                var addcart = e.Item.FindControl("CartBtnUser") as Button;
                var purchase = e.Item.FindControl("PurchaseBtnUser") as Button;
                if (Session["User"] != null)
                {
                    MsUser curr = Session["User"] as MsUser;
                    String role = curr.UserRole;
                    if (role.Equals("Admin"))
                    {
                        addcart.Visible = false;
                        purchase.Visible = false;
                        updateBtnAdmin.Visible = true;
                        deleteBtnAdmin.Visible = true;
                        AddStationery.Visible = true;
                    }
                }
            }
        }

        protected void AddStationery_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/AddStationery.aspx");
        }

        protected void StationeryRepeater_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {
            int stationeryID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Delete")
            {
                MsStationeryController.DeleteStationery(stationeryID);
                updateStationery(null);
            }
            else if (e.CommandName == "Update")
            {
                Response.Redirect($"UpdateStationery.aspx?stationeryID={stationeryID}");
            }
            else if (e.CommandName == "AddCart")
            {
                Response.Redirect($"StationeryDetails.aspx?stationeryID={stationeryID}");
            }
            else if (e.CommandName == "Purchase")
            {
                Response.Redirect($"StationeryDetails.aspx?stationeryID={stationeryID}");
            }
        }
    }
}