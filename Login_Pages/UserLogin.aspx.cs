using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;

public partial class UserLogin : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\phishdb.mdf;Integrated Security=True;User Instance=True");
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";

    }

    string sts;

    protected void Button1_Click(object sender, EventArgs e)
    {






        string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
        Console.WriteLine(hostName);
        // Get the IP  
        string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();



        con.Open();
        cmd = new SqlCommand("select * from iptb  where Ip='" + myIP + "' ", con);
        SqlDataReader dr1 = cmd.ExecuteReader();
        if (dr1.Read())
        {

            sts = dr1["Status"].ToString();


        }
        else
        {


            dr1.Close();


            cmd = new SqlCommand("insert into iptb values('"+myIP +"','active')", con);
            cmd.ExecuteNonQuery();

           

        }
        con.Close();




        if (sts == "InActive")
        {
            Response.Write("<Script> alert('Ip has Block') </Script>");
        }
        else
        {
            con.Open();
            cmd = new SqlCommand("select * from regtb where UserNAme='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                Session["uname"] = TextBox1.Text;
                Session["mob"] = dr["Mobile"].ToString();
                Session["mail"] = dr["Email"].ToString();
                Response.Redirect("UserHome.aspx");


            }
            else
            {

                Response.Write("<Script> alert('username or Password Incorrect!') </Script>");

            }
            con.Close();

        }
    }
}