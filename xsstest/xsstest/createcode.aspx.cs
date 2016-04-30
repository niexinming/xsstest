using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace xsstest
{
    public partial class createcode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            xssfile xf = new xssfile();
            mysql sql = new mysql();
            desclass mydes = new desclass();
            string flag = "false";
            flag = Request["flag"];
          
                string mycookie = "";
            string mysession = "";
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
                      if (flag == "true")
                      {
                          string codetitle = Request["codetitle"];
                          string codeducument = Request["codeducument"];
                          string beizhu = Request["beizhu"];
                          string mynname = ownname;
                          string yuancode = codeducument;
                          codetitle = xf.filet(codetitle);
                       //   codeducument = xf.filet(codeducument);
                          beizhu = xf.filet(beizhu);

                          sql.createcode(mynname, codetitle, codeducument, beizhu,yuancode);

                         Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["localurl"].ToString() + "viewcode.aspx");

                       }
             }
                else
                {
                    Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["localurl"].ToString() + "login.aspx");
                }
            }
        
    }
}