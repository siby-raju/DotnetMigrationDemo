using Microsoft.AspNetCore.Mvc;
using DotnetMigrationDemo.Core.Models;
using DotnetMigrationDemo.Core.Services;
namespace DotnetMigrationDemo.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DataController : ControllerBase {
    private readonly IDataService _dataService;
    public DataController(IDataService dataService) { _dataService = dataService; }
    [HttpPost]
    public async Task<ActionResult<DataItem>> Process([FromBody] DataItem item) {
        var result = await _dataService.ProcessAsync(item, CancellationToken.None);
        return Ok(result);
    }
    [HttpPost("batch")]
    public async Task<ActionResult<IEnumerable<DataItem>>> ProcessBatch([FromBody] IEnumerable<DataItem> items) {
        var result = await _dataService.ProcessBatchAsync(items, CancellationToken.None);
        return Ok(result);
    }
}
