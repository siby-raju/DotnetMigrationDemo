using DotnetMigrationDemo.Core.Models;
using DotnetMigrationDemo.Core.Services;

namespace DotnetMigrationDemo.Services;

public class DataService : IDataService
{
    public async Task<DataItem> ProcessAsync(DataItem item, CancellationToken cancellationToken)
    {
        // Mark as processing
        item.Status = DataStatus.Processing;
        
        // Simulate processing (50ms)
        await Task.Delay(50, cancellationToken);
        
        // Mark as completed
        item.Status = DataStatus.Completed;
        
        return item;
    }

    public async Task<IEnumerable<DataItem>> ProcessBatchAsync(IEnumerable<DataItem> items, CancellationToken cancellationToken)
    {
        // Process all items in parallel
        var tasks = items.Select(item => ProcessAsync(item, cancellationToken));
        return await Task.WhenAll(tasks);
    }
}