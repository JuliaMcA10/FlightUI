CREATE PROCEDURE uspAttendantFlightMilesFuture(@Attendant_ID AS INTEGER

)

AS
BEGIN
   SELECT SUM(TF.intMilesFlown) As TotalMilesFlown
   FROM TAttendants As "TA" Right JOIN TAttendantFlights As "TAF"
   ON TA.intAttendantID = TAF.intAttendantID
   JOIN TFlights AS "TF"
   ON TF.intFlightID = TAF.intFlightID
   Where TF.dtmFlightDate > GETDATE() AND TA.intAttendantID = @Attendant_ID
END;