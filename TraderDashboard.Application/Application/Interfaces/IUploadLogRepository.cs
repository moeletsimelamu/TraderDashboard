using TraderDashboard.Domain.Entities;

namespace TraderDashboard.Application.Interfaces;

public interface IUploadLogRepository : IRepository<UploadLog>
{
    Task<IEnumerable<UploadLog>> GetByUserIdAsync(int userId);
}