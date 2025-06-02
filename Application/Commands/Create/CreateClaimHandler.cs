using Claim.Application;
using Claim.Domain;
using MediatR;
using System;
using Claim.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Claim.Application.Commands.Create
{

    public class CreateClaimHandler : IRequestHandler<CreateClaimCommand, ClaimDomain>
    {
        private readonly IClaimRepository _repository;

        public CreateClaimHandler(IClaimRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClaimDomain> Handle(CreateClaimCommand request, CancellationToken cancellationToken)
        {
            var claim = new ClaimDomain
            {
                ClaimId = Guid.NewGuid().ToString(),
                PolicyId = request.PolicyId,
                Description = request.Description,
                Status = "Pending",
                Notes = new List<ClaimNote>()
            };

            await _repository.AddClaimAsync(claim);
            return claim;
        }
    }
}
