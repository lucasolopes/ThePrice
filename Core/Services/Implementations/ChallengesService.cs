using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Services.Abstractions;
using Services.Mappers;
using Shared.Request;
using Shared.Response;

namespace Services.Implementations;
public class ChallengesService(IChallengesRepository repository) : IChallengesService
{
    private readonly IChallengesRepository _repository = repository;

    public async Task CreateAttachChallenges(List<ChallengeRequest> challenges)
    {
        List<Challenge> challengesList = ChallengeMapper.Convert(challenges);

        await _repository.CreateAttachChallenges(challengesList);
    }

    public async Task<ChallengeResponse> GetRandomChallenge()
    {
        Challenge challenge = await _repository.GetRandomChallenge();

        return ChallengeMapper.Convert(challenge);
    }
}

