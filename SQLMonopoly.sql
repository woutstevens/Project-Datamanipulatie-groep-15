CREATE TABLE [dbo].[Spelvak]
(
		[id]				int			IDENTITY(1,1),
		[naam]				varchar(45)		Not Null,
		[type]				varchar(45)		Not Null,
		[kleur]				varchar(45)		Null,
		[spelerId]			int				Null,
		[prijsMet1Huis]		int				Null,
		[prijsMet2Huizen]	int				Null,
		[prijsMet3Huizen]	int				Null,
		[prijsMet4Huizen]	int				Null,
		[prijsMet1Hotel]	int				Null,
		[aantalHuizen]		int				Null,
		[aantalHotels]		int				Null,
		[prijsPerHotel]		int				Null,
		[prijsPerHuis]		int				Null,
		[aankoopwaarde]		int				Not Null,
		[hypotheekwaarde]	int				Not Null,
		[aantalOgen]		int				Null,
		CONSTRAINT [PK_Spelvak] PRIMARY KEY ([id])
);


CREATE TABLE [dbo].[Speler]
(
		[id]				int			IDENTITY(1,1),
		[naam]				varchar(45)		Not Null,
		[figuur]			varchar(45)		Not Null,
		[spelvakId]			int				Null,
		[huidigSaldo]		int				Null,
		[gevangenis]		bit				Not Null,
		[verlaatGevangenis]	int				Null,
		CONSTRAINT [PK_Speler] PRIMARY KEY ([id])
);

CREATE TABLE [dbo].[Kans]
(
		[id]				int			IDENTITY(1,1),
		[naam]				varchar(45)		Not Null,
		[type]				varchar(45)		Not Null,
		[omschrijving]		varchar(45)		Null,
		[bedrag]			int				Null,
		[aantalPosities]	int				Null,
		[houbij]			bit				Not Null,
		CONSTRAINT [PK_Kans] PRIMARY KEY ([id]),

);

CREATE TABLE [dbo].[AlgemeenFonds]
(
		[id]				int			IDENTITY(1,1),
		[naam]				varchar(45)		Not Null,
		[type]				varchar(45)		Not Null,
		[omschrijving]		varchar(45)		Null,
		[bedrag]			int				Null,
		[aantalPosities]	int				Null,
		[houbij]			bit				Not Null,
		CONSTRAINT [PK_AlgemeenFonds] PRIMARY KEY ([id]),

);

ALTER TABLE [dbo].[Spelvak]
ADD CONSTRAINT [FK_Project_Speler] FOREIGN KEY ([spelerId])
			REFERENCES [dbo].[Speler]([id]) 