using MediatR;
using Policy.Domain;

public class GetPolicyByIdQuery : IRequest<PolicyDomain>
{
    public string Id { get; set; }

    public GetPolicyByIdQuery(string id)
    {
        Id = id;
    }
}
