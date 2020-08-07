using System.Linq;
using AutoMapper;
using DotNetDatingApp.api.Dtos;
using DotNetDatingApp.api.Models;

namespace DotNetDatingApp.api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.photoUrl, opt =>
                {
                    opt.MapFrom(src => src.photos.FirstOrDefault(p => p.ismain).url);
                })
                .ForMember(dest => dest.age, opt =>
                {
                    opt.MapFrom(d => d.dateOfBirth.CalculateAge());
                });
            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.photoUrl, opt =>
                {
                    opt.MapFrom(src => src.photos.FirstOrDefault(p => p.ismain).url);
                })
                .ForMember(dest => dest.age, opt =>
                {
                    opt.MapFrom(d => d.dateOfBirth.CalculateAge());
                });
            CreateMap<Photo, PhotosForDetailedDto>();
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto, Photo>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<MessageForCreationDto, Message>().ReverseMap();
            CreateMap<Message, MessageToReturnDto>()
                .ForMember(m => m.SenderPhotoUrl, opt => opt
                    .MapFrom(u => u.Sender.photos.FirstOrDefault(p => p.ismain).url))
                .ForMember(m => m.RecipientPhotoUrl, opt => opt
                    .MapFrom(u => u.Recipient.photos.FirstOrDefault(p => p.ismain).url));
        }
    }
}