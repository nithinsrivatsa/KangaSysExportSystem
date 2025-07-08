// <copyright file="AuthControllerTests.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Tests.ControllerTests
{
    using KangaSys.API.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Moq;

    public class AuthControllerTests
    {
        private readonly Mock<IConfiguration> _mockConfig;
        private readonly AuthController _controller;

        public AuthControllerTests()
        {
            _mockConfig = new Mock<IConfiguration>();

            _mockConfig.Setup(c => c["JwtSettings:SecretKey"]).Returns("ThisIsASecretKeyForJwtTesting123!");
            _mockConfig.Setup(c => c["JwtSettings:Issuer"]).Returns("TestIssuer");
            _mockConfig.Setup(c => c["JwtSettings:Audience"]).Returns("TestAudience");

            _controller = new AuthController(_mockConfig.Object);
        }

        [Fact]
        public void Login_ShouldReturnToken_WhenCredentialsAreValid()
        {
            // Arrange
            var request = new AuthController.LoginRequest
            {
                Username = "admin",
                Password = "password123"
            };

            // Act
            var result = _controller.Login(request) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
            Assert.Contains("Token", result.Value.ToString());
        }

        [Fact]
        public void Login_ShouldReturnUnauthorized_WhenCredentialsAreInvalid()
        {
            // Arrange
            var request = new AuthController.LoginRequest
            {
                Username = "user",
                Password = "wrongpass"
            };

            // Act
            var result = _controller.Login(request) as UnauthorizedObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Invalid credentials", result.Value);
        }
    }

}
