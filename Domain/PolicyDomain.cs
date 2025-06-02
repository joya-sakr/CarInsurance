using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using Policy.Domain;

namespace Policy.Domain
{
    public class PolicyDomain
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PolicyId { get; set; } 

        [Required]
        public string PolicyNumber { get; set; } = null!;

        [Required]
        public string CarPlateNumber { get; set; } = null!;

        [Required]
        public DateTime EffectiveDate { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public decimal Premium { get; set; }

        [Required]
        public string Stats { get; set; } = null!;

        [Required]
        public Insured Insured { get; set; } = null!;
    }
}
