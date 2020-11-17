using System;
using System.Collections.Generic;
using System.Linq;

namespace search_model
{
    public class Question : BaseEntity
    {
        public Question(string statement, string imageUrl, string thumbUrl, IEnumerable<QuestionChoice> choices)
        {
            Statement = statement;
            ImageUrl = imageUrl;
            ThumbUrl = thumbUrl;
            Choices = choices;
        }

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
        private IEnumerable<QuestionChoice> choices; 
        public IEnumerable<QuestionChoice> Choices 
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
    }
}
