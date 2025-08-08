CREATE PROCEDURE uspAttendattPastFlightInfo(@Attendant_ID AS INTEGER

)

AS
BEGIN
   SELECT TA.intAttendantID, TF.intFlightID, TF.dtmFlightDate, TF.strFlightNumber,  TF.dtmTimeofDeparture, TF.dtmTimeOfLanding, TF.intFromAirportID, TF.intToAirportID, TF.intMilesFlown, TPS.strPlaneNumber
FROM TAttendants AS TA JOIN TAttendantFlights AS TAF
						ON TA.intAttendantID = TAF.intAttendantID
                        JOIN TFlights As TF
                        ON TF.intFlightID = TAF.intFlightID
                        JOIN TPlanes AS TPS
                        ON TPS.intPlaneID = TF.intPlaneID
                       Where TA.intAttendantID = @Attendant_ID
                       AND TF.dtmFlightDate < GETDATE()
END;