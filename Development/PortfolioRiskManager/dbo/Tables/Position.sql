CREATE TABLE [dbo].[Position] (
    [PositionId]  INT             IDENTITY (1, 1) NOT NULL,
    [SecurityId]  INT             NOT NULL,
    [PortfolioId] INT             NOT NULL,
    [Shares]      DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED ([PositionId] ASC),
    CONSTRAINT [FK_Position_Portfolio] FOREIGN KEY ([PortfolioId]) REFERENCES [dbo].[Portfolio] ([PortfolioId]),
    CONSTRAINT [FK_Position_Security] FOREIGN KEY ([SecurityId]) REFERENCES [dbo].[Security] ([SecurityId])
);

