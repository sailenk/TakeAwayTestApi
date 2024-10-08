using Microsoft.AspNetCore.Mvc;
using TakeAwayTestApi.Service;

namespace TakeAwayTestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ITakeAwayTestService _takeAwayTestService;

    public UsersController(ITakeAwayTestService takeAwayTestService)
    {
        _takeAwayTestService = takeAwayTestService ?? throw new ArgumentNullException(nameof(takeAwayTestService));
    }


    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUser(int userId)
    {
        UserData? user = await _takeAwayTestService.GetUserAsync(userId);

        if (user == null)
        {
            return new NotFoundResult();
        }

        return Ok(user);
    }

    [HttpPost("add")]
    public async Task<IActionResult> PostUser([FromBody] UserData user)
    {
        if (!ModelState.IsValid)
        {
            return new BadRequestResult();
        }

        bool result = await _takeAwayTestService.AddUserAsync(user);
        if (!result)
        {
            return new BadRequestResult();
        }

        return Ok();
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateUser([FromBody] UserData user)
    {
        if (!ModelState.IsValid)
        {
            return new BadRequestResult();
        }

        bool result = await _takeAwayTestService.UpdateUserAsync(user);
        if (!result)
        {
            return new BadRequestResult();
        }

        return Ok();
    }

    [HttpDelete("delete/{userId}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        await _takeAwayTestService.DeleteUserAsync(userId);

        return Ok();
    }
}