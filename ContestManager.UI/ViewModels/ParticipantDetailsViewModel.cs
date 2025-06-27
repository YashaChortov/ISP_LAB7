using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContestManager.Application.ParticipantUseCases.Commands;
using ContestManager.Application.ParticipantUseCases.Queries;
using ContestManager.Domain.Entities;
using MediatR;

namespace ContestManager.UI.ViewModels
{
    [QueryProperty(nameof(Participant), "Participant")]
    public partial class ParticipantDetailsViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        [ObservableProperty]
        private Participant? _participant;

        public ParticipantDetailsViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [RelayCommand]
        private async Task UpdateParticipantScore(int newScore)
        {
            if (Participant == null) return;

            await _mediator.Send(new UpdateParticipantScoreCommand(
                Participant.Id, // Используем Id экземпляра
                newScore));

            // Обновляем данные участника
            var updatedParticipant = await _mediator.Send(
                new GetParticipantQuery(Participant.Id)); 

            if (updatedParticipant != null)
            {
                Participant = updatedParticipant;
            }
        }
    }
}