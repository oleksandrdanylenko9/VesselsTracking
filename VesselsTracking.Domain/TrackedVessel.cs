namespace VesselsTracking.Domain;

public class TrackedVessel
{
    public TrackedVessel(long imoNumber, string vesselName, string position, DateTime trackedTime)
    {
        Id = Guid.NewGuid();
        ImoNumber = imoNumber;
        VesselName = vesselName;
        Position = position;
        TrackedTime = trackedTime;
    }
    public Guid Id { get; }
    public long ImoNumber { get; private set; }
    public string VesselName { get; private set; }
    public DateTime TrackedTime { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    /// <summary>
    /// Might be some coordinates, use IPoint in the future
    /// </summary>
    public string Position { get; private set; }

    public void Update(long imoNumber, string vesselName, string position, DateTime trackedTime)
    {
        if (imoNumber != default) ImoNumber = imoNumber;
        VesselName = vesselName;
        Position = position;
        if (trackedTime != default) TrackedTime = trackedTime;
        UpdatedAt = DateTime.UtcNow;
    }
}