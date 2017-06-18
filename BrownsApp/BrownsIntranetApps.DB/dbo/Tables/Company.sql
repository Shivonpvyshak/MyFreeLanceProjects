CREATE TABLE [dbo].[Company] (
    [ID]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NULL,
    CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([ID] ASC)
);

