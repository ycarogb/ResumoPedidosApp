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

CREATE TABLE [CLIENTE] (
    [Id] int NOT NULL IDENTITY,
    [Nome] VARCHAR(50) NOT NULL,
    [Bairro] VARCHAR(50) NOT NULL,
    CONSTRAINT [PK_CLIENTE] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [RESUMOPEDIDO] (
    [Id] int NOT NULL IDENTITY,
    [IdCliente] INT NOT NULL,
    [ValorTotal] DECIMAL(5,2) NOT NULL,
    CONSTRAINT [PK_RESUMOPEDIDO] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [PRODUTO] (
    [Id] int NOT NULL IDENTITY,
    [Descricao] VARCHAR(100) NOT NULL,
    [Valor] DECIMAL(5,2) NOT NULL,
    [ResumoPedidoId] int NOT NULL,
    CONSTRAINT [PK_PRODUTO] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PRODUTO_RESUMOPEDIDO_ResumoPedidoId] FOREIGN KEY ([ResumoPedidoId]) REFERENCES [RESUMOPEDIDO] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_PRODUTO_ResumoPedidoId] ON [PRODUTO] ([ResumoPedidoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231224033237_CriacaoNovaTabelaResumoPedido7', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [PRODUTO] DROP CONSTRAINT [FK_PRODUTO_RESUMOPEDIDO_ResumoPedidoId];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PRODUTO]') AND [c].[name] = N'ResumoPedidoId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [PRODUTO] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [PRODUTO] ALTER COLUMN [ResumoPedidoId] int NULL;
GO

ALTER TABLE [PRODUTO] ADD CONSTRAINT [FK_PRODUTO_RESUMOPEDIDO_ResumoPedidoId] FOREIGN KEY ([ResumoPedidoId]) REFERENCES [RESUMOPEDIDO] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240116234502_Retira chave estrangeira da tabela PRODUTO', N'6.0.0');
GO

COMMIT;
GO

