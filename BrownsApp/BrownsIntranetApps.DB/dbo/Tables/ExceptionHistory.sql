CREATE TABLE [dbo].[ExceptionHistory] (
    [ID]            INT           IDENTITY (1, 1) NOT NULL,
    [Source]        VARCHAR (200) NULL,
    [Message]       VARCHAR (MAX) NULL,
    [StackTrace]    VARCHAR (MAX) NULL,
    [ExceptionDate] DATETIME      CONSTRAINT [DF_dbo.ExceptionHistory_ExceptionDate] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_ExceptionHistory] PRIMARY KEY CLUSTERED ([ID] ASC)
);



