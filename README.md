# InstructorsList Application Test Assignment
## Requirements
1. .NET Core Runtime `~2.2.6`
2. .NET Core SDK `~2.2.108`
3. Microsoft SQL Server 2017
4. NodeJS `~12.9.1`
5. NPM `~6.11.3`
## Building & running
1. Correctly setup connection string to database in `appsettings.json`. **NOTE!** Your MS SQL Server user must have `dbcreator` server role.  

In the root of repo:

2. Run Angular development server:
```
$ cd ClientApp
$ ng serve
```

3. Run backend:
```
$ dotnet run
```

