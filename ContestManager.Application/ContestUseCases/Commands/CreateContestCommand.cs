using ContestManager.Domain.Entities;
using MediatR;

namespace ContestManager.Application.ContestUseCases.Commands
{
    public sealed record CreateContestCommand(string Name, DateTime NominationDate, string Category)
        : IRequest<Contest>;
}