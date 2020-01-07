CREATE TABLE [dbo].[setupfeature] (
    [setupid] BIGINT        NOT NULL,
    [created] DATETIME      NOT NULL,
    [updated] DATETIME      NOT NULL,
    [name]    VARCHAR (MAX) NOT NULL,
    [value]   VARCHAR (MAX) NOT NULL
);

