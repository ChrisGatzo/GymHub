
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/10/2015 19:02:03
-- Generated from EDMX file: C:\Users\chris\Documents\Git Hub ShowCase\GymHub\GymHub\DataAccess\DomainModels\GymHubModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GymHubDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TraineeCheckIns_Trainees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TraineeCheckIns] DROP CONSTRAINT [FK_TraineeCheckIns_Trainees];
GO
IF OBJECT_ID(N'[dbo].[FK_TraineeStatistics_Exercises]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TraineeStatistics] DROP CONSTRAINT [FK_TraineeStatistics_Exercises];
GO
IF OBJECT_ID(N'[dbo].[FK_TraineeStatistics_Trainees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TraineeStatistics] DROP CONSTRAINT [FK_TraineeStatistics_Trainees];
GO
IF OBJECT_ID(N'[dbo].[FK_TrainingSchedules_Exercises]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TrainingSchedules] DROP CONSTRAINT [FK_TrainingSchedules_Exercises];
GO
IF OBJECT_ID(N'[dbo].[FK_TrainingSchedules_Programs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TrainingSchedules] DROP CONSTRAINT [FK_TrainingSchedules_Programs];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Exercises]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Exercises];
GO
IF OBJECT_ID(N'[dbo].[Programs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Programs];
GO
IF OBJECT_ID(N'[dbo].[TraineeCheckIns]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TraineeCheckIns];
GO
IF OBJECT_ID(N'[dbo].[Trainees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trainees];
GO
IF OBJECT_ID(N'[dbo].[TraineeStatistics]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TraineeStatistics];
GO
IF OBJECT_ID(N'[dbo].[TrainingSchedules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrainingSchedules];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Exercises'
CREATE TABLE [dbo].[Exercises] (
    [Id] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Programs'
CREATE TABLE [dbo].[Programs] (
    [Id] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'TraineeCheckIns'
CREATE TABLE [dbo].[TraineeCheckIns] (
    [Id] int  NOT NULL,
    [TraineeId] int  NOT NULL,
    [CheckInDateTime] datetime  NOT NULL
);
GO

-- Creating table 'Trainees'
CREATE TABLE [dbo].[Trainees] (
    [Id] int  NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [AspNetUserId] nvarchar(128)  NULL
);
GO

-- Creating table 'TraineeStatistics'
CREATE TABLE [dbo].[TraineeStatistics] (
    [Id] int  NOT NULL,
    [TraineeId] int  NOT NULL,
    [ExerciseId] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [Weight] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'TrainingSchedules'
CREATE TABLE [dbo].[TrainingSchedules] (
    [Id] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [ProgramId] int  NOT NULL,
    [ExerciseId] int  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Exercises'
ALTER TABLE [dbo].[Exercises]
ADD CONSTRAINT [PK_Exercises]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Programs'
ALTER TABLE [dbo].[Programs]
ADD CONSTRAINT [PK_Programs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TraineeCheckIns'
ALTER TABLE [dbo].[TraineeCheckIns]
ADD CONSTRAINT [PK_TraineeCheckIns]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Trainees'
ALTER TABLE [dbo].[Trainees]
ADD CONSTRAINT [PK_Trainees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TraineeStatistics'
ALTER TABLE [dbo].[TraineeStatistics]
ADD CONSTRAINT [PK_TraineeStatistics]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TrainingSchedules'
ALTER TABLE [dbo].[TrainingSchedules]
ADD CONSTRAINT [PK_TrainingSchedules]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ExerciseId] in table 'TraineeStatistics'
ALTER TABLE [dbo].[TraineeStatistics]
ADD CONSTRAINT [FK_TraineeStatistics_Exercises]
    FOREIGN KEY ([ExerciseId])
    REFERENCES [dbo].[Exercises]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TraineeStatistics_Exercises'
CREATE INDEX [IX_FK_TraineeStatistics_Exercises]
ON [dbo].[TraineeStatistics]
    ([ExerciseId]);
GO

-- Creating foreign key on [ExerciseId] in table 'TrainingSchedules'
ALTER TABLE [dbo].[TrainingSchedules]
ADD CONSTRAINT [FK_TrainingSchedules_Exercises]
    FOREIGN KEY ([ExerciseId])
    REFERENCES [dbo].[Exercises]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrainingSchedules_Exercises'
CREATE INDEX [IX_FK_TrainingSchedules_Exercises]
ON [dbo].[TrainingSchedules]
    ([ExerciseId]);
GO

-- Creating foreign key on [ProgramId] in table 'TrainingSchedules'
ALTER TABLE [dbo].[TrainingSchedules]
ADD CONSTRAINT [FK_TrainingSchedules_Programs]
    FOREIGN KEY ([ProgramId])
    REFERENCES [dbo].[Programs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrainingSchedules_Programs'
CREATE INDEX [IX_FK_TrainingSchedules_Programs]
ON [dbo].[TrainingSchedules]
    ([ProgramId]);
GO

-- Creating foreign key on [TraineeId] in table 'TraineeCheckIns'
ALTER TABLE [dbo].[TraineeCheckIns]
ADD CONSTRAINT [FK_TraineeCheckIns_Trainees]
    FOREIGN KEY ([TraineeId])
    REFERENCES [dbo].[Trainees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TraineeCheckIns_Trainees'
CREATE INDEX [IX_FK_TraineeCheckIns_Trainees]
ON [dbo].[TraineeCheckIns]
    ([TraineeId]);
GO

-- Creating foreign key on [TraineeId] in table 'TraineeStatistics'
ALTER TABLE [dbo].[TraineeStatistics]
ADD CONSTRAINT [FK_TraineeStatistics_Trainees]
    FOREIGN KEY ([TraineeId])
    REFERENCES [dbo].[Trainees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TraineeStatistics_Trainees'
CREATE INDEX [IX_FK_TraineeStatistics_Trainees]
ON [dbo].[TraineeStatistics]
    ([TraineeId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [AspNetUserId] in table 'Trainees'
ALTER TABLE [dbo].[Trainees]
ADD CONSTRAINT [FK_Trainees_AspNetUsers]
    FOREIGN KEY ([AspNetUserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Trainees_AspNetUsers'
CREATE INDEX [IX_FK_Trainees_AspNetUsers]
ON [dbo].[Trainees]
    ([AspNetUserId]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

ALTER DATABASE GymHubDB SET ENABLE_BROKER

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------