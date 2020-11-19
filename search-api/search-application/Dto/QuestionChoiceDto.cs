using Newtonsoft.Json;

namespace search_application.Dto
{
    public class QuestionChoiceDto
    {
        public int Id { get; set; }
        public string Choice { get; set; }
        public int Votes { get; set; }
    }
}
