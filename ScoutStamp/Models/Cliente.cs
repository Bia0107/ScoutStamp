using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace ScoutStamp.Models
{
    public class Cliente
    {
        [Required (ErrorMessage="É obrigatório informar o id do cliente.")]
        [Display(Name = "Id do Cliente")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o telefone.")]
        [Display(Name = "Telefone")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o email.")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o CPF.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter 11 digitos.")]
        public long CPF { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o nome")]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        [Display(Name = "Data de Nascimento")]
        public DateFormat Nascimento { get; set; }
    }
}

