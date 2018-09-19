CREATE TABLE [dbo].[Portfolio] (
    [PortfolioId]      INT             IDENTITY (1, 1) NOT NULL,
    [PortfolioName]    VARCHAR (50)    NOT NULL,
    [PortfolioBalance] DECIMAL (18, 2) NULL,
    [Cash]             DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_Portfolio] PRIMARY KEY CLUSTERED ([PortfolioId] ASC)
);

