
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/08/2018 15:12:56
-- Generated from EDMX file: F:\框架源码\DbContextScope-master\Model.Entity\Authority\Authority.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Test];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_GroupUser_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupUser] DROP CONSTRAINT [FK_GroupUser_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupUser_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupUser] DROP CONSTRAINT [FK_GroupUser_User];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleUser_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleUser] DROP CONSTRAINT [FK_RoleUser_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleUser_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleUser] DROP CONSTRAINT [FK_RoleUser_User];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupRole_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupRole] DROP CONSTRAINT [FK_GroupRole_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupRole_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupRole] DROP CONSTRAINT [FK_GroupRole_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_MenuAuthority_Menu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MenuAuthority] DROP CONSTRAINT [FK_MenuAuthority_Menu];
GO
IF OBJECT_ID(N'[dbo].[FK_MenuAuthority_Authority]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MenuAuthority] DROP CONSTRAINT [FK_MenuAuthority_Authority];
GO
IF OBJECT_ID(N'[dbo].[FK_FileAuthority_File]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileAuthority] DROP CONSTRAINT [FK_FileAuthority_File];
GO
IF OBJECT_ID(N'[dbo].[FK_FileAuthority_Authority]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileAuthority] DROP CONSTRAINT [FK_FileAuthority_Authority];
GO
IF OBJECT_ID(N'[dbo].[FK_PageElementAuthority_PageElement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PageElementAuthority] DROP CONSTRAINT [FK_PageElementAuthority_PageElement];
GO
IF OBJECT_ID(N'[dbo].[FK_PageElementAuthority_Authority]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PageElementAuthority] DROP CONSTRAINT [FK_PageElementAuthority_Authority];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionAuthority_Action]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionAuthority] DROP CONSTRAINT [FK_ActionAuthority_Action];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionAuthority_Authority]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionAuthority] DROP CONSTRAINT [FK_ActionAuthority_Authority];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleAuthority_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleAuthority] DROP CONSTRAINT [FK_RoleAuthority_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleAuthority_Authority]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleAuthority] DROP CONSTRAINT [FK_RoleAuthority_Authority];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupSet] DROP CONSTRAINT [FK_GroupGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_MenuMenu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MenuSet] DROP CONSTRAINT [FK_MenuMenu];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_UserUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[RoleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleSet];
GO
IF OBJECT_ID(N'[dbo].[AuthoritySet1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AuthoritySet1];
GO
IF OBJECT_ID(N'[dbo].[GroupSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupSet];
GO
IF OBJECT_ID(N'[dbo].[MenuSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MenuSet];
GO
IF OBJECT_ID(N'[dbo].[FileSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FileSet];
GO
IF OBJECT_ID(N'[dbo].[PageElementSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PageElementSet];
GO
IF OBJECT_ID(N'[dbo].[ActionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionSet];
GO
IF OBJECT_ID(N'[dbo].[GroupUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupUser];
GO
IF OBJECT_ID(N'[dbo].[RoleUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleUser];
GO
IF OBJECT_ID(N'[dbo].[GroupRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupRole];
GO
IF OBJECT_ID(N'[dbo].[MenuAuthority]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MenuAuthority];
GO
IF OBJECT_ID(N'[dbo].[FileAuthority]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FileAuthority];
GO
IF OBJECT_ID(N'[dbo].[PageElementAuthority]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PageElementAuthority];
GO
IF OBJECT_ID(N'[dbo].[ActionAuthority]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionAuthority];
GO
IF OBJECT_ID(N'[dbo].[RoleAuthority]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleAuthority];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [CreateDate] datetime  NULL,
    [CreateUser_Id] int  NOT NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(1000)  NULL
);
GO

-- Creating table 'Authority'
CREATE TABLE [dbo].[Authority] (
    [Id] bigint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Group'
CREATE TABLE [dbo].[Group] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(1000)  NULL,
    [Parent_Id] int  NOT NULL
);
GO

-- Creating table 'Menu'
CREATE TABLE [dbo].[Menu] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Url] nvarchar(max)  NOT NULL,
    [Parent_Id] int  NOT NULL
);
GO

-- Creating table 'File'
CREATE TABLE [dbo].[File] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FileName] nvarchar(50)  NOT NULL,
    [FilePath] nvarchar(max)  NOT NULL,
    [FileType] nvarchar(50)  NULL
);
GO

-- Creating table 'PageElement'
CREATE TABLE [dbo].[PageElement] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Code] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Action'
CREATE TABLE [dbo].[Action] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Url] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GroupUser'
CREATE TABLE [dbo].[GroupUser] (
    [Group_Id] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'RoleUser'
CREATE TABLE [dbo].[RoleUser] (
    [Role_Id] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'GroupRole'
CREATE TABLE [dbo].[GroupRole] (
    [Group_Id] int  NOT NULL,
    [Role_Id] int  NOT NULL
);
GO

-- Creating table 'MenuAuthority'
CREATE TABLE [dbo].[MenuAuthority] (
    [Menu_Id] int  NOT NULL,
    [Authority_Id] bigint  NOT NULL
);
GO

-- Creating table 'FileAuthority'
CREATE TABLE [dbo].[FileAuthority] (
    [File_Id] int  NOT NULL,
    [Authority_Id] bigint  NOT NULL
);
GO

-- Creating table 'PageElementAuthority'
CREATE TABLE [dbo].[PageElementAuthority] (
    [PageElement_Id] int  NOT NULL,
    [Authority_Id] bigint  NOT NULL
);
GO

-- Creating table 'ActionAuthority'
CREATE TABLE [dbo].[ActionAuthority] (
    [Action_Id] int  NOT NULL,
    [Authority_Id] bigint  NOT NULL
);
GO

-- Creating table 'RoleAuthority'
CREATE TABLE [dbo].[RoleAuthority] (
    [Role_Id] int  NOT NULL,
    [Authority_Id] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Authority'
ALTER TABLE [dbo].[Authority]
ADD CONSTRAINT [PK_Authority]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Group'
ALTER TABLE [dbo].[Group]
ADD CONSTRAINT [PK_Group]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Menu'
ALTER TABLE [dbo].[Menu]
ADD CONSTRAINT [PK_Menu]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'File'
ALTER TABLE [dbo].[File]
ADD CONSTRAINT [PK_File]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PageElement'
ALTER TABLE [dbo].[PageElement]
ADD CONSTRAINT [PK_PageElement]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Action'
ALTER TABLE [dbo].[Action]
ADD CONSTRAINT [PK_Action]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Group_Id], [User_Id] in table 'GroupUser'
ALTER TABLE [dbo].[GroupUser]
ADD CONSTRAINT [PK_GroupUser]
    PRIMARY KEY CLUSTERED ([Group_Id], [User_Id] ASC);
GO

-- Creating primary key on [Role_Id], [User_Id] in table 'RoleUser'
ALTER TABLE [dbo].[RoleUser]
ADD CONSTRAINT [PK_RoleUser]
    PRIMARY KEY CLUSTERED ([Role_Id], [User_Id] ASC);
GO

-- Creating primary key on [Group_Id], [Role_Id] in table 'GroupRole'
ALTER TABLE [dbo].[GroupRole]
ADD CONSTRAINT [PK_GroupRole]
    PRIMARY KEY CLUSTERED ([Group_Id], [Role_Id] ASC);
GO

-- Creating primary key on [Menu_Id], [Authority_Id] in table 'MenuAuthority'
ALTER TABLE [dbo].[MenuAuthority]
ADD CONSTRAINT [PK_MenuAuthority]
    PRIMARY KEY CLUSTERED ([Menu_Id], [Authority_Id] ASC);
GO

-- Creating primary key on [File_Id], [Authority_Id] in table 'FileAuthority'
ALTER TABLE [dbo].[FileAuthority]
ADD CONSTRAINT [PK_FileAuthority]
    PRIMARY KEY CLUSTERED ([File_Id], [Authority_Id] ASC);
GO

-- Creating primary key on [PageElement_Id], [Authority_Id] in table 'PageElementAuthority'
ALTER TABLE [dbo].[PageElementAuthority]
ADD CONSTRAINT [PK_PageElementAuthority]
    PRIMARY KEY CLUSTERED ([PageElement_Id], [Authority_Id] ASC);
GO

-- Creating primary key on [Action_Id], [Authority_Id] in table 'ActionAuthority'
ALTER TABLE [dbo].[ActionAuthority]
ADD CONSTRAINT [PK_ActionAuthority]
    PRIMARY KEY CLUSTERED ([Action_Id], [Authority_Id] ASC);
GO

-- Creating primary key on [Role_Id], [Authority_Id] in table 'RoleAuthority'
ALTER TABLE [dbo].[RoleAuthority]
ADD CONSTRAINT [PK_RoleAuthority]
    PRIMARY KEY CLUSTERED ([Role_Id], [Authority_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Group_Id] in table 'GroupUser'
ALTER TABLE [dbo].[GroupUser]
ADD CONSTRAINT [FK_GroupUser_Group]
    FOREIGN KEY ([Group_Id])
    REFERENCES [dbo].[Group]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [User_Id] in table 'GroupUser'
ALTER TABLE [dbo].[GroupUser]
ADD CONSTRAINT [FK_GroupUser_User]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupUser_User'
CREATE INDEX [IX_FK_GroupUser_User]
ON [dbo].[GroupUser]
    ([User_Id]);
GO

-- Creating foreign key on [Role_Id] in table 'RoleUser'
ALTER TABLE [dbo].[RoleUser]
ADD CONSTRAINT [FK_RoleUser_Role]
    FOREIGN KEY ([Role_Id])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [User_Id] in table 'RoleUser'
ALTER TABLE [dbo].[RoleUser]
ADD CONSTRAINT [FK_RoleUser_User]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleUser_User'
CREATE INDEX [IX_FK_RoleUser_User]
ON [dbo].[RoleUser]
    ([User_Id]);
GO

-- Creating foreign key on [Group_Id] in table 'GroupRole'
ALTER TABLE [dbo].[GroupRole]
ADD CONSTRAINT [FK_GroupRole_Group]
    FOREIGN KEY ([Group_Id])
    REFERENCES [dbo].[Group]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Role_Id] in table 'GroupRole'
ALTER TABLE [dbo].[GroupRole]
ADD CONSTRAINT [FK_GroupRole_Role]
    FOREIGN KEY ([Role_Id])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupRole_Role'
CREATE INDEX [IX_FK_GroupRole_Role]
ON [dbo].[GroupRole]
    ([Role_Id]);
GO

-- Creating foreign key on [Menu_Id] in table 'MenuAuthority'
ALTER TABLE [dbo].[MenuAuthority]
ADD CONSTRAINT [FK_MenuAuthority_Menu]
    FOREIGN KEY ([Menu_Id])
    REFERENCES [dbo].[Menu]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Authority_Id] in table 'MenuAuthority'
ALTER TABLE [dbo].[MenuAuthority]
ADD CONSTRAINT [FK_MenuAuthority_Authority]
    FOREIGN KEY ([Authority_Id])
    REFERENCES [dbo].[Authority]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MenuAuthority_Authority'
CREATE INDEX [IX_FK_MenuAuthority_Authority]
ON [dbo].[MenuAuthority]
    ([Authority_Id]);
GO

-- Creating foreign key on [File_Id] in table 'FileAuthority'
ALTER TABLE [dbo].[FileAuthority]
ADD CONSTRAINT [FK_FileAuthority_File]
    FOREIGN KEY ([File_Id])
    REFERENCES [dbo].[File]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Authority_Id] in table 'FileAuthority'
ALTER TABLE [dbo].[FileAuthority]
ADD CONSTRAINT [FK_FileAuthority_Authority]
    FOREIGN KEY ([Authority_Id])
    REFERENCES [dbo].[Authority]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FileAuthority_Authority'
CREATE INDEX [IX_FK_FileAuthority_Authority]
ON [dbo].[FileAuthority]
    ([Authority_Id]);
GO

-- Creating foreign key on [PageElement_Id] in table 'PageElementAuthority'
ALTER TABLE [dbo].[PageElementAuthority]
ADD CONSTRAINT [FK_PageElementAuthority_PageElement]
    FOREIGN KEY ([PageElement_Id])
    REFERENCES [dbo].[PageElement]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Authority_Id] in table 'PageElementAuthority'
ALTER TABLE [dbo].[PageElementAuthority]
ADD CONSTRAINT [FK_PageElementAuthority_Authority]
    FOREIGN KEY ([Authority_Id])
    REFERENCES [dbo].[Authority]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PageElementAuthority_Authority'
CREATE INDEX [IX_FK_PageElementAuthority_Authority]
ON [dbo].[PageElementAuthority]
    ([Authority_Id]);
GO

-- Creating foreign key on [Action_Id] in table 'ActionAuthority'
ALTER TABLE [dbo].[ActionAuthority]
ADD CONSTRAINT [FK_ActionAuthority_Action]
    FOREIGN KEY ([Action_Id])
    REFERENCES [dbo].[Action]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Authority_Id] in table 'ActionAuthority'
ALTER TABLE [dbo].[ActionAuthority]
ADD CONSTRAINT [FK_ActionAuthority_Authority]
    FOREIGN KEY ([Authority_Id])
    REFERENCES [dbo].[Authority]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionAuthority_Authority'
CREATE INDEX [IX_FK_ActionAuthority_Authority]
ON [dbo].[ActionAuthority]
    ([Authority_Id]);
GO

-- Creating foreign key on [Role_Id] in table 'RoleAuthority'
ALTER TABLE [dbo].[RoleAuthority]
ADD CONSTRAINT [FK_RoleAuthority_Role]
    FOREIGN KEY ([Role_Id])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Authority_Id] in table 'RoleAuthority'
ALTER TABLE [dbo].[RoleAuthority]
ADD CONSTRAINT [FK_RoleAuthority_Authority]
    FOREIGN KEY ([Authority_Id])
    REFERENCES [dbo].[Authority]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleAuthority_Authority'
CREATE INDEX [IX_FK_RoleAuthority_Authority]
ON [dbo].[RoleAuthority]
    ([Authority_Id]);
GO

-- Creating foreign key on [Parent_Id] in table 'Group'
ALTER TABLE [dbo].[Group]
ADD CONSTRAINT [FK_GroupGroup]
    FOREIGN KEY ([Parent_Id])
    REFERENCES [dbo].[Group]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupGroup'
CREATE INDEX [IX_FK_GroupGroup]
ON [dbo].[Group]
    ([Parent_Id]);
GO

-- Creating foreign key on [Parent_Id] in table 'Menu'
ALTER TABLE [dbo].[Menu]
ADD CONSTRAINT [FK_MenuMenu]
    FOREIGN KEY ([Parent_Id])
    REFERENCES [dbo].[Menu]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MenuMenu'
CREATE INDEX [IX_FK_MenuMenu]
ON [dbo].[Menu]
    ([Parent_Id]);
GO

-- Creating foreign key on [CreateUser_Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_UserUser]
    FOREIGN KEY ([CreateUser_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUser'
CREATE INDEX [IX_FK_UserUser]
ON [dbo].[User]
    ([CreateUser_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------