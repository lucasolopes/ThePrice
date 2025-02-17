using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;
public class ChallengesRepository(ThePriceDbContext context) : IChallengesRepository
{
    private readonly ThePriceDbContext _context = context;

    public async Task CreateAttachChallenges(List<Challenge> challengesList)
    {
        await _context.Challenges.AddRangeAsync(challengesList);
        await _context.SaveChangesAsync();
    }

    public async Task<Challenge> GetRandomChallenge()
    {
        return await _context.Challenges
            .FromSqlRaw("SELECT * FROM Challenges ORDER BY RAND() LIMIT 1")
            .FirstOrDefaultAsync();
    }
}

