**Running PostgreSQL database using Docker Compose**

Windows:  
1\. Start postgres pod
docker compose up -d 

Warning: Do not "docker compose down -v", the state of the docker pod will be wiped. The data will otherwise survive restarts.

**Confirm all tables are loaded** 

$cid = docker compose ps -q db
docker exec -it $cid psql -U peter -d messagingdb -c "SELECT version();"
docker exec -it $cid psql -U peter -d messagingdb -c "\dt"

expected output should list all tables loaded into postgreSQL database


**Confirm data exists in table**
$cid = docker compose ps -q db
docker exec -it $cid psql -U peter -d messagingdb -c "SELECT * FROM external_identities LIMIT 10;"



MacOS/Linux
1\. Start postgres pod
docker compose up -d
 



