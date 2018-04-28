CREATE TABLE [dbo].[tbl_Representative] (
    [RepresentativeID] INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]        NVARCHAR (50) NULL,
    [MiddleName]       NVARCHAR (50) NULL,
    [LastName]         NVARCHAR (50) NULL,
    [Active]           BIT           NULL,
    [DateAdded]        DATE          NULL,
    [UserID]           INT           NULL,
    PRIMARY KEY CLUSTERED ([RepresentativeID] ASC)
);

