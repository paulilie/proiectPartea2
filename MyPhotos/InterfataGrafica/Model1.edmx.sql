
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/23/2020 13:44:52
-- Generated from EDMX file: F:\pipau\Desktop\proiect .net\MyPhotos\MyPhotos\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Proiect];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MyItemsEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MyItems] DROP CONSTRAINT [FK_MyItemsEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_MyItemsPerson_MyItems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MyItemsPerson] DROP CONSTRAINT [FK_MyItemsPerson_MyItems];
GO
IF OBJECT_ID(N'[dbo].[FK_MyItemsPerson_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MyItemsPerson] DROP CONSTRAINT [FK_MyItemsPerson_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_MyItemsPlace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MyItems] DROP CONSTRAINT [FK_MyItemsPlace];
GO
IF OBJECT_ID(N'[dbo].[FK_MyItemsDinamic_MyItems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MyItemsDinamic] DROP CONSTRAINT [FK_MyItemsDinamic_MyItems];
GO
IF OBJECT_ID(N'[dbo].[FK_MyItemsDinamic_Dinamic]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MyItemsDinamic] DROP CONSTRAINT [FK_MyItemsDinamic_Dinamic];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[MyItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MyItems];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[Places]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Places];
GO
IF OBJECT_ID(N'[dbo].[People]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People];
GO
IF OBJECT_ID(N'[dbo].[Dinamics]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dinamics];
GO
IF OBJECT_ID(N'[dbo].[MyItemsPerson]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MyItemsPerson];
GO
IF OBJECT_ID(N'[dbo].[MyItemsDinamic]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MyItemsDinamic];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MyItems'
CREATE TABLE [dbo].[MyItems] (
    [IId] int IDENTITY(1,1) NOT NULL,
    [IPath] nvarchar(max)  NOT NULL,
    [IName] nvarchar(max)  NOT NULL,
    [IDescription] nvarchar(max)  NOT NULL,
    [IType] nvarchar(max)  NOT NULL,
    [IDate] nvarchar(max)  NOT NULL,
    [IIsPhoto] nvarchar(max)  NOT NULL,
    [IMark] nvarchar(max)  NOT NULL,
    [IDelete] nvarchar(max)  NOT NULL,
    [Event_EId] int  NULL,
    [Place_PID] int  NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [EId] int IDENTITY(1,1) NOT NULL,
    [EName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Places'
CREATE TABLE [dbo].[Places] (
    [PID] int IDENTITY(1,1) NOT NULL,
    [PName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [PId] int IDENTITY(1,1) NOT NULL,
    [PName] nvarchar(max)  NOT NULL,
    [PPrenume] nvarchar(max)  NOT NULL,
    [PType] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Dinamics'
CREATE TABLE [dbo].[Dinamics] (
    [DId] int IDENTITY(1,1) NOT NULL,
    [DDescription] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MyItemsPerson'
CREATE TABLE [dbo].[MyItemsPerson] (
    [MyItems_IId] int  NOT NULL,
    [People_PId] int  NOT NULL
);
GO

-- Creating table 'MyItemsDinamic'
CREATE TABLE [dbo].[MyItemsDinamic] (
    [MyItems_IId] int  NOT NULL,
    [Dinamics_DId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IId] in table 'MyItems'
ALTER TABLE [dbo].[MyItems]
ADD CONSTRAINT [PK_MyItems]
    PRIMARY KEY CLUSTERED ([IId] ASC);
GO

-- Creating primary key on [EId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([EId] ASC);
GO

-- Creating primary key on [PID] in table 'Places'
ALTER TABLE [dbo].[Places]
ADD CONSTRAINT [PK_Places]
    PRIMARY KEY CLUSTERED ([PID] ASC);
GO

-- Creating primary key on [PId] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([PId] ASC);
GO

-- Creating primary key on [DId] in table 'Dinamics'
ALTER TABLE [dbo].[Dinamics]
ADD CONSTRAINT [PK_Dinamics]
    PRIMARY KEY CLUSTERED ([DId] ASC);
GO

-- Creating primary key on [MyItems_IId], [People_PId] in table 'MyItemsPerson'
ALTER TABLE [dbo].[MyItemsPerson]
ADD CONSTRAINT [PK_MyItemsPerson]
    PRIMARY KEY CLUSTERED ([MyItems_IId], [People_PId] ASC);
GO

-- Creating primary key on [MyItems_IId], [Dinamics_DId] in table 'MyItemsDinamic'
ALTER TABLE [dbo].[MyItemsDinamic]
ADD CONSTRAINT [PK_MyItemsDinamic]
    PRIMARY KEY CLUSTERED ([MyItems_IId], [Dinamics_DId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Event_EId] in table 'MyItems'
ALTER TABLE [dbo].[MyItems]
ADD CONSTRAINT [FK_MyItemsEvent]
    FOREIGN KEY ([Event_EId])
    REFERENCES [dbo].[Events]
        ([EId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MyItemsEvent'
CREATE INDEX [IX_FK_MyItemsEvent]
ON [dbo].[MyItems]
    ([Event_EId]);
GO

-- Creating foreign key on [MyItems_IId] in table 'MyItemsPerson'
ALTER TABLE [dbo].[MyItemsPerson]
ADD CONSTRAINT [FK_MyItemsPerson_MyItems]
    FOREIGN KEY ([MyItems_IId])
    REFERENCES [dbo].[MyItems]
        ([IId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [People_PId] in table 'MyItemsPerson'
ALTER TABLE [dbo].[MyItemsPerson]
ADD CONSTRAINT [FK_MyItemsPerson_Person]
    FOREIGN KEY ([People_PId])
    REFERENCES [dbo].[People]
        ([PId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MyItemsPerson_Person'
CREATE INDEX [IX_FK_MyItemsPerson_Person]
ON [dbo].[MyItemsPerson]
    ([People_PId]);
GO

-- Creating foreign key on [Place_PID] in table 'MyItems'
ALTER TABLE [dbo].[MyItems]
ADD CONSTRAINT [FK_MyItemsPlace]
    FOREIGN KEY ([Place_PID])
    REFERENCES [dbo].[Places]
        ([PID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MyItemsPlace'
CREATE INDEX [IX_FK_MyItemsPlace]
ON [dbo].[MyItems]
    ([Place_PID]);
GO

-- Creating foreign key on [MyItems_IId] in table 'MyItemsDinamic'
ALTER TABLE [dbo].[MyItemsDinamic]
ADD CONSTRAINT [FK_MyItemsDinamic_MyItems]
    FOREIGN KEY ([MyItems_IId])
    REFERENCES [dbo].[MyItems]
        ([IId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Dinamics_DId] in table 'MyItemsDinamic'
ALTER TABLE [dbo].[MyItemsDinamic]
ADD CONSTRAINT [FK_MyItemsDinamic_Dinamic]
    FOREIGN KEY ([Dinamics_DId])
    REFERENCES [dbo].[Dinamics]
        ([DId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MyItemsDinamic_Dinamic'
CREATE INDEX [IX_FK_MyItemsDinamic_Dinamic]
ON [dbo].[MyItemsDinamic]
    ([Dinamics_DId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------