CREATE Procedure [dbo].[GetPartReportData]
    /* Input Parameters */
  	@Make varchar(100) = null,
	@Model varchar(100) = null,
	@SerialNumberRange varchar(MAX) = null,
	@PartNumber varchar(100) = null,
	@PartManual text = null,
	@PartDescription varchar(MAX) = null
        
AS

--exec GetPartReportData 'JLG',NULL,NULL,NULL,NULL,NULL
--exec GetPartReportData NULL,NULL,NULL,'test',NULL,NULL
--exec GetPartReportData '','','','test','',''
    Set NoCount ON
    /* Variable Declaration */
    Declare @SQLQuery AS NVarchar(4000)
    Declare @ParamDefinition AS NVarchar(2000) 
    Set @SQLQuery = 'Select * From dbo.Parts where 1=1' 
    
    If @Make Is Not Null and @Make !='All'
         Set @SQLQuery = @SQLQuery + ' And (Make = @Make)'

    If @Model Is Not Null
         Set @SQLQuery = @SQLQuery + ' And (Model = @Model)' 
  
    If @SerialNumberRange Is Not Null
         Set @SQLQuery = @SQLQuery + ' And (SerialNumberRange = @SerialNumberRange)'
  
    If @PartNumber IS NOT NULL 
         Set @SQLQuery = @SQLQuery + ' And (PartNumber = @PartNumber)'

	If @PartManual Is Not Null
		Set @SQLQuery = @SQLQuery + ' And (PartManual = @PartManual)'

	If @PartDescription Is Not Null
		Set @SQLQuery = @SQLQuery + ' And (PartDescription = @PartDescription)'

		Set @SQLQuery = @SQLQuery +  ' ORDER BY PARTNUMBER'

    /* Specify Parameter Format for all input parameters included 
     in the stmt */
    Set @ParamDefinition =      ' @Make varchar(100),
	@Model varchar(100),
	@SerialNumberRange varchar,
	@PartNumber varchar(100),
	@PartManual text,
	@PartDescription varchar'
    /* Execute the Transact-SQL String with all parameter value's 
       Using sp_executesql Command */
    Execute sp_Executesql     @SQLQuery, 
                @ParamDefinition, 
                @Make,
				@Model,
				@SerialNumberRange,
				@PartNumber,
				@PartManual,
				@PartDescription
                
    If @@ERROR <> 0 GoTo ErrorHandler
    Set NoCount OFF
    Return(0)
  
ErrorHandler:
    Return(@@ERROR)
