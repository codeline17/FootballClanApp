using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Objects;

namespace FCW.Actions
{
    public partial class Paypal : System.Web.UI.Page
    {
        private Objects.User _user = new Objects.User();
        private readonly string _connectionstring = ConfigurationManager.ConnectionStrings["FCWConn"].ConnectionString;
        private readonly string _key =
            ConfigurationManager.AppSettings["safetykey"];

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!SecurityCheck())
                    ReturnError();

                var requestType = Request.Params["type"];

                switch (requestType)
                {
                    case "PUI": //Insert Purchase
                        InsertPurchase(_user.Guid);
                        break;
                    case "CNP": //Confirm Purchase
                        ConfirmPurchase(_user.Guid);
                        break;
                }
            }
            catch (Exception)
            {
                //None
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
            bool r;
            var userguid = Request.Params["userGuid"] != null ? new Guid(Request.Params["userGuid"]) : new Guid();

            try
            {
                _user = Session["currentUser"] != null ? (Objects.User)Session["currentUser"] : UserGetByGuid(userguid);
                r = _user.Guid != null || (_key.Length == Request.Params["safetykey"].Length && _key == Request.Params["safetykey"]);
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
                        Convert.ToInt32(reader["lastsspreds"]), Convert.ToInt32(reader["AvatarId"]),
                        Convert.ToInt32(reader["Rank"]), reader["NameOfClan"].ToString(), new Guid(reader["SessionId"].ToString()),
                        Convert.ToDateTime(reader["Birthday"]), Convert.ToBoolean(Convert.ToInt16(reader["isFirstLogin"]))
                        , Convert.ToInt16(reader["yesterdaypoints"]), Convert.ToInt16(reader["detailpoints"]), Convert.ToInt16(reader["todaypoints"]));
                    }
                }
            }
            return gUser;
        } 
        #endregion

        private void InsertPurchase(Guid userGuid)
        {
            var itemName = Request.Params["ItemName"];

            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("PurchaseInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserGuid", SqlDbType.UniqueIdentifier).Value = userGuid;
                    cmd.Parameters.Add("@PurchaseName", SqlDbType.VarChar, 10).Value = itemName;
                    conn.Open();
                    var r = (Guid) cmd.ExecuteScalar();
                    
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Write(userGuid + "|" + r);   
                }
            }
        }
        private void ConfirmPurchase(Guid userGuid)
        {
            var purchaseGuid = new Guid(Request.Params["PurchaseGuid"]);
            var price = Convert.ToDecimal(Request.Params["Price"]);

            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("PurchaseConfirm", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserGuid", SqlDbType.UniqueIdentifier).Value = userGuid;
                    cmd.Parameters.Add("@PurchaseId", SqlDbType.UniqueIdentifier).Value = purchaseGuid;
                    cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = price;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}