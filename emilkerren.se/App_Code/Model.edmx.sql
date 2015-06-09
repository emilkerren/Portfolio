
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/14/2014 16:29:43
-- Generated from EDMX file: C:\Users\Emil\Documents\Ballou\emilkerren.se\App_Code\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [fuohulnwTradoorDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MemberSet'
CREATE TABLE [dbo].[MemberSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Admin] bit  NOT NULL,
    [Jobcreator] bit  NOT NULL,
    [Telephone] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PostSet'
CREATE TABLE [dbo].[PostSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [MemberId] int  NOT NULL,
    [JobId] int  NOT NULL,
    [Job_Id] int  NOT NULL
);
GO

-- Creating table 'TagSet'
CREATE TABLE [dbo].[TagSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TagWord] nvarchar(max)  NOT NULL,
    [MemberId] int  NOT NULL
);
GO

-- Creating table 'JobSet'
CREATE TABLE [dbo].[JobSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Category] nvarchar(max)  NOT NULL,
    [Location] nvarchar(max)  NOT NULL,
    [AskingPrice] nvarchar(max)  NOT NULL,
    [MemberId] int  NOT NULL
);
GO

-- Creating table 'RatingSet'
CREATE TABLE [dbo].[RatingSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Num] int  NOT NULL,
    [MemberId] int  NOT NULL
);
GO

-- Creating table 'BidSet'
CREATE TABLE [dbo].[BidSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Price] float  NOT NULL,
    [MemberId] int  NOT NULL,
    [JobId] int  NOT NULL
);
GO

-- Creating table 'JobBidders'
CREATE TABLE [dbo].[JobBidders] (
    [Member_Id] int  NOT NULL,
    [Job_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'MemberSet'
ALTER TABLE [dbo].[MemberSet]
ADD CONSTRAINT [PK_MemberSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PostSet'
ALTER TABLE [dbo].[PostSet]
ADD CONSTRAINT [PK_PostSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TagSet'
ALTER TABLE [dbo].[TagSet]
ADD CONSTRAINT [PK_TagSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JobSet'
ALTER TABLE [dbo].[JobSet]
ADD CONSTRAINT [PK_JobSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RatingSet'
ALTER TABLE [dbo].[RatingSet]
ADD CONSTRAINT [PK_RatingSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BidSet'
ALTER TABLE [dbo].[BidSet]
ADD CONSTRAINT [PK_BidSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Member_Id], [Job_Id] in table 'JobBidders'
ALTER TABLE [dbo].[JobBidders]
ADD CONSTRAINT [PK_JobBidders]
    PRIMARY KEY CLUSTERED ([Member_Id], [Job_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MemberId] in table 'JobSet'
ALTER TABLE [dbo].[JobSet]
ADD CONSTRAINT [FK_UserJob]
    FOREIGN KEY ([MemberId])
    REFERENCES [dbo].[MemberSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserJob'
CREATE INDEX [IX_FK_UserJob]
ON [dbo].[JobSet]
    ([MemberId]);
GO

-- Creating foreign key on [Member_Id] in table 'JobBidders'
ALTER TABLE [dbo].[JobBidders]
ADD CONSTRAINT [FK_JobBidders_Member]
    FOREIGN KEY ([Member_Id])
    REFERENCES [dbo].[MemberSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Job_Id] in table 'JobBidders'
ALTER TABLE [dbo].[JobBidders]
ADD CONSTRAINT [FK_JobBidders_Job]
    FOREIGN KEY ([Job_Id])
    REFERENCES [dbo].[JobSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_JobBidders_Job'
CREATE INDEX [IX_FK_JobBidders_Job]
ON [dbo].[JobBidders]
    ([Job_Id]);
GO

-- Creating foreign key on [MemberId] in table 'PostSet'
ALTER TABLE [dbo].[PostSet]
ADD CONSTRAINT [FK_UserPost]
    FOREIGN KEY ([MemberId])
    REFERENCES [dbo].[MemberSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPost'
CREATE INDEX [IX_FK_UserPost]
ON [dbo].[PostSet]
    ([MemberId]);
GO

-- Creating foreign key on [MemberId] in table 'RatingSet'
ALTER TABLE [dbo].[RatingSet]
ADD CONSTRAINT [FK_UserRating]
    FOREIGN KEY ([MemberId])
    REFERENCES [dbo].[MemberSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRating'
CREATE INDEX [IX_FK_UserRating]
ON [dbo].[RatingSet]
    ([MemberId]);
GO

-- Creating foreign key on [MemberId] in table 'BidSet'
ALTER TABLE [dbo].[BidSet]
ADD CONSTRAINT [FK_UserBid]
    FOREIGN KEY ([MemberId])
    REFERENCES [dbo].[MemberSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserBid'
CREATE INDEX [IX_FK_UserBid]
ON [dbo].[BidSet]
    ([MemberId]);
GO

-- Creating foreign key on [JobId] in table 'BidSet'
ALTER TABLE [dbo].[BidSet]
ADD CONSTRAINT [FK_BidJob]
    FOREIGN KEY ([JobId])
    REFERENCES [dbo].[JobSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BidJob'
CREATE INDEX [IX_FK_BidJob]
ON [dbo].[BidSet]
    ([JobId]);
GO

-- Creating foreign key on [MemberId] in table 'TagSet'
ALTER TABLE [dbo].[TagSet]
ADD CONSTRAINT [FK_TagMember]
    FOREIGN KEY ([MemberId])
    REFERENCES [dbo].[MemberSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TagMember'
CREATE INDEX [IX_FK_TagMember]
ON [dbo].[TagSet]
    ([MemberId]);
GO

-- Creating foreign key on [Job_Id] in table 'PostSet'
ALTER TABLE [dbo].[PostSet]
ADD CONSTRAINT [FK_PostJob]
    FOREIGN KEY ([Job_Id])
    REFERENCES [dbo].[JobSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PostJob'
CREATE INDEX [IX_FK_PostJob]
ON [dbo].[PostSet]
    ([Job_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------