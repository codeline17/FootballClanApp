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

namespace Smaug.Data_Access
{
    public static class DataLayer
    {
        private static string cString = System.Configuration.ConfigurationManager.ConnectionStrings["cString"].ConnectionString;

        public static void SaveOrUpdate(this extended_fixtures ef)
        {
            foreach (var league in ef.league)
            {
                //SaveLeague
                league.SaveOrUpdate();

                if (league.week == null) continue;
                {
                    if (league.week.Length <= 0) continue;
                    foreach (var m in from w in league.week where w.match.Length > 0 from m in w.match select m)
                    {
                        m.SaveOrUpdate(league);
                    }
                }

                if (league.stage == null) continue;
                {
                    if (league.stage.Length <= 0) continue;
                    foreach (var m in from s in league.stage where s.match.Length > 0 from m in s.match select m)
                    {
                        m.SaveOrUpdate(league);
                    }
                }
            }
        }
        
        private static void SaveOrUpdate(this extended_fixturesLeagueStageMatch fixture, extended_fixturesLeague league)
        {
            fixture.home.SaveOrUpdate();
            fixture.away.SaveOrUpdate();
            var dtString = fixture.date + " " + fixture.time;
            var dt = DateTime.ParseExact(dtString.Replace(".", "/"), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

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
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void SaveOrUpdate(this extended_fixturesLeagueWeekMatch fixture, extended_fixturesLeague league)
        {
            fixture.home.SaveOrUpdate();
            fixture.away.SaveOrUpdate();
            var dtString = fixture.date + " " + fixture.time;
            var dt = DateTime.ParseExact(dtString.Replace(".", "/"), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

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
                    command.Parameters.Add(new SqlParameter("@Country", "TestFeed2"));
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
                    command.Parameters.Add(new SqlParameter("@Country", "TestFeed2"));
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
                    command.Parameters.Add(new SqlParameter("@Country", "TestFeed2"));
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
                    command.Parameters.Add(new SqlParameter("@Country", "TestFeed2"));
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
                    command.Parameters.Add(new SqlParameter("@Country", "TestFeed2"));
                    command.Parameters.Add(new SqlParameter("@Stadium", "NoStadium"));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
