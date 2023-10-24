using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Admin_Addcat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack == true)
        {
            BindGridView();
        }

    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

    public void BindGridView()
    {

        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("Select * from Addcategory", con);
        con.Open();
        da.Fill(dt);
        con.Close();

        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }

        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "insert into Addcategory(CName)values(@cname)";
        cmd.Parameters.AddWithValue("@cname", TextBox1.Text);
        

        cmd.Connection = con;
        try
        {

            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Added Category successfully')</script>");

            BindGridView();
           
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
}