using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Services.Abstractions;

namespace Services.Implementations;
public class ChallengesService(IChallengesRepository repository) : IChallengesService
{
    private readonly IChallengesRepository _repository = repository;

    public async Task CreateAttachChallenges(List<string> challenges)
    {
        var challengesList = challenges.Select(x => new Challenge { challenge = x }).ToList();

        await _repository.CreateAttachChallenges(challengesList);
    }

    public async Task<Challenge> GetRandomChallenge()
    {
        return await _repository.GetRandomChallenge();
    }
}

