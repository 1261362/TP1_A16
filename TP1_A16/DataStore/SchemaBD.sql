-- Créer la table Client
CREATE TABLE Client (
    id INT IDENTITY(1,1) PRIMARY KEY, 
    nom NVARCHAR(50) NOT NULL,
    prenom NVARCHAR(50) NOT NULL,
    courriel NVARCHAR(100) NOT NULL UNIQUE,
    telephone NVARCHAR(15) NOT NULL    
);


-- Créer la table TypeAnimal
CREATE TABLE TypeAnimal (
    id INT IDENTITY(1,1) PRIMARY KEY,  
    nom NVARCHAR(50) NOT NULL,
    description NVARCHAR(255) NOT NULL,
    quantiteDisponible INT NOT NULL,
    prixAnimal FLOAT NOT NULL,  
    imageUrl NVARCHAR(255) NOT NULL,
    type NVARCHAR(50) NOT NULL  
);

