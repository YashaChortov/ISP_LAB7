using ContestManager.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace ContestManager.Application
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider services)
        {
            var unitOfWork = services.GetRequiredService<IUnitOfWork>();

            await unitOfWork.DeleteDatabaseAsync();
            await unitOfWork.CreateDatabaseAsync();

            // Добавляем тестовые номинации
            var contest1 = new Contest("Лучший дизайн", DateTime.Now.AddDays(-10), "Дизайн");
            var contest2 = new Contest("Лучшая программа", DateTime.Now.AddDays(-5), "Программирование");

            await unitOfWork.ContestRepository.AddAsync(contest1);
            await unitOfWork.ContestRepository.AddAsync(contest2);
            await unitOfWork.SaveAllAsync();

            // Добавляем тестовых участников
            var participants = new List<Participant>
            {
                new("Иван Иванов", 20, "БГУИР", 8) { ContestId = contest1.Id },
                new("Петр Петров", 22, "БГУ", 6) { ContestId = contest1.Id },
                new("Анна Сидорова", 21, "БНТУ", 9) { ContestId = contest1.Id },
                new("Мария Кузнецова", 23, "БГУИР", 4) { ContestId = contest2.Id },
                new("Алексей Смирнов", 20, "БГУ", 7) { ContestId = contest2.Id }
            };

            foreach (var participant in participants)
            {
                await unitOfWork.ParticipantRepository.AddAsync(participant);
            }

            await unitOfWork.SaveAllAsync();
        }
    }
}