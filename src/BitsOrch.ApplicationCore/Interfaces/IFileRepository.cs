using BitsOrch.Infrastructure.Entities;

namespace BitsOrch.ApplicationCore.Interfaces;

public interface IFileRepository
{
    public Task<FieldEntity> AddRecordAsync(FieldEntity record, CancellationToken token);

    public Task<List<FieldEntity>> GetRecordsAsync(CancellationToken token);
    
    public Task<FieldEntity> FetchRecordByIdAsync(string id, CancellationToken token);

    public Task<FieldEntity> DeleteRecordAsync(FieldEntity record, CancellationToken token);
}