CREATE TABLE [dbo].[Car] (
    [CarID]       NVARCHAR(50)           NOT NULL,
    [BrandID]     NVARCHAR(50)           NOT NULL,
    [ColorID]     NVARCHAR(50)           NOT NULL,
    [DailyPrice]  DECIMAL (18)  NOT NULL,
    [ModelYear]   INT           NOT NULL,
    [Description] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([CarID] ASC)
);

