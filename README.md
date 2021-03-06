# TIAE5 DB Mini

## The the SQL Server ready for the project
1. Open SQL Server Management Studio and log in with an admin user
2. Run the file `SQL/CreateDatabase.sql` to create the database
3. Run the file `SQL/CreateLogin.sql` to create a user with access to that database

## Generate the migrations from Visual Studio
1. Open the project in visual studio
2. In the top menu, select Tools > NuGet Package Manager > Package Manager console
3. Execute the following commands
  * `EntityFrameworkCore\Add-Migration TIAE5_DB_Mini.Models.AppContext`
  * `EntityFrameworkCore\Update-Database`
