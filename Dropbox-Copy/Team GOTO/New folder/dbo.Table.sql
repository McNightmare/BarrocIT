CREATE TABLE [dbo].[Table]
(
	[Company_ID] VARCHAR(20) NOT NULL PRIMARY KEY, 
    [Company_Name] VARCHAR(50) NOT NULL, 
    [Address1] VARCHAR(50) NOT NULL, 
    [Zipcode1] VARCHAR(8) NOT NULL, 
    [Address2] VARCHAR(50) NULL, 
    [Zipcode2] VARCHAR(8) NULL, 
    [Residence1] VARCHAR(50) NULL, 
    [Residence2] VARCHAR(50) NULL, 
    [Contact_Person] VARCHAR(50) NULL, 
    [Initials] VARCHAR(10) NULL, 
    [Telephone_Nr1] INT NOT NULL, 
    [Telephone_Nr2] INT NULL, 
    [Fax_Nr] INT NULL, 
    [Email] VARCHAR(50) NOT NULL
)
