using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Configuration;
public partial class Admin_AddFoodItems : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["aname"] == null || string.IsNullOrEmpty(Session["aname"].ToString()))
        //{
        //    Response.Redirect("~/Login.aspx/?r=Admin/AddFoodItems.aspx");
        //}
        if (!IsPostBack==true)
        {
            cat();
        }

    }

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

    public void subcat()
    {

        try
        {
           
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Addsubcat where catid=@catid ";
            cmd.Parameters.AddWithValue("@catid",DropDownList1.SelectedValue);



            cmd.Connection = con;




            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            DropDownList2.Items.Insert(0, "----Select----");
            if (dt.Rows.Count > 0)
            {


                DropDownList2.DataSource = dt;
                DropDownList2.DataTextField = "subcatname";
                DropDownList2.DataValueField = "id";
                DropDownList2.DataBind();

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

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
    protected void BindGridView()
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
       
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("Select ItemId,ItemName,Rate,ItemPath from AddItem",con);
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

        if (FileUpload1.PostedFile != null)
        {
            string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

            //Save files to disk
            FileUpload1.SaveAs(Server.MapPath("../Images/" + FileName));

            con.Open();
            //Add Entry to DataBase
            //String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            //SqlConnection con = new SqlConnection(strConnString);
            //string strQuery = "spAddItems";
            //SqlCommand cmd = new SqlCommand(strQuery);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AddItems";
            cmd.Parameters.AddWithValue("@ItemName",txtItemName.Text);
            cmd.Parameters.AddWithValue("@CName", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@subcatname", DropDownList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Rate", txtRate.Text);
            cmd.Parameters.AddWithValue("@quantity", txtquntity.Text);
            
            cmd.Parameters.AddWithValue("@ItemPath", "../Images/" + FileName);
           
            cmd.Connection = con;
            try
            {
             
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Added successfully')</script>");

                BindGridView();
                txtItemName.Text = "";
              
                txtRate.Text = "";
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
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindGridView();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindGridView();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string ItemId = GridView1.DataKeys[e.RowIndex].Value.ToString();
         // find values for update
          //TextBox  = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtItemId");
          TextBox ItemName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtItemName");
        TextBox Rate = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtRate");
         FileUpload FileUpload1 = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("FileUpload1");
 
        string path = "../Images/";
        if (FileUpload1.HasFile)
        {
            path += FileUpload1.FileName;
            //save image in folder
            FileUpload1.SaveAs(MapPath(path));
        }
        else
        {
            // use previous user image if new image is not changed
            Image img = (Image)GridView1.Rows[e.RowIndex].FindControl("img_user");
            path = img.ImageUrl;
        }

        SqlCommand cmd = new SqlCommand("update AddItem set ItemName='" + ItemName.Text + "',Rate='" + Rate.Text + "',ItemPath='" + path + "'  where ItemId=" + ItemId + "", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
 
        GridView1.EditIndex = -1;
        BindGridView();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ItemId = GridView1.DataKeys[e.RowIndex].Value.ToString();
     
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from AddItem where ItemId=" + ItemId, con);
        int result = cmd.ExecuteNonQuery();
        con.Close();
        if (result == 1)
        {
            BindGridView();
           
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGridView();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        subcat();
    }
}