using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web.Script.Serialization;
using Objects;

namespace FCW.Actions
{
    public partial class Flick : System.Web.UI.Page
    {
        private Objects.User _user = new Objects.User();
        private readonly string _key =
            ConfigurationManager.AppSettings["safetykey"];
        private readonly string _connectionstring = ConfigurationManager.ConnectionStrings["FCWConn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!SecurityCheck())
                    ReturnError();

                var requestType = Request.Params["type"];

                switch (requestType)
                {
                    case "FGOAL": //InsertPredictions
                        FlickGoal(_user);
                        break;
                    case "FSHOOT": //GetPredictions
                        FlickShoot(_user);
                        break;
                    case "FRMN": //GetUserName
                        FlicksRemaining(_user);
                        break;
                }
            }
            catch (Exception)
            {
                ReturnError();
            }

            Response.End();
        }

        private void FlicksRemaining(Objects.User user)
        {
            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("FlicksGetByUserId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userGuid", SqlDbType.UniqueIdentifier).Value = user.Guid;
                    conn.Open();
                    var r = cmd.ExecuteScalar();

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write(r);
                }
            }
        }

        private void FlickShoot(Objects.User user)
        {
            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("FlickShootOne", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userGuid", SqlDbType.UniqueIdentifier).Value = user.Guid;
                    conn.Open();
                    var r = cmd.ExecuteScalar();
                    
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write("ok");
                }
            }
        }

        private void FlickGoal(Objects.User user)
        {
            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("FlickGoal", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userGuid", SqlDbType.UniqueIdentifier).Value = user.Guid;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
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
            var userguid = Request.Params["userGuid"] != null ? new Guid(Request.Params["userGuid"]) : Guid.Empty;

            try
            {
                if (Session["currentUser"] != null)
                {
                    _user = (Objects.User)Session["currentUser"];
                    r = true;
                }
                else if (_key.Length == Request.Params["safetykey"].Length && _key == Request.Params["safetykey"])
                {
                    _user = UserGetByGuid(userguid);
                    r = true;
                }
                else
                {
                    r = false;
                }
            }
            catch (Exception)
            {
                r = false;
            }

            return r;
        }

        private static Objects.User UserGetByGuid(Guid guid)
        {
            var gUser = new Objects.User { Guid = guid };
            return gUser;
        }
    }
}