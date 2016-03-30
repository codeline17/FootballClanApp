﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
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
                    case "UNL": // Unlocks ************************************* UserGetUnlocks
                        UserUnlocks(user.Guid);
                        break;
                    case "GU": //Get User *************************************
                        GetUserDetials();
                        break;
                    case "RFR": //Refresh UserDetails
                        RefreshUserDetials(user.Guid);
                        break;
                    case "CHT": //Refresh UserChats
                        GetUserChats(user.Guid);
                        break;
                    case "SND": //Refresh UserChats
                        SendMessage(user.Guid);
                        break;
                    case "TGF": //Toggle Favorite
                        ToggleFavorite(user.Guid);
                        break;
                    case "UUD": //Update User Details
                        UpdateUserDetails();
                        break;//////////////Leaderboard
                    case "GAU": //Get All Users
                        GetAllUsers();
                        break;
                    case "GFA": //Get Favorites
                        GetFavorites();
                        break;
                    case "GAT": //Get All Trophies
                        // TODO : Trophies??
                        //UpdateUserDetails();
                        break;/////////////End Leaderboard
                    case "LO": //Logout
                        Logout();
                        break;
                    case "PO": //Purchase Options
                        PurchaseGame(user.Guid);
                        break;
                    case "PEF": //Purchase Extra Fixture
                        PurchaseExtraFixtures(user.Guid);
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
                    case "GACBU": //Get All Clans By User
                        GetAllClansByUser(user.Guid);
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

        private void GetUserChats(Guid guid)
        {
            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("ChatroomsGetByUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Userguid", SqlDbType.UniqueIdentifier).Value = guid;

                    var r = new List<Chatroom>();

                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var chatroom = new Chatroom(Convert.ToInt16(reader["Id"]), reader["Name"].ToString());
                        chatroom.Messages = GetMessagesByChatroom(chatroom.Id);
                        r.Add(chatroom);
                    }

                    user.Chatrooms = r;

                    var json = new JavaScriptSerializer().Serialize(user);

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write(json);
                }
            }
        }

        private List<Chatmessage> GetMessagesByChatroom(int ChatroomId)
        {
            var r = new List<Chatmessage>();

            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("MessageGetByChatroom", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ChatroomId", SqlDbType.BigInt).Value = ChatroomId;

                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        r.Add(new Chatmessage(reader["Message"].ToString(), reader["From"].ToString(),
                            Convert.ToDateTime(reader["Timestamp"]), Convert.ToBoolean(reader["Disposable"])));
                    };
                }
            }

            return r;
        }

        private void SendMessage(Guid guid)
        {
            var ChatroomId = Convert.ToInt16(Request.Params["chatroomid"]);
            var Message = Request.Params["message"];
            var ExpiresOn = DateTime.Now;

            var r = 0;
            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("MessageSendByUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Userguid", SqlDbType.UniqueIdentifier).Value = guid;
                    cmd.Parameters.Add("@ChatroomId", SqlDbType.Int).Value = ChatroomId;
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar).Value = Message;
                    cmd.Parameters.Add("@ExpiresOn", SqlDbType.DateTime).Value = ExpiresOn;
                    conn.Open();
                    r = Convert.ToInt16(cmd.ExecuteScalar());                              
                }
            }
            var json = new JavaScriptSerializer().Serialize(r);

            Response.ClearContent();
            Response.ClearHeaders();
            Response.Write(json);
        }

        private void UserUnlocks(Guid guid)
        {
            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("UserGetUnlocks", conn))
                {
                    var r = new List<Unlockables>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Userguid", SqlDbType.UniqueIdentifier).Value = guid;

                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        r.Add(new Unlockables(reader["Name"].ToString(),Convert.ToDateTime(reader["ExpiresOn"])));
                    }

                    var json = new JavaScriptSerializer().Serialize(r);

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write(json);
                }
            }
        }
        private void PurchaseExtraFixtures(Guid guid)
        {
            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("PurchaseExtraFixtures", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserGuid", SqlDbType.UniqueIdentifier).Value = user.Guid;

                    conn.Open();
                    var r = cmd.ExecuteScalar();

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write(r);
                }
            }
        }
        private void PurchaseGame(Guid guid)
        {
            var slug = Request.Params["Slug"];

            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("PurchaseGame", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserGuid", SqlDbType.UniqueIdentifier).Value = user.Guid;
                    cmd.Parameters.Add("@GameSlug", SqlDbType.VarChar, 20).Value = slug;

                    conn.Open();
                    var r = cmd.ExecuteScalar();

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write(r);
                }
            }
        }
        private void ToggleFavorite(Guid guid)
        {
            var name = Request.Params["FavUname"];

            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("UserFavoriteToggle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserGuid", SqlDbType.UniqueIdentifier).Value = user.Guid;
                    cmd.Parameters.Add("@FavoriteUsername", SqlDbType.VarChar, 20).Value = name;

                    conn.Open();
                    var r = cmd.ExecuteScalar();

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write(r);
                }
            }
        }
        private void GetFavorites()
        {
            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("UserGetFavoritesById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userGuid", SqlDbType.UniqueIdentifier).Value = user.Guid;

                    var r = new List<Objects.User>();
                    conn.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        r.Add(
                                new Objects.User(
                                    reader["UserName"].ToString(),
                                    (Guid)reader["GUID"],
                                    0,
                                    0,
                                    new UserDetails("", "", new City("")),
                                    Convert.ToInt32(reader["Points"]),
                                    Convert.ToInt32(reader["tpreds"]),
                                    Convert.ToInt32(reader["spreds"]), Convert.ToInt32(reader["lastspreds"]),
                                    Convert.ToInt32(reader["lastsspreds"]), Convert.ToInt32(reader["AvatarId"]),
                                    Convert.ToInt32(reader["Rank"]),
                                    reader["NameOfClan"].ToString(),
                                    new Guid(),
                                    DateTime.Now,
                                    false
                                )
                            );
                    }
                    var json = new JavaScriptSerializer().Serialize(r);
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write(json);
                }
            }
        }
        private void GetAllUsers()
        {
            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("UserGetAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    var r = new List<Objects.User>();
                    conn.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        r.Add(
                                new Objects.User(
                                    reader["UserName"].ToString(),
                                    (Guid)reader["GUID"],
                                    0,
                                    0,
                                    new UserDetails("","",new City("")),
                                    Convert.ToInt32(reader["Points"]),
                                    Convert.ToInt32(reader["tpreds"]),
                                    Convert.ToInt32(reader["spreds"]), Convert.ToInt32(reader["lastspreds"]),
                                    Convert.ToInt32(reader["lastsspreds"]), Convert.ToInt32(reader["AvatarId"]),
                                    Convert.ToInt32(reader["Rank"]),
                                    reader["NameOfClan"].ToString(),
                                    new Guid(),
                                    DateTime.Now,
                                    false
                                )
                            );
                    }
                    var json = new JavaScriptSerializer().Serialize(r);
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write(json);
                }
            }
        }
        private void UpdateUserDetails()
        {
            var pwd = Request.Params["pwd"];
            var pwdr = Request.Params["pwdr"];
            var avid = Request.Params["avid"];
            var adress = Request.Params["adress"];
            var birthday = DateTime.Now;
            DateTime.TryParseExact(Request.Params["birthday"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthday);

            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("UserUpdateDetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userGuid", SqlDbType.UniqueIdentifier).Value = user.Guid;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = pwd == pwdr && pwd != null && pwdr != null ? pwd : "";
                    cmd.Parameters.Add("@AvatarId", SqlDbType.Int).Value = Convert.ToInt32(avid);
                    cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = adress;
                    cmd.Parameters.Add("@Birthday", SqlDbType.DateTime).Value = birthday;

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
                                new Objects.User(reader["PartName"].ToString(),Convert.ToInt32(reader["Points"]), Convert.ToInt32(reader["PRank"]))
                                );
                        }
                        else
                        {
                            league.Clans.Add(
                                new Clan(
                                    reader["PartName"].ToString(), 
                                    Convert.ToInt32(reader["Points"]), 
                                    Convert.ToInt32(reader["PRank"]),
                                    Convert.ToInt32(reader["Image"])
                                    )
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
        public void RefreshUserDetials(Guid guid)
        {

            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("UserGetById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = guid;

                    var gUser = new Objects.User();
                    
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        gUser = new Objects.User(reader["UserName"].ToString(), new Guid(reader["GUID"].ToString()),
                            Convert.ToInt32(reader["Credit"]), Convert.ToInt32(reader["ClanId"]),
                        new UserDetails(reader["Email"].ToString(), reader["Address"].ToString(),
                        new City("Tirana")), Convert.ToInt32(reader["Points"]), Convert.ToInt32(reader["tpreds"]),
                        Convert.ToInt32(reader["spreds"]), Convert.ToInt32(reader["lastspreds"]),
                        Convert.ToInt32(reader["lastsspreds"]), Convert.ToInt32(reader["AvatarId"]), Convert.ToInt32(reader["Rank"]),
                        reader["NameOfClan"].ToString(), new Guid(), Convert.ToDateTime(reader["Birthday"]), Convert.ToBoolean(Convert.ToInt32(reader["isFirstLogin"])));
                    }
                    
                    user = gUser;
                    GetUserChats(user.Guid);

                    HttpContext.Current.Session["currentUser"] = user;
                    Session["currentUser"] = user;

                    var json = new JavaScriptSerializer().Serialize(gUser);
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
        private void GetAllClansByUser(Guid userGuid)
        {
            var clans = new List<Objects.Clan>();

            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("ClanGetAllByUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserGuid", SqlDbType.UniqueIdentifier).Value = userGuid;

                    conn.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        clans.Add(
                            new Clan(
                                reader["Name"].ToString(),
                                Convert.ToInt32(reader["Count"]),
                                reader["Leader"].ToString(),
                                Convert.ToInt32(reader["Rank"]),
                                Convert.ToInt32(reader["Points"]),
                                Convert.ToInt32(reader["Image"])
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
                                reader["Leader"].ToString(),
                                Convert.ToInt32(reader["Rank"]),
                                Convert.ToInt32(reader["Points"]),
                                Convert.ToInt32(reader["Image"])
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
                                {
                                    TotalPredictions = Convert.ToInt32(reader["tpreds"]),
                                    SuccessfulPredictions = Convert.ToInt32(reader["spreds"]),
                                    LastPredictions = Convert.ToInt32(reader["lastspreds"]),
                                    LastSuccessfulPredictions = Convert.ToInt32(reader["lastsspreds"]),
                                    Rank = Convert.ToInt32(reader["UserRank"])
                                }
                            );
                        }

                        if (reader["TrophyId"].ToString() != "0" && clan.Trophies.Count(x => x.Id == Convert.ToInt16(reader["TrophyId"].ToString())) == 0)
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
                        clan.Rank = Convert.ToInt32(reader["Rank"]);
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