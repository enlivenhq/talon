using System;
using System.Web.UI;
using Talon.Web.Presenters;
using Talon.Web.Views;

namespace Talon.Web
{
    using System.Linq;
    using Data.Components;
    using Data.Repositories;
    using Helpers;

    // ReSharper disable once InconsistentNaming
    public partial class _Default : Page, IDefaultView
    {
        public int TotalOpportunites { get; set; }
        public string EstimatedRevenue { get; set; }

        protected DefaultPresenter Presenter { get; set; }

        protected async void Page_Load(object sender, EventArgs e)
        {
            Presenter = new DefaultPresenter(this);
            Presenter.Initialize();

            if (!AccountHelper.LoggedIn) return;

            var component = new OpportunityComponent(AccountHelper.Client);
            var probabilityStatisticsComponent = new ProbabilityStatisticsComponent(new ProbabilityStatisticsRepository());
            var data = await component.GetOpportunities();
            var opportunites = data.ToList();
            TotalOpportunites = opportunites.Count;

            var listOfTopOpportunities = opportunites.ConvertAll(probabilityStatisticsComponent.GetTopOpportunity);
            var categorizedTopCategories =
                probabilityStatisticsComponent.CategorizeTopOpportunities(listOfTopOpportunities);

            EstimatedRevenue = probabilityStatisticsComponent.CalculateEstimatedRevenue(listOfTopOpportunities);

            var timeComponent = new TimeStatisticsComponent(new TimeStatisticsRepository());

            listOfTopOpportunities.ForEach(x => timeComponent.AddCalculatedCloseDate(x));

            HotOpportunites.DataSource = categorizedTopCategories.HotOpportunites.OrderByDescending(opportunity => opportunity.FormattedCalculatedProbabilityOfClose);
            HotOpportunites.DataBind();
            MediumOpportunities.DataSource = categorizedTopCategories.MediumOpportunities.OrderByDescending(opportunity => opportunity.FormattedCalculatedProbabilityOfClose);
            MediumOpportunities.DataBind();
            ColdOpportunities.DataSource = categorizedTopCategories.ColdOpportunities.OrderByDescending(opportunity => opportunity.FormattedCalculatedProbabilityOfClose);
            ColdOpportunities.DataBind();
        }
    }
}