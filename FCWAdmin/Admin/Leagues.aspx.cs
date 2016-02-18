using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FCWAdmin.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                calStartDate.StartDate = DateTime.Now;
                txtStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                var dt = DateTime.Now;
                DateTime.TryParseExact(txtStartDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
                calStartDate.SelectedDate = dt;
                txtEndDate.Text = "";
                SetEndDateStartFrom();
            }
        }

        private void SetEndDateStartFrom()
        {
            var sdt = DateTime.Now;
            DateTime.TryParse(calStartDate.SelectedDate.ToString(), out sdt);
            calEndDate.StartDate = sdt.AddDays(2);
        }

        protected void btnDummy_Click(object sender, EventArgs e)
        {
            SetEndDateStartFrom();
        }
    }
}