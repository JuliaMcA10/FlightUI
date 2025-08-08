CREATE PROCEDURE uspPassengerInfo(@Passenger_ID AS INTEGER

)

AS
BEGIN
   SELECT * From TPassengers
   Where TPassengers.intPassengerID = @Passenger_ID
END;