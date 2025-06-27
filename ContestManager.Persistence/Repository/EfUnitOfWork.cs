using ContestManager.Domain.Abstractions;
using ContestManager.Domain.Entities;
using ContestManager.Persistence.Data;

namespace ContestManager.Persistence.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Contest>> _contestRepository;
        private readonly Lazy<IRepository<Participant>> _participantRepository;

        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _contestRepository = new Lazy<IRepository<Contest>>(() =>
                new EfRepository<Contest>(context));
            _participantRepository = new Lazy<IRepository<Participant>>(() =>
                new EfRepository<Participant>(context));
        }

        public IRepository<Contest> ContestRepository => _contestRepository.Value;
        public IRepository<Participant> ParticipantRepository => _participantRepository.Value;

        public async Task SaveAllAsync() => await _context.SaveChangesAsync();
        public async Task DeleteDatabaseAsync() => await _context.Database.EnsureDeletedAsync();
        public async Task CreateDatabaseAsync() => await _context.Database.EnsureCreatedAsync();
    }
}