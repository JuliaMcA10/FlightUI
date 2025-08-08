CREATE PROCEDURE uspPilotListbyIDRole(
     @pilot_id AS INTEGER
	 ,@role_ID AS INTEGER
    
    
)
AS
BEGIN
   SELECT TP.strFirstName, TP.strLastName, TP.strEmployeeID, TP.dtmDateOfLicense, TP.dtmDateOfHire, TP.dtmDateOfTermination, TP.intPilotRoleID, TPR.strPilotRole
   FROM TPilots as TP JOIN TPilotRoles as TPR
   ON TP.intPilotRoleID = TPR.intPilotRoleID
   Where TP.intPilotID = @pilot_id
   AND TPR.intPilotRoleID = @role_ID;
END;
 
 EXECUTE uspPilotListbyIDRole 1, 1