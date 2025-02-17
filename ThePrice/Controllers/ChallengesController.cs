using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared.Request;
using Shared.Response;

namespace ThePrice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChallengesController(IChallengesService challengesService) : ControllerBase
{
    private readonly IChallengesService _challengesService = challengesService;

    [HttpGet]
    public async Task<IActionResult> GetRandomChallenges()
    {
        ChallengeResponse challenges = await _challengesService.GetRandomChallenge();
        return Ok(challenges);
    }

    [HttpPost]
    [Route("Attach")]
    public async Task<IActionResult> CreateAttachChallenges(List<ChallengeRequest> challenges)
    {
        await _challengesService.CreateAttachChallenges(challenges);
        return Ok();
    }

}

