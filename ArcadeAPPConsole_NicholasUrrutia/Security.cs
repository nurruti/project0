using System;
using System.Data.SqlClient;

namespace ArcadeAPPConsole_NicholasUrrutia
{
    class Security
    {
        public bool Login(string uName,string pwd)
        {
            SqlConnection con = new SqlConnection(@"server=DESKTOP-2LDPKO5\NICHOLASINSTANCE;database=project0;integrated security=true");
            SqlCommand cmd_login = new SqlCommand("select count(*) from login where username=@userName and password=@pwd",con);

            cmd_login.Parameters.AddWithValue("@userName",uName);
            cmd_login.Parameters.AddWithValue("@pwd",pwd);

//Trying to make sense of this...
            try
            {
                //Opens the connection and checks login table for usernames and passwords
                con.Open();
                int credential_count =(int) cmd_login.ExecuteScalar();
                if (credential_count > 0)//if a match is found...
                {
                    return true;//then you log in
                }
                else//otherwise...
                {
                    return false;//login fails
                }
            }
            catch (System.Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}