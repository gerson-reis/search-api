# search-api
The application is builded with code-first so, to start app in your machine os server you'll need only an connectionstring
to a new sql server database.

steps:
1 - Create a sql server database
2 - Take sql server database connection string
3 - Open search-api solution and go to search-api project to alter appsetting.json
4 - Set DefaultConnection with the connection string
5 - Start project, when the project run the same will apply migrations to create tables in database.
5 - Enjoiy