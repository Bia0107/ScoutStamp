using System.ComponentModel.DataAnnotations;

namespace ScoutStamp.Models
{
    public class Produto
    {
        [Required(ErrorMessage = "Obrigatório informar o id do produto.")]
        [Display(Name = "Id do produto")]
        public int IdProduto { get; set; }

        [Required(ErrorMessage ="É obrigatório informar o nome.")]
        [Display(Name = "Nome do Produto")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [Display(Name = "Valor do Produto")]
        public double ValorUnid { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Display(Name = "Quantidade em Estoque")]
        public int QtdEstoque { get; set; }

        [Required(ErrorMessage ="É obrigatório informar o id do fornecedor.")]
        [Display(Name = "Id do Fornecedor")]
        public int IdFornecedor { get; set; }
    }
}
