using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMedium.MODELS.DTO.Request.User
{
    public class AddNewUserRequest
    {
        [Required(ErrorMessage = "İsim alanı boş bırakılamaz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyisim alanı boş bırakılamaz.")]
        public string Surname { get; set; }
        public string About { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
        public string Password { get; set; }
    }
}
