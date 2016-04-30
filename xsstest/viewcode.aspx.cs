using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace xsstest
{
    public partial class viewcode : System.Web.UI.Page
    {
        string gloadmyname = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            
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
                gloadmyname = ownname;
                mysql sql = new mysql();
                GridView1.DataSource = sql.viewcode(ownname,"",1);
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
            sql.deletecode(GridView1.Rows[e.RowIndex].Cells[0].Text.ToString(),gloadmyname,1);
            string filename = sql.selectcode(GridView1.Rows[e.RowIndex].Cells[0].Text.ToString(), gloadmyname, 2);
            if (File.Exists(filename))
            {
                //如果存在则删除
                File.Delete(filename);
            }
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["localurl"].ToString() + "viewcode.aspx");
          
        }

       

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            
            GridViewRow row = GridView1.SelectedRow;
          
            string Name = row.Cells[0].Text;
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["localurl"].ToString() + "mycookie.aspx?codeid=" + Name);
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            //GridViewRow row = GridView1.SelectedRow;

            string Name = GridView1.Rows[e.NewEditIndex].Cells[0].Text.ToString();
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["localurl"].ToString() + "editcode.aspx?codeid=" + Name);
        }
    }
}
