CREATE TABLE [dbo].[Rentals] (
    [Id]         INT NOT NULL,
    [CarId]      INT NOT NULL,
    [CustomerId] INT  NOT NULL,
    [RentDate]   DATETIME      NOT NULL,
    [ReturnDate] DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

