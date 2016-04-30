using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
namespace xsstest
{
    public partial class register : System.Web.UI.Page
    {
        private void createfile(string ownname)
        {
            string sPath = System.Configuration.ConfigurationManager.AppSettings["localpath"].ToString() + ownname;
            if (!Directory.Exists(sPath))

            {

                Directory.CreateDirectory(sPath);

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           string flag = "false";

            flag = Request["flag"];
            if (flag=="true")
            {
                string name = "", psw = "", mail = "";
                mysql sql = new mysql();
                xssfile xs = new xssfile();
                desclass mydes = new desclass();
                name = Request["name"];
                psw = Request["mima1"];
                mail = Request["mail"];

               


                if (name == "" || psw == "" || mail == "")
                {
                    Label4.Text = "用户名或密码或邮箱不能为空";
                }
                else
                {
                    name = xs.filet(name);
                    psw = xs.filet(psw);
                    mail = xs.filet(mail);

                    Regex regn = new Regex(@"^[A-Za-z0-9_]+$");
                    bool nameisok = regn.IsMatch(name);
                    if (nameisok == false) {Response.Write("用户名必须是3 -16个字母,数字,下划线"); return; }

                    Regex regm = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                    bool mailisok = regn.IsMatch(mail);
                    if (nameisok == false) { Response.Write("邮箱格式不正确"); return; }


                    psw = mydes.EnCode(psw);
                    psw = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(psw, "MD5");
                    sql.register(name, psw, mail);

                    createfile(name);

                    Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["localurl"].ToString() + "login.aspx");
                }
            }
        }
       

       
    }
}