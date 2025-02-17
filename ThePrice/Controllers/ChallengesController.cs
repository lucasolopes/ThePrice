using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace ThePrice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChallengesController(IChallengesService challengesService) : ControllerBase
{
    private readonly IChallengesService _challengesService = challengesService;

    [HttpGet]
    public async Task<IActionResult> GetRandomChallenges()
    {
        Challenge challenges = await _challengesService.GetRandomChallenge();
        return Ok(challenges);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAttachChallenges(List<string> challenges)
    {
        await _challengesService.CreateAttachChallenges(challenges);
        return Ok();
    }

}

