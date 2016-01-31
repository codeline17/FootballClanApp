using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using Objects;

namespace FCW.Actions
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly string _connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["FCWConn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var username = Request.Params["username"];
                var password = Request.Params["password"];

                using (var conn = new SqlConnection(_connectionstring))
                {
                    using (var cmd = new SqlCommand("UserLogin", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@username", SqlDbType.VarChar, 20).Value = username;
                        cmd.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = password;

                        var user = new Objects.User();
                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            user = new Objects.User(username, password, new Guid(reader["GUID"].ToString()), 
                            new UserDetails(reader["Email"].ToString(), reader["Address"].ToString(), new City("Tirana")));
                        }

                        var json = new JavaScriptSerializer().Serialize(user);

                        Session["currentUser"] = user;

                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.Write(json);
                        Response.End();
                    }
                }
            }   
            catch (Exception ex)
            {
                //throw ex;
            }
        }
    }
}