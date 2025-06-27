namespace ContestManager.Domain.Entities
{
    public class Participant : Entity
    {
        public Participant(string name, int age, string institution, int voteScore)
        {
            Name = name;
            Age = age;
            Institution = institution;
            VoteScore = voteScore;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; private set; }
        public string Institution { get;  set; }
        public int VoteScore { get;  set; }
        public int? ContestId { get;  set; }
        public Contest? Contest { get;  set; }

        public void UpdateInfo(string name, int age, string institution)
        {
            Name = name;
            Age = age;
            Institution = institution;
        }

        public void UpdateScore(int score)
        {
            if (score >= 0)
                VoteScore = score;
        }

        public void AssignToContest(int contestId)
        {
            ContestId = contestId;
        }

        public void RemoveFromContest()
        {
            ContestId = null;
        }
    }
}