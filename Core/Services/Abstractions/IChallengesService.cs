using Shared.Request;
using Shared.Response;

namespace Services.Abstractions;
public interface IChallengesService
{
    Task<ChallengeResponse> GetRandomChallenge();
    Task CreateAttachChallenges(List<ChallengeRequest> challenges);
}

