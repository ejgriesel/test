CREATE TABLE [dbo].[fixregistration] (
    [id]            BIGINT        IDENTITY (1, 1) NOT NULL,
    [datetime]      DATETIME      DEFAULT (NULL) NULL,
    [commandid]     BIGINT        NOT NULL,
    [registid]      VARCHAR (MAX) NOT NULL,
    [registrefid]   VARCHAR (MAX) DEFAULT (NULL) NULL,
    [pending]       BIT           NOT NULL,
    [instructionid] VARCHAR (MAX) DEFAULT (NULL) NULL,
    [reported]      DATETIME      DEFAULT (NULL) NULL,
    [investorcode]  VARCHAR (MAX) DEFAULT (NULL) NULL,
    [tryreport]     BIT           DEFAULT ((1)) NULL,
    [error]         BIT           DEFAULT ((0)) NULL,
    [haserror]      BIT           DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

