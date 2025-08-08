CREATE PROCEDURE uspAddAttendant
     @intAttendantID		INTEGER			
	,@strFirstName			VARCHAR(255)	
	,@strLastName			VARCHAR(255)	
	,@strEmployeeID			VARCHAR(255)	
	,@dtmDateOfHire			DATETIME		
	,@dtmDateOfTermination	DATETIME		
       
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
    SELECT @intAttendantID = MAX(intAttendantID) + 1 
    FROM TAttendants (TABLOCKX) -- lock table until end of transaction
    -- default to 1 if table is empty
    SELECT @intAttendantID = COALESCE(@intAttendantID, 1)
    INSERT INTO TAttendants (intAttendantID, strFirstName, strLastName, strEmployeeID, dtmDateOfHire, dtmDateOfTermination)
    VALUES (@intAttendantID, @strFirstName, @strLastName, @strEmployeeID, @dtmDateOfHire, @dtmDateOfTermination)

COMMIT TRANSACTION
GO
