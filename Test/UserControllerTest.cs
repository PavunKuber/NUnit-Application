
// using NUnit.Framework;
// using Moq;
// using Microsoft.AspNetCore.Mvc;
// using ProductAPIVS.Controllers;
// using ProductAPIVS.Models;
// using Microsoft.Extensions.Options;
// using System.Threading.Tasks;
// using System.Collections.Generic;
// using Microsoft.IdentityModel.Tokens;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using ProductAPIVS.Handler;
// using Microsoft.EntityFrameworkCore;
// using System.Linq.Expressions;
 
// namespace ProductAPIVS.Tests
// {
//     [TestFixture]
//     public class UserControllerTests : ControllerBase
//     {
//         private UserController _userController;
//         private Mock<Learn_DBContext> _dbContextMock;
//         private Mock<IOptions<JwtSettings>> _optionsMock;
//         private Mock<IRefereshTokenGenerator> _refreshTokenGeneratorMock;
 
//         [SetUp]
//         public void Setup()
//         {
//             // Mock dependencies using Moq
//             _dbContextMock = new Mock<Learn_DBContext>();
//             _optionsMock = new Mock<IOptions<JwtSettings>>();
//             _refreshTokenGeneratorMock = new Mock<IRefereshTokenGenerator>();
 
//             // Setup any specific behavior for mocks if needed
//             _optionsMock.Setup(x => x.Value).Returns(new JwtSettings { securitykey = "A_Strong_Secret_Key_With_At_Least_32_Bytes" });
 
//             // Create the UserController instance with mocked dependencies
//             _userController = new UserController(_dbContextMock.Object, _optionsMock.Object, _refreshTokenGeneratorMock.Object);
//         }
 
//         [Test]
// public async Task Authenticate_ValidUser_ReturnsOk()
// {
//     // Arrange
//     var userCred = new UserCred { username = "buchy", password = "buchy" };
//     var user = new TblUser { Userid = userCred.username, Password = userCred.password, Role = "admin" };
 
//     // Setup the TblUsers using FindAsync
//     _dbContextMock.Setup(x => x.TblUsers.FindAsync(It.IsAny<object[]>()))
//                   .ReturnsAsync(new object[] { user });
 
//     // Mock the token generation
//     _refreshTokenGeneratorMock.Setup(x => x.GenerateToken(It.IsAny<string>())).ReturnsAsync("fake_refresh_token");
 
//     // Act
//     var result = await _userController.Authenticate(userCred) as ObjectResult;
 
//     // Assert
//     Assert.NotNull(result);
//     Assert.AreEqual(200, result.StatusCode);
 
//     // Add more assertions as needed
// }
 
        // [Test]
        // public async Task RefToken_ValidToken_ReturnsOk()
        // {
        //     // Arrange
        //     var userController = new UserController(_dbContext, Options.Create(_jwtSettings), _refreshTokenGenerator);
        //     var tokenResponse = new TokenResponse { jwttoken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImJ1Y2h5Iiwicm9sZSI6ImFkbWluIiwibmJmIjoxNzA2Njc2OTE4LCJleHAiOjE3MDY2NzgxMTgsImlhdCI6MTcwNjY3NjkxOH0.KKuNJPfWpTAV0vVXCjg6d5XVzsKypP5D5ZaY4wXoeEw", refereshtoken = "tGd38RbsAXEQqM1EvKDfMyfCsxliDri/fhlrWN7pNbs=" };
 
        //     // Act
        //     var result = await userController.RefToken(tokenResponse) as OkObjectResult;
 
        //     // Assert
        //     Assert.IsNotNull(result);
        //     Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
        // }
 
        // [Test]
        // public async Task RefToken_InvalidToken_ReturnsUnauthorized()
        // {
        //     // Arrange
        //     var userController = new UserController(_dbContext, Options.Create(_jwtSettings), _refreshTokenGenerator);
        //     var tokenResponse = new TokenResponse { jwttoken = "invalid_jwt_token", refereshtoken = "invalid_refresh_token" };
 
        //     // Act
        //     var result = await userController.RefToken(tokenResponse) as UnauthorizedResult;
 
        //     // Assert
        //     Assert.IsNotNull(result);
        //     Assert.AreEqual(StatusCodes.Status401Unauthorized, result.StatusCode);
        // }
//     }
// }
 
 
using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Options;
using ProductAPIVS.Controllers;
using ProductAPIVS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProductAPIVS.Handler;
 
namespace ProductAPIVS.Tests
{
    [TestFixture]
    public class UserControllerTests
    {
        private Learn_DBContext _dbContext;
        private JwtSettings _jwtSettings;
        private IRefereshTokenGenerator _refreshTokenGenerator;
 
        [SetUp]
        public void Setup()
        {
            // Mocking dependencies
            var dbContextOptions = new DbContextOptionsBuilder<Learn_DBContext>().UseInMemoryDatabase(databaseName: "InMemoryDatabase").Options;
            _dbContext = new Learn_DBContext(dbContextOptions);
 
            _jwtSettings = new JwtSettings
            {
                securitykey = "A_Strong_Secret_Key_With_At_Least_32_Bytes"
            };
 
            var refreshTokenGeneratorMock = new Mock<IRefereshTokenGenerator>();
            refreshTokenGeneratorMock.Setup(x => x.GenerateToken(It.IsAny<string>())).ReturnsAsync("mocked_refresh_token");
 
            _refreshTokenGenerator = refreshTokenGeneratorMock.Object;
        }
 
//         [Test]
// public async Task Authenticate_ValidCredentials_ReturnsOk()
// {
//     // Arrange
//     var userController = new UserController(_dbContext, Options.Create(_jwtSettings), _refreshTokenGenerator);
//     var userCred = new UserCred { username = "sssssssssssssbuchy", password = "buchsssssssssssssssssyma" };
 
//     // Setup the in-memory database with a user that matches the credentials
//     _dbContext.TblUsers.Add(new TblUser { Userid = userCred.username, Password = userCred.password, Role = "admin" });
//     await _dbContext.SaveChangesAsync();
 
//     // Act
//     var result = await userController.Authenticate(userCred) as OkObjectResult;
 
//     // Assert
//     // Assert.IsNotNull(result, "Result is expected to be not null");
//     // Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode, "Expected HTTP 200 OK status");
//        Assert.NotNull(result);
//        Assert.AreEqual(200, result.StatusCode);
//     // Add more assertions as needed based on the expected response content
//     // For example, you might want to check the content of the result object.
// }
[Test]
public async Task Authenticate_ValidCredentials_ReturnsOk()
{
    // Arrange
    var userController = new UserController(_dbContext, Options.Create(_jwtSettings), _refreshTokenGenerator);
 
    // Use incorrect credentials intentionally
    var validUserCred = new UserCred { username = "Kavitha", password = "Kavi@123" };
 
    // Setup the in-memory database with a valid user
    _dbContext.TblUsers.Add(new TblUser { Userid = "Kavitha", Password = "Kavi@123", Role = "admin" });
    await _dbContext.SaveChangesAsync();
 
    // Act
    var resultValid = await userController.Authenticate(validUserCred) as OkObjectResult;
 
    // Assert
    Assert.NotNull(resultValid);
    Assert.AreEqual(200, resultValid.StatusCode);
}
 
[Test]
public async Task Authenticate_InvalidCredentials_ReturnsUnauthorized()
{
    // Arrange
    var userController = new UserController(_dbContext, Options.Create(_jwtSettings), _refreshTokenGenerator);
    var invalidUserCred = new UserCred { username = "invalid_username", password = "invalid_password" };
 
    // Act
    var resultInvalid = await userController.Authenticate(invalidUserCred) as UnauthorizedResult;
 
    // Assert
    Assert.NotNull(resultInvalid);
    Assert.AreEqual(StatusCodes.Status401Unauthorized, resultInvalid.StatusCode);
}
 
    }
}
 