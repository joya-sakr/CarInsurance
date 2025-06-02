using MongoDB.Driver;
using Policy.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Policy.Infrastructure
{
    public class PolicyImplementation : IPolicyRepository
    {
        private readonly IMongoCollection<PolicyDomain> _policies;

        public PolicyImplementation(IMongoDatabase database)
        {
            _policies = database.GetCollection<PolicyDomain>("Policies");
        }

        public async Task<PolicyDomain> GetPolicyByIdAsync(string policyId)
        {
            return await _policies.Find(p => p.PolicyId == policyId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PolicyDomain>> GetAllPoliciesAsync()
        {
            return await _policies.Find(_ => true).ToListAsync();
        }

        public async Task AddPolicyAsync(PolicyDomain policy)
        {
            await _policies.InsertOneAsync(policy);
        }

        public async Task UpdatePolicyAsync(PolicyDomain policy)
        {
            await _policies.ReplaceOneAsync(p => p.PolicyId == policy.PolicyId, policy);
        }

        public async Task DeletePolicyAsync(string policyId)
        {
            await _policies.DeleteOneAsync(p => p.PolicyId == policyId);
        }
    }
}
