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

CREATE TABLE [Doctors] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Specializatuon] nvarchar(max) NOT NULL,
    [Salary] decimal(18,2) NOT NULL,
    [PerformanceRate] int NOT NULL,
    CONSTRAINT [PK_Doctors] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'PerformanceRate', N'Salary', N'Specializatuon') AND [object_id] = OBJECT_ID(N'[Doctors]'))
    SET IDENTITY_INSERT [Doctors] ON;
INSERT INTO [Doctors] ([Id], [Name], [PerformanceRate], [Salary], [Specializatuon])
VALUES ('0ecfbf4a-43cb-43e3-bc1d-f65311329923', N'Joann', 72, 9232.0, N'Hematology'),
('1eba0d36-22ba-4947-855d-f2d5f4bafa10', N'Rafael', 97, 12266.0, N'Pediatrics'),
('2925724d-fd2e-4358-bc5e-e4a2af0fcd57', N'Mable', 5, 33706.0, N'Infectious Disease'),
('61547fa3-fdf4-46f4-be21-b02186b206e9', N'Sara', 82, 45041.0, N'Pediatrics'),
('66dd89dc-8c74-4f32-a498-683ae86fb9f2', N'Judy', 32, 18711.0, N'Neurology'),
('7e614007-0646-47db-8294-256a136bb54f', N'Jessie', 65, 27064.0, N'Hematology'),
('807c4fcd-4c2e-49af-85b1-d23b02fe0bb6', N'Alyssa', 79, 16586.0, N'Gastroenterology'),
('ac8829b9-ecef-4b39-a8b4-be25c563c9ab', N'Paula', 0, 19094.0, N'Urology'),
('b18ed37d-cd76-4b61-ba9d-4e44ae45b719', N'Judy', 19, 48498.0, N'Dermatology'),
('eb9ef91d-7500-401f-bfcf-4d3af0f9ec13', N'Naomi', 27, 32145.0, N'Pediatrics');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'PerformanceRate', N'Salary', N'Specializatuon') AND [object_id] = OBJECT_ID(N'[Doctors]'))
    SET IDENTITY_INSERT [Doctors] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230610121342_Initial', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DELETE FROM [Doctors]
WHERE [Id] = '0ecfbf4a-43cb-43e3-bc1d-f65311329923';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Doctors]
WHERE [Id] = '1eba0d36-22ba-4947-855d-f2d5f4bafa10';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Doctors]
WHERE [Id] = '2925724d-fd2e-4358-bc5e-e4a2af0fcd57';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Doctors]
WHERE [Id] = '61547fa3-fdf4-46f4-be21-b02186b206e9';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Doctors]
WHERE [Id] = '66dd89dc-8c74-4f32-a498-683ae86fb9f2';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Doctors]
WHERE [Id] = '7e614007-0646-47db-8294-256a136bb54f';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Doctors]
WHERE [Id] = '807c4fcd-4c2e-49af-85b1-d23b02fe0bb6';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Doctors]
WHERE [Id] = 'ac8829b9-ecef-4b39-a8b4-be25c563c9ab';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Doctors]
WHERE [Id] = 'b18ed37d-cd76-4b61-ba9d-4e44ae45b719';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Doctors]
WHERE [Id] = 'eb9ef91d-7500-401f-bfcf-4d3af0f9ec13';
SELECT @@ROWCOUNT;

GO

CREATE TABLE [Issues] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Issues] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Patients] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [DoctorId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Patients] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Patients_Doctors_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [Doctors] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [IssuePatient] (
    [IssuesId] uniqueidentifier NOT NULL,
    [PatientsId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_IssuePatient] PRIMARY KEY ([IssuesId], [PatientsId]),
    CONSTRAINT [FK_IssuePatient_Issues_IssuesId] FOREIGN KEY ([IssuesId]) REFERENCES [Issues] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_IssuePatient_Patients_PatientsId] FOREIGN KEY ([PatientsId]) REFERENCES [Patients] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'PerformanceRate', N'Salary', N'Specializatuon') AND [object_id] = OBJECT_ID(N'[Doctors]'))
    SET IDENTITY_INSERT [Doctors] ON;
INSERT INTO [Doctors] ([Id], [Name], [PerformanceRate], [Salary], [Specializatuon])
VALUES ('0772f2d5-23ec-4540-a07f-4af793386b7d', N'Sara', 82, 45041.0, N'Pediatrics'),
('375447f8-f75b-4cd7-9129-b0a5d78332dc', N'Naomi', 27, 32145.0, N'Pediatrics'),
('56f86e40-fcd8-4911-900c-7ae1255fc53a', N'Alyssa', 79, 16586.0, N'Gastroenterology'),
('6724a92b-ea27-40c1-adc3-d6667ea07ffc', N'Judy', 32, 18711.0, N'Neurology'),
('9d3c4cbd-3248-47ca-8934-e4315c702e11', N'Judy', 19, 48498.0, N'Dermatology'),
('aa1e6135-fb7e-4649-9016-d8a8f96ce12c', N'Rafael', 97, 12266.0, N'Pediatrics'),
('c74fab27-9d03-43d7-a99c-c5f25ba79987', N'Jessie', 65, 27064.0, N'Hematology'),
('c97a676a-e3ea-4c28-92a2-90f8d0dd521b', N'Joann', 72, 9232.0, N'Hematology'),
('d474b19d-2da7-4249-a946-a4bd73eb1d8d', N'Paula', 0, 19094.0, N'Urology'),
('f413b97d-1de4-4da9-8d2b-c93cea7b66f8', N'Mable', 5, 33706.0, N'Infectious Disease');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'PerformanceRate', N'Salary', N'Specializatuon') AND [object_id] = OBJECT_ID(N'[Doctors]'))
    SET IDENTITY_INSERT [Doctors] OFF;
GO

CREATE INDEX [IX_IssuePatient_PatientsId] ON [IssuePatient] ([PatientsId]);
GO

CREATE INDEX [IX_Patients_DoctorId] ON [Patients] ([DoctorId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230610183025_AddingPatient', N'7.0.5');
GO

COMMIT;
GO

