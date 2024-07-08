using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class FeedBack : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|Datadirectory|\phishdb.mdf;Integrated Security=True;User Instance=True");
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        Label4.Text = Session["uname"].ToString();

        cmd = new SqlCommand("select * from feedtb ", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        cmd = new SqlCommand("insert into feedtb values('" + Session["uname"].ToString() + "','" + TextBox1.Text + "')", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close ();
        Response.Write("<Script> alert('Feedback Info Saved!') </Script>");

        cmd = new SqlCommand("select * from feedtb ", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";

    }
}