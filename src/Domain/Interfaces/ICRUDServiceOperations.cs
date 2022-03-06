namespace Domain.Interfaces;

public interface ICRUDServiceOperations<TModel>
{
    TModel New(TModel model);
    TModel? Get(Guid id);
    IReadOnlyCollection<TModel> GetAll();
    TModel Update(Guid id, TModel model);
    bool Delete(Guid id);
}