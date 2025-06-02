using MediatR;
using Policy.Domain;
using System;

namespace Policy.Application.Commands.Create
{
    public class CreatePolicyCommand : IRequest<string>
    {
        public string PolicyNumber { get; set; } = null!;
        public string CarPlateNumber { get; set; } = null!;
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Premium { get; set; }
        public string Stats { get; set; } = null!;
        public Insured Insured { get; set; } = null!;
    }
}
