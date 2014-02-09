using Talon.Data.Components;
using Talon.Web.Helpers;
using Talon.Web.Views;

namespace Talon.Web.Presenters
{
    public class OpportunityPresenter
    {
        #region Protected Properties

        protected IOpportunityView View;

        protected OpportunityComponent OpportunityComponent;
        protected ProbabilityStatisticsComponent ProbabilityStatisticsComponent;

        #endregion

        #region Public Properties

        public OpportunityPresenter(IOpportunityView view)
        {
            View = view;
            OpportunityComponent = new OpportunityComponent(AccountHelper.Client);
            ProbabilityStatisticsComponent = new ProbabilityStatisticsComponent();
        }

        public async void Initialize()
        {
            var opportunity =
                await OpportunityComponent.GetOpportunityById(View.OpportunityId);
            View.CurrentOpportunity = ProbabilityStatisticsComponent.GetTopOpportunity(opportunity);
        }

        #endregion
    }
}