using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ScoutStamp.Models;

namespace ScoutStamp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = "INSERT INTO tbLogin (usuário,senha) " +
                                "VALUES (@usuário,@senha)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@usuário", login.usuário);
            command.Parameters.AddWithValue("@senha", login.senha);         

            command.ExecuteNonQuery();

            return RedirectToAction("Index", "Home");
        }
    }
}

