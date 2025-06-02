using MediatR;
using System.Collections.Generic;
using Policy.Domain;

namespace Policy.Application.Queries.List
{

    public class GetAllPoliciesQuery : IRequest<IEnumerable<PolicyDomain>>
    {
    }
}
