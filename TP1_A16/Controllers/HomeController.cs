using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using TP1_A16.Models;

namespace TP1_A16.Controllers
{
    public class HomeController : Controller
    {
        private string connectionString;
        public IConfiguration configuration;

        private readonly ILogger<HomeController> _logger;

        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("defaultConnection");
        }
        public IActionResult Index()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            List<TypeAnimal> listeAnimaux = new List<TypeAnimal>();

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "getAnimaux",
                Connection = conn
            };

            conn.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                TypeAnimal animal = new TypeAnimal()
                {
                    ImageUrl = reader["imageUrl"] as string,
                    Nom = reader.GetString(reader.GetOrdinal("nom")),
                    Description = reader.GetString(reader.GetOrdinal("description")),
                    QuantiteDisponible = reader.GetInt32(reader.GetOrdinal("quantiteDisponible")),
                    PrixAnimal = reader.GetDouble(reader.GetOrdinal("prixAnimal")),
                    Type = reader.GetString(reader.GetOrdinal("type"))
                };
                listeAnimaux.Add(animal);
                
            }
            return View(listeAnimaux);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
