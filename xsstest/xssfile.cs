using System;
using System.Collections.Generic;
using System.Web;

namespace xsstest
{
    public class xssfile
    {
       public string filet(string str)
        {
           str= System.Web.HttpContext.Current.Server.HtmlEncode(str);
            return str;
        }

        
    }
}