using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;



public partial class Search : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|Datadirectory|\phishdb.mdf;Integrated Security=True;User Instance=True");
    SqlCommand cmd;
    SqlConnection mycon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\phishdb.mdf;Integrated Security=True;User Instance=True");
    SqlCommand mycmd;
    // public static DocumentCollection docCollection;
    public class ItemNews
    {
        public string title { get; set; }
        public string link { get; set; }
        public string item_id { get; set; }
        public string PubDate { get; set; }
        public string Description { get; set; }
        public string content { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    string type;

    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        cmd = new SqlCommand("select * from phistb where url like '%" + TextBox1.Text + "%'  ", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            type = dr["type"].ToString();


            if (type == "Phishing")
            {
                Response.Write("<Script> alert('This Website Like Phishing Website!')</Script>");

                GridView2.DataSource = null;
                GridView2.DataBind();
            }
            else
            {

                dr.Close();

                List<ItemNews> Details = new List<ItemNews>();

                // httpWebRequest with API url
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://news.google.com/news?q=" + TextBox1.Text + "&output=rss");

                //Method GET
                request.Method = "GET";

                //HttpWebResponse for result
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();


                //Mapping of status code
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == "")
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                    //Get news data in json string

                    string data = readStream.ReadToEnd();

                    //Declare DataSet for put data in it.
                    DataSet ds = new DataSet();
                    StringReader reader = new StringReader(data);
                    ds.ReadXml(reader);
                    DataTable dtGetNews = new DataTable();

                    if (ds.Tables.Count > 3)
                    {
                        dtGetNews = ds.Tables["item"];

                        foreach (DataRow dtRow in dtGetNews.Rows)
                        {
                            ItemNews DataObj = new ItemNews();
                            DataObj.title = dtRow["title"].ToString();
                            DataObj.link = dtRow["link"].ToString();
                            DataObj.item_id = dtRow["item_id"].ToString();
                            DataObj.PubDate = dtRow["pubDate"].ToString();
                            DataObj.Description = dtRow["description"].ToString();
                            // DataObj.content = dtRow["Content"].ToString();
                            Details.Add(DataObj);


                            string your_String = dtRow["title"].ToString();
                            string my_String = Regex.Replace(your_String, @"[^0-9a-zA-Z]+", " ");

                            mycmd = new SqlCommand("insert into historyc values (@keyword,@title,@linktext,@link,@description,@date,@Username)", mycon);
                            mycmd.Parameters.AddWithValue("@keyword", Encrypt(TextBox1.Text));
                            mycmd.Parameters.AddWithValue("@title", Encrypt(my_String));
                            mycmd.Parameters.AddWithValue("@linktext", dtRow["link"].ToString());
                            mycmd.Parameters.AddWithValue("@link", dtRow["item_id"].ToString());
                            mycmd.Parameters.AddWithValue("@description", dtRow["description"].ToString());
                            mycmd.Parameters.AddWithValue("@date", DateTime.Today.ToString());
                            mycmd.Parameters.AddWithValue("@Username", Session["uname"].ToString());
                            mycon.Open();
                            mycmd.ExecuteNonQuery();
                            mycon.Close();



                        }


                    }

                    GridView2.DataSource = dtGetNews;
                    GridView2.DataBind();

                }

            }

        }


          

        else
        {


            Response.Write("<Script> alert('This Website Not Found!')</Script>");
           
        }
        con.Close();
    }


    private string Encrypt(string clearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }
}