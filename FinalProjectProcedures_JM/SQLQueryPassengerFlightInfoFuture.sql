CREATE PROCEDURE uspPassengerFlightInfoFuture(@Passenger_ID AS INTEGER

)

AS
BEGIN
   SELECT TP.intPassengerID, TF.intFlightID, TF.dtmFlightDate, TF.strFlightNumber,  TF.dtmTimeofDeparture, TF.dtmTimeOfLanding, TF.intFromAirportID, TF.intToAirportID, TF.intMilesFlown, TPS.strPlaneNumber
FROM TPassengers AS TP JOIN TFlightPassengers AS TFP
						ON TP.intPassengerID = TFP.intPassengerID
                        JOIN TFlights As TF
                        ON TF.intFlightID = TFP.intFlightID
                        JOIN TPlanes AS TPS
                        ON TPS.intPlaneID = TF.intPlaneID
                       Where TP.intPassengerID = @Passenger_ID
                       AND TF.dtmFlightDate > GETDATE()
END;