CREATE PROCEDURE uspEmployeeLogin(@LoginID AS VARCHAR (255) 
									,@Password AS VARCHAR (255)
									
)
AS
BEGIN
SELECT strEmployeeLoginID, strEmployeePassword FROM TEmployees
WHERE strEmployeeLoginID = @LoginID AND strEmployeePassword = @Password
END