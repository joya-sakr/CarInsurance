using MediatR;
using System;

public class UpdateClaimCommand : IRequest<bool>
{
    public string ClaimId { get; set; }
    public string PolicyId { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime ClaimDate { get; set; }

    public UpdateClaimCommand(string claimId, string policyId, string description, decimal amount, DateTime claimDate)
    {
        ClaimId = claimId;
        PolicyId = policyId;
        Description = description;
        Amount = amount;
        ClaimDate = claimDate;
    }
}
