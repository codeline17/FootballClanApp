﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web.Script.Serialization;
using Objects;


namespace FCW.Actions
{
    public partial class Fixture : System.Web.UI.Page
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

                var requestType = Request.Params["type"];

                switch (requestType)
                {
                    case "SNDPD": //InsertPredictions
                        InsertPredictions(_user);
                        break;
                    case "PREDS": //GetPredictions
                        GetPredictions(_user);
                        break;
                    case "GUN": //GetUserName
                        GetUserName(_user);
                        break;
                    case "GLS": //GetLiveScore
                        GetLiveScore(_user);
                        break;
                }
            }
            catch (Exception ex)
            {
                //Nope
            }

            Response.End();
        }

        #region Utils
        protected void ReturnError()
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Write("Error");
            Response.End();
        }
        protected bool SecurityCheck()
        {
            var r = false;
            var _userguid = Request.Params["userGuid"] != null ? new Guid(Request.Params["userGuid"]) : new Guid();

            try
            {
                _user = Session["currentUser"] != null ? (Objects.User)Session["currentUser"] : UserGetByGuid(_userguid);
                r = _user.Guid != null || (_key.Length == Request.Params[""].Length && _key == Request.Params[""]);
            }
            catch (Exception)
            {
                r = false;
            }

            return r;
        }
        private Objects.User UserGetByGuid(Guid guid)
        {
            var gUser = new Objects.User();
            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("UserGetById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = guid;

                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        gUser = new Objects.User(reader["UserName"].ToString(), new Guid(reader["GUID"].ToString()),
                            Convert.ToInt32(reader["Credit"]), Convert.ToInt32(reader["Credit2"]), Convert.ToInt32(reader["ClanId"]),
                        new UserDetails(reader["Email"].ToString(), reader["Address"].ToString(),
                        new City("Tirana")), Convert.ToInt32(reader["Points"]), Convert.ToInt32(reader["tpreds"]),
                        Convert.ToInt32(reader["spreds"]), Convert.ToInt32(reader["lastspreds"]),
                        Convert.ToInt32(reader["lastsspreds"]), Convert.ToInt32(reader["AvatarId"]), Convert.ToInt32(reader["Rank"]),
                        reader["NameOfClan"].ToString(), new Guid(), Convert.ToDateTime(reader["Birthday"]), Convert.ToBoolean(Convert.ToInt32(reader["isFirstLogin"])));
                    }
                }
            }
            return gUser;
        }
        #endregion

        private void GetLiveScore(Objects.User user)
        {
            var date = DateTime.Now;
            DateTime.TryParseExact(Request.Params["date"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("FixturesGetLiveScore", conn))
                {
                    var fixtures = new List<Objects.Fixture>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@data", SqlDbType.DateTime).Value = date;
                    cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = user.Guid;
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        fixtures.Add(new Objects.Fixture(
                                    new Team(reader["HomeTeam"].ToString()),
                                    new Team(reader["AwayTeam"].ToString()),
                                    new Competition(reader["LeagueName"].ToString(),
                                    reader["Country"].ToString()),
                                    Convert.ToDateTime(reader["StartDate"]),
                                    Convert.ToInt16(reader["HomeGoals"]),
                                    Convert.ToInt16(reader["AwayGoals"]),
                                    Convert.ToInt16(reader["HomeYellow"]),
                                    Convert.ToInt16(reader["AwayYellow"]),
                                    Convert.ToInt16(reader["HomeRed"]),
                                    Convert.ToInt16(reader["AwayRed"]),
                                    reader["Status"].ToString()
                                    ));
                    }
                    var json = new JavaScriptSerializer().Serialize(fixtures);
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write(json);
                }
            }
        }
        private void InsertPredictions(Objects.User user)
        {
            var r = "Success";
            try
            {
                var pds = Request.Params["pds"].Split(';');

                foreach (var pd in pds)
                {
                    try
                    {
                        InsertPrediction(user, pd);
                    }
                    catch (Exception ex)
                    {
                        r = "Partial Exeption";
                    }
                }
            }
            catch (Exception)
            {
                r = "Exeption";
            }


            var json = new JavaScriptSerializer().Serialize(r);
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Write(json);
        }
        private void InsertPrediction(Objects.User user, string prediction)
        {
            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("PredictionInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FixtureId", SqlDbType.BigInt).Value = prediction.Split('|')[0];
                    cmd.Parameters.Add("@GameSlug", SqlDbType.VarChar,10).Value = prediction.Split('|')[1];
                    cmd.Parameters.Add("@OutcomeName", SqlDbType.VarChar, 10).Value = prediction.Split('|')[2];
                    cmd.Parameters.Add("@userGuid", SqlDbType.UniqueIdentifier).Value = user.Guid;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void GetPredictions(Objects.User user)
        {
            var date = DateTime.Now;
            DateTime.TryParseExact(Request.Params["date"], "dd/MM/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None, out date);

            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("PredictionsGetByUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userGuid", SqlDbType.UniqueIdentifier).Value = user.Guid;
                    cmd.Parameters.Add("@data", SqlDbType.DateTime).Value = date;

                    var fixtures = new List<Objects.Fixture>();
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var fixture = fixtures.FirstOrDefault(x => x.ID == Convert.ToInt32(reader["Id"]));
                        if (fixture == null)
                        {
                            fixtures.Add(new Objects.Fixture(
                                    Convert.ToInt32(reader["id"]),
                                    new Team(reader["HomeTeam"].ToString()),
                                    new Team(reader["AwayTeam"].ToString()),
                                    new List<Event>(), reader["Status"].ToString(),
                                    new Competition(reader["LeagueName"].ToString(),
                                    reader["Country"].ToString()),
                                    new List<Game>
                                    {
                                        new Game(reader["GameName"].ToString(),reader["Slug"].ToString(),new List<Outcome>
                                        {
                                            new Outcome(
                                                reader["OutcomeName"].ToString(),
                                                Convert.ToBoolean(reader["IsSelected"]),
                                                reader["Repeater"].ToString()
                                                ,Convert.ToBoolean(reader["isWon"]))
                                        }
                                        ,reader["Repeater"].ToString()
                                        ,Convert.ToInt16(reader["Value"])
                                        ,Convert.ToInt16(reader["Price"])
                                        ,Convert.ToBoolean(reader["GAuthorized"])
                                        ,Convert.ToBoolean(reader["Evaluated"]))
                                    }
                                    ,Convert.ToDateTime(reader["StartDate"]),
                                    Convert.ToBoolean(reader["GameSealed"]),
                                    reader["FixturePack"].ToString(),
                                    Convert.ToInt32(reader["HomeGoals"]),
                                    Convert.ToInt32(reader["AwayGoals"]),
                                    Convert.ToBoolean(reader["FAuthorized"]),
                                    reader["StatusSlug"].ToString()));
                        }
                        else
                        {
                            var game = fixture.Games.FirstOrDefault(x => x.Slug == reader["Slug"].ToString());

                            if (game == null)
                            {
                                fixture.Games.Add(new Game(reader["GameName"].ToString(), reader["Slug"].ToString(), new List<Outcome>
                               {
                                   new Outcome(
                                       reader["OutcomeName"].ToString(),
                                       Convert.ToBoolean(reader["IsSelected"]),
                                       reader["Repeater"].ToString(),
                                       Convert.ToBoolean(reader["isWon"]))
                               }
                               ,reader["Repeater"].ToString()
                               ,Convert.ToInt16(reader["Value"])
                               ,Convert.ToInt16(reader["Price"])
                               ,Convert.ToBoolean(reader["GAuthorized"])
                               ,Convert.ToBoolean(reader["Evaluated"])));
                            }
                            else
                            {
                                var outcome =
                                    game.Outcomes.FirstOrDefault(x => x.Name == reader["OutcomeName"].ToString());
                                if (outcome == null)
                                {
                                    game.AddOutcome(new Outcome(
                                        reader["OutcomeName"].ToString(), 
                                        Convert.ToBoolean(reader["IsSelected"]), 
                                        reader["Repeater"].ToString(),
                                       Convert.ToBoolean(reader["isWon"])));
                                }
                            }
                        }
                    }
                    var json = new JavaScriptSerializer().Serialize(fixtures);
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write(json);

                }
            }
        }
        private void GetUserName(Objects.User user)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Write(string.Format("{0}|{1}",user.Username, user.Credit));
        }
    }
}