CREATE TABLE [dbo].[instruction] (
    [id]              BIGINT        IDENTITY (1, 1) NOT NULL,
    [datetime]        DATETIME      DEFAULT (NULL) NULL,
    [commandid]       BIGINT        NOT NULL,
    [channelid]       INT           NOT NULL,
    [instructiontype] VARCHAR (MAX) NOT NULL,
    [instructionid]   VARCHAR (MAX) NOT NULL,
    [recurring]       BIT           DEFAULT ((0)) NOT NULL,
    [reported]        DATETIME      DEFAULT (NULL) NULL,
    [instancestatus]  INT           DEFAULT (NULL) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

