namespace Domain.Interfaces.Repositories;

public interface IRepository<TModel>
{
    TModel New(TModel model);
    TModel? Get(Guid id);
    IEnumerable<TModel> GetAll();
    TModel Update(Guid id, TModel model);
    bool Delete(Guid id);
}