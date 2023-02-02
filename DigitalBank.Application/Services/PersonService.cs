using AutoMapper;
using DigitalBank.Application.Contracts.Services;
using DigitalBank.Application.DTOs;
using DigitalBank.Application.DTOs.Person;
using DigitalBank.Application.DTOs.Validations;
using DigitalBank.Domain.Contracts.Repositories;
using DigitalBank.Domain.Entities;
using DigitalBank.Domain.FiltersDb;

namespace DigitalBank.Application.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public PersonService(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<ReadPersonDto>> CreateAsync(CreatePersonDto personDto)
    {
        if (personDto == null)
            return ResultService.Fail<ReadPersonDto>("O objeto da pessoa deve ser informado", 400);
        
        var result = new CreatePersonDtoValidator().Validate(personDto);
        if (!result.IsValid)
            return ResultService.RequestError<ReadPersonDto>("Problemas na validação", 400, result);

        var person = _mapper.Map<Person>(personDto);
        var data = await _personRepository.CreateAsync(person);
        return ResultService.Ok(_mapper.Map<ReadPersonDto>(data), 201);
    }

    public async Task<ResultService> DeleteAsync(int id)
    {
        var person = await _personRepository.GetByIdAsync(id);
        if (person == null)
            return ResultService.Fail("Pessoa não encontrada", 404);
 
        await _personRepository.DeleteAsync(person);
        return ResultService.Ok("Pessoa removida com sucesso", 204);
    }

    public async Task<ResultService<ICollection<ReadPersonDto>>> GetAllAsync()
    {
        var people = await _personRepository.GetAllAsync();
        var data = _mapper.Map<ICollection<ReadPersonDto>>(people);
        return ResultService.Ok(data, 200);
    }

    public async Task<ResultService<ReadPersonDto>> GetByIdAsync(int id)
    {
        var person = await _personRepository.GetByIdAsync(id);
        if (person == null)
            return ResultService.Fail<ReadPersonDto>("Pessoa não encontrada", 404);
        
        var data = _mapper.Map<ReadPersonDto>(person);
        return ResultService.Ok(data, 200);
    }

    public async Task<ResultService<PagedBaseResponseDto<ReadPersonDto>>> GetPagedAsync(PersonFilterDb personFilterDb)
    {
        var peoplePaged = await _personRepository.GetPagedAsync(personFilterDb);
        var result = new PagedBaseResponseDto<ReadPersonDto>(peoplePaged.TotalRegisters,
                                                            _mapper.Map<List<ReadPersonDto>>(peoplePaged.Data));
        return ResultService.Ok(result, 200);
    }

    public async Task<ResultService> UpdateAsync(int id, UpdatePersonDto personDto)
    {
        if (personDto == null)
            return ResultService.Fail("O objeto da pessoa deve ser informado", 400);

        var result = new UpdatePersonDtoValidator().Validate(personDto);
        if (!result.IsValid)
            return ResultService.RequestError("Problemas na validação", 400, result);

        var person = await _personRepository.GetByIdAsync(id);
        if(person == null)
            return ResultService.Fail<ReadPersonDto>("Pessoa não encontrada", 404);

        person = _mapper.Map(personDto, person);
        await _personRepository.UpdateAsync(person);
        return ResultService.Ok("Pessoa atualizada com sucesso", 204);
    }
}
