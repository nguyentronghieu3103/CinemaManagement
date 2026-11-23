/*
========================================================================================
   STORYLINE CINEMA MANAGEMENT & BOOKING SYSTEM
   FILE 01: KHỞI TẠO CƠ SỞ DỮ LIỆU (DATABASE CREATION)
========================================================================================
*/

USE master;
GO

-- 1. Kiểm tra và tạo Cơ sở dữ liệu CinemaManagementDb
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'CinemaManagementDb')
BEGIN
    CREATE DATABASE CinemaManagementDb
    COLLATE Vietnamese_CI_AS;
    PRINT N'>> Tạo cơ sở dữ liệu CinemaManagementDb thành công.';
END
ELSE
BEGIN
    PRINT N'>> Cơ sở dữ liệu CinemaManagementDb đã tồn tại.';
END
GO

-- 2. Cấu hình các tham số môi trường tối ưu cho CSDL
ALTER DATABASE CinemaManagementDb SET ANSI_NULL_DEFAULT ON;
ALTER DATABASE CinemaManagementDb SET ANSI_NULLS ON;
ALTER DATABASE CinemaManagementDb SET ANSI_PADDING ON;
ALTER DATABASE CinemaManagementDb SET ANSI_WARNINGS ON;
ALTER DATABASE CinemaManagementDb SET ARITHABORT ON;
ALTER DATABASE CinemaManagementDb SET CONCAT_NULL_YIELDS_NULL ON;
ALTER DATABASE CinemaManagementDb SET QUOTED_IDENTIFIER ON;
ALTER DATABASE CinemaManagementDb SET NUMERIC_ROUNDABORT OFF;
GO

USE CinemaManagementDb;
GO

PRINT N'>> [01_create_database.sql] Hoàn tất kết nối CSDL CinemaManagementDb!';
GO
