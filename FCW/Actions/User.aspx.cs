using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Objects;

namespace FCW.Actions
{
    public partial class User : System.Web.UI.Page
    {
        private Objects.User user = new Objects.User();

        private readonly string _connectionstring =
            System.Configuration.ConfigurationManager.ConnectionStrings["FCWConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                user = (Objects.User) Session["currentUser"];
                if (user.Username == null)
                    return;

                var requestType = Request.Params["type"];

                switch (requestType)
                {
                    case "GU": //Get User
                        GetUserDetials();
                        break;
                    case "CDL": //Clan Details
                        GetClanDetails();
                        break;
                    case "LDL": //League Details

                        break;
                    case "CL": //Create Clan
                        CreateClan();
                        break;
                    case "GAC": //Get All Clans
                        GetAllClans();
                        break;
                    case "GAU": //Get All Users

                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                //None
            }

            Response.End();

        }

        private void GetUserDetials()
        {
            var json = new JavaScriptSerializer().Serialize(user);
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Write(json);
        }

        private void CreateClan()
        {
            var name = Request.Params["name"];
            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("ClanCreate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userGuid", SqlDbType.UniqueIdentifier).Value = user.Guid;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 20).Value = name;

                    conn.Open();
                    var r = Convert.ToInt32(cmd.ExecuteScalar());

                    user.ClanId = r;
                    Session["currentUser"] = user;
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write(r);
                }
            }
        }

        private void GetAllClans()
        {
            var clans = new List<Objects.Clan>();

            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("ClanGetAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        clans.Add(
                            new Clan(
                                reader["Name"].ToString(), 
                                Convert.ToInt32(reader["Count"]),
                                reader["Leader"].ToString()
                                )
                            );
                    }

                    var json = new JavaScriptSerializer().Serialize(clans);
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write(json);
                }
            }
        }

        private void GetClanDetails()
        {
            
        }
    }
}