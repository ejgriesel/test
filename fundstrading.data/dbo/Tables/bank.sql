CREATE TABLE [dbo].[bank] (
    [id]                  BIGINT        IDENTITY (1, 1) NOT NULL,
    [channelid]           INT           NOT NULL,
    [universalbranchcode] VARCHAR (MAX) NOT NULL,
    [graphitecode]        VARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

