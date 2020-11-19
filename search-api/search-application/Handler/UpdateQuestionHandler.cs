using MediatR;
using search_application.Command;
using search_application.Dto;
using search_application.Mapper;
using search_data;
using search_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace search_application.Handler
{
    public class UpdateQuestionHandler : IRequestHandler<UpdateQuestionCommand, QuestionDto>
    {
        private readonly IRepository<Question> repository;

        public UpdateQuestionHandler(IRepository<Question> repository)
        {
            this.repository = repository;
        }

        public async Task<QuestionDto> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var actualQuestion = await repository.GetById(request.Id);

            if (!string.Equals(actualQuestion.ImageUrl, request.Image_url))
                actualQuestion.UpdateImageUrl(request.Image_url);

            if (!string.Equals(actualQuestion.ThumbUrl, request.Thumb_url))
                actualQuestion.UpdateThumbUrl(request.Thumb_url);

            if (!string.Equals(actualQuestion.Statement, request.Question))
                actualQuestion.UpdateStatement(request.Question);

            UpdateChoices(request, actualQuestion);

            var result = await repository.Update(actualQuestion);
            return result.AsDto();
        }

        private void UpdateChoices(UpdateQuestionCommand request, Question actualQuestion)
        {
            var choicesUpdateId = request.Choices.Select(x => x.Id).ToArray();
            var choicesToRemove = actualQuestion.Choices.Where(x => !choicesUpdateId.Contains(x.Id)).ToList();
            choicesToRemove.ForEach(x => actualQuestion.Choices.Remove(x));

            var newChoices = request.Choices.Where(x => x.Id == 0).Select(x => new QuestionChoice(x.Choice)).ToList();
            newChoices.ForEach(x => actualQuestion.Choices.Add(x));

            (from actual in actualQuestion.Choices
                join toUpdate in request.Choices on actual.Id equals toUpdate.Id
                select GetActualWithUpdate(actual, toUpdate.Choice, toUpdate.Votes))
            .ToArray();
        }

        private QuestionChoice GetActualWithUpdate(QuestionChoice actual, string newValue, int votes)
        {
            actual.UpdateValue(newValue);
            actual.UpdateVotes(votes);
            return actual;
        }
    }
}
