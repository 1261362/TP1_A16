using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using TP1_A16.Models;
using System.Collections.Generic;

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

        //get list of animals
        private List<TypeAnimal> getAnimaux()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            List<TypeAnimal> listeAnimaux = new List<TypeAnimal>();

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT id, nom, description, quantiteDisponible, prixAnimal, type FROM TypeAnimal",
                Connection = conn
            };

            conn.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                TypeAnimal animal = new TypeAnimal()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")), // Ensure you have Id property in TypeAnimal
                    Nom = reader.GetString(reader.GetOrdinal("nom")),
                    Description = reader.GetString(reader.GetOrdinal("description")),
                    QuantiteDisponible = reader.GetInt32(reader.GetOrdinal("quantiteDisponible")),
                    PrixAnimal = reader.GetDouble(reader.GetOrdinal("prixAnimal")),
                    Type = reader.GetString(reader.GetOrdinal("type"))
                };
                listeAnimaux.Add(animal);
            }

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
            TypeAnimal animal = getAnimaux().Find(animal => animal.Id == id);

            if (animal == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(animal);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TypeAnimal animal)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;

                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand
                {
                    CommandText = "INSERT INTO TypeAnimal (Nom, Description, QuantiteDisponible, PrixAnimal, Type) VALUES (@nom, @description, @quantiteDisponible, @prixAnimal, @type)",
                    Connection = conn
                };

                cmd.Parameters.Add(new SqlParameter("@nom", animal.Nom));
                cmd.Parameters.Add(new SqlParameter("@description", animal.Description));
                cmd.Parameters.Add(new SqlParameter("@quantiteDisponible", animal.QuantiteDisponible));
                cmd.Parameters.Add(new SqlParameter("@prixAnimal", animal.PrixAnimal));
                cmd.Parameters.Add(new SqlParameter("@type", animal.Type));

                conn.Open();
                cmd.ExecuteNonQuery();
                ViewBag.SuccessMessage = "L'animal a été créé avec succès !";
                conn.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(animal);
            }
        }

        // GET: TypeAnimalController/Edit/5
        public ActionResult Edit(int id)
        {
            TypeAnimal animal = getAnimaux().Find(a => a.Id == id);

            if (animal == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(animal);
        }

        // POST: TypeAnimalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TypeAnimal updatedAnimal)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedAnimal);
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        CommandType = CommandType.Text,
                        CommandText = "UPDATE TypeAnimal SET Nom = @Nom, Description = @Description, QuantiteDisponible = @QuantiteDisponible, PrixAnimal = @PrixAnimal, Type = @Type WHERE id = @Id",
                        Connection = conn
                    };

                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nom", updatedAnimal.Nom);
                    cmd.Parameters.AddWithValue("@Description", updatedAnimal.Description);
                    cmd.Parameters.AddWithValue("@QuantiteDisponible", updatedAnimal.QuantiteDisponible);
                    cmd.Parameters.AddWithValue("@PrixAnimal", updatedAnimal.PrixAnimal);
                    cmd.Parameters.AddWithValue("@Type", updatedAnimal.Type);

                    conn.Open();
                    int count = cmd.ExecuteNonQuery();
                    conn.Close();

                    ViewBag.SuccessMessage = "Animal successfully modified!";

                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "No animal found with that id.");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating animal: {ex.Message}");
            }

            return View(updatedAnimal);
        }

        // GET: TypeAnimalController/Delete/5
        public ActionResult Delete(int id)
        {
            TypeAnimal animal = getAnimaux().Find(a => a.Id == id);
            if (animal == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(animal);
        }

        // POST: TypeAnimalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, List<TypeAnimal>listeAnimaux)
        {
            try
            {
                    // vérifier validité id
                    if (id <= 0)
                    {
                        return NotFound(); // Return NotFound if the ID is invalid
                    }

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                    SqlCommand cmd = new SqlCommand
                    {
                        CommandType = CommandType.Text,
                        CommandText = "DELETE FROM TypeAnimal WHERE id = @Id",
                        Connection = conn
                    };
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                   }

                ViewBag.SuccessMessage = "Animal successfully deleted!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
