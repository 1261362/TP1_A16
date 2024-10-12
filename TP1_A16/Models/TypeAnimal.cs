namespace TP1_A16.Models
{
    public class TypeAnimal
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public int QuantiteDisponible { get; set; }
        public double PrixAnimal { get; set; }
        public string Type { get; set; }

        public TypeAnimal(string nom, string description, int quantiteDisponible,
            float prixAnimal, string type)
        {
            this.Nom = nom;
            this.Description = description;
            this.QuantiteDisponible = quantiteDisponible;
            this.PrixAnimal = prixAnimal;
            this.Type = type;
        }

        // Empty constructor
        public TypeAnimal() { }
    }
}


/*CREATE TABLE TypeAnimal (
    id INT IDENTITY(1,1) PRIMARY KEY,   -- Utilisation de IDENTITY pour l'incrémentation automatique
    nom NVARCHAR(50) NOT NULL,
    description NVARCHAR(255) NOT NULL,
    quantiteDisponible INT NOT NULL,
    prixAnimal FLOAT NOT NULL,   -- Utilisation de FLOAT ou DECIMAL pour les valeurs numériques
    type NVARCHAR(50) NOT NULL  -- Nouvelle colonne ajoutée
);*/
