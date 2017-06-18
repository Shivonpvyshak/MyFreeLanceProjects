-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddException]
	
	@Source [varchar](200) NULL,
	@Message [varchar](max) NULL,
	@StackTrace [varchar](max) NULL,
	@ExceptionDate [date] NULL
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
     INSERT INTO dbo.ExceptionHistory
          ( 
            [Source],                   
            [Message],                  
            [StackTrace],                     
            [ExceptionDate]                   
            
          ) 
     VALUES 
          ( 
            @Source,@Message,@StackTrace,CURRENT_TIMESTAMP
          ) 

END
