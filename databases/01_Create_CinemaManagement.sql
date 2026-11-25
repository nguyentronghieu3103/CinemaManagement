
USE [master];
GO

IF DB_ID(N'CinemaManagement') IS NULL
BEGIN
    EXEC(N'CREATE DATABASE [CinemaManagement];');
    PRINT N'Đã tạo database CinemaManagement.';
END
ELSE
BEGIN
    PRINT N'Database CinemaManagement đã tồn tại.';
END;
GO
