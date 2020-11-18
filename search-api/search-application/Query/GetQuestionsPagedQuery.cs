using MediatR;
using search_application.Dto;
using System.Collections.Generic;

namespace search_application.Query
{
    public class GetQuestionsPagedQuery : IRequest<IEnumerable<QuestionDto>>
    {
        public GetQuestionsPagedQuery() {}

        public GetQuestionsPagedQuery(int offSet, int limit, string fitler)
        {
            OffSet = offSet;
            Limit = limit;
            Filter = fitler;
        }

        public int OffSet { get; set; }
        public int Limit { get; set; }
        public string Filter { get; set; }
    }
}
