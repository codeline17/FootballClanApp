using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Stat;
using NHibernate.Util;
using Smaug.Bases;
using Smaug.Models;
using Smaug.Utils;

namespace Smaug.Data_Access
{
    public static class DataLayer
    {
        private static string cString = System.Configuration.ConfigurationManager.ConnectionStrings["cString"].ConnectionString;

        public static void SaveOrUpdate(this extended_fixtures ef)
        {
            if (ef.league != null)
            {
                foreach (var league in ef.league)
                {
                    league.Country = ef.country;
                    //SaveLeague
                    league.SaveOrUpdate();

                    if (league.week != null)
                    {
                        if (league.week.Length > 0)
                        {
                            foreach (var weeks in league.week.Where(w => w.match != null))
                            {
                                foreach (var f in weeks.match)
                                {
                                    f.SaveOrUpdate(league);
                                }
                            }
                        }
                    }

                    if (league.stage != null)
                    {
                        if (league.stage.Length > 0)
                        {
                            foreach (var stage in league.stage)
                            {
                                if (stage.match != null)
                                {
                                    foreach (var f in stage.match)
                                    {
                                        f.SaveOrUpdate(league);
                                    }
                                }

                                if (stage.week != null)
                                {
                                    foreach (var w in stage.week)
                                    {
                                        if (w.match != null)
                                        {
                                            foreach (var m in w.match)
                                            {
                                                m.SaveOrUpdate(league);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        
        private static void SaveOrUpdate(this extended_fixturesLeagueStageMatch fixture, extended_fixturesLeague league)
        {
            fixture.home.Country = league.Country;
            fixture.home.SaveOrUpdate();
            fixture.away.Country = league.Country;
            fixture.away.SaveOrUpdate();
            var dtString = fixture.date + " " + fixture.time;
            var dt = DateTime.ParseExact(dtString.Replace(".", "/"), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            using (var conn = new SqlConnection(cString))
            {
                using (var command = new SqlCommand("FeedFixtureInsert", conn))
                {
                    conn.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@league_id", int.Parse(league.id.ToString())));
                    command.Parameters.Add(new SqlParameter("@home_id", int.Parse(fixture.home.id.ToString())));
                    command.Parameters.Add(new SqlParameter("@away_id", int.Parse(fixture.away.id.ToString())));
                    command.Parameters.Add(new SqlParameter("@startdate", dt));
                    command.Parameters.Add(new SqlParameter("@status", fixture.status));
                    command.Parameters.Add(new SqlParameter("@feed_id", int.Parse(fixture.id.ToString())));
                    command.Parameters.Add(new SqlParameter("@feed_no", "2"));
                    command.Parameters.Add(new SqlParameter("@static_id", fixture.static_id));
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void SaveOrUpdate(this extended_fixturesLeagueWeekMatch fixture, extended_fixturesLeague league)
        {
            fixture.home.Country = league.Country;
            fixture.home.SaveOrUpdate();
            fixture.away.Country = league.Country;
            fixture.away.SaveOrUpdate();
            var dtString = fixture.date + " " + fixture.time;
            DateTime dt;
            if (!DateTime.TryParseExact(dtString.Replace(".", "/"), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                DateTime.TryParseExact(fixture.date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);

            using (var conn = new SqlConnection(cString))
            {
                using (var command = new SqlCommand("FeedFixtureInsert", conn))
                {
                    conn.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@league_id", int.Parse(league.sub_id.ToString())));
                    command.Parameters.Add(new SqlParameter("@home_id", int.Parse(fixture.home.id.ToString())));
                    command.Parameters.Add(new SqlParameter("@away_id", int.Parse(fixture.away.id.ToString())));
                    command.Parameters.Add(new SqlParameter("@startdate", dt));
                    command.Parameters.Add(new SqlParameter("@status", fixture.status));
                    command.Parameters.Add(new SqlParameter("@feed_id", int.Parse(fixture.id.ToString())));
                    command.Parameters.Add(new SqlParameter("@feed_no", "2"));
                    command.Parameters.Add(new SqlParameter("@static_id", fixture.static_id));
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void SaveOrUpdate(this extended_fixturesLeagueStageWeekMatch fixture, extended_fixturesLeague league)
        {
            fixture.home.Country = league.Country;
            fixture.home.SaveOrUpdate();
            fixture.away.Country = league.Country;
            fixture.away.SaveOrUpdate();
            var dtString = fixture.date + " " + fixture.time;
            DateTime dt;
            if (!DateTime.TryParseExact(dtString.Replace(".", "/"), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                DateTime.TryParseExact(fixture.date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);

            using (var conn = new SqlConnection(cString))
            {
                using (var command = new SqlCommand("FeedFixtureInsert", conn))
                {
                    conn.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@league_id", int.Parse(league.sub_id.ToString())));
                    command.Parameters.Add(new SqlParameter("@home_id", int.Parse(fixture.home.id.ToString())));
                    command.Parameters.Add(new SqlParameter("@away_id", int.Parse(fixture.away.id.ToString())));
                    command.Parameters.Add(new SqlParameter("@startdate", dt));
                    command.Parameters.Add(new SqlParameter("@status", fixture.status));
                    command.Parameters.Add(new SqlParameter("@feed_id", int.Parse(fixture.id.ToString())));
                    command.Parameters.Add(new SqlParameter("@feed_no", "2"));
                    command.Parameters.Add(new SqlParameter("@static_id", fixture.static_id));
                    command.ExecuteNonQuery();
                }
            }
        }
                
        private static void SaveOrUpdate(this extended_fixturesLeague league)
        {
            using (var conn = new SqlConnection(cString))
            {
                using (var command = new SqlCommand("FeedLeagueInsert",conn))
                {
                    conn.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", int.Parse(league.sub_id.ToString())));
                    command.Parameters.Add(new SqlParameter("@Name", league.name));
                    command.Parameters.Add(new SqlParameter("@Country", league.Country));
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void SaveOrUpdate(this extended_fixturesLeagueStageMatchAway team)
        {
            using (var conn = new SqlConnection(cString))
            {
                using (var command = new SqlCommand("FeedTeamInsert", conn))
                {
                    conn.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", int.Parse(team.id.ToString())));
                    command.Parameters.Add(new SqlParameter("@Name", team.name));
                    command.Parameters.Add(new SqlParameter("@Country", team.Country));
                    command.Parameters.Add(new SqlParameter("@Stadium", "NoStadium"));
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void SaveOrUpdate(this extended_fixturesLeagueStageMatchHome team)
        {
            using (var conn = new SqlConnection(cString))
            {
                using (var command = new SqlCommand("FeedTeamInsert", conn))
                {
                    conn.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", int.Parse(team.id.ToString())));
                    command.Parameters.Add(new SqlParameter("@Name", team.name));
                    command.Parameters.Add(new SqlParameter("@Country", team.Country));
                    command.Parameters.Add(new SqlParameter("@Stadium", "NoStadium"));
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void SaveOrUpdate(this extended_fixturesLeagueWeekMatchAway team)
        {
            using (var conn = new SqlConnection(cString))
            {
                using (var command = new SqlCommand("FeedTeamInsert", conn))
                {
                    conn.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", int.Parse(team.id.ToString())));
                    command.Parameters.Add(new SqlParameter("@Name", team.name));
                    command.Parameters.Add(new SqlParameter("@Country", team.Country));
                    command.Parameters.Add(new SqlParameter("@Stadium", "NoStadium"));
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void SaveOrUpdate(this extended_fixturesLeagueWeekMatchHome team)
        {
            using (var conn = new SqlConnection(cString))
            {
                using (var command = new SqlCommand("FeedTeamInsert", conn))
                {
                    conn.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", int.Parse(team.id.ToString())));
                    command.Parameters.Add(new SqlParameter("@Name", team.name));
                    command.Parameters.Add(new SqlParameter("@Country", team.Country));
                    command.Parameters.Add(new SqlParameter("@Stadium", "NoStadium"));
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void SaveOrUpdate(this extended_fixturesLeagueStageWeekMatchAway team)
        {
            using (var conn = new SqlConnection(cString))
            {
                using (var command = new SqlCommand("FeedTeamInsert", conn))
                {
                    conn.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", int.Parse(team.id.ToString())));
                    command.Parameters.Add(new SqlParameter("@Name", team.name));
                    command.Parameters.Add(new SqlParameter("@Country", team.Country));
                    command.Parameters.Add(new SqlParameter("@Stadium", "NoStadium"));
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void SaveOrUpdate(this extended_fixturesLeagueStageWeekMatchHome team)
        {
            using (var conn = new SqlConnection(cString))
            {
                using (var command = new SqlCommand("FeedTeamInsert", conn))
                {
                    conn.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", int.Parse(team.id.ToString())));
                    command.Parameters.Add(new SqlParameter("@Name", team.name));
                    command.Parameters.Add(new SqlParameter("@Country", team.Country));
                    command.Parameters.Add(new SqlParameter("@Stadium", "NoStadium"));
                    command.ExecuteNonQuery();
                }
            }
        }


        //Highlights
        public static void SaveOrUpdate(this highlights h)
        {
            if (h != null)
                foreach (var l in h.league)
                {
                    foreach (var m in l.match)
                    {
                        m.SaveOrUpdate();
                    }
                }
        }

        private static void SaveOrUpdate(this highlightsLeagueMatch m)
        {
            using (var conn = new SqlConnection(cString))
            {
                using (var command = new SqlCommand("FixtureUpdateOnLiveScore", conn))
                {
                    conn.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@HomeGoals", int.Parse(m.home.goals.ToString())));
                    command.Parameters.Add(new SqlParameter("@AwayGoals", int.Parse(m.away.goals.ToString())));
                    command.Parameters.Add(new SqlParameter("@Status", m.status));
                    command.Parameters.Add(new SqlParameter("@static_id", m.static_id));
                    command.ExecuteNonQuery();
                }
            }
        }

        
    }
}
