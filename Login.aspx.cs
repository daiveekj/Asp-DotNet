using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WebApplication1.code;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DBCalling db=new DBCalling();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoggedInUser"] != null)
                {                   
                    Response.Redirect("Dashboard.aspx");
                }
            }
        }

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            CredentialValidation();
        }

        void CredentialValidation()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (db.IsValidCredentials(username, password))
            {
                Session["LoggedInUser"] = username;
                Response.Redirect("Default.aspx");
            }
            else if (username == "" && password == "")
            {

                lblMessage.Text = "Please Enter UserName and Password";

            }
            else if (username == "")
            {
                lblMessage.Text = "Please Enter UserName";
                txtUsername.Text = string.Empty;

            }
            else if (password == "")
            {
                lblMessage.Text = "Please enter password";
                txtPassword.Text = string.Empty;

            }
            else
            {
                lblMessage.Text = "Invalid UserName and Password";
                txtUsername.Text = string.Empty;

            }
            
        }
    }
    }
