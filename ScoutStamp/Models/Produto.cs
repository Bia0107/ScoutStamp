using System.ComponentModel.DataAnnotations;

namespace ScoutStamp.Models
{
    public class Produto
    {
        [Display(Name = "Código do Produto")]
        public int IdProduto { get; set; }

        [Display(Name = "Nome do Produto")]
        public string? Nome { get; set; }

        [Display(Name = "Descrição do Produto")]
        public double? ValorUnid { get; set; }
        
        [Display(Name = "Quantidade em Estoque")]
        public double? QtdEstoque { get; set; }

        [Display(Name = "Código do Fornecedor")]
        public int IdFornecedor { get; set; }
    }
}
