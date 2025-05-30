using Claim.Application;
using Claim.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Claim.Application.Queries.Get
{

    public class GetClaimByIdHandler : IRequestHandler<GetClaimByIdQuery, ClaimDomain>
    {
        private readonly IClaimRepository _repository;

        public GetClaimByIdHandler(IClaimRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClaimDomain> Handle(GetClaimByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetClaimByIdAsync(request.Id);
        }
    }
}
