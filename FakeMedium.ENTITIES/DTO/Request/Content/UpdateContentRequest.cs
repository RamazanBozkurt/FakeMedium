using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMedium.MODELS.DTO.Request.Content
{
    public class UpdateContentRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "İçerik başlığı boş bırakılamaz.")]
        public string ContentHeader { get; set; }
        [Required(ErrorMessage = "İçerik metni boş bırakılamaz.")]
        public string ContentBody { get; set; }
        public string ContentDetails { get; set; }
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
