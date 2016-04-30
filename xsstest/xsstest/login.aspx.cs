using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
namespace xsstest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = Text1.Value;
            string pass = Text2.Value;
            Boolean isok = false;
            mysql sql = new mysql();
            desclass mydes = new desclass();
            if(name=="" || pass=="")
            {
                Label3.Text = "用户名密码不能为空";
            }
            else
            {
                pass = mydes.EnCode(pass);
                pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "MD5");
                isok =sql.login(name, pass,1);
                if(isok==false)
                {
                    Label3.Text = "用户名或密码错误";
                }
                else
                {
                    string desname = mydes.EnCode(name);
                    Session["username"] = name;
                    HttpCookie myHttpCookie = new HttpCookie("name", desname);
                    myHttpCookie.HttpOnly = true;
                    Response.AppendCookie(myHttpCookie);
                    Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["localurl"].ToString() + "viewcode.aspx");
                }
            }
        }
    }
}