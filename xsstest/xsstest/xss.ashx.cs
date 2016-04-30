using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace xsstest
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        
        public void ProcessRequest(HttpContext context)
        {
            mysql sql = new mysql();
            xssfile xs = new xssfile();
            string cookie = "";
            string codeid = context.Request["codeid"];
            cookie = context.Request["cookie"];
            
           // cookie = xs.filet(cookie);
          
            sql.inster(cookie,codeid);
            sql.sendmail(codeid);
            context.Response.Write(" ");


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}