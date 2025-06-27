using ContestManager.Domain.Entities;
using MediatR;

namespace ContestManager.Application.ParticipantUseCases.Queries
{
    public sealed record GetParticipantQuery(int ParticipantId) : IRequest<Participant?>;
}