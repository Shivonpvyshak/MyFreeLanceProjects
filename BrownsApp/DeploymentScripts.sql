--02/19/2017
ALTER TABLE [Billing].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Invoice_Customer_Customer] FOREIGN KEY([CustID])
REFERENCES [Customer].[Customer] ([ID])
GO

ALTER TABLE [Billing].[Invoice] CHECK CONSTRAINT [FK_Invoice_Invoice_Customer_Customer]
GO

--3/26/2017
--Addition of Paid Date in Invoice Table
ALTER Table Billing.Invoice
 Add  PaidDate Datetime

 --4/16/2017
 ALTER Table Billing.Invoice
 Add  CountyId int

 --4/19/2017
 ALTER TABLE Billing.Customer
ADD CONSTRAINT UX_Name UNIQUE (Name)
GO

--4/30/2017
ALTER TABLE Billing.InvoiceItems
Alter column Quantity Decimal(10,2) NOT NULL;
