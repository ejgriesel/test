CREATE TABLE [dbo].[apirequest] (
    [id]        BIGINT        IDENTITY (1, 1) NOT NULL,
    [datetime]  DATETIME      DEFAULT (NULL) NULL,
    [commandid] BIGINT        NOT NULL,
    [raw]       VARCHAR (MAX) DEFAULT (NULL) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

