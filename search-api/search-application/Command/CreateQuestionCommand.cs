using MediatR;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace search_application.Command
{
    public class CreateQuestionCommand : IRequest
    {
        [Required(ErrorMessage = "The field Question is mandatory.")]
        [JsonProperty(PropertyName = "question")]
        public string Question { get; set; }
        [Required(ErrorMessage = "The field Image Url is mandatory.")]
        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "The field Thumb Url is mandatory.")]
        [JsonProperty(PropertyName = "thumb_url")]
        public string ThumbUrl { get; set; }
        [Required(ErrorMessage = "The field Choices is mandatory.")]
        [JsonProperty(PropertyName = "choices")]
        public IEnumerable<string> Choices { get; set; }
    }
}
