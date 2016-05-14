using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace PaymentCallback
{
    public partial class F38B0516C3 : System.Web.UI.Page
    {
        private readonly string _connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["FCWConn"].ConnectionString;
        private readonly string _mode = System.Configuration.ConfigurationManager.AppSettings["_mode"];
        const string StrSandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";
        const string StrLive = "https://www.paypal.com/cgi-bin/webscr";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var reqEp = "http://www.google.com";
                //Post back to either sandbox or live
                switch (_mode)
                {
                    case "live":
                        reqEp = StrLive;
                        break;
                    case "test":
                        reqEp = StrSandbox;
                        break;
                }
                var req = (HttpWebRequest)WebRequest.Create(reqEp);

                //Set values for the request back
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                var param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
                var strRequest = Encoding.ASCII.GetString(param);
                strRequest = strRequest + "&cmd=_notify-validate";
                req.ContentLength = strRequest.Length;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                //for proxy
                //Dim proxy As New WebProxy(New System.Uri("http://url:port#"))
                //req.Proxy = proxy

                //Send the request to PayPal and get the response
                var streamOut = new StreamWriter(req.GetRequestStream(), Encoding.ASCII);
                streamOut.Write(strRequest);
                streamOut.Close();
                var streamIn = new StreamReader(req.GetResponse().GetResponseStream());
                var strResponse = streamIn.ReadToEnd();
                streamIn.Close();

                switch (strResponse)
                {
                    case "VERIFIED":
                        var paymentstatus = Request["payment_status"];
                        if (paymentstatus == "Completed")
                        {
                            CreateTransaction(Request);
                            ConfirmPurchase(
                                new Guid(Request["custom"].Split('|')[0]),
                                new Guid(Request["custom"].Split('|')[1]),
                                Convert.ToDecimal(Request["mc_gross"]));
                        }
                        //check the payment_status is Completed request["custom"] + ";" + request["mc_gross"];
                        //check that txn_id has not been previously processed
                        //check that receiver_email is your Primary PayPal email
                        //check that payment_amount/payment_currency are correct
                        //process payment
                        break;
                    case "INVALID":
                        //log for manual investigation
                        break;
                    //Response wasn't VERIFIED or INVALID, log for manual investigation
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void CreateTransaction(HttpRequest request)
        {
            using (var conn = new SqlConnection(_connectionstring))
            {
                using (var cmd = new SqlCommand("PaymentInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@value", SqlDbType.VarChar, 150).Value = request["custom"] + ";" + request["mc_gross"];
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void ConfirmPurchase(Guid userGuid, Guid purchaseGuid, decimal price)
        {
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