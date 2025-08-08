CREATE PROCEDURE uspPilotFlightMiles(@Pilot_ID AS INTEGER

)

AS
BEGIN
   SELECT SUM(TF.intMilesFlown) As TotalMilesFlown
   FROM TPilots As "TP" Right JOIN TPilotFlights As "TPF"
   ON TP.intPilotID = TPF.intPilotID
   JOIN TFlights AS "TF"
   ON TF.intFlightID = TPF.intFlightID
   Where TF.dtmFlightDate < GETDATE() AND TP.intPilotID = @Pilot_ID
END;

EXECUTE uspPilotFlightMiles 1