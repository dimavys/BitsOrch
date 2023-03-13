using BitsOrch.Infrastructure;

namespace BitsOrch.ApplicationCore.Interfaces;

public interface IFileService
{
    public Task<FieldDTO> InsertFileAsync(Stream fileStream, CancellationToken token);
    public Task<List<FieldDTO>> GetRowsAsync(CancellationToken token);

    public Task<FieldDTO> DeleteRowAsync(string id, CancellationToken token);
}