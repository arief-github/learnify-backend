using API.DTO;
using AutoMapper;
using Entity;

namespace API.Helpers
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(c => c.Category, o => o.MapFrom(s => s.Category.Name));

            CreateMap<Requirement, RequirementDto>();
            CreateMap<Learning, LearningDto>();
        }
    }
}