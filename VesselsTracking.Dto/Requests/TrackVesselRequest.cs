using System.ComponentModel.DataAnnotations;

namespace VesselsTracking.Dto.Requests;

public class TrackVesselRequest
{
    [Required]
    public long ImoNumber { get; set; }
    [Required]
    public string VesselName { get; set; }
    [Required]
    public string Position { get; set; }
    [Required]
    public DateTime TrackedDate { get; set; }
}