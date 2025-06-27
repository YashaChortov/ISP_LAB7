using ContestManager.Application.ParticipantUseCases.Commands;
using ContestManager.Domain.Abstractions;
using ContestManager.Domain.Entities;
using MediatR;

namespace ContestManager.Application.ParticipantUseCases.Handlers
{
    internal class CreateParticipantCommandHandler
        : IRequestHandler<CreateParticipantCommand, Participant>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateParticipantCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Participant> Handle(CreateParticipantCommand request,
            CancellationToken cancellationToken)
        {
            var participant = new Participant(
                request.Name,
                request.Age,
                request.Institution,
                request.VoteScore);

            if (request.ContestId.HasValue)
            {
                participant.AssignToContest(request.ContestId.Value);
            }

            await _unitOfWork.ParticipantRepository.AddAsync(participant, cancellationToken);
            await _unitOfWork.SaveAllAsync();
            return participant;
        }
    }
}