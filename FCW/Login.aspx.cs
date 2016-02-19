using System;
using Objects;

namespace FCW
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var user = (User)Session["currentUser"];
                if (user.Username != null)
                {
                    Response.Redirect("Default.aspx");
                }

            }
            catch (Exception)
            {
                
            }
        }
    }
}