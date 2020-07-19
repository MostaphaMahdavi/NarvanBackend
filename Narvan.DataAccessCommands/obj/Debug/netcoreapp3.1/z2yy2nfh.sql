IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Roles] (
    [Id] bigint NOT NULL IDENTITY,
    [IsDelete] bit NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [Title] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Users] (
    [Id] bigint NOT NULL IDENTITY,
    [IsDelete] bit NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NOT NULL,
    [Email] nvarchar(250) NOT NULL,
    [FirstName] nvarchar(250) NOT NULL,
    [LastName] nvarchar(250) NOT NULL,
    [Address] nvarchar(500) NOT NULL,
    [EmailActiveCode] nvarchar(max) NULL,
    [IsActivated] bit NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [UserRoles] (
    [Id] bigint NOT NULL IDENTITY,
    [IsDelete] bit NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NOT NULL,
    [UserId] bigint NOT NULL,
    [RoleId] bigint NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_UserRoles_RoleId] ON [UserRoles] ([RoleId]);

GO

CREATE INDEX [IX_UserRoles_UserId] ON [UserRoles] ([UserId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200706074754_init_001', N'3.1.5');

GO

ALTER TABLE [UserRoles] DROP CONSTRAINT [FK_UserRoles_Roles_RoleId];

GO

ALTER TABLE [UserRoles] DROP CONSTRAINT [FK_UserRoles_Users_UserId];

GO

ALTER TABLE [UserRoles] DROP CONSTRAINT [PK_UserRoles];

GO

EXEC sp_rename N'[UserRoles]', N'UserRole';

GO

EXEC sp_rename N'[UserRole].[IX_UserRoles_UserId]', N'IX_UserRole_UserId', N'INDEX';

GO

EXEC sp_rename N'[UserRole].[IX_UserRoles_RoleId]', N'IX_UserRole_RoleId', N'INDEX';

GO

ALTER TABLE [UserRole] ADD CONSTRAINT [PK_UserRole] PRIMARY KEY ([Id]);

GO

CREATE TABLE [ProductCategory] (
    [Id] bigint NOT NULL IDENTITY,
    [IsDelete] bit NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NOT NULL,
    [Title] nvarchar(250) NOT NULL,
    [ParentId] bigint NULL,
    CONSTRAINT [PK_ProductCategory] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductCategory_ProductCategory_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [ProductCategory] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Products] (
    [Id] bigint NOT NULL IDENTITY,
    [IsDelete] bit NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NOT NULL,
    [ProductName] nvarchar(250) NOT NULL,
    [Price] int NOT NULL,
    [ShortDescription] nvarchar(700) NOT NULL,
    [Description] nvarchar(3900) NOT NULL,
    [ImageName] nvarchar(max) NOT NULL,
    [IsExists] bit NOT NULL,
    [IsSpecial] bit NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Slider] (
    [Id] bigint NOT NULL IDENTITY,
    [IsDelete] bit NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NOT NULL,
    [Title] nvarchar(100) NOT NULL,
    [Description] nvarchar(1000) NOT NULL,
    [ImageName] nvarchar(max) NOT NULL,
    [Link] nvarchar(150) NULL,
    CONSTRAINT [PK_Slider] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ProductGallery] (
    [Id] bigint NOT NULL IDENTITY,
    [IsDelete] bit NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NOT NULL,
    [ProductId] bigint NOT NULL,
    [ImageName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ProductGallery] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductGallery_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ProductSelectedCategory] (
    [Id] bigint NOT NULL IDENTITY,
    [IsDelete] bit NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NOT NULL,
    [ProductId] bigint NOT NULL,
    [ProductCategoryId] bigint NOT NULL,
    CONSTRAINT [PK_ProductSelectedCategory] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductSelectedCategory_ProductCategory_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategory] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductSelectedCategory_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ProductVisit] (
    [Id] bigint NOT NULL IDENTITY,
    [IsDelete] bit NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NOT NULL,
    [ProductId] bigint NOT NULL,
    [UserIp] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ProductVisit] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductVisit_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_ProductCategory_ParentId] ON [ProductCategory] ([ParentId]);

GO

CREATE INDEX [IX_ProductGallery_ProductId] ON [ProductGallery] ([ProductId]);

GO

CREATE INDEX [IX_ProductSelectedCategory_ProductCategoryId] ON [ProductSelectedCategory] ([ProductCategoryId]);

GO

CREATE INDEX [IX_ProductSelectedCategory_ProductId] ON [ProductSelectedCategory] ([ProductId]);

GO

CREATE INDEX [IX_ProductVisit_ProductId] ON [ProductVisit] ([ProductId]);

GO

ALTER TABLE [UserRole] ADD CONSTRAINT [FK_UserRole_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [UserRole] ADD CONSTRAINT [FK_UserRole_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200706132011_init_002', N'3.1.5');

GO

