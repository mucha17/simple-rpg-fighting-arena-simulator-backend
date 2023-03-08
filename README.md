# simple-rpg-fighting-arena-simulator-backend
Simple RPG Fighting Arena - Backend

# Project Description
A simple fighting arena simulator for RPG games. It’s goal is to reduce time players need to spend on an RPG game, by simulating fights, so GM doesn’t have to do them manually.
# Backend usage
1. Run `MS Server Express`, create database, set database user (e.g. `docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=P@ssword" -e "MSSQL_PID=Express" -p 1433:1433 --name=development-sql-server -v //c/Users/User/Workspace/docker_mounts/development_sql_server:/var/opt/mssql/data -d mcr.microsoft.com/mssql/server:2022-latest`) and configure the connection string in `appsettings.json`.
2. Run migrations to create database structure with `dotnet ef database update`.
3. Start backend with `dotnet watch run`.
4. Open Swagger with browser at location `http://localhost:5096/swagger/index.html`.
5. Register an account and log in.
6. Create characters, provide them with weapon and spells.
7. Start a fight (`POST` on `/Fight`)
8. View Highscore (`GET` on `/Fight`)
# TODO
1. Add validation.
1. Replace the temporary fighting mechanism with better implementation.
2. Create a frontend.

