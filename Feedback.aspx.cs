using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public partial class UserAccount_Feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null || string.IsNullOrEmpty(Session["UserId"].ToString()))
        {
            Response.Redirect("~/Login.aspx/?r=UserAccount/Feedback.aspx");
        }
        
            TextBox2.Text = Session["UserId"].ToString();
        
    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_Insertfeedback";
            cmd.Parameters.AddWithValue("@UserId", TextBox2.Text);
            cmd.Parameters.AddWithValue("@userview", TextBox1.Text);
            cmd.Connection = con;
            int res = cmd.ExecuteNonQuery();
            if (res > 0)
            {
                lblFeedback.Text = "Success";

            }
        }
        catch (Exception ex)
        {

        }
       

    }
}