using BitsOrch.Infrastructure.Entities;

namespace BitsOrch.ApplicationCore.Interfaces;

public interface IFileRepository
{
    // public Task<List<FieldEntity>> GetFileAsync(string id, CancellationToken token);
    public void AddRecordAsync(FieldEntity record, CancellationToken token);
}