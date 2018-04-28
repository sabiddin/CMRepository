CREATE TABLE [dbo].[tbl_User] (
    [UserID]    INT           IDENTITY (1, 1) NOT NULL,
    [Username]  NVARCHAR (50) NULL,
    [Password]  NVARCHAR (50) NULL,
    [Locked]    BIT           NULL,
    [DateAdded] DATE          NULL,
    [RoleID]    INT           NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);



