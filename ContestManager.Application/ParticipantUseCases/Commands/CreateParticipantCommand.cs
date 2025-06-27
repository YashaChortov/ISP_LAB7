using ContestManager.Domain.Entities;
using MediatR;

namespace ContestManager.Application.ParticipantUseCases.Commands
{
    public sealed record CreateParticipantCommand(
        string Name,
        int Age,
        string Institution,
        int VoteScore,
        int? ContestId) : IRequest<Participant>;
}