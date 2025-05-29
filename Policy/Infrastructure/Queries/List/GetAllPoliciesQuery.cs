using MediatR;
using System.Collections.Generic;
using Policy.Domain;

public class GetAllPoliciesQuery : IRequest<IEnumerable<PolicyDomain>>
{
}
