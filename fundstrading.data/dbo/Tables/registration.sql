CREATE TABLE [dbo].[registration] (
    [id]            BIGINT        IDENTITY (1, 1) NOT NULL,
    [datetime]      DATETIME      DEFAULT (NULL) NULL,
    [channelid]     INT           NOT NULL,
    [iosaccount]    VARCHAR (MAX) NOT NULL,
    [acknowledged]  BIT           NOT NULL,
    [pending]       BIT           NOT NULL,
    [instructionid] VARCHAR (MAX) DEFAULT (NULL) NULL,
    [reported]      DATETIME      DEFAULT (NULL) NULL,
    [investorcode]  VARCHAR (MAX) DEFAULT (NULL) NULL,
    [xml]           VARCHAR (MAX) NOT NULL,
    [tryreport]     BIT           CONSTRAINT [DF__regist_tryreport] DEFAULT ((1)) NOT NULL,
    [haserror]      BIT           CONSTRAINT [DF__regist_haserror] DEFAULT ((0)) NOT NULL,
    [status]        INT           CONSTRAINT [DF__regist_status] DEFAULT ((-1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

