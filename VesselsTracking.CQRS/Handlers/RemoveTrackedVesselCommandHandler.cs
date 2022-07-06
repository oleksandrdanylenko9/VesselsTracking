using MediatR;
using Microsoft.EntityFrameworkCore;
using VesselsTracking.CQRS.Commands;
using VesselsTracking.Persistence;

namespace VesselsTracking.CQRS.Handlers;

public class RemoveTrackedVesselCommandHandler : IRequestHandler<RemoveTrackedVesselCommand, Unit>
{
    private readonly VesselsDbContext _context;

    public RemoveTrackedVesselCommandHandler(VesselsDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(RemoveTrackedVesselCommand request, CancellationToken cancellationToken)
    {
        var vessel = await _context.TrackedVessels.FirstOrDefaultAsync(x => x.Id == request.TrackingId, cancellationToken);
        if (vessel == null)
            throw new Exception($"Vessel with ID {request.TrackingId} not found");

        _context.Remove(vessel);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}