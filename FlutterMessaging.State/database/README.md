**Running PostgreSQL database using Docker Compose**

Windows:  
1\. Start postgres pod
docker compose up -d

2\. apply schema to running database using **Powershell**
2\.1 $cid = docker compose ps -q db

2\.2 Wait for pod to finish starting
do {
$status = docker inspect -f "{{.State.Health.Status}}" $cid
  if ($status -ne "healthy") { Start-Sleep -Seconds 1 }
} while ($status -ne "healthy")
 

Copy-paste script (step 1 & 2) - run in **Powershell**:
docker compose up -d
$cid = docker compose ps -q db
do {
$status = docker inspect -f "{{.State.Health.Status}}" $cid
  if ($status -ne "healthy") { Start-Sleep -Seconds 1 }
} while ($status -ne "healthy") 


Warning: Do not "docker compose down -v", the state is currently ephemeral and this will wipe the database

**Confirm all tables are loaded** 

$cid = docker compose ps -q db
docker exec -it $cid psql -U peter -d messagingdb -c "SELECT version();"
docker exec -it $cid psql -U peter -d messagingdb -c "\dt"

expected output should list all tables loaded into postgreSQL database


**Confirm data exists in table**
$cid = docker compose ps -q db
docker exec -it $cid psql -U peter -d messagingdb -c "SELECT * FROM profiles LIMIT 10;"



MacOS/Linux
1\. Start postgres pod
docker compose up -d

    2\. apply schema to running database
    docker exec -i $(docker compose ps -q db) psql -U peter -d messagingdb < messaging_schema.sql



