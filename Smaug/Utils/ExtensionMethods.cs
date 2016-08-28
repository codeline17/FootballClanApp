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
                            var c = command.ExecuteNonQuery();
                            if (c > 0)
                            {
                                frmMain.ConsoleWrite($"U shtua nje ekip");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error in FeedTeamInsert");
                            Console.WriteLine($"Error : {e.Message}");
                            Console.WriteLine($"Stack : {e.StackTrace}");
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
                            Console.WriteLine($"Error in FeedLeagueInsert");
                            Console.WriteLine($"Error : {e.Message}");
                            Console.WriteLine($"Stack : {e.StackTrace}");
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
                            var c = command.ExecuteNonQuery();
                            if (c > 0)
                            {
                                frmMain.ConsoleWrite($"{DateTime.Now.ToString("dd/MM/yyyy hh:mm")} : Shtova {match.HomeTeam.Name} - {match.AwayTeam.Name}");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error in FeedFixtureInsert");
                            Console.WriteLine($"Error : {e.Message}");
                            Console.WriteLine($"Stack : {e.StackTrace}");
                        }
                    }
                }
            }
        }

        public static void UpdateEvents(this Match match)
        {
            foreach (var e in match.Events)
            {
                using (var conn = new SqlConnection(CString))
                {
                    using (var command = new SqlCommand("EventUpdateOnLiveScore", conn))
                    {
                        conn.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (match.Static_id == "24081623421402348626")
                        {
                            
                        }
                        command.Parameters.Add(new SqlParameter("@Id", e.Id));
                        command.Parameters.Add(new SqlParameter("@Static_Id", match.Static_id));
                        command.Parameters.Add(new SqlParameter("@Minute", e.Minute));
                        command.Parameters.Add(new SqlParameter("@Type", e.Type));
                        command.Parameters.Add(new SqlParameter("@Team", e.Team));
                        command.Parameters.Add(new SqlParameter("@PlayerId", e.Player.Id));
                        command.Parameters.Add(new SqlParameter("@PlayerName", e.Player.Name.Replace("(pen.)","").Replace("(o.g.)","").Trim()));
                        try
                        {
                            var c = command.ExecuteNonQuery();
                           if (c > 0)
                            {
                                Console.WriteLine($"Event updated");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error in EventUpdateOnLiveScore");
                            Console.WriteLine($"Error : {ex.Message}");
                            Console.WriteLine($"Stack : {ex.StackTrace}");
                        }
                    }
                }
            }
        }
        public static void Update(this IList<Match> matches)
        {
            //foreach (var match in matches.Where(m => m.Date == DateTime.Now.ToString("dd.MM.yyyy")))
            foreach (var match in matches)
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
                            match.UpdateEvents();
                            if (c > 0)
                            {
                                Console.WriteLine($"Match updated");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error in FixtureUpdateOnLiveScore");
                            Console.WriteLine($"Error : {e.Message}");
                            Console.WriteLine($"Stack : {e.StackTrace}");
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

        public static int ToInt(this string number, int defaultInt)
        {
            var resultNum = defaultInt;
            try
            {
                if (!string.IsNullOrEmpty(number))
                    resultNum = Convert.ToInt32(number);
            }
            catch
            {
                //Nuthin
            }
            return resultNum;
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey> (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var seenKeys = new HashSet<TKey>();
            return source.Where(element => seenKeys.Add(keySelector(element)));
        }
    }
}
