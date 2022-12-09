using AutoMapper;
using WebAPI.Repository;
using WebAPI.Services;
using WebAPI.Models;
using System.Linq.Expressions;

namespace WebAPI.Services
{
    public class GenericService<T> : IGenericService<T> where T : class, IBaseModel
    {
        protected IGenericRepository<T> _repository;
        protected IMapper _mapper;

        public GenericService(IGenericRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync<TSource>(TSource dto)
        {
            var entity = _mapper.Map<T>(dto);
            try
            {
                await _repository.CreateAsync(entity);
                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"cant add {typeof(T).Name}!", ex);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync<T>(id);
            if (entity == null)
            {
                throw new Exception($"{typeof(T).Name} is not found");
            }
            await _repository.DeleteAsync(entity);
        }

        public async Task<List<TResult>> GetAllAsync<TResult>() where TResult : class
        {
            var allEntities = (await _repository.GetAllAsync()).ToList();
            var entityDtos = _mapper.Map<List<TResult>>(allEntities);
            return entityDtos;
        }

        public async Task<TResult> GetByIdAsync<TResult>(int id)
        {
            var entity = (await _repository.GetByConditionAsync(e => e.Id.Equals(id))).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception($"No {typeof(T).Name} with id = {id}");
            }

            var entityDto = _mapper.Map<TResult>(entity);
            return entityDto;
        }

        public async Task UpdateByIdAsync<TSource>(int id, TSource dto)
        {
            try
            {
                var entity = await GetByIdAsync<T>(id);
                entity = _mapper.Map(dto, entity);
                await _repository.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"cant update {typeof(T).Name}", ex);
            }
        }
    }
}
