using ContestManager.Domain.Entities;
using MediatR;

namespace ContestManager.Application.ContestUseCases.Queries
{
    public sealed record GetContestParticipantsQuery(int ContestId)
        : IRequest<IEnumerable<Participant>>;
}