using MediatR;
using Policy.Domain;

namespace Policy.Application.Queries.Get
{

    public class GetPolicyByIdQuery : IRequest<PolicyDomain>
    {
        public string PolicyId { get; set; }

        public GetPolicyByIdQuery(string id)
        {
            PolicyId = id;
        }
    }
}
