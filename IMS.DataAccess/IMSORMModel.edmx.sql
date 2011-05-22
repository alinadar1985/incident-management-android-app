
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/18/2011 23:38:36
-- Generated from EDMX file: C:\Users\laimer\Documents\Repository\IMS\IMS.DataAccess\IMSORMModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [IMS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_OnSiteOperatorReport]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reports] DROP CONSTRAINT [FK_OnSiteOperatorReport];
GO
IF OBJECT_ID(N'[dbo].[FK_ReportPhoto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Photo] DROP CONSTRAINT [FK_ReportPhoto];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[OnSiteOperators]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OnSiteOperators];
GO
IF OBJECT_ID(N'[dbo].[Reports]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reports];
GO
IF OBJECT_ID(N'[dbo].[Photo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Photo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'OnSiteOperators'
CREATE TABLE [dbo].[OnSiteOperators] (
    [OperatorID] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Reports'
CREATE TABLE [dbo].[Reports] (
    [ReportID] uniqueidentifier  NOT NULL,
    [OperatorID] uniqueidentifier  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [Priority] nvarchar(15)  NOT NULL,
    [Location] nvarchar(25)  NOT NULL
);
GO

-- Creating table 'Photo'
CREATE TABLE [dbo].[Photo] (
    [ContentMd5] uniqueidentifier  NOT NULL,
    [ReportID] uniqueidentifier  NOT NULL,
    [UploadStatus] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [OperatorID] in table 'OnSiteOperators'
ALTER TABLE [dbo].[OnSiteOperators]
ADD CONSTRAINT [PK_OnSiteOperators]
    PRIMARY KEY CLUSTERED ([OperatorID] ASC);
GO

-- Creating primary key on [ReportID] in table 'Reports'
ALTER TABLE [dbo].[Reports]
ADD CONSTRAINT [PK_Reports]
    PRIMARY KEY CLUSTERED ([ReportID] ASC);
GO

-- Creating primary key on [ContentMd5] in table 'Photo'
ALTER TABLE [dbo].[Photo]
ADD CONSTRAINT [PK_Photo]
    PRIMARY KEY CLUSTERED ([ContentMd5] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [OperatorID] in table 'Reports'
ALTER TABLE [dbo].[Reports]
ADD CONSTRAINT [FK_OnSiteOperatorReport]
    FOREIGN KEY ([OperatorID])
    REFERENCES [dbo].[OnSiteOperators]
        ([OperatorID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OnSiteOperatorReport'
CREATE INDEX [IX_FK_OnSiteOperatorReport]
ON [dbo].[Reports]
    ([OperatorID]);
GO

-- Creating foreign key on [ReportID] in table 'Photo'
ALTER TABLE [dbo].[Photo]
ADD CONSTRAINT [FK_ReportPhoto]
    FOREIGN KEY ([ReportID])
    REFERENCES [dbo].[Reports]
        ([ReportID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ReportPhoto'
CREATE INDEX [IX_FK_ReportPhoto]
ON [dbo].[Photo]
    ([ReportID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------