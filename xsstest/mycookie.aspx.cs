using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace xsstest
{
    public partial class mycookie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            desclass mydes = new desclass();
            string codeid=Request["codeid"];
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
                Label1.Text = "你好" + ownname;
                mysql sql = new mysql();
                if (codeid == "" || codeid == null)
                {
                    Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["localurl"].ToString() + "viewcode.aspx"); return;
                }
                GridView1.DataSource = sql.viewcode(codeid,ownname, 2);
                GridView1.DataBind();

            }
            else
            {
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["localurl"].ToString() + "login.aspx");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            mysql sql = new mysql();
            sql.deletecode(GridView1.Rows[e.RowIndex].Cells[1].Text.ToString(),"", 2);

            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["localurl"].ToString() + "viewcode.aspx");

        }
    }
}