CREATE PROCEDURE [dbo].[getAnimaux]
AS
BEGIN
	SELECT id, nom, description, quantiteDisponible, prixAnimal,imageUrl, type 
	FROM TypeAnimal
END;


--Creer un animal / insert
CREATE PROCEDURE [dbo].[InsertAnimal]

    @nom NVARCHAR(50),
    @description NVARCHAR(255),
    @quantiteDisponible INT,
    @prixAnimal FLOAT,
    @type NVARCHAR(50)
AS
BEGIN
    INSERT INTO TypeAnimal (Nom, Description, QuantiteDisponible, PrixAnimal, Type)
    VALUES (@nom, @description, @quantiteDisponible, @prixAnimal, @type);
END;


Exec getAnimaux;

--edit----
CREATE PROCEDURE [dbo].[editAnimal] 

	@id INT,
	@nom NVARCHAR(50),
    @description NVARCHAR(255),
    @quantiteDisponible INT,
    @prixAnimal FLOAT,
    @type NVARCHAR(50)
AS
BEGIN

	UPDATE TypeAnimal
	SET
	nom = @nom,
    description = @description,
    quantiteDisponible = @quantiteDisponible,
    prixAnimal = @prixAnimal,
    type = @type
		
	WHERE id = @id;
END;

  --delete
CREATE PROCEDURE [dbo].[deleteAnimal]
    @id INT
AS
BEGIN
    DELETE FROM TypeAnimal
    WHERE id = @id;
END;


--find
CREATE PROCEDURE [dbo].[findAnimal]
    @searchTxt NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM TypeAnimal 
    WHERE 
        type LIKE @searchTxt + '%' OR 
        nom LIKE @searchTxt + '%' OR 
        description LIKE @searchTxt + '%';
END;


