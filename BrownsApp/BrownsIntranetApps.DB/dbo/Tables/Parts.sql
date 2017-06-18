CREATE TABLE [dbo].[Parts] (
    [ID]                BIGINT        IDENTITY (1, 1) NOT NULL,
    [CompanyID]         INT           NULL,
    [Make]              VARCHAR (50)  NULL,
    [Model]             VARCHAR (500) NULL,
    [SerialNumberRange] VARCHAR (MAX) NULL,
    [PartNumber]        VARCHAR (100) NULL,
    [PartManual]        VARCHAR (MAX) NULL,
    [PartDescription]   VARCHAR (MAX) NULL,
    [ListPrice]         VARCHAR (100) NULL,
    [AddedBy]           VARCHAR (50)  NULL,
    [AddedDate]         DATETIME      NULL,
    [LastUpdatedBy]     VARCHAR (50)  CONSTRAINT [DF_Parts_LastUpdatedBy] DEFAULT (getdate()) NULL,
    [LastUpdatedDate]   DATETIME      CONSTRAINT [DF_Parts_LastUpdatedDate] DEFAULT (getdate()) NULL,
    [IsDeleted]         BIT           CONSTRAINT [DF_Parts_IsDeleted] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_Parts] PRIMARY KEY CLUSTERED ([ID] ASC)
);



