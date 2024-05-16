using Mint.Application.Interfaces;
using Mint.WebApp.Admin.Application.Operations.Commands.Categories;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Microsoft.Extensions.Logging.Testing;
using Microsoft.Extensions.Logging;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;
using Mint.Domain.Models.Admin.Categories;

namespace Mint.WebApp.Admin.Tests.Admin.Application.Operations.Commands.Categories;

public class CreateCategoryCommandTests
{
    private readonly FakeLogger<CreateCategoryCommandHandler> _fakeLogger = new();

    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    private readonly CreateCategoryCommandHandler _handler;

    public CreateCategoryCommandTests()
    {
        var fixture = new Fixture().WithAutoNSubstitutions();
        fixture.Register<ILogger<CreateCategoryCommandHandler>>(() => _fakeLogger);

        _categoryRepository = fixture.Freeze<ICategoryRepository>();
        _unitOfWork = fixture.Freeze<IUnitOfWork>();

        _handler = fixture.Create<CreateCategoryCommandHandler>();
    }

    [Fact]
    public async Task InvalidCategoryInfoModel_ShouldThrow()
    {
        // Arrange
        var model = new CategoryInfoBindingModel
        {
            Name = string.Empty,
        };
        var command = new CreateCategoryCommand(model);

        // Act
        var action = () => _handler.Handle(command, default);

        // Assert
        await action.Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task CreateValidCategory()
    {
        // Arrange
        var fixture = new Fixture();
        var request = new CategoryInfoBindingModel
        {
            Name = fixture.Create<string>(),
            DisplayOrder = fixture.Create<int>(),
            BadgeStyle = fixture.Create<string>(),
            BadgeText = "test",
            Description = fixture.Create<string>(),
            DefaultLink = fixture.Create<string>(),
            Ico = fixture.Create<string>(),
            IsPublished = fixture.Create<bool>(),
            ShowOnHomePage = fixture.Create<bool>(),
        };
        var command = new CreateCategoryCommand(request);

        Category category = default!;
        _categoryRepository
            .When(x => x.AddAsync(Arg.Any<Category>()))
            .Do(x => category = x.Arg<Category>());

        // Act
        await _handler.Handle(command, default);

        // Assert
        _ = _categoryRepository
            .Received()
            .AddAsync(category);

        _ = _unitOfWork
            .Received()
            .SaveChangesAsync();

        using (new AssertionScope())
        {
            category.Name.Should().Be(request.Name);
            category.DisplayOrder.Should().Be(request.DisplayOrder);
            category.BadgeText.Should().Be(request.BadgeText);
            category.BadgeStyle.Should().Be(request.BadgeStyle);
            category.DefaultLink.Should().Be(request.DefaultLink);
            category.Description.Should().Be(request.Description);
            category.Ico.Should().Be(request.Ico);
            category.IsPublished.Should().Be(request.IsPublished);
            category.ShowOnHomePage.Should().Be(request.ShowOnHomePage);

            _fakeLogger.LatestRecord.Level.Should().Be(LogLevel.Information);
            _fakeLogger.LatestRecord.Message.Should().Contain(category.Id.ToString());
        }
    }
}
