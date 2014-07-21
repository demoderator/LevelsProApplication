﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LevelsPro.App_Code;
using BusinessLogic.Select;
using System.Security.Cryptography;
using System.IO;
using System.Text;
namespace LevelsPro
{
    public partial class Login : AuthorizedPage
    {
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Session["MyUICulture"] != null && Session["MyCulture"] != null)
            {
                if (Session["MyUICulture"].ToString() == "en-US")
                {
                    ddlLanguage.SelectedIndex = 0;
                }
                else if ((Session["MyUICulture"].ToString() == "fr-FR"))
                {
                    ddlLanguage.SelectedIndex = 1;
                }
                else 
                {
                    ddlLanguage.SelectedIndex = 2;
                }
            }
            if (ddlLanguage.SelectedIndex==0)
            {
                SetCulture("en-US", "en-US");
            }
            else if (ddlLanguage.SelectedIndex == 1)
            {
                SetCulture("fr-FR", "fr-FR");
            }
            else 
            {
                SetCulture("es-ES", "es-ES");
            }

            lblError.Visible = false;
            

        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }       
        
      public static string Encrypt(string originalString)
       {

    var cryptoProvider = new DESCryptoServiceProvider();
    var memoryStream = new MemoryStream();
    var cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(bytes, bytes),
        CryptoStreamMode.Write);
    var writer = new StreamWriter(cryptoStream);
    writer.Write(originalString);
    writer.Flush();
    cryptoStream.FlushFinalBlock();
    writer.Flush();
    return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
    }


        protected void btnSignin_Click(object sender, EventArgs e)
        {
            string user, pwd, Sysrole;
            user = txtUser.Text.Trim();
            pwd = Encrypt(txtPassword.Text);
           // pwd = txtPassword.Text;

            DataSet ds = new DataSet();

            ds = UserData(user);

            if (ds.Tables[0].Rows.Count == 0)
            {
                lblError.Visible = true;
                lblError.Text = "Invalid user name or password.";
                txtPassword.Focus();
                return;
                
            }
            Session["language"] = ddlLanguage.SelectedItem.Text;
            Session["userid"] = ds.Tables[0].Rows[0]["UserID"];
            Session["username"] = user;

            if (ds.Tables[0].Rows[0]["U_Password"].ToString().Equals(""))
            {
                //Session["userid"] = ds.Tables[0].Rows[0]["UserID"];
                //Session["username"] = user;
                //Session["language"] = ddlLanguage.SelectedItem.Text;
                Session["password"] = null;
                mpeSetNewPassword.Show();
            }
            else if (ds.Tables[0].Rows[0]["U_Password"].ToString() == pwd)
            {
                Sysrole = ds.Tables[0].Rows[0]["U_SysRole"].ToString();


                Session["userrole"] = ds.Tables[0].Rows[0]["RoleName"].ToString();
                Session["rolename"] = ds.Tables[0].Rows[0]["RoleName"].ToString();
               // Session["Role_ID"] = ds.Tables[0].Rows[0]["Role_ID"];
                Session["UserRoleID"] = ds.Tables[0].Rows[0]["U_RolesID"];
                Session["role"] = Sysrole;

                if (ds.Tables[0].Rows[0]["Display_Name"].ToString() == "1")
                {
                    Session["displayname"] = ds.Tables[0].Rows[0]["U_FirstName"].ToString() + ' ' + ds.Tables[0].Rows[0]["U_LastName"].ToString();
                }
                else
                {
                    Session["displayname"] = ds.Tables[0].Rows[0]["U_NickName"].ToString();
                }

                Session["siteid"] = ds.Tables[0].Rows[0]["U_SiteID"];
                Session["sitename"] = ds.Tables[0].Rows[0]["SiteName"].ToString();

                
                Session["U_Points"] = ds.Tables[0].Rows[0]["U_Points"];
                //Session["username"] = user;                
                Session["password"] = pwd;

                if (ds.Tables[0].Rows[0]["ManagerEmail"] != null)
                {
                    Session["ManagerEmail"] = ds.Tables[0].Rows[0]["ManagerEmail"];
                }
                if (ds.Tables[0].Rows[0]["ManagerID"] != null)
                {
                    Session["ManagerID"] = ds.Tables[0].Rows[0]["ManagerID"];
                }
                
                if (Sysrole.Equals("Admin"))
                {
                    Response.Redirect("~/AdminPanel/AdminHome.aspx?" + DateTime.Now.Ticks);
                }
                else if (Sysrole.Equals("Manager"))
                {
                    Response.Redirect("~/ManagerPanel/TeamPerformance.aspx?" + DateTime.Now.Ticks);
                }
                else if (Sysrole.Equals("Player"))
                {
                    Response.Redirect("~/PlayerPanel/PlayerHome.aspx?" + DateTime.Now.Ticks);
                }
                else
                {
                    Response.Redirect("~\\Login.aspx?" + DateTime.Now.Ticks);
                }            
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Invalid user name or password.";
                txtPassword.Focus();
                return;
            }
        }

        protected void btnForgetPass_Click(object sender, EventArgs e)
        {
            mpeForgot.Show();            
        }
    }
}