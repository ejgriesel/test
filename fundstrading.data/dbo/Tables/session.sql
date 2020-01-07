CREATE TABLE [dbo].[session] (
    [id]               INT           IDENTITY (1, 1) NOT NULL,
    [channelid]        INT           NOT NULL,
    [beginstring]      VARCHAR (MAX) NOT NULL,
    [sendercompid]     VARCHAR (MAX) NOT NULL,
    [targetcompid]     VARCHAR (MAX) NOT NULL,
    [onbehalfofcompid] VARCHAR (MAX) DEFAULT (NULL) NULL,
    [roe]              VARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

