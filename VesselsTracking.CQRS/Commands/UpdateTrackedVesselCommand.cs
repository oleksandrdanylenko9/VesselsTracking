using MediatR;

namespace VesselsTracking.CQRS.Commands;

public class UpdateTrackedVesselCommand : IRequest<Unit>
{
    public UpdateTrackedVesselCommand(Guid id, long imoNumber, string vesselName, string position, DateTime? trackedTime)
    {
        Id = id;
        ImoNumber = imoNumber;
        VesselName = vesselName;
        Position = position;
        TrackedTime = trackedTime;
    }

    public Guid Id { get; }
    public long ImoNumber { get; }
    public string VesselName { get; }
    public string Position { get; }
    public DateTime? TrackedTime { get; }
}