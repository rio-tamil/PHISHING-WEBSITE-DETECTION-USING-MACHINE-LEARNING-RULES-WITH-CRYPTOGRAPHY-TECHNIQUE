using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;

public partial class UploadImage : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|Datadirectory|\phishdb.mdf;Integrated Security=True;User Instance=True");
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        grid();
    }

    string filepath;

    protected void Button1_Click(object sender, EventArgs e)
    {
        string filename = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Upload/" + filename));
        filepath = Server.MapPath("~/Upload/" + filename);
        FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
        BinaryReader br = new BinaryReader(fs);
        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
        br.Close();
        fs.Close();



        cmd = new SqlCommand("insert into imagetb values(@ImageName,@CompanyName,@FilePath,@FileData)", con);
        cmd.Parameters.AddWithValue("@ImageName", TextBox1.Text);
        cmd.Parameters.AddWithValue("@CompanyName", TextBox2.Text);
        cmd.Parameters.AddWithValue("@FilePath", "~/Upload/" + filename);
        cmd.Parameters.AddWithValue("@FileData", bytes);
     
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();


        Response.Write("<Script> alert('Image Info Saved!') </Script>");
        grid();

    }

    protected void lnkView_Click(object sender, EventArgs e)
    {
        GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
        string id = grdrow.Cells[0].Text;



        con.Open();
        cmd = new SqlCommand("Delete from imagetb where id='" + id + "' ", con);
        cmd.ExecuteNonQuery();
        con.Close();

        grid();


    }

    private void grid()
    {
        cmd = new SqlCommand("select * from imagetb  ", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView2.DataSource = dt;
        GridView2.DataBind();

    }

} 