using Microsoft.AspNetCore.Mvc;
using Policy.Domain;
using Policy.Application;
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
            policy.Id = ObjectId.GenerateNewId().ToString();
            await _policyRepository.AddPolicyAsync(policy);
            return CreatedAtAction(nameof(GetPolicyById), new { id = policy.Id }, policy);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPolicyById(string id)
        {
            var policy = await _policyRepository.GetPolicyByIdAsync(id);
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


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePolicy(string id, [FromBody] PolicyDomain updatedPolicy)
        {
            var existingPolicy = await _policyRepository.GetPolicyByIdAsync(id);
            if (existingPolicy == null)
                return NotFound();

            updatedPolicy.Id = id;
            await _policyRepository.UpdatePolicyAsync(updatedPolicy);
            return Ok("Policy updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(string id)
        {
            var existingPolicy = await _policyRepository.GetPolicyByIdAsync(id);
            if (existingPolicy == null)
                return NotFound();

            await _policyRepository.DeletePolicyAsync(id);
            return Ok("Policy deleted");
        }
    }
}
