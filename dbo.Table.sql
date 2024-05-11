CREATE TABLE [dbo].[Users]
(
	[id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY ,
	[firstname] NVARCHAR (64) NOT NULL,
	[lastname] NVARCHAR (64),
	[sex] BIT,
	[age] INT,
	[state] NVARCHAR (64),
	[email] NVARCHAR (64) NOT NULL,
	[username] NVARCHAR (64) NOT NULL,
	[password] NVARCHAR (64) NOT NULL,
);
