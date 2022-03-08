using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Domain.Interfaces.Repositories;
using DataAccess.Interfaces;

namespace DataAccess.Repositories;

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

    public TModel? Get(Guid id)
    {
        var entity = _dbSet.Find(id);

        if (entity is null) return default;

        return _mapper.Map<TModel>(entity);
    }

    public IEnumerable<TModel> GetAll()
    {
        return _mapper.Map<IReadOnlyCollection<TModel>>(_dbSet);
    }

    public TModel New(TModel model)
    {
        var entity = _mapper.Map<TEntity>(model);

        _dbSet.Add(entity);
        _context.SaveChanges();

        return _mapper.Map<TModel>(entity);
    }

    public TModel Update(Guid id, TModel model)
    {
        var entity = _dbSet.FirstOrDefault(x => x.Id == id);

        if (entity is null)
            throw new InvalidOperationException($"'{nameof(id)}' - not found");

        _mapper.Map(model, entity);
        _context.SaveChanges();

        return _mapper.Map<TModel>(entity);
    }

    public bool Delete(Guid id)
    {
        var entity = _dbSet.Find(id);

        if (entity is null) return false;

        _context.Entry(entity).State = EntityState.Deleted;
        _context.SaveChanges();

        return true;
    }
}