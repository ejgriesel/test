CREATE TABLE [dbo].[transactionreport] (
    [id]            BIGINT        IDENTITY (1, 1) NOT NULL,
    [channelid]     INT           NOT NULL,
    [transactionid] VARCHAR (MAX) DEFAULT (NULL) NULL,
    [processed]     DATETIME      NOT NULL,
    [reported]      DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

