using Claim.Domain;
using MediatR;
using System;

namespace Claim.Application.Commands.Create
{

    public class CreateClaimCommand : IRequest<ClaimDomain>
    {
        public required string PolicyId { get; set; }
        public required DateTime ClaimDate { get; set; }
        public required string Description { get; set; }
        public required decimal Amount { get; set; }
        public required string Status { get; set; }
        public required Insured Insured { get; set; }
    }
}