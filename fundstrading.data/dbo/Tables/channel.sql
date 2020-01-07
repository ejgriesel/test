CREATE TABLE [dbo].[channel] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [description] VARCHAR (MAX) NOT NULL,
    [appid]       VARCHAR (MAX) NOT NULL,
    [apikey]      VARCHAR (MAX) NOT NULL,
    [userid]      VARCHAR (MAX) NOT NULL,
    [baseurl]     VARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

