using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Policy.Domain;
using Policy.Infrastructure;

namespace Policy.Application.Queries.Get
{

    public class GetPolicyByIdHandler : IRequestHandler<GetPolicyByIdQuery, PolicyDomain>
    {
        private readonly IPolicyRepository _repository;

        public GetPolicyByIdHandler(IPolicyRepository repository)
        {
            _repository = repository;
        }

        public async Task<PolicyDomain> Handle(GetPolicyByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetPolicyByIdAsync(request.PolicyId);
        }
    }
}