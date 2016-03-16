using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FCW.Actions
{
    public partial class Paypal : System.Web.UI.Page
    {
        private readonly string _connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["FCWConn"].ConnectionString;
        private string trn_id, payment_status;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var user = new Objects.User();
                user = (Objects.User)Session["currentUser"];
                if (user.Username == null)
                    return;

                var requestType = Request.Params["type"];

                switch (requestType)
                {
                    case "PUI": //Insert Purchase
                        InsertPurchase(user.Guid);
                        break;
                    case "CNP": //Confirm Purchase
                        
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