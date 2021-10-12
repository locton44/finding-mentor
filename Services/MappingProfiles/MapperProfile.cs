using AutoMapper;
using Data.Entities;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.MappingProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // USER MODEL
            CreateMap<UserRegisterModel, User>()
                .ReverseMap();
            CreateMap<UserViewModels, User>()
                .ReverseMap();

            //MAJOR MODEL
            CreateMap<MajorViewModel, Major>()
                .ReverseMap(); 
            CreateMap<MajorAddModel, Major>()
                 .ReverseMap();
            CreateMap<MajorUpdateModel, Major>()
                 .ReverseMap();

            //MENTOR MODEL
            CreateMap<MentorAddModel, Mentor>()
                .ReverseMap();
            CreateMap<MentorViewModel, Mentor>()
                .ReverseMap();
            CreateMap<MentorUpdateModel, Mentor>()
                .ReverseMap();
            //STUDENT MODEL
            CreateMap<StudentAddModel, Student>()
                .ReverseMap();
            CreateMap<StudentViewModel, Student>()
                .ReverseMap();
            CreateMap<StudentUpdateModel, Student>()
                .ReverseMap();

            //COURSE MODEL
            CreateMap<CourseAddModels, Course>()
                 .ReverseMap();
            CreateMap<CourseUpdateModels, Course>()
                .ReverseMap();
            CreateMap<CourseViewModel, Course>()
                .ReverseMap();
            // SUBJECT MODEL
            CreateMap<SubjectAddModels, Subject>()
                 .ReverseMap();
            CreateMap<SubjectUpdateModels, Subject>()
                .ReverseMap();
            CreateMap<SubjectViewModel, Subject>()
                .ReverseMap();
            //.ForMember(m => m.PhoneNumber, map => map.MapFrom(m1 => m1.Phone))
        }
    }
}
