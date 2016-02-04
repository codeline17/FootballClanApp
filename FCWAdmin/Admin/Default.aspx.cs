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
        private readonly SqlDataSource _dsMatches = new SqlDataSource();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            BindGrid(DateTime.Now);
        }        

        protected void txtCalendar_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            var dtStr = Request.Form[txtCalendar.UniqueID];
            var dt = DateTime.Now;
            dt = DateTime.Parse(dtStr);
            BindGrid(dt);
        }

        private void BindGrid(DateTime? date)
        {
            if (date == null)
                   return;

            
            _dsMatches.ID = "dsMatches";
            Page.Controls.Add(_dsMatches);
            _dsMatches.ConnectionString = ConfigurationManager.ConnectionStrings["AdminConnectionString"].ConnectionString;
            _dsMatches.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            _dsMatches.SelectCommand = "MatchGetByDate";
            if (_dsMatches.SelectParameters.Count == 0)
            {
                _dsMatches.SelectParameters.Add("startDate", TypeCode.DateTime, ((DateTime)date).ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                _dsMatches.SelectParameters["startDate"].DefaultValue = ((DateTime)date).ToString("yyyy-MM-dd HH:mm:ss");
            }
            
            gdView.DataSource = _dsMatches;
            gdView.DataBind();

        }

        protected void gdView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            var ddlCities = (DropDownList) e.Row.FindControl("ddlPacks");
            var query = "select * from FixturePacks";
            var cmd = new SqlCommand(query);
            ddlCities.DataSource = GetData(cmd);
            ddlCities.DataTextField = "Name";
            ddlCities.DataValueField = "Id";
            if (ddlCities.Items.Count != 0) return;
            ddlCities.DataBind();
            var label = e.Row.FindControl("lblPack") as Label;
            if (label != null)
                ddlCities.Items.FindByText(label.Text).Selected = true;
        }

        private DataTable GetData(SqlCommand cmd)
        {
            var strConnString = ConfigurationManager.ConnectionStrings["AdminConnectionString"].ConnectionString;
            using (var con = new SqlConnection(strConnString))
            {
                using (var sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (var dt = new DataTable())
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
            /*var dtStr = Request.Form[txtCalendar.UniqueID];
            var dt = DateTime.Now;
            dt = DateTime.Parse(dtStr);
            BindGrid(dt);*/
        }

        protected void gdView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {                
                var row = gdView.Rows[e.RowIndex];
                var ddlPacks = (DropDownList)row.FindControl("ddlPacks");
                var hfId = (HiddenField)row.FindControl("hdId");
                var fixtureId = hfId.Value;

                _dsMatches.ConnectionString = ConfigurationManager.ConnectionStrings["AdminConnectionString"].ConnectionString;
                _dsMatches.UpdateCommandType = SqlDataSourceCommandType.StoredProcedure;
                _dsMatches.UpdateCommand = "FixturePackUpdate";
                if (_dsMatches.UpdateParameters.Count == 0)
                {
                    _dsMatches.UpdateParameters.Add("fixtureId", DbType.Int32, fixtureId);
                    _dsMatches.UpdateParameters.Add("packId", DbType.Int32, ddlPacks.SelectedValue);
                    _dsMatches.Update();
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
            gdView.EditIndex = -1;
            btnFilter_Click(null, EventArgs.Empty);
        }

        protected void gdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdView.PageIndex = e.NewPageIndex;
        }
    }
}