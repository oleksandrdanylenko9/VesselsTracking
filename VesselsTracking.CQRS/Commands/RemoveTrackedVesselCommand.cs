using MediatR;

namespace VesselsTracking.CQRS.Commands;

public class RemoveTrackedVesselCommand : IRequest
{
    public RemoveTrackedVesselCommand(Guid trackingId)
    {
        TrackingId = trackingId;
    }

    public Guid TrackingId { get; }
}