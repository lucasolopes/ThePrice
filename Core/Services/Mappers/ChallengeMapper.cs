using Domain.Entities;
using Shared.Request;
using Shared.Response;

namespace Services.Mappers;
public static class ChallengeMapper
{
    public static ChallengeResponse Convert(Challenge challenge)
    {
        return new ChallengeResponse
        {
            Challenge = challenge.Challenges
        };
    }

    public static List<Challenge> Convert(List<ChallengeRequest> challenges)
    {
        return challenges.Select(challenge => new Challenge
        {
            Challenges = challenge.Challenge
        }).ToList();
    }
}
