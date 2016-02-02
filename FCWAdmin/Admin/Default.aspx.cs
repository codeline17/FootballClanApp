using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FCWAdmin.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        private SqlDataSource dsMatches = new SqlDataSource();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (dtNdeshjet.SelectedDate == null)
                {
                    dtNdeshjet.SelectedDate = DateTime.Now.Date;
                }
                BindGrid(dtNdeshjet.SelectedDate);
            }       
                 
        }        

        protected void txtCalendar_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            var dtStr = Request.Form[txtCalendar.UniqueID];
            DateTime dt = DateTime.Now;
            DateTime.TryParseExact(dtStr, "dd/MM/yyyy",CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);

            DateTime time;
            var matchingCulture = CultureInfo.GetCultures(CultureTypes.AllCultures).FirstOrDefault(ci => DateTime.TryParse(dtStr, ci, DateTimeStyles.None, out time));
            //DateTime.TryParseExact(dtStr, matchingCulture, DateTimeStyles.None, out dt);
            BindGrid(Convert.ToDateTime(dtStr));
        }

        private void BindGrid(DateTime? date)
        {
            if (date == null)
                   return;

            
            dsMatches.ID = "dsMatches";
            Page.Controls.Add(dsMatches);
            dsMatches.ConnectionString = ConfigurationManager.ConnectionStrings["AdminConnectionString"].ConnectionString;
            dsMatches.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            dsMatches.SelectCommand = "MatchGetByDate";
            if (dsMatches.SelectParameters.Count == 0)
            {
                dsMatches.SelectParameters.Add("startDate", TypeCode.DateTime, ((DateTime)date).ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                dsMatches.SelectParameters["startDate"].DefaultValue = ((DateTime)date).ToString("yyyy-MM-dd HH:mm:ss");
            }
            
            gdView.DataSource = dsMatches;
            gdView.DataBind();

        }

        protected void gdView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gdView.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlCities = (DropDownList)e.Row.FindControl("ddlPacks");
                string query = "select * from FixturePacks";
                SqlCommand cmd = new SqlCommand(query);
                ddlCities.DataSource = GetData(cmd);
                ddlCities.DataTextField = "Name";
                ddlCities.DataValueField = "Id";
                if (ddlCities.Items.Count == 0)
                {
                    ddlCities.DataBind();
                    ddlCities.Items.FindByText((e.Row.FindControl("lblPack") as Label).Text).Selected = true;
                }                
            }
        }

        private DataTable GetData(SqlCommand cmd)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["AdminConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        

        protected void gdView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gdView.EditIndex = e.NewEditIndex;
            var dtStr = Request.Form[txtCalendar.UniqueID];
            DateTime dt = DateTime.Now;
            DateTime.TryParseExact(dtStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
            BindGrid(Convert.ToDateTime(dtStr));
        }

        protected void gdView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {                
                GridViewRow row = gdView.Rows[e.RowIndex];
                DropDownList ddlPacks = (DropDownList)row.FindControl("ddlPacks");
                HiddenField hfId = (HiddenField)row.FindControl("hdId");
                var fixtureId = hfId.Value;

                dsMatches.ConnectionString = ConfigurationManager.ConnectionStrings["AdminConnectionString"].ConnectionString;
                dsMatches.UpdateCommandType = SqlDataSourceCommandType.StoredProcedure;
                dsMatches.UpdateCommand = "FixturePackUpdate";
                if (dsMatches.UpdateParameters.Count == 0)
                {
                    dsMatches.UpdateParameters.Add("fixtureId", DbType.Int32, fixtureId);
                    dsMatches.UpdateParameters.Add("packId", DbType.Int32, ddlPacks.SelectedValue);
                    dsMatches.Update();
                }
                BindGrid(dtNdeshjet.SelectedDate);

            }
            catch (Exception)
            {

                throw;
            }

            

        }

        protected void gdView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}