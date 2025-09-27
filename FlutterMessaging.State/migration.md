Run migration

dotnet ef migrations add pluralize_tables --project FlutterMessaging.State --startup-project FlutterMessaging.API
dotnet ef migrations script --idempotent -o Migrations/pluralize_tables.sql --project FlutterMessaging.State --startup-project FlutterMessaging.API


apply to docker pod 
--windows--
$cid = docker compose ps -q db
Get-Content -Raw .\Migrations\pluralize_tables.sql | docker exec -i $cid psql -U peter -d messagingdb

--unix--
docker exec -i $(docker compose ps -q db) psql -U peter -d messagingdb < Migrations/pluralize_tables.sql
