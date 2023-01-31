using AutoMapper;
using DigitalBank.Application.DTOs.Account;
using DigitalBank.Domain.Entities;

namespace DigitalBank.Application.Profiles;

public class AccountProfile : Profile
{
	public AccountProfile()
	{
		CreateMap<CreateAccountDto, Account>().ReverseMap();
		CreateMap<UpdateAccountDto, Account>().ReverseMap();
		CreateMap<ReadAccountDto, Account>().ReverseMap();
	}
}
