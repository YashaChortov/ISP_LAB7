using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContestManager.Application.ContestUseCases.Queries;
using ContestManager.Domain.Entities;
using MediatR;
using System.Collections.ObjectModel;

namespace ContestManager.UI.ViewModels
{
    public partial class ContestsViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        [ObservableProperty]
        private Contest? _selectedContest;

        public ObservableCollection<Contest> Contests { get; } = new();
        public ObservableCollection<Participant> Participants { get; } = new();

        public ContestsViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [RelayCommand]
        private async Task LoadContests()
        {
            var contests = await _mediator.Send(new GetAllContestsQuery());

            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Contests.Clear();
                foreach (var contest in contests)
                {
                    Contests.Add(contest);
                }
            });
        }

        [RelayCommand]
        async Task GoToDetails(Participant participant)
        {
            if (participant is null) return;

            var parameters = new Dictionary<string, object>
    {
        { "Participant", participant }
    };

            await Shell.Current.GoToAsync(nameof(ParticipantDetailsPage), parameters);
        }

        [RelayCommand]
        private async Task LoadParticipants()
        {
            if (SelectedContest == null) return;

            var participants = await _mediator.Send(
                new GetContestParticipantsQuery(SelectedContest.Id));

            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Participants.Clear();
                foreach (var participant in participants)
                {
                    Participants.Add(participant);
                }
            });
        }

        [RelayCommand]
        private async Task ShowParticipantDetails(Participant participant)
        {
            var parameters = new Dictionary<string, object>
            {
                { "Participant", participant }
            };

            await Shell.Current.GoToAsync("ParticipantDetails", parameters);
        }
    }
}