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
                        GetLeagueList(user);
                        break;
                    case "CL": //Create Clan
                        CreateClan();
                        break;
                    case "GAC": //Get All Clans
                        GetAllClans();
                        break;
                    case "GAU": //Get All Users

                        break;
                    case "JC": //Join Clan
                        JoinClan();
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

        private void GetLeagueList(Objects.User user)
        {
            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("LeaguesGetByUserId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add ("@UserGuid", SqlDbType.UniqueIdentifier).Value = user.Guid;

                    var r = new List<Objects.League>();
                    conn.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        r.Add(GetLeagueDetails(Convert.ToInt32(reader["Id"])));
                    }

                    var json = new JavaScriptSerializer().Serialize(r);
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write(json);
                }
            }
        }

        private Objects.League GetLeagueDetails(int id)
        {
            var league = new Objects.League();

            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("[LeagueGetById]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LeagueId", SqlDbType.BigInt).Value = id;
                    
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    /*l.Name,l.StartDate,l.EndDate,	u.Id as 'PartId',u.UserName as 'PartName',points
                    */

                    while (reader.Read())
                    {
                        league.Name = reader["Name"].ToString();
                        league.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        league.EndDate = Convert.ToDateTime(reader["EndDate"]);
                        if (reader["LeagueTypeId"].ToString() == "1")
                        {
                            league.Users.Add(
                                new Objects.User(reader["PartName"].ToString(),Convert.ToInt32(reader["Points"]))
                                );
                        }

                    }
                }
            }

            return league;
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

        private void JoinClan()
        {
            var name = Request.Params["name"];
            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("ClanAddUser", conn))
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
            var id = Convert.ToInt64(Request.Params["Id"]);
            var clan = new Objects.Clan();

            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("ClanGetById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                    conn.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        clan.Name = reader["ClanName"].ToString();
                        clan.Users.Add(
                                new Objects.User(
                                    reader["UserName"].ToString(), 
                                    Convert.ToDateTime(reader["MemberSince"].ToString()).ToString("dd/MM/yyyy")
                                    )
                            );
                        clan.Leader = reader["isLeader"].ToString() != "0" ? reader["UserName"].ToString() : clan.Leader;
                    }
                }
            }
            var json = new JavaScriptSerializer().Serialize(clan);
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Write(json);
        }
    }
}