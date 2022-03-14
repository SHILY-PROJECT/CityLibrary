namespace Domain.Interfaces.Repositories;

public interface IRepository<TModel>
{
    Task<TModel> NewAsync(TModel model);
    Task<TModel?> GetAsync(Guid id);
    Task<IEnumerable<TModel>> GetAllAsync();
    Task<TModel> UpdateAsync(Guid id, TModel model);
    Task<bool> DeleteAsync(Guid id);
}