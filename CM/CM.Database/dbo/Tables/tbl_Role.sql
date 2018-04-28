CREATE TABLE [dbo].[tbl_Role] (
    [RoleID]    INT           IDENTITY (1, 1) NOT NULL,
    [RoleDesc]  NVARCHAR (50) NULL,
    [DateAdded] DATE          DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([RoleID] ASC)
);

