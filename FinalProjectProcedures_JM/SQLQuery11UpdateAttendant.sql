CREATE PROCEDURE uspUpdateAttendant
     @intAttendantID		INTEGER			
	,@strFirstName			VARCHAR(255)	
	,@strLastName			VARCHAR(255)	
	,@strEmployeeID			VARCHAR(255)	
	,@dtmDateOfHire			DATETIME		
	,@dtmDateOfTermination	DATETIME
       
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
  
    Update  TAttendants 
			SET strFirstName =	@strFirstName, 
			    strLastName =	@strLastName,
				strEmployeeID = @strEmployeeID,
				dtmDateOfHire = @dtmDateOfHire,
				dtmDateOfTermination = @dtmDateOfTermination
			
	WHERE  intAttendantID = @intAttendantID
COMMIT TRANSACTION
GO