using AutoMapper;
using DigitalBank.Application.DTOs.User;
using DigitalBank.Domain.Entities;

namespace DigitalBank.Application.Profiles;

public class UserProfileDto : Profile
{
	public UserProfileDto()
	{
		CreateMap<RegisterUserDto, User>().ReverseMap();
		CreateMap<RegisterUserDto, Person>().ReverseMap();
    }
}
