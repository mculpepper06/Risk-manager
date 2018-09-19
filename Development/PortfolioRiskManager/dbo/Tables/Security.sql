CREATE TABLE [dbo].[Security] (
    [SecurityId]   INT             IDENTITY (1, 1) NOT NULL,
    [SecurityName] VARCHAR (50)    NOT NULL,
    [MarketCap]    DECIMAL (18, 2) NULL,
    [LastPrice]    DECIMAL (18, 2) NULL,
    [Volume]       INT             NULL,
    [CountryId]    INT             NOT NULL,
    [IndustryId]   INT             NOT NULL,
    [Symbol]       VARCHAR (10)    NULL,
    CONSTRAINT [PK_Security] PRIMARY KEY CLUSTERED ([SecurityId] ASC),
    CONSTRAINT [FK_Security_Country] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Country] ([CountryId]),
    CONSTRAINT [FK_Security_Industry] FOREIGN KEY ([IndustryId]) REFERENCES [dbo].[Industry] ([IndustryId])
);

