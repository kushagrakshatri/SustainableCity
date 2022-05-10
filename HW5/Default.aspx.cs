using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using Newtonsoft.Json;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["myCookie"];

        if(cookie != null)
        {
            TextBox1.Text = cookie["input"];
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("myCookie");
        cookie["input"] = TextBox1.Text;
        cookie.Expires = DateTime.Now.AddMinutes(1);
        Response.Cookies.Add(cookie);

        string url1 = @"http://localhost:49867/Service.svc/solar?place=" + TextBox1.Text;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url1);
        request.ContentType = "application/json";
        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader sreader = new StreamReader(dataStream);
        string responsereader = sreader.ReadToEnd();
        response.Close();

        string solar = JsonConvert.DeserializeObject<string>(responsereader);

        string url2 = @"http://localhost:49867/Service.svc/wind?place=" + TextBox1.Text;
        HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(url2);
        request2.ContentType = "application/json";
        WebResponse response2 = request2.GetResponse();
        Stream dataStream2 = response2.GetResponseStream();
        StreamReader sreader2 = new StreamReader(dataStream2);
        string responsereader2 = sreader2.ReadToEnd();
        response2.Close();

        string wind = JsonConvert.DeserializeObject<string>(responsereader2);

        float solarNum = float.Parse(solar);
        float windNum = float.Parse(wind);

        float avg = (solarNum + windNum) / 2;

        string avgStr = string.Format("{0:N2}", avg);

        result.InnerHtml = avgStr;


    }
}