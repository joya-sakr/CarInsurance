using MediatR;

public class DeletePolicyCommand : IRequest<bool>
{
    public string PolicyId { get; set; }

    public DeletePolicyCommand(string policyId)
    {
        PolicyId = policyId;
    }
}
