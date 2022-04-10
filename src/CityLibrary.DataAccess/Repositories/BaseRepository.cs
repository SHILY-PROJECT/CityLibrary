using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CityLibrary.Domain.Interfaces.Repositories;
using CityLibrary.DataAccess.Interfaces;

namespace CityLibrary.DataAccess.Repositories;

public abstract class BaseRepository<TModel, TEntity> : IRepository<TModel> where TEntity : class, IGuidProperty
{
    private readonly CityLibraryDbContext _context;
    private readonly DbSet<TEntity> _dbSet;
    private readonly IMapper _mapper;

    public BaseRepository(CityLibraryDbContext context, DbSet<TEntity> dbSet, IMapper mapper)
    {
        _context = context;
        _dbSet = dbSet;
        _mapper = mapper;
    }

    public virtual async Task<TModel?> GetAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity is null) return default;

        return _mapper.Map<TModel>(entity);
    }

    public virtual async Task<IEnumerable<TModel>> GetAllAsync()
    {
        var entities = await _dbSet.ToArrayAsync();
        return _mapper.Map<IEnumerable<TModel>>(entities);
    }

    public virtual async Task<TModel> NewAsync(TModel model)
    {
        var entity = _mapper.Map<TEntity>(model);

        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<TModel>(entity);
    }

    public virtual async Task<TModel> UpdateAsync(Guid id, TModel model)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        if (entity is null)
            throw new InvalidOperationException($"'{nameof(id)}' - not found");

        _mapper.Map(model, entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<TModel>(entity);
    }

    public virtual async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity is null) return false;

        _context.Entry(entity).State = EntityState.Deleted;
        await _context.SaveChangesAsync();

        return true;
    }
}