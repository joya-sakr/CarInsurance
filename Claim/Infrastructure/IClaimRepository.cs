using Claim.Domain;

public interface IClaimRepository
{
	Task<ClaimDomain> GetClaimByIdAsync(string claimId);
	Task<IEnumerable<ClaimDomain>> GetClaimsByPolicyIdAsync(string policyId);
	Task AddClaimAsync(ClaimDomain claim);
	Task UpdateClaimAsync(ClaimDomain claim);
	Task AddNoteToClaimAsync(string claimId, string note);
}