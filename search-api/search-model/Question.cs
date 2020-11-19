using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace search_model
{
    public class Question : BaseEntity
    {
        public Question(string statement, string imageUrl, string thumbUrl, List<QuestionChoice> choices)
        {
            Statement = statement;
            ImageUrl = imageUrl;
            ThumbUrl = thumbUrl;
            Choices = choices;
        }

        protected Question() {}

        private string statement;
        public string Statement {
            get => statement;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("You cant send an invalid question.");

                statement = value;
            }
        }
        public bool ContainsChoice(string value) => Choices.Any(x => x.Value.ToLower().Contains(value.ToLower()));
        private ICollection<QuestionChoice> choices; 
        public ICollection<QuestionChoice> Choices 
        {
            get => choices;
            private set 
            {
                if (!value.Any())
                    throw new ArgumentException("The question cant be without choices.");

                choices = value;
            } 
        }
        public string ImageUrl { get; private set; }
        public string ThumbUrl { get; private set; }
        public void UpdateThumbUrl(string value)
        {
            ThumbUrl = value;
        }
        public void UpdateImageUrl(string value)
        {
            ImageUrl = value;
        }
        public void UpdateStatement(string value)
        {
            Statement = value;
        }
    }
}
