using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Claim.Domain
{
    public class ClaimDomain
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ClaimId { get; set; } = null!;

        [Required]
        public string PolicyId { get; set; } = null!;

        [Required]
        public DateTime ClaimDate { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Status { get; set; } = null!;

        [Required]
        public Insured Insured { get; set; } = null!;

        public List<ClaimNote> Notes { get; set; } = new();
    }
}
