using MediatR;
using search_application.Command;
using System.Threading;
using System.Threading.Tasks;

namespace search_application.Handler
{
    public class CreateQuestionHandler : IRequestHandler<CreateQuestionCommand>
    {
        public async Task<Unit> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {

            return Unit.Value;
        }
    }
}
