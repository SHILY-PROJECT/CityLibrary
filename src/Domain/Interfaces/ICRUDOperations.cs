namespace Domain.Interfaces;

public interface ICRUDOperations<TModel>
{
    TModel New(TModel model);
    TModel? Get(Guid id);
    IReadOnlyCollection<TModel> GetAll();
    TModel Update(Guid id, TModel model);
    bool Delete(Guid id);
}