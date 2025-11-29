using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ScoutStamp.Models;

namespace ScoutStamp.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IConfiguration _configuration;
        public ProdutoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = "INSERT INTO tbProduto (IdProduto,Nome,ValorInid,QtdEstoque,IdFornecedor) VALUES (@IdProduto,@Nome,@ValorInid,@QtdEstoque,@IdFornecedor)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdProduto", produto.IdProduto);
            command.Parameters.AddWithValue("@Nome", produto.Nome);
            command.Parameters.AddWithValue("@ValorUnid", produto.ValorUnid);
            command.Parameters.AddWithValue("@QtdEstoque", produto.QtdEstoque);
            command.Parameters.AddWithValue("@IdFornecedor", produto.IdFornecedor);
            command.ExecuteNonQuery();

            return RedirectToAction("Index", "Home");
        }
    }
}
