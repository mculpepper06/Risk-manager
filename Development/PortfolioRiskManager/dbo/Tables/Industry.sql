CREATE TABLE [dbo].[Industry] (
    [IndustryId]   INT          IDENTITY (6, 1) NOT NULL,
    [IndustryName] VARCHAR (50) NOT NULL,
    [SectorName]   VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Industry] PRIMARY KEY CLUSTERED ([IndustryId] ASC)
);

