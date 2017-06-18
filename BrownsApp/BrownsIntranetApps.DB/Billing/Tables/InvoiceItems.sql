CREATE TABLE [Billing].[InvoiceItems] (
    [ID]              INT           IDENTITY (1, 1) NOT NULL,
    [InvoiceID]       INT           NOT NULL,
    [Description]     VARCHAR (MAX) NULL,
    [Quantity]        INT           NOT NULL,
    [Price]           MONEY         NOT NULL,
    [Total]           MONEY         NOT NULL,
    [AddedBy]         VARCHAR (50)  NULL,
    [AddedDate]       DATETIME      NULL,
    [LastUpdatedBy]   VARCHAR (50)  NULL,
    [LastUpdatedDate] DATETIME      NULL,
    CONSTRAINT [PK_InvoiceItems] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_InvoiceItems_InvoiceItems_Invoice] FOREIGN KEY ([InvoiceID]) REFERENCES [Billing].[Invoice] ([ID])
);

