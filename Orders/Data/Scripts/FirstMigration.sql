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

CREATE TABLE [Customers] (
    [Id] bigint NOT NULL IDENTITY,
    [Name] VARCHAR(100) NOT NULL,
    [Phone] CHAR(11) NOT NULL,
    [PostalCode] CHAR(8) NOT NULL,
    [City] nvarchar(60) NOT NULL,
    [State] CHAR(2) NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Products] (
    [Id] bigint NOT NULL IDENTITY,
    [BarCode] VARCHAR(14) NOT NULL,
    [Description] VARCHAR(60) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [ProductType] nvarchar(max) NOT NULL,
    [Active] bit NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Orders] (
    [Id] bigint NOT NULL IDENTITY,
    [CustomerId] bigint NOT NULL,
    [StartDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    [FinishDate] datetime2 NOT NULL,
    [DeliveryType] int NOT NULL,
    [OrderStatus] nvarchar(max) NOT NULL,
    [Comments] VARCHAR(500) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [OrderItems] (
    [Id] bigint NOT NULL IDENTITY,
    [OrderId] bigint NOT NULL,
    [ProductId] bigint NOT NULL,
    [Quantity] int NOT NULL DEFAULT 1,
    [Price] decimal(18,2) NOT NULL,
    [Discount] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_OrderItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);
GO

CREATE NONCLUSTERED INDEX [IX_Customer_Phone] ON [Customers] ([Phone]);
GO

CREATE INDEX [IX_OrderItems_OrderId] ON [OrderItems] ([OrderId]);
GO

CREATE INDEX [IX_OrderItems_ProductId] ON [OrderItems] ([ProductId]);
GO

CREATE INDEX [IX_Orders_CustomerId] ON [Orders] ([CustomerId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220123230701_FirstMigration', N'6.0.1');
GO

COMMIT;
GO

