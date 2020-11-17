﻿namespace search_model
{
    public class QuestionChoice : BaseEntity
    {
        public QuestionChoice(string value, int votes)
        {
            Value = value;
            Votes = votes;
        }

        public string Value { get; private set; }
        public int Votes { get; private set; }
    }
}
