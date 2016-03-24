using System;
using System.Diagnostics;
using Objects;

namespace FCW
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var user = (User)Session["currentUser"];
                if (user.Username == null)
                {
                    Response.Redirect("Login.aspx");                    
                }
                var el = Request.Params["success"];
                Debug.Write(el);

            }
            catch (Exception)
            {
                Response.Redirect("Login.aspx");
            }
        }

        private void Initialize()
        {
            try
            {
                var Userguid = new Guid(Request.Cookies["cuserguid"].Value);
                if (Userguid != null)
                {

                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}