USE [CM]
GO

INSERT INTO [dbo].[tbl_Client]
           ([ClientSSN]
		   ,[ClientFirstName]
           ,[ClientMiddleName]
           ,[ClientLastName]
           ,[Active]
           ,[DateAdded]
           ,[RepresentativeID])
     VALUES
           ('111223333'
		   ,'Mark'
           ,''
           ,'Zackerburgh'
           ,1
           ,GETDATE()
           ,1)
		   INSERT INTO [dbo].[tbl_Client]
           ([ClientSSN]
		   ,[ClientFirstName]
           ,[ClientMiddleName]
           ,[ClientLastName]
           ,[Active]
           ,[DateAdded]
           ,[RepresentativeID])
     VALUES
           ('222334444'
		   ,'Bill'
           ,''
           ,'Gates'
           ,1
           ,GETDATE()
           ,1)
GO


