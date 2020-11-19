using System;

namespace search_model
{
    public class QuestionChoice : BaseEntity
    {
        public QuestionChoice(string value)
        {
            Value = value;
        }

        protected QuestionChoice() {}

        private string value;
        public string Value 
        {
            get => value;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidOperationException("Choice question is invalid.");
                this.value = value;
            }
        }
        public int Votes { get; private set; }
        public Question Question { get; private set; }
        public void UpdateVotes(int value)
        {
            Votes = value;
        }
        public void UpdateValue(string value)
        {
            Value = value;
        }
    }
}
