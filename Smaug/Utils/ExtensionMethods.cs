using System;
using Smaug.Interfaces;
using Smaug.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Linq;
using System.Linq;

namespace Smaug.Utils
{
    public static class ExtensionMethods
    {
        private static readonly string CString = System.Configuration.ConfigurationManager.ConnectionStrings["CString"].ConnectionString;
        public static void SaveOrUpdate(this IList<ITeam> teams)
        {
            foreach (var team in teams)
            {
                using (var conn = new SqlConnection(CString))
                {
                    using (var command = new SqlCommand("FeedTeamInsert", conn))
                    {
                        conn.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@id", team.GetType().GetProperty("Id").GetValue(team,null)));
                        command.Parameters.Add(new SqlParameter("@name", team.GetType().GetProperty("Name").GetValue(team, null)));
                        command.Parameters.Add(new SqlParameter("@Country", team.GetType().GetProperty("Country").GetValue(team, null)));
                        command.Parameters.Add(new SqlParameter("@Stadium", "NoStadium"));
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine($"Error in FeedTeamInsert");
                            Debug.WriteLine($"Error : {e.Message}");
                            Debug.WriteLine($"Stack : {e.StackTrace}");
                        }
                    }
                }
            }
        }
        public static void SaveOrUpdate(this IList<League> leagues)
        {
            foreach (var league in leagues)
            {
                using (var conn = new SqlConnection(CString))
                {
                    using (var command = new SqlCommand("FeedLeagueInsert", conn))
                    {
                        conn.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Id", league.GetType().GetProperty("Sub_id").GetValue(league, null)));
                        command.Parameters.Add(new SqlParameter("@name", league.GetType().GetProperty("Name").GetValue(league, null)));
                        command.Parameters.Add(new SqlParameter("@Country", league.GetType().GetProperty("Country").GetValue(league, null)));
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine($"Error in FeedLeagueInsert");
                            Debug.WriteLine($"Error : {e.Message}");
                            Debug.WriteLine($"Stack : {e.StackTrace}");
                        }
                    }
                }
            }
        }
        public static void SaveOrUpdate(this IList<Match> matches)
        {
            foreach (var match in matches)
            {
                var dtString = match.Date + " " + match.Time;
                DateTime dt;
                if (!DateTime.TryParseExact(dtString.Replace(".", "/"), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    DateTime.TryParseExact(match.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);

                using (var conn = new SqlConnection(CString))
                {
                    using (var command = new SqlCommand("FeedFixtureInsert", conn))
                    {
                        conn.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        //command.Parameters.Add(new SqlParameter("@Id", league.GetType().GetProperty("Sub_id").GetValue(league, null)));
                        command.Parameters.Add(new SqlParameter("@league_id", match.GetType().GetProperty("LeagueId").GetValue(match, null)));
                        command.Parameters.Add(new SqlParameter("@home_id", match.GetType().GetProperty("HomeId").GetValue(match, null)));
                        command.Parameters.Add(new SqlParameter("@away_id", match.GetType().GetProperty("AwayId").GetValue(match, null)));
                        command.Parameters.Add(new SqlParameter("@startdate", dt));
                        command.Parameters.Add(new SqlParameter("@status", match.GetType().GetProperty("Status").GetValue(match, null)));
                        command.Parameters.Add(new SqlParameter("@feed_id", match.GetType().GetProperty("Id").GetValue(match, null)));
                        command.Parameters.Add(new SqlParameter("@feed_no", "2"));
                        command.Parameters.Add(new SqlParameter("@static_id", match.GetType().GetProperty("Static_id").GetValue(match, null)));
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine($"Error in FeedFixtureInsert");
                            Debug.WriteLine($"Error : {e.Message}");
                            Debug.WriteLine($"Stack : {e.StackTrace}");
                        }
                    }
                }
            }
        }
        public static void Update(this IList<Match> matches)
        {
            foreach (var match in matches.Where(m => m.Date == DateTime.Now.ToString("dd.MM.yyyy")))
            {
                var dtString = match.Date + " " + match.Time;
                DateTime dt;
                if (!DateTime.TryParseExact(dtString.Replace(".", "/"), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    DateTime.TryParseExact(match.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
                using (var conn = new SqlConnection(CString))
                {
                    using (var command = new SqlCommand("FixtureUpdateOnLiveScore", conn))
                    {
                        conn.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@FixtureId", match.GetType().GetProperty("Id").GetValue(match, null)));
                        command.Parameters.Add(new SqlParameter("@HomeGoals", match.GetType().GetProperty("HomeGoals").GetValue(match, null)));
                        command.Parameters.Add(new SqlParameter("@AwayGoals", match.GetType().GetProperty("AwayGoals").GetValue(match, null)));
                        command.Parameters.Add(new SqlParameter("@Status", match.Status));
                        command.Parameters.Add(new SqlParameter("@Static_Id", match.GetType().GetProperty("Static_id").GetValue(match, null)));
                        try
                        {
                            var c = command.ExecuteNonQuery();
                            if (c > 0)
                            {
                                Debug.WriteLine($"Match updated");
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine($"Error in FixtureUpdateOnLiveScore");
                            Debug.WriteLine($"Error : {e.Message}");
                            Debug.WriteLine($"Stack : {e.StackTrace}");
                        }
                    }
                }
            }
        }
        public static XElement FindParent(this XElement e, string name)
        {
            XElement r = null;

            if (e == null)
                return r;
            
            if (e.Parent != null && e.Parent.Name == name)
            {
                r = e.Parent;
            }
            else
            {
                r = e.Parent.FindParent(name);
            }

            return r;
        }
    }
}
