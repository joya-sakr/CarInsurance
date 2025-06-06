using Claim.Domain;
using MediatR;
using System.Collections.Generic;
using Policy.Domain; 

namespace Claim.Application.Queries.GetByPolicyId
{

    public class GetClaimsByPolicyIdQuery : IRequest<IEnumerable<ClaimDomain>>
    {
        public string PolicyId { get; }

        public GetClaimsByPolicyIdQuery(string policyId)
        {
            PolicyId = policyId;
        }
    }
}
