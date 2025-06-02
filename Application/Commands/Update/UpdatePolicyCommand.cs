using MediatR;
using System;
using Policy.Domain;

namespace Policy.Application.Commands.Update { 

public class UpdatePolicyCommand : IRequest<bool>
{
    public string PolicyId { get; set; }
    public string PolicyNumber { get; set; }
    public string CarPlateNumber { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public decimal Premium { get; set; }
    public string Stats { get; set; }
    public Insured Insured { get; set; }

        public UpdatePolicyCommand(
            string policyid,
            string policyNumber,
            string carPlateNumber,
            DateTime effectiveDate,
            DateTime expirationDate,
            decimal premium,
            string stats,
            Insured insured)
        {
            PolicyId = policyid;
            PolicyNumber = policyNumber;
            CarPlateNumber = carPlateNumber;
            EffectiveDate = effectiveDate;
            ExpirationDate = expirationDate;
            Premium = premium;
            Stats = stats;
            Insured = insured;

        }
    }
}
