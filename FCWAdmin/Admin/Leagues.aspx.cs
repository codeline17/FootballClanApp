using System;
using System.Collections.Generic;
using System.Data;
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
                SetEndDateStartFrom();
            }
            else
            {
                var dt = DateTime.Now;
                DateTime.TryParseExact(txtStartDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
                calStartDate.SelectedDate = dt;
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

        protected void btnCreateClan_Click(object sender, EventArgs e)
        {
            DateTime startDate;
            DateTime endDate;
            var hasStartDate = DateTime.TryParseExact(txtStartDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
            var hasEndDate = DateTime.TryParseExact(txtEndDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);

            if (!hasStartDate || !hasEndDate || txtLeagueName.Text == "") return;
            dsLeaguesAll.InsertParameters["Name"].DefaultValue = txtLeagueName.Text;
            dsLeaguesAll.InsertParameters["type"].DefaultValue = rbLeagueType.SelectedValue;
            dsLeaguesAll.InsertParameters["StartDate"].DefaultValue = startDate.ToString("yyyy-MM-dd HH:mm:ss");
            dsLeaguesAll.InsertParameters["EndDate"].DefaultValue = endDate.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                dsLeaguesAll.Insert();
                ddlLeagues.DataBind();
            }
            catch (Exception ex)
            {
                
            }
            
        }

        protected void ddlLeagues_SelectedIndexChanged(object sender, EventArgs e)
        {
            gdLeagueDetails.DataBind();
        }
    }
}