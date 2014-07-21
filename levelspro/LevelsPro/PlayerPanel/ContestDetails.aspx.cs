﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Common;
using BusinessLogic.Select;
using LevelsPro.App_Code;
using BusinessLogic.Update;

namespace LevelsPro.PlayerPanel
{
    public partial class ContestDetails : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["userid"] != null && Session["userid"].ToString() != "")
                {
                    ViewProfile.LoadData();
                    lblName.Text = Session["displayname"].ToString() + " - Contest";
                }

                if (Session["ContestID"] != null)
                {
                    Load_ContestDetails(Convert.ToInt32(Session["ContestID"]));
                }
            }
        }

        public void Load_ContestDetails(int ContestID)
        {

            DataSet ds = new DataSet();
            Contest _contest = new Contest();
            PlayerContestViewDetailBLL contest = new PlayerContestViewDetailBLL();
            _contest.ContestID = ContestID;
            contest.Contest = _contest;
            contest.Invoke();
            ds = contest.ResultSet;
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                imgContestImage.ImageUrl = "~/view-file.aspx?contestid=" + ContestID;
                lblContestName.InnerText = ds.Tables[0].Rows[0]["Contest_Name"].ToString();
                lblContestEndDate.InnerText = Convert.ToDateTime(ds.Tables[0].Rows[0]["Contest_EndDate"]).ToString("MMMM dd, yyyy");
                ltContestDescription.Text = ds.Tables[0].Rows[0]["Contest_Descp"].ToString();
                // lblContestDescription.InnerText = ds.Tables[0].Rows[0]["Contest_Dur"].ToString();
            }

            DataSet dsPointsTable = new DataSet();
            Contest _contestid = new Contest();
            ContestPlayersScoreBLL contestplayerscore = new ContestPlayersScoreBLL();
            _contestid.ContestID = ContestID;
            contestplayerscore.Contest = _contestid;
            contestplayerscore.Invoke();
            dsPointsTable = contestplayerscore.ResultSet;
            if (dsPointsTable != null && dsPointsTable.Tables[0].Rows.Count > 0)
            {
                gvPointsTable.DataSource = dsPointsTable;
                gvPointsTable.DataBind();
            }

        }

        protected void gvPointsTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image imgRank = (Image)e.Row.FindControl("imgbtnRank");
                if (imgRank != null)
                {
                    if (e.Row.RowIndex == 0)
                    {
                        imgRank.ImageUrl = "~/PlayerPanel/Images/rank-1.png";
                        imgRank.Width = Unit.Pixel(40);
                        imgRank.Height = Unit.Pixel(30);
                    }
                    else
                        if (e.Row.RowIndex == 1)
                        {
                            imgRank.ImageUrl = "~/PlayerPanel/Images/rank-2.png";
                            imgRank.Width = Unit.Pixel(35);
                            imgRank.Height = Unit.Pixel(25);
                        }
                        else if (e.Row.RowIndex == 2)
                        {
                            imgRank.ImageUrl = "~/PlayerPanel/Images/rank-3.png";
                            imgRank.Width = Unit.Pixel(30);
                            imgRank.Height = Unit.Pixel(20);
                        }
                }

            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            LoginUpdateBLL loginuser = new LoginUpdateBLL();
            Common.User user = new Common.User();
            user.UserID = Convert.ToInt32(Session["userid"]);
            loginuser.Users = user;
            try
            {
                loginuser.Invoke();
            }
            catch (Exception ex)
            {
            }
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }
    }

}