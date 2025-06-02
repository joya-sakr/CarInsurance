using MediatR;
using Claim.Domain;

namespace Claim.Application.Queries.Get
{

	public class GetClaimByIdQuery : IRequest<ClaimDomain>
	{
		public string Id { get; set; }

		public GetClaimByIdQuery(string id)
		{
			Id = id;
		}
	}
}