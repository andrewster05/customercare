CREATE TABLE [dbo].[Customers] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Firstname]   VARCHAR (100) NOT NULL,
    [Lastname]    VARCHAR (100) NOT NULL,
    [Email]       VARCHAR (255) NOT NULL,
    [DateOfBirth] DATE          NOT NULL,
    [ZipCode]     VARCHAR (9)   NULL,
    [Country]     INT           NULL,
    [CreatedDate] DATETIME      NOT NULL,
    [SystemRole]  INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);