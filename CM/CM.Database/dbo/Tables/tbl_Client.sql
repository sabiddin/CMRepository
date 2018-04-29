CREATE TABLE [dbo].[tbl_Client] (
    [ClientID]         INT           IDENTITY (1, 1) NOT NULL,
    [ClientSSN]        NVARCHAR (9)  NOT NULL,
    [ClientFirstName]  NVARCHAR (50) NULL,
    [ClientMiddleName] NVARCHAR (50) NULL,
    [ClientLastName]   NVARCHAR (50) NULL,
    [Active]           BIT           NULL,
    [DateAdded]        DATE          NULL,
    [RepresentativeID] INT           NULL,
    PRIMARY KEY CLUSTERED ([ClientID] ASC)
);

