using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using TP1_A16.Models;

namespace TP1_A16.Controllers
{
    public class ProcedureClientController : Controller
    {

        private string connectionString;
        public IConfiguration configuration;

        public ProcedureClientController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public ActionResult Rechercher(string search)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            List<Client> listeRecherche;
            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RechercheClient";
            cmd.Connection = conn;      
             // findAnimal = procedure stocké pour rechercher dans nom, desscription et type
            cmd.Parameters.Add(new SqlParameter("@recherche", search + "%"));
            conn.Open();
            
            reader = cmd.ExecuteReader();
            listeRecherche = new List<Client>();        
             while (reader.Read())
                    {
                        Client clientRecherche = new Client()
                        {                           
                            Nom = reader.GetString(reader.GetOrdinal("nom")),
                            Prenom = reader.GetString(reader.GetOrdinal("prenom")),
                            Courriel = reader.GetString(reader.GetOrdinal("courriel"))                            
                        };
                        listeRecherche.Add(clientRecherche);
                    }
               return View("Index", listeRecherche);
        }


        // GET: ProcedureClientController
        public ActionResult Index()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            List<Client> listeClient;
            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetListeClient";
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            listeClient = new List<Client>();
            while (reader.Read())
            {
                Client client = new Client();
                client.Nom = reader.GetString("nom");
                client.Prenom = reader.GetString("prenom");
                client.Courriel = reader.GetString("courriel");
                listeClient.Add(client);
            }
            return View(listeClient);
        }

        // GET: ProcedureClientController/Details/5
        public ActionResult Details(string nom)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Client client = null;

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetDetailsClient";
            cmd.Parameters.Add(new SqlParameter("@Nom", nom));
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            client = new Client();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // GetOrdinal pour éviter les erreurs de casse
                    client = new Client();
                    client.Nom = reader.GetString(reader.GetOrdinal("Nom"));      
                    client.Prenom = reader.GetString(reader.GetOrdinal("Prenom"));
                    client.Courriel = reader.GetString(reader.GetOrdinal("Courriel"));
                    client.Telephone = reader.GetString(reader.GetOrdinal("Telephone"));
                }
                return View(client);
            }
            conn.Close();
            return RedirectToAction(nameof(Index));
        }

        // GET: ProcedureClientController/Create
        public ActionResult Create()
        {
            Client client = new Client();
            return View(client);
        }

        // POST: ProcedureClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;
                SqlDataReader reader;
                
                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AjoutClient";
                cmd.Parameters.Add(new SqlParameter("@Nom", client.Nom));
                cmd.Parameters.Add(new SqlParameter("@Prenom", client.Prenom));
                cmd.Parameters.Add(new SqlParameter("@Courriel", client.Courriel));
                cmd.Parameters.Add(new SqlParameter("@Telephone", client.Telephone));
                cmd.Connection = conn;

                conn.Open();
                int rowCount = cmd.ExecuteNonQuery();
                conn.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProcedureClientController/Edit/5
        public ActionResult Edit(string nom)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Client client = null;

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetDetailsClient";
            cmd.Parameters.Add(new SqlParameter("@Nom", nom));
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            client = new Client();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    client = new Client();
                    client.Nom = reader.GetString("Nom");
                    client.Prenom = reader.GetString("Prenom");
                    client.Courriel = reader.GetString("Courriel");
                    client.Telephone = reader.GetString("Telephone");
                }
                return View(client);
            }
            conn.Close();
            return RedirectToAction(nameof(Index));
        }

        // POST: ProcedureClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            try
            {

                SqlConnection conn;
                SqlCommand cmd;
                SqlDataReader reader;


                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateClient";
                cmd.Parameters.Add(new SqlParameter("@Nom", client.Nom));
                cmd.Parameters.Add(new SqlParameter("@Prenom", client.Prenom));
                cmd.Parameters.Add(new SqlParameter("@Courriel", client.Courriel));
                cmd.Parameters.Add(new SqlParameter("@Telephone", client.Telephone));
                cmd.Connection = conn;

                conn.Open();
                int rowCount = cmd.ExecuteNonQuery();
                conn.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProcedureClientController/Delete/5
        public ActionResult Delete(string nom)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Client client = null;

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(); 
            cmd.Parameters.Add(new SqlParameter("@nom", nom));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetDetailsClient";

            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            client = new Client();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    client = new Client();
                    client.Nom = reader.GetString("Nom");
                    client.Prenom = reader.GetString("Prenom");
                    client.Courriel = reader.GetString("Courriel");
                    client.Telephone = reader.GetString("Telephone");
                }
                return View(client);
            }
            conn.Close();
            return RedirectToAction(nameof(Index));
        }

        // POST: ProcedureClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string nom, Client client)
        {
            SqlConnection conn;
            SqlCommand cmd;

            connectionString = configuration.GetConnectionString("defaultConnection");

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();

            cmd.Parameters.Add(new SqlParameter("@nom", nom));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SupprimerClient";
           

            cmd.Connection = conn;
            conn.Open();

            int rowCount = cmd.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction(nameof(Index));
        }
    }
}
