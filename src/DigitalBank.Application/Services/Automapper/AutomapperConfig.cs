using AutoMapper;
using DigitalBank.Communication.Requests;
using DigitalBank.Domain.Entities;

namespace DigitalBank.Application.Services.Automapper;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<RequestRegisterUserJson, User>()
            .ForMember(dest => dest.Password, config => config.Ignore());
    }
}
