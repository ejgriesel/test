CREATE TABLE [dbo].[feeinstruction] (
    [id]                BIGINT        IDENTITY (1, 1) NOT NULL,
    [datetime]          DATETIME      DEFAULT (NULL) NULL,
    [channelid]         INT           NOT NULL,
    [correlationid]     VARCHAR (MAX) DEFAULT (NULL) NULL,
    [feecode]           VARCHAR (MAX) NOT NULL,
    [postinstructionid] VARCHAR (MAX) DEFAULT (NULL) NULL,
    [investmentcode]    VARCHAR (MAX) DEFAULT (NULL) NULL,
    [applied]           DATETIME      DEFAULT (NULL) NULL,
    [failed]            BIT           NOT NULL,
    [feeinstructionid]  VARCHAR (MAX) DEFAULT (NULL) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

