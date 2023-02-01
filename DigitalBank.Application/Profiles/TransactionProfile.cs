using AutoMapper;
using DigitalBank.Application.DTOs.Transaction;
using DigitalBank.Domain.Entities;

namespace DigitalBank.Application.Profiles;

public class TransactionProfile : Profile
{
	public TransactionProfile()
	{
		CreateMap<CreateTransactionDto, Transaction>().ReverseMap();
		CreateMap<UpdateTransactionDto, Transaction>().ReverseMap();
		CreateMap<ReadTransactionDto, Transaction>().ReverseMap();
	}
}
