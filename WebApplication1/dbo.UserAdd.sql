CREATE PROC UserAdd
@UserName varchar(20),
@Password varchar(10)

AS

INSERT INTO Submit(UserName, Password) VALUES(@UserName, @Password)