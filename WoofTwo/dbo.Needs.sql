CREATE TABLE [dbo].[Needs] (
    [NeedsId] INT IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_dbo.Needs] PRIMARY KEY CLUSTERED ([NeedsId] ASC),

    CONSTRAINT [FK_dbo.Needs_dbo.Species_NeedsId] FOREIGN KEY ([NeedsId]) REFERENCES [dbo].[Species] ([SpeciesId])
	
);


GO
CREATE NONCLUSTERED INDEX [IX_NeedsId]
    ON [dbo].[Needs]([NeedsId] ASC);

