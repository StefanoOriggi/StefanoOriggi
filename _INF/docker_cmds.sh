docker run --name WebServer1 -p 8085:80 --mount type=bind,source=/Users/origgi/Documents/SCUOLA/INF/webserver_prova,target=/usr/local/apache2/htdocs/ httpd:2.4

docker run -d --name mariadb1 --hostname mariadb1 -p 3306:3306 -v volume_mariadb:/var/lib/mysql --env MARIADB_ROOT_PASSWORD=root mariadb

docker run -d --network dbnetwork --name mariadb2 --env MARIADB_USER=userprova --env MARIADB_PASSWORD=user --env MARIADB_ROOT_PASSWORD=root mariadb

docker run -it --network dbnetwork --rm mariadb mariadb -h mariadb -u userprova -p

docker run --name phpmyadmin --network dbnetwork -d --link mariadb:db -p 8080:80 --rm phpmyadmin
