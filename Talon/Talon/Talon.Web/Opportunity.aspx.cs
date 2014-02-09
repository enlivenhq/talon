using System;
using Talon.Web.Presenters;
using Talon.Web.Views;

namespace Talon.Web
{
    using System.Web;
    using System.Web.UI.WebControls;
    using Helpers;

    public partial class Opportunity : System.Web.UI.Page, IOpportunityView
    {
        #region Public Properties

        public Data.Models.TopOpportunity CurrentOpportunity { get; set; }

        public string OpportunityId
        {
            get { return Request["opportunity"]; }
        }

        public int FormattedCalculatedProbabilityOfClose
        {
            get { return CurrentOpportunity.FormattedCalculatedProbabilityOfClose; }
        }

        public string OpportunityName
        {
            get { return CurrentOpportunity.OpportunityName; }
        }

        #endregion

        #region Protected Properties

        protected OpportunityPresenter Presenter;

        #endregion

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AccountHelper.LoggedIn) HttpContext.Current.Response.Redirect("Login.aspx");
            Presenter = new OpportunityPresenter(this);
            Presenter.Initialize();
        }

        #endregion
    }
}