CREATE TABLE [dbo].[Users] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [username]  NVARCHAR (64) NOT NULL,
    [password]  NVARCHAR (64) NOT NULL,
    [firstname] NVARCHAR (64) NOT NULL,
    [lastname]  NVARCHAR (64) NOT NULL,
    [sex]       BIT           NOT NULL,
    [age]       INT           NOT NULL,
    [state]     NVARCHAR (64) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[Games] (
    [id]     INT            IDENTITY (1, 1) NOT NULL,
    [game]   NVARCHAR (512) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

