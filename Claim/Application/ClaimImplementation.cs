using Claim.Domain;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Claim.Application
{
    public class ClaimImplementation : IClaimRepository
    {
        private readonly IMongoCollection<ClaimDomain> _claims;

        public ClaimImplementation(IMongoDatabase database)
        {
            _claims = database.GetCollection<ClaimDomain>("Claims");
        }

        public async Task<ClaimDomain> GetClaimByIdAsync(string claimId)
        {
            return await _claims.Find(c => c.ClaimId == claimId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ClaimDomain>> GetClaimsByPolicyIdAsync(string policyId)
        {
            return await _claims.Find(c => c.PolicyId == policyId).ToListAsync();
        }

        public async Task AddClaimAsync(ClaimDomain claim)
        {
            await _claims.InsertOneAsync(claim);
        }

        public async Task UpdateClaimAsync(ClaimDomain claim)
        {
            await _claims.ReplaceOneAsync(c => c.ClaimId == claim.ClaimId, claim);
        }

        public async Task AddNoteToClaimAsync(string claimId, string note)
        {
            var filter = Builders<ClaimDomain>.Filter.Eq(c => c.ClaimId, claimId);

            var newNote = new ClaimNote
            {
                Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString(),
                CreatedBy = "system", // You can replace this with real user info
                CreatedAt = DateTime.UtcNow,
                Note = note
            };

            var update = Builders<ClaimDomain>.Update.Push(c => c.Notes, newNote);

            await _claims.UpdateOneAsync(filter, update);
        }
    }
}
