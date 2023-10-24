using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["r"] != null)
        {
            string r = Request.QueryString["r"].ToString();
            Response.Redirect("~/Login.aspx");
        }
    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
   

    
    protected void Button6_Click(object sender, EventArgs e)
    {
        if (txtpwd.Text != null && txtuname.Text != null && txtpwd.Text != "" && txtuname.Text != "")
        {
          
            if (DropDownList1.SelectedItem.Text == "Admin" && txtuname.Text=="admin" && txtpwd.Text=="123")
                {
                    Session["aname"] = txtuname.Text;
                    Response.Redirect("Admin/Home.aspx");
                }

        int UserID_temp=0;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.CommandText = "spLogin";
        cmd.Parameters.AddWithValue("@email", txtuname.Text);
        cmd.Parameters.AddWithValue("@password",txtpwd.Text);
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            //loginResponse = new LoginResponse();
            UserID_temp = Convert.ToInt32(sdr["UserId"].ToString());


        }
    
            if (Request.QueryString["r"] == null || string.IsNullOrEmpty(Request.QueryString["r"].ToString()))
            {
               
                 if (DropDownList1.SelectedItem.Text == "User")
                {
                    Session["UserId"] = UserID_temp;
                 
                    Response.Redirect("UserAccount/Home.aspx");
                }
            }

            else
            {
                string r = Request.QueryString["r"].ToString();
                Response.Redirect("~/" + Request.QueryString["r"].ToString());
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
        }
    }

    protected void btnfrgpswd_Click(object sender, EventArgs e)
    {
        //Response.Redirect("ForgotPassword.aspx");
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        txtpwd.Text = "";
        txtuname.Text = "";
        DropDownList1.SelectedIndex = -1;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserRegistration.aspx");
    }
}