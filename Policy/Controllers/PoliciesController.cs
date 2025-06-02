using Microsoft.AspNetCore.Mvc;
using Policy.Domain;
using MongoDB.Driver;
using Policy.Infrastructure;
using MongoDB.Bson;

namespace Policy.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyRepository _policyRepository;

        public PoliciesController(IPolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePolicy([FromBody] PolicyDomain policy)
        {
            policy.PolicyId = ObjectId.GenerateNewId().ToString();
            await _policyRepository.AddPolicyAsync(policy);
            return CreatedAtAction(nameof(GetPolicyById), new { policyId = policy.PolicyId }, policy);
        }

        [HttpGet("{policyId}")]
        public async Task<IActionResult> GetPolicyById(string policyId)
        {
            var policy = await _policyRepository.GetPolicyByIdAsync(policyId);
            if (policy == null)
                return NotFound();

            return Ok(policy);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPolicies()
        {
            var policies = await _policyRepository.GetAllPoliciesAsync();
            return Ok(policies);
        }

        [HttpPut("{policyId}")]
        public async Task<IActionResult> UpdatePolicy(string policyId, [FromBody] PolicyDomain updatedPolicy)
        {
            var existingPolicy = await _policyRepository.GetPolicyByIdAsync(policyId);
            if (existingPolicy == null)
                return NotFound();

            updatedPolicy.PolicyId = policyId;
            await _policyRepository.UpdatePolicyAsync(updatedPolicy);
            return Ok("Policy updated");
        }

        [HttpDelete("{policyId}")]
        public async Task<IActionResult> DeletePolicy(string policyId)
        {
            var existingPolicy = await _policyRepository.GetPolicyByIdAsync(policyId);
            if (existingPolicy == null)
                return NotFound();

            await _policyRepository.DeletePolicyAsync(policyId);
            return Ok("Policy deleted");
        }
    }
}
