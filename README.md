# TIAE5 DB Mini

## The the SQL Server ready for the project
* Open SQL Server Management Studio and log in with an admin user
* Run the following command to create a database to work on
  * `CREATE DATABASE Grundbuchamt;`
* Run the following commands to create a user and login to access the database
  * Use `GO` in between these commands or run them separately!
  * `CREATE LOGIN Grundbuchamt WITH PASSWORD = 'IBZ2021?';`
  * `CREATE USER Grundbuchamt FOR LOGIN Grundbuchamt;`
  * `exec sp_addsrvrolemember [Grundbuchamt], sysadmin;`
* Make sure your Server accepts SQL Server account logins
  * Right click server, select Properties > Security > Server authentication
  * Select "SQL Server and Windows authentication* 

## Generate the database from Visual Studio
* Open the project in visual studio
* In the top menu, select Tools > NuGet Package Manager > Package Manager console
* Execute the following command to set up and populate database
  * `EntityFrameworkCore\Update-Database`
* Execute the following command to re-generate migrations (only for development)
  * `EntityFrameworkCore\Add-Migration TIAE5_DB_Mini.Models.AppContext`

## Using different database credentials
If you are using a different database connection string locally, do not commit these changes to the repository. To be very sure, just ignore changes to the appsettings locally (`git update-index --assume-unchanged TIAE5-DB-Mini/appsettings.json`)

## See all available routes
If you want to see all available routes, please visit go to the following URL Path:

`<hostname>/`

You should see something like this:
![](https://i.imgur.com/mZ4o5Jp.png)