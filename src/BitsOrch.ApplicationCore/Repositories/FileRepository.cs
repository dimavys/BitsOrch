using BitsOrch.ApplicationCore.Interfaces;
using BitsOrch.Infrastructure.Context;
using BitsOrch.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace BitsOrch.ApplicationCore.Repositories;

public class FileRepository : IFileRepository
{
    private readonly AppDbContext _dbContext;

    public FileRepository(AppDbContext dbContext) => _dbContext = dbContext;

    // public async Task<List<FieldEntity>> GetFileAsync(string id, CancellationToken token)
    // {
    //     return await _dbContext.Fields.Where(f => f.Id == id).ToListAsync(token);
    // }

    public async void AddRecordAsync(FieldEntity record, CancellationToken token)
    {
        await _dbContext.AddAsync(record, token);
        await _dbContext.SaveChangesAsync(token);
    }
}