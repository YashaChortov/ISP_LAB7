using ContestManager.Application.ContestUseCases.Queries;
using ContestManager.Domain.Abstractions;
using ContestManager.Domain.Entities;
using MediatR;

namespace ContestManager.Application.ContestUseCases.Handlers
{
    internal class GetAllContestsQueryHandler : IRequestHandler<GetAllContestsQuery, IEnumerable<Contest>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllContestsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Contest>> Handle(GetAllContestsQuery request,
            CancellationToken cancellationToken)
        {
            return await _unitOfWork.ContestRepository.ListAllAsync(cancellationToken);
        }
    }
}