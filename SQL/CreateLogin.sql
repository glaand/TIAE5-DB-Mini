CREATE LOGIN Grundbuchamt
    WITH PASSWORD = 'IBZ2021?';
GO

CREATE USER Grundbuchamt FOR LOGIN Grundbuchamt;
GO

exec sp_addsrvrolemember [Grundbuchamt], sysadmin;
GO