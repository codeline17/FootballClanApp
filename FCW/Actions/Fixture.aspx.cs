using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web.Script.Serialization;
using Objects;


namespace FCW.Actions
{
    public partial class Fixture : System.Web.UI.Page
    {
        private readonly string _connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["FCWConn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var user = new Objects.User();
                user = (Objects.User) Session["currentUser"];
                if (user.Username == null)
                    return;

                var requestType = Request.Params["type"];

                switch (requestType)
                {
                    case "UDM": //UserDailyMatches
                        UserDailyMatches(user);
                        break;
                    case "SNDPD":
                        InsertPredictions(user);
                        break;
                    default :
                        break;
                }
            }
            catch (Exception)
            {
                //None
            }

        }

        private void UserDailyMatches(Objects.User user)
        {
            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("FixturesGetByUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userGuid", SqlDbType.UniqueIdentifier).Value = user.Guid;

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
                                            new Outcome(reader["OutcomeName"].ToString())
                                        })
                                    }
                                    ,Convert.ToDateTime(reader["StartDate"])));
                        }
                        else
                        {
                            var game = fixture.Games.FirstOrDefault(x => x.Slug == reader["Slug"].ToString());

                            if (game == null)
                            {
                               fixture.Games.Add(new Game(reader["GameName"].ToString(),reader["Slug"].ToString(),new List<Outcome>
                               {
                                   new Outcome(reader["OutcomeName"].ToString())
                               }));
                            }
                            else
                            {
                                var outcome =
                                    game.Outcomes.FirstOrDefault(x => x.Name == reader["OutcomeName"].ToString());
                                if (outcome == null)
                                {
                                    game.Outcomes.Add(new Outcome(reader["OutcomeName"].ToString()));
                                }
                            }
                        }
                    }
                    var json = new JavaScriptSerializer().Serialize(fixtures);
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write(json);
                    Response.End();
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

            Response.ClearContent();
            Response.ClearHeaders();
            Response.Write(r);
            Response.End();

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
    }
}