-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.UpdatePartsPrice
	
	@PartNumber varchar(100) ,
	@ListPrice varchar(50) 
AS
-- EXEC dbo.UpdatePartsPrice '160000337','25'
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	  DECLARE @RowCount1 INTEGER
  UPDATE [dbo].[Parts]
   SET [ListPrice] = @ListPrice
 WHERE [PartNumber]  = @PartNumber 
  SELECT @RowCount1 = @@ROWCOUNT
  SELECT @RowCount1 AS UPDATEDCOUNT
END
