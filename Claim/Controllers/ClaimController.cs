using Microsoft.AspNetCore.Mvc;
using Claim.Domain;
using Claim.Application;
using MongoDB.Bson;
using MediatR;

namespace Claim.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimRepository _claimRepository;

        public ClaimsController(IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClaim([FromBody] ClaimDomain claim)
        {
            claim.ClaimId = ObjectId.GenerateNewId().ToString();
           // claim.Notes = claim.Notes ?? new List<ClaimNote>();
           // claim.Status = string.IsNullOrEmpty(claim.Status) ? "Pending" : claim.Status;

            await _claimRepository.AddClaimAsync(claim);
            return CreatedAtAction(nameof(GetClaim), new { id = claim.ClaimId }, claim);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClaim(string id)
        {
            var claim = await _claimRepository.GetClaimByIdAsync(id);
            if (claim == null)
                return NotFound();
            return Ok(claim);
        }

        [HttpGet]
        public async Task<IActionResult> GetClaimsByPolicyId([FromQuery] string policyId)
        {
            var claims = await _claimRepository.GetClaimsByPolicyIdAsync(policyId);
            return Ok(claims);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateClaimStatus(string id, [FromBody] string status)
        {
            var claim = await _claimRepository.GetClaimByIdAsync(id);
            if (claim == null)
                return NotFound();

            claim.Status = status;
            await _claimRepository.UpdateClaimAsync(claim);

            return Ok("Claim status updated");
        }

        [HttpPost("{id}/notes")]
        public async Task<IActionResult> AddNoteToClaim(string id, [FromBody] ClaimNote note)
        {
            var claim = await _claimRepository.GetClaimByIdAsync(id);
            if (claim == null)
                return NotFound();

            note.Id = ObjectId.GenerateNewId().ToString();
            if (claim.Notes == null)
                claim.Notes = new List<ClaimNote>();
            claim.Notes.Add(note);

            await _claimRepository.UpdateClaimAsync(claim);
            return Ok("Note added to claim");
        }
    }
}
