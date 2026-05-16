using DotnetMigrationDemo.Core.Models;
using DotnetMigrationDemo.Services;
namespace DotnetMigrationDemo.Tests;
public class DataServiceTests {
    private readonly DataService _dataService;
    public DataServiceTests() { _dataService = new DataService(); }
    [Fact]
    public async Task ProcessAsync_ShouldCompleteItem() {
        var item = new DataItem { Name = "Test", Value = "Value" };
        var result = await _dataService.ProcessAsync(item, CancellationToken.None);
        Assert.Equal(DataStatus.Completed, result.Status);
    }
    [Fact]
    public async Task ProcessBatchAsync_ShouldCompleteAllItems() {
        var items = new[] { new DataItem { Name = "1" }, new DataItem { Name = "2" }, new DataItem { Name = "3" } };
        var results = await _dataService.ProcessBatchAsync(items, CancellationToken.None);
        Assert.Equal(3, results.Count());
        Assert.All(results, r => Assert.Equal(DataStatus.Completed, r.Status));
    }
    [Fact]
    public void DataItem_ShouldInitializeWithDefaults()
    {
    var item = new DataItem();
    Assert.Equal(DataStatus.Pending, item.Status);
    }
}
