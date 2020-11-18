namespace search_model
{
    public class QuestionChoice : BaseEntity
    {
        public QuestionChoice(string value)
        {
            Value = value;
        }

        protected QuestionChoice() {}

        public string Value { get; private set; }
        public int Votes { get; private set; }
        public Question Question { get; private set; }
        public void AddVotes(int votes)
        {
            Votes += votes;
        }
    }
}
