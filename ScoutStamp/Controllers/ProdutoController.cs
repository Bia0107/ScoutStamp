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
        public IActionResult Produto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Produto(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return View(produto);
            }

            string? connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var connection = new MySqlConnection(connectionString);
            {
                try
                {
                    connection.Open();
                    string sql = "INSERT INTO tbProduto (IdProduto,Nome,ValorUnid,QtdEstoque,IdFornecedr)" +
                                 "VALUES (@IdProduto,@Nome,@ValorUnid,@QtdEstoque,@IdFornecedr)";

                    using MySqlCommand command = new MySqlCommand(sql, connection);
                    {
                        command.Parameters.AddWithValue("@IdProduto", produto.IdProduto);
                        command.Parameters.AddWithValue("@Nome", produto.Nome);
                        command.Parameters.AddWithValue("@ValorUnid", produto.ValorUnid);
                        command.Parameters.AddWithValue("@QtdEstoque", produto.QtdEstoque);
                        command.Parameters.AddWithValue("@IdFornecedor", produto.IdFornecedor);

                        command.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    ModelState.AddModelError(string.Empty, "Erro ao registrar o produto: " + ex.Message);
                    return View(produto);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
