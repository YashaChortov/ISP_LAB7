using MediatR;

namespace ContestManager.Application.ParticipantUseCases.Commands
{
    public sealed record DeleteParticipantCommand(int ParticipantId) : IRequest;
}