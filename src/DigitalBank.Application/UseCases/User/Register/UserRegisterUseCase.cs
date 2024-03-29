﻿using AutoMapper;
using DigitalBank.Application.Services.Cryptography;
using DigitalBank.Application.Services.Token;
using DigitalBank.Communication.Requests;
using DigitalBank.Communication.Responses;
using DigitalBank.Domain.Repositories;
using DigitalBank.Domain.Repositories.User;
using DigitalBank.Exceptions;
using DigitalBank.Exceptions.ExceptionsBase;

namespace DigitalBank.Application.UseCases.User.Register;

public class UserRegisterUseCase : IUserRegisterUseCase
{
    private readonly IUserWriteOnlyRepository _userWriteRepository;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly PasswordEncrypter _passwordEncrypter;
    private readonly TokenController _tokenController;

    public UserRegisterUseCase(IUserWriteOnlyRepository userWriteRepository, IMapper mapper, IUnitOfWork unitOfWork, PasswordEncrypter passwordEncrypter, IUserReadOnlyRepository userReadOnlyRepository, TokenController tokenController)
    {
        _userWriteRepository = userWriteRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _passwordEncrypter = passwordEncrypter;
        _userReadOnlyRepository = userReadOnlyRepository;
        _tokenController = tokenController;
    }

    public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
    {
        await Validate(request);

        var user = _mapper.Map<Domain.Entities.User>(request);
        user.Password = _passwordEncrypter.Encrypt(request.Password);

        await _userWriteRepository.Add(user);

        await _unitOfWork.Commit();

        var token = _tokenController.GenerateToken(user.Email);

        return new ResponseRegisterUserJson
        {
            Token = token,
        };
    }

    private async Task Validate(RequestRegisterUserJson request)
    {
        var validator = new UserRegisterValidator();
        var result = validator.Validate(request);

        var userExistsWithEmail = await _userReadOnlyRepository.UserExistsWithEmail(request.Email);
        if (userExistsWithEmail)
        {
            result.Errors.Add(new FluentValidation.Results.ValidationFailure("email", ResourceErrorMessages.EMAIL_JA_CADASTRADO));
        }

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ValidationsErrorException(errorMessages);
        }
    }
}
