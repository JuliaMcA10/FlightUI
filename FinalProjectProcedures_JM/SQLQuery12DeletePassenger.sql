CREATE PROCEDURE uspDeletePassenger
     @intPassengerID				AS INTEGER  
    
       
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
  
    Delete  FROM TPassengers 
	WHERE  intPassengerID = @intPassengerID

COMMIT TRANSACTION
GO