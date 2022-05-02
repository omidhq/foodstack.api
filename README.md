# Foodstack


### What?
This is an experimental project called Foodstack that suggests recipes based on given ingredients. It's essentially an app that helps you to decide *what to cook with what you have in your fridge*. 
This repository is the backend API for Foodstack app. To see the client side code (Nextjs + TailwindCSS) please check out [the frontend repository](https://github.com/omidhq/foodstack.client). 

### Why?
This web api was developed as part of a graduation project at [**SALT, School of Applied Technology - Stockholm**](https://salt.dev/).

### How?
**Backend:**
- [ASP.NET Core Web API 6.0](https://docs.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/)
- [SqlServer](https://www.microsoft.com/en-us/sql-server/)
- [Spoonacular API](https://spoonacular.com/food-api)

**Frontend:**
- [Next.JS](https://nextjs.org/) *--typescript*
- [Tailwind CSS](https://tailwindcss.com/)

### Who?
- [Leon Jardevall](https://github.com/Hypergolix)
- [Mathias Viklund](https://github.com/MoatShrimp)
- [Omid Haqbin](https://github.com/omidhq)

## Development

### Starting the database

```bash
docker-compose up -d
```

This will start the database. The first time you run this command it will take about 1-5 minutes. But then it will be lightning fast.

The credentials for the `sa`-account is found in the `docker-compose.yml`-file.

Once the `docker-compose` command has finished you can use Azure Data Studio (should also be installed on your computers) to access the database with those credentials.

### Shutting the database down

Note the `-d` in the command above. This means that the docker container will run in the background. You can see it through the Docker client but other than that it's hidden.

But you want to shut the database down. This can be done through:

```bash
docker stop sql-server-db
```

Note that the database is held in the container so when you shut it down the data is gone.

### WEB API

In order to run the api, first off, you need to restore the dependencies:
```
dotnet restore
```
Then you need to have have an api key from Spoonacular and set it up as a secret: 
```
dotnet user-secrets init
dotnet user-secrets set "SpoonacularApiKey" "<yourAPIKey>"
```
Then run the API
```
dotnet restore
dotnet run
```

Happy hacking! :)