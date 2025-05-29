using MediatR;
using Claim.Domain;

public class GetClaimByIdQuery : IRequest<ClaimDomain>
{
	public string Id { get; set; }

	public GetClaimByIdQuery(string id)
	{
		Id = id;
	}
}
