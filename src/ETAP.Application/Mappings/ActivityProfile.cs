using AutoMapper;
using ETAP.Application.DTOs.Activities;
using ETAP.Domain.Entities;
using ETAP.Domain.Enums;

namespace ETAP.Application.Mappings
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile()
        {
            // Entity ➡ DTO
            CreateMap<Activity, ActivityDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.DisplayName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.DisplayName))
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.Organization.Name))
                .ForMember(dest => dest.OrganizerFullName, opt => opt.MapFrom(src => $"{src.Organizer.FirstName} {src.Organizer.LastName}"));

            // DTO ➡ Entity (Create)
            CreateMap<CreateActivityRequest, Activity>()
                .ConstructUsing(src => new Activity(
                    src.Title,
                    src.Description,
                    src.StartDate,
                    src.EndDate,
                    src.Location,
                    ActivityCategory.FromValue(src.Category),
                    src.OrganizationId,
                    src.OrganizerId));

            CreateMap<UpdateActivityRequest, Activity>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => ActivityCategory.FromValue(src.Category)))
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}