using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class DeletePolicyHandler : IRequestHandler<DeletePolicyCommand, bool>
{
    private readonly IPolicyRepository _repository;

    public DeletePolicyHandler(IPolicyRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeletePolicyCommand request, CancellationToken cancellationToken)
    {
        var existingPolicy = await _repository.GetPolicyByIdAsync(request.PolicyId);
        if (existingPolicy == null) return false;

        await _repository.DeletePolicyAsync(request.PolicyId);
        return true;
    }
}
