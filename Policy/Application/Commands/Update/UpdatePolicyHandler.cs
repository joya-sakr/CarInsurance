using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Policy.Domain;

namespace Policy.Application.Commands.Update
{

    public class UpdatePolicyHandler : IRequestHandler<UpdatePolicyCommand, bool>
    {
        private readonly IPolicyRepository _repository;

        public UpdatePolicyHandler(IPolicyRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdatePolicyCommand request, CancellationToken cancellationToken)
        {
            var existingPolicy = await _repository.GetPolicyByIdAsync(request.Id);
            if (existingPolicy == null) return false;

            existingPolicy.PolicyNumber = request.PolicyNumber;
            existingPolicy.CarPlateNumber = request.CarPlateNumber;
            existingPolicy.EffectiveDate = request.EffectiveDate;
            existingPolicy.ExpirationDate = request.ExpirationDate;
            existingPolicy.Premium = request.Premium;
            existingPolicy.Stats = request.Stats;
            existingPolicy.Insured = request.Insured;

            await _repository.UpdatePolicyAsync(existingPolicy);
            return true;
        }
    }
}
