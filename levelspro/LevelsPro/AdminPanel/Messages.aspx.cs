﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using BusinessLogic.Delete;
using BusinessLogic.Update;
using LevelsPro.App_Code;

namespace LevelsPro.AdminPanel
{
    public partial class Messages : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userid"] != null && Session["userid"].ToString() != "")
                {
                  
                    lblName.Text = Session["displayname"].ToString() + " - Messages";
                }

                
                btnShowAll_Click(null, null);
            }
        }

        public void LoadData()
        {
            if (Session["userid"] != null && Session["userid"].ToString() != "")
            {
                

                btnShowUnRead.CssClass = "green";
                btnShowAll.CssClass = "orange";
                MessagesViewBLL messageview = new MessagesViewBLL();

                try
                {
                    messageview.Invoke();
                }
                catch (Exception ex)
                {
                }

                DataView dv = messageview.ResultSet.Tables[0].DefaultView;

                dv.RowFilter = "To_UserID=" + Session["userid"];

                DataTable dt = dv.ToTable();

                if (dt != null && dt.Rows.Count > 0)
                {
                    dlMessages.DataSource = dt;
                    dlMessages.DataBind();
                }
                else
                {
                    dlMessages.DataSource = null;
                    dlMessages.DataBind();
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void btnComposeMessage_Click(object sender, EventArgs e)
        {
            if (hfShowAll.Value == "0")
            {
                LoadUnReadData();
            }
            else
            {
                LoadData();
            }
            mpeComposeMessageDiv.Show();
        }

        protected void btnShowUnRead_Click(object sender, EventArgs e)
        {
            LoadUnReadData();
        }

        #region show unread message
        public void LoadUnReadData()
        {
            if (Session["userid"] != null && Session["userid"].ToString() != "")
            {
                btnShowUnRead.CssClass = "green";
                btnShowAll.CssClass = "orange";
                MessagesViewBLL messageview = new MessagesViewBLL();

                try
                {
                    messageview.Invoke();
                }
                catch (Exception ex)
                {
                }

                DataView dv = messageview.ResultSet.Tables[0].DefaultView;

                dv.RowFilter = "To_UserID=" + Session["userid"] + " AND IsRead= 0";

                DataTable dt = dv.ToTable();

                if (dt != null && dt.Rows.Count > 0)
                {
                    dlMessages.DataSource = dt;
                    dlMessages.DataBind();
                }
                else
                {
                    dlMessages.DataSource = null;
                    dlMessages.DataBind();
                }
                hfShowAll.Value = "0";
            }
        }
        #endregion
        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadData();
            hfShowAll.Value = "1";
        }

        #region view and delete message
        protected void dlMessages_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ViewPopup")
            {
                int MessageID = Convert.ToInt32(e.CommandArgument);


                MessageStatusUpdateBLL statusupdate = new MessageStatusUpdateBLL();
                Common.Messages message = new Common.Messages();
                message.MessageID = MessageID;
                statusupdate.Messages = message;
                try
                {
                    statusupdate.Invoke();
                }
                catch (Exception ex)
                {
                }
                if (hfShowAll.Value == "0")
                {
                    btnShowUnRead_Click(null, null);
                }
                else
                {
                    btnShowAll_Click(null, null);
                }

                mpeViewMessageDetailsDiv.Show();
                ucViewMessageDetails.loadData(MessageID);
                
            }
            else if (e.CommandName == "DeleteMsg")
            {
                int MessageID = Convert.ToInt32(e.CommandArgument);
                MessageDeleteBLL msgBLL = new MessageDeleteBLL();
                Common.Messages msg = new Common.Messages();

                msg.MessageID = MessageID;

                msgBLL.Message = msg;

                try
                {
                    msgBLL.Invoke();
                    btnShowAll_Click(null, null);
                }
                catch
                {

                }
            }
        }
        #endregion
        protected void dlMessages_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblIsRead = e.Item.FindControl("lblIsRead") as Label;
                ImageButton ibtnDelete = e.Item.FindControl("ibtnDelete") as ImageButton;
                Image imgUnread = e.Item.FindControl("imgUnread") as Image;

                if (lblIsRead != null && lblIsRead.Text.Trim() != "" && lblIsRead.Text.Trim().ToLower() == "true")
                {
                    ibtnDelete.Visible = true;
                    imgUnread.Visible = false;
                }
                else
                {
                    imgUnread.Visible = true;
                    ibtnDelete.Visible = false;
                }
            }
          
        }
    }
}