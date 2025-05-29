using MediatR;
using Claim.Application;
using System.Threading;
using System.Threading.Tasks;

namespace Claim.Infrastructure.Commands.Notes
{
    public class AddClaimNoteHandler : IRequestHandler<AddClaimNoteCommand, bool>
    {
        private readonly IClaimRepository _repository;

        public AddClaimNoteHandler(IClaimRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(AddClaimNoteCommand request, CancellationToken cancellationToken)
        {
            var claim = await _repository.GetClaimByIdAsync(request.ClaimId);

            if (claim == null)
                return false;

            await _repository.AddNoteToClaimAsync(request.ClaimId, request.Note);

            return true;
        }
    }
}
