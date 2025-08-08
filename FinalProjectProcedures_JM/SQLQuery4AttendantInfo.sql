CREATE PROCEDURE uspAttendantInfo(@Attendant_ID AS INTEGER

)

AS
BEGIN
   SELECT * From TAttendants
   Where TAttendants.intAttendantID = @Attendant_ID
END;