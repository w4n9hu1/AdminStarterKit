# AdminStarterKit

## Install Mysql in Docker

`docker run --name d-mysql -p 3306:3306 -e MYSQL_ROOT_PASSWORD=my-secret-pw -d mysql:latest`

## EF

```
Add-Migration InitialCreate
Update-Database
```
## Refers:

[Is the repository pattern useful with Entity Framework Core?](https://www.thereformedprogrammer.net/is-the-repository-pattern-useful-with-entity-framework-core/)