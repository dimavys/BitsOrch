using BitsOrch.ApplicationCore.Interfaces;
using BitsOrch.ApplicationCore.Mapping;
using BitsOrch.Infrastructure;
using BitsOrch.Infrastructure.Entities;
using CsvHelper;

namespace BitsOrch.ApplicationCore.Services;

public class FileService : IFileService
{
    private readonly IFileRepository _fileRepository;
    public FileService(IFileRepository fileRepository) => _fileRepository = fileRepository;

    public async Task<FieldDTO> InsertFileAsync(Stream fileStream, CancellationToken token)
    {
        using var streamReader = new StreamReader(fileStream);
        using var csvReader = new CsvReader(streamReader, System.Globalization.CultureInfo.InvariantCulture);
        csvReader.Context.RegisterClassMap<FieldMapper>();
        await csvReader.ReadAsync();
        csvReader.ReadHeader();
        while (await csvReader.ReadAsync())
        {
            var @record =  csvReader.GetRecord<FieldEntity>();
            @record.Id = Guid.NewGuid().ToString();
            
            await _fileRepository.AddRecordAsync(@record, token);
        }

        return new FieldDTO();
    }

    public async Task<List<FieldDTO>> GetRowsAsync(CancellationToken token)
    {
        var rows = await _fileRepository.GetRecordsAsync(token);
        var result = new List<FieldDTO>();
        foreach (var row in rows)
            result.Add(new FieldDTO
            {
                Id = row.Id,
                Name = row.Name,
                BirthDate = row.BirthDate,
                MobilePhone = row.MobilePhone,
                Married = row.Married,
                Salary = row.Salary
            });
        return result;
    }

    public async Task<FieldDTO> DeleteRowAsync(string id, CancellationToken token)
    {
        var row = await _fileRepository.FetchRecordByIdAsync(id, token);
        var result = await _fileRepository.DeleteRecordAsync(row, token);
        return new FieldDTO
        {
            Id = result.Id,
            Name = result.Name,
            BirthDate = result.BirthDate,
            MobilePhone = result.MobilePhone,
            Married = result.Married,
            Salary = result.Salary
        };
    }
}