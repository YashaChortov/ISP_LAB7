using System.Collections.ObjectModel;

namespace ContestManager.Domain.Entities
{
    public class Contest : Entity
    {
        private List<Participant> _participants = new();

        public Contest(string name, DateTime nominationDate, string category)
        {
            Name = name;
            NominationDate = nominationDate;
            Category = category;
        }

        public string Name { get; private set; }
        public DateTime NominationDate { get; private set; }
        public string Category { get; private set; }
        public IReadOnlyList<Participant> Participants => _participants.AsReadOnly();

        public void AddParticipant(Participant participant)
        {
            if (participant == null) return;
            _participants.Add(participant);
        }

        public void UpdateInfo(string name, DateTime date, string category)
        {
            Name = name;
            NominationDate = date;
            Category = category;
        }
    }
}