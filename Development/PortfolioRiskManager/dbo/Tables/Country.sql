CREATE TABLE [dbo].[Country] (
    [CountryId] INT          NOT NULL,
    [Name]      VARCHAR (50) NULL,
    CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED ([CountryId] ASC)
);

