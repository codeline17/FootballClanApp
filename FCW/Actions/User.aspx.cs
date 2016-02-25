﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
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
                    case "GU": //Get User *************************************
                        GetUserDetials();
                        break;
                    case "RFR": //Refresh UserDetails
                        RefreshUserDetials(user.Guid);
                        break;
                    case "GAU": //Get All Users

                        break;
                    case "UUD": //Update User Details
                        UpdateUserDetails();
                        break;
                    case "LO": //Logout
                        Logout();
                        break;
                    case "CDL": //Clan Details**********************************
                        GetClanDetails();
                        break;
                    case "CL": //Create Clan
                        CreateClan();
                        break;
                    case "GAC": //Get All Clans
                        GetAllClans();
                        break;
                    case "JC": //Join Clan
                        JoinClan();
                        break;
                    case "AUC": //Approve user
                        ApproveUserClan(user.Guid);
                        break;
                    case "RMUC": //Remove user
                        RemoveUserClan(user.Guid);
                        break;
                    case "LDL": //League Details**********************************
                        GetLeagueList(user);
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

        private void UpdateUserDetails()
        {
            var pwd = Request.Params["pwd"];
            var pwdr = Request.Params["pwdr"];
            var avid = Request.Params["avid"];

            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("UserUpdateDetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userGuid", SqlDbType.UniqueIdentifier).Value = user.Guid;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = pwd == pwdr && pwd != null && pwdr != null ? pwd : "";
                    cmd.Parameters.Add("@AvatarId", SqlDbType.Int).Value = Convert.ToInt32(avid);

                    conn.Open();
                    var r = cmd.ExecuteScalar().ToString();

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write(r);
                }
            }
        }

        private void Logout()
        {
            Session["currentUser"] = null;
            
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Write("Out Motherfucker!");

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
                        else
                        {
                            league.Clans.Add(
                                new Clan(reader["PartName"].ToString(), Convert.ToInt32(reader["Points"]))
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
        private void RefreshUserDetials(Guid guid)
        {

            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("UserGetById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = guid;

                    var user = new Objects.User();
                    
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new Objects.User(reader["UserName"].ToString(), new Guid(reader["GUID"].ToString()),
                            Convert.ToInt32(reader["Credit"]), Convert.ToInt32(reader["ClanId"]),
                        new UserDetails(reader["Email"].ToString(), reader["Address"].ToString(),
                        new City("Tirana")), Convert.ToInt32(reader["Points"]), Convert.ToInt32(reader["tpreds"]),
                        Convert.ToInt32(reader["spreds"]), Convert.ToInt32(reader["lastspreds"]),
                        Convert.ToInt32(reader["lastsspreds"]), Convert.ToInt32(reader["AvatarId"]));
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
        private void CreateClan()
        {
            var name = Request.Params["name"];
            var prv = Request.Params["private"];
            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("ClanCreate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userGuid", SqlDbType.UniqueIdentifier).Value = user.Guid;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 20).Value = name;
                    cmd.Parameters.Add("@Private", SqlDbType.Bit).Value = Convert.ToBoolean(prv);

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
                        if (clan.Users.Count(x => x.Username == reader["UserName"].ToString()) == 0)
                        {
                            clan.Users.Add(
                                new Objects.User(
                                    reader["UserName"].ToString(),
                                    Convert.ToDateTime(reader["MemberSince"].ToString()).ToString("dd/MM/yyyy"),
                                    Convert.ToBoolean(reader["Approved"]),
                                    Convert.ToInt16(reader["Points"].ToString())
                                    )
                            );
                        }

                        if (clan.Trophies.Count(x => x.Id == Convert.ToInt16(reader["TrophyId"].ToString())) == 0)
                        {
                            clan.Trophies.Add(
                                new Objects.Trophy(
                                    Convert.ToInt16(reader["TrophyCount"].ToString()), 
                                    reader["TrophyName"].ToString(),
                                    reader["TrophyColor"].ToString()
                                    )
                                );
                        }
                        
                        clan.Leader = reader["isLeader"].ToString() != "0" ? reader["UserName"].ToString() : clan.Leader;
                        clan.isPrivate = Convert.ToBoolean(reader["Private"]);
                    }
                }
            }
            var json = new JavaScriptSerializer().Serialize(clan);
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Write(json);
        }

        private void ApproveUserClan(Guid guid)
        {
            var name = Request.Params["name"];
            var clanName = Request.Params["clanName"];

            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("ClanApprovePlayer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SenderGuid", SqlDbType.UniqueIdentifier).Value = user.Guid;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20).Value = name;
                    cmd.Parameters.Add("@ClanName", SqlDbType.VarChar, 20).Value = clanName;

                    conn.Open();
                    cmd.ExecuteScalar();

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write("1");
                }
            }
        }

        private void RemoveUserClan(Guid guid)
        {
            var name = Request.Params["name"];
            var clanName = Request.Params["clanName"];

            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("ClanRemovePlayer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SenderGuid", SqlDbType.UniqueIdentifier).Value = user.Guid;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20).Value = name;
                    cmd.Parameters.Add("@ClanName", SqlDbType.VarChar, 20).Value = clanName;

                    conn.Open();
                    cmd.ExecuteScalar();

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write("1");
                }
            }
        }
    }
}