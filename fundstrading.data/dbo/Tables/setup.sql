CREATE TABLE [dbo].[setup] (
    [id]        BIGINT IDENTITY (1, 1) NOT NULL,
    [channelid] INT    NOT NULL,
    [sessionid] INT    NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

