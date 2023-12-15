CREATE DATABASE GetriDFAOnionArchi 
USE GetriDFAOnionArchi 


CREATE TABLE [dbo].[Users]
(
UserId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
UserName VARCHAR(50) NOT NULL,
Password VARCHAR(50) NOT NULL,
Email VARCHAR(50) NOT NULL,
ModifiedDate DATETIME,
IPAdress VARCHAR(50)
)

CREATE TABLE [dbo].[UserProfiles]
(
UserProfileId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
FirstName VARCHAR(50),
LastName VARCHAR(50),
Address1 VARCHAR(50),
Address2 VARCHAR(50),
ContactNo VARCHAR(50),
ModifiedDate DATETIME,
IPAddress varchar(50),
UserId int FOREIGN KEY REFERENCES [dbo].Users(UserId)
)
