CREATE TABLE [dbo].[Goals] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [State]       INT          NOT NULL,
    [Title]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Goals] PRIMARY KEY CLUSTERED ([ID] ASC)
);

