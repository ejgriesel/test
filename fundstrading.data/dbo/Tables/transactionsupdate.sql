CREATE TABLE [dbo].[transactionsupdate] (
    [id]                BIGINT        IDENTITY (1, 1) NOT NULL,
    [datetime]          DATETIME      NOT NULL,
    [commandid]         BIGINT        NOT NULL,
    [sessionid]         INT           NOT NULL,
    [originalcommandid] BIGINT        NOT NULL,
    [newcommandid]      BIGINT        DEFAULT (NULL) NULL,
    [raw]               VARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

