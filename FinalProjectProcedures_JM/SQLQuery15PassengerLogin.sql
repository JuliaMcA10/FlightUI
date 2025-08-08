CREATE PROCEDURE uspPassengerLogin(@LoginID AS VARCHAR (255) 
									,@Password AS VARCHAR (255)
									
)
AS
BEGIN
SELECT strLoginID, strPassword FROM TPassengers
WHERE strLoginID = @LoginID AND strPassword = @Password
END
