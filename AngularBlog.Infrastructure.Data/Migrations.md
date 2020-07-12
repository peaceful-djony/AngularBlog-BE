#MySql:
##add
set DB_TYPE=MySQL  
dotnet ef migrations add InitialCreate_MySQL -s AngularBlog.API -p AngularBlog.Infrastructure.Data --context MySqlDbContext --output-dir Migrations/MySql
##DB apply
dotnet ef database update -s AngularBlog.API -p AngularBlog.Infrastructure.Data --context MySqlDbContext
##remove
dotnet ef migrations remove -s AngularBlog.API -p AngularBlog.Infrastructure.Data --context MySqlDbContext
##cleanup
dotnet ef database update 0 -s AngularBlog.API -p AngularBlog.Infrastructure.Data --context MySqlDbContext

#Oracle:
##add
set DB_TYPE=Oracle  
dotnet ef migrations add InitialCreate_Oracle -s AngularBlog.API -p AngularBlog.Infrastructure.Data --context OracleDbContext --output-dir Migrations/Oracle
##DB apply
dotnet ef database update -s AngularBlog.API -p AngularBlog.Infrastructure.Data --context OracleDbContext
##remove
dotnet ef migrations remove -s AngularBlog.API -p AngularBlog.Infrastructure.Data --context OracleDbContext
##cleanup
dotnet ef database update 0 -s AngularBlog.API -p AngularBlog.Infrastructure.Data --context OracleDbContext
