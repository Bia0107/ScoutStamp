using System.ComponentModel.DataAnnotations;

namespace ScoutStamp.Models
{
    public class Fornecedor
    {
        [Display(Name = "Código do Fornecedor")]
        public int IdFornecedor { get; set; }

        [Display(Name = "Nome")]
        public string? NomeFantasia { get; set; }

        [Display(Name = "Razão Social")]
        public string? RazaoSocial { get; set; }

        [Display(Name = "CNPJ")]
        public int CNPJ { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Endereço")]
        public int IdEndereco { get; set; }
    }
}
