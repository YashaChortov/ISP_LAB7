using ContestManager.Application.ParticipantUseCases.Commands;
using ContestManager.Domain.Abstractions;
using ContestManager.Domain.Entities;
using MediatR;

namespace ContestManager.Application.ParticipantUseCases.Handlers
{
    internal class UpdateParticipantScoreCommandHandler
        : IRequestHandler<UpdateParticipantScoreCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateParticipantScoreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateParticipantScoreCommand request,
            CancellationToken cancellationToken)
        {
            var participant = await _unitOfWork.ParticipantRepository
                .GetByIdAsync(request.ParticipantId, cancellationToken);

            if (participant != null)
            {
                participant.UpdateScore(request.NewScore);
                await _unitOfWork.ParticipantRepository.UpdateAsync(participant, cancellationToken);
                await _unitOfWork.SaveAllAsync();
            }
        }
    }
}