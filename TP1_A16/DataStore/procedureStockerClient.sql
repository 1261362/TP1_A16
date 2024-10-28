--Ajouter CLient----------------------------------
CREATE PROCEDURE AjoutClient
    @Nom NVARCHAR(50),
    @Prenom NVARCHAR(50),
    @Courriel NVARCHAR(100),
	@Telephone NVARCHAR(15)
AS
BEGIN
    INSERT INTO Client (Nom, Prenom, Courriel,telephone)
    VALUES (@Nom, @Prenom, @Courriel, @Telephone);
END

-- GetDetailsClient

CREATE PROCEDURE [dbo].[GetDetailsClient]
    -- Ajouter les paramètres pour la procédure stockée
    @nom as nvarchar(50) = NULL,
    @prenom as nvarchar(50) = NULL,
    @courriel as nvarchar(50) = NULL,
	@telephone as nvarchar(50) = null
AS
BEGIN
    SET NOCOUNT ON;

    select Nom, Prenom, Courriel, telephone
    from [Animaux].dbo.Client
    where (@nom IS NULL OR Nom = @nom)
      and (@prenom IS NULL OR Prenom = @prenom)
      and (@courriel IS NULL OR Courriel = @courriel)
	  and (@telephone is null or telephone = @telephone);
END

--GetListeClient----------------------------------
CREATE PROCEDURE [dbo].[GetListeClient]
    -- Ajouter les paramètres pour la procédure stockée
    @nom as nvarchar(24) = NULL,
    @prenom as nvarchar(24) = NULL,
    @courriel as nvarchar(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Sélectionner les films en fonction des paramètres
    select Nom, Prenom, Courriel
    from [Animaux].dbo.Client
    where (@nom IS NULL OR Nom = @nom)
      and (@prenom IS NULL OR Prenom = @prenom)
      and (@courriel IS NULL OR Courriel = @courriel);
END

--rechercheClient----------------------------------
CREATE procedure [dbo].[RechercheClient]
	@recherche as nvarchar(24) = NULL
as 
begin
	SET NOCOUNT ON;
	 
    select Nom, Prenom, Courriel
    from [Animaux].dbo.Client
    where  
	nom LIKE @recherche + '%' OR 
	prenom LIKE @recherche + '%' OR
	courriel LIKE @recherche + '%'
END

--supprimerClient----------------------------------
CREATE procedure [dbo].[SupprimerClient]
	@nom nvarchar(50)
AS
BEGIN
	DELETE FROM Client
	WHERE nom = @nom;
END;

--Updateclient----------------------------------
CREATE procedure [dbo].[UpdateClient]
    @nom NVARCHAR(50),
    @prenom NVARCHAR(50),
	@courriel NVARCHAR(50),
	@telephone NVARCHAR(15)
    
as 
begin 
	update Client
	set 
		nom= @nom,
		prenom= @prenom,
		courriel = @courriel,
		telephone = @telephone
	where nom = @nom
end