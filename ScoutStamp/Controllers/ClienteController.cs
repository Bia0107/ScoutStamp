using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ScoutStamp.Models;

namespace ScoutStamp.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IConfiguration _configuration;
        public ClienteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Cliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            string? connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var connection = new MySqlConnection(connectionString);
            {
                try
                {
                    connection.Open();
                    string sql = "INSERT INTO tbProduto (IdCliente,Telefone,Email,CPF,Nome,DataNasc)" +
                                    "VALUES(@IdCliente,@Telefone,@Email,@CPF,@Nome,@DataNasc)";

                    using MySqlCommand command = new MySqlCommand(sql, connection);
                    {
                        command.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                        command.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                        command.Parameters.AddWithValue("@Email", cliente.Email);
                        command.Parameters.AddWithValue("@CPF", cliente.CPF);
                        command.Parameters.AddWithValue("@Nome", cliente.Nome);
                        command.Parameters.AddWithValue("@Nascimento", cliente.Nascimento);

                        command.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    ModelState.AddModelError(string.Empty, "Erro ao registrar o fornecedor: " + ex.Message);
                    return View(cliente);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }


}
