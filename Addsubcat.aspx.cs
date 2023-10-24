using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Admin_Addsubcat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack == true)
        {
            cat();
        }

    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

    public void cat()
    {

        try
        {
            DropDownList1.Items.Clear();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Addcategory";
            


            cmd.Connection = con;




            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            DropDownList1.Items.Insert(0, "----Select----");
            if (dt.Rows.Count > 0)
            {


                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "CName";
                DropDownList1.DataValueField = "CId";
                DropDownList1.DataBind();

                //Cache["Rate"] = dt;

            }


            //while (sdr.Read())
            // {
            //     string str = sdr["ItemName"].ToString();
            //     ddlItemName.Items.Add(sdr["ItemName"].ToString());
            // }}

        }
        catch (Exception ex)
        {
        }
    }

    public void BindGridView()
    {

        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("Select * from Addsubcat", con);
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
     
            con.Open();
       


        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "insert into Addsubcat(catid,catname,subcatname)values(@catid,@catname,@subcatname)";
        cmd.Parameters.AddWithValue("@catid", DropDownList1.SelectedValue);
        cmd.Parameters.AddWithValue("@catname", DropDownList1.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@subcatname", TextBox1.Text);

        cmd.Connection = con;
        try
        {

            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Added Sub Category successfully')</script>");

          

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
            BindGridView();

        }
    }
}