using Claim.Domain;
using Claim.Infrastructure;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Claim.Application.Queries.GetByPolicyId
{

	public class GetClaimsByPolicyIdHandler : IRequestHandler<GetClaimsByPolicyIdQuery, IEnumerable<ClaimDomain>>
	{
		private readonly IClaimRepository _repository;

		public GetClaimsByPolicyIdHandler(IClaimRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<ClaimDomain>> Handle(GetClaimsByPolicyIdQuery request, CancellationToken cancellationToken)
		{
			return await _repository.GetClaimsByPolicyIdAsync(request.PolicyId);
		}
	}
}
