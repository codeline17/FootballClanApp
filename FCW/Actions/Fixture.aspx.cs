using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                    cmd.Parameters.Add("@userGuid", SqlDbType.VarChar, 36).Value = user.Guid;

                    var fixtures = new List<Objects.Fixture>();
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var fixture = fixtures.FirstOrDefault(x => x.ID == Convert.ToInt32(reader["Id"]));
                        if (fixture == null)
                        {
                            fixture = new Objects.Fixture(
                                    Convert.ToInt32(reader["id"]),
                                    new Team(reader["HomeTeam"].ToString()), 
                                    new Team(reader["AwayTeam"].ToString()),
                                    new List<Event>(), reader["Status"].ToString(),
                                    new Competition(reader["LeagueName"].ToString(),
                                    reader["Country"].ToString()), 
                                    new List<Game>());   
                        }
                        else
                        {
                            fixture.Games.Add(new Game(reader["GameName"].ToString(),reader));
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
    }
}