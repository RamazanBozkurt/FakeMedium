using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMedium.MODELS.DTO.Request.Category
{
    public class UpdateCategoryRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kategori adı boş bırakılamaz.")]
        public string Name { get; set; }
    }
}
