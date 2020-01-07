CREATE TABLE [dbo].[apiresponse] (
    [id]            BIGINT        IDENTITY (1, 1) NOT NULL,
    [datetime]      DATETIME      DEFAULT (NULL) NULL,
    [commandid]     BIGINT        NOT NULL,
    [responseCode]  INT           NOT NULL,
    [accepted]      BIT           DEFAULT (NULL) NULL,
    [instructionid] VARCHAR (MAX) DEFAULT (NULL) NULL,
    [raw]           VARCHAR (MAX) DEFAULT (NULL) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

