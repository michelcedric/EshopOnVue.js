[![Build status](https://github.com/michelcedric/EshopOnVue.js/actions/workflows/dotnet.yml/badge.svg)](https://github.com/michelcedric/EshopOnVue.js/actions/workflows/dotnet.yml)
# EshopOnVue.js

# Database
1. Ensure your connection strings in `appsettings.json` point to a local SQL Server instance.
1. Ensure the tool EF was already installed. You can find some help [here](https://docs.microsoft.com/ef/core/miscellaneous/cli/dotnet)

    ```
    dotnet tool update --global dotnet-ef
    ```

1. Open a command prompt in the Web folder and execute the following commands:

    ``` 
    dotnet ef database update --context EshopContext -p EshopOnVue.js.Infrastructure/EshopOnVue.js.Infrastructure.csproj -s EshopOnVue.js.Spa/EshopOnVue.js.Spa.csproj
  
    ```

    These commands will create two separate databases, one for the store's catalog data and shopping cart information, and one for the app's user credentials and identity data.

1. Run the application.

    The first time you run the application, it will seed both databases with data such that you should see products in the store, and you should be able to log in using the demouser@microsoft.com account.

    Note: If you need to create migrations, you can use these commands:

    ```
    -- create migration (from .sln folder CLI)
    dotnet ef migrations add Basket --context EshopContext -p EshopOnVue.js.Infrastructure/EshopOnVue.js.Infrastructure.csproj -s EshopOnVue.js.Spa/EshopOnVue.js.Spa.csproj -o Data/Migrations
    ```

