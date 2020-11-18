using MediatR;
using search_application.Dto;

namespace search_application.Query
{
    public class GetQuestionByIdQuery : IRequest<QuestionDto>
    {
        public GetQuestionByIdQuery(int id)
        {
            Id = id;
        }
        public GetQuestionByIdQuery() {}

        public int Id { get; set; }
    }
}
