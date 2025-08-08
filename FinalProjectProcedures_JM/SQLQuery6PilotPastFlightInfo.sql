CREATE PROCEDURE uspPilotPastFlightInfo(@Pilot_ID AS INTEGER

)

AS
BEGIN
   SELECT TP.intPilotID, TF.intFlightID, TF.dtmFlightDate, TF.strFlightNumber,  TF.dtmTimeofDeparture, TF.dtmTimeOfLanding, TF.intFromAirportID, TF.intToAirportID, TF.intMilesFlown, TPS.strPlaneNumber
FROM TPilots AS TP JOIN TPilotFlights AS TPF
						ON TP.intPilotID = TPF.intPilotID
                        JOIN TFlights As TF
                        ON TF.intFlightID = TPF.intFlightID
                        JOIN TPlanes AS TPS
                        ON TPS.intPlaneID = TF.intPlaneID
                       Where TP.intPilotID = @Pilot_ID
                       AND TF.dtmFlightDate < GETDATE()
END;
