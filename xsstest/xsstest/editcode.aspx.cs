using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace xsstest
{
    public partial class editcode : System.Web.UI.Page
    {
        
        string mycodeid = "";
        string mynameis = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if(Request["FormView1$button1"].ToString()== "提交编辑代码")
                {
                    mysql sql = new mysql();
                    xssfile xs = new xssfile();
                    string beizhu = Request["FormView1$beizhu"];
                    string document = Request["FormView1$mycodedocument"];
                    string title = Request["FormView1$mycodename"];
                    string codeid = Request["codeid"];

                    beizhu = xs.filet(beizhu);
                    title = xs.filet(title);


                    sql.updatecode(codeid, title, document, beizhu);

                    Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["localurl"].ToString() + "success.html");
                    return;

                }
               
            }
             catch
            {

            }
                string mycookie = "";
                string mysession = "";
                desclass mydes = new desclass();
                try
                {
                    mysession = Session["username"].ToString();
                }
                catch
                { mysession = null; }

                try
                {

                    mycookie = Request.Cookies["name"].Value;

                }
                catch
                {
                    mycookie = null;

                }
                string ownname = mydes.yanzheng(mycookie, mysession);
                if (ownname != null)
                {
                    mycodeid = Request["codeid"];
                    if (mycodeid == "" || mycodeid == null)
                    {
                        Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["localurl"].ToString() + "viewcode.aspx"); return;
                    }
                    mynameis = ownname;

                    mysql sql = new mysql();

                    FormView1.DataSource = sql.viewcode(mycodeid, ownname, 3);
                    FormView1.DataBind();


                }
                else
                {
                    Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["localurl"].ToString() + "login.aspx");
                }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            string code = "";
            mysql sql = new mysql();
            code=sql.selectcode(mycodeid, mynameis, 1);

            if(code!=null)
            {
               
                Random ran = new Random();
                int RandKey = ran.Next(100, 999);
                string path = System.Configuration.ConfigurationManager.AppSettings["localpath"].ToString()  + mynameis + "\\" + DateTime.Now.ToFileTimeUtc()+ RandKey.ToString() + ".js";
                FileStream fs = new FileStream(path, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(code);
                sw.Close();
                fs.Close();
                Label1.Text = path;
                sql.deletecode(mycodeid, path, 3);
            }

        }

      
    }
}
