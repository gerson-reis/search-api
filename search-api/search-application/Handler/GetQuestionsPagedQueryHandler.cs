using MediatR;
using search_application.Dto;
using search_application.Mapper;
using search_application.Query;
using search_data;
using search_model;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace search_application.Handler
{
    public class GetQuestionsPagedQueryHandler : IRequestHandler<GetQuestionsPagedQuery, IEnumerable<QuestionDto>>
    {
        private readonly IRepository<Question> repository;

        public GetQuestionsPagedQueryHandler(IRepository<Question> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<QuestionDto>> Handle(GetQuestionsPagedQuery request, CancellationToken cancellationToken)
        {
            var result = !string.IsNullOrEmpty(request.Filter) ?
                                await repository
                                .GetPage(request.Limit, request.OffSet, x => request.Filter.Contains(x.Statement.ToLower()) || (x.Choices.Select(c => c.Value.ToLower()).Any(c => request.Filter.Contains(c)))) :
                                await repository.GetPage(request.Limit, request.OffSet);

            return result.AsDto();
        }
    }
}
