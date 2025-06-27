using ContestManager.Application.ContestUseCases.Commands;
using ContestManager.Domain.Abstractions;
using ContestManager.Domain.Entities;
using MediatR;

namespace ContestManager.Application.ContestUseCases.Handlers
{
    internal class CreateContestCommandHandler : IRequestHandler<CreateContestCommand, Contest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateContestCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Contest> Handle(CreateContestCommand request,
            CancellationToken cancellationToken)
        {
            var contest = new Contest(request.Name, request.NominationDate, request.Category);
            await _unitOfWork.ContestRepository.AddAsync(contest, cancellationToken);
            await _unitOfWork.SaveAllAsync();
            return contest;
        }
    }
}