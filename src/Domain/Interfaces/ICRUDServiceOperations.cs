namespace Domain.Interfaces;

public interface ICRUDServiceOperations<TModel>
{
    Task<TModel> NewAsync(TModel model);
    Task<TModel?> GetAsync(Guid id);
    Task<IReadOnlyCollection<TModel>> GetAllAsync();
    Task<TModel> UpdateAsync(Guid id, TModel model);
    Task<bool> DeleteAsync(Guid id);
}