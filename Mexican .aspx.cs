using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class UserAccount_Mexican : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null || string.IsNullOrEmpty(Session["UserId"].ToString()))
        {
            Response.Redirect("~/Login.aspx/?r=UserAccount/Mexican.aspx");
        }
        if (!IsPostBack)
        {
            filldl();
        }
        CountCart();
        lblmgs.Text = Session["UserId"].ToString();
    }
    public void CountCart()
    {

        try
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_ShowCartItemsCount";

            int UserId = Convert.ToInt32(Session["UserId"]);

            cmd.Parameters.AddWithValue("@UserId", UserId);

            cmd.Connection = con;
            int ItemsCount;
            ItemsCount = Convert.ToInt32(cmd.ExecuteScalar());

            LinkButton1.Text = "ViewCart" + " ( " + ItemsCount + " )";
            con.Close();
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }



    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
    public void filldl()
    {

        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select ItemId,ItemPath,CAST(CAST(Rate As money) As decimal(8, 2))as Rate,ItemName from AddItem ";
        DataTable dt = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        dlItems.DataSource = dt;
        dlItems.DataBind();
        con.Close();



    }
    protected void dlItems_ItemCommand(object source, DataListCommandEventArgs e)
    {
        //CultureInfo india = new CultureInfo("en-IN");
        //DateTime instance = DateTime.Parse(txtinvoicedate.Text, india);
        int index = Convert.ToInt32(e.Item.ItemIndex);
        Label lblitem = (Label)e.Item.FindControl("Label1");
        //Label lblqun = (Label)e.Item.FindControl("lblquantity");
        Label lblItemName = (Label)e.Item.FindControl("lblItemName");
        Label lblPrice = (Label)e.Item.FindControl("lblPrice");
        string today = DateTime.Today.ToString("dd-MM-yyyy");
        Label lblUserId = (Label)e.Item.FindControl("lblUserId");
        lblUserId.Text = lblmgs.Text;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.CommandText = "sp_GridaddCart";
        //cmd.Parameters.AddWithValue("@ItemId", lblitem.Text);
        //cmd.Parameters.AddWithValue("@Quantity", lblqun.Text);
        //cmd.Parameters.AddWithValue("@Rate", lblPrice.Text);
        //cmd.Parameters.AddWithValue("@Date", today);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Sp_AddDeletecart";
        cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(lblUserId.Text));
        cmd.Parameters.AddWithValue("@ItemId", lblitem.Text);
        //cmd.Parameters.AddWithValue("@Quntity", lblqun.Text);
        cmd.Parameters.AddWithValue("@Rate", lblPrice.Text);
        cmd.Parameters.AddWithValue("@Date", today);

        if (e.CommandName == "Addcart")
        {
            cmd.CommandText = "Sp_AddDeletecart";
            cmd.Parameters.AddWithValue("@Type", "add");
        }
        if (e.CommandName == "deletecart")
        {
            cmd.CommandText = "Sp_AddDeletecart";
            cmd.Parameters.AddWithValue("@Type", "dele");
        }



        cmd.Connection = con;
        int res = cmd.ExecuteNonQuery();
        if (res > 0)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Added successfully')</script>");


            CountCart();
            if (e.CommandName == "Addcart")
            {

                Button Addcart = (Button)e.CommandSource;
                Addcart.Visible = false;
            }



        }

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewCart.aspx");
    }
    protected void dlItems_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}