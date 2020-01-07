CREATE TABLE [dbo].[DB_Config] (
    [Branch]    VARCHAR (256)  NOT NULL,
    [SubBranch] VARCHAR (256)  NOT NULL,
    [Key]       VARCHAR (256)  NOT NULL,
    [Value]     VARCHAR (7000) NULL,
    CONSTRAINT [PK_DB_Config] PRIMARY KEY CLUSTERED ([Branch] ASC, [SubBranch] ASC, [Key] ASC)
);

