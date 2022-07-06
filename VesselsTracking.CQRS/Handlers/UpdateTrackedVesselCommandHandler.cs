using MediatR;
using Microsoft.EntityFrameworkCore;
using VesselsTracking.CQRS.Commands;
using VesselsTracking.Persistence;

namespace VesselsTracking.CQRS.Handlers;

public class UpdateTrackedVesselCommandHandler : IRequestHandler<UpdateTrackedVesselCommand, Unit>
{
    private readonly VesselsDbContext _context;

    public UpdateTrackedVesselCommandHandler(VesselsDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateTrackedVesselCommand request, CancellationToken cancellationToken)
    {
        var vessel = await _context.TrackedVessels.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (vessel == null)
            throw new Exception($"Vessel with ID {request.Id} not found");

        vessel.Update(request.ImoNumber, request.VesselName, request.Position, request.TrackedTime.GetValueOrDefault());

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}