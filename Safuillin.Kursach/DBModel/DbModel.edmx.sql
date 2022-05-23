
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/22/2022 16:01:28
-- Generated from EDMX file: C:\Users\sabirov\Desktop\Safuillin.Kursach\Safuillin.Kursach\DBModel\DbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\USERS\SABIROV\DOCUMENTS\SAFUILLIN_12345.MDF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserReceipt_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserReceipt] DROP CONSTRAINT [FK_UserReceipt_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserReceipt_Receipt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserReceipt] DROP CONSTRAINT [FK_UserReceipt_Receipt];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Receipts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Receipts];
GO
IF OBJECT_ID(N'[dbo].[UserReceipt]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserReceipt];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Role] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Receipts'
CREATE TABLE [dbo].[Receipts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Desc] nvarchar(max)  NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Time] nvarchar(max)  NOT NULL,
    [Photo] varbinary(max)  NULL
);
GO

-- Creating table 'UserReceipt'
CREATE TABLE [dbo].[UserReceipt] (
    [User_Id] int  NOT NULL,
    [Receipt_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Receipts'
ALTER TABLE [dbo].[Receipts]
ADD CONSTRAINT [PK_Receipts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [User_Id], [Receipt_Id] in table 'UserReceipt'
ALTER TABLE [dbo].[UserReceipt]
ADD CONSTRAINT [PK_UserReceipt]
    PRIMARY KEY CLUSTERED ([User_Id], [Receipt_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'UserReceipt'
ALTER TABLE [dbo].[UserReceipt]
ADD CONSTRAINT [FK_UserReceipt_User]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Receipt_Id] in table 'UserReceipt'
ALTER TABLE [dbo].[UserReceipt]
ADD CONSTRAINT [FK_UserReceipt_Receipt]
    FOREIGN KEY ([Receipt_Id])
    REFERENCES [dbo].[Receipts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserReceipt_Receipt'
CREATE INDEX [IX_FK_UserReceipt_Receipt]
ON [dbo].[UserReceipt]
    ([Receipt_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------