using MediatR;
using Newtonsoft.Json;
using search_application.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace search_application.Command
{
    public class UpdateQuestionCommand : IRequest<QuestionDto>
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }
        public IEnumerable<QuestionChoiceDto> Choices { get; set; }
        [Required(ErrorMessage = "The field Question is mandatory.")]
        public string Question { get; set; }
        [Required(ErrorMessage = "The field Image Url is mandatory.")]
        public string Image_url { get; set; }
        [Required(ErrorMessage = "The field Thumb Url is mandatory.")]
        public string Thumb_url { get; set; }
    }
}
