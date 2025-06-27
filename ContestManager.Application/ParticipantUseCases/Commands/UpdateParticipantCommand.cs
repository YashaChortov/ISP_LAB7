using ContestManager.Domain.Entities;
using MediatR;

namespace ContestManager.Application.ParticipantUseCases.Commands
{
    public sealed record UpdateParticipantCommand(
        int ParticipantId,
        string Name,
        int Age,
        string Institution,
        int VoteScore) : IRequest;
}