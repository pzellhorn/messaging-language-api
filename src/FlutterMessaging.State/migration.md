
# --Windows --
# Run migration in root (/API/FlutterMessagingApi/src/) 

$Name     = "messagingendpoints"
$Project  = "FlutterMessaging.State"
$Startup  = "FlutterMessaging.API"
$Context  = "FlutterMessaging.State.Data.MessagingDbContext"
$OutDir   = Join-Path $Project "Migrations"
$OutFile  = Join-Path $OutDir "$Name.sql"
New-Item -ItemType Directory -Force -Path $OutDir | Out-Null

dotnet ef migrations add $Name `
  --project $Project `
  --startup-project $Startup `
  --context $Context `
&& dotnet ef migrations script --idempotent `
  -o $OutFile `
  --project $Project `
  --startup-project $Startup `
  --context $Context


# --Windows --
# apply to docker pod, in the src folder:  

$composeDir = Resolve-Path (Join-Path $Project 'database')
Push-Location $composeDir.Path
$cid = docker compose ps -q db
Get-Content -Raw (Join-Path ..\Migrations "$Name.sql") | docker exec -i $cid psql -U peter -d messagingdb
Pop-Location

 
--unix--
docker exec -i $(docker compose ps -q db) psql -U peter -d messagingdb < ../Migrations/pluralize_tables.sql
