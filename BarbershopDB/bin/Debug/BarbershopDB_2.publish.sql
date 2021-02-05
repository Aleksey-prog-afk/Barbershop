/*
Скрипт развертывания для BarbershopDB

Этот код был создан программным средством.
Изменения, внесенные в этот файл, могут привести к неверному выполнению кода и будут потеряны
в случае его повторного формирования.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "BarbershopDB"
:setvar DefaultFilePrefix "BarbershopDB"
:setvar DefaultDataPath "C:\Users\Alexey\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\Alexey\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Проверьте режим SQLCMD и отключите выполнение скрипта, если режим SQLCMD не поддерживается.
Чтобы повторно включить скрипт после включения режима SQLCMD выполните следующую инструкцию:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Для успешного выполнения этого скрипта должен быть включен режим SQLCMD.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Выполняется удаление ограничение без названия для [dbo].[Orders]...';


GO
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK__Orders__ClientId__300424B4];


GO
PRINT N'Выполняется удаление ограничение без названия для [dbo].[OrderDetails]...';


GO
ALTER TABLE [dbo].[OrderDetails] DROP CONSTRAINT [FK__OrderDeta__Maste__2E1BDC42];


GO
PRINT N'Выполняется удаление ограничение без названия для [dbo].[OrderDetails]...';


GO
ALTER TABLE [dbo].[OrderDetails] DROP CONSTRAINT [FK__OrderDeta__Order__2D27B809];


GO
PRINT N'Выполняется удаление ограничение без названия для [dbo].[OrderDetails]...';


GO
ALTER TABLE [dbo].[OrderDetails] DROP CONSTRAINT [FK__OrderDeta__Servi__2F10007B];


GO
PRINT N'Выполняется запуск перестройки таблицы [dbo].[Administrators]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Administrators] (
    [Id]       INT        IDENTITY (1, 1) NOT NULL,
    [Name]     NCHAR (50) NULL,
    [Phone]    NCHAR (10) NULL,
    [Login]    NCHAR (10) NULL,
    [Password] NCHAR (10) NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Администратор1] PRIMARY KEY CLUSTERED ([Id] ASC) ON [PRIMARY]
) ON [PRIMARY];

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Administrators])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Administrators] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Administrators] ([Id], [Name], [Phone], [Login], [Password])
        SELECT   [Id],
                 [Name],
                 [Phone],
                 [Login],
                 [Password]
        FROM     [dbo].[Administrators]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Administrators] OFF;
    END

DROP TABLE [dbo].[Administrators];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Administrators]', N'Administrators';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Администратор1]', N'PK_Администратор', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Выполняется запуск перестройки таблицы [dbo].[Clients]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Clients] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (50) NULL,
    [Phone] NVARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC) ON [PRIMARY]
) ON [PRIMARY];

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Clients])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Clients] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Clients] ([Id], [Name], [Phone])
        SELECT   [Id],
                 [Name],
                 [Phone]
        FROM     [dbo].[Clients]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Clients] OFF;
    END

DROP TABLE [dbo].[Clients];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Clients]', N'Clients';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Выполняется запуск перестройки таблицы [dbo].[Masters]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Masters] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NULL,
    [Phone]      NVARCHAR (10) NULL,
    [WorkBegins] TIME (7)      NULL,
    [WorkEnds]   TIME (7)      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC) ON [PRIMARY]
) ON [PRIMARY];

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Masters])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Masters] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Masters] ([Id], [Name], [Phone], [WorkBegins], [WorkEnds])
        SELECT   [Id],
                 [Name],
                 [Phone],
                 [WorkBegins],
                 [WorkEnds]
        FROM     [dbo].[Masters]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Masters] OFF;
    END

DROP TABLE [dbo].[Masters];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Masters]', N'Masters';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Выполняется запуск перестройки таблицы [dbo].[Orders]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Orders] (
    [Id]       INT      IDENTITY (1, 1) NOT NULL,
    [ClientId] INT      NULL,
    [Date]     DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC) ON [PRIMARY]
) ON [PRIMARY];

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Orders])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Orders] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Orders] ([Id], [ClientId], [Date])
        SELECT   [Id],
                 [ClientId],
                 [Date]
        FROM     [dbo].[Orders]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Orders] OFF;
    END

DROP TABLE [dbo].[Orders];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Orders]', N'Orders';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Выполняется запуск перестройки таблицы [dbo].[Services]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Services] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Title] NVARCHAR (50)  NULL,
    [Price] NUMERIC (5, 2) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC) ON [PRIMARY]
) ON [PRIMARY];

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Services])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Services] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Services] ([Id], [Title], [Price])
        SELECT   [Id],
                 [Title],
                 [Price]
        FROM     [dbo].[Services]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Services] OFF;
    END

DROP TABLE [dbo].[Services];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Services]', N'Services';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Выполняется создание <Без имени>...';


GO
ALTER TABLE [dbo].[Orders] WITH NOCHECK
    ADD FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id]);


GO
PRINT N'Выполняется создание <Без имени>...';


GO
ALTER TABLE [dbo].[OrderDetails] WITH NOCHECK
    ADD FOREIGN KEY ([MasterId]) REFERENCES [dbo].[Masters] ([Id]);


GO
PRINT N'Выполняется создание <Без имени>...';


GO
ALTER TABLE [dbo].[OrderDetails] WITH NOCHECK
    ADD FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]);


GO
PRINT N'Выполняется создание <Без имени>...';


GO
ALTER TABLE [dbo].[OrderDetails] WITH NOCHECK
    ADD FOREIGN KEY ([ServiceId]) REFERENCES [dbo].[Services] ([Id]);


GO
PRINT N'Существующие данные проверяются относительно вновь созданных ограничений';


GO
USE [$(DatabaseName)];


GO
CREATE TABLE [#__checkStatus] (
    id           INT            IDENTITY (1, 1) PRIMARY KEY CLUSTERED,
    [Schema]     NVARCHAR (256),
    [Table]      NVARCHAR (256),
    [Constraint] NVARCHAR (256)
);

SET NOCOUNT ON;

DECLARE tableconstraintnames CURSOR LOCAL FORWARD_ONLY
    FOR SELECT SCHEMA_NAME([schema_id]),
               OBJECT_NAME([parent_object_id]),
               [name],
               0
        FROM   [sys].[objects]
        WHERE  [parent_object_id] IN (OBJECT_ID(N'dbo.Orders'), OBJECT_ID(N'dbo.OrderDetails'))
               AND [type] IN (N'F', N'C')
                   AND [object_id] IN (SELECT [object_id]
                                       FROM   [sys].[check_constraints]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0
                                       UNION
                                       SELECT [object_id]
                                       FROM   [sys].[foreign_keys]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0);

DECLARE @schemaname AS NVARCHAR (256);

DECLARE @tablename AS NVARCHAR (256);

DECLARE @checkname AS NVARCHAR (256);

DECLARE @is_not_trusted AS INT;

DECLARE @statement AS NVARCHAR (1024);

BEGIN TRY
    OPEN tableconstraintnames;
    FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
    WHILE @@fetch_status = 0
        BEGIN
            PRINT N'Проверка ограничения: ' + @checkname + N' [' + @schemaname + N'].[' + @tablename + N']';
            SET @statement = N'ALTER TABLE [' + @schemaname + N'].[' + @tablename + N'] WITH ' + CASE @is_not_trusted WHEN 0 THEN N'CHECK' ELSE N'NOCHECK' END + N' CHECK CONSTRAINT [' + @checkname + N']';
            BEGIN TRY
                EXECUTE [sp_executesql] @statement;
            END TRY
            BEGIN CATCH
                INSERT  [#__checkStatus] ([Schema], [Table], [Constraint])
                VALUES                  (@schemaname, @tablename, @checkname);
            END CATCH
            FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
        END
END TRY
BEGIN CATCH
    PRINT ERROR_MESSAGE();
END CATCH

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') >= 0
    CLOSE tableconstraintnames;

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') = -1
    DEALLOCATE tableconstraintnames;

SELECT N'Ошибка при проверке ограничения:' + [Schema] + N'.' + [Table] + N',' + [Constraint]
FROM   [#__checkStatus];

IF @@ROWCOUNT > 0
    BEGIN
        DROP TABLE [#__checkStatus];
        RAISERROR (N'Произошла ошибка при проверке ограничений', 16, 127);
    END

SET NOCOUNT OFF;

DROP TABLE [#__checkStatus];


GO
PRINT N'Обновление завершено.';


GO
