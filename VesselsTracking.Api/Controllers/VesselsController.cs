using System.ComponentModel.DataAnnotations;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VesselsTracking.CQRS.Commands;
using VesselsTracking.CQRS.Queries;
using VesselsTracking.Dto.Requests;
using VesselsTracking.Dto.Responses;

namespace VesselsTracking.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VesselsController : ControllerBase
{
    private readonly ISender _sender;
    public VesselsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    [ProducesResponseType(typeof(TrackedVesselsResponse[]), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Array), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetVessels()
    {
        var result = await _sender.Send(new GetTrackedVesselsQuery());

        return Ok(result);
    }

    [HttpPost]
    [Route("track")]
    [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> TrackVessel([FromBody, Required] TrackVesselRequest request)
    {
        var result = await _sender.Send(
            new TrackVesselCommand(request.ImoNumber, request.VesselName, request.Position, request.TrackedDate));

        return Ok(
            new
            {
                TrackingId = result
            });
    }

    [HttpPut]
    [Route("{trackingId:guid}")]
    [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> ChangeVesselData([FromRoute, Required] Guid trackingId, [FromBody] UpdateTrackedVesselRequest request)
    {
        var result = await _sender.Send(
            new UpdateTrackedVesselCommand(trackingId, request.ImoNumber, request.VesselName, request.Position, request.TrackedTime));

        return Ok(result);
    }
    
    [HttpDelete]
    [Route("{trackingId:guid}")]
    [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> ChangeVesselData([FromRoute, Required] Guid trackingId)
    {
        var result = await _sender.Send(
            new RemoveTrackedVesselCommand(trackingId));

        return Ok(result);
    }
}