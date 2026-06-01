using TraderDashboard.Domain.Entities;

namespace TraderDashboard.Application.Interfaces;

public interface IStrategyRepository : IRepository<Strategy>
{
    Task<Strategy?> GetByNameAsync(string name);
}