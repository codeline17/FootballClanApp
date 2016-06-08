using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
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
                var code = Request.Params["type"];

                switch (code)
                {
                    case "Login":
                        UserLogin();
                        break;
                    case "CookieCheck":
                        CookieCheck();
                        break;
                }

            }   
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        private void UserLogin()
        {
            var username = Request.Params["username"];
            var password = Request.Params["password"];
            var device_type = Request.Params["device_type"];
            var push_id = Request.Params["push_id"];
            if (device_type==null)
            {
                device_type = "00000000000000000000000000000000000000000000000000";
            }
            if (push_id==null)
            {
                push_id = "00000000000000000000000000000000000000000000000000";
            }
            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("UserLogin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@username", SqlDbType.VarChar, 20).Value = username;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = password;
                    cmd.Parameters.Add("@DeviceType", SqlDbType.VarChar, 100).Value = device_type;
                    cmd.Parameters.Add("@PushId", SqlDbType.VarChar, 100).Value = push_id;

                    var user = new Objects.User();
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new Objects.User(username, new Guid(reader["GUID"].ToString()),
                            Convert.ToInt32(reader["Credit"]), Convert.ToInt32(reader["Credit2"]), Convert.ToInt32(reader["ClanId"]),
                        new UserDetails(reader["Email"].ToString(), reader["Address"].ToString(),
                        new City("Tirana")), Convert.ToInt32(reader["Points"]), Convert.ToInt32(reader["tpreds"]),
                        Convert.ToInt32(reader["spreds"]), Convert.ToInt32(reader["lastspreds"]),
                        Convert.ToInt32(reader["lastsspreds"]), Convert.ToInt32(reader["AvatarId"]),
                        Convert.ToInt32(reader["Rank"]), reader["NameOfClan"].ToString(), new Guid(reader["SessionId"].ToString()),
                        Convert.ToDateTime(reader["Birthday"]), Convert.ToBoolean(Convert.ToInt16(reader["isFirstLogin"]))
                        ,Convert.ToInt16(reader["yesterdaypoints"]), Convert.ToInt16(reader["detailpoints"]), Convert.ToInt16(reader["todaypoints"]));
                        user.DeviceType = reader["DeviceType"].ToString();
                        user.PushId = reader["PushId"].ToString();
                    }

                    var json = new JavaScriptSerializer().Serialize(user);

                    HttpContext.Current.Session["currentUser"] = user;
                    Session["currentUser"] = user;

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write(json);
                    HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                    HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                    HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
                }
            }
        }

        private void CookieCheck()
        {
            var userguid = Request.Params["userguid"] != null ? new Guid(Request.Params["userguid"]) : new Guid();
            
            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("[UserGetById]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = userguid;

                    var user = new Objects.User();
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new Objects.User(reader["UserName"].ToString(), new Guid(reader["GUID"].ToString()),
                            Convert.ToInt32(reader["Credit"]), Convert.ToInt32(reader["Credit2"]), Convert.ToInt32(reader["ClanId"]),
                        new UserDetails(reader["Email"].ToString(), reader["Address"].ToString(),
                        new City("Tirana")), Convert.ToInt32(reader["Points"]), Convert.ToInt32(reader["tpreds"]),
                        Convert.ToInt32(reader["spreds"]), Convert.ToInt32(reader["lastspreds"]),
                        Convert.ToInt32(reader["lastsspreds"]), Convert.ToInt32(reader["AvatarId"]),
                        Convert.ToInt32(reader["Rank"]), reader["NameOfClan"].ToString(), new Guid(reader["SessionId"].ToString()),
                        Convert.ToDateTime(reader["Birthday"]), Convert.ToBoolean(Convert.ToInt16(reader["isFirstLogin"]))
                        , Convert.ToInt16(reader["yesterdaypoints"]), Convert.ToInt16(reader["detailpoints"]), Convert.ToInt16(reader["todaypoints"]));
                    }

                    var json = new JavaScriptSerializer().Serialize(user);

                    HttpContext.Current.Session["currentUser"] = user;
                    Session["currentUser"] = user;

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write(json);
                    HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                    HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                    HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
                }
            }

        }
    }
}