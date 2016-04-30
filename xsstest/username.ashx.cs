using System;
using System.Collections.Generic;
using System.Web;

namespace xsstest
{
    /// <summary>
    /// username 的摘要说明
    /// </summary>
    public class username : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            mysql sql = new mysql();
            string username=context.Request["username"];

            Boolean isusname = sql.login(username, "", 2);

            context.Response.Write(isusname);

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