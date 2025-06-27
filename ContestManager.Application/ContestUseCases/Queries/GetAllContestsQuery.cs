using ContestManager.Domain.Entities;
using MediatR;

namespace ContestManager.Application.ContestUseCases.Queries
{
    public sealed record GetAllContestsQuery : IRequest<IEnumerable<Contest>>;
}