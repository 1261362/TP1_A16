namespace TP1_A16.Models
{
    public class Animaux
    {
        public string Nom {  get; set; }    
        public string Description { get; set; } 
        public int QuantiteDisponible { get; set; }
        public float PrixAnimal { get; set; }
        public string Type { get; set; }  

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
