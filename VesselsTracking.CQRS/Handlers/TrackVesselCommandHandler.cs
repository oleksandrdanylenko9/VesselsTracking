using MediatR;
using VesselsTracking.CQRS.Commands;
using VesselsTracking.Domain;
using VesselsTracking.Persistence;

namespace VesselsTracking.CQRS.Handlers;

public class TrackVesselCommandHandler : IRequestHandler<TrackVesselCommand, Guid>
{
    private readonly VesselsDbContext _context;
    public TrackVesselCommandHandler(VesselsDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(TrackVesselCommand request, CancellationToken cancellationToken)
    {
        var trackedVessel = new TrackedVessel(request.ImoNumber, request.VesselName, request.Position, request.TrackedTime);

        await _context.AddAsync(trackedVessel, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return trackedVessel.Id;
    }
}