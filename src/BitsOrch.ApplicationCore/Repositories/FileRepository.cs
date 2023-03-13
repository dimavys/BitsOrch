using BitsOrch.ApplicationCore.Interfaces;
using BitsOrch.Infrastructure.Context;
using BitsOrch.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace BitsOrch.ApplicationCore.Repositories;

public class FileRepository : IFileRepository
{
    private readonly AppDbContext _dbContext;

    public FileRepository(AppDbContext dbContext) => _dbContext = dbContext;

    public async Task<List<FieldEntity>> GetRecordsAsync(CancellationToken token)
    {
       var recordList = await _dbContext.Fields.ToListAsync(token);
       return recordList;
    }

    public async Task<FieldEntity> AddRecordAsync(FieldEntity record, CancellationToken token)
    {
         await _dbContext.Fields.AddAsync(record, token);
         await _dbContext.SaveChangesAsync(token);
         return record;
    }

    public async Task<FieldEntity> FetchRecordByIdAsync(string id, CancellationToken token)
    {
        var record = await _dbContext.Fields.Where(f => f.Id == id).FirstOrDefaultAsync(token);
        return record;
    }
    
    public async Task<FieldEntity> DeleteRecordAsync(FieldEntity record, CancellationToken token)
    {
        _dbContext.Fields.Remove(record);
        await _dbContext.SaveChangesAsync(token);
        return record;
    }
}