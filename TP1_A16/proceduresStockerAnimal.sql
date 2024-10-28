  --Code pour les procedures stockées : 

  --liste des animaux 

  IF OBJECT_ID('[dbo].[getAnimaux]', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE [dbo].[getAnimaux];
END

  CREATE PROCEDURE [dbo].[getAnimaux]
AS
BEGIN
	SELECT id, nom, description, quantiteDisponible, prixAnimal, type 
	FROM TypeAnimal
END;


--Creer un animal / insert


IF OBJECT_ID('[dbo].[InsertAnimal]', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE [dbo].[InsertAnimal];
END

go

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

IF OBJECT_ID('[dbo].[editAnimal]', 'P') IS NOT NULL
BEGIN 

	DROP PROCEDURE [dbo].[editAnimal];
	END 
GO

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

 IF OBJECT_ID('[dbo].[deleteAnimal]', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE [dbo].[deleteAnimal];
END
GO

CREATE PROCEDURE [dbo].[deleteAnimal]
    @id INT
AS
BEGIN
    DELETE FROM TypeAnimal
    WHERE id = @id;
END;


--find

IF OBJECT_ID('[dbo].[findAnimal]', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE [dbo].[findAnimal];
END
GO



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


