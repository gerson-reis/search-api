using MediatR;
using Newtonsoft.Json;
using search_application.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace search_application.Command
{
    public class CreateQuestionCommand : IRequest<QuestionDto>
    {
        [Required(ErrorMessage = "The field Question is mandatory.")]
        public string Question { get; set; }
        [Required(ErrorMessage = "The field Image Url is mandatory.")]
        public string Image_url { get; set; }
        [Required(ErrorMessage = "The field Thumb Url is mandatory.")]
        [JsonProperty(PropertyName = "thumb_url")]
        public string Thumb_url { get; set; }
        [Required(ErrorMessage = "The field Choices is mandatory.")]
        public IEnumerable<string> Choices { get; set; }
    }
}
