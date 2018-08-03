
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/24/2018 19:21:01
-- Generated from EDMX file: C:\Users\Gabriel\source\repos\ActivosFijo\ActivosFijo\Models\ActivodaFijoContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Activos_Fijo];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Activos_F__Depar__534D60F1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Activos_Fijos] DROP CONSTRAINT [FK__Activos_F__Depar__534D60F1];
GO
IF OBJECT_ID(N'[dbo].[FK__Activos_F__Tipos__5441852A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Activos_Fijos] DROP CONSTRAINT [FK__Activos_F__Tipos__5441852A];
GO
IF OBJECT_ID(N'[dbo].[FK__Calculo_D__Activ__5812160E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Calculo_Depreciacion] DROP CONSTRAINT [FK__Calculo_D__Activ__5812160E];
GO
IF OBJECT_ID(N'[dbo].[FK__Empleados__Depar__4F7CD00D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empleados] DROP CONSTRAINT [FK__Empleados__Depar__4F7CD00D];
GO
IF OBJECT_ID(N'[dbo].[FK__Empleados__Tipo___5070F446]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empleados] DROP CONSTRAINT [FK__Empleados__Tipo___5070F446];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Activos_Fijos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Activos_Fijos];
GO
IF OBJECT_ID(N'[dbo].[Calculo_Depreciacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Calculo_Depreciacion];
GO
IF OBJECT_ID(N'[dbo].[Departamentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departamentos];
GO
IF OBJECT_ID(N'[dbo].[Tipo_Persona]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tipo_Persona];
GO
IF OBJECT_ID(N'[dbo].[Tipos_Activos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tipos_Activos];
GO
IF OBJECT_ID(N'[dbo].[Empleados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empleados];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Activos_Fijos'
CREATE TABLE [dbo].[Activos_Fijos] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Descripcion] varchar(50)  NOT NULL,
    [Departamento] int  NOT NULL,
    [Tipos_Activos] int  NOT NULL,
    [Fecha_Registro] datetime  NOT NULL,
    [Valor_Compra] int  NOT NULL,
    [Depreciacion_Acumulada] decimal(18,0)  NOT NULL,
    [Desechado] bit  NOT NULL,
    [Periodo] datetime  NULL,
    [Monto_Despreciado] int  NULL
);
GO

-- Creating table 'Calculo_Depreciacion'
CREATE TABLE [dbo].[Calculo_Depreciacion] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Periodo] datetime  NOT NULL,
    [Activo_Fijo] int  NOT NULL,
    [ID_AsientosCont] int  NOT NULL,
    [Fecha_Proceso] datetime  NOT NULL,
    [Monto_Despreciado] int  NOT NULL,
    [Depreciacion_Acum] decimal(18,0)  NOT NULL,
    [Cuenta_Compra] int  NOT NULL,
    [Cuenta_Despreciacion] int  NOT NULL,
    [Desechado] bit  NOT NULL
);
GO

-- Creating table 'Departamentos'
CREATE TABLE [dbo].[Departamentos] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Descripcion] varchar(50)  NOT NULL,
    [Estado] bit  NOT NULL,
    [Desechado] bit  NOT NULL
);
GO

-- Creating table 'Tipo_Persona'
CREATE TABLE [dbo].[Tipo_Persona] (
    [ID] int  NOT NULL,
    [Tipo_Persona1] varchar(10)  NOT NULL
);
GO

-- Creating table 'Tipos_Activos'
CREATE TABLE [dbo].[Tipos_Activos] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Descripcion] varchar(50)  NOT NULL,
    [Contable_Compra] int  NOT NULL,
    [Contable_Depreciacion] int  NOT NULL,
    [Estado] bit  NOT NULL,
    [Desechado] bit  NOT NULL
);
GO

-- Creating table 'Empleados'
CREATE TABLE [dbo].[Empleados] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(100)  NOT NULL,
    [Cedula] varchar(13)  NOT NULL,
    [Departamento] int  NOT NULL,
    [Tipo_Persona] int  NOT NULL,
    [Fecha_Ingreso] datetime  NOT NULL,
    [Estado] bit  NOT NULL,
    [Desechado] bit  NOT NULL,
    [Username] varchar(50)  NULL,
    [Password] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Activos_Fijos'
ALTER TABLE [dbo].[Activos_Fijos]
ADD CONSTRAINT [PK_Activos_Fijos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Calculo_Depreciacion'
ALTER TABLE [dbo].[Calculo_Depreciacion]
ADD CONSTRAINT [PK_Calculo_Depreciacion]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Departamentos'
ALTER TABLE [dbo].[Departamentos]
ADD CONSTRAINT [PK_Departamentos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tipo_Persona'
ALTER TABLE [dbo].[Tipo_Persona]
ADD CONSTRAINT [PK_Tipo_Persona]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tipos_Activos'
ALTER TABLE [dbo].[Tipos_Activos]
ADD CONSTRAINT [PK_Tipos_Activos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Empleados'
ALTER TABLE [dbo].[Empleados]
ADD CONSTRAINT [PK_Empleados]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Departamento] in table 'Activos_Fijos'
ALTER TABLE [dbo].[Activos_Fijos]
ADD CONSTRAINT [FK__Activos_F__Depar__534D60F1]
    FOREIGN KEY ([Departamento])
    REFERENCES [dbo].[Departamentos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Activos_F__Depar__534D60F1'
CREATE INDEX [IX_FK__Activos_F__Depar__534D60F1]
ON [dbo].[Activos_Fijos]
    ([Departamento]);
GO

-- Creating foreign key on [Tipos_Activos] in table 'Activos_Fijos'
ALTER TABLE [dbo].[Activos_Fijos]
ADD CONSTRAINT [FK__Activos_F__Tipos__5441852A]
    FOREIGN KEY ([Tipos_Activos])
    REFERENCES [dbo].[Tipos_Activos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Activos_F__Tipos__5441852A'
CREATE INDEX [IX_FK__Activos_F__Tipos__5441852A]
ON [dbo].[Activos_Fijos]
    ([Tipos_Activos]);
GO

-- Creating foreign key on [Activo_Fijo] in table 'Calculo_Depreciacion'
ALTER TABLE [dbo].[Calculo_Depreciacion]
ADD CONSTRAINT [FK__Calculo_D__Activ__5812160E]
    FOREIGN KEY ([Activo_Fijo])
    REFERENCES [dbo].[Activos_Fijos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Calculo_D__Activ__5812160E'
CREATE INDEX [IX_FK__Calculo_D__Activ__5812160E]
ON [dbo].[Calculo_Depreciacion]
    ([Activo_Fijo]);
GO

-- Creating foreign key on [Departamento] in table 'Empleados'
ALTER TABLE [dbo].[Empleados]
ADD CONSTRAINT [FK__Empleados__Depar__4F7CD00D]
    FOREIGN KEY ([Departamento])
    REFERENCES [dbo].[Departamentos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Empleados__Depar__4F7CD00D'
CREATE INDEX [IX_FK__Empleados__Depar__4F7CD00D]
ON [dbo].[Empleados]
    ([Departamento]);
GO

-- Creating foreign key on [Tipo_Persona] in table 'Empleados'
ALTER TABLE [dbo].[Empleados]
ADD CONSTRAINT [FK__Empleados__Tipo___5070F446]
    FOREIGN KEY ([Tipo_Persona])
    REFERENCES [dbo].[Tipo_Persona]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Empleados__Tipo___5070F446'
CREATE INDEX [IX_FK__Empleados__Tipo___5070F446]
ON [dbo].[Empleados]
    ([Tipo_Persona]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------