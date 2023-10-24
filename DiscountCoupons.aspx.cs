using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

public partial class Admin_DiscountCoupons : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["aname"] == null || string.IsNullOrEmpty(Session["aname"].ToString()))
        {
            Response.Redirect("~/Login.aspx/?r=Admin/DiscountCoupons.aspx");
        }
        if (!IsPostBack)
        {
            cat();
            BindGridView();
        }
        
    }
    protected void BindGridView()
    {
        try
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_viewDiscountCoupons";
            //cmd.Parameters.AddWithValue("@DiscountPercentage", txtDisPercentage.Text);
            //cmd.Parameters.AddWithValue("@ItemName", ddlItemName.SelectedItem.Text);
            //cmd.Parameters.AddWithValue("@CName",ddlCat.SelectedItem.Text);
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            con.Close();
        }
    }

    //protected void BindGridView()
    //{
    //    DataTable dt = new DataTable();
    //    SqlDataAdapter da = new SqlDataAdapter("Select CoupnID,DiscountPercentage,ItemId,CId from DiscountCoupons", con);
    //    con.Open();
    //    da.Fill(dt);
    //    con.Close();

    //    if (dt.Rows.Count > 0)
    //    {
    //        GridView1.DataSource = dt;
    //        GridView1.DataBind();
    //    }
    //}

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

    public void filldl()
    {

        //if (con.State == ConnectionState.Open)
        //{
        //    con.Close();
        //}
        //con.Open();
        //SqlCommand cmd = con.CreateCommand();
        //cmd.CommandType = CommandType.Text;
        //cmd.CommandText = "select ItemId,ItemPath,CAST(CAST(Rate As money) As decimal(8, 2))as Rate from DiscountCoupens";
        //DataTable dt = new DataTable();
        //SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //adp.Fill(dt);
        //dlItems.DataSource = dt;
        //dlItems.DataBind();
        //con.Close();
        


    }
   
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        string strQuery = "SpAddCoupens";
        SqlCommand cmd = new SqlCommand(strQuery); 
        cmd.Parameters.AddWithValue("@ItemId", ddlItemName.SelectedValue);
        cmd.Parameters.AddWithValue("@CName", ddlCat.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@DiscountPercentage", txtDisPercentage.Text);

        //decimal DiscountAmount=0;
        // decimal per=  Convert.ToDecimal(txtDisPercentage.Text);
        // DiscountAmount = Convert.ToDecimal(Convert.ToDecimal(txtRate.Text) * (Convert.ToDecimal(per / 100)));

         //cmd.Parameters.AddWithValue("@DiscountAmount", DiscountAmount);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Discount Coupons Added')</script>");
            BindGridView();
          //  ddlCat.SelectedIndex = -1;
            ddlItemName.SelectedIndex = -1;
            txtDisPercentage.Text = "";
            //txtRate.Text = "";
            
            
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

        //if (FileUpload1.PostedFile != null)
        //{
        //    string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

        //    //Save files to disk
        //    FileUpload1.SaveAs(Server.MapPath("Images/" + FileName));


        //    //Add Entry to DataBase
        //    String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        //    SqlConnection con = new SqlConnection(strConnString);
        //    string strQuery = "AddItemsForDisc";
        //    SqlCommand cmd = new SqlCommand(strQuery);
        //    cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text);
        //    cmd.Parameters.AddWithValue("@CName", DropDownList1.SelectedItem.Text);
        //    cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text);
        //    cmd.Parameters.AddWithValue("@Rate", txtRate.Text);
        //    cmd.Parameters.AddWithValue("@ItemPath", "Images/" + FileName);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Connection = con;
        //    try
        //    {
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        filldl(); 
        //        txtItemName.Text = "";
        //        txtQuantity.Text = "";
        //        txtRate.Text = "";
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        //    finally
        //    {
        //        con.Close();
        //        con.Dispose();
        //    }
        //}
    }

    public void cat()
    {

        try
        {
            ddlCat.Items.Clear();
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
            ddlCat.Items.Insert(0, "----Select----");
            if (dt.Rows.Count > 0)
            {


                ddlCat.DataSource = dt;
                ddlCat.DataTextField = "CName";
                ddlCat.DataValueField = "CId";
                ddlCat.DataBind();

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

    protected void ddlCat_SelectedIndexChanged(object sender, EventArgs e)
    {

       try
        {
            ddlItemName.Items.Clear();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_ShowItems";
            cmd.Parameters.AddWithValue("@CName", ddlCat.SelectedItem.Text);
            

            cmd.Connection = con;
  
           
        

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            ddlItemName.Items.Insert(0, "----Select----");
            if (dt.Rows.Count > 0)
            {
               

                ddlItemName.DataSource = dt;
                ddlItemName.DataTextField = "ItemName";
                ddlItemName.DataValueField = "ItemId";
                ddlItemName.DataBind();

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
    protected void ddlItemName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DataTable dt =(DataTable) Cache["Rate"];

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    if (dt.Rows[i][1].ToString() == ddlItemName.SelectedItem.Text)
        //    {

        //        txtRate.Text = dt.Rows[i][2].ToString();
        //    }


        //}
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string CoupnID = GridView1.DataKeys[e.RowIndex].Value.ToString();
        // find values for update
        //TextBox  = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtItemId");
        TextBox DiscountPercentage = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDiscountPercentage");
        SqlCommand cmd = new SqlCommand("update DiscountCoupons set DiscountPercentage='" + DiscountPercentage.Text + "'  where CoupnID=" + CoupnID + "", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        GridView1.EditIndex = -1;
        BindGridView();
        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Update Success')</script>");

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindGridView();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string CoupnID  = GridView1.DataKeys[e.RowIndex].Value.ToString();

        con.Open();
        SqlCommand cmd = new SqlCommand("delete from DiscountCoupons where CoupnID=" + CoupnID, con);
        int result = cmd.ExecuteNonQuery();
        con.Close();
        if (result == 1)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Delete Success')</script>");

            BindGridView();

        }
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindGridView();
    }
}