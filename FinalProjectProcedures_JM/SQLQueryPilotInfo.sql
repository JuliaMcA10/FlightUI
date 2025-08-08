CREATE PROCEDURE uspPilotListbyRole(
     @pilot_id AS INTEGER
    
    
)
AS
BEGIN
   SELECT TP.strFirstName, TP.strLastName, TP.strEmployeeID, TP.dtmDateOfLicense, TP.dtmDateOfHire, TP.dtmDateOfTermination
   FROM TPilots as TP 
   Where TP.intPilotID = @pilot_id;
END;