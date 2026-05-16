using DotnetMigrationDemo.Core.Models;
using DotnetMigrationDemo.Services;

namespace DotnetMigrationDemo.Tests;

public class DataServiceTests
{
    private readonly DataService _dataService;

    public DataServiceTests()
    {
        _dataService = new DataService();
    }

    [Fact]
    public async Task ProcessAsync_ShouldCompleteItem()
    {
        // Arrange
        var item = new DataItem { Name = "Test Item", Value = "Test Value" };

        // Act
        var result = await _dataService.ProcessAsync(item, CancellationToken.None);

        // Assert
        Assert.Equal(DataStatus.Completed, result.Status);
        Assert.Equal("Test Item", result.Name);
    }

    [Fact]
    public async Task ProcessBatchAsync_ShouldCompleteAllItems()
    {
        // Arrange
        var items = new[]
        {
            new DataItem { Name = "Item 1", Value = "Value 1" },
            new DataItem { Name = "Item 2", Value = "Value 2" },
            new DataItem { Name = "Item 3", Value = "Value 3" }
        };

        // Act
        var results = await _dataService.ProcessBatchAsync(items, CancellationToken.None);

        // Assert
        var resultArray = results.ToArray();
        Assert.Equal(3, resultArray.Length);
        Assert.All(resultArray, r => Assert.Equal(DataStatus.Completed, r.Status));
    }

    [Fact]
    public void DataItem_ShouldInitializeWithDefaults()
    {
        // Arrange & Act
        var item = new DataItem();

        // Assert
        Assert.Equal(DataStatus.Pending, item.Status);
        Assert.NotNull(item.Id);
        Assert.Equal(DateTime.UtcNow.Date, item.CreatedAt.Date);
    }
}