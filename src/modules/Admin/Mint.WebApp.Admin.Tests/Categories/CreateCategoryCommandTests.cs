using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Testing;
using Mint.Domain.Models.Admin.Categories;
using Mint.Infrastructure.Repositories.Admin.Interfaces;
using Mint.WebApp.Admin.Operations.Commands.Categories;
using Mint.WebApp.Admin.Tests.Utils;
using NSubstitute;

namespace Mint.WebApp.Admin.Tests.Categories;

public class CreateCategoryCommandTests
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly FakeLogger<CreateCategoryCommandHandler> _fakeLogger;

    private readonly CreateCategoryCommandHandler _handler;

    public CreateCategoryCommandTests()
    {
        var fixture = new Fixture().WithAutoNSubstitutions();

        _fakeLogger = new FakeLogger<CreateCategoryCommandHandler>();
        fixture.Register<ILogger<CreateCategoryCommandHandler>>(() => _fakeLogger);

        _categoryRepository = fixture.Freeze<ICategoryRepository>();

        _handler = fixture.Freeze<CreateCategoryCommandHandler>();
    }

    [Fact]
    public async Task Create_ShouldBeSucceed()
    {
        // Arrange
        var fixture = new Fixture();
        var command = fixture.Create<CreateCategoryCommand>();

        Category category = default!;
        _categoryRepository
            .Context
            .When(x => x.AddAsync(Arg.Any<Category>()))
            .Do(x => category = x.Arg<Category>());

        // Act
        await _handler.Handle(command, default);

        // Assert
        _ = _categoryRepository
            .Received()
            .Context
            .AddAsync(category);

        _ = _categoryRepository
            .Received()
            .Context
            .SaveChangesAsync();

        category.Id.Should().Be(command.Category.Id);
        category.Name.Should().Be(command.Category.Name);
        category.DisplayOrder.Should().Be(command.Category.DisplayOrder);
        category.BadgeText.Should().Be(command.Category.BadgeText);
        category.BadgeStyle.Should().Be(command.Category.BadgeStyle);
        category.DefaultLink.Should().Be(command.Category.DefaultLink);
        category.Description.Should().Be(command.Category.Description);
        category.Ico.Should().Be(command.Category.Ico);
        category.IsPublished.Should().Be(command.Category.IsPublished);
        category.ShowOnHomePage.Should().Be(command.Category.ShowOnHomePage);

        _fakeLogger.LatestRecord.Level.Should().Be(LogLevel.Information);
        _fakeLogger.LatestRecord.Message.Should().Contain(category.Id.ToString());
    }
}
