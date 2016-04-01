using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Serialization;

namespace FCW.Actions
{
    public partial class Register : System.Web.UI.Page
    {
        private Objects.User _user = new Objects.User();
        private readonly string _key =
            ConfigurationManager.AppSettings["safetykey"];
        private readonly string _connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["FCWConn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!SecurityCheck())
                    ReturnError();

                var username = Request.Params["username"];
                var password = Request.Params["password"];
                var email = Request.Params["email"];

                using (var conn = new SqlConnection(_connectionstring))
                {
                    using (var cmd = new SqlCommand("UserCreate", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20).Value = username.Trim();
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 20).Value = password.Trim();
                        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 20).Value = email.Trim();

                        conn.Open();
                        var reader = cmd.ExecuteScalar();

                        var json = new JavaScriptSerializer().Serialize(reader);
                        
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.Write(json);
                        HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                        HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                        HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
                    }
                }
            }
            catch (Exception)
            {
                //throw ex;
            }
        }

        protected void ReturnError()
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Write("Error");
            Response.End();
        }
        protected bool SecurityCheck()
        {
            bool r;

            try
            {
                _user = (Objects.User)Session["currentUser"];
                r = _user.Guid != null || (_key.Length == Request.Params["safetykey"].Length && _key == Request.Params["safetykey"]);
            }
            catch (Exception)
            {
                r = false;
            }

            return r;
        }
    }
}