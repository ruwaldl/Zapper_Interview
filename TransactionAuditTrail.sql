USE [Zapper]
GO

Create Table TransactionAuditTrail(
[TransactionID] UNIQUEIDENTIFIER PRIMARY KEY default NEWID()  NOT NULL,/*This Field is used to give a transaction an unique number*/
[MerchantNumber] nvarchar(50)  NOT NULL,/*This field displays the number that identifies the Merchant*/
[MerchantName] nvarchar(40)  NOT NULL,/*This field displays  the linked name of the merchant*/
[RetrievalReferenceNumber] nvarchar(12) NOT NULL,/** This field displays the number maintained throughout the lifecycle of  a transaction (Pos->Authorizer)*/
[RequestedAmount] DECIMAL(18, 2) NOT NULL,/*This field display the amount requested by the Merchant/POS/QRCode */
[ResponseCode] int NOT NULL,/* This field displays the outcome of the transaction (Approved, Declined) from the authorizer*/
[TerminalNumber] nvarchar(8) NOT NULL,/*This field displays the number of the terminal where transaction took place*/
[ResponseAmount] DECIMAL(18, 2) NOT NULL,/*This field is used to display the amount that was authorised by Authorizer*/
[PanNumber] nvarchar(19) NOT NULL,/*This field displays the Card number or Voucher used in the transaction*/
[CustomerId] UNIQUEIDENTIFIER NOT NULL,/*This field displays the unqiuie  Id of the customer in Zapper*/
[TransactionDateTime] DateTime NOT NULL,/*This field displays the Date and Time of the transaction*/
[CustomerName] nvarchar(50)  NOT NULL,/*This fileds displays the Customer Name linked to the CustomerId*/
[TransactionType] int NOT NULL,/*This field diplays the transaction type (Withdrawal,Purchase,Refund)*/
[AuthorizationID] nvarchar(6) NOT NULL,/*This field displays the Authorisation Id from the Authorizer*/
[Currency] nvarchar(3) NOT NULL,/*This field displays the currency of the transaction that was performed*/
[TransactionMethod] nvarchar(10) NOT NULL, /*This field displays the payment method of the transaction (QRCode,Card,Voucher)*/
[AdditionalAmount] DECIMAL(18, 2) NOT NULL, /*This field displays additinal amounts (TIP) in the transaction*/
[AdditionalData] nvarchar(MAX) NOT NULL, /*This field displays additional information carried in the transaction.*/
[TransactionStatus] nvarchar(50) NOT NULL, /*This field displays the status of the  transaction.*/

 CONSTRAINT UQ_RetrievalReferenceNumber UNIQUE (RetrievalReferenceNumber),
 CONSTRAINT UQ_Transaction UNIQUE (MerchantNumber, RetrievalReferenceNumber, TransactionDateTime, PanNumber,TransactionStatus)/*Composite unique constraint to prevent duplicate payments*/
)