using DigitalBank.Api.Controllers;
using DigitalBank.Application.Contracts.Services;
using DigitalBank.Application.DTOs.User;
using DigitalBank.Application.Services;
using DigitalBank.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DigitalBank.Tests.Unit;

public class UserControllerTest
{
    [Fact(DisplayName = "Sucesso no Login")]
    public async void Retorna_Token_Caso_Login_Tenha_Sucesso()
    {
        // Arrange 
        var userServiceMock = new Mock<IUserService>();
        userServiceMock.Setup(x => x.GenerateTokenAsync(It.IsAny<LoginUserDto>()))
            .ReturnsAsync(new ResultService<dynamic> {
                Success = true, Data = new TokenData { token = "token" }
            });

        var controller = new UserController(userServiceMock.Object);
        var loginUserDto = new LoginUserDto { Email = "saulo@gmail.com", Password = "password" };

        // Act
        var result = await controller.LoginAsync(loginUserDto);

        // Assert
        Assert.IsType<OkObjectResult>(result);

        var okResult = result as OkObjectResult;
        var value = okResult.Value as TokenData;

        Assert.NotNull(value);
        Assert.Equal("token", value.token);
    }
}
