using MediatR;
using Policy.Domain;

namespace Policy.Application.Queries.Get
{

    public class GetPolicyByIdQuery : IRequest<PolicyDomain>
    {
        public string Id { get; set; }

        public GetPolicyByIdQuery(string id)
        {
            Id = id;
        }
    }
}
