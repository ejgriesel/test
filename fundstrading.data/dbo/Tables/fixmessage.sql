CREATE TABLE [dbo].[fixmessage] (
    [id]          BIGINT        IDENTITY (1, 1) NOT NULL,
    [datetime]    DATETIME      DEFAULT (NULL) NULL,
    [sessionid]   INT           NOT NULL,
    [commandid]   BIGINT        NOT NULL,
    [incoming]    BIT           NOT NULL,
    [messagetype] VARCHAR (5)   DEFAULT (NULL) NULL,
    [raw]         VARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

