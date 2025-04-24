using ETAP.Application.DTOs.Activities;

namespace ETAP.Application.Interfaces
{
    public interface IActivityService
    {
        Task<List<ActivityDto>> GetAllAsync();
        Task<ActivityDto?> GetByIdAsync(Guid id);
        Task CreateAsync(CreateActivityRequest request);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(UpdateActivityRequest request);
    }
}