CREATE TABLE [dbo].[tblWebsite] (
    [Id]   INT            NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[tblStatic] (
    [Id]         INT           NOT NULL,
    [DataCreate] DATETIME      NULL,
    [idWebSite]  INT           NULL,
    [Count]      INT           NULL,
    [Name]       VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
