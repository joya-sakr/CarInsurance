using Claim.Domain;
using MediatR;
using System.Collections.Generic;

public class GetClaimsByPolicyIdQuery : IRequest<IEnumerable<ClaimDomain>>
{
    public string PolicyId { get; }

    public GetClaimsByPolicyIdQuery(string policyId)
    {
        PolicyId = policyId;
    }
}
