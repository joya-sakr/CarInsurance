using Claim.Application;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class UpdateClaimHandler : IRequestHandler<UpdateClaimCommand, bool>
{
    private readonly IClaimRepository _repository;

    public UpdateClaimHandler(IClaimRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateClaimCommand request, CancellationToken cancellationToken)
    {
        var existingClaim = await _repository.GetClaimByIdAsync(request.ClaimId);
        if (existingClaim == null) return false;

        existingClaim.PolicyId = request.PolicyId;
        existingClaim.Description = request.Description;
        existingClaim.Amount = request.Amount;
        existingClaim.ClaimDate = request.ClaimDate;

        await _repository.UpdateClaimAsync(existingClaim);
        return true;
    }
}
