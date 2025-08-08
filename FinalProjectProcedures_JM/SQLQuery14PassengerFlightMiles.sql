CREATE PROCEDURE uspPassengerFlightMiles(@Passenger_ID AS INTEGER

)

AS
BEGIN
   SELECT SUM(TF.intMilesFlown) As TotalMilesFlown
   FROM TPassengers As "TP" Right JOIN TFlightPassengers As "TFP"
   ON TP.intPassengerID = TFP.intPassengerID
   JOIN TFlights AS "TF"
   ON TF.intFlightID = TFP.intFlightID
   Where TF.dtmFlightDate < GETDATE() AND TP.intPassengerID = @Passenger_ID
END;


EXECUTE uspPassengerFlightMiles 1