﻿using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ThePriceDbContext(DbContextOptions<ThePriceDbContext> options) : DbContext(options)
{

}

