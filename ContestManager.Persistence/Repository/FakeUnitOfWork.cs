using ContestManager.Domain.Abstractions;
using ContestManager.Domain.Entities;
using System.Collections.Concurrent;

namespace ContestManager.Persistence.Repository
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly ConcurrentDictionary<Type, object> _repositories = new();

        public IRepository<Contest> ContestRepository =>
            GetRepository<Contest>();

        public IRepository<Participant> ParticipantRepository =>
            GetRepository<Participant>();

        private IRepository<T> GetRepository<T>() where T : Entity
        {
            return (IRepository<T>)_repositories.GetOrAdd(typeof(T),
                new FakeRepository<T>());
        }

        public Task SaveAllAsync()
        {
            // Фейковая реализация - просто возвращаем завершенную задачу
            return Task.CompletedTask;
        }

        public Task DeleteDatabaseAsync()
        {
            // Фейковая реализация - очищаем "репозитории"
            _repositories.Clear();
            return Task.CompletedTask;
        }

        public Task CreateDatabaseAsync()
        {
            // Фейковая реализация - ничего не делаем
            return Task.CompletedTask;
        }
    }
}