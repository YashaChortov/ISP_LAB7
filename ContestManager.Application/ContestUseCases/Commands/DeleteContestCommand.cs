using MediatR;

namespace ContestManager.Application.ContestUseCases.Commands
{
    public sealed record DeleteContestCommand(int ContestId) : IRequest;
}