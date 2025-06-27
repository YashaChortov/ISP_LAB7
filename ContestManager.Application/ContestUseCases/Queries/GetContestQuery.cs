using ContestManager.Domain.Entities;
using MediatR;

namespace ContestManager.Application.ContestUseCases.Queries
{
    public sealed record GetContestQuery(int ContestId) : IRequest<Contest?>;
}