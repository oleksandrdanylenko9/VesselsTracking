using MediatR;
using VesselsTracking.Dto.Responses;

namespace VesselsTracking.CQRS.Queries;

public class GetTrackedVesselsQuery : IRequest<TrackedVesselsResponse[]>
{

}