using System.Collections.Generic;

namespace search_application.Dto
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public IEnumerable<QuestionChoiceDto> Choices { get; set; }
        public string Image_url { get; set; }
        public string Thumb_url { get; set; }
    }
}
