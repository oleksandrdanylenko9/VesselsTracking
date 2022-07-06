namespace VesselsTracking.Dto.Responses;

public class TrackedVesselsResponse
{
    public Guid Id { get; set; }
    public long ImoNumber { get; set; }
    public string VesselName { get; set; }
    public DateTime TrackedTime { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string Position { get; set; }
}