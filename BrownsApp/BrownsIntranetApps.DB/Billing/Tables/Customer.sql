CREATE TABLE [Billing].[Customer] (
    [ID]               INT           IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (100) NOT NULL,
    [Address1]         VARCHAR (MAX) NOT NULL,
    [Address2]         VARCHAR (MAX) NULL,
    [City]             VARCHAR (50)  NOT NULL,
    [State]            VARCHAR (50)  NOT NULL,
    [Zip]              VARCHAR (50)  NOT NULL,
    [ShippingStreet]   VARCHAR (MAX) NULL,
    [ShippingCity]     VARCHAR (50)  NULL,
    [ShippingState]    VARCHAR (50)  NULL,
    [ShippingZip]      VARCHAR (50)  NULL,
    [ContactNumber]    VARCHAR (50)  NULL,
    [AddedDate]        DATETIME      NULL,
    [AddedBy]          VARCHAR (50)  NULL,
    [LastUpdatedDate]  DATETIME      CONSTRAINT [DF_Customer_LastUpdatedDate] DEFAULT (getdate()) NULL,
    [LastUpdatedBy]    VARCHAR (50)  NULL,
    [Street]           VARCHAR (MAX) NULL,
    [ShippingAddress1] VARCHAR (MAX) NULL,
    [ShippingAddress2] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Billing.Customer] PRIMARY KEY CLUSTERED ([ID] ASC)
);



