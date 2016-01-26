using System;
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

            }
            catch (Exception)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}