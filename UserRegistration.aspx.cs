using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public partial class UserRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_UserRegistration";
        cmd.Parameters.AddWithValue("@username", txtUname.Text);
        cmd.Parameters.AddWithValue("@password", txtPswd.Text);
        cmd.Parameters.AddWithValue("@MobileNo", txtMobile.Text);
        cmd.Parameters.AddWithValue("@email", txtEmailID.Text);
        cmd.Parameters.AddWithValue("@fName", txtFname.Text);
        cmd.Parameters.AddWithValue("@LName", txtLanme.Text);
        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
        cmd.Parameters.AddWithValue("@State", txtState.Text);
        cmd.Parameters.AddWithValue("@country", txtCountry.Text);
        cmd.Parameters.AddWithValue("@ZipCode", txtZipCode.Text);
        cmd.Connection = con;
        int res = cmd.ExecuteNonQuery();
        if (res> 0)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Registration  Successfully')</script>");
          
        }
        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Registration not Successfully')</script>");

    }
}