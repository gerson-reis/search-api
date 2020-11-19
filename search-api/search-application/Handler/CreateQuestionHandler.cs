using MediatR;
using search_application.Command;
using search_application.Dto;
using search_application.Mapper;
using search_data;
using search_model;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace search_application.Handler
{
    public class CreateQuestionHandler : IRequestHandler<CreateQuestionCommand, QuestionDto>
    {
        private readonly IRepository<Question> repository;

        public CreateQuestionHandler(IRepository<Question> repository)
        {
            this.repository = repository;
        }

        public async Task<QuestionDto> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var choices = request.Choices.Select(x => new QuestionChoice(x)).ToList();
            var result = await repository.Insert(new Question(request.Question, request.Image_url, request.Image_url, choices));
            return result.AsDto();
        }
    }
}
