using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using TP1_A16.Models;

namespace TP1_A16.Controllers
{
    public class ProcedureAnimauxController : Controller
    {
        private string connectionString;
        public IConfiguration configuration;

        public ProcedureAnimauxController(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("defaultConnection");

        }

        //retourner tous les animaux
        private List<TypeAnimal> getAnimaux()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            List<TypeAnimal> listeAnimaux = new List<TypeAnimal>();

            connectionString = configuration.GetConnectionString("defaultconnection");

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT nom, description, quantiteDisponible, prixAnimal, type FROM TypeAnimal", // Assuming your table is named TypeAnimal
                Connection = conn
            };

            conn.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                TypeAnimal animal = new TypeAnimal()
                {                  
                    Nom = reader.GetString(reader.GetOrdinal("nom")),
                    Description = reader.GetString(reader.GetOrdinal("description")),
                    QuantiteDisponible = reader.GetInt32(reader.GetOrdinal("quantiteDisponible")),
                    PrixAnimal = reader.GetDouble(reader.GetOrdinal("prixAnimal")), 
                    Type = reader.GetString(reader.GetOrdinal("type"))
                };
                listeAnimaux.Add(animal);
            }

            conn.Close();
            return listeAnimaux;
        }

        public ActionResult Index()
        {
            List<TypeAnimal> listeAnimaux = getAnimaux();
            return View(listeAnimaux);
        }



        // GET: ProcedureAnimauxController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProcedureAnimauxController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProcedureAnimauxController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProcedureAnimauxController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProcedureAnimauxController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProcedureAnimauxController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProcedureAnimauxController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
