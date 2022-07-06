namespace VesselsTracking.Dto.Requests;

public class UpdateTrackedVesselRequest
{
    public long ImoNumber { get; set; }
    public string VesselName { get; set; }
    public string Position { get; set; }
    public DateTime? TrackedTime { get; set; }
}