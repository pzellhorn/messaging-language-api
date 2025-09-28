Run migration in /src/

dotnet ef migrations add init_tables --project FlutterMessaging.State --startup-project FlutterMessaging.API
dotnet ef migrations script --idempotent -o FlutterMessaging.State/Migrations/init_tables.sql --project FlutterMessaging.State --startup-project FlutterMessaging.API


apply to docker pod, in database folder
--windows--
$cid = docker compose ps -q db
Get-Content -Raw ..\Migrations\init_tables.sql | docker exec -i $cid psql -U peter -d messagingdb



--unix--
docker exec -i $(docker compose ps -q db) psql -U peter -d messagingdb < ../Migrations/pluralize_tables.sql
