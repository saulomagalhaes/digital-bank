using AutoMapper;
using DigitalBank.Application.DTOs.Person;
using DigitalBank.Domain.Entities;

namespace DigitalBank.Application.Profiles;

public class PersonProfile : Profile
{
	public PersonProfile()
	{
		CreateMap<CreatePersonDto, Person>().ReverseMap();
		CreateMap<ReadPersonDto, Person>().ReverseMap();
		CreateMap<UpdatePersonDto, Person>().ReverseMap();
	}
}
