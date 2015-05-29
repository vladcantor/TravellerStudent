CREATE PROCEDURE TravellerStudent_Users_Insert
	@UserGUID uniqueidentifier,
	@LoginName nvarchar(100),
	@Name nvarchar(100),
	@UserType smallint
AS
BEGIN
	INSERT INTO Users(UserGUID, LoginName, Name, UserType) VALUES (@UserGUID, @LoginName, @Name, @UserType)
END
GO
