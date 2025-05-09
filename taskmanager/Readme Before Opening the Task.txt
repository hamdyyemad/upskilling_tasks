&&**This task was created by using VS Code Editor and dotnet tool**&&

1) Firstly, to get the connection string locally

 - run the query:

select
    'data source=' + @@servername +
    ';initial catalog=' + db_name() +
    case type_desc
        when 'WINDOWS_LOGIN' 
            then ';trusted_connection=true'
        else
            ';user id=' + suser_name() + ';password=<<YourPassword>>'
    end
    as ConnectionString
from sys.server_principals
where name = suser_name()


Then you'll get something like:
data source=ATLAS-CB38B4CQ0;initial catalog=taskManagerDB;trusted_connection=true

You should add "TrustServerCertificate=True;" to the end to be:
data source=ATLAS-CB38B4CQ0;initial catalog=taskManagerDB;trusted_connection=true;TrustServerCertificate=True;

The connection string will be:
"DefaultConnection": "data source=ATLAS-CB38B4CQ0;initial catalog=taskManagerDB;trusted_connection=true;TrustServerCertificate=True;"
-------------------------------------------------------------------------------------------------------------------------------------

2) Secondly, you should run Swagger to be able to test the APIs
http://localhost:5013/swagger/index.html
