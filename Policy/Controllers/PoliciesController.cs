using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Policy.Domain;

namespace Policy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoliciesController : ControllerBase
    {
        private readonly IMongoCollection<PolicyDomain> _policies;

        public PoliciesController(IMongoCollection<PolicyDomain> policies)
        {
            _policies = policies;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePolicy([FromBody] PolicyDomain policy)
        {
            await _policies.InsertOneAsync(policy);
            return CreatedAtAction(nameof(GetPolicy), new { id = policy.Id }, policy);
        }

        [HttpGet]
        public async Task<IActionResult> GetPolicies()
        {
            var policies = await _policies.Find(_ => true).ToListAsync();
            return Ok(policies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPolicy(string id)
        {
            var policy = await _policies.Find(p => p.Id == id).FirstOrDefaultAsync();
            if (policy == null)
                return NotFound();
            return Ok(policy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePolicy(string id, [FromBody] PolicyDomain updated)
        {
            var result = await _policies.ReplaceOneAsync(p => p.Id == id, updated);
            if (result.MatchedCount == 0)
                return NotFound();
            return Ok("Policy updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(string id)
        {
            var result = await _policies.DeleteOneAsync(p => p.Id == id);
            if (result.DeletedCount == 0)
                return NotFound();
            return Ok("Policy deleted");
        }
    }
}
