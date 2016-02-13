using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI.WebControls;

namespace FCWAdmin.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        private readonly SqlDataSource _dsMatches = new SqlDataSource();
        private int NormalMatches = 0;
        private int ExtraMatches = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dtNdeshjet.SelectedDate = DateTime.Now;
                txtCalendar.Text = DateTime.Now.ToString("dd/MM/yyyy");
                BindGrid();
            }
            else
            {
                DateTime dt = DateTime.Now;
                DateTime.TryParseExact(txtCalendar.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
                dtNdeshjet.SelectedDate = dt;
            } 
        }        

        protected void txtCalendar_TextChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            NormalMatches = 0;
            ExtraMatches = 0;
            var dtStr = Request.Form[txtCalendar.UniqueID] ?? txtCalendar.Text;
            var dt = DateTime.Now;
            if (!DateTime.TryParseExact(dtStr,"dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                dt = DateTime.Now;
            BindGrid(dt);
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            BindGrid();
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
            var label = e.Row.FindControl("lblPack") as Label;
            switch (label?.Text)
            {
                case "Normal":
                    NormalMatches++;
                    break;
                case "Extra":
                    ExtraMatches++;
                    break;
            }
            lblState.Text = string.Format("[{0} - Normal]    [{1} - Extra]",NormalMatches,ExtraMatches);
            if (e.Row.RowType == DataControlRowType.DataRow && gdView.EditIndex == e.Row.RowIndex)                
            {               
                var ddlCities = (DropDownList)e.Row.FindControl("ddlPacks");
                const string query = "select * from FixturePacks";
                var cmd = new SqlCommand(query);
                ddlCities.DataSource = GetData(cmd);
                ddlCities.DataTextField = "Name";
                ddlCities.DataValueField = "Id";
                if (ddlCities.Items.Count != 0) return;
                ddlCities.DataBind();
                if (label != null)
                    ddlCities.Items.FindByText(label.Text).Selected = true;               
            }
        }

        private static DataTable GetData(SqlCommand cmd)
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
            BindGrid();
        }

        protected void gdView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            gdView.EditIndex = -1;
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
            }
            catch (Exception)
            {

                throw;
            }
            gdView.EditIndex = -1;
            btnFilter_Click(null, EventArgs.Empty);
        }

        protected void gdView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gdView.EditIndex = -1;
            btnFilter_Click(null, EventArgs.Empty);
        }

        protected void gdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdView.PageIndex = e.NewPageIndex;
            btnFilter_Click(null, EventArgs.Empty);
        }
    }
}