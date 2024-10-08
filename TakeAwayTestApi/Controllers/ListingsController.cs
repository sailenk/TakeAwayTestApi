using Microsoft.AspNetCore.Mvc;
using TakeAwayTestApi.Service;

namespace TakeAwayTestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ListingsController : ControllerBase
{
    private readonly ITakeAwayTestService _takeAwayTestService;

    public ListingsController(ITakeAwayTestService takeAwayTestService)
    {
        _takeAwayTestService = takeAwayTestService ?? throw new ArgumentNullException(nameof(takeAwayTestService));
    }

    [HttpGet("saved/{userId}/{pageNumber}/{pageSize}")]
    public async Task<IActionResult> GetSavedListings(int userId, int pageNumber, int pageSize)
    {
        ICollection<SavedListingData>? savedListingDatas = await _takeAwayTestService.GetSavedListingAsync(userId, pageNumber, pageSize);
        if (savedListingDatas != null)
        {
            return Ok(savedListingDatas);
        }

        return Ok();
    }

    [HttpGet("shortlisted/count/{propertyId}")]
    public async Task<IActionResult> GetTotalCount(int propertyId)
    {
        int count = await _takeAwayTestService.GetTotalShortlistedAsync(propertyId);
        return Ok(count);
    }

    [HttpPost("add")]
    public async Task<IActionResult> PostSaveListing([FromBody] SavedListingData data)
    {
        if (!ModelState.IsValid)
        {
            return new BadRequestResult();
        }

        var result = await _takeAwayTestService.AddSavedListingAsync(data);

        if (!result)
        {
            return new BadRequestResult();
        }

        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> PutSavedListing([FromBody] SavedListingData data)
    {
        if (!ModelState.IsValid)
        {
            return new BadRequestResult();
        }

        var result = await _takeAwayTestService.UpdateSavedListingAsync(data);

        if (!result)
        {
            return new BadRequestResult();
        }

        return Ok(result);
    }

    [HttpDelete("delete/{listingId}/{userId}")]
    public async Task<IActionResult> DeleteSavedListing(int listingId, int userId)
    {
        await _takeAwayTestService.DeleteSavedListingAsync(listingId, userId);

        return Ok();
    }

}