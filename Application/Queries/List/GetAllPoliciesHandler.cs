using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Policy.Domain;
using System.Linq.Expressions;
using Policy.Infrastructure;

namespace Policy.Application.Queries.List
{

	public class GetAllPoliciesHandler : IRequestHandler<GetAllPoliciesQuery, IEnumerable<PolicyDomain>>
	{
		private readonly IPolicyRepository _repository;

		public GetAllPoliciesHandler(IPolicyRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<PolicyDomain>> Handle(GetAllPoliciesQuery request, CancellationToken cancellationToken)
		{
			return await _repository.GetAllPoliciesAsync();
		}
	}
}
