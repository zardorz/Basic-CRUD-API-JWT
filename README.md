# Basic-CRUD-API-JWT
Simple application, without further validation, to exemplify the use of a CRUD in Anlgular 8 with NetCore API using JWT and session control via database

## Clone or download the application

- Restore package dependnecies NutGet
- build
- Set "DefaultConnection": "Server=BAUER-PC\SQLEXPRESS2017;" inside "appsettings.json" to yoyr Sql Server
- Select "WebApi" projet and RUN (this API dont have any custom/swagger page)
- Set Up DB runing in PMC of VS 2019 dotnet ef database update --context ApiDbContext
- Finally run project