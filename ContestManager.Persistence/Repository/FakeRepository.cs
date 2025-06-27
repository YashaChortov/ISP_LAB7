using ContestManager.Domain.Abstractions;
using ContestManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ContestManager.Persistence.Repository
{
    public class FakeRepository<T> : IRepository<T> where T : Entity
    {
        private readonly List<T> _data = new();

        public Task<T?> GetByIdAsync(int id,
            CancellationToken cancellationToken = default,
            params Expression<Func<T, object>>[]? includesProperties)
        {
            // В фейковой реализации игнорируем includesProperties
            return Task.FromResult(_data.FirstOrDefault(e => e.Id == id));
        }

        public Task<IReadOnlyList<T>> ListAllAsync(
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult((IReadOnlyList<T>)_data.AsReadOnly());
        }

        public Task<IReadOnlyList<T>> ListAsync(
            Expression<Func<T, bool>> filter,
            CancellationToken cancellationToken = default,
            params Expression<Func<T, object>>[]? includesProperties)
        {
            // В фейковой реализации игнорируем includesProperties
            var query = _data.AsQueryable().Where(filter);
            return Task.FromResult((IReadOnlyList<T>)query.ToList());
        }

        public Task AddAsync(T entity,
            CancellationToken cancellationToken = default)
        {
            _data.Add(entity);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(T entity,
            CancellationToken cancellationToken = default)
        {
            var index = _data.FindIndex(e => e.Id == entity.Id);
            if (index >= 0)
            {
                _data[index] = entity;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity,
            CancellationToken cancellationToken = default)
        {
            _data.RemoveAll(e => e.Id == entity.Id);
            return Task.CompletedTask;
        }

        public Task<T?> FirstOrDefaultAsync(
            Expression<Func<T, bool>> filter,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_data.AsQueryable().FirstOrDefault(filter));
        }
    }
}