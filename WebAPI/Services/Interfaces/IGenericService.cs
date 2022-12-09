using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IGenericService<T> where T : class, IBaseModel
    {
        Task<int> CreateAsync<TSource>(TSource dto);
        Task<TResult> GetByIdAsync<TResult>(int id);
        Task<List<TResult>> GetAllAsync<TResult>() where TResult : class;
        Task UpdateByIdAsync<TSource>(int id, TSource dto);
        Task DeleteByIdAsync(int id);
    }
}
