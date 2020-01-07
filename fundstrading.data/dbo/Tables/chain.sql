CREATE TABLE [dbo].[chain] (
    [id]         BIGINT        IDENTITY (1, 1) NOT NULL,
    [datetime]   DATETIME      DEFAULT (NULL) NULL,
    [commandid]  BIGINT        NOT NULL,
    [fqcnstring] VARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

