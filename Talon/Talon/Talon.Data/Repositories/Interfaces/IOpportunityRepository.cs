using System.Collections.Generic;
using System.Threading.Tasks;
using Salesforce.Force;
using Talon.Data.Models;

namespace Talon.Data.Repositories.Interfaces
{
    public interface IOpportunityRepository
    {
        Task<IEnumerable<Opportunity>> GetOpportunities(ForceClient forceClient);

        Task<Opportunity> GetOpportunity(ForceClient forceClient, string opportunityId);
    }
}
