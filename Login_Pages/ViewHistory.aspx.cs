using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Text;


public partial class ViewHistory : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|datadirectory|\phishdb.mdf;Integrated Security=True;User Instance=True");
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    
    string filename;

    protected void lnkView_Click(object sender, EventArgs e)
    {
        GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
        string id = grdrow.Cells[0].Text;

        con.Open();
        cmd = new SqlCommand("select * from historyc where id='" + id + "'  ", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {


         //  string ss=

            Response.Write("<script> window.open('" + dr["linktext"].ToString() + "','_blank'); </script>");
          

        }


    }


  

    protected void Button1_Click(object sender, EventArgs e)
    {



        Random rr = new Random();
        int i = rr.Next(1111, 9999);


        Session["otp"] = i.ToString();


        sendmessage(Session["mob"].ToString(), "Your Download Otp  " + i.ToString());




        string to = Session["mail"].ToString();
        string from = "sampletest685@gmail.com";
        // string subject = "Key";
        // string body = TextBox1.Text;
        string password = "hneucvnontsuwgpj";
        using (MailMessage mm = new MailMessage(from, to))
        {
            mm.Subject = "file Download Key";
            mm.Body = "Your Download Otp:" + i.ToString();

            //if (fuAttachment.HasFile)
            //{

            //}
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential(from, password);
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email has sent.');", true);



        }


    }

    public void sendmessage(string targetno, string message)
    {


        //String query = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=fantasy5535&password=1163974702&sendername=Sample&mobileno=" + targetno + "&message=" + message;
        //WebClient client = new WebClient();
        //Stream sin = client.OpenRead(query);
        Response.Write("<script> alert('Message Send ') </script>");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {



        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].Text = Decrypt(e.Row.Cells[1].Text);
            e.Row.Cells[2].Text = Decrypt(e.Row.Cells[2].Text);
           
        }
    }

    private string Decrypt(string cipherText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            Response.Write("<Script> alert('Please Enter OTP') </Script>");
        }
        else
        {



            if (TextBox1.Text == Session["otp"].ToString())
            {



                cmd = new SqlCommand("select * from historyc where username='" + Session["uname"].ToString() + "' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();




            }

            else
            {


                Response.Write("<Script> alert('otp Incorrect!') </Script>");

            }


        }
    }
}