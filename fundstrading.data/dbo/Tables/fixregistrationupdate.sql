CREATE TABLE [dbo].[fixregistrationupdate] (
    [id]            BIGINT        IDENTITY (1, 1) NOT NULL,
    [datetime]      DATETIME      DEFAULT (NULL) NULL,
    [commandid]     INT           NOT NULL,
    [channelid]     INT           NOT NULL,
    [sessionid]     INT           NOT NULL,
    [registid]      VARCHAR (MAX) DEFAULT (NULL) NULL,
    [registrefid]   VARCHAR (MAX) DEFAULT (NULL) NULL,
    [instructionid] VARCHAR (MAX) NOT NULL,
    [reported]      DATETIME      DEFAULT (NULL) NULL,
    [tryreport]     BIT           CONSTRAINT [DF__fixregistupdt_tryreport] DEFAULT ((1)) NOT NULL,
    [haserror]      BIT           CONSTRAINT [DF__fixregistupdt_haserror] DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

