namespace DotnetMigrationDemo.Core.Models;
public class DataItem {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public DataStatus Status { get; set; } = DataStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
public enum DataStatus { Pending, Processing, Completed, Failed }
