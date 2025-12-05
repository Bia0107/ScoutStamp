using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ScoutStamp.Models;
using System.Diagnostics;

namespace ScoutStamp.Controllers
{
    public class FornecedorController : Controller
    {

        private readonly IConfiguration _configuration;
        public FornecedorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Fornecedor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Fornecedor(Fornecedor fornecedor)
        {
            if (!ModelState.IsValid)
            {
                return View(fornecedor);
            }

            string? connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var connection = new MySqlConnection(connectionString);
            {
                try
                {
                    connection.Open();
                    string sql = "INSERT INTO tbProduto (IdFornecedor,NomeFantasia,RazaoSocial,CNPJ,Email,IdEdereco)" +
                                 "VALUES (@IdFornecedor,@NomeFantasia,@RazaoSocial,@CNPJ,@Email,@IdEdereco)";

                    using MySqlCommand command = new MySqlCommand(sql, connection);
                    {
                        command.Parameters.AddWithValue("@IdFornecedor", fornecedor.IdFornecedor);
                        command.Parameters.AddWithValue("@NomeFantasia", fornecedor.NomeFantasia);
                        command.Parameters.AddWithValue("@RazaoSocial", fornecedor.RazaoSocial);
                        command.Parameters.AddWithValue("@CNPJ", fornecedor.CNPJ);
                        command.Parameters.AddWithValue("@Email", fornecedor.Email);
                        command.Parameters.AddWithValue("@IdEndereco", fornecedor.IdEndereco);

                        command.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    ModelState.AddModelError(string.Empty, "Erro ao registrar o fornecedor: " + ex.Message);
                    return View(fornecedor);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}

