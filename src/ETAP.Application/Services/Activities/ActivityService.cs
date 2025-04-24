using AutoMapper;
using ETAP.Application.DTOs.Activities;
using ETAP.Application.Interfaces;
using ETAP.Domain.Entities;
using Ardalis.Specification;

namespace ETAP.Application.Services.Activities
{
    public class ActivityService : IActivityService
    {
        private readonly IRepositoryBase<Activity> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ActivityService(IRepositoryBase<Activity> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ActivityDto>> GetAllAsync()
        {
            var activities = await _repository.ListAsync();
            return _mapper.Map<List<ActivityDto>>(activities);
        }

        public async Task<ActivityDto?> GetByIdAsync(Guid id)
        {
            var activity = await _repository.GetByIdAsync(id);
            return activity is null ? null : _mapper.Map<ActivityDto>(activity);
        }

        public async Task CreateAsync(CreateActivityRequest request)
        {
            var activity = _mapper.Map<Activity>(request);
            await _repository.AddAsync(activity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var activity = await _repository.GetByIdAsync(id);
            if (activity is not null)
            {
                await _repository.DeleteAsync(activity);
            }
        }

        public async Task UpdateAsync(UpdateActivityRequest request)
        {
            var activity = await _repository.GetByIdAsync(request.Id);
            if (activity is null) throw new Exception("Etkinlik bulunamadı.");

            _mapper.Map(request, activity); // var olan entity'ye map et

            await _repository.UpdateAsync(activity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}