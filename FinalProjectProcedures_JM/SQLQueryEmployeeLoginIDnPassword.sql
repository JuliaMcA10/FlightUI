CREATE PROCEDURE uspEmployeeLoginIDnPassword(
     @employee_id AS INTEGER
    
    
)
AS
BEGIN
   SELECT TE.strEmployeeLoginID, TE.strEmployeePassword
   FROM TEmployees as TE
   Where TE.intFKEmployeeID = @employee_id;
END;