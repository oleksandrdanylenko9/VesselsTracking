using MediatR;
using Microsoft.EntityFrameworkCore;
using VesselsTracking.CQRS.Queries;
using VesselsTracking.Dto.Responses;
using VesselsTracking.Persistence;

namespace VesselsTracking.CQRS.Handlers;

public class GetTrackedVesselsQueryHandler : IRequestHandler<GetTrackedVesselsQuery, TrackedVesselsResponse[]>
{
    private readonly VesselsDbContext _context;

    public GetTrackedVesselsQueryHandler(VesselsDbContext context)
    {
        _context = context;
    }

    public async Task<TrackedVesselsResponse[]> Handle(GetTrackedVesselsQuery request, CancellationToken cancellationToken)
    {
        return await _context.TrackedVessels.Select(
            x => new TrackedVesselsResponse
            {
                Id = x.Id,
                ImoNumber = x.ImoNumber,
                VesselName = x.VesselName,
                Position = x.Position,
                TrackedTime = x.TrackedTime,
                UpdatedAt = x.UpdatedAt,
            }).ToArrayAsync(cancellationToken: cancellationToken);
    }
}