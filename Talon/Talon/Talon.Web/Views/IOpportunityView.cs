namespace Talon.Web.Views
{
    public interface IOpportunityView
    {
        Data.Models.TopOpportunity CurrentOpportunity { get; set; }

        string OpportunityId { get; }
    }
}
