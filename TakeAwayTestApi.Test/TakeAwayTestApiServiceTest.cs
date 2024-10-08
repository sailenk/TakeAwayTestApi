using Moq;
using TakeAwayTestApi.Presistance.Models;
using TakeAwayTestApi.Service;

namespace TakeAwayTestApi.Test;

[TestFixture]
public class Tests
{
    private Mock<ITakeAwayTestRepository> _mockRepository;
    private TakeAwayTestSerivce _service;

    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<ITakeAwayTestRepository>();
        _service = new TakeAwayTestSerivce(_mockRepository.Object);
    }

    [Test]
    public async Task GetUserAsync_ReturnUser()
    {
        //Arrange
        _mockRepository.Setup(r => r.GetUserAsync(1)).ReturnsAsync(new User { Id = 1, FirstName = "Test", LastName = "Test", Email = "test@test.com" });

        // Act
        var result = await _service.GetUserAsync(1);

        //Asset
        Assert.That(result?.Id, Is.EqualTo(1));

        //verify
        _mockRepository.Verify(r => r.GetUserAsync(1), Times.Once);
    }

    [Test]
    public async Task GetUserAsync_ReturnUserNoResult()
    {
        //Arrange
        _mockRepository.Setup(r => r.GetUserAsync(5)).ReturnsAsync(new User());

        // Act
        var result = await _service.GetUserAsync(5);

        //Asset
        Assert.That(result?.Id, Is.EqualTo(0));

        //verify
        _mockRepository.Verify(r => r.GetUserAsync(5), Times.Once);
    }

    [Test]
    public async Task GetSavedListingAsync_ReturnSavedListings()
    {
        //Arrange
        _mockRepository.Setup(r => r.GetSavedListingAsync(1, 1, 10)).ReturnsAsync(new List<SavedListing>() { new SavedListing { Id = 1, ListingId = 1, UserId = 1, IsShortListed = true } });

        // Act
        var result = await _service.GetSavedListingAsync(1, 1, 10);

        //Asset
        Assert.That(result?.Count, Is.EqualTo(1));

        //verify
        _mockRepository.Verify(r => r.GetSavedListingAsync(1, 1, 10), Times.Once);
    }

    [Test]
    public async Task GetSavedListingAsync_ReturnNoResult()
    {
        //Arrange
        _mockRepository.Setup(r => r.GetSavedListingAsync(5, 1, 10)).ReturnsAsync(new List<SavedListing>());

        // Act
        var result = await _service.GetSavedListingAsync(5, 1, 10);

        //Asset
        Assert.That(result, Is.Null);

        //verify
        _mockRepository.Verify(r => r.GetSavedListingAsync(5, 1, 10), Times.Once);
    }
}