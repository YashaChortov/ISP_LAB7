using MediatR;

namespace ContestManager.Application.ParticipantUseCases.Commands
{
    public sealed record RemoveParticipantFromContestCommand(int ParticipantId) : IRequest;
}