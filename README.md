# TIAE5 DB Mini

## Project setup
### 1. Get the SQL Server ready for the project
* Open SQL Server Management Studio and log in with an admin user
* Run the sql script below to create the user and database required
* Make sure your Server accepts SQL Server account logins
  * Right click server, select Properties > Security > Server authentication
  * Select "SQL Server and Windows authentication* 

```sql
-- Create an administrative user to create and migrate the
-- database. Alternatively, adjust the conenction string in
-- appsettings.json and use your local admin
CREATE LOGIN Grundbuchamt WITH PASSWORD = 'IBZ2021?';
GO
CREATE USER Grundbuchamt FOR LOGIN Grundbuchamt;
GO
exec sp_addsrvrolemember [Grundbuchamt], sysadmin;
GO

-- Create database for case study
CREATE DATABASE Grundbuchamt;
```

### 2. Generate the database from Visual Studio
* Open the project in Visual Studio
* In the top menu, select Tools > NuGet Package Manager > Package Manager console
* Execute the following command to set up and populate database
  * `EntityFrameworkCore\Update-Database`

### 3. Create users for runtime and grant them permissions
For a transparent setup to the administrator, we decided not to include permissions in the automated database migrations. Run the following with the user created above or your sysadmin to set up logins and users with access to the database.

```sql
USE Grundbuchamt;
GO

-- Create external user for people inquiring about buildings
CREATE LOGIN TIAE5DT_Externer WITH PASSWORD = 'IBZ2022';
GO
CREATE USER TIAE5DT_Externer FOR LOGIN TIAE5DT_Externer;
GO
GRANT SELECT ON beteiligtes TO TIAE5DT_Externer;
GRANT SELECT ON eigentuemer TO TIAE5DT_Externer;
GRANT SELECT ON gefaehrdungs TO TIAE5DT_Externer;
GRANT SELECT ON grundbuchamt TO TIAE5DT_Externer;
GRANT SELECT ON mitarbeiter TO TIAE5DT_Externer;
GRANT SELECT ON objekts TO TIAE5DT_Externer;
GRANT SELECT ON BeteiligteObjekt TO TIAE5DT_Externer;

-- Create internal user for employees of the department
CREATE LOGIN TIAE5DT_Interner WITH PASSWORD = 'IBZ2022';
GO
CREATE USER TIAE5DT_Interner FOR LOGIN TIAE5DT_Interner;
GO
GRANT SELECT, INSERT, UPDATE ON beteiligtes TO TIAE5DT_Interner;
GRANT SELECT, INSERT ON eigentuemer TO TIAE5DT_Interner;
GRANT SELECT, INSERT, DELETE ON gefaehrdungs TO TIAE5DT_Interner;
GRANT SELECT, INSERT ON grundbuchamt TO TIAE5DT_Interner;
GRANT SELECT ON mitarbeiter TO TIAE5DT_Interner;
GRANT SELECT, INSERT, UPDATE ON objekts TO TIAE5DT_Interner;
GRANT SELECT, INSERT, DELETE ON BeteiligteObjekt TO TIAE5DT_Interner;
```

### 4. Start the project
* Go back to visual studio and run the project
  * If you are using the express installation of SQL Server, change the `"server=.` to `"server=.\\SQLEXPRESS` in the project's `appsettings.json`.

---

## Additional notes

### Re-generating migrations during development
* Execute the following command in the NuGet console to re-generate migrations
  * `EntityFrameworkCore\Add-Migration TIAE5_DB_Mini.Models.AppContext`

### Using different database credentials
If you are using a different database connection string locally, do not commit these changes to the repository. To be very sure, just ignore changes to the appsettings locally (`git update-index --assume-unchanged TIAE5-DB-Mini/appsettings.json`)

### See all available resources
If you want to see all available resources, please visit go to the following URL Path: `<hostname>/`

You should see an output like this:

![](https://i.imgur.com/mZ4o5Jp.png)

For getting the actual routes for each resource, consult the Postman Collection.
