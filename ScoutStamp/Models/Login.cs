using System.ComponentModel.DataAnnotations;

namespace ScoutStamp.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Usuário inválido")]
        [Display(Name = "Usuário")]
        public string? usuário { get; set; }

        [Required(ErrorMessage = "Senha")]
        [Display(Name = "Senha")]
        public string? senha { get; set; }
    }
}


        
