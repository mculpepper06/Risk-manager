CREATE TABLE [dbo].[Price] (
    [PriceId]       INT             IDENTITY (1, 1) NOT NULL,
    [SecurityId]    INT             NOT NULL,
    [AsOfDate]      DATE            NOT NULL,
    [SecurityPrice] DECIMAL (18, 4) NOT NULL,
    CONSTRAINT [PK_Price] PRIMARY KEY CLUSTERED ([PriceId] ASC),
    CONSTRAINT [FK_Price_Security] FOREIGN KEY ([SecurityId]) REFERENCES [dbo].[Security] ([SecurityId])
);

