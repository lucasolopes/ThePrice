using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Abstractions;
public interface IChallengesService
{
    Task<Challenge> GetRandomChallenge();
    Task CreateAttachChallenges(List<string> challenges);
}

