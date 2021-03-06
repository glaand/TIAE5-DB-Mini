# TIAE5 DB Mini

## The the SQL Server ready for the project
* Open SQL Server Management Studio and log in with an admin user
* Run the file `SQL/CreateDatabase.sql` to create the database
* Run the file `SQL/CreateLogin.sql` to create a user with access to that database
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

`<hostname>/api/`

You should see something like this:
![](https://i.imgur.com/Vldhd0E.png)