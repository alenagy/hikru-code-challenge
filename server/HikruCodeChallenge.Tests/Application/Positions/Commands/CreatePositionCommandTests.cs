using FluentAssertions;
using HikruCodeChallenge.Application.Interfaces;
using HikruCodeChallenge.Application.Positions.Commands;
using Microsoft.Extensions.Logging;
using Moq;

namespace HikruCodeChallenge.Tests.Application.Positions.Commands
{
    public class CreatePositionCommandTests
    {
        private readonly Mock<IPositionRepository> _repositoryMock;
        private readonly Mock<ILogger<CreatePositionCommand.Handler>> _loggerMock;

        public CreatePositionCommandTests()
        {
            _repositoryMock = new Mock<IPositionRepository>();
            _loggerMock = new Mock<ILogger<CreatePositionCommand.Handler>>();
        }

        [Fact]
        public async Task Handle_ShouldCreatePositionAndReturnId()
        {
            // Arrange
            var handler = new CreatePositionCommand.Handler(_repositoryMock.Object, _loggerMock.Object);

            var command = new CreatePositionCommand
            {
                Title = "Software Engineer",
                Description = "Develop amazing applications.",
                Location = "Remote",
                Status = "Open",
                RecruiterId = Guid.NewGuid(),
                DepartmentId = Guid.NewGuid(),
                Budget = 100000,
                ClosingDate = DateTime.UtcNow.AddMonths(2)
            };

            _repositoryMock
                .Setup(repo => repo.CreateAsync(It.IsAny<Domain.Entities.Position>()))
                .ReturnsAsync(Guid.NewGuid());

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeEmpty();
            _repositoryMock.Verify(repo => repo.CreateAsync(It.IsAny<Domain.Entities.Position>()), Times.Once);
        }
    }
}
