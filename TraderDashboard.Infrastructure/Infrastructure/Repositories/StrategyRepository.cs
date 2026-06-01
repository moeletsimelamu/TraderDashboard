using Microsoft.EntityFrameworkCore;
using TraderDashboard.Application.Interfaces;
using TraderDashboard.Domain.Entities;
using TraderDashboard.Infrastructure.Data;

namespace TraderDashboard.Infrastructure.Repositories;

public class StrategyRepository : BaseRepository<Strategy>, IStrategyRepository
{
    public StrategyRepository(AppDbContext context) : base(context) { }

    public async Task<Strategy?> GetByNameAsync(string name) =>
        await _context.Strategies
            .FirstOrDefaultAsync(s => s.Name.ToLower() == name.ToLower());
}