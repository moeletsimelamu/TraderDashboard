using Microsoft.EntityFrameworkCore;
using TraderDashboard.Application.Interfaces;
using TraderDashboard.Domain.Entities;
using TraderDashboard.Infrastructure.Data;

namespace TraderDashboard.Infrastructure.Repositories;

public class UploadLogRepository : BaseRepository<UploadLog>, IUploadLogRepository
{
    public UploadLogRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<UploadLog>> GetByUserIdAsync(int userId) =>
        await _context.UploadLogs
            .Where(u => u.UserId == userId)
            .OrderByDescending(u => u.UploadedAt)
            .ToListAsync();
}