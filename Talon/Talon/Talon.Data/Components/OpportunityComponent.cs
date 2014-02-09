using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talon.Data.Repositories.Interfaces;

namespace Talon.Data.Components
{
    using Models;
    using Repositories;
    using Salesforce.Force;

    public class OpportunityComponent
    {
        #region Private Properties

        private readonly IOpportunityRepository Repository;

        private readonly ForceClient ForceClient;

        #endregion

        #region Public Methods

        public OpportunityComponent(IOpportunityRepository repository, ForceClient client)
        {
            Repository = repository;
            ForceClient = client;
        }

        public OpportunityComponent(ForceClient client) : this(new OpportunityRepository(), client)
        {

        }

        public async Task<IEnumerable<Opportunity>> GetOpportunities()
        {
            return await Repository.GetOpportunities(ForceClient);
        }

        public async Task<Opportunity> GetOpportunityById(string opportunityId)
        {
            return await Repository.GetOpportunity(ForceClient, opportunityId);
        }

        #endregion
    }
}
