using search_application.Dto;
using search_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace search_application.Mapper
{
    public static class QuestionToDto
    {
        public static QuestionDto AsDto(this Question question)
        {
            return new QuestionDto()
            {
                Id = question.Id,
                Image_url = question.ImageUrl,
                Question = question.Statement,
                Thumb_url = question.ThumbUrl,
                Choices = question.Choices.Select(x => new QuestionChoiceDto() 
                {
                    Choice = x.Value,
                    Votes = x.Votes
                })
            };
        }

        public static IEnumerable<QuestionDto> AsDto(this IEnumerable<Question> questions)
        {
            foreach (var question in questions)
            {
                yield return question.AsDto();
            } 
        }
    }
}
