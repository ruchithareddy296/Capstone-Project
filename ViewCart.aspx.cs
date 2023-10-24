using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
public partial class UserAccount_ViewCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null || string.IsNullOrEmpty(Session["UserId"].ToString()))
        {
            Response.Redirect("~/Login.aspx/?r=UserAccount/ViewCart.aspx");
        }
        if (!IsPostBack)
        {
            cartid();
            BindGridView();
            m1();
            lblCartId.Visible = false;
        }
    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
    public void cartid()
    {
        lblRes.Text = Session["UserId"].ToString();
        try
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select CartId from AddCart where Userid=" + lblRes.Text + " and Status=0";
            cmd.Connection = con;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                lblCartId.Text = sdr[0].ToString();
            }

        }
        catch (Exception ex)
        {
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
            cmd.CommandText = "Sp_ViewCart";
            cmd.Parameters.AddWithValue("@CartId", lblCartId.Text);
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
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindGridView();

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            con.Open();
            string CartId = ((Label)(GridView1.Rows[e.RowIndex].FindControl("lblCartId"))).Text;

            string ItemId = ((Label)(GridView1.Rows[e.RowIndex].FindControl("lblItemId"))).Text;


            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_deleteCart";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@ItemID", ItemId);
            cmd.Parameters.AddWithValue("@CartId", CartId);

            cmd.Connection = con;
            int res = cmd.ExecuteNonQuery();
            if (res > 0)
            {
                con.Close();
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('delete Success')</script>");
                BindGridView();
                m1();
            }
            else
            {

                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('delete Not Success')</script>");
            }

        }
        catch (Exception ex)
        {

        }
        finally
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            //Mbind();
        }

        GridView1.EditIndex = -1;
        BindGridView();


    }
  
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindGridView();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
           
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertSales";

            decimal DiscountAmount = 0;
            //decimal per = Convert.ToDecimal(txtDisPer.Text);
            //DiscountAmount = Convert.ToDecimal(Convert.ToDecimal(txtNetAmonut.Text) * (Convert.ToDecimal(per / 100)));

            //txtTAmount.Text = (Convert.ToDecimal(Convert.ToDecimal(txtNetAmonut.Text) - DiscountAmount)).ToString();

            cmd.Parameters.AddWithValue("@NetAmount", Convert.ToDecimal(txtNetAmonut.Text));
            cmd.Parameters.AddWithValue("@AccountNo", RadioButtonList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@CardType", txtAccount.Text);
            cmd.Parameters.AddWithValue("@Date", TextBox1.Text);

            //cmd.Parameters.AddWithValue("@TotalAmount", Convert.ToDecimal(txtTAmount.Text));
            //cmd.Parameters.AddWithValue("@DiscountPercentage", txtDisPer.Text);
            cmd.Parameters.AddWithValue("@CartId", Convert.ToInt32(lblCartId.Text));

            int UserId = Convert.ToInt32(Session["UserId"]);
            cmd.Parameters.AddWithValue("@UserId", UserId);           

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Ordered Successfully')</script>");

                //BindGridView();
                //txtTAmount.ReadOnly = true;
                
                txtAccount.ReadOnly = true;
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
        catch (Exception ex)
        {
        }

    }
    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }


    }
    decimal total = 0;
    public void m1()
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {

            Label LblNetAmount = (Label)(GridView1.Rows[i].FindControl("lblNetAmount"));

            string str = LblNetAmount.Text;

            if (LblNetAmount.Text != null && LblNetAmount.Text != "" && LblNetAmount.Text != string.Empty)
            {
                total += Convert.ToDecimal(LblNetAmount.Text);
            }

        }

        txtNetAmonut.Text = total.ToString();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            decimal total = 0;

            con.Open();
            string CartId = ((Label)(GridView1.Rows[e.RowIndex].FindControl("lblCartId"))).Text;
            string Rate = ((Label)(GridView1.Rows[e.RowIndex].FindControl("lblRate"))).Text;
            // string Pkg = ((Label)(GdvMCuustomerinvoice.Rows[e.RowIndex].FindControl("lblPkg"))).Text;
            string NetAmount = ((Label)(GridView1.Rows[e.RowIndex].FindControl("lblNetAmount"))).Text;
          string NoOfItems = ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("txtNoOfItems"))).Text;
            string ItemId = ((Label)(GridView1.Rows[e.RowIndex].FindControl("lblItemId"))).Text;
            string CName = ((Label)(GridView1.Rows[e.RowIndex].FindControl("lblCName"))).Text;
         //   string quantity = ((Label)(GridView1.Rows[e.RowIndex].FindControl("lblQuntity"))).Text;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_UpdateCart";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@ItemID", ItemId);
            cmd.Parameters.AddWithValue("@CartId", CartId);
            cmd.Parameters.AddWithValue("@Rate", Rate);

            cmd.Parameters.AddWithValue("@CName", CName);
           cmd.Parameters.AddWithValue("@NoOfItems", NoOfItems);
            cmd.Connection = con;
            int res = cmd.ExecuteNonQuery();
            if (res > 0)
            {
                con.Close();
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Updated Success')</script>");

                
                BindGridView();

                for (int i = 0; i < GridView1.Rows.Count; i++ )
                {

                    Label LblNetAmount = (Label) (GridView1.Rows[i].FindControl("lblNetAmount"));

                    string str = LblNetAmount.Text ;

                    if (LblNetAmount.Text != null && LblNetAmount.Text !="" && LblNetAmount.Text != string.Empty)
                    {
                        total += Convert.ToDecimal(LblNetAmount.Text);
                    }

                }

                txtNetAmonut.Text = total.ToString();



            }
            else
            {

                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Updated Not Success')</script>");
            }

        }
        catch (Exception ex)
        {

        }
        finally
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            //Mbind();
        }

        GridView1.EditIndex = -1;
        BindGridView();

    }
}

    

