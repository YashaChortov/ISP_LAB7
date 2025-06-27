using MediatR;

namespace ContestManager.Application.ParticipantUseCases.Commands
{
    public sealed record AssignParticipantToContestCommand(
        int ParticipantId,
        int ContestId) : IRequest;
}