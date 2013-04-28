
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/28/2013 16:54:19
-- Generated from EDMX file: C:\Users\Desarrollo\Documents\GitHub\Entrecine8\EntrecineWebApp\Models\EntrecineModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EntrecineDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PeliculaFavoritas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FavoritasConjunto] DROP CONSTRAINT [FK_PeliculaFavoritas];
GO
IF OBJECT_ID(N'[dbo].[FK_FavoritasUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FavoritasConjunto] DROP CONSTRAINT [FK_FavoritasUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_DescuentoSesion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SesionConjunto] DROP CONSTRAINT [FK_DescuentoSesion];
GO
IF OBJECT_ID(N'[dbo].[FK_SesionPelicula]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SesionConjunto] DROP CONSTRAINT [FK_SesionPelicula];
GO
IF OBJECT_ID(N'[dbo].[FK_SesionReserva]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReservaConjunto] DROP CONSTRAINT [FK_SesionReserva];
GO
IF OBJECT_ID(N'[dbo].[FK_ReservaUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReservaConjunto] DROP CONSTRAINT [FK_ReservaUsuario];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ReservaConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReservaConjunto];
GO
IF OBJECT_ID(N'[dbo].[UsuarioConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioConjunto];
GO
IF OBJECT_ID(N'[dbo].[PeliculaConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PeliculaConjunto];
GO
IF OBJECT_ID(N'[dbo].[SesionConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SesionConjunto];
GO
IF OBJECT_ID(N'[dbo].[DescuentoConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DescuentoConjunto];
GO
IF OBJECT_ID(N'[dbo].[FavoritasConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FavoritasConjunto];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ReservaConjunto'
CREATE TABLE [dbo].[ReservaConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Sala] int  NOT NULL,
    [Fila] int  NOT NULL,
    [Columna] int  NOT NULL,
    [SesionId] int  NOT NULL,
    [Usuario_Id] int  NOT NULL
);
GO

-- Creating table 'UsuarioConjunto'
CREATE TABLE [dbo].[UsuarioConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Apellidos] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Administrador] bit  NOT NULL
);
GO

-- Creating table 'PeliculaConjunto'
CREATE TABLE [dbo].[PeliculaConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Precio] float  NOT NULL,
    [Duracion] int  NOT NULL
);
GO

-- Creating table 'SesionConjunto'
CREATE TABLE [dbo].[SesionConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Fecha] time  NOT NULL,
    [DescuentoId] int  NOT NULL,
    [Pelicula_Id] int  NOT NULL
);
GO

-- Creating table 'DescuentoConjunto'
CREATE TABLE [dbo].[DescuentoConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Porcentaje] float  NOT NULL
);
GO

-- Creating table 'FavoritasConjunto'
CREATE TABLE [dbo].[FavoritasConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Pelicula_Id] int  NOT NULL,
    [Usuario_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ReservaConjunto'
ALTER TABLE [dbo].[ReservaConjunto]
ADD CONSTRAINT [PK_ReservaConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsuarioConjunto'
ALTER TABLE [dbo].[UsuarioConjunto]
ADD CONSTRAINT [PK_UsuarioConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PeliculaConjunto'
ALTER TABLE [dbo].[PeliculaConjunto]
ADD CONSTRAINT [PK_PeliculaConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SesionConjunto'
ALTER TABLE [dbo].[SesionConjunto]
ADD CONSTRAINT [PK_SesionConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DescuentoConjunto'
ALTER TABLE [dbo].[DescuentoConjunto]
ADD CONSTRAINT [PK_DescuentoConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FavoritasConjunto'
ALTER TABLE [dbo].[FavoritasConjunto]
ADD CONSTRAINT [PK_FavoritasConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Pelicula_Id] in table 'FavoritasConjunto'
ALTER TABLE [dbo].[FavoritasConjunto]
ADD CONSTRAINT [FK_PeliculaFavoritas]
    FOREIGN KEY ([Pelicula_Id])
    REFERENCES [dbo].[PeliculaConjunto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PeliculaFavoritas'
CREATE INDEX [IX_FK_PeliculaFavoritas]
ON [dbo].[FavoritasConjunto]
    ([Pelicula_Id]);
GO

-- Creating foreign key on [Usuario_Id] in table 'FavoritasConjunto'
ALTER TABLE [dbo].[FavoritasConjunto]
ADD CONSTRAINT [FK_FavoritasUsuario]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[UsuarioConjunto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FavoritasUsuario'
CREATE INDEX [IX_FK_FavoritasUsuario]
ON [dbo].[FavoritasConjunto]
    ([Usuario_Id]);
GO

-- Creating foreign key on [DescuentoId] in table 'SesionConjunto'
ALTER TABLE [dbo].[SesionConjunto]
ADD CONSTRAINT [FK_DescuentoSesion]
    FOREIGN KEY ([DescuentoId])
    REFERENCES [dbo].[DescuentoConjunto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DescuentoSesion'
CREATE INDEX [IX_FK_DescuentoSesion]
ON [dbo].[SesionConjunto]
    ([DescuentoId]);
GO

-- Creating foreign key on [Pelicula_Id] in table 'SesionConjunto'
ALTER TABLE [dbo].[SesionConjunto]
ADD CONSTRAINT [FK_SesionPelicula]
    FOREIGN KEY ([Pelicula_Id])
    REFERENCES [dbo].[PeliculaConjunto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SesionPelicula'
CREATE INDEX [IX_FK_SesionPelicula]
ON [dbo].[SesionConjunto]
    ([Pelicula_Id]);
GO

-- Creating foreign key on [SesionId] in table 'ReservaConjunto'
ALTER TABLE [dbo].[ReservaConjunto]
ADD CONSTRAINT [FK_SesionReserva]
    FOREIGN KEY ([SesionId])
    REFERENCES [dbo].[SesionConjunto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SesionReserva'
CREATE INDEX [IX_FK_SesionReserva]
ON [dbo].[ReservaConjunto]
    ([SesionId]);
GO

-- Creating foreign key on [Usuario_Id] in table 'ReservaConjunto'
ALTER TABLE [dbo].[ReservaConjunto]
ADD CONSTRAINT [FK_ReservaUsuario]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[UsuarioConjunto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ReservaUsuario'
CREATE INDEX [IX_FK_ReservaUsuario]
ON [dbo].[ReservaConjunto]
    ([Usuario_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------