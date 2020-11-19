using MediatR;
using search_application.Dto;
using search_application.Mapper;
using search_application.Query;
using search_data;
using search_model;
using System.Threading;
using System.Threading.Tasks;

namespace search_application.Handler
{
    public class GetQuestionByIdHandler : IRequestHandler<GetQuestionByIdQuery, QuestionDto>
    {
        private readonly IRepository<Question> repository;

        public GetQuestionByIdHandler(IRepository<Question> repository)
        {
            this.repository = repository;
        }

        public async Task<QuestionDto> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetById(request.Id);
            return result.AsDto();
        }
    }
}
