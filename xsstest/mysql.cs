using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace xsstest
{
    public class mysql
    {
       private  OleDbConnection getconn()
        {
            string connstr = "Provider=Microsoft.Jet.OLEDB.4.0 ;Data Source=" + System.Configuration.ConfigurationManager.ConnectionStrings["conn"];
            OleDbConnection tempconn = new OleDbConnection(connstr);

            return tempconn;

        }
        public void inster(string cookie,string codeid)
        {
            int intcodeid = Convert.ToInt16(codeid);
            OleDbConnection conn = getconn();
            OleDbCommand com = new OleDbCommand();
            com.Connection = conn;
            com.CommandText = "insert into [table](cookie,codeid)values(@cookie,@codeid)";

            com.Parameters.AddWithValue("@cookie", SqlDbType.VarChar);
            com.Parameters["@cookie"].Value = cookie;

            com.Parameters.AddWithValue("@codeid", SqlDbType.Int);
            com.Parameters["@codeid"].Value = intcodeid;

           
            conn.Open();
            com.ExecuteNonQuery();
            com.Dispose();
            conn.Close();

        }
        public Boolean login(string username,string userpass,int flag)
        {
            if (username == null || userpass == null) return false;
            OleDbConnection conn = getconn();
            OleDbCommand com = new OleDbCommand();
            OleDbDataReader reader;
            
            com.Connection = conn;
            if (flag == 1)
            {
                com.CommandText = "select myid,username,userpassword from [user] where username=@username and userpassword=@userpass";
                com.Parameters.AddWithValue("@username", SqlDbType.VarChar);
                com.Parameters["@username"].Value = username;
                com.Parameters.AddWithValue("@userpass", SqlDbType.VarChar);
                com.Parameters["@userpass"].Value = userpass;
            }
            else
            {
                com.CommandText = "select myid,username from [user] where username=@username";
                
                com.Parameters.AddWithValue("@username", SqlDbType.VarChar);
                com.Parameters["@username"].Value = username;
               
            }
            conn.Open();
            reader=com.ExecuteReader();
            reader.Read();
            try
            {
              int a=(int)reader["myid"];
            }
            catch(Exception e)
            {
                com.Clone();
                conn.Close();
                return false;
            }
            com.Dispose();
            conn.Close();
            return true;
        }
        public void register(string name,string psw,string mail)
        {
            OleDbConnection conn = getconn();
            OleDbCommand com = new OleDbCommand();
            com.Connection = conn;
            com.CommandText = "insert into [user](username,userpassword,mail)values(@name,@psw,@mail)";
            com.Parameters.AddWithValue("@name", SqlDbType.VarChar);
            com.Parameters["@name"].Value = name;
            com.Parameters.AddWithValue("@psw", SqlDbType.VarChar);
            com.Parameters["@psw"].Value = psw;
            com.Parameters.AddWithValue("@mail", SqlDbType.VarChar);
            com.Parameters["@mail"].Value = mail;

            conn.Open();
            com.ExecuteNonQuery();
            com.Dispose();
            conn.Close();
        }

        public DataSet viewcode(string name,string myname,int flag)
        {
          
            OleDbConnection conn = getconn();
            OleDbCommand com = new OleDbCommand();
            com.Connection = conn;
            switch(flag)
            {
                case 1:
                    {
                        com.CommandText = " SELECT code.codeid, code.mycodename,code.path FROM code INNER JOIN[user] ON code.myid = user.myid where[user].username = @name";
                        com.Parameters.AddWithValue("@name", SqlDbType.VarChar);
                        com.Parameters["@name"].Value = name;
                        break;
                    }
                case 2:
                    {
                        
                        com.CommandText = "SELECT table.ID, table.cookie, table.time FROM (code INNER JOIN [table] ON code.codeid = table.codeid) INNER JOIN [user] ON code.myid = user.myid where table.codeid=@name and [user].username=@myname";
                        com.Parameters.AddWithValue("@name", SqlDbType.Int);
                        com.Parameters["@name"].Value = name;

                        com.Parameters.AddWithValue("@myname", SqlDbType.VarChar);
                        com.Parameters["@myname"].Value = myname;
                        break;
                       
                    }
                case 3:
                    {
                        com.CommandText = "SELECT code.codeid, code.mycodename, code.mycodedocument, code.beizhu FROM code INNER JOIN [user] ON code.myid = user.myid where code.codeid=@name and [user].username=@myname";
                        com.Parameters.AddWithValue("@name", SqlDbType.Int);
                        com.Parameters["@name"].Value = name;

                        com.Parameters.AddWithValue("@myname", SqlDbType.VarChar);
                        com.Parameters["@myname"].Value = myname;
                        break;
                    }
        }
           
            OleDbDataAdapter adapter = new OleDbDataAdapter(com);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "viewcode");
            com.Dispose();
            conn.Close();
            return ds;
                
        }


        public void deletecode(string id ,string path,int flag)
        {
            int myid = Convert.ToInt32(id);
            OleDbConnection conn = getconn();
            OleDbCommand com = new OleDbCommand();
            com.Connection = conn;
            switch (flag) { 
                case 1:
                {
                    com.CommandText = "delete from code where codeid=@myid";
                    com.Parameters.AddWithValue("@myid", SqlDbType.Int);
                    com.Parameters["@myid"].Value = myid;
                    conn.Open();
                    com.ExecuteNonQuery();
                    com.Dispose();
                    conn.Close();



                    conn = getconn();
                    com = new OleDbCommand();
                    com.Connection = conn;
                    com.CommandText = "delete from [table] where codeid=@myid";
                    com.Parameters.AddWithValue("@myid", SqlDbType.Int);
                    com.Parameters["@myid"].Value = myid;
                    break;
                }
            case 2:
                {
                    com.CommandText = "delete from table where ID=@myid";
                    com.Parameters.AddWithValue("@myid", SqlDbType.Int);
                    com.Parameters["@myid"].Value = myid;
                    break;
                }
            case 3:
                {
                    com.CommandText = "update code set path=@path where code.codeid=@myid";
                        com.Parameters.AddWithValue("@path", SqlDbType.VarChar);
                        com.Parameters["@path"].Value = path;

                        com.Parameters.AddWithValue("@myid", SqlDbType.Int);
                    com.Parameters["@myid"].Value = myid;
                    break;
                }
            }
            conn.Open();
            com.ExecuteNonQuery();
            com.Dispose();
            conn.Close();
        }

        public void createcode(string username, string codetitle, string codeducument, string beizhu,string yuancode)
        {
            int myid;
            OleDbConnection conn = getconn();
            OleDbCommand com = new OleDbCommand();
            OleDbDataReader reader;

            com.Connection = conn;
            com.CommandText = "select myid,username from [user] where username=@username";
            com.Parameters.AddWithValue("@username", SqlDbType.VarChar);
            com.Parameters["@username"].Value = username;
            conn.Open();
            reader = com.ExecuteReader();
            reader.Read();
            try
            {
                myid = (int)reader["myid"];
            }
            catch (Exception e)
            {
                com.Dispose();
                conn.Close();
                return;
            }
            reader.Close();
            com.Parameters.Clear();
            com.CommandText = "insert into code(myid,mycodename,mycodedocument,beizhu,yuancode)values(" + myid + ",@codetitle,@codeducument,@beizhu,@yuancode)";
            com.Parameters.AddWithValue("@codetitle", SqlDbType.VarChar);
            com.Parameters["@codetitle"].Value = codetitle;

            com.Parameters.AddWithValue("@codeducument", SqlDbType.VarChar);
            com.Parameters["@codeducument"].Value = codeducument;

            com.Parameters.AddWithValue("@beizhu", SqlDbType.VarChar);
            com.Parameters["@beizhu"].Value = beizhu;

            com.Parameters.AddWithValue("@yuancode", SqlDbType.VarChar);
            com.Parameters["@yuancode"].Value = yuancode;
            com.ExecuteNonQuery();
            com.Dispose();
            conn.Close();
        }

        public string selectcode(string codeid,string unm,int flag)
        {
            string canshu = "";
            if (flag == 1) canshu = "yuancode"; else canshu = "path";
            OleDbConnection conn = getconn();
            OleDbCommand com = new OleDbCommand();
            OleDbDataReader reader;
            string codedocument = "";
            com.Connection = conn;
          
                com.CommandText = "SELECT code.yuancode FROM code INNER JOIN [user] ON code.myid = user.myid where code.codeid=@codeid and [user].username=@unm";
                com.Parameters.AddWithValue("@codeid", SqlDbType.Int);
                com.Parameters["@codeid"].Value = codeid;

                 com.Parameters.AddWithValue("@unm", SqlDbType.VarChar);
                 com.Parameters["@unm"].Value =unm;

            conn.Open();
                reader = com.ExecuteReader();
                reader.Read();
                try
                {
                    codedocument = reader[canshu].ToString();
                }
                catch (Exception e)
                {
                    com.Clone();
                    conn.Close();
                    return null;
                }
           
            com.Dispose();
            conn.Close();
            return codedocument;
        }


        public void sendmail(string codeid)
        {
            mail mm = new mail();
            string username = "";
            string mailurl = "";
            string cookiecontent = "";
            OleDbConnection conn = getconn();
            OleDbCommand com = new OleDbCommand();
            OleDbDataReader reader;

            com.Connection = conn;
            com.CommandText = "SELECT top 1 user.username, user.mail, table.cookie FROM (code INNER JOIN [user] ON code.myid = user.myid) INNER JOIN [table] ON code.codeid = table.codeid  where table.codeid=@codeid order by table.time desc";
            com.Parameters.AddWithValue("@codeid", SqlDbType.Int);
            com.Parameters["@codeid"].Value = codeid;
            conn.Open();
            reader = com.ExecuteReader();
            reader.Read();
            try
            {
                username = reader["username"].ToString();
                mailurl = reader["mail"].ToString();
                cookiecontent = reader["cookie"].ToString();
            }
            catch (Exception e)
            {
                com.Dispose();
                conn.Close();
                return;
            }
            mm.sendmail(username, mailurl, cookiecontent);
            com.Dispose();
            conn.Close();
            return;
        }

        public void updatecode(string codeid,string title,string document,string beizhu)
        {
           
            OleDbConnection conn = getconn();
            OleDbCommand com = new OleDbCommand();
            com.Connection = conn;
            com.CommandText = "update code set mycodedocument=@document,mycodename=@title,beizhu=@beizh,yuancode=@document where codeid=@codeid";
            com.Parameters.AddWithValue("@document", SqlDbType.VarChar);
            com.Parameters["@document"].Value = document;


            com.Parameters.AddWithValue("@title", SqlDbType.VarChar);
            com.Parameters["@title"].Value =title;


            com.Parameters.AddWithValue("@beizh", SqlDbType.VarChar);
            com.Parameters["@beizh"].Value = beizhu;

            com.Parameters.AddWithValue("@codeid", SqlDbType.Int);
            com.Parameters["@codeid"].Value = codeid;

            conn.Open();
            com.ExecuteNonQuery();
            com.Dispose();
            conn.Close();
        }

    }
}


