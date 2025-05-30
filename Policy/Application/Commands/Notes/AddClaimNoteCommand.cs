using MediatR;

namespace Claim.Infrastructure.Commands.Notes
{
    public class AddClaimNoteCommand : IRequest<bool>
    {
        public string ClaimId { get; set; }
        public string Note { get; set; }

        public AddClaimNoteCommand(string claimId, string note)
        {
            ClaimId = claimId;
            Note = note;
        }
    }
}
