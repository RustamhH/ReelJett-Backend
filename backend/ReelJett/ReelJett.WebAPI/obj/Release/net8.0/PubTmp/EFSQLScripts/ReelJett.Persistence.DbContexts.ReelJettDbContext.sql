IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE TABLE [Movies] (
        [Id] nvarchar(450) NOT NULL,
        [Title] nvarchar(max) NOT NULL,
        [LikeCount] int NOT NULL,
        [ViewCount] int NOT NULL,
        [DislikeCount] int NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [LastModifiedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Movies] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE TABLE [ProffesionalMovies] (
        [Id] nvarchar(450) NOT NULL,
        [Year] nvarchar(max) NOT NULL,
        [Rated] nvarchar(max) NOT NULL,
        [Released] nvarchar(max) NOT NULL,
        [Runtime] nvarchar(max) NOT NULL,
        [Genre] nvarchar(max) NOT NULL,
        [Director] nvarchar(max) NOT NULL,
        [Writer] nvarchar(max) NOT NULL,
        [Actors] nvarchar(max) NOT NULL,
        [Plot] nvarchar(max) NOT NULL,
        [Language] nvarchar(max) NOT NULL,
        [Country] nvarchar(max) NOT NULL,
        [Awards] nvarchar(max) NOT NULL,
        [Poster] nvarchar(max) NOT NULL,
        [Metascore] nvarchar(max) NOT NULL,
        [imdbRating] nvarchar(max) NOT NULL,
        [imdbVotes] nvarchar(max) NOT NULL,
        [imdbID] nvarchar(max) NOT NULL,
        [Type] nvarchar(max) NOT NULL,
        [DVD] nvarchar(max) NOT NULL,
        [BoxOffice] nvarchar(max) NOT NULL,
        [Production] nvarchar(max) NOT NULL,
        [Website] nvarchar(max) NOT NULL,
        [Response] nvarchar(max) NOT NULL,
        [MovieId] nvarchar(450) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [LastModifiedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_ProffesionalMovies] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProffesionalMovies_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE TABLE [Ratings] (
        [Id] nvarchar(450) NOT NULL,
        [Source] nvarchar(max) NOT NULL,
        [Value] nvarchar(max) NOT NULL,
        [MovieId] nvarchar(450) NOT NULL,
        [ProffesionalMovieId] nvarchar(450) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [LastModifiedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Ratings] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Ratings_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Ratings_ProffesionalMovies_ProffesionalMovieId] FOREIGN KEY ([ProffesionalMovieId]) REFERENCES [ProffesionalMovies] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [LastModifiedAt] datetime2 NOT NULL,
        [ProfilePhoto] nvarchar(max) NOT NULL,
        [RoomId] nvarchar(450) NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE TABLE [Comments] (
        [Id] nvarchar(450) NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [LikeCount] int NOT NULL,
        [UserId] nvarchar(450) NOT NULL,
        [MovieId] nvarchar(450) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [LastModifiedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Comments] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Comments_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Comments_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE TABLE [HistoryLists] (
        [Id] nvarchar(450) NOT NULL,
        [UserId] nvarchar(450) NOT NULL,
        [MovieId] nvarchar(450) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [LastModifiedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_HistoryLists] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_HistoryLists_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_HistoryLists_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE TABLE [PersonalMovies] (
        [Id] nvarchar(450) NOT NULL,
        [Poster] varbinary(max) NOT NULL,
        [MovieLink] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [UploadDate] datetime2 NOT NULL,
        [UserId] nvarchar(450) NOT NULL,
        [MovieId] nvarchar(450) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [LastModifiedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_PersonalMovies] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_PersonalMovies_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_PersonalMovies_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE TABLE [Rooms] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [MovieUrl] nvarchar(max) NOT NULL,
        [PosterUrl] nvarchar(max) NOT NULL,
        [UserId] nvarchar(450) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [LastModifiedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Rooms] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Rooms_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE TABLE [WatchLists] (
        [Id] nvarchar(450) NOT NULL,
        [UserId] nvarchar(450) NOT NULL,
        [MovieId] nvarchar(450) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [LastModifiedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_WatchLists] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_WatchLists_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_WatchLists_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE INDEX [IX_AspNetUsers_RoomId] ON [AspNetUsers] ([RoomId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE INDEX [IX_Comments_MovieId] ON [Comments] ([MovieId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE INDEX [IX_Comments_UserId] ON [Comments] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE INDEX [IX_HistoryLists_MovieId] ON [HistoryLists] ([MovieId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE INDEX [IX_HistoryLists_UserId] ON [HistoryLists] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE UNIQUE INDEX [IX_PersonalMovies_MovieId] ON [PersonalMovies] ([MovieId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE INDEX [IX_PersonalMovies_UserId] ON [PersonalMovies] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE UNIQUE INDEX [IX_ProffesionalMovies_MovieId] ON [ProffesionalMovies] ([MovieId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE INDEX [IX_Ratings_MovieId] ON [Ratings] ([MovieId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE INDEX [IX_Ratings_ProffesionalMovieId] ON [Ratings] ([ProffesionalMovieId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE INDEX [IX_Rooms_UserId] ON [Rooms] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE INDEX [IX_WatchLists_MovieId] ON [WatchLists] ([MovieId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    CREATE INDEX [IX_WatchLists_UserId] ON [WatchLists] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    ALTER TABLE [AspNetUserClaims] ADD CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    ALTER TABLE [AspNetUserLogins] ADD CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    ALTER TABLE [AspNetUserRoles] ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_Rooms_RoomId] FOREIGN KEY ([RoomId]) REFERENCES [Rooms] ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708164245_initialize'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240708164245_initialize', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708181520_mig_1'
)
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Firstname] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708181520_mig_1'
)
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Lastname] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240708181520_mig_1'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240708181520_mig_1', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240712205328_mig_2'
)
BEGIN
    ALTER TABLE [WatchLists] DROP CONSTRAINT [FK_WatchLists_Movies_MovieId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240712205328_mig_2'
)
BEGIN
    DROP INDEX [IX_WatchLists_UserId] ON [WatchLists];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240712205328_mig_2'
)
BEGIN
    DROP INDEX [IX_HistoryLists_UserId] ON [HistoryLists];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240712205328_mig_2'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[WatchLists]') AND [c].[name] = N'MovieId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [WatchLists] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [WatchLists] ALTER COLUMN [MovieId] nvarchar(450) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240712205328_mig_2'
)
BEGIN
    CREATE TABLE [MovieItem] (
        [Id] nvarchar(450) NOT NULL,
        [MovieId] nvarchar(450) NOT NULL,
        [WatchListId] nvarchar(450) NULL,
        [HistoryListId] nvarchar(450) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [LastModifiedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_MovieItem] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_MovieItem_HistoryLists_HistoryListId] FOREIGN KEY ([HistoryListId]) REFERENCES [HistoryLists] ([Id]),
        CONSTRAINT [FK_MovieItem_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_MovieItem_WatchLists_WatchListId] FOREIGN KEY ([WatchListId]) REFERENCES [WatchLists] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240712205328_mig_2'
)
BEGIN
    CREATE TABLE [UserTokens] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Token] nvarchar(max) NOT NULL,
        [ExpireTime] datetime2 NOT NULL,
        [UserId] nvarchar(450) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [LastModifiedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_UserTokens] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240712205328_mig_2'
)
BEGIN
    CREATE UNIQUE INDEX [IX_WatchLists_UserId] ON [WatchLists] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240712205328_mig_2'
)
BEGIN
    CREATE UNIQUE INDEX [IX_HistoryLists_UserId] ON [HistoryLists] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240712205328_mig_2'
)
BEGIN
    CREATE INDEX [IX_MovieItem_HistoryListId] ON [MovieItem] ([HistoryListId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240712205328_mig_2'
)
BEGIN
    CREATE INDEX [IX_MovieItem_MovieId] ON [MovieItem] ([MovieId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240712205328_mig_2'
)
BEGIN
    CREATE INDEX [IX_MovieItem_WatchListId] ON [MovieItem] ([WatchListId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240712205328_mig_2'
)
BEGIN
    CREATE UNIQUE INDEX [IX_UserTokens_UserId] ON [UserTokens] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240712205328_mig_2'
)
BEGIN
    ALTER TABLE [WatchLists] ADD CONSTRAINT [FK_WatchLists_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240712205328_mig_2'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240712205328_mig_2', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240713065156_mig_3'
)
BEGIN
    DROP INDEX [IX_UserTokens_UserId] ON [UserTokens];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240713065156_mig_3'
)
BEGIN
    CREATE INDEX [IX_UserTokens_UserId] ON [UserTokens] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240713065156_mig_3'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240713065156_mig_3', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240725221840_mig_4'
)
BEGIN
    ALTER TABLE [HistoryLists] DROP CONSTRAINT [FK_HistoryLists_Movies_MovieId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240725221840_mig_4'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[HistoryLists]') AND [c].[name] = N'MovieId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [HistoryLists] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [HistoryLists] ALTER COLUMN [MovieId] nvarchar(450) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240725221840_mig_4'
)
BEGIN
    ALTER TABLE [HistoryLists] ADD CONSTRAINT [FK_HistoryLists_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240725221840_mig_4'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240725221840_mig_4', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240725222108_mig_5'
)
BEGIN
    ALTER TABLE [HistoryLists] DROP CONSTRAINT [FK_HistoryLists_Movies_MovieId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240725222108_mig_5'
)
BEGIN
    ALTER TABLE [WatchLists] DROP CONSTRAINT [FK_WatchLists_Movies_MovieId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240725222108_mig_5'
)
BEGIN
    DROP INDEX [IX_WatchLists_MovieId] ON [WatchLists];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240725222108_mig_5'
)
BEGIN
    DROP INDEX [IX_HistoryLists_MovieId] ON [HistoryLists];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240725222108_mig_5'
)
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[WatchLists]') AND [c].[name] = N'MovieId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [WatchLists] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [WatchLists] DROP COLUMN [MovieId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240725222108_mig_5'
)
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[HistoryLists]') AND [c].[name] = N'MovieId');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [HistoryLists] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [HistoryLists] DROP COLUMN [MovieId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240725222108_mig_5'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240725222108_mig_5', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    ALTER TABLE [Ratings] DROP CONSTRAINT [FK_Ratings_ProffesionalMovies_ProffesionalMovieId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DROP INDEX [IX_Ratings_ProffesionalMovieId] ON [Ratings];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ratings]') AND [c].[name] = N'ProffesionalMovieId');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Ratings] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Ratings] DROP COLUMN [ProffesionalMovieId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'Actors');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [Actors];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'Awards');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [Awards];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'BoxOffice');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [BoxOffice];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'Country');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [Country];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'DVD');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [DVD];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'Director');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [Director];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'Genre');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [Genre];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'Language');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [Language];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'Metascore');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [Metascore];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'Plot');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [Plot];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'Poster');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [Poster];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'Production');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [Production];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'Rated');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [Rated];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'Released');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [Released];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'Response');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [Response];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'Runtime');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [Runtime];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'Type');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [Type];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'Website');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [Website];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'Writer');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [Writer];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var24 sysname;
    SELECT @var24 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'Year');
    IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var24 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [Year];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var25 sysname;
    SELECT @var25 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'imdbID');
    IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var25 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [imdbID];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var26 sysname;
    SELECT @var26 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'imdbRating');
    IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var26 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [imdbRating];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    DECLARE @var27 sysname;
    SELECT @var27 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProffesionalMovies]') AND [c].[name] = N'imdbVotes');
    IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [ProffesionalMovies] DROP CONSTRAINT [' + @var27 + '];');
    ALTER TABLE [ProffesionalMovies] DROP COLUMN [imdbVotes];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240727214541_mig_6'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240727214541_mig_6', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240806002143_mig_7'
)
BEGIN
    ALTER TABLE [Movies] ADD [Categories] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240806002143_mig_7'
)
BEGIN
    ALTER TABLE [Movies] ADD [Runtime] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240806002143_mig_7'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240806002143_mig_7', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240812213022_mig_8'
)
BEGIN
    ALTER TABLE [ProffesionalMovies] ADD [VideoUrl] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240812213022_mig_8'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240812213022_mig_8', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240818122459_mig_9'
)
BEGIN
    ALTER TABLE [PersonalMovies] ADD [IsPublished] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240818122459_mig_9'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240818122459_mig_9', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240823150216_mig_10'
)
BEGIN
    EXEC sp_rename N'[ProffesionalMovies].[VideoUrl]', N'TRDublaj', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240823150216_mig_10'
)
BEGIN
    ALTER TABLE [ProffesionalMovies] ADD [MultipleUrl] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240823150216_mig_10'
)
BEGIN
    ALTER TABLE [ProffesionalMovies] ADD [TRAltyazi] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240823150216_mig_10'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240823150216_mig_10', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240826143225_mig_11'
)
BEGIN
    ALTER TABLE [Movies] ADD [Poster] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240826143225_mig_11'
)
BEGIN
    ALTER TABLE [Movies] ADD [Rating] float NOT NULL DEFAULT 0.0E0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240826143225_mig_11'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240826143225_mig_11', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240829103006_mig_12'
)
BEGIN
    ALTER TABLE [Movies] ADD [Year] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240829103006_mig_12'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240829103006_mig_12', N'8.0.6');
END;
GO

COMMIT;
GO

