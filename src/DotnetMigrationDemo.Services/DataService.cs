using DotnetMigrationDemo.Core.Models;
using DotnetMigrationDemo.Core.Services;
namespace DotnetMigrationDemo.Services;
public class DataService : IDataService {
    public async Task<DataItem> ProcessAsync(DataItem item, CancellationToken cancellationToken) {
        item.Status = DataStatus.Processing;
        await Task.Delay(50, cancellationToken);
        item.Status = DataStatus.Completed;
        return item;
    }
    public async Task<IEnumerable<DataItem>> ProcessBatchAsync(IEnumerable<DataItem> items, CancellationToken cancellationToken) {
        var tasks = items.Select(item => ProcessAsync(item, cancellationToken));
        return await Task.WhenAll(tasks);
    }
}
