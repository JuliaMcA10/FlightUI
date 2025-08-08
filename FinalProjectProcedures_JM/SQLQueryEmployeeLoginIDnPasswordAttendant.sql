CREATE PROCEDURE uspEmployeeLoginIDnPasswordAttendant(
     @employee_id AS INTEGER
    
    
)
AS
BEGIN
   SELECT TE.strEmployeeLoginID, TE.strEmployeePassword
   FROM TEmployees as TE
   Where TE.strEmployeeRole = 'Attendant' AND TE.intFKEmployeeID = @employee_id;
END
