using ContestManager.Domain.Entities;
using MediatR;

namespace ContestManager.Application.ContestUseCases.Commands
{
    public sealed record UpdateContestCommand(
        int ContestId,
        string Name,
        DateTime NominationDate,
        string Category) : IRequest;
}