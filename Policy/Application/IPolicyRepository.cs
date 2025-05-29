using Policy.Domain;
public interface IPolicyRepository
{
	Task<PolicyDomain> GetPolicyByIdAsync(string policyId);
	Task<IEnumerable<PolicyDomain>> GetAllPoliciesAsync();
	Task AddPolicyAsync(PolicyDomain policy);
	Task UpdatePolicyAsync(PolicyDomain policy);
	Task DeletePolicyAsync(string policyId);
}