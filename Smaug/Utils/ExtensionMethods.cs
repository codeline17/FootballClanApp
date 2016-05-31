using Smaug.Interfaces;
using Smaug.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Xml.Linq;

namespace Smaug.Utils
{
    public static class ExtensionMethods
    {
        private static string cString = System.Configuration.ConfigurationManager.ConnectionStrings["cString"].ConnectionString;

        public static void SaveOrUpdate(this IList<ITeam> teams)
        {
            foreach (var team in teams)
            {
                using (var conn = new SqlConnection(cString))
                {
                    using (var command = new SqlCommand("FeedTeamInsert", conn))
                    {
                        conn.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@id", team.GetType().GetProperty("Id").GetValue(team,null)));
                        command.Parameters.Add(new SqlParameter("@Name", team.GetType().GetProperty("Name").GetValue(team, null)));
                        command.Parameters.Add(new SqlParameter("@Country", team.GetType().GetProperty("Country").GetValue(team, null)));
                        command.Parameters.Add(new SqlParameter("@Stadium", "NoStadium"));
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void SaveOrUpdate(this IList<League> leagues)
        {
            foreach (var league in leagues)
            {
                using (var conn = new SqlConnection(cString))
                {
                    using (var command = new SqlCommand("FeedLeagueInsert", conn))
                    {
                        conn.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Id", league.GetType().GetProperty("Sub_id").GetValue(league, null)));
                        command.Parameters.Add(new SqlParameter("@Name", league.GetType().GetProperty("Name").GetValue(league, null)));
                        command.Parameters.Add(new SqlParameter("@Country", league.GetType().GetProperty("Country").GetValue(league, null)));
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static XElement FindParent(this XElement e, string Name)
        {
            XElement r = null;

            if (e == null)
                return r;
            
            if (e.Parent != null && e.Parent.Name == Name)
            {
                r = e.Parent;
            }
            else
            {
                r = e.Parent.FindParent(Name);
            }

            return r;
        }
    }
}
