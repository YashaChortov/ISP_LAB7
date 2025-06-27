using MediatR;

namespace ContestManager.Application.ParticipantUseCases.Commands
{
    public sealed record UpdateParticipantScoreCommand(
        int ParticipantId,
        int NewScore) : IRequest;
}