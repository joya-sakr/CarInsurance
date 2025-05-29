using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Policy.Domain;

namespace Policy.Application.Commands.CreatePolicy
{
    public class CreatePolicyCommandHandler : IRequestHandler<CreatePolicyCommand, string>
    {
        private readonly IPolicyRepository _policyRepository;

        public CreatePolicyCommandHandler(IPolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }

        public async Task<string> Handle(CreatePolicyCommand request, CancellationToken cancellationToken)
        {
            var policy = new PolicyDomain
            {
                PolicyNumber = request.PolicyNumber,
                CarPlateNumber = request.CarPlateNumber,
                EffectiveDate = request.EffectiveDate,
                ExpirationDate = request.ExpirationDate,
                Premium = request.Premium,
                Stats = request.Stats,
                Insured = request.Insured
            };

            await _policyRepository.AddPolicyAsync(policy);
            return policy.Id;
        }
    }
}
