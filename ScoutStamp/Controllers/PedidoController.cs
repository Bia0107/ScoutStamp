using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ScoutStamp.Models;

namespace ScoutStamp.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IConfiguration _configuration;
        public PedidoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Pedido()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Pedido(Pedido pedido)
        {
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = "INSERT INTO tbFornecedor (IdPedido,DataPedido,Produto,ValorTotal,StatusPedido,IdCliente,IdEndereco) " +
                                "VALUES (@IdPedido,@DataPedido,@Produto,@ValorTotal,@StatusPedido,@IdCliente,@IdEndereco)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPedido", pedido.IdPedido);
            command.Parameters.AddWithValue("@DataPedido", pedido.DataPedido);
            command.Parameters.AddWithValue("@Produto", pedido.Produto);
            command.Parameters.AddWithValue("@ValorTotal", pedido.ValorTotal);
            command.Parameters.AddWithValue("@StatusPedido", pedido.StatusPedido);
            command.Parameters.AddWithValue("@IdCliente", pedido.IdCliente);
            command.Parameters.AddWithValue("@IdPedido", pedido.IdEndereco);

            command.ExecuteNonQuery();

            return RedirectToAction("Index", "Home");
        }
    }
}

