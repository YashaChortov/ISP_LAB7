using ContestManager.Application.ContestUseCases.Queries;
using ContestManager.Domain.Abstractions;
using ContestManager.Domain.Entities;
using MediatR;
using System.Linq.Expressions;

namespace ContestManager.Application.ContestUseCases.Handlers
{
    internal class GetContestParticipantsQueryHandler
        : IRequestHandler<GetContestParticipantsQuery, IEnumerable<Participant>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetContestParticipantsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Participant>> Handle(GetContestParticipantsQuery request,
            CancellationToken cancellationToken)
        {
            Expression<Func<Participant, bool>> filter = p => p.ContestId == request.ContestId;
            return await _unitOfWork.ParticipantRepository.ListAsync(filter, cancellationToken);
        }
    }
}