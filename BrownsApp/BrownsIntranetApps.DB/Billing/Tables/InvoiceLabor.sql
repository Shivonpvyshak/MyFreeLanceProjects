CREATE TABLE [Billing].[InvoiceLabor] (
    [ID]              INT          IDENTITY (1, 1) NOT NULL,
    [InvoiceID]       INT          NOT NULL,
    [LaborType]       VARCHAR (50) NOT NULL,
    [Hours]           FLOAT (53)   NOT NULL,
    [Rate]            MONEY        NOT NULL,
    [Amount]          MONEY        NULL,
    [AddedDate]       DATETIME     NULL,
    [AddedBy]         VARCHAR (50) NULL,
    [LastUpdatedDate] DATETIME     NULL,
    [LastUpdatedBy]   VARCHAR (50) NULL,
    CONSTRAINT [PK_InvoiceLabor] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_InvoiceLabor_InvoiceLabor_Invoice] FOREIGN KEY ([InvoiceID]) REFERENCES [Billing].[Invoice] ([ID])
);

