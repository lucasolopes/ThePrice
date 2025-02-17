﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories;
public interface IChallengesRepository
{
    Task<Challenge> GetRandomChallenge();
    Task CreateAttachChallenges(List<Challenge> challengesList);
}

