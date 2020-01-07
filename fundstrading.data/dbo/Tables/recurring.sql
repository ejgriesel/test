CREATE TABLE [dbo].[recurring] (
    [id]            BIGINT        IDENTITY (1, 1) NOT NULL,
    [datetime]      DATETIME      DEFAULT (NULL) NULL,
    [channelid]     INT           NOT NULL,
    [recurringtype] VARCHAR (MAX) NOT NULL,
    [graphitecode]  VARCHAR (MAX) NOT NULL,
    [cancelid]      BIGINT        NOT NULL,
    [enddate]       DATETIME      DEFAULT (NULL) NULL,
    [reported]      DATETIME      DEFAULT (NULL) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

