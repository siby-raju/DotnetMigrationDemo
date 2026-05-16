using DotnetMigrationDemo.Core.Models;
namespace DotnetMigrationDemo.Core.Services;
public interface IDataService {
    Task<DataItem> ProcessAsync(DataItem item, CancellationToken cancellationToken);
    Task<IEnumerable<DataItem>> ProcessBatchAsync(IEnumerable<DataItem> items, CancellationToken cancellationToken);
}
