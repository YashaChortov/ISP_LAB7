using ContestManager.Domain.Abstractions;
using ContestManager.Domain.Entities;

public interface IUnitOfWork
{
    IRepository<Contest> ContestRepository { get; }
    IRepository<Participant> ParticipantRepository { get; }
    Task SaveAllAsync();
    Task DeleteDatabaseAsync();
    Task CreateDatabaseAsync();
}