using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Claim.Domain;

namespace Claim.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimsController : ControllerBase
    {
        private readonly IMongoCollection<ClaimDomain> _claims;

        public ClaimsController(IMongoCollection<ClaimDomain> claims)
        {
            _claims = claims;
        }

        [HttpPost]
        public async Task<IActionResult> createClaim([FromBody] ClaimDomain claim)
        {
            await _claims.InsertOneAsync(claim);
            return CreatedAtAction(nameof(getClaim), new { id = claim.ClaimId }, claim);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getClaim(string id)
        {
            var claim = await _claims.Find(c => c.ClaimId == id).FirstOrDefaultAsync();
            if (claim == null)
                return NotFound();
            return Ok(claim);
        }

        [HttpGet]
        public async Task<IActionResult> getClaimsByPolicyId([FromQuery] string policyId)
        {
            var claims = await _claims.Find(c => c.PolicyId == policyId).ToListAsync();
            return Ok(claims);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateClaimStatus(string id, [FromBody] string status)
        {
            var update = Builders<ClaimDomain>.Update.Set(c => c.Status, status);
            var result = await _claims.UpdateOneAsync(c => c.ClaimId == id, update);

            if (result.MatchedCount == 0)
                return NotFound();

            return Ok("Claim status updated");
        }

        [HttpPost("{id}/notes")]
        public async Task<IActionResult> AddNoteToClaim(string id, [FromBody] ClaimNote note)
        {
            var update = Builders<ClaimDomain>.Update.Push(c => c.Notes, note);
            var result = await _claims.UpdateOneAsync(c => c.ClaimId == id, update);

            if (result.MatchedCount == 0)
                return NotFound();

            return Ok("Note added to claim");
        }
    }
}
