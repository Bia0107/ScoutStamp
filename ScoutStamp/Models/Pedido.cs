using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace ScoutStamp.Models
{
    public class Pedido
    {
        [Required(ErrorMessage ="O código do pedido é obrigatório")]
        [Display(Name = "Código do Pedido")]
        public int IdPedido { get; set; }

        [Required(ErrorMessage = "A data do pedido é obrigatório")]
        [Display(Name = "Data do Pedido")]
        public DateFormat DataPedido { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        [Display(Name = "Nome do Produto")]
        public string? Produto { get; set; }

        [Required(ErrorMessage = "O valor do pedido é obrigatório")]
        [Display(Name = "Código do Pedido")]
        public double ValorTotal { get; set; }

        [Required(ErrorMessage = "O status do pedido é obrigatório")]
        [Display(Name = "Status do Pedido")]
        public string? StatusPedido { get; set; }

        [Required(ErrorMessage = "O id do cliente é obrigatório")]
        [Display(Name = "Id do Cliente")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "O id do endereço é obrigatório")]
        [Display(Name = "Id do Endereço")]
        public int IdEndereco { get; set; }
    }
}
