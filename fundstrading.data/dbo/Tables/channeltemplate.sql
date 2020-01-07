CREATE TABLE [dbo].[channeltemplate] (
    [id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [channelid]      INT           NOT NULL,
    [investortypeid] INT           NOT NULL,
    [template]       VARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

