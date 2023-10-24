using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

    protected void Button1_Click(object sender, EventArgs e)
    {
       
         string s;
         s = string.Format("update UserLogin set Password = '{0}' where UserId = '{1}' and password = '{2}'", txtNewpassword.Text, txtUserName.Text, txtOldpassword.Text);
        SqlCommand cmd = new SqlCommand(s, con);
        con.Open();
        int res = cmd.ExecuteNonQuery();
        if (res > 0)
        {

            txtUserName.Text = "";
            txtNewpassword.Text = "";
            txtOldpassword.Text = "";
            txtConfirmPassword.Text = "";
            lblRres.Text = "Password Updated successfully";
        }
        else
            lblRres.Text = "Username or Password not Currect";

        con.Close();
    }
    }
