using MediatR;

namespace VesselsTracking.CQRS.Commands;

public class TrackVesselCommand : IRequest<Guid>
{
    public TrackVesselCommand(long imoNumber, string vesselName, string position, DateTime trackedTime)
    {
        ImoNumber = imoNumber;
        VesselName = vesselName;
        Position = position;
        TrackedTime = trackedTime;
    }

    public long ImoNumber { get; }
    public string VesselName { get; }
    public string Position { get; }
    public DateTime TrackedTime { get; }
}