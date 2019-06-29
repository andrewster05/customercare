# Customer Care

## OBJECTIVE
- Write a .Net Core application with login and registration for users.
- Application should have a customer’s table (Firstname, Lastname, Email, DateofBirth, ZipCode, Country, CreatedDate, SystemRole) in addition to the users table.
- Users with admin role should able to CRUD customers.
- Once admins login, they should go to customer list page which has search, page and sort (Use stored procedure).
- Users should be able to view/edit their own profile.

## RUN
- run in the PM Console: "dotnet ef database update -c ApplicationDbContext"
- execute all sql scripts in the Sql > Scripts location

## LOGIN
- look in the appsettings.json for the administrator credentials
- additional users created through the registration will not be adminstrators. 

HAVE FUN!
