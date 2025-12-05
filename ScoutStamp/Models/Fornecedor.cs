using System.ComponentModel.DataAnnotations;

namespace ScoutStamp.Models
{
    public class Fornecedor
    {
        [Required(ErrorMessage = "O id do fornecedor é obrigatório.")]
        [Display(Name = "Id do Fornecedor")]
        public string? IdFornecedor { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [Display(Name = "Nome")]
        public string? NomeFantasia { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a razão social.")]
        [Display(Name = "Razão Social")]
        public string? RazaoSocial { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "O CNPJ deve conter 14 digitos.")]
        [Display(Name = "CNPJ")]
        public string? CNPJ { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O id do endereço é obrigatório.")]
        [Display(Name = "Endereço")]
        public int IdEndereco { get; set; }
    }
}
